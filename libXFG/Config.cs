using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG
{
    public enum RuntimeType
    {
        Mono,
        Net,
    }
    public enum PlatformType
    {
        Windows,
        Linux,
        Unix,
        OSX,
        Android,
        iOS,
        Unknown,
    }
    public static class Config
    {
        public static RuntimeType Runtime { get; private set; }
        public static PlatformType Platform { get; private set; }
        internal static void Init()
        {

#if ANDROID
            Runtime = RuntimeType.Mono;
            Platform = PlatformType.Android;
#elif IPHONE
            Runtime = RuntimeType.Mono;
            Platform = PlatformType.iOS; 
#else
            Runtime = DetectMono() ? RuntimeType.Mono : RuntimeType.Net;
            if (DetectWindows())
                Platform = PlatformType.Windows;
            else
            {
                //Not on windows, time to decide whether this is Osx/Linux
                utsname name;
                uname(out name);
                switch (name.sysname)
                {
                    case "Linux":
                        Platform = PlatformType.Linux;
                        break;
                    case "Darwin":
                        Platform = PlatformType.OSX;
                        break;
                    default:
                        Platform = PlatformType.Unix;
                        break;
                }
            }
#endif
        }

        #region Unix
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct utsname
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string sysname;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string nodename;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string release;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string version;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string machine;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string extraJustInCase;

        }
        [DllImport("libc")]
        private static extern void uname(out utsname uname_struct);
        static bool DetectWindows()
        {
            return
                System.Environment.OSVersion.Platform == PlatformID.Win32NT ||
                System.Environment.OSVersion.Platform == PlatformID.Win32S ||
                System.Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                System.Environment.OSVersion.Platform == PlatformID.WinCE;
        }
        private static bool DetectMono()
        {
            Type t = Type.GetType("Mono.Runtime");
            return t != null;
        }
        #endregion

    }
}
