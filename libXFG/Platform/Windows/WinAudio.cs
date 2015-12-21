using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Platform.Windows
{
    class WinAudio : IAudio
    {
        public void Mute()
        {
            throw new NotImplementedException();
        }

        public void Unmute()
        {
            throw new NotImplementedException();
        }

        public Audiolib.ISound CreateSound(string filename)
        {
            throw new NotImplementedException();
        }

        public Audiolib.IMusic CreateMusic(string filename)
        {
            throw new NotImplementedException();
        }

        public Audiolib.IAudioDevice CreateDevice(bool stereo, int sampleRate)
        {
            throw new NotImplementedException();
        }

        public void SetListener(MathUtils.Vector3 pos, MathUtils.Vector3 dir)
        {
            throw new NotImplementedException();
        }

        public bool Supports3DAudio()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public float Volume
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
