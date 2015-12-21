using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

using GLbitfield = System.UInt32;
using GLboolean = System.Boolean;
using GLbyte = System.SByte;
using GLclampf = System.Single;
using GLdouble = System.Double;
using GLenum = System.UInt32;
using GLfloat = System.Single;
using GLint = System.Int32;
using GLintPtr = System.IntPtr;
using GLshort = System.Int16;
using GLsizei = System.Int32;
using GLubyte = System.Byte;
using GLuint = System.UInt32;
using GLushort = System.UInt16;
using GLvoid = System.IntPtr;
using System.Collections.Generic;

namespace XFG.Backend.Windows
{
    internal static partial class Wgl
    {
        internal static IntPtr _glDLL = IntPtr.Zero;
        private static IntPtr OpenGLLib
        {
            get
            {
                if (_glDLL == IntPtr.Zero)
                    _glDLL = LoadLibrary("opengl32.dll");
                return _glDLL;
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
            IntPtr res = externGetProcAddress(OpenGLLib, name);
            if (res == IntPtr.Zero)
                return wglGetProcAddress(name);
            else
                return res;
        }

        internal delegate UIntPtr wglCreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, int[] attribList);
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

