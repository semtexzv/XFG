using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.Gfx;
using System.Runtime.InteropServices;

namespace XFG.MathUtils
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Vector4(float val)
        {
            X = val;
            Y = val;
            Z = val;
            W = val;
        }
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public Vector4(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0.0f;
            W = 0.0f;
        }
        public Vector4(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0.0f;
        }
        public Vector4(Vector3 v, float w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }
        public Vector4(Vector4 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        public float Length
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }

        public float LengthSquared
        {
            get
            {
                return (float)X * X + Y * Y + Z * Z + W * W;
            }
        }
        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else if (index == 2) return Z;
                else if (index == 3) return W;
                throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else if (index == 2) Z = value;
                else if (index == 3) W = value;
                else throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
            }
        }

        public void Add(float val)
        {
            X += val;
            Y += val;
            Z += val;
            W += val;
        }
        public void Add(float vecX, float vecY, float vecZ, float vecW)
        {
            X += vecX;
            Y += vecY;
            Z += vecZ;
            W += vecW;
        }
        public void Add(Vector4 vec)
        {
            X += vec.X;
            Y += vec.Y;
            Z += vec.Z;
            W += vec.W;
        }

        public void Sub(float val)
        {
            X -= val;
            Y -= val;
            Z -= val;
            W -= val;
        }
        public void Sub(float vecX, float vecY, float vecZ, float vecW)
        {
            X -= vecX;
            Y -= vecY;
            Z -= vecZ;
            W -= vecW;
        }
        public void Sub(Vector4 vec)
        {
            X -= vec.X;
            Y -= vec.Y;
            Z -= vec.Z;
            W -= vec.W;
        }


        public void Mul(float val)
        {
            X *= val;
            Y *= val;
            Z *= val;
            W *= val;
        }
        public void Mul(float vecX, float vecY, float vecZ, float vecW)
        {
            X *= vecX;
            Y *= vecY;
            Z *= vecZ;
            W *= vecW;
        }
        public void Mul(Vector4 vec)
        {
            X *= vec.X;
            Y *= vec.Y;
            Z *= vec.Z;
            W *= vec.W;
        }

        public void Div(float val)
        {
            X /= val;
            Y /= val;
            Z /= val;
            W /= val;
        }
        public void Div(float vecX, float vecY, float vecZ, float vecW)
        {
            X /= vecX;
            Y /= vecY;
            Z /= vecZ;
            W /= vecW;
        }
        public void Div(Vector4 vec)
        {
            X /= vec.X;
            Y /= vec.Y;
            Z /= vec.Z;
            W /= vec.W;
        }

        public float Dot(Vector4 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z + W * other.W;
        }
        public float Dot(Vector3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }
        public void Nor()
        {
            
            float s = LengthSquared;
            if (s == 1)
                return;
            s = Math.Sqrt(s);
            X /= s;
            Y /= s;
            Z /= s;
            W /= s;
        }
        public void Clamp(Vector4 min, Vector4 max)
        {
            X = X < min.X ? min.X : X > max.X ? max.X : X;
            Y = Y < min.Y ? min.Y : Y > max.Y ? max.Y : Y;
            Z = Z < min.Z ? min.Z : Z > max.Z ? max.Z : Z;

            W = W < min.W ? min.W : W > max.W ? max.W : W;
        }
        public static Vector4 Lerp(Vector4 a, Vector4 b, float blend)
        {
            Vector4 result = new Vector4(0);
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
            result.Z = blend * (b.Z - a.Z) + a.Z;
            result.W = blend * (b.W - a.W) + a.W;
            return result;
        }

        public static Vector4 Max(Vector4 a, Vector4 b)
        {
            return a > b ? a : b;
        }
        public static Vector4 Min(Vector4 a, Vector4 b)
        {
            return a < b ? a : b;
        }












        #region Operators
        //We try to use structs as immutable, if you need mutability , use methods
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }
        public static Vector4 operator +(Vector4 a, float val)
        {
            return new Vector4(a.X + val, a.Y + val, a.Z + val, a.W + val);
        }
        public static Vector4 operator +(float val, Vector4 a)
        {
            return new Vector4(a.X + val, a.Y + val, a.Z + val, a.W + val);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }
        public static Vector4 operator -(Vector4 a, float val)
        {
            return new Vector4(a.X - val, a.Y - val, a.Z - val, a.W - val);
        }
        public static Vector4 operator -(float val, Vector4 a)
        {
            return new Vector4(val - a.X, val - a.Y, val - a.Z, val - a.W);
        }

        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
        }
        public static Vector4 operator *(Vector4 a, float val)
        {
            return new Vector4(a.X * val, a.Y * val, a.Z * val, a.W * val);
        }
        public static Vector4 operator *(float val, Vector4 a)
        {
            return new Vector4(val * a.X, val * a.Y, a.Z * val, a.W * val);
        }

        public static Vector4 operator *(Matrix4 mat, Vector4 vec)
        {
            return new Vector4(mat.Row1.Dot(vec), mat.Row2.Dot(vec), mat.Row3.Dot(vec), mat.Row4.Dot(vec));
          //Equivalent to:
            /*
            return new Vector4(
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y + mat[0, 2] * vec.Z + mat[0, 3] * vec.W,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y + mat[1, 2] * vec.Z + mat[1, 3] * vec.W,
                mat[2, 0] * vec.X + mat[2, 1] * vec.Y + mat[2, 2] * vec.Z + mat[2, 3] * vec.W,
                mat[3, 0] * vec.X + mat[3, 1] * vec.Y + mat[3, 2] * vec.Z + mat[3, 3] * vec.W
                );*/
        }
        public static Vector4 operator *(Vector4 vec, Matrix4 mat)
        {
            mat.Transpose();
            return mat * vec;
        }

        public static Vector4 operator *(Quaternion qat,Vector4 vec)
        {
            Quaternion v = new Quaternion(vec.X, vec.Y, vec.Z, vec.W), i, t;
            i = qat.Inverse;
            t = qat * v;
            v = t * i;

            return new Vector4(v.X, v.Y, v.Z, v.W);
        }

        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
        }
        public static Vector4 operator /(Vector4 a, float val)
        {
            return new Vector4(a.X / val, a.Y / val, a.Z / val, a.W / val);
        }
        public static Vector4 operator /(float val, Vector4 a)
        {
            return new Vector4(val / a.X, val / a.Y, val / a.Z, val / a.W);
        }

        public static Vector4 operator -(Vector4 a)
        {
            return new Vector4(-a.X, -a.Y, -a.Z, -a.W);
        }

        public static bool operator <(Vector4 a, Vector4 b)
        {
            return a.LengthSquared < b.LengthSquared;
        }
        public static bool operator >(Vector4 a, Vector4 b)
        {
            return a.LengthSquared > b.LengthSquared;
        }
        public static bool operator <=(Vector4 a, Vector4 b)
        {
            return a.LengthSquared <= b.LengthSquared;
        }
        public static bool operator >=(Vector4 a, Vector4 b)
        {
            return a.LengthSquared >= b.LengthSquared;
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !a.Equals(b);
        }

        public static implicit operator Vector4(Color v)
        {
            throw new NotImplementedException();
        }
        #endregion

        public override string ToString()
        {
            return String.Format("{{{0},{1},{2},{3}}}", X, Y, Z, W);
        }
        public override int GetHashCode()
        {
            return (X.GetHashCode() ^ Y.GetHashCode() + Z.GetHashCode()) ^ W.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4))
                return false;

            return this.Equals((Vector4)obj);
        }
        public bool Equals(Vector4 other)
        {
            return
                X == other.X &&
                Y == other.Y &&
                Z == other.Z;
        }
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);
        
    }
}

