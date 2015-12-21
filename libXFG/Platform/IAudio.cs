using XFG.Audiolib;
using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Platform
{
    public interface IAudio : IDisposable
    { 
        void Mute();
        void Unmute();
        ISound CreateSound(string filename);
        IMusic CreateMusic(string filename);
        IAudioDevice CreateDevice(bool stereo, int sampleRate);
        void SetListener(Vector3 pos,Vector3 dir);
        bool Supports3DAudio();
        float Volume { get; set; }
    }
}
