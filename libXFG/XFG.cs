using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Platform;
using XFG.Platform.Dummy;
using XFG.Platform.Windows;
using XFG.Platform.X11;

namespace XFG
{
    public static class XFG
    {
        public static void Init(AppConfig conf, AppListener listener)
        {
            Config.Init();
            IPlatform platform = new DummyPlatform();
            switch (Config.Platform)
            {
                case PlatformType.Windows:
                    platform = new WglPlatform();
                    break;
                case PlatformType.Linux:
                    platform = new X11Platform();
                    break;
                default:
                    break;
            }
            platform.Init(conf, listener);
            platform.Run();
        }
        
    }
}
