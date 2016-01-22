using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    public class TextureRegion
    {
        public Texture Texture;
        public float U1;
        public float V1;
        public float U2;
        public float V2;
        
        public TextureRegion(Texture texture,int x,int y,int width,int height)
        {
            Texture = texture;
            U1 = (float)x / texture.Width;
            U2 = (float)(x + width)/texture.Width ;

            V1 = (float)y/texture.Height ;
            V2 = (float)(y + height)/texture.Height;
        }
        public TextureRegion(Texture texture)
        {
            Texture = texture;
            U1 = V1 = 0;
            U2 = V2 = 1;
        }
        public TextureRegion(TextureRegion region)
        {
            Texture = region.Texture;
            U1 = region.U1;
            U2 = region.U2;
            V1 = region.V1;
            V2 = region.V2;     
        }

        /// <summary>
        /// X coordinate in pixels
        /// </summary>
        public float X
        {
            get
            {
                return U1 * Texture.Width;
            }
        }
        /// <summary>
        /// Y coordinate in pixels
        /// </summary>
        public float Y
        {
            get
            {
                return V1 * Texture.Height;
            }
        }
        /// <summary>
        /// Width in pixels
        /// </summary>
        public float Width
        {
            get
            {
                return (U2 - U1) * Texture.Width;
            }
        }
        /// <summary>
        /// Height in pixels
        /// </summary>
        public float Height
        {
            get
            {
                return (V2 - V1) * Texture.Height;
            }
        }
    }
}
