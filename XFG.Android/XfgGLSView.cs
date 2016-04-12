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

namespace XFG
{
    class XfgGLSView : GLSurfaceView
    {
        public XfgGLSView(Context context) : base(context)
        {
        }

        public XfgGLSView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
        public override IInputConnection OnCreateInputConnection(EditorInfo outAttrs)
        {
            return base.OnCreateInputConnection(outAttrs);
        }
        public class XfgEGLConfigChooser : IEGLConfigChooser
        {
            public XfgEGLConfigChooser()
            {

            }
            public IntPtr Handle
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Javax.Microedition.Khronos.Egl.EGLConfig ChooseConfig(IEGL10 egl, Javax.Microedition.Khronos.Egl.EGLDisplay display)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}