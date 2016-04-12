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
    class AndroidPlatform : XFG.Platform.IPlatform
    {
        public IAudio Audio
        {
            get
            {
                return null;
            }
        }

        public IDisplay Display
        {
            get
            {
                return null;
            }
        }

        public IInput Input
        {
            get
            {
                return null;
            }
        }

        public void Init(AppConfig config)
        {
        }

        public void Run(AppListener app)
        {
        }
    }
}