using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.MathUtils
{
    public static class Math
    {
        public const float PI = (float)System.Math.PI;
        public const float PI2 = PI / 2;
        public const float Deg2Rad = PI / 180;
        public const float Rad2Deg = 180 / PI;


        public static void Swap<T>(ref T x, ref T y)
        {
            T t = y;
            y = x;
        }

        public static T Max<T>(T x, T y)
        {
            return (Comparer<T>.Default.Compare(x, y) > 0) ? x : y;
        }
        public static T Max<T>(params T[] vals)
        {
            if (vals.Length > 1)
            {
                T res = vals[0];
                for (int i = 0; i < vals.Length; i++)
                {
                    res = Max(res, vals[i]);
                }
                return res;
            }
            else if (vals.Length > 0)
                return vals[0];
            else
                return default(T);

        }

        public static float Cos(float angle)
        {
            return (float)System.Math.Cos((double)angle);
        }
        public static float Sin(float angle)
        {
            return (float)System.Math.Sin((double)angle);
        }
        public static float Tan(float angle)
        {
            return (float)System.Math.Tan((double)angle);
        }
        public static float Sqrt(float val)
        {
            return (float)System.Math.Sqrt(val);
        }
        public static float Atan2(float x,float y)
        {
            return (float)System.Math.Atan2(x, y);
        }
        public static float Asin(float x)
        {
            return (float)System.Math.Asin(x);
        }
        public static float Clamp(float val, float min, float max)
        {
            return val > max ? max : val < min ? min : val;
        }
        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }
        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }
        public static float Abs(float a)
        {
            return a < 0 ? -a : a;
        }

        public static T Min<T>(T x, T y)
        {
            return (Comparer<T>.Default.Compare(x, y) > 0) ? y : x;
        }
        public static T Min<T>(params T[] vals)
        {
            if (vals.Length > 1)
            {
                T res = vals[0];
                for (int i = 0; i < vals.Length; i++)
                {
                    res = Min(res, vals[i]);
                }
                return res;
            }
            else if (vals.Length > 0)
                return vals[0];
            else
                return default(T);

        }
       

    }
}
