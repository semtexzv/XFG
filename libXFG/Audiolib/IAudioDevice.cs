using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Audiolib
{
    public delegate void OnBufferEmptyDelegate();
    /// <summary>
    /// Represents platform agnostic PCM audio device that can play 16 bit short PCM data over 1-2 channels
    /// </summary>
    public interface IAudioDevice : IDisposable
    {
        /// <summary>
        /// Returns sample rate of this audio device
        /// </summary>
        /// <returns></returns>
        int SampleRate();
        /// <summary>
        /// Number of channels of this audio device
        /// </summary>
        /// <returns></returns>
        int Channels();
        /// <summary>
        /// Method for submitting PCM data,
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <param name="offset">Offset in bytes</param>
        /// <param name="count">Count in bytes</param>
        void SubmitBuffer(short[] buffer, int offset, int count);
        /// <summary>
        /// Continue playing
        /// </summary>
        void Play();
        /// <summary>
        /// Pause Playing
        /// </summary>
        void Pause();
        /// <summary>
        /// Changes volume of this audio device
        /// </summary>
        /// <param name="volume"></param>
        void SetVolume(float volume);
        /// <summary>
        /// Called when buffer is empty and device is still in playing state
        /// </summary>
        event OnBufferEmptyDelegate OnBufferEmpty;
    }
}
