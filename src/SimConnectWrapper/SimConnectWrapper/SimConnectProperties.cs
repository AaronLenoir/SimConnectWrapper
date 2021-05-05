using Microsoft.FlightSimulator.SimConnect;

namespace SimConnectWrapper
{
    /// <summary>
    /// Standard implemented SimConnect properties
    /// </summary>
    public class SimConnectProperties
    {
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
