﻿using Microsoft.FlightSimulator.SimConnect;

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
        // TODO: Correctly parse the masked value
        public static SimConnectProperty EngineControlSelect = new SimConnectProperty(
            SimConnectPropertyKey.EngineControlSelect, "ENGINE CONTROL SELECT", "mask", SIMCONNECT_DATATYPE.INT32);

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
