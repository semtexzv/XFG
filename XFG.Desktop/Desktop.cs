using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG;
using XFG.Platform;
using XFG.Glfw;
using System.Runtime.InteropServices;

namespace XFG
{
   public static class Desktop
    {

        private static IPlatform Platform = null;
        public static void Init(AppConfig conf)
        {
            PlatformType type = getPlatformType();
            switch (type)
            {
                case PlatformType.Windows:
                case PlatformType.Linux:
                case PlatformType.OSX:
                case PlatformType.Unix:
                    Platform = new GlfwPlatform();
                    break;
                default:
                    throw new Exception("Unsupported platform");
            }
            Platform.Init(conf);
            XFG.Config.InitPlatform(type,Platform);
        }
        public static void Run(AppListener listener)
        {
            listener.Create();

            Platform.Run(listener);
        }

        private static PlatformType getPlatformType()
        {
            var platform = PlatformType.Unknown;
            if (DetectWindows())
                platform = PlatformType.Windows;
            else
            {
                //Not on windows, time to decide whether this is Osx/Linux
                utsname name;
                uname(out name);
                switch (name.sysname)
                {
                    case "Linux":
                        platform = PlatformType.Linux;
                        break;
                    case "Darwin":
                        platform = PlatformType.OSX;
                        break;
                    default:
                        platform = PlatformType.Unix;
                        break;
                }
            }
            return platform;
        }

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
            return Type.GetType("Mono.Runtime") != null;
        }
        
    }
}
