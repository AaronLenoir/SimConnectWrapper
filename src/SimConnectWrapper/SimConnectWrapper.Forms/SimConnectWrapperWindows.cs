using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConnectWrapper.Forms
{
    public class SimConnectWrapperWindows : SimConnectWrapperBase
    {
        // ID used to identify the SimConnect message in the Windows Message Loop
        private const int WM_USER_SIMCONNECT = 0x0402;

        private string Title;

        private IntPtr Handle;

        private ISynchronizeInvoke SynchronizationObject;

        public SimConnectWrapperWindows(string title, IntPtr handle, ISynchronizeInvoke synchronizationObject)
        {
            Title = title;
            Handle = handle;
            SynchronizationObject = synchronizationObject;
        }

        protected override SimConnect CreateSimConnect()
        {
            return new SimConnect(Title, Handle, WM_USER_SIMCONNECT, null, 0);
        }

        protected override ISynchronizeInvoke GetSynchronizationObject()
        {
            return SynchronizationObject;
        }
    }
}
