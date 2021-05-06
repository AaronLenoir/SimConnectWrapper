using Microsoft.FlightSimulator.SimConnect;

namespace SimConnectWrapper
{
    /// <summary>
    /// Standard implemented SimConnect properties
    /// </summary>
    /// <remarks>Based on the MSFS SDK documentation, some variables may be missing or not available</remarks>
    public class SimConnectProperties
    {
        // See SDK Documentation: Content Configuration > Variable Lists > Simulation Variables

        // Aircraft Autopilot Data
        /// <summary>
        /// Airspeed hold active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotAirspeedHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAirspeedHold, "AUTOPILOT AIRSPEED HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected airspeed (knots)
        /// </summary>
        public static SimConnectProperty AutopilotAirspeedHoldVar = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAirspeedHoldVar, "AUTOPILOT AIRSPEED HOLD VAR", "knots", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Altitude hole active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotAltitudeLock = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAltitudeLock, "AUTOPILOT ALTITUDE LOCK", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected altitude (feet)
        /// </summary>
        public static SimConnectProperty AutopilotAltitudeLockVar = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAltitudeLockVar, "AUTOPILOT ALTITUDE LOCK VAR", "feet", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotAltitudeSlotIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAltitudeSlotIndex, "AUTOPILOT ALTITUDE SLOT INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Approach mode active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotApproachHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotApproachHold, "AUTOPILOT APPROACH HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Attitude hold active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotAttitudeHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAttitudeHold, "AUTOPILOT ATTITUDE HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Available flag (bool)
        /// </summary>
        public static SimConnectProperty AutopilotAvailable = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotAvailable, "AUTOPILOT AVAILABLE", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Back course mode active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotBackcourseHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotBackcourseHold, "AUTOPILOT BACKCOURSE HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Bank Mode Active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotBankHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotBankHold, "AUTOPILOT BANK HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Whether or not the autopilot has been disengaged. (bool)
        /// </summary>
        public static SimConnectProperty AutopilotDisengaged = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotDisengaged, "AUTOPILOT DISENGAGED", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Flight director active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotFlightDirectorActive = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotFlightDirectorActive, "AUTOPILOT FLIGHT DIRECTOR ACTIVE", "bool", SIMCONNECT_DATATYPE.INT32
        );
        /// <summary>
        /// Reference bank angle (radians)
        /// </summary>
        public static SimConnectProperty AutopilotFlightDirectorBank = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotFlightDirectorBank, "AUTOPILOT FLIGHT DIRECTOR BANK", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Raw reference bank angle (radians)
        /// </summary>
        public static SimConnectProperty AutopilotFlightDirectorBankEx1 = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotFlightDirectorBankEx1, "AUTOPILOT FLIGHT DIRECTOR BANK EX1", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Reference pitch angle (radians)
        /// </summary>
        public static SimConnectProperty AutopilotFlightDirectorPitch = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotFlightDirectorPitch, "AUTOPILOT FLIGHT DIRECTOR PITCH", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Raw reference pitch angle (radians)
        /// </summary>
        public static SimConnectProperty AutopilotFlightDirectorPitchEx1 = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotFlightDirectorPitchEx1, "AUTOPILOT FLIGHT DIRECTOR PITCH EX1", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// GS hold active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotGlideslopeHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotGlideslopeHold, "AUTOPILOT GLIDESLOPE HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Heading mode active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotHeadingLock = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotHeadingLock, "AUTOPILOT HEADING LOCK", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected heading (degrees)
        /// </summary>
        public static SimConnectProperty AutopilotHeadingLockDir = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotHeadingLockDir, "AUTOPILOT HEADING LOCK DIR", "degrees", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotHeadingSlotIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotHeadingSlotIndex, "AUTOPILOT HEADING SLOT INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Mach hold active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotMachHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotMachHold, "AUTOPILOT MACH HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected mach (number)
        /// </summary>
        public static SimConnectProperty AutopilotMachHoldVar = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotMachHoldVar, "AUTOPILOT MACH HOLD VAR", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotManagedIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotManagedIndex, "AUTOPILOT MANAGED INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Is the Managed Speed in Mach (bool)
        /// </summary>
        public static SimConnectProperty AutopilotManagedSpeedInMach = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotManagedSpeedInMach, "AUTOPILOT MANAGED SPEED IN MACH", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Managed Autothrottle active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotManagedThrottleActive = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotManagedThrottleActive, "AUTOPILOT MANAGED THROTTLE ACTIVE", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// On/off flag (bool)
        /// </summary>
        public static SimConnectProperty AutopilotMaster = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotMaster, "AUTOPILOT MASTER", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if autopilot max bank applied (radians)
        /// </summary>
        public static SimConnectProperty AutopilotMaxBank = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotMaxBank, "AUTOPILOT MAX BANK", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// True if autopilot nav1 lock applied (bool)
        /// </summary>
        public static SimConnectProperty AutopilotNav1Lock = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotNav1Lock, "AUTOPILOT NAV1 LOCK", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Index of Nav radio selected (number)
        /// </summary>
        public static SimConnectProperty AutopilotNavSelected = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotNavSelected, "AUTOPILOT NAV SELECTED", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Set to True if the autopilot pitch hold has is engaged. (bool)
        /// </summary>
        public static SimConnectProperty AutopilotPitchHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotPitchHold, "AUTOPILOT PITCH HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Current reference pitch (radians)
        /// </summary>
        public static SimConnectProperty AutopilotPitchHoldRef = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotPitchHoldRef, "AUTOPILOT PITCH HOLD REF", "radians", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// True if autopilot rpm hold applied (bool)
        /// </summary>
        public static SimConnectProperty AutopilotRpmHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotRpmHold, "AUTOPILOT RPM HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected rpm (number)
        /// </summary>
        public static SimConnectProperty AutopilotRpmHoldVar = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotRpmHoldVar, "AUTOPILOT RPM HOLD VAR", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotRpmSlotIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotRpmSlotIndex, "AUTOPILOT RPM SLOT INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotSpeedSlotIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotSpeedSlotIndex, "AUTOPILOT SPEED SLOT INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Takeoff / Go Around power mode active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotTakeoffPowerActive = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotTakeoffPowerActive, "AUTOPILOT TAKEOFF POWER ACTIVE", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Autothrottle armed (bool)
        /// </summary>
        public static SimConnectProperty AutopilotThrottleArm = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotThrottleArm, "AUTOPILOT THROTTLE ARM", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Autothrottle max thrust (float, percent.)
        /// </summary>
        public static SimConnectProperty AutopilotThrottleMaxThrust = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotThrottleMaxThrust, "AUTOPILOT THROTTLE MAX THRUST", "percent", SIMCONNECT_DATATYPE.FLOAT32);
        /// <summary>
        /// True if autopilot vertical hold applied (bool)
        /// </summary>
        public static SimConnectProperty AutopilotVerticalHold = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotVerticalHold, "AUTOPILOT VERTICAL HOLD", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Selected vertical speed (feet/minute)
        /// </summary>
        public static SimConnectProperty AutopilotVerticalHoldVar = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotVerticalHoldVar, "AUTOPILOT VERTICAL HOLD VAR", "feet/minute", SIMCONNECT_DATATYPE.FLOAT32)
        ;
        /// <summary>
        /// Index of the managed references (number)
        /// </summary>
        public static SimConnectProperty AutopilotVsSlotIndex = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotVsSlotIndex, "AUTOPILOT VS SLOT INDEX", "number", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Wing leveler active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotWingLeveler = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotWingLeveler, "AUTOPILOT WING LEVELER", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Yaw damper active (bool)
        /// </summary>
        public static SimConnectProperty AutopilotYawDamper = new SimConnectProperty(
            SimConnectPropertyKey.AutopilotYawDamper, "AUTOPILOT YAW DAMPER", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Auto-throttle active (bool)
        /// </summary>
        public static SimConnectProperty AutothrottleActive = new SimConnectProperty(
            SimConnectPropertyKey.AutothrottleActive, "AUTOTHROTTLE ACTIVE", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// Com [index] Radio Frequency step: 
        ///   0 = 25kHz 
        ///   1 = 8.33kHz (enum)
        /// </summary>
        public static SimConnectProperty ComSpacingMode = new SimConnectProperty(
            SimConnectPropertyKey.ComSpacingMode, "COM SPACING MODE", "enum", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the Elevators and Ailerons computer has failed. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireElacFailed = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireElacFailed, "FLY BY WIRE ELAC FAILED", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the fly by wire Elevators and Ailerons computer is on. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireElacSwitch = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireElacSwitch, "FLY BY WIRE ELAC SWITCH", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the Flight Augmentation computer has failed. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireFacFailed = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireFacFailed, "FLY BY WIRE FAC FAILED", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the fly by wire Flight Augmentation computer is on. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireFacSwitch = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireFacSwitch, "FLY BY WIRE FAC SWITCH", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the Spoilers and Elevators computer has failed. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireSecFailed = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireSecFailed, "FLY BY WIRE SEC FAILED", "bool", SIMCONNECT_DATATYPE.INT32);
        /// <summary>
        /// True if the fly by wire Spoilers and Elevators computer is on. (bool)
        /// </summary>
        public static SimConnectProperty FlyByWireSecSwitch = new SimConnectProperty(
            SimConnectPropertyKey.FlyByWireSecSwitch, "FLY BY WIRE SEC SWITCH", "bool", SIMCONNECT_DATATYPE.INT32);


        // Aircraft engine data
        public static SimConnectProperty NumberOfEngines = new SimConnectProperty(
            SimConnectPropertyKey.NumberOfEngines, "NUMBER OF ENGINES", "number", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty EngineControlSelect = new SimConnectProperty(
            SimConnectPropertyKey.EngineControlSelect, "ENGINE CONTROL SELECT", "mask", SIMCONNECT_DATATYPE.INT32);
        public static SimConnectProperty ThrottleLowerLimit = new SimConnectProperty(
            SimConnectPropertyKey.ThrottleLowerLimit, "THROTTLE LOWER LIMIT", "percent", SIMCONNECT_DATATYPE.FLOAT64);
        // TODO: Support an actual enum as the value instead of a numeric value?
        public static SimConnectProperty EngineType = new SimConnectProperty(
            SimConnectPropertyKey.EngineType, "ENGINE TYPE", "enum", SIMCONNECT_DATATYPE.INT32);
        // TODO: Support an actual bool as the value instead of a numeric value?
        public static SimConnectProperty MasterIgnitionSwitch = new SimConnectProperty(
            SimConnectPropertyKey.MasterIgnitionSwitch, "MASTER IGNITION SWITCH", "bool", SIMCONNECT_DATATYPE.INT32);
        public static SimConnectProperty GeneralEngineCombustion(int index)
        {
            return new SimConnectProperty(
                SimConnectPropertyKey.GeneralEngineCombustion, $"GENERAL ENG COMBUSTION:{index}", "bool", SIMCONNECT_DATATYPE.INT32);
        }

        public static SimConnectProperty PlaneLongitude = new SimConnectProperty(
            SimConnectPropertyKey.PlaneLongitude, "PLANE LONGITUDE", "degree", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty PlaneLatitude = new SimConnectProperty(
            SimConnectPropertyKey.PlaneLatitude, "PLANE LATITUDE", "degree", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty PlaneHeadingDegreesTrue = new SimConnectProperty(
            SimConnectPropertyKey.PlaneHeadingDegreesTrue, "PLANE HEADING DEGREES TRUE", "degree", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty PlaneAltitude = new SimConnectProperty(
            SimConnectPropertyKey.PlaneAltitude, "PLANE ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty GpsGroundSpeed = new SimConnectProperty(
            SimConnectPropertyKey.GpsGroundSpeed, "GPS GROUND SPEED", "knots", SIMCONNECT_DATATYPE.FLOAT64);
        public static SimConnectProperty AtcId = new SimConnectProperty(
            SimConnectPropertyKey.AtcId, "ATC ID", "", SIMCONNECT_DATATYPE.STRING64);
        public static SimConnectProperty AtcType = new SimConnectProperty(
            SimConnectPropertyKey.AtcType, "ATC TYPE", "", SIMCONNECT_DATATYPE.STRING64);
    }
}
