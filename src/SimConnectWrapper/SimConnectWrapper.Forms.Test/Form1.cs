using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimConnectWrapper.Forms.Test
{
    public partial class Form1 : Form
    {
        private Timer _timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simConnectWrapper.Connect();

            simConnectWrapper.Subscribe(SimConnectProperties.PlaneAltitude);

            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (simConnectWrapper.HasError)
            {
                lblStatusText.Text = $"Error: {simConnectWrapper.LatestError.Message}";
            } else
            {
                var altitude = simConnectWrapper.LatestData[SimConnectProperties.PlaneAltitude];
                if (!altitude.Empty)
                {
                    lblAltitude.Text = $"{altitude.DoubleValue} ft";
                    lblStatusText.Text = $"Latest data received on: {simConnectWrapper.LastDataReceivedOn}";
                }
                else
                {
                    lblStatusText.Text = $"No data received, last checked {DateTime.Now}";
                }
            }
        }
    }
}
