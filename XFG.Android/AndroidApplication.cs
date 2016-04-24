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
        private AndroidFiles files;

        /// <summary>
        /// This method should be called on <see cref="Activity.OnCreate(Bundle)"/> in order to initialize all
        /// necessary configuration
        /// </summary>
        /// <param name="config">Application configuration</param>
        public void Init(AndroidApplicationConfig config,AppListener listener)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            this.listener = listener;
            display = new AndroidDisplay(this,config);
            files = new AndroidFiles(this);
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
                return new AndroidInput();
            }
        }

        IFiles IPlatform.Files
        {
            get
            {
                return files;
            }
        }
    }
}