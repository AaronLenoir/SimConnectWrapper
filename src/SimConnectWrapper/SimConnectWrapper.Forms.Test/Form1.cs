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

            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAirspeedHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAirspeedHoldVar);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeLock);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeLockVar);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeSlotIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotApproachHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAttitudeHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAvailable);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotBackcourseHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotBankHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotDisengaged);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorActive);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorBank);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorBankEx1);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorPitch);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorPitchEx1);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotGlideslopeHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingLock);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingLockDir);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingSlotIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMachHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMachHoldVar);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedSpeedInMach);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedThrottleActive);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMaster);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMaxBank);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotNav1Lock);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotNavSelected);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotPitchHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotPitchHoldRef);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmHoldVar);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmSlotIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotSpeedSlotIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotTakeoffPowerActive);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotThrottleArm);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotThrottleMaxThrust);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVerticalHold);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVerticalHoldVar);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVsSlotIndex);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotWingLeveler);
            simConnectWrapper.Subscribe(SimConnectProperties.AutopilotYawDamper);
            simConnectWrapper.Subscribe(SimConnectProperties.AutothrottleActive);
            simConnectWrapper.Subscribe(SimConnectProperties.ComSpacingMode);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireElacFailed);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireElacSwitch);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireFacFailed);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireFacSwitch);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireSecFailed);
            simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireSecSwitch);

            simConnectWrapper.Subscribe(SimConnectProperties.NumberOfEngines);
            simConnectWrapper.Subscribe(SimConnectProperties.EngineControlSelect);
            simConnectWrapper.Subscribe(SimConnectProperties.EngineType);
            simConnectWrapper.Subscribe(SimConnectProperties.ThrottleLowerLimit);
            simConnectWrapper.Subscribe(SimConnectProperties.MasterIgnitionSwitch);
            simConnectWrapper.Subscribe(SimConnectProperties.GeneralEngineCombustion(1));
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
