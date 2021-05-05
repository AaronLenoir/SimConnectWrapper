using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimConnectWrapper.Forms
{
    public partial class SimConnectWrapper : Control, ISimConnectWrapper
    {
        private SimConnectWrapperWindows _simConnectWrapper;

        public SimConnectWrapper()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            _simConnectWrapper = new SimConnectWrapperWindows(this.Name, this.Handle, this);
            _simConnectWrapper.Connect();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            //if (_simConnectWrapper != null)
            //{
            //    _simConnectWrapper.HandleWndProc(m.Msg);
            //}
            if (_simConnectWrapper != null && 
                m.Msg == _simConnectWrapper.WM_USER_SIMCONNECT)
            {
                try
                {
                    _simConnectWrapper.ReceiveMessage();
                }
                catch (Exception ex)
                {
                    _simConnectWrapper.RaiseError(ex);
                }
            }

            base.WndProc(ref m);
        }

        public bool HasError => ((ISimConnectWrapper)_simConnectWrapper).HasError;

        public Exception LatestError => ((ISimConnectWrapper)_simConnectWrapper).LatestError;

        public DateTime LastDataReceivedOn => ((ISimConnectWrapper)_simConnectWrapper).LastDataReceivedOn;

        public Dictionary<SimConnectProperty, SimConnectPropertyValue> LatestData => ((ISimConnectWrapper)_simConnectWrapper).LatestData;

        public IEnumerable<SimConnectProperty> Subscriptions => ((ISimConnectWrapper)_simConnectWrapper).Subscriptions;

        public SimConnect Sim => ((ISimConnectWrapper)_simConnectWrapper).Sim;

        public event EventHandler<Exception> OnError
        {
            add
            {
                ((ISimConnectWrapper)_simConnectWrapper).OnError += value;
            }

            remove
            {
                ((ISimConnectWrapper)_simConnectWrapper).OnError -= value;
            }
        }

        public void ReceiveMessage()
        {
            ((ISimConnectWrapper)_simConnectWrapper).ReceiveMessage();
        }

        public void Subscribe(SimConnectProperty property)
        {
            ((ISimConnectWrapper)_simConnectWrapper).Subscribe(property);
        }

        public void Subscribe(IEnumerable<SimConnectProperty> properties)
        {
            ((ISimConnectWrapper)_simConnectWrapper).Subscribe(properties);
        }
    }
}
