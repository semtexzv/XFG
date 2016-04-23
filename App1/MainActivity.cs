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

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AndroidApplication
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Init(new AndroidApplicationConfig(), new TestAppListener());
          
            
        }
    }
}

