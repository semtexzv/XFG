using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XFG;
using Android.Opengl;
using TestApp;
using Android.Util;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AndroidApplication
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AndroidApplicationConfig conf = new AndroidApplicationConfig();
            conf.displayFormat = DisplayFormat.RGB888;
            Init(conf, new TestAppListener());
            Logger.OnMessage += (msg, type) =>
            {
                Log.WriteLine((LogPriority)type, "TEST", msg);
            };
          
            
        }
    }
}

