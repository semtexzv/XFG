using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.MathUtils
{
    public struct Matrix3 : IEquatable<Matrix3>
    {
       
        public static readonly Matrix3 Identity = new Matrix3(
            1, 0, 0,
            0, 1, 0,
            0, 0, 1);

        public static readonly Matrix3 Zero = new Matrix3(0,0,0,0,0,0,0,0,0);


        public Vector3 Col1;
        public Vector3 Col2;
        public Vector3 Col3;
        
       
        public Matrix3(Matrix3 m)
        {
            Col1 = m.Col1;
            Col2 = m.Col2;
            Col3 = m.Col3;
        }

        public Matrix3(
           float m00, float m01, float m02,
           float m10, float m11, float m12,
           float m20, float m21, float m22)
        {
            Col1 = new Vector3(m00, m01, m02);
            Col2 = new Vector3(m10, m11, m12);
            Col3 = new Vector3(m20, m21, m22);
            Transpose();
        }
        public float M11
        {
            get { return Row1.X; }
            set { Col1.X = value; }
        }
        public float M12
        {
            get { return Row1.Y; }
            set { Col1.Y = value; }
        }
        public float M13
        {
            get { return Row1.Z; }
            set { Col1.Z = value; }
        }
       
        public float M21
        {
            get { return Row2.X; }
            set { Col2.X = value; }
        }
        public float M22
        {
            get { return Row2.Y; }
            set { Col2.Y = value; }
        }
        public float M23
        {
            get { return Row2.Z; }
            set { Col2.Z = value; }
        }
        
        public float M31
        {
            get { return Row3.X; }
            set { Col3.X = value; }
        }
        public float M32
        {
            get { return Row3.Y; }
            set { Col3.Y = value; }
        }
        public float M33
        {
            get { return Row3.Z; }
            set { Col3.Z = value; }
        }

        public float Determinant
        {
            get
            {
                return M11 * M22 * M33 + M12 * M23 * M31 + M13 * M21 * M32
                    - M13 * M22 * M31 - M11 * M23 * M32 - M12 * M21 * M33;
            }
        }

        public Boolean Singular
        {
            get
            {
                return Determinant == 0;
            }
        }
        public Vector3 Row1
        {
            get { return new Vector3(Col1.X, Col2.X, Col3.X); }
            set { Col1.X = value.X; Col2.X = value.Y; Col3.X = value.Z; }
        }
        public Vector3 Row2
        {
            get { return new Vector3(Col1.Y, Col2.Y, Col3.Y); }
            set { Col1.Y = value.X; Col2.Y = value.Y; Col3.Y = value.Z; }
        }
        public Vector3 Row3
        {
            get { return new Vector3(Col1.Z, Col2.Z, Col3.Z); }
            set { Col1.Z = value.X; Col2.Z = value.Y; Col3.Z = value.Z; }
        }

        public Vector3 Diagonal
        {
            get
            {
                return new Vector3(Row1.X, Row2.Y, Row3.Z);
            }
            set
            {
                Col1.X = value.X;
                Col2.Y = value.Y;
                Col3.Z = value.Z;
            }
        }
        public float Trace { get { return Row1.X + Row2.Y + Row3.Z; } }

        public float this[int rowIndex, int columnIndex]
        {
            get
            {
                if (rowIndex == 0) return Row1[columnIndex];
                else if (rowIndex == 1) return Row2[columnIndex];
                else if (rowIndex == 2) return Row3[columnIndex];
                throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " + columnIndex + ")");
            }
            set
            {
                if (columnIndex == 0) Col1[rowIndex] = value;
                else if (columnIndex == 1) Col2[rowIndex] = value;
                else if (columnIndex == 2) Col3[rowIndex] = value;
                else throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " + columnIndex + ")");
            }
        }
     
        public Matrix3 Cofactor
        {
            get
            {
                Matrix3 res = new Matrix3();
                res.M11 = +(M22 * M33 - M23 * M32);
                res.M12 = -(M21 * M33 - M23 * M31);
                res.M13 = +(M21 * M32 - M22 * M31);

                res.M21 = -(M12 * M33 - M13 * M32);
                res.M22 = +(M11 * M33 - M13 * M31);
                res.M23 = -(M11 * M32 - M12 * M31);

                res.M31 = +(M12 * M23 - M13 * M22);
                res.M32 = -(M11 * M23 - M13 * M21);
                res.M33 = +(M11 * M22 - M12 * M21);
                return res;
            }
        }
        public Matrix3 Adjugate
        {
            get
            {
                Matrix3 cof = Cofactor;
                cof.Transpose();
                return cof;
            }
        }

        public Matrix3 Inverse
        {
            get
            {
                float det = Determinant;
                if (det == 0)
                    throw new InvalidOperationException("Matrix is singular, can't be inverted");
            
                Matrix3 res = Adjugate;
                res.Div(det);
                return res;
            }
        }
        public Matrix3 Transposed
        {
            get
            {
                Matrix3 r = new Matrix3(this);
                r.Transpose();
                return r;
            }
        }

        public void Transpose()
        {
            Vector3 r1 = Row1;
            Vector3 r2 = Row2;
            Vector3 r3 = Row3;

            Col1 = r1;
            Col2 = r2;
            Col3 = r3;
        }

        public void Add(Matrix3 m)
        {
            Col1.Add(m.Col1);
            Col2.Add(m.Col2);
            Col3.Add(m.Col3);
        }
        public void Add(float v)
        {
            Col1.Add(v);
            Col2.Add(v);
            Col3.Add(v);
        }
        public void Sub(Matrix3 m)
        {
            Col1.Sub(m.Col1);
            Col2.Sub(m.Col2);
            Col3.Sub(m.Col3);
        }
        public void Sub(float v)
        {
            Col1.Sub(v);
            Col2.Sub(v);
            Col3.Sub(v);
        }

        public void Div(Matrix3 m)
        {
            if (m.Singular)
                throw new Exception("Matrix is singular");
            else
            {
                Mul(m.Inverse);
            }
        }

        public void Div(float v)
        {
            Col1.Div(v);
            Col2.Div(v);
            Col3.Div(v);
        }

        public void Mul(Matrix3 mat)
        {
            float m11 = M11 * mat.M11 + M12 * mat.M21 + M13 * mat.M31;
            float m12 = M11 * mat.M12 + M12 * mat.M22 + M13 * mat.M32;
            float m13 = M11 * mat.M13 + M12 * mat.M23 + M13 * mat.M33;

            float m21 = M21 * mat.M11 + M22 * mat.M21 + M23 * mat.M31;
            float m22 = M21 * mat.M12 + M22 * mat.M22 + M23 * mat.M32;
            float m23 = M21 * mat.M13 + M22 * mat.M23 + M23 * mat.M33;

            float m31 = M31 * mat.M11 + M32 * mat.M21 + M33 * mat.M31;
            float m32 = M31 * mat.M12 + M32 * mat.M22 + M33 * mat.M32;
            float m33 = M31 * mat.M13 + M32 * mat.M23 + M33 * mat.M33;
            M11 = m11;
            M12 = m12;
            M13 = m13;

            M21 = m21;
            M22 = m22;
            M23 = m23;

            M31 = m31;
            M32 = m32;
            M33 = m33;
        }
        public void Mul(float v)
        {
            Col1.Mul(v);
            Col2.Mul(v);
            Col3.Mul(v);
        }




        public static Matrix3 operator +(Matrix3 m, float val)
        {
            Matrix3 res = new Matrix3(m);
            res.Add(val);
            return res;
        }
        public static Matrix3 operator +(float val, Matrix3 m)
        {

            Matrix3 res = new Matrix3(m);
            res.Add(val);
            return res;
        }
        public static Matrix3 operator +(Matrix3 l, Matrix3 r)
        {

            Matrix3 res = new Matrix3(l);
            res.Add(r);
            return res;
        }


        public static Matrix3 operator -(Matrix3 m, float val)
        {
            Matrix3 res = new Matrix3(m);
            res.Sub(val);
            return res;
        }
        public static Matrix3 operator -(float val, Matrix3 m)
        {

            Matrix3 res = new Matrix3(m);
            res.Sub(val);
            return res;
        }
        public static Matrix3 operator -(Matrix3 l, Matrix3 r)
        {

            Matrix3 res = new Matrix3(l);
            res.Sub(r);
            return res;
        }

        public static Matrix3 operator *(Matrix3 m, float val)
        {
            Matrix3 res = new Matrix3(m);
            res.Mul(val);
            return res;
        }
        public static Matrix3 operator *(float val, Matrix3 m)
        {

            Matrix3 res = new Matrix3(m);
            res.Mul(val);
            return res;
        }
        public static Matrix3 operator *(Matrix3 l, Matrix3 r)
        {

            Matrix3 res = new Matrix3(l);
            res.Mul(r);
            return res;
        }

        public static Matrix3 operator /(Matrix3 m, float val)
        {
            Matrix3 res = new Matrix3(m);
            res.Div(val);
            return res;
        }
        public static Matrix3 operator /(Matrix3 l, Matrix3 r)
        {

            Matrix3 res = new Matrix3(l);
            res.Div(r);
            return res;
        }




        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }





        public override string ToString()
        {
            return String.Format("{{{0},{1},{2}}}", Row1, Row2 ,Row3);
        }
        public override int GetHashCode()
        {
            return Row1.GetHashCode() ^ Row2.GetHashCode() + Row3.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3))
                return false;

            return this.Equals((Matrix3)obj);
        }

        public bool Equals(Matrix3 other)
        {
            return
                Row1 == other.Row1&&
                Row2 == other.Row2&&
                Row3 == other.Row3;
        }

    }
}
