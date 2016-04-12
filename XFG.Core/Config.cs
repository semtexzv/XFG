using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG
{
    public enum PlatformType
    {
        Windows,
        Linux,
        Unix,
        OSX,
        Android,
        iOS,
        Unknown,
    }
    public static class Config
    {
        public static PlatformType Platform { get; private set; }

        public static void InitPlatform(PlatformType type, Platform.IPlatform platform)
        {
            Platform = type;
            if (platform != null)
            {
                Audio.SetPlatform(platform.Audio);
                Graphics.SetPlatform(platform.Display);
                Input.SetPlatform(platform.Input);
            }
        }
    }
}
