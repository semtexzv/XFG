using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFG;
using XFG.Platform;

namespace XFG
{
    public static class Android
    {
        public static void Init(AppConfig conf, AppListener listener)
        {
            IPlatform platform = null;
            platform.Init(conf);
            XFG.Config.InitPlatform(PlatformType.Android,platform);

            listener.Create();

            platform.Run(listener);
        }
    }
}