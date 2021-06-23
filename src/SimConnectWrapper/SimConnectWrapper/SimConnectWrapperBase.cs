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

        private List<SimConnectProperty> _subscriptions;
        
        private Timer _connectionPollingTimer;

        private Timer _dataPollingTimer;

        public SimConnectWrapperBase()
        {
            _subscriptions = new List<SimConnectProperty>();
            LastDataReceivedOn = DateTime.UtcNow.AddYears(-100);
            LatestData = new Dictionary<SimConnectProperty, SimConnectPropertyValue>();

            ConnectionPollingInterval = 1000;
            DataPollingInterval = 1000;
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

        private Timer StartConnectionPolling()
        {
            Timer timer = new Timer();

            timer = new Timer();
            timer.Interval = ConnectionPollingInterval;
            timer.Elapsed += PollConnection;
            timer.SynchronizingObject = GetSynchronizationObject();
            timer.Start();

            return timer;
        }

        private Timer StartDataPolling()
        {
            Timer timer = new Timer();

            timer = new Timer();
            timer.Interval = DataPollingInterval;
            timer.Elapsed += PollData;
            timer.SynchronizingObject = GetSynchronizationObject();
            timer.Start();

            return timer;
        }

        /// <summary>
        /// Executed periodically, this function will try to initialize a SimConnect connection
        /// if there isn't one yet
        /// </summary>
        private void PollConnection(object sender, EventArgs e)
        {
            try
            {
                var connection = CreateConnection();
            }
            catch (Exception ex)
            {
                if (Sim != null)
                {
                    Sim.Dispose();
                    Sim = null;
                }

                RaiseError(ex);
            }
        }

        /// <summary>
        /// Executed periodically, this function Requests the data needed from SimConnect.
        /// </summary>
        private void PollData(object sender, EventArgs e)
        {
            if (!_opened) { return; }

            foreach (var property in Subscriptions)
            {
                Sim.RequestDataOnSimObjectType(property.Key, property.Key, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
            }
        }

        /// <summary>
        /// If not done yet, creates a new SimConnect object and hooks in the necessary events
        /// </summary>
        private SimConnect CreateConnection()
        {
            if (Sim == null)
            {
                Sim = CreateSimConnect();
                Sim.OnRecvOpen += SimConnect_OnRecvOpen;
                Sim.OnRecvSimobjectDataBytype += SimConnect_OnRecvSimobjectDataBytype;
            }

            return Sim;
        }

        /// <summary>
        /// Handler for the OnRecvOpen event, where the necessary data structure registrations with SimConnect
        /// can be done
        /// </summary>
        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            foreach (var property in Subscriptions)
            {
                Sim.AddToDataDefinition(property.Key, property.Name, property.Unit, property.SimConnectDataType, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                if (property.SimConnectDataType == SIMCONNECT_DATATYPE.STRING64)
                {
                    Sim.RegisterDataDefineStruct<String64>(property.Key);
                }
                else if (property.SimConnectDataType == SIMCONNECT_DATATYPE.FLOAT32)
                {
                    Sim.RegisterDataDefineStruct<double>(property.Key);
                }
                else if (property.SimConnectDataType == SIMCONNECT_DATATYPE.FLOAT64)
                {
                    Sim.RegisterDataDefineStruct<double>(property.Key);
                }
                else if (property.SimConnectDataType == SIMCONNECT_DATATYPE.INT32)
                {
                    Sim.RegisterDataDefineStruct<Int32>(property.Key);
                }
                else if (property.SimConnectDataType == SIMCONNECT_DATATYPE.INT64)
                {
                    Sim.RegisterDataDefineStruct<Int64>(property.Key);
                } else
                {
                    Sim.RegisterDataDefineStruct<double>(property.Key);
                }
            }

            _opened = true;

            ClearError();
        }

        /// <summary>
        /// Event Handler when the simulator offers new data, will update LatestData
        /// </summary>
        private void SimConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            LastDataReceivedOn = DateTime.UtcNow;

            // TODO: Support other data types and structs ...
            var property = Subscriptions.SingleOrDefault(prop => (uint)prop.Key == data.dwRequestID);

            if (!property.IsEmpty)
            {
                LatestData[property] = new SimConnectPropertyValue(data, property.SimConnectDataType);
            }

            ClearError();
        }

        public SimConnect Sim { get; private set; }

        public DateTime LastDataReceivedOn { get; private set; }

        public Dictionary<SimConnectProperty, SimConnectPropertyValue> LatestData { get; }

        public IEnumerable<SimConnectProperty> Subscriptions => _subscriptions;

        /// <summary>
        /// Defines the interval by which a connection attempt to SimConnect is attempted
        /// </summary>
        /// <remarks>If set to 0, no polling is done for a connection and PollConnection must be called manually</remarks>
        public int ConnectionPollingInterval { get; set; }

        /// <summary>
        /// Defines the interval by which data is requested from SimConnect
        /// </summary>
        /// <remarks>If set to 0, no polling is done for data and PollData must be called manually</remarks>
        public int DataPollingInterval { get; set; }

        public bool HasError { get; private set; }

        public Exception LatestError { get; private set; }

        public event EventHandler<Exception> OnError;

        /// <summary>
        /// Triggers the retrieval of Information from the Sim, should be executed 
        /// at the appropriate time by the implementers of this Base class
        /// </summary>
        public void ReceiveMessage()
        {
            try
            {
                Sim.ReceiveMessage();
            }
            catch (Exception ex)
            {
                RaiseError(ex);
            }
        }

        public void Subscribe(SimConnectProperty property)
        {
            if (!_subscriptions.Contains(property))
            {
                _subscriptions.Add(property);
                LatestData.Add(property, SimConnectPropertyValue.EmptyValue);
            }
        }

        public void Subscribe(IEnumerable<SimConnectProperty> properties)
        {
            foreach(var property in properties) { Subscribe(property); }
        }

        public void Connect()
        {
            if (ConnectionPollingInterval > 0)
            {
                _connectionPollingTimer = StartConnectionPolling();
            }

            if (DataPollingInterval > 0)
            {
                _dataPollingTimer = StartDataPolling();
            }
        }

        public void PollConnection()
        {
            PollConnection(null, null);
        }

        /// <summary>
        /// Requests the data from SimConnect for all Subscriptions
        /// </summary>
        public void PollData()
        {
            PollData(null, null);
        }

        public void RaiseError(Exception exception)
        {
            HasError = true;
            LatestError = exception;

            OnError?.Invoke(this, exception);
        }

        public void ClearError()
        {
            HasError = false;
            LatestError = null;
        }
    }
}
