using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    public enum AnimType
    {
        Normal,
        Loop,
        PingPong,
    }
    public class Animation
    {
        private TextureRegion[] Regions;
        private float frameTime;
        public float FrameTime
        {
            get
            {
                return frameTime;
            }
            set
            {
                frameTime = value;
                AnimTime = frameTime * Regions.Length;
            }
        }
        private float AnimTime;
        public AnimType Type;
        public float TotalTime;
        public Animation(float frameTime, AnimType type, params TextureRegion[] regions)
        {
            Type = type;
            Regions = regions;
            AnimTime = regions.Length * frameTime;
            FrameTime = frameTime;
        }
        public void Update(float delta)
        {
            TotalTime += delta;
        }
        public TextureRegion GetRegion()
        {
            return GetRegion(TotalTime, Type);
        }
        public TextureRegion GetRegion(float time)
        {
            return GetRegion(time, Type);
        }
        public TextureRegion GetRegion( float time,AnimType type)
        {
            int frameNum = (int)(time / frameTime);
            switch(type)
            {
                case AnimType.Normal:
                    return Regions[Math.Min(Regions.Length-1,frameNum)];
                case AnimType.Loop:
                    return Regions[(int)(frameNum % Regions.Length)];
                case AnimType.PingPong:
                    int iteration = (int)(time / AnimTime);
                    if(iteration % 2 == 0)
                        return Regions[(int)(frameNum % Regions.Length)];
                    else
                        return Regions[Regions.Length-1-(int)(frameNum % Regions.Length)];
                default:
                    return null;
            }
        }


    }
}
