using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XFG;
using Android.Opengl;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        GLSurfaceView abc;
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            
            AddContentView(abc);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            XFG.Config.InitPlatform(PlatformType.Android,null);
            XFG.Logger.OnMessage += (msg, type) => { Android.Util.Log.WriteLine((Android.Util.LogPriority)type, "TEST", msg); };

            Android.Util.Log.Debug("TEST",XFG.Config.Platform.ToString());
        }
    }
}

