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
    public partial class SimConnectWrapper : Control
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
