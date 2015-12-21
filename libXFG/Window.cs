using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Backend;

namespace XFG
{
    public class Window
    {
        internal IWindow impl;
        public Window(AppConfig config)
        {
            impl = CreateWindow(config);
        }
        string Title
        {
            get { return impl.Title; }
            set { impl.Title = value;  }
        }
        bool Visible
        {
            get { return impl.Visible;  }
            set { impl.Visible = value; }
        }
        bool FullScreen
        {
            get { return impl.Fullscreen; }
            set { impl.Fullscreen = value; }
        }
        internal static IWindow CreateWindow(AppConfig config)
        {
            switch(Config.Platform)
            {
                case PlatformType.Windows:
                    return new Backend.Windows.WglWindow(config);
                default:
                    return null;
            }
        }
       
    }
}
