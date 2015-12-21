using XFG.Audiolib;
using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Backend
{
    /// <summary>
    /// Represents audio platform, will be created before application is initialized
    /// and will be disposed of after game is closed
    /// </summary>
    public interface IAudioPlatform : IDisposable
    { 
        /// <summary>
        /// Suspends all sounds, could be thought as mute button, 
        /// However, does not stop sounds from running
        /// </summary>
        void Mute();
        /// <summary>
        /// Resumes all sounds
        /// </summary>
        void Unmute();
        /// <summary>
        /// Creates new sound instance. All sound data will be loaded to memory
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Newly created sound</returns>
        ISound CreateSound(string filename);
        /// <summary>
        /// Creates new music instance. Data will be streamed to memory
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        IMusic CreateMusic(string filename);
        /// <summary>
        /// Returns new audio device for playing PCM samples of specified sample rate , with interleaved channels
        /// Warning, implementation might not support exact channel number and sample rate, So Check returned instance
        /// for actual properties of audio device
        /// </summary>
        /// <param name="channels">Suggested number of channes</param>
        /// <param name="sampleRate">Suggested Sample rate</param>
        /// <returns></returns>
        IAudioDevice CreateDevice(bool stereo, int sampleRate);
        /// <summary>
        /// Sets listener position and direction, used for positional audio, might not be available on some platforms
        /// </summary>
        /// <param name="pos">Listener's position</param>
        /// <param name="dir">Listener's direction</param>
        void SetListener(Vector3 pos,Vector3 dir);
        /// <summary>
        /// Does this platform support positional audio ?
        /// </summary>
        /// <returns></returns>
        bool Supports3DAudio();
    }
}
