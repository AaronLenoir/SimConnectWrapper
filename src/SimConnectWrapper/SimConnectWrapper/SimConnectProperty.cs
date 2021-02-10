using Microsoft.FlightSimulator.SimConnect;
using System;

namespace SimConnectWrapper
{
    public struct SimConnectProperty
    {
        public SimConnectPropertyKey Key { get; }

        public string Name { get; }

        public string Unit { get; }

        public SIMCONNECT_DATATYPE SimConnectDataType { get; }

        public bool IsEmpty => String.IsNullOrEmpty(Name);

        public SimConnectProperty(SimConnectPropertyKey key, string name, string unit, SIMCONNECT_DATATYPE simConnectDataType)
        {
            Key = key;
            Name = name;
            Unit = unit;
            SimConnectDataType = simConnectDataType;
        }

        public bool Equals(SimConnectProperty other)
        {
            return Key == other.Key && Name == other.Name && Unit == other.Unit;
        }

        public override bool Equals(object obj)
        {
            return obj is SimConnectProperty other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Key;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(SimConnectProperty prop1, SimConnectProperty prop2)
        {
            return prop1.Key == prop2.Key &&
                   prop1.Name == prop2.Name &&
                   prop1.Unit == prop2.Unit;
        }

        public static bool operator !=(SimConnectProperty prop1, SimConnectProperty prop2)
        {
            return !(prop1 == prop2);
        }
    }
}
