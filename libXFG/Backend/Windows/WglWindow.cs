using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG.Backend.Windows
{
    class WglWindow : IWindow
    {
        private IntPtr Handle;
        private WglContext Context;
        
        public WglWindow(AppConfig config)
        {
            WNDCLASS cls = new WNDCLASS();
            cls.style = ClassStyles.OwnDC | ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw;
            cls.lpfnWndProc = new Wgl.WndProc((a, b, c, d) =>
            {
                switch (b)
                {
                    case WM.ERASEBKGND:
                        return (IntPtr)1;
                    case WM.PAINT:
                        return (IntPtr)0;
                    default:
                        return Wgl.DefWindowProc(a, b, c, d);
                }
            });
            cls.hInstance = Wgl.GetModuleHandle(null);
            cls.hIcon = IntPtr.Zero;
            cls.hCursor = IntPtr.Zero;
            cls.hbrBackground = IntPtr.Zero;
            cls.lpszMenuName = null;
            cls.lpszClassName = Utils.Extensions.RandomString(10) + "Class";
            ushort windowClass = Wgl.RegisterClass(ref cls);
            if (windowClass == 0)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create register window class :{0}", err));
            }
            Handle = Wgl.CreateWindowEx(0, cls.lpszClassName, Title,
                    WindowStyles.WS_OVERLAPPEDWINDOW, 0, 0, 240, 240, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create dummy window :{0}", err));
            }
            Context = new WglContext(Handle);
        }


        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Fullscreen
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
