using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.MathUtils
{
    public struct Matrix4
    {
        public static Matrix4 Identity = new Matrix4(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
            );
        public Vector4 Col1;
        public Vector4 Col2;
        public Vector4 Col3;
        public Vector4 Col4;

        public Vector4 Row1
        {
            get { return new Vector4(Col1.X, Col2.X, Col3.X, Col4.X); }
            set { Col1.X = value.X; Col2.X = value.Y; Col3.X = value.Z; Col4.X = value.W; }
        }
        public Vector4 Row2
        {
            get { return new Vector4(Col1.Y, Col2.Y, Col3.Y, Col4.Y); }
            set { Col1.Y = value.X; Col2.Y = value.Y; Col3.Y = value.Z; Col4.Y = value.W; }
        }
        public Vector4 Row3
        {
            get { return new Vector4(Col1.Z, Col2.Z, Col3.Z, Col4.Z); }
            set { Col1.Z = value.X; Col2.Z = value.Y; Col3.Z = value.Z; Col4.Z = value.W; }
        }
        public Vector4 Row4
        {
            get { return new Vector4(Col1.W, Col2.W, Col3.W, Col4.W); }
            set { Col1.W = value.X; Col2.W = value.Y; Col3.W = value.Z; Col4.W = value.W; }
        }

        public Vector4 Diagonal
        {
            get
            {
                return new Vector4(Col1.X, Col2.Y, Col3.Z, Col4.W);
            }
            set
            {
                Col1.X = value.X;
                Col2.Y = value.Y;
                Col3.Z = value.Z;
                Col4.W = value.W;
            }
        }
        public Vector3 Euler
        {
            get
            {
                return new Vector3(
                    (float)System.Math.Atan2(this[2, 1], this[2, 2]),
                    (float)System.Math.Atan2(-this[2, 0], Math.Sqrt(this[2, 1] * this[2, 1] - this[2, 2] * this[2, 2])),
                    (float)System.Math.Atan2(this[1, 0], this[0, 0]));

            }
        }



        public float this[int row, int col]
        {
            get
            {
                if (col == 0) return Col1[row];
                else if (col == 1) return Col2[row];
                else if (col == 2) return Col3[row];
                else if (col == 3) return Col4[row];
                else return 0;
            }
            set
            {
                if (col == 0) Col1[row] = value;
                else if (col == 1) Col2[row] = value;
                else if (col == 2) Col3[row] = value;
                else if (col == 3) Col4[row] = value;
            }
        }
        public Matrix4(Matrix4 m)
        {
            Col1 = m.Col1;
            Col2 = m.Col2;
            Col3 = m.Col3;
            Col4 = m.Col4;
        }
        public Matrix4(params float[] vals) : this(Identity)
        {
            if (vals.Length >= 4)
            {
                Row1 = new Vector4(vals[0], vals[1], vals[2], vals[3]);
            }
            if (vals.Length >= 8)
            {
                Row2 = new Vector4(vals[4], vals[5], vals[6], vals[7]);
            }
            if (vals.Length >= 12)
            {
                Row3 = new Vector4(vals[8], vals[9], vals[10], vals[11]);
            }
            if (vals.Length >= 16)
            {
                Row4 = new Vector4(vals[12], vals[13], vals[14], vals[15]);
            }
        }
        public float Determinant
        {
            get
            {
                float det = 0;
                for (int i = 0; i < 4; i++)
                {
                    det += ((i % 2 == 0) ? +1 : -1) * this[0, i] * SubMatrix(0, i).Determinant;
                }
                return det;
            }
        }
        public Matrix3 SubMatrix(int exR, int exC)
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (exC != j && exR != i)
                    {
                        res[i > exR ? i - 1 : i, j > exC ? j - 1 : j] = this[i, j];
                    }
                }
            }
            return res;
        }
        public Boolean Singular
        {
            get
            {
                return Determinant == 0;
            }
        }
        public float Trace { get { return Row1.X + Row2.Y + Row3.Z + Row4.W; } }
        public Matrix4 Cofactor
        {
            get
            {
                Matrix4 cof = new Matrix4();
                Matrix3 sub = new Matrix3();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i1 = 0; i1 < 4; i1++)
                        {
                            for (int j1 = 0; j1 < 4; j1++)
                            {
                                if (i1 != i && j != j1)
                                {
                                    sub[i1 > i ? i1 - 1 : i1, j1 > j ? j1 - 1 : j1] = this[i1, j1];
                                }
                            }
                        }
                        cof[i, j] = (i + j) % 2 == 0 ? sub.Determinant : -sub.Determinant;
                    }
                }
                return cof;
            }
        }
        public Matrix4 Adjugate
        {
            get
            {
                Matrix4 cof = Cofactor;
                cof.Transpose();
                return cof;
            }
        }
        public Matrix4 Inverse
        {
            get
            {
                float det = Determinant;
                if (det == 0)
                    throw new InvalidOperationException("Matrix is singular, can't be inverted");

                Matrix4 res = Adjugate;
                res.Mul(det);
                return res;
            }
        }
        public Matrix4 Transposed
        {
            get
            {
                Matrix4 res = this;
                res.Transpose();
                return res;
            }
        }
        public void Transpose()
        {
            Vector4 r1 = Row1;
            Vector4 r2 = Row2;
            Vector4 r3 = Row3;
            Vector4 r4 = Row4;

            Col1 = r1;
            Col2 = r2;
            Col3 = r3;
            Col4 = r4;
        }


        public void Add(Matrix4 m)
        {
            Col1.Add(m.Col1);
            Col2.Add(m.Col2);
            Col3.Add(m.Col3);
            Col4.Add(m.Col4);
        }

        public void Sub(Matrix4 m)
        {
            Col1.Sub(m.Col1);
            Col2.Sub(m.Col2);
            Col3.Sub(m.Col3);
            Col4.Sub(m.Col4);
        }

        public void Mul(float v)
        {
            Col1.Mul(v);
            Col2.Mul(v);
            Col3.Mul(v);
            Col4.Mul(v);
        }
        public void Mul(Matrix4 mat)
        {
            Matrix4 res = new Matrix4(

               Row1.Dot(mat.Col1), Row1.Dot(mat.Col2), Row1.Dot(mat.Col3), Row1.Dot(mat.Col4),
               Row2.Dot(mat.Col1), Row2.Dot(mat.Col2), Row2.Dot(mat.Col3), Row2.Dot(mat.Col4),
               Row3.Dot(mat.Col1), Row3.Dot(mat.Col2), Row3.Dot(mat.Col3), Row3.Dot(mat.Col4),
               Row4.Dot(mat.Col1), Row4.Dot(mat.Col2), Row4.Dot(mat.Col3), Row4.Dot(mat.Col4)

                );
            this = res;

        }
        public void Div(float v)
        {
            Col1.Div(v);
            Col2.Div(v);
            Col3.Div(v);
            Col4.Div(v);
        }
        public void Div(Matrix4 m)
        {
            if (m.Singular)
                throw new Exception("Matrix is singular");
            else
            {
                Mul(m.Inverse);
            }
        }

        public static Matrix4 operator +(Matrix4 l, Matrix4 r)
        {
            Matrix4 res = new Matrix4(l);
            res.Add(r);
            return res;
        }

        public static Matrix4 operator -(Matrix4 l, Matrix4 r)
        {

            Matrix4 res = new Matrix4(l);
            res.Sub(r);
            return res;
        }

        public static Matrix4 operator *(Matrix4 m, float val)
        {
            Matrix4 res = new Matrix4(m);
            res.Mul(val);
            return res;
        }
        public static Matrix4 operator *(float val, Matrix4 m)
        {

            Matrix4 res = new Matrix4(m);
            res.Mul(val);
            return res;
        }
        public static Matrix4 operator *(Matrix4 l, Matrix4 r)
        {

            Matrix4 res = new Matrix4(l);
            res.Mul(r);
            return res;
        }

        public static Matrix4 operator *(Matrix4 l, Quaternion r)
        {
            Matrix4 res = new Matrix4(l);
            res.Mul(r.AsMatrix);
            return res;
        }
        public static Matrix4 operator *(Quaternion l, Matrix4 r)
        {
            Matrix4 res = l.AsMatrix;
            res.Mul(r);
            return res;
        }

        public static Matrix4 operator /(Matrix4 m, float val)
        {
            Matrix4 res = new Matrix4(m);
            res.Mul(val);
            return res;
        }
        public static Matrix4 operator /(Matrix4 l, Matrix4 r)
        {

            Matrix4 res = new Matrix4(l);
            res.Div(r);
            return res;
        }




        public static bool operator ==(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return String.Format("{{{0},{1},{2},{3}}}", Row1, Row2, Row3, Row4);
        }
        public override int GetHashCode()
        {
            return Row1.GetHashCode() ^ Row2.GetHashCode() + Row3.GetHashCode() ^ Row4.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix4))
                return false;

            return this.Equals((Matrix4)obj);
        }

        public bool Equals(Matrix4 other)
        {
            return
                Row1 == other.Row1 &&
                Row2 == other.Row2 &&
                Row3 == other.Row3 &&
                Row4 == other.Row4;
        }

        public void Reset()
        {
            this.Row1 = Identity.Row1;
            this.Row2 = Identity.Row2;
            this.Row3 = Identity.Row3;
            this.Row4 = Identity.Row4;
        }

        public static Matrix4 Translation(Vector3 translation)
        {
            Matrix4 m = Identity;
            m.Col4 = new Vector4(translation, 1);
            return m;
        }
        public static Matrix4 Scale(Vector3 scale)
        {
            Matrix4 m = Identity;
            m.Diagonal = new Vector4(scale, 1);
            return m;
        }
        public static Matrix4 RotX(float angle)
        {
            Matrix4 m = Identity;
            m[1, 1] = m[2, 2] = Math.Cos(angle);
            m[1, 2] = -Math.Sin(angle);
            m[2, 1] = Math.Sin(angle);
            return m;
        }    
        public static Matrix4 RotY(float angle)
        {
            Matrix4 m = Identity;
            m[0, 0] = m[1, 1] = Math.Cos(angle);
            m[0, 1] = -Math.Sin(angle);
            m[1, 0] = Math.Sin(angle);
            return m;
        }
        public static Matrix4 RotZ(float angle)
        {
            Matrix4 m = Identity;
            m[0, 0] = m[2, 2] = Math.Cos(angle);
            m[2, 0] = -Math.Sin(angle);
            m[0, 2] = Math.Sin(angle);
            return m;
        }
        public static Matrix4 Ortho(float left, float right, float bottom, float top, float near, float far)
        {
            Matrix4 res = Identity;
            float x_orth = 2 / (right - left);
            float y_orth = 2 / (top - bottom);
            float z_orth = -2 / (far - near);

            float tx = -(right + left) / (right - left);
            float ty = -(top + bottom) / (top - bottom);
            float tz = -(far + near) / (far - near);

            res[0,0] = x_orth;
            res[1,1] = y_orth;
            res[2,2] = z_orth;
            res[0,3] = tx;
            res[1,3] = ty;
            res[2,3] = tz;
            res[3,3] = 1;

            return res;
        }
        public static Matrix4 Ortho(float width, float height)
        {
            return Ortho(-width / 2, width / 2, -height / 2, height/2, -0.001f, 100f);
        }
        public static Matrix4 PerspectiveInf(float near, float fovy, float aspectRatio)
        {
            Matrix4 res = new Matrix4();
            res = Identity;
            float f = 1 / Math.Tan(fovy / 2);
            res[0, 0] = f / aspectRatio;
            res[1, 1] = f;
            res[2, 2] = 0;
            res[2, 3] = -near;
            res[3, 2] = -1;
            res[3, 3] = 0;
            return res;
        }
    }
}