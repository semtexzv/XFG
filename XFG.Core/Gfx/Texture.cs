using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.OpenGL;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace XFG.Gfx
{
    public class Texture
    {
        public int Handle;
        public int Unit = 0;
        TextureMinFilter _minFilter = TextureMinFilter.LINEAR;
        TextureMagFilter _magFilter = TextureMagFilter.NEAREST;
        TextureWrapMode _wrapS = TextureWrapMode.CLAMP_TO_EDGE;
        TextureWrapMode _wrapT = TextureWrapMode.CLAMP_TO_EDGE;

        public Texture(IFileHandle file)
        {
            Handle = GL.GenTexture();
            
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            var data = image.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.BindTexture(TextureTarget.TEXTURE_2D, Handle);
            GL.TexImage2D(TextureTarget.TEXTURE_2D, 0, InternalPixelFormat.RGBA, Width, Height, 0, OpenGL.PixelFormat.RGBA, PixelType.UNSIGNED_BYTE, data.Scan0);
            image.UnlockBits(data);
            image.Dispose();
            UploadParams();

        }
        public TextureMinFilter MinFilter
        {
            get
            {
                return _minFilter;
            }
            set
            {
                _minFilter = value;
                Bind();
                GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_MIN_FILTER, (int)_minFilter);
            }
        }
        public TextureMagFilter MagFilter
        {
            get
            {
                return _magFilter;
            }
            set
            {
                _magFilter = value;
                Bind();
                GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_MIN_FILTER, (int)_magFilter);
            }
        }
        public TextureWrapMode WrapS
        {
            get
            {
                return _wrapS;
            }
            set
            {
                _wrapS = value;
                Bind();
                GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_WRAP_S, (int)_wrapS);
            }
        }
        public TextureWrapMode WrapT
        {
            get
            {
                return _wrapT;
            }
            set
            {
                _wrapT=value;
                Bind();
                GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_WRAP_T, (int)_wrapT);
            }
        }

        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get;
            private set;
        }
        public void UploadParams()
        {
            Bind();
            GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_WRAP_S, (int)WrapS);
            GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_WRAP_T, (int)WrapT);
            GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_MAG_FILTER, (int)MagFilter);
            GL.TexParameteri(TextureTarget.TEXTURE_2D, TextureParameter.TEXTURE_MIN_FILTER, (int)MinFilter);
        }
        public void Bind()
        {
            if (binds[Unit] != this)
            {
                GL.ActiveTexture(TextureUnit.TEXTURE0 + Unit);
                GL.BindTexture(TextureTarget.TEXTURE_2D, Handle);
            }
        }
        private static Texture[] binds = new Texture[16];
        
      
        
    }
}


