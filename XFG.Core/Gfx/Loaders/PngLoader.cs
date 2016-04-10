using XFG.OpenGL;
using XFG.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx.Loaders
{

    class PngLoader : TextureLoader
    {
        string Filename;
        public int Height { get; private set; }
        public int Width { get; private set; }
        int FilterMethod = 0;
        bool Filtered
        {
            get
            {
                return FilterMethod != 0;
            }
        }
        public PngLoader(string fname)
        {
            Filename = fname;
        }

        public bool CanLoad(string filename)
        {
            return filename.Contains(".png");
        }

        public TextureLoader Create(string filename)
        {
            return new PngLoader(filename);
        }
        public void Load()
        {
            Stopwatch sw = new Stopwatch();
            PNG im = new PNG(Filename);
            Width = im.Width;
            Height = im.Height;
            byte[] res = new byte[Width * Height * 4];
            im.ReadScanlinesRGBA(ref res, Height);
            try
            {
                IntPtr add = Marshal.UnsafeAddrOfPinnedArrayElement(res, 0);
                GL.TexImage2D(TextureTarget.TEXTURE_2D, 0, InternalPixelFormat.RGBA, Width, Height, 0, PixelFormat.RGBA, PixelType.UNSIGNED_BYTE, add);
                var error = GL.GetError();
                if (error != ErrorCode.NO_ERROR)
                {
                    throw new Exception("Error creating texture " + error);
                }
            }
            catch (Exception e)
            {
                Logger.Debug(e.Message);
            }
        }
    }
}
