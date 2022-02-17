using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SimConnectWrapper.Samples.msfs2skydemon
{
    public partial class Form1 : Form
    {
        private readonly Forms.SimConnectWrapper _simConnectWrapper;

        private Timer _timer;

        public Form1()
        {
            InitializeComponent();

            // Cannot use the visual studio designer due to 64 bit limitations
            _simConnectWrapper = new Forms.SimConnectWrapper();
            Controls.Add(_simConnectWrapper);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _simConnectWrapper.Connect();

            _simConnectWrapper.Subscribe(SimConnectProperties.PlaneLatitude);
            _simConnectWrapper.Subscribe(SimConnectProperties.PlaneLongitude);
            _simConnectWrapper.Subscribe(SimConnectProperties.PlaneAltitude);
            _simConnectWrapper.Subscribe(SimConnectProperties.PlaneHeadingDegreesTrue);
            _simConnectWrapper.Subscribe(SimConnectProperties.GpsGroundSpeed);
            _simConnectWrapper.Subscribe(SimConnectProperties.AtcId);

            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_simConnectWrapper.HasError)
            {
                lblStatus.Text = $"Error: {_simConnectWrapper.LatestError.Message}";
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "Connected";
                lblStatus.ForeColor = Color.Green;

                SendData();
            }
        }

        private void SendData()
        {
            var longitude = _simConnectWrapper.LatestData[SimConnectProperties.PlaneLongitude].DoubleValue;
            var latitude = _simConnectWrapper.LatestData[SimConnectProperties.PlaneLatitude].DoubleValue;
            var altitude = _simConnectWrapper.LatestData[SimConnectProperties.PlaneAltitude].DoubleValue * 0.3048;
            var headingTrue = _simConnectWrapper.LatestData[SimConnectProperties.PlaneHeadingDegreesTrue].DoubleValue;
            var groundSpeed = _simConnectWrapper.LatestData[SimConnectProperties.GpsGroundSpeed].DoubleValue;

            var message = new XgpsMessage(longitude, latitude, altitude, headingTrue, groundSpeed); 

            if (message.Valid)
            {
                try
                {
                    var host = txtHost.Text;
                    if (chkBroadcast.Checked) { host = "255.255.255.255"; }

                    var udpMessage = new UdpMessage(host, 49002, message.Data);
                    udpMessage.Send();

                    lblStatus.Text = $"Data sent at {DateTime.UtcNow}";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error: {ex}";
                    lblStatus.ForeColor = Color.Red;
                }
            }
        }

        private void chkBroadcast_CheckedChanged(object sender, EventArgs e)
        {
            txtHost.Enabled = !chkBroadcast.Checked;
        }
    }
}
