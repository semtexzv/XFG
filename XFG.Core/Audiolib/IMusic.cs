using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Audiolib
{
    public delegate void OnMusicCompleteDelegation();
    /// <summary>
    /// Streamed audio solution for playing music
    /// </summary>
    public interface IMusic
    {
        /// <summary>
        /// Plays music, If music is already playing has no effect.
        /// </summary>
        void Play();
        /// <summary>
        /// Pauses playing music. Can be resumed by calling Play()
        /// </summary>
        void Pause();
        /// <summary>
        /// Stops playing, music will start playing from beginning after calling play()
        /// </summary>
        void Stop();

        bool Playing { get; }
        /// <summary>
        /// Changes volume of this instance
        /// </summary>
        /// <param name="volume"></param>
        float Volume { get; set; }
        /// <summary>
        /// Enables/Disables looping.
        /// </summary>
        /// <param name="looping"></param>
        void SetLooping(bool looping);
        bool isLooping();
        /// <summary>
        /// Called when music stops playing/loop iteration has ended
        /// </summary>
        event OnMusicCompleteDelegation OnComplete;
    }
}
