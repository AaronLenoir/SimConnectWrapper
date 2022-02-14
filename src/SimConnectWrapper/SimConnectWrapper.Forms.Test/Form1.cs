using System;
using System.Text;
using System.Windows.Forms;

namespace SimConnectWrapper.Forms.Test
{
    public partial class Form1 : Form
    {
        private Timer _timer;

        private readonly SimConnectWrapper _simConnectWrapper;

        public Form1()
        {
            InitializeComponent();

            // Cannot use the visual studio designer due to 64 bit limitations
            _simConnectWrapper = new SimConnectWrapper();
            Controls.Add(_simConnectWrapper);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _simConnectWrapper.Connect();

            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAirspeedHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAirspeedHoldVar);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeLock);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeLockVar);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAltitudeSlotIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotApproachHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAttitudeHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotAvailable);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotBackcourseHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotBankHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotDisengaged);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorActive);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorBank);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorBankEx1);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorPitch);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotFlightDirectorPitchEx1);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotGlideslopeHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingLock);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingLockDir);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotHeadingSlotIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMachHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMachHoldVar);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedSpeedInMach);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotManagedThrottleActive);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMaster);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotMaxBank);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotNav1Lock);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotNavSelected);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotPitchHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotPitchHoldRef);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmHoldVar);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotRpmSlotIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotSpeedSlotIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotTakeoffPowerActive);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotThrottleArm);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotThrottleMaxThrust);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVerticalHold);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVerticalHoldVar);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotVsSlotIndex);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotWingLeveler);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutopilotYawDamper);
            _simConnectWrapper.Subscribe(SimConnectProperties.AutothrottleActive);
            _simConnectWrapper.Subscribe(SimConnectProperties.ComSpacingMode);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireElacFailed);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireElacSwitch);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireFacFailed);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireFacSwitch);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireSecFailed);
            _simConnectWrapper.Subscribe(SimConnectProperties.FlyByWireSecSwitch);

            _simConnectWrapper.Subscribe(SimConnectProperties.NumberOfEngines);
            _simConnectWrapper.Subscribe(SimConnectProperties.EngineControlSelect);
            _simConnectWrapper.Subscribe(SimConnectProperties.EngineType);
            _simConnectWrapper.Subscribe(SimConnectProperties.ThrottleLowerLimit);
            _simConnectWrapper.Subscribe(SimConnectProperties.MasterIgnitionSwitch);
            _simConnectWrapper.Subscribe(SimConnectProperties.GeneralEngineCombustion(1));
            _simConnectWrapper.Subscribe(SimConnectProperties.AtcType);

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
                lblStatusText.Text = $"Error: {_simConnectWrapper.LatestError.Message}";
            } else
            {
                var allData = new StringBuilder();

                foreach(var property in _simConnectWrapper.Subscriptions)
                {
                    var value = _simConnectWrapper.LatestData[property];

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
