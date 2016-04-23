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
using XFG.Platform;

namespace XFG
{
    public class AndroidApplication : Activity, IPlatform
    {
        public AppListener listener;
        private AndroidDisplay display;

        /// <summary>
        /// This method should be called on <see cref="Activity.OnCreate(Bundle)"/> in order to initialize all
        /// necessary configuration
        /// </summary>
        /// <param name="config">Application configuration</param>
        public void Init(AndroidApplicationConfig config,AppListener listener)
        {
            this.listener = listener;
            display = new AndroidDisplay(this,config);
            XFG.Config.InitPlatform(PlatformType.Android, this);
            SetContentView(display.view);
        }
        
        IAudio IPlatform.Audio
        {
            get
            {
                return null;
            }
        }

        IDisplay IPlatform.Display
        {
            get
            {
                return display;
            }
        }

        IInput IPlatform.Input
        {
            get
            {
                return null;
            }
        }
        
    }
}