using Microsoft.FlightSimulator.SimConnect;
using SimConnectWrapper.SimConnectDataType;
using System;

namespace SimConnectWrapper
{
    public class SimConnectPropertyValue
    {
        internal SimConnectPropertyValue()
        {
            Empty = true;
        }

        private void SetValue(object value)
        {
            RawValue = value;

            if (value == null) { return; }

            if (value is double) { DoubleValue = (double)value; return; }

            if (value is int) { IntegerValue = (int)value; return; }

            if (value is string) { StringValue = (string)value; return; }
        }

        public static SimConnectPropertyValue EmptyValue
        {
            get
            {
                return new SimConnectPropertyValue();
            }
        }

        public SimConnectPropertyValue(SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data, SIMCONNECT_DATATYPE dataType)
        {
            if (dataType == SIMCONNECT_DATATYPE.STRING8)
            {
                SetValue(((String8)data.dwData[0]).Value);
            }
            else if (dataType == SIMCONNECT_DATATYPE.STRING64)
            {
                SetValue(((String64)data.dwData[0]).Value);
            }
            else
            {
                SetValue(data.dwData[0]);
            }
        }

        public bool Empty { get; set; }

        public double? DoubleValue { get; set; }

        public double? IntegerValue { get; set; }

        public string StringValue { get; set; }

        public object RawValue { get; set; }
    }
}
