using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using Microsoft.FlightSimulator.SimConnect;
using SimConnectWrapper.SimConnectDataType;

namespace SimConnectWrapper
{
    public abstract class SimConnectWrapperBase : ISimConnectWrapper
    {
        private bool _opened = false;

        public DateTime LastDataReceivedOn { get; private set; }

        public Dictionary<SimConnectProperty, SimConnectPropertyValue> LatestData { get; }

        private List<SimConnectProperty> _subscriptions;
        public IEnumerable<SimConnectProperty> Subscriptions => _subscriptions;

        public SimConnectWrapperBase()
        {
            _subscriptions = new List<SimConnectProperty>();
            LastDataReceivedOn = DateTime.UtcNow.AddYears(-100);
            LatestData = new Dictionary<SimConnectProperty, SimConnectPropertyValue>();
        }

        /// <summary>
        /// When implemented in a derived class, creates the instance of SimConnect
        /// appropriatly for that implementation
        /// </summary>
        protected abstract SimConnect CreateSimConnect();

        /// <summary>
        /// When implemented in a derived class returns the 
        /// Synchronization object used for the internal timer
        /// </summary>
        /// <remarks>This controls the thread it executes the method on</remarks>
        protected abstract ISynchronizeInvoke GetSynchronizationObject();

        private Timer StartTimer()
        {
            Timer timer = new Timer();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += GetData;
            timer.SynchronizingObject = GetSynchronizationObject();
            timer.Start();

            return timer;
        }

        private void GetData(object sender, EventArgs e)
        {
            try
            {
                var connection = GetConnection();

                if (!_opened) { return; }

                foreach (var property in Subscriptions)
                {
                    Sim.RequestDataOnSimObjectType(property.Key, property.Key, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                }
            }
            catch (Exception ex)
            {
                if (Sim != null)
                {
                    Sim.Dispose();
                    Sim = null;
                }

                OnError?.Invoke(this, ex);
            }
        }

        private SimConnect GetConnection()
        {
            if (Sim == null)
            {
                Sim = CreateSimConnect();
                Sim.OnRecvOpen += SimConnect_OnRecvOpen;
                Sim.OnRecvSimobjectDataBytype += SimConnect_OnRecvSimobjectDataBytype;
            }

            return Sim;
        }

        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            foreach (var property in Subscriptions)
            {
                Sim.AddToDataDefinition(property.Key, property.Name, property.Unit, property.SimConnectDataType, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                if (property.SimConnectDataType == SIMCONNECT_DATATYPE.STRING64)
                {
                    Sim.RegisterDataDefineStruct<String64>(property.Key);
                }
                else
                {
                    Sim.RegisterDataDefineStruct<double>(property.Key);
                }
            }

            _opened = true;
        }

        private void SimConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            LastDataReceivedOn = DateTime.UtcNow;

            // TODO: Support other data types and structs ...
            var property = Subscriptions.SingleOrDefault(prop => (uint)prop.Key == data.dwRequestID);

            if (!property.IsEmpty)
            {
                LatestData[property] = GetValue(data, property.SimConnectDataType);
            }
        }

        private SimConnectPropertyValue GetValue(SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data, SIMCONNECT_DATATYPE dataType)
        {
            // TODO: Move this method to the constructor of SimConnectPropertyValue
            if (dataType == SIMCONNECT_DATATYPE.STRING8)
            {
                return new SimConnectPropertyValue(((String8)data.dwData[0]).Value);
            }
            else if (dataType == SIMCONNECT_DATATYPE.STRING64)
            {
                return new SimConnectPropertyValue(((String64)data.dwData[0]).Value);
            }
            else
            {
                return new SimConnectPropertyValue(data.dwData[0]);
            }
        }

        public bool HasError => throw new NotImplementedException();

        public Exception LatestError => throw new NotImplementedException();

        public SimConnect Sim { get; private set; }

        public event EventHandler<Exception> OnError;

        public void Subscribe(SimConnectProperty property)
        {
            if (!_subscriptions.Contains(property))
            {
                _subscriptions.Add(property);
            }
        }

        public void Subscribe(IEnumerable<SimConnectProperty> properties)
        {
            foreach(var property in properties) { Subscribe(property); }
        }
    }
}
