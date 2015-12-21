using System;
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
using XFG.OpenGL;

namespace XFG.Platform.Windows
{
    internal static partial class Wgl 
    {

        internal delegate IntPtr WndProc(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);


        private const string KERN_DLL = "Kernel32.dll";

        [DllImport(KERN_DLL, EntryPoint = "LoadLibrary")]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(KERN_DLL, EntryPoint = "GetProcAddress")]
        private static extern IntPtr externGetProcAddress(IntPtr library, string lpProcName);

        [DllImport(KERN_DLL, EntryPoint = "FreeLibrary")]
        internal static extern bool FreeLibrary(IntPtr library);

        [DllImport(KERN_DLL, CharSet = CharSet.Unicode)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);



        private const string GL_DLL = "opengl32.dll";

        [DllImport(GL_DLL, EntryPoint = "wglCreateContext", ExactSpelling = true)]
        internal static extern UIntPtr CreateContext(IntPtr HDC);

        [DllImport(GL_DLL, EntryPoint = "wglDeleteContext", ExactSpelling = true)]
        internal static extern bool DeleteContext(UIntPtr HRC);

        [DllImport(GL_DLL, EntryPoint = "wglGetCurrentContext", ExactSpelling = true)]
        internal static extern uint GetCurrentContext();

        [DllImport(GL_DLL, EntryPoint = "wglGetCurrentDC", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentDC();

        [DllImport(GL_DLL, EntryPoint = "wglMakeCurrent", ExactSpelling = true)]
        internal static extern bool MakeCurrent(IntPtr HDC, UIntPtr HRC);

        [DllImport(GL_DLL, EntryPoint = "wglCopyContext", ExactSpelling = true)]
        internal static extern bool CopyContext(uint HRCSrc, UIntPtr HRCDst, uint Mask);

        [DllImport(GL_DLL, EntryPoint = "wglGetProcAddress", ExactSpelling = true)]
        private static extern IntPtr wglGetProcAddress(string lpszProc);

      
        [DllImport(GL_DLL, EntryPoint = "glGetString")]
        internal static extern IntPtr exGlGetString(StringName name);

        internal static string GlGetString(StringName name)
        {
            return Marshal.PtrToStringAnsi(exGlGetString(name));
        }
        
        [DllImport(GL_DLL, EntryPoint = "glGetError")]
        public static extern GLenum GetError();

        private const string GDI_DLL = "gdi32.dll";

        [DllImport(GDI_DLL, EntryPoint = "GetPixelFormat", ExactSpelling = true)]
        internal static extern int GetPixelFormat(IntPtr HDC);

        [DllImport(GDI_DLL, EntryPoint = "ChoosePixelFormat", ExactSpelling = true)]
        internal static extern int ChoosePixelFormat(IntPtr hDc, ref PixelFormat PFD);

        [DllImport(GDI_DLL, EntryPoint = "DescribePixelFormat", ExactSpelling = true)]
        internal static extern int DescribePixelFormat(IntPtr HDC, int IndexPFD, UInt32 cjpfd, ref PixelFormat PFD);

        [DllImport(GDI_DLL, EntryPoint = "SetPixelFormat", ExactSpelling = true)]
        internal static extern bool SetPixelFormat(IntPtr HDC, int IndexPFD, ref PixelFormat PFD);
        
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern bool SwapBuffers(IntPtr dc);





        private const string USER_DLL = "user32.dll";
        [DllImport(USER_DLL)]
        internal static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport(USER_DLL)]
        internal static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport(USER_DLL)]
        internal static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport(USER_DLL, EntryPoint = "GetDC", ExactSpelling = true)]
        internal static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport(USER_DLL, EntryPoint = "ReleaseDC")]
        internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport(USER_DLL, EntryPoint = "RegisterClass", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern ushort RegisterClass([In] ref WNDCLASS lpWndClass);

        [DllImport(USER_DLL, EntryPoint = "UnregisterClass", ExactSpelling = true)]
        internal static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        [DllImport(USER_DLL, EntryPoint = "CallWindowProc", ExactSpelling = true)]
        internal static extern IntPtr CallWindowProc(WndProc lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER_DLL, EntryPoint = "DefWindowProc", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER_DLL, CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport(USER_DLL, CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool SetWindowText(IntPtr hwnd,string text);

        [DllImport(USER_DLL, EntryPoint = "CreateWindowEx", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(
           uint dwExStyle,
           string lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PixelFormat
    {
        public ushort nSize;
        public ushort nVersion;
        public Flag dwFlags;
        public Type PixelType;
        public byte cColorBits;
        public byte cRedBits;
        public byte cRedShift;
        public byte cGreenBits;
        public byte cGreenShift;
        public byte cBlueBits;
        public byte cBlueShift;
        public byte cAlphaBits;
        public byte cAlphaShift;
        public byte cAccumBits;
        public byte cAccumRedBits;
        public byte cAccumGreenBits;
        public byte cAccumBlueBits;
        public byte cAccumAlphaBits;
        public byte cDepthBits;
        public byte cStencilBits;
        public byte cAuxBuffers;
        public Plane LayerType;
        public byte bReserved;
        public uint dwLayerMask;
        public uint dwVisibleMask;
        public uint dwDamageMask;
        // 40 bytes total

        public static PixelFormat Zero
        {
            get
            {
                PixelFormat PF;

                PF.nSize = 40;
                PF.nVersion = 0;
                PF.dwFlags = 0;
                PF.PixelType = Type.RGBA;
                PF.cColorBits = 0;
                PF.cRedBits = 0;
                PF.cRedShift = 0;
                PF.cGreenBits = 0;
                PF.cGreenShift = 0;
                PF.cBlueBits = 0;
                PF.cBlueShift = 0;
                PF.cAlphaBits = 0;
                PF.cAlphaShift = 0;
                PF.cAccumBits = 0;
                PF.cAccumRedBits = 0;
                PF.cAccumGreenBits = 0;
                PF.cAccumBlueBits = 0;
                PF.cAccumAlphaBits = 0;
                PF.cDepthBits = 0;
                PF.cStencilBits = 0;
                PF.cAuxBuffers = 0;
                PF.LayerType = Plane.Main;
                PF.bReserved = 0;
                PF.dwLayerMask = 0;
                PF.dwVisibleMask = 0;
                PF.dwDamageMask = 0;

                return PF;
            }
        }

        public static PixelFormat Default
        {
            get
            {
                PixelFormat PF;

                PF.nSize = 40;
                PF.nVersion = 1;
                PF.dwFlags = Flag.DrawToWindow | Flag.SupportOpenGL | Flag.DoubleBuffer | Flag.SwapCopy;
                PF.PixelType = Type.RGBA;
                PF.cColorBits = 32;
                PF.cRedBits = 0;
                PF.cRedShift = 0;
                PF.cGreenBits = 0;
                PF.cGreenShift = 0;
                PF.cBlueBits = 0;
                PF.cBlueShift = 0;
                PF.cAlphaBits = 0;
                PF.cAlphaShift = 0;
                PF.cAccumBits = 0;
                PF.cAccumRedBits = 0;
                PF.cAccumGreenBits = 0;
                PF.cAccumBlueBits = 0;
                PF.cAccumAlphaBits = 0;
                PF.cDepthBits = 32;
                PF.cStencilBits = 0;
                PF.cAuxBuffers = 0;
                PF.LayerType = Plane.Main;
                PF.bReserved = 0;
                PF.dwLayerMask = 0;
                PF.dwVisibleMask = 0;
                PF.dwDamageMask = 0;

                return PF;
            }
        }

        [Flags]
        public enum Flag : uint
        {
            DoubleBuffer = 0x00000001,
            Stereo = 0x00000002,
            DrawToWindow = 0x00000004,
            DrawToBitmap = 0x00000008,

            SupportGDI = 0x00000010,
            SupportOpenGL = 0x00000020,
            GenericFormat = 0x00000040,
            NeedPalette = 0x00000080,

            NeedSystemPalette = 0x00000100,
            SwapExchange = 0x00000200,
            SwapCopy = 0x00000400,
            SwapLayerBuffers = 0x00000800,

            GenericAccellerated = 0x00001000,
            SupportDirectDraw = 0x00002000,
        }
        public enum Type : byte
        {
            RGBA = 0,
            ColorIndex = 1,
        }
        public enum Plane : sbyte
        {
            Main = 0,
            Overlay = 1,
            Underlay = -1,
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WNDCLASS
    {
        public ClassStyles style;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Wgl.WndProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszMenuName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszClassName;
    }

    [Flags]
    enum ClassStyles : uint
    {
        ByteAlignClient = 0x1000,
        ByteAlignWindow = 0x2000,
        ClassDC = 0x40,
        DoubleClicks = 0x8,
        DropShadow = 0x20000,
        GlobalClass = 0x4000,
        HorizontalRedraw = 0x2,
        NoClose = 0x200,
        OwnDC = 0x20,
        ParentDC = 0x80,
        SaveBits = 0x800,
        VerticalRedraw = 0x1
    }
    [Flags]
    enum WindowStyles : uint
    {
        WS_BORDER = 0x800000,
        WS_CAPTION = 0xc00000,
        WS_CHILD = 0x40000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_DISABLED = 0x8000000,
        WS_DLGFRAME = 0x400000,
        WS_GROUP = 0x20000,
        WS_HSCROLL = 0x100000,
        WS_MAXIMIZE = 0x1000000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_MINIMIZE = 0x20000000,
        WS_MINIMIZEBOX = 0x20000,
        WS_OVERLAPPED = 0x0,
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUP = 0x80000000u,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_SIZEFRAME = 0x40000,
        WS_SYSMENU = 0x80000,
        WS_TABSTOP = 0x10000,
        WS_VISIBLE = 0x10000000,
        WS_VSCROLL = 0x200000
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public UInt32 message;
        public UIntPtr wParam;
        public UIntPtr lParam;
        public UInt32 time;
        public POINT pt;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public Int32 x;
        public Int32 Y;
    }  
}
