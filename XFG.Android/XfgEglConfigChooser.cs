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
using Android.Util;

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
                EGL10.EglRenderableType, EGL14.EglOpenglEs2Bit,
                EGL10.EglNone
            };
            if (!egl.EglChooseConfig(display, configAttribs, configs, 1, num_config))
            {
                throw new Exception("Could not select Egl Display config");
            }
            printConfig(egl, display, configs[0]);
            return configs[0];
        }

        private void printConfig(IEGL10 egl, Javax.Microedition.Khronos.Egl.EGLDisplay display, Javax.Microedition.Khronos.Egl.EGLConfig config)
        {
            int[] attributes = {EGL10.EglBufferSize, EGL10.EglAlphaSize, EGL10.EglBlueSize, EGL10.EglGreenSize,
                EGL10.EglRedSize, EGL10.EglDepthSize, EGL10.EglStencilSize, EGL10.EglConfigCaveat, EGL10.EglConfigId,
                EGL10.EglLevel, EGL10.EglMaxPbufferHeight, EGL10.EglMaxPbufferPixels, EGL10.EglMaxPbufferWidth,
                EGL10.EglNativeRenderable, EGL10.EglNativeVisualId, EGL10.EglNativeVisualType,
                0x3030, // EGL10.EGL_PRESERVED_RESOURCES,
				EGL10.EglSamples, EGL10.EglSampleBuffers, EGL10.EglSurfaceType, EGL10.EglTransparentType,
                EGL10.EglTransparentRedValue, EGL10.EglTransparentGreenValue, EGL10.EglTransparentBlueValue, 0x3039, // EGL10.EGL_BIND_TO_TEXTURE_RGB,
				0x303A, // EGL10.EGL_BIND_TO_TEXTURE_RGBA,
				0x303B, // EGL10.EGL_MIN_SWAP_INTERVAL,
				0x303C, // EGL10.EGL_MAX_SWAP_INTERVAL,
				EGL10.EglLuminanceSize, EGL10.EglAlphaMaskSize, EGL10.EglColorBufferType, EGL10.EglRenderableType, 0x3042 // EGL10.EGL_CONFORMANT
			};
            String[] names = {"EGL_BUFFER_SIZE", "EGL_ALPHA_SIZE", "EGL_BLUE_SIZE", "EGL_GREEN_SIZE", "EGL_RED_SIZE",
                "EGL_DEPTH_SIZE", "EGL_STENCIL_SIZE", "EGL_CONFIG_CAVEAT", "EGL_CONFIG_ID", "EGL_LEVEL", "EGL_MAX_PBUFFER_HEIGHT",
                "EGL_MAX_PBUFFER_PIXELS", "EGL_MAX_PBUFFER_WIDTH", "EGL_NATIVE_RENDERABLE", "EGL_NATIVE_VISUAL_ID",
                "EGL_NATIVE_VISUAL_TYPE", "EGL_PRESERVED_RESOURCES", "EGL_SAMPLES", "EGL_SAMPLE_BUFFERS", "EGL_SURFACE_TYPE",
                "EGL_TRANSPARENT_TYPE", "EGL_TRANSPARENT_RED_VALUE", "EGL_TRANSPARENT_GREEN_VALUE", "EGL_TRANSPARENT_BLUE_VALUE",
                "EGL_BIND_TO_TEXTURE_RGB", "EGL_BIND_TO_TEXTURE_RGBA", "EGL_MIN_SWAP_INTERVAL", "EGL_MAX_SWAP_INTERVAL",
                "EGL_LUMINANCE_SIZE", "EGL_ALPHA_MASK_SIZE", "EGL_COLOR_BUFFER_TYPE", "EGL_RENDERABLE_TYPE", "EGL_CONFORMANT"};
            int[] value = new int[1];
            for (int i = 0; i < attributes.Length; i++)
            {
                int attribute = attributes[i];
                String name = names[i];
                
                if (egl.EglGetConfigAttrib(display, config, attribute, value))
                {
                    Log.Warn("EGLCONFIG", String.Format("  {0}: {1}\n", name, value[0]));
                }
                else
                {
                   
                    while (egl.EglGetError() != EGL10.EglSuccess)    ;
                }
            }
        }



    }
}