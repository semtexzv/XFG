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
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X;
        public float Y;
        public float Z;
        public float Length
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }
        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z;
            }
        }
        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                if (index == 1) return Y;
                else if (index == 2) return Z;
                else return 0;
            }
            set
            {
                if (index == 0) X=value;
                if (index == 1) Y=value;
                else if (index == 2) Z=value;
            }
        }
        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }
        public Vector3(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0;
        }
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3(Vector2 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0;
        }
        public Vector3(Vector3 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }
        public void Add(float val)
        {
            X += val;
            Y += val;
            Z += val;
        }
        public void Add(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }
        public void Add(Vector3 other)
        {
            X += other.X;
            Y += other.Y;
            Z += other.Z;
        }
        public void Sub(float val)
        {
            X -= val;
            Y -= val;
            Z -= val;
        }
        public void Sub(float x, float y, float z)
        {
            X -= x;
            Y -= y;
            Z -= z;
        }
        public void Sub(Vector3 other)
        {
            X -= other.X;
            Y -= other.Y;
            Z -= other.Z;
        }
        public void Mul(float val)
        {
            X *= val;
            Y *= val;
            Z *= val;
        }
        public void Mul(float x, float y, float z)
        {
            X *= x;
            Y *= y;
            Z *= z;
        }
        public void Mul(Vector3 other)
        {
            X *= other.X;
            Y *= other.Y;
            Z *= other.Z;
        }
        public void Div(float val)
        {
            X /= val;
            Y /= val;
            Z /= val;
        }
        public void Div(float x, float y, float z)
        {
            X /= x;
            Y /= y;
            Z /= z;
        }
        public void Div(Vector3 other)
        {
            X /= other.X;
            Y /= other.Y;
            Z /= other.Z;
        }
        public float Dot(Vector3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }
        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                Y*other.Z-other.Y*Z,
                -(X*other.Z-other.X*Z),
                X*other.Y-other.X*Y);
        }
        public void Norm()
        {
            float s = Length;
            X /= s;
            Y /= s;
            Z /= s;
        }
        public void Clamp(Vector3 min, Vector3 max)
        {
            X = X < min.X ? min.X : X > max.X ? max.X : X;
            Y = Y < min.Y ? min.Y : Y > max.Y ? max.Y : Y;
            Z = Z < min.Z ? min.Z : Z > max.Z ? max.Z : Z;
        }
        public static void RotateD(Vector3 axis,float angleDegrees)
        {
            Rotate(axis, Math.Deg2Rad * angleDegrees);
        }
        public static void Rotate(Vector3 axis,float theta)
        {
                        
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float blend)
        {
            Vector3 result;
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
            result.Z = blend * (b.Z - a.Z) + a.Z;
            return result;
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return a > b ? a : b;
        }
        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return a < b ? a : b;
        }
      

        #region Operators
        //We try to use structs as immutable, if you need mutability , use methods
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y,a.Z+b.Z);
        }
        public static Vector3 operator +(Vector3 a, float val)
        {
            return new Vector3(a.X + val, a.Y + val,a.Z+val);
        }
        public static Vector3 operator +(float val, Vector3 a)
        {
            return new Vector3(a.X + val, a.Y + val,a.Z+val);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y,a.Z-b.Z);
        }
        public static Vector3 operator -(Vector3 a, float val)
        {
            return new Vector3(a.X - val, a.Y - val,a.Z-val);
        }
        public static Vector3 operator -(float val, Vector3 a)
        {
            return new Vector3(val - a.X, val - a.Y,val-a.Z);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y,a.Z*b.Z);
        }
        public static Vector3 operator *(Vector3 a, float val)
        {
            return new Vector3(a.X * val, a.Y * val,a.Z*val);
        }
        public static Vector3 operator *(float val, Vector3 a)
        {
            return new Vector3(val * a.X, val * a.Y,a.Z*val);
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X / b.X, a.Y / b.Y,a.Z/b.Z);
        }
        public static Vector3 operator /(Vector3 a, float val)
        {
            return new Vector3(a.X / val, a.Y / val,a.Z/val);
        }
        public static Vector3 operator /(float val, Vector3 a)
        {
            return new Vector3(val / a.X, val / a.Y,val/a.Z);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.X, -a.Y,-a.Z);
        }
        
        public static Vector3 operator *(Matrix4 mat, Vector3 vec)
        {
            return new Vector3(
                mat.Row1.Dot(vec),
                mat.Row2.Dot(vec),
                mat.Row3.Dot(vec)
                /*
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y + mat[0, 2] * vec.Z ,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y + mat[1, 2] * vec.Z ,
                mat[2, 0] * vec.X + mat[2, 1] * vec.Y + mat[2, 2] * vec.Z */
                );
        }
        public static Vector3 operator *(Matrix3 mat, Vector3 vec)
        {
            return new Vector3(
                mat.Row1.Dot(vec),
                mat.Row2.Dot(vec),
                mat.Row3.Dot(vec)
                /*
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y + mat[0, 2] * vec.Z,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y + mat[1, 2] * vec.Z,
                mat[2, 0] * vec.X + mat[2, 1] * vec.Y + mat[2, 2] * vec.Z*/
                );
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {
            return q.AsMatrix * v;
        }

        public static bool operator <(Vector3 a, Vector3 b)
        {
            return a.LengthSquared < b.LengthSquared;
        }
        public static bool operator >(Vector3 a, Vector3 b)
        {
            return a.LengthSquared > b.LengthSquared;
        }
        public static bool operator <=(Vector3 a, Vector3 b)
        {
            return a.LengthSquared <= b.LengthSquared;
        }
        public static bool operator >=(Vector3 a, Vector3 b)
        {
            return a.LengthSquared >= b.LengthSquared;
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }
        #endregion

        public override string ToString()
        {
            return "{" + X + "," + Y + ","+Z+ "}";
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() + Z.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3))
                return false;

            return this.Equals((Vector3)obj);
        }
        public bool Equals(Vector3 other)
        {
            return
                X == other.X &&
                Y == other.Y && 
                Z == other.Z;
        }
        public static readonly Vector3 Zero = new Vector3(0, 0,0);
        public static readonly Vector3 One = new Vector3(1, 1,0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);
        public static readonly Vector3 Forward = new Vector3(0, 0, -1);
        public static readonly Vector3 Back = new Vector3(0, 0, 1);

    }
}
