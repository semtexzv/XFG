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
using XFG.OpenGL;
using XFG.Platform;
using Android.Opengl;
using Javax.Microedition.Khronos.Egl;
using Javax.Microedition.Khronos.Opengles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace XFG
{
    class AndroidDisplay : Java.Lang.Object, IDisplay,GLSurfaceView.IRenderer
    {
        public GLSurfaceView view;
        private Stopwatch sw;
        private long lastTicks;
        private float deltaTime;
        private int width;
        private int height;

        private AndroidApplication application;

        public AndroidDisplay(AndroidApplication application, AndroidApplicationConfig config)
        {
            sw = new Stopwatch();
            this.application = application;
            createGLSurfaceView(config.displayFormat, application);
        }


        protected void createGLSurfaceView(DisplayFormat format, AndroidApplication application)
        {
            GLSurfaceView.IEGLConfigChooser configChooser = new XfgEglConfigChooser(format);

            view = new GLSurfaceView(application.ApplicationContext);
            view.SetEGLConfigChooser(configChooser);

            view.SetRenderer(this);
            this.application = application;
        }

        public float Delta
        {
            get
            {
                return deltaTime;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }
        
        public event OnResizeDelegate OnResized;

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void SetMode(DisplayMode mode)
        {
            throw new NotImplementedException();
        }

        public void SetVSync(bool sync)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public bool SupportsVSync()
        {
            throw new NotImplementedException();
        }

        void GLSurfaceView.IRenderer.OnDrawFrame(IGL10 gl)
        {
            long ticks = sw.ElapsedTicks;

            deltaTime = (ticks - lastTicks) / Stopwatch.Frequency;
            application.listener.Render(Delta);
        }

        void GLSurfaceView.IRenderer.OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            this.width = width;
            this.height = height;
            gl.GlViewport(0, 0, width, height);
            if (OnResized != null)
            {
                OnResized.Invoke(width, height);
            }
        }
        [DllImport("libGLESv2.so")]
        public static extern IntPtr eglGetProcAddress(string procname);


        void GLSurfaceView.IRenderer.OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
        {
            sw.Start();
            lastTicks = sw.ElapsedTicks;
            XFG.OpenGL.GL.Load((name) =>
            {
                return eglGetProcAddress(name);
            });

        }
        
    }
}