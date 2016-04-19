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
        private SurfaceView surface;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
           
            View view = LayoutInflater.Inflate(Resource.Layout.Main,null);

            // Set our view from the "main" layout resource
            SetContentView(view);

            LinearLayout lin = (LinearLayout)view.FindViewById(Resource.Id.test);
            lin.AddView(new XFG.XfgGLSView(this,DisplayFormat.RGB888));
            
            
        }
    }
}

