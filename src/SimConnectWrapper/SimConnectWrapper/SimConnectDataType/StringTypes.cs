using System.Runtime.InteropServices;

namespace SimConnectWrapper.SimConnectDataType
{
    // SimConnect exposes various fixed sized strings which can be
    // marshalled to a .NET String

    public struct String8
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Value;
    }
    public struct String32
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Value;
    }

    public struct String64
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Value;
    }

    public struct String128
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string Value;
    }

    public struct String256
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Value;
    }

    public struct String260
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string Value;
    }
}
