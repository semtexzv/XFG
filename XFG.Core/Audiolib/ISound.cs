using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Audiolib
{
    public delegate void OnSoundCompleteDelegate(int id);

    /// <summary>
    /// Represents platform agnostic sound, platform-specific sounds should i
    /// </summary>
    public interface ISound
    {
       /// <summary>
       /// Plays new Instance of this sound.After instance has stopped playing, it will be disposed of
       /// </summary>
       /// <returns> ID of the instance, or -1 if operation fails</returns>
        int Play();
        /// <summary>
        /// Resumes paused instance, or all instances if id = 0
        /// </summary>
        /// <param name="id"></param>
        void Resume(int id = 0);
        /// <summary>
        /// Pauses specified instance, or all instances if id = 0
        /// </summary>
        /// <param name="id">Instance ID</param>
        void Pause(int id =0);
        /// <summary>
        /// Stops specified instance, or all instances if id = 0
        /// </summary>
        /// <param name="id">Instance ID</param>
        void Stop(int id = 0);
        /// <summary>
        /// Sets volume of instance, or all instances if id = 0
        /// Volume from 0.0 to 1.0 represents normal range, any values under 0 will be clipped to 0
        /// and any values Above 1 will result in amplification/gain 
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="id"></param>
        void SetVolume(float volume,int id = 0);
        /// <summary>
        /// Sets instance position in 3D space, or all instances if id = 0
        /// Warning, doing this erases pan/pitch settings and requires 3D audio to be available and enabled
        /// </summary>
        /// <param name="position"></param>
        /// <param name="id"></param>
        void SetPosition(Vector3 position, int id = 0);
        /// <summary>
        /// Sets instance looping, or all instances if id = 0.
        /// If instance was already looping, and SetLooping(false) is called, instance will finish
        /// </summary>
        /// <param name="looping"></param>
        /// <param name="id"></param>
        void SetLooping(bool looping, int id = 0);

        /// <summary>
        /// Called when instance finishes playing, If the instance is looping, called on end of every loop
        /// </summary>
        event OnSoundCompleteDelegate OnComplete;
    }
}
