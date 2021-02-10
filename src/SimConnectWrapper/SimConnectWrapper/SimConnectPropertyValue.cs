namespace SimConnectWrapper
{
    public class SimConnectPropertyValue
    {
        internal SimConnectPropertyValue()
        {
            Empty = true;
        }

        public SimConnectPropertyValue(object value)
        {
            RawValue = value;

            if (value == null) { return; }

            if (value is double) { DoubleValue = (double)value; return; }

            if (value is string) { StringValue = (string)value; return; }
        }

        public bool Empty { get; set; }

        public double? DoubleValue { get; set; }

        public string StringValue { get; set; }

        public object RawValue { get; set; }
    }
}
