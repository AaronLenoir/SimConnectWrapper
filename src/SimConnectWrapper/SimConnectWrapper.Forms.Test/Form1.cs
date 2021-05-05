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

        private SimConnectWrapper simConnectWrapper;

        public Form1()
        {
            InitializeComponent();

            // Cannot use the visual studio designer due to 64 bit limitations
            simConnectWrapper = new SimConnectWrapper();
            Controls.Add(simConnectWrapper);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simConnectWrapper.Connect();

            simConnectWrapper.Subscribe(SimConnectProperties.NumberOfEngines);
            simConnectWrapper.Subscribe(SimConnectProperties.EngineControlSelect);
            simConnectWrapper.Subscribe(SimConnectProperties.AtcId);
            simConnectWrapper.Subscribe(SimConnectProperties.AtcType);
            simConnectWrapper.Subscribe(SimConnectProperties.GpsGroundSpeed);
            simConnectWrapper.Subscribe(SimConnectProperties.PlaneAltitude);
            simConnectWrapper.Subscribe(SimConnectProperties.PlaneHeadingDegreesTrue);
            simConnectWrapper.Subscribe(SimConnectProperties.PlaneLatitude);
            simConnectWrapper.Subscribe(SimConnectProperties.PlaneLongitude);

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
                var allData = new StringBuilder();

                foreach(var property in simConnectWrapper.Subscriptions)
                {
                    var value = simConnectWrapper.LatestData[property];

                    if (!value.Empty)
                    {
                        allData.AppendLine($"{property.Name} ({value.RawValue.GetType().Name}): {value.RawValue}");
                    } else
                    {
                        allData.AppendLine($"{property.Name} (unknown): no data received yet");
                    }
                }

                txtRawValues.Text = allData.ToString();

                lblStatusText.Text = $"Last check for data {DateTime.Now}";
            }
        }
    }
}
