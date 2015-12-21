using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG
{
    public class DisplayFormat
    {
        /// <summary>
        /// Used to represent display format,
        /// Warning! Platform implementation should return display format that
        /// matches or exceeds every property of requested format. 
        /// EG , you request RGBA4444 and get RGBA8888 is perfectly valid. 
        /// </summary>
        /// <param name="red">Bit depth of red sample</param>
        /// <param name="green">Bit depth of green sample</param>
        /// <param name="blue">Bit depth of blue sample</param>
        /// <param name="alpha">Bit depth of alpha sample</param>
        /// <param name="depth">Bit depth of depth sample</param>
        /// <param name="stencil">Bit depth of stencil sample</param>
        /// <param name="samples">Number of samples for MSAA, should be power of two</param>
        public DisplayFormat(int red=8,int green=8,int blue=8,int alpha=8,int depth=16,int stencil=8,int samples=0)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Alpha = alpha;
            this.Depth = depth;
            this.Stencil = stencil;
            this.Samples = samples;
        }
        /// <summary>
        /// Bit depth of red sample.
        /// </summary>
        public int Red;
        /// <summary>
        /// Bit depth of green sample.
        /// </summary>
        public int Green;
        /// <summary>
        /// Bit depth of blue sample.
        /// </summary>
        public int Blue;
        /// <summary>
        /// Bit depth of alpha sample.
        /// </summary>
        public int Alpha;
        /// <summary>
        /// Bit depth of depth sample.
        /// </summary>
        public int Depth;
        /// <summary>
        /// Bit depth of stencil sample.
        /// </summary>
        public int Stencil;
        /// <summary>
        /// Number of samples used for MSAA.
        /// </summary>
        public int Samples;

        public override string ToString()
        {
            return String.Format("Color:{0},{1},{2} Alpha:{3} Depth:{4} Stencil:{5} Samples:{6}", Red, Green, Blue, Alpha, Depth, Stencil, Samples);
        }
        /// <summary>
        /// Does this format support MSAA?
        /// </summary>
        public bool Multisample
        {
            get
            {
                return Samples != 0;
            }
        }
        /// <summary>
        /// number of sample buffers for MSAA, for glES should be 1 or 0.
        /// </summary>
        public int SampleBuffers
        {
            get
            {
                return Multisample ? 1 : 0;
            }
        }

        /// <summary>
        /// Changes bit depth of stencil sample and returns this format.
        /// </summary>
        public DisplayFormat SetStencil(int stencil)
        {
            Stencil = stencil;
            return this;
        }
        /// <summary>
        /// Changes number of MSAA samples and returns this format.
        /// </summary>
        public DisplayFormat SetSamples(int sam)
        {
            Samples = sam;
            return this;
        }
        /// <summary>
        /// Changes bit depth of depth buffer and returns this format
        /// </summary>
        public DisplayFormat SetDepth(int depth)
        {
            Depth = depth;
            return this;
        }
        /// <summary>
        /// Creates standard RGB888 format
        /// </summary>
        public static DisplayFormat RGB888
        {
            get
            {
                return new DisplayFormat(8, 8, 8, 0);
            }
        }
        /// <summary>
        /// Creates standard RGBA8888 format
        /// </summary>
        public static DisplayFormat RGBA8888
        {
            get
            {
                return new DisplayFormat(8, 8, 8, 8);
            }
        }
        /// <summary>
        /// Creates standard RGB565 format
        /// </summary>
        public static DisplayFormat RGB565
        {
            get
            {
                return new DisplayFormat(5,6,5,0);
            }
        }
        /// <summary>
        /// Creates standard RGBA5551 format
        /// </summary>
        public static DisplayFormat RGBA5551
        {
            get
            {
                return new DisplayFormat(5, 5, 5, 1);
            }
        }
        /// <summary>
        /// Creates standard RGBA4444 format
        /// </summary>
        public static DisplayFormat RGBA4444
        {
            get
            {
                return new DisplayFormat(4,4,4,4);
            }
        }
    }
}
