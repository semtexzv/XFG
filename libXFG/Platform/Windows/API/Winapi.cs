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
        internal static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           IntPtr lpClassName,
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DestroyWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        internal static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        internal static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        internal static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        internal static extern IntPtr DispatchMessage([In] ref MSG lpmsg);
        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        internal static RECT GetClientRect(IntPtr hWnd)
        {
            RECT result;
            GetClientRect(hWnd, out result);
            return result;
        }

        #endregion
        #region Gdi32
        [DllImport("gdi32.dll")]
        internal static extern int ChoosePixelFormat(IntPtr hdc,[In] ref PixelFormatDescriptor ppfd);
        [DllImport("gdi32.dll")]
        internal static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat,ref PixelFormatDescriptor ppfd);
        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern bool SwapBuffers(IntPtr dc);
        #endregion
    }
}
