using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Platform;
using XFG.Platform.Dummy;
using XFG.Platform.Windows;

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
                default:
                    break;
            }
            platform.Init(conf, listener);
            platform.Run();
        }
    }
}
