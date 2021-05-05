using Microsoft.FlightSimulator.SimConnect;
using System;
using System.ComponentModel;

namespace SimConnectWrapper.Forms
{
    /// <summary>
    /// Implementation of a SimConnectWrapper with Windows Forms Specifics
    /// </summary>
    public class SimConnectWrapperWindows : SimConnectWrapperBase
    {
        // ID used to identify the SimConnect message in the Windows Message Loop
        public uint WM_USER_SIMCONNECT { get { return 0x0402; } }

        private string Title;

        private IntPtr Handle;

        /// <summary>
        /// This object is used by the internal timer in the SimConnectWrapper 
        /// to ensure the events happen on the main application thread
        /// </summary>
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
