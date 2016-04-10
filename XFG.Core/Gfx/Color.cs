using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    public struct Color
    {
        Vector4 col;
        public Color (float r,float g,float b,float a)
        {
            col = new Vector4(r, g, b, a);
        }
        public Color(int rgba8888)
        {
            col = new Vector4(
                ((rgba8888 & 0xFF000000) >> 24) / 255f,
                ((rgba8888 & 0x00FF0000) >> 16) / 255f,
                ((rgba8888 & 0x0000FF00) >> 8) / 255f,
                ((rgba8888 & 0x000000FF)) / 255f
                );
        }
        public void Clamp()
        {
            col.Clamp(Vector4.Zero, Vector4.One);
        }
        public Color Lerp(Color _a, Color _b, float blend)
        {
            return new Color() { col = Vector4.Lerp(_a.col, _b.col, blend), };
        }

        public float Red
        {
            get
            {
                return col.X;
            }
            set
            {
                col.X = value;
            }
        }
        public float Green
        {
            get
            {
                return col.Y;
            }
            set
            {
                col.Y = value;
            }
        }
        public float Blue
        {
            get { return col.Z; }
            set { col.Z = value; }
        }
        public float Alpha
        {
            get { return col.W; }
            set { col.W = value; }
        }

        public static Color FromRGBA8888(int rgba8888)
        {
            return new Color(((rgba8888 & 0xFF000000) >> 24) / 255f,
                ((rgba8888 & 0x00FF0000) >> 16) / 255f,
                ((rgba8888 & 0x0000FF00) >> 8) / 255f,
                ((rgba8888 & 0x000000FF)) / 255f);
        }
        public static int ToRGBA8888(Color c)
        {
            return ((int)c.Red * 255) << 24 | ((int)c.Green * 255) << 16 | ((int)c.Blue * 255) << 8 | ((int)c.Alpha * 255);
        }

        public override string ToString()
        {
            return col.ToString();
        }
    }
}
