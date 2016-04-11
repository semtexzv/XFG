using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG;
using XFG.Platform;
using XFG.Glfw;
namespace XFG
{
   public static class Desktop
    {
        public static void Init(AppConfig conf, AppListener listener)
        {
            IPlatform platform = null;
            switch (Config.Platform)
            {
                case PlatformType.Windows:
                    platform = new GlfwPlatform();
                    break;
                case PlatformType.Linux:
                    platform = new GlfwPlatform();
                    break;
                default:
                    platform = new GlfwPlatform();
                    break;
            }
            platform.Init(conf);
            XFG.Config.InitPlatform(platform);

            listener.Create();

            platform.Run(listener);
        }

    }
}
