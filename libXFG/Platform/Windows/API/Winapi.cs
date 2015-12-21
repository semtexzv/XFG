using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG.Platform.Windows
{
    internal static class Winapi
    {
        #region Kernel32 
        [DllImport("kernel32")]
        internal static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32")]
        internal static extern bool FreeLibrary(IntPtr library);
        [DllImport("kernel32")]
        internal static extern IntPtr GetProcAddress(IntPtr library, string lpProcName);
        [DllImport("kernel32")]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        #region User32
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.U2)]
        internal static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
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

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
        [DllImport("user32.dll")]
        internal static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        internal static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        internal static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        internal static extern IntPtr DispatchMessage([In] ref MSG lpmsg);
        #endregion
        #region Gdi32

        #endregion

    }
}
