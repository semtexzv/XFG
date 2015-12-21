using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.MathUtils;
namespace XFG.Gfx
{
    /// <summary>
    /// Simple Camera, can handle Orthographic and Perspective projections,
    /// Rotation+Translations are done in base Right-handed coordinate system
    /// </summary>
    public class Camera
    {
        public Vector3 Position = new Vector3();
        public Vector3 Up = new Vector3(0,1,0);
        public Vector3 Forward = new Vector3(0,0,1);
        public Quaternion Rotation = Quaternion.Identity;

        public Matrix4 Projection = Matrix4.Identity;
        public Matrix4 View = Matrix4.Identity;
        /// <summary>
        /// Creates transform matrix from view matrix
        /// Kinda slow, matrix inversion is costly
        /// </summary>
        public Matrix4 Transform
        {
            get
            {
                return View.Inverse;
            }
        }
        public Matrix4 Combined = Matrix4.Identity;


        public void SetToOrtho(float width, float height)
        {
            Projection = Matrix4.Ortho(width, height, 1000);
        }
        public void SetToPerspective(float fovY, float aspectRatio)
        {
            Projection = Matrix4.PerspectiveInf( 0.01f,fovY, aspectRatio);
        }

        public void Translate(Vector3 p)
        {
            Position += p;
        }
        public void Rotate(Quaternion q)
        {
            Rotation *= q;
            Forward = q.Rotate(Forward);
            Up = q.Rotate(Up);

        }
        private void Renormal()
        {
            Right = Up.Cross(Forward);
            Right.Norm();
            Forward.Norm();
            Up = Forward.Cross(Right);
            Up.Norm();
        }
        private Vector3 Right = new Vector3(1, 0, 0);
        public void Update()
        {
            Renormal();
            View = new Matrix4(); 
            View.Row1 = new Vector4(Right);
            View.Row2 = new Vector4(Up);
            View.Row3 = new Vector4(Forward);
            View.Col4 = new Vector4(-Position.Dot(Right),-Position.Dot(Up),-Position.Dot(Forward), 1);
            Combined = Projection*View;
        }
    }
}
