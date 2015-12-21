using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;

namespace XFG.Platform.Windows
{
    internal static partial class Wgl
    {
        #region Functions
        [DllImport("opengl32.dll", EntryPoint = "wglCreateContext", ExactSpelling = true)]
        internal static extern UIntPtr CreateContext(IntPtr HDC);

        [DllImport("opengl32.dll", EntryPoint = "wglDeleteContext", ExactSpelling = true)]
        internal static extern bool DeleteContext(UIntPtr HRC);

        [DllImport("opengl32.dll", EntryPoint = "wglGetCurrentContext", ExactSpelling = true)]
        internal static extern uint GetCurrentContext();

        [DllImport("opengl32.dll", EntryPoint = "wglGetCurrentDC", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentDC();

        [DllImport("opengl32.dll", EntryPoint = "wglMakeCurrent", ExactSpelling = true)]
        internal static extern bool MakeCurrent(IntPtr HDC, UIntPtr HRC);

        [DllImport("opengl32.dll", EntryPoint = "wglCopyContext", ExactSpelling = true)]
        internal static extern bool CopyContext(uint HRCSrc, UIntPtr HRCDst, uint Mask);

        [DllImport("opengl32.dll", EntryPoint = "wglGetProcAddress", ExactSpelling = true)]
        private static extern IntPtr wglGetProcAddress(string lpszProc);
        #endregion
        #region Consts
        internal const int CONTEXT_DEBUG_BIT_ARB = 0x00000001;
        internal const int CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 0x00000002;
        internal const int CONTEXT_ES2_PROFILE_BIT_EXT = 0x00000004;

        internal const int CONTEXT_MAJOR_VERSION_ARB = 0x2091;
        internal const int CONTEXT_MINOR_VERSION_ARB = 0x2092;
        internal const int CONTEXT_LAYER_PLANE_ARB = 0x2093;
        internal const int CONTEXT_FLAGS_ARB = 0x2094;
        internal const int CONTEXT_PROFILE_MASK_ARB = 0x9126;
        internal const int CONTEXT_CORE_PROFILE_BIT_ARB = 0x00000001;
        internal const int CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 0x00000002;
        internal const int ERROR_INVALID_VERSION_ARB = 0x2095;

        internal const int NUMBER_PIXEL_FORMATS_ARB = 0x2000;
        internal const int DRAW_TO_WINDOW_ARB = 0x2001;
        internal const int DRAW_TO_BITMAP_ARB = 0x2002;
        internal const int ACCELERATION_ARB = 0x2003;
        internal const int NEED_PALETTE_ARB = 0x2004;
        internal const int NEED_SYSTEM_PALETTE_ARB = 0x2005;
        internal const int SWAP_LAYER_BUFFERS_ARB = 0x2006;
        internal const int SWAP_METHOD_ARB = 0x2007;
        internal const int NUMBER_OVERLAYS_ARB = 0x2008;
        internal const int NUMBER_UNDERLAYS_ARB = 0x2009;
        internal const int TRANSPARENT_ARB = 0x200A;
        internal const int TRANSPARENT_RED_VALUE_ARB = 0x2037;
        internal const int TRANSPARENT_GREEN_VALUE_ARB = 0x2038;
        internal const int TRANSPARENT_BLUE_VALUE_ARB = 0x2039;
        internal const int TRANSPARENT_ALPHA_VALUE_ARB = 0x203A;
        internal const int TRANSPARENT_INDEX_VALUE_ARB = 0x203B;
        internal const int SHARE_DEPTH_ARB = 0x200C;
        internal const int SHARE_STENCIL_ARB = 0x200D;
        internal const int SHARE_ACCUM_ARB = 0x200E;
        internal const int SUPPORT_GDI_ARB = 0x200F;
        internal const int SUPPORT_OPENGL_ARB = 0x2010;
        internal const int DOUBLE_BUFFER_ARB = 0x2011;
        internal const int STEREO_ARB = 0x2012;
        internal const int PIXEL_TYPE_ARB = 0x2013;
        internal const int COLOR_BITS_ARB = 0x2014;
        internal const int RED_BITS_ARB = 0x2015;
        internal const int RED_SHIFT_ARB = 0x2016;
        internal const int GREEN_BITS_ARB = 0x2017;
        internal const int GREEN_SHIFT_ARB = 0x2018;
        internal const int BLUE_BITS_ARB = 0x2019;
        internal const int BLUE_SHIFT_ARB = 0x201A;
        internal const int ALPHA_BITS_ARB = 0x201B;
        internal const int ALPHA_SHIFT_ARB = 0x201C;
        internal const int ACCUM_BITS_ARB = 0x201D;
        internal const int ACCUM_RED_BITS_ARB = 0x201E;
        internal const int ACCUM_GREEN_BITS_ARB = 0x201F;
        internal const int ACCUM_BLUE_BITS_ARB = 0x2020;
        internal const int ACCUM_ALPHA_BITS_ARB = 0x2021;
        internal const int DEPTH_BITS_ARB = 0x2022;
        internal const int STENCIL_BITS_ARB = 0x2023;
        internal const int AUX_BUFFERS_ARB = 0x2024;
        internal const int NO_ACCELERATION_ARB = 0x2025;
        internal const int GENERIC_ACCELERATION_ARB = 0x2026;
        internal const int FULL_ACCELERATION_ARB = 0x2027;
        internal const int SWAP_EXCHANGE_ARB = 0x2028;
        internal const int SWAP_COPY_ARB = 0x2029;
        internal const int SWAP_UNDEFINED_ARB = 0x202A;
        internal const int TYPE_RGBA_ARB = 0x202B;
        internal const int TYPE_COLORINDEX_ARB = 0x202C;

        internal const int NUMBER_PIXEL_FORMATS_EXT = 0x2000;
        internal const int DRAW_TO_WINDOW_EXT = 0x2001;
        internal const int DRAW_TO_BITMAP_EXT = 0x2002;
        internal const int ACCELERATION_EXT = 0x2003;
        internal const int NEED_PALETTE_EXT = 0x2004;
        internal const int NEED_SYSTEM_PALETTE_EXT = 0x2005;
        internal const int SWAP_LAYER_BUFFERS_EXT = 0x2006;
        internal const int SWAP_METHOD_EXT = 0x2007;
        internal const int NUMBER_OVERLAYS_EXT = 0x2008;
        internal const int NUMBER_UNDERLAYS_EXT = 0x2009;
        internal const int TRANSPARENT_EXT = 0x200A;
        internal const int TRANSPARENT_VALUE_EXT = 0x200B;
        internal const int SHARE_DEPTH_EXT = 0x200C;
        internal const int SHARE_STENCIL_EXT = 0x200D;
        internal const int SHARE_ACCUM_EXT = 0x200E;
        internal const int SUPPORT_GDI_EXT = 0x200F;
        internal const int SUPPORT_OPENGL_EXT = 0x2010;
        internal const int DOUBLE_BUFFER_EXT = 0x2011;
        internal const int STEREO_EXT = 0x2012;
        internal const int PIXEL_TYPE_EXT = 0x2013;
        internal const int COLOR_BITS_EXT = 0x2014;
        internal const int RED_BITS_EXT = 0x2015;
        internal const int RED_SHIFT_EXT = 0x2016;
        internal const int GREEN_BITS_EXT = 0x2017;
        internal const int GREEN_SHIFT_EXT = 0x2018;
        internal const int BLUE_BITS_EXT = 0x2019;
        internal const int BLUE_SHIFT_EXT = 0x201A;
        internal const int ALPHA_BITS_EXT = 0x201B;
        internal const int ALPHA_SHIFT_EXT = 0x201C;
        internal const int ACCUM_BITS_EXT = 0x201D;
        internal const int ACCUM_RED_BITS_EXT = 0x201E;
        internal const int ACCUM_GREEN_BITS_EXT = 0x201F;
        internal const int ACCUM_BLUE_BITS_EXT = 0x2020;
        internal const int ACCUM_ALPHA_BITS_EXT = 0x2021;
        internal const int DEPTH_BITS_EXT = 0x2022;
        internal const int STENCIL_BITS_EXT = 0x2023;
        internal const int AUX_BUFFERS_EXT = 0x2024;
        internal const int NO_ACCELERATION_EXT = 0x2025;
        internal const int GENERIC_ACCELERATION_EXT = 0x2026;
        internal const int FULL_ACCELERATION_EXT = 0x2027;
        internal const int SWAP_EXCHANGE_EXT = 0x2028;
        internal const int SWAP_COPY_EXT = 0x2029;
        internal const int SWAP_UNDEFINED_EXT = 0x202A;
        internal const int TYPE_RGBA_EXT = 0x202B;
        internal const int TYPE_COLORINDEX_EXT = 0x202C;
        internal const int SAMPLE_BUFFERS_ARB = 0x2041;
        internal const int SAMPLES_ARB = 0x2042;
        internal const int CW_USEDEFAULT = int.MinValue;
        #endregion
        internal static IntPtr glDLL = IntPtr.Zero;
        private static IntPtr OpenGLLib
        {
            get
            {
                if (glDLL == IntPtr.Zero)
                    glDLL = Winapi.LoadLibrary("opengl32.dll");
                return glDLL;
            }
        }
        internal static T GlGetProc<T>(string name)
        {
            IntPtr procAdd = wglGetProcAddress(name);
            if (procAdd == IntPtr.Zero)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(Marshal.GetDelegateForFunctionPointer(procAdd, typeof(T)), typeof(T));

        }
        //WglGetProcAddres does not work on fuctions from opengl 1.1
        //We muse obtain them using LoadLibrarz and GetProcAddress
        //Sigh ....

        internal static IntPtr GlGetProcAddress(string name)
        {
            IntPtr res = Winapi.GetProcAddress(OpenGLLib, name);
            if (res == IntPtr.Zero)
                return wglGetProcAddress(name);
            else
                return res;
        }

        internal delegate IntPtr wglCreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, int[] attribList);
        internal delegate bool wglGetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues);
        internal delegate bool wglGetPixelFormatAttribfvARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues);
        internal delegate bool wglChoosePixelFormatARB(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, ref int piFormats, ref uint nNumFormats);

