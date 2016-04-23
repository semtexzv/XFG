using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Javax.Microedition.Khronos.Egl;

namespace XFG
{
    class XfgEglConfigChooser : Java.Lang.Object, GLSurfaceView.IEGLConfigChooser
    {
        private static int EGL_OPENGL_ES2_BIT = 4;

        private DisplayFormat format;
        public XfgEglConfigChooser(DisplayFormat format)
        {
            this.format = format;
        }

        public Javax.Microedition.Khronos.Egl.EGLConfig ChooseConfig(IEGL10 egl, Javax.Microedition.Khronos.Egl.EGLDisplay display)
        {
            int[] num_config = new int[1];
            Javax.Microedition.Khronos.Egl.EGLConfig[] configs = new Javax.Microedition.Khronos.Egl.EGLConfig[1];

            int[] configAttribs = new int[] {
                EGL10.EglRedSize, format.Red,
                EGL10.EglGreenSize, format.Green,
                EGL10.EglBlueSize, format.Blue,
                EGL10.EglAlphaSize, format.Alpha,
                EGL10.EglDepthSize, format.Depth,
                EGL10.EglSampleBuffers, format.SampleBuffers,
                EGL10.EglSamples,format.Samples,
                EGL10.EglRenderableType, EGL_OPENGL_ES2_BIT,
                EGL10.EglNone
            };
            if (!egl.EglChooseConfig(display, configAttribs, configs, 1, num_config))
            {
                throw new Exception("Could not select Egl Display config");
            }
            return configs[0];
        }



    }
}