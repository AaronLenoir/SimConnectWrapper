namespace SimConnectWrapper.Samples.msfs2skydemon
{
               // if (longitude.HasValue &&
               // latitude.HasValue &&
               // altitude.HasValue &&
               // headingTrue.HasValue &&
               // groundSpeed.HasValue)

    public class XgpsMessage
    {
        public string Data { get; set; }

        public bool Valid { get; set; }

        public XgpsMessage(double? longitude,
                           double? latitude,
                           double? altitude,
                           double? headerTrue,
                           double? groundSpeed)
        {
            var originalCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            try
            {
                if (longitude.HasValue &&
                    latitude.HasValue &&
                    altitude.HasValue &&
                    headerTrue.HasValue &&
                    groundSpeed.HasValue)
                {
                    Valid = true;
                    Data = $"XGPSMSFS,{longitude:F6},{latitude:F6},{altitude:F1},{headerTrue:F2},{groundSpeed:F6}";
                } else
                {
                    Valid = false;
                }
            }
            catch
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }
    }
}
