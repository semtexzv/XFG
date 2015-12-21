using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFG.MathUtils
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X;
        public float Y;
        public float Length
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y);
            }
        }
        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y;
            }
        }
        public Vector2 PerpR
        {
            get
            {
                return new Vector2(Y, -X);
            }
        }
        public Vector2 PerpL
        {
            get
            {
                return new Vector2(-Y, X);
            }
        }
        public float this[int indexer]
        {
            get
            {
                if (indexer == 0)
                    return X;
                else
                    return Y;
            }
            set
            {
                if (indexer == 0)
                    X = value;
                else
                    Y = value;
            }
        }
        public Vector2(float value)
        {
            X = value;
            Y = value;
        }
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector2(Vector2 vec)
        {
            X = vec.X;
            Y = vec.Y;
        }
        public Vector2(Vector3 vec)
        {
            X = vec.X;
            Y = vec.Y;
        }
        public void Add(float val)
        {
            X += val;
            Y += val;
        }
        public void Add(float x, float y)
        {
            X += x;
            Y += y;
        }
        public void Add(Vector2 other)
        {
            X += other.X;
            Y += other.Y;
        }
        public void Sub(float val)
        {
            X -= val;
            Y -= val;
        }
        public void Sub(float x, float y)
        {
            X -= x;
            Y -= y;
        }
        public void Sub(Vector2 other)
        {
            X -= other.X;
            Y -= other.Y;
        }
        public void Mul(float val)
        {
            X *= val;
            Y *= val;
        }
        public void Mul(float x, float y)
        {
            X *= x;
            Y *= y;
        }
        public void Mul(Vector2 other)
        {
            X *= other.X;
            Y *= other.Y;
        }
        public void Div(float val)
        {
            X /= val;
            Y /= val;
        }
        public void Div(float x, float y)
        {
            X /= x;
            Y /= y;
        }
        public void Div(Vector2 other)
        {
            X /= other.X;
            Y /= other.Y;
        }
        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }
        public void Norm()
        {
            float s = Length;
            X /= s;
            Y /= s;
        }
        public void Clamp(Vector2 min, Vector2 max)
        {
            X = X < min.X ? min.X : X > max.X ? max.X : X;
            Y = Y < min.Y ? min.Y : Y > max.Y ? max.Y : Y;
        }

        public void RotateD(float angleDegrees)
        {
            Rotate(Math.Deg2Rad * angleDegrees);
        }
        public void Rotate(float theta)
        {
            float sin = (float)System.Math.Sin(theta);
            float cos = (float)System.Math.Cos(theta);

            float x = X * cos - Y * sin;
            float y = X * sin + Y * cos;
            X = x;
            Y = y;
        }

        public static Vector2 Lerp(ref Vector2 a, ref Vector2 b, float blend)
        {
            Vector2 result;
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
            return result;
        }

        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return a > b ? a : b;
        }
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return a < b ? a : b;
        }

        #region Operators
        //We try to use structs as immutable, if you need mutability , use methods
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2 operator +(Vector2 a, float val)
        {
            return new Vector2(a.X + val, a.Y + val);
        }
        public static Vector2 operator +(float val, Vector2 a)
        {
            return new Vector2(a.X + val, a.Y + val);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2 operator -(Vector2 a, float val)
        {
            return new Vector2(a.X - val, a.Y - val);
        }
        public static Vector2 operator -(float val, Vector2 a)
        {
            return new Vector2(val-a.X, val - a.Y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }
        public static Vector2 operator *(Vector2 a, float val)
        {
            return new Vector2(a.X * val, a.Y * val);
        }
        public static Vector2 operator *(float val, Vector2 a)
        {
            return new Vector2(val * a.X, val * a.Y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }
        public static Vector2 operator /(Vector2 a, float val)
        {
            return new Vector2(a.X / val, a.Y / val);
        }
        public static Vector2 operator /(float val, Vector2 a)
        {
            return new Vector2(val / a.X, val / a.Y);
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.X, -a.Y);
        }
        
        public static bool operator <(Vector2 a, Vector2 b)
        {
            return a.LengthSquared < b.LengthSquared;
        }
        public static bool operator >(Vector2 a, Vector2 b)
        {
            return a.LengthSquared > b.LengthSquared;
        }
        public static bool operator <=(Vector2 a, Vector2 b)
        {
            return a.LengthSquared <= b.LengthSquared;
        }
        public static bool operator >=(Vector2 a, Vector2 b)
        {
            return a.LengthSquared >= b.LengthSquared;
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }
        #endregion

        public override string ToString()
        {
            return "{"+X + "," + Y+"}";
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
                return false;

            return this.Equals((Vector2)obj);
        }
        public bool Equals(Vector2 other)
        {
            return
                X == other.X &&
                Y == other.Y;
        }
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 One = new Vector2(1, 1);
    }
}
