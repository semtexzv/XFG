using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.MathUtils
{
    // We use right handed coordinate system
    //   y|  /-z 
    //    | /
    //    |/
    //     --------- x
    // Quaternion needs to be able to parse and output specific rotations around each axis in Vector3
    
    public struct Quaternion : IEquatable<Quaternion>
    {
        public static readonly Quaternion Identity = new Quaternion(0, 0, 0, 1);
        public Vector4 Values;
        public Vector3 Xyz { get { return new Vector3(Values.X, Values.Y, Values.Z); } set { Values.X = value.X; Values.Y = value.Y;Values.Z = value.Z; } }
        public float X { get { return Values.X; } set { Values.X = value; } }
        public float Y { get { return Values.Y; } set { Values.Y = value; } }
        public float Z { get { return Values.Z; } set { Values.Z = value; } }
        public float W { get { return Values.W; } set { Values.W = value; } }

        public Quaternion(Vector4 vals)
        {
            Values = vals;
        }
        public Quaternion(float x, float y, float z, float w)
        {
            Values = new Vector4(x, y, z, w);
            Values.Nor();
        }
        public Quaternion(Vector3 from, Vector3 to) : this(from-to,0f)
        {
        }
        public Quaternion(Quaternion q)
        {
            Values = q.Values;
            Values.Nor();
        }
        public Quaternion(float qx, float qy, float qz)
        {
            Quaternion q1 = new Quaternion(new Vector3(1, 0, 0), qx);
            Quaternion q2 = new Quaternion(new Vector3(0, 1, 0), qy);
            Quaternion q3 = new Quaternion(new Vector3(0, 0, 1), qz);
            Values = (q3 * q2 * q1).Values;
        }
        public Quaternion(Vector3 axis, float angle)
        {
            if(angle==0)
            {
                Values = Identity.Values;
                return;
            }
            axis.Norm();
            float s = Math.Sin(angle *0.5f);
            float c = Math.Cos(angle *0.5f);
            Values = new Vector4(axis.X * s, axis.Y * s, axis.Z * s, c);
            Values.Nor();
        }
        public Vector3 Axis
        {
            get
            {
                Vector3 res = new Vector3();
                float s = 1/Math.Sqrt(1 - W * W);
                res.X = X * s;
                res.Y = Y * s;
                res.Z = Z * s;
                return res;
            }
        }
        public float Angle
        {
            get
            {
                return 2 * (float)System.Math.Acos(W);
            }
             
        }
      
        public Vector3 Euler
        {
            get
            {
                return new Vector3(

                    Math.Atan2(2 * X * W - 2 * Y * Z, 1 - 2 * X * X - 2 * Z * Z),
                    Math.Atan2(2 * Y * W - 2 * X * Z, 1 - 2 * Y * Y - 2 * Z * Z),
                    Math.Asin(2 * X * Y + 2 * Z * W)
                    );
            }
        }
        public float Length
        {
            get
            {
                return Values.Length;
            }

        }
        public float LengthSquared
        {
            get
            {
                return Values.LengthSquared;
            }
        }


        public void Nor()
        {
            if(Math.Abs(Values.LengthSquared-1f)>0.001)
                Values.Nor();
        }

        public Quaternion Conjugate
        {
            get { return new Quaternion(-X, -Y, -Z, W); }
        }
        public Quaternion Inverse
        {
            get { return new Quaternion(X, Y, Z, -W); }
        }


        public void Add(Quaternion q)
        {
            Values.Add(q.Values);
        }
        public void Sub(Quaternion q)
        {
            Values.Sub(q.Values);
        }
        public void Mul(float val)
        {
            Values.Mul(val);
        }
        public void Mul(Quaternion q)
        {
            float newX = this.W * q.X + this.X * q.W + this.Y * q.Z - this.Z * q.Y;
            float newY = this.W * q.Y + this.Y * q.W + this.Z * q.X - this.X * q.Z;
            float newZ = this.W * q.Z + this.Z * q.W + this.X * q.Y - this.Y * q.X;
            float newW = this.W * q.W - this.X * q.X - this.Y * q.Y - this.Z * q.Z;
            this.X = newX;
            this.Y = newY;
            this.Z = newZ;
            this.W = newW;
        }
        public float Dot(Quaternion q)
        {
            return Values.Dot(q.Values);
        }
        public Vector3 Rotate(Vector3 v)
        {
            v.Norm();
            return AsMatrix * v;
        }

        public Matrix4 AsMatrix
        {
            get
            {
                float X2 = X * X;
                float Y2 = Y * Y;
                float Z2 = Z * Z;
                float XY = X * Y;
                float XZ = X * Z;
                float YZ = Y * Z;
                float WX = W * X;
                float WY = W * Y;
                float WZ = W * Z;

                // This calculation Would be a lot more complicated for non-unit length quaternions
                // Note: The constructor of MatriX4 eXpects the MatriX in column-major format like eXpected bY
                //   OpenGL
                return new Matrix4(1.0f - 2.0f * (Y2 + Z2), 2.0f * (XY - WZ), 2.0f * (XZ + WY), 0.0f,
                        2.0f * (XY + WZ), 1.0f - 2.0f * (X2 + Z2), 2.0f * (YZ - WX), 0.0f,
                        2.0f * (XZ - WY), 2.0f * (YZ + WX), 1.0f - 2.0f * (X2 + Y2), 0.0f,
                        0.0f, 0.0f, 0.0f, 1.0f);
            }
        }
       
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            Quaternion ret = new Quaternion(q1);
            ret.Add(q2);
            return ret;
        }
        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            Quaternion ret = new Quaternion(q1);
            ret.Sub(q2);
            return ret;
        }
        public static Quaternion operator -(Quaternion q)
        {
            return new Quaternion(q.Conjugate
                );
        }
        public static Quaternion operator *(Quaternion q1, float scale)
        {
            Quaternion ret = new Quaternion(q1);
            ret.Mul(scale);
            return ret;
        }
        public static Quaternion operator *(float scale,Quaternion q1)
        {
            Quaternion ret = new Quaternion(q1);
            ret.Mul(scale);
            return ret;
        }
        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            Quaternion ret = new Quaternion(q1);
            ret.Mul(q2);
            return ret;
        }

        public static bool operator ==(Quaternion q1, Quaternion q2)
        {
            return q1.Values == q2.Values;
        }
        public static bool operator !=(Quaternion q1, Quaternion q2)
        {
            return q1.Values == q2.Values;
        }
        public static Quaternion Slerp(Quaternion q1, Quaternion q2,float alpha)
        {
            float w1, w2;
            float cosTheta = q1.Dot(q2);
            bool flip = false;
            if(cosTheta<0)
            {
                cosTheta = -cosTheta;
                flip = true;
            }
            float theta = (float)System.Math.Acos(cosTheta);
            float sinTheta = Math.Sin(theta);
            if(sinTheta<0.01f)
            {
                w1 = 1 - alpha;
                w2 = alpha;
            }
            else
            {
                w1 = Math.Sin((1 - alpha) * theta) / sinTheta;
                w2 = Math.Sin(alpha * theta) / sinTheta;
            }
            if(flip)
            {
                w2 = -w2;

            }
            return new Quaternion(q1 * w1 + q2 * w2);
            
        }
        public static Quaternion Nlerp(Quaternion q1 , Quaternion q2, float alpha)
        {
            Quaternion res;
            float t1 = 1 - alpha;
            if (q1.Dot(q2) < 0)
               res = new Quaternion(q1 * t1 + q2 * -alpha);
            else
                res = new Quaternion(q1 * t1 + q2 * alpha);
            res.Nor();
            return res;
        }
        

        public static Quaternion FromMatrix(Matrix4 matrix)
        {
            //method found on 
            //http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/christian.htm
            // Only works for pure rotation matrices, no shearing reflections or scaling
            Quaternion quaternion = Identity;
            quaternion.W = Math.Sqrt(Math.Max(0, 1 + matrix[0,0] + matrix[1,1] + matrix[2,2])) / 2;
            quaternion.X = Math.Sqrt(Math.Max(0, 1 + matrix[0,0] - matrix[1,1] - matrix[2,2])) / 2;
            quaternion.Y = Math.Sqrt(Math.Max(0, 1 - matrix[0,0] + matrix[1,1] - matrix[2,2])) / 2;
            quaternion.Z = Math.Sqrt(Math.Max(0, 1 - matrix[0,0] - matrix[1,1] + matrix[2,2])) / 2;
            quaternion.X *= (matrix[2,1] - matrix[1,2] < 0) ? -1 : 1;
            quaternion.Y *= (matrix[0,2] - matrix[2,0]< 0) ? -1 : 1;
            quaternion.Z *= (matrix[1,0] - matrix[0,1] < 0) ? -1 : 1;
            //remove any scaling from matrix
            quaternion.Nor();
            return quaternion;
        }






        public override bool Equals(object obj)
        {
            if (obj is Quaternion)
                return this == (Quaternion)obj;
            else return false;
        }
        public bool Equals(Quaternion other)
        {
            return this == other;
        }


        public override int GetHashCode()
        {
            return Values.GetHashCode();
        }
        public override string ToString()
        {
            return Values.ToString();
        }


    }
}
