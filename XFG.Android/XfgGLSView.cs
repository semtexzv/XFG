using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Opengl;
using Android.Util;
using Android.Views.InputMethods;
using Javax.Microedition.Khronos.Egl;
using XFG.Platform;
using XFG.OpenGL;
using static Android.Opengl.GLSurfaceView;
using Javax.Microedition.Khronos.Opengles;

namespace XFG
{
    public class XfgGLSView : GLSurfaceView, IDisplay,IRenderer
    {
        public XfgGLSView(Context context,DisplayFormat format) : base(context)
        {
            SetEGLConfigChooser(format.Red, format.Green, format.Blue, format.Alpha, format.Depth, format.Stencil);
            SetRenderer(this);
        }

        int IDisplay.Height
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int IDisplay.Width
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        event OnResizeDelegate IDisplay.OnResized
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IDisplay.Hide()
        {
            throw new NotImplementedException();
        }

        void IDisplay.SetMode(DisplayMode mode)
        {
        }

        void IDisplay.SetVSync(bool sync)
        {
            throw new NotImplementedException();
        }

        void IDisplay.Show()
        {
            throw new NotImplementedException();
        }

        bool IDisplay.SupportsVSync()
        {
            throw new NotImplementedException();
        }

        public void OnDrawFrame(IGL10 gl)
        {
            gl.GlClear(GL10.GlColorBufferBit);
            gl.GlClearColor(1.0f, 0.0f, 0.0f, 0.5f);
        }

        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
           
        }

        public void OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
        {

        }
    }
}