﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Platform.Windows
{
    class WglPlatform : IPlatform
    {
        internal WglDisplay display;
        internal WinAudio audio;
        
        public void Init(AppConfig config, AppListener app)
        {
            display = new WglDisplay(config,app);
            audio = new WinAudio();
        }
        public IAudio Audio
        {
            get { return audio; }
        }
        public IDisplay Display
        {
            get { return display; }
        }
        public IInput Input
        {
            get { return display; }
        }
        public void Run()
        {
            display.MessageLoop();
        }
    }
}