        internal delegate int _wglGetSwapIntervalEXT();
        internal delegate bool _wglSwapIntervalEXT(int interval);


        internal static wglCreateContextAttribsARB CreateContextAttribs;
        internal static wglGetPixelFormatAttribivARB GetPixelFormatAttribiv;
        internal static wglGetPixelFormatAttribfvARB GetPixelFormatAttribfv;
        internal static wglChoosePixelFormatARB ChoosePixelFormatARB;

        internal static _wglGetSwapIntervalEXT GetSwapIntervalEXT;
        internal static _wglSwapIntervalEXT SwapIntervalEXT;

        private delegate IntPtr wglGetExtensionsStringARB(IntPtr hdc);
        private static wglGetExtensionsStringARB GetExtensionsStringARB;
        internal static string GetExtensionsString(IntPtr hDC)
        {
            return Marshal.PtrToStringAnsi(GetExtensionsStringARB(hDC));
        }
        internal static void LoadFuncs()
        {
            CreateContextAttribs = GlGetProc<wglCreateContextAttribsARB>("wglCreateContextAttribsARB");
            GetPixelFormatAttribiv = GlGetProc<wglGetPixelFormatAttribivARB>("wglGetPixelFormatAttribivARB");
            GetPixelFormatAttribfv = GlGetProc<wglGetPixelFormatAttribfvARB>("wglGetPixelFormatAttribfvARB");
            ChoosePixelFormatARB = GlGetProc<wglChoosePixelFormatARB>("wglChoosePixelFormatARB");
            GetExtensionsStringARB = GlGetProc<wglGetExtensionsStringARB>("wglGetExtensionsStringARB");
            GetSwapIntervalEXT = GlGetProc<_wglGetSwapIntervalEXT>("wglGetSwapIntervalEXT");
            SwapIntervalEXT = GlGetProc<_wglSwapIntervalEXT>("wglSwapIntervalEXT");
        }
    }
}

