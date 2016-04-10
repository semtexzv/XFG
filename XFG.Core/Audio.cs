using XFG.Audiolib;
using XFG.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG
{
    /// <summary>
    /// Static class for handling all audio 
    /// </summary>
   public static class Audio
    {
        private static IAudio Platform;
        internal static void SetPlatform(IAudio graphics)
        {
            Platform = graphics;
        }
        public static ISound CreateSound(string filename)
        {
            return Platform.CreateSound(filename);
        }
        public static IMusic CreateMusic(string filename)
        {
            return Platform.CreateMusic(filename);
        }
        public static IAudioDevice CreateDevice(bool stereo,int sampleRate)
        {
            return Platform.CreateDevice(stereo, sampleRate);
        }
        public static void Mute()
        {
            Platform.Mute();
        }
        public static void Unmute()
        {
            Platform.Unmute();
        }

    }
}
