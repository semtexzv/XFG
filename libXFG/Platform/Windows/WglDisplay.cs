using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG.Platform.Windows
{
    class WglDisplay : IDisplay
    {
        private IntPtr Handle;
        private WglContext Context;
        AppListener App;
        Wgl.WndProc WndProc = new Wgl.WndProc((a, b, c, d) =>
            {
                switch (b)
                {
                    case WM.ERASEBKGND:
                        return (IntPtr)1;
                    case WM.PAINT:
                        //Render here
                        return (IntPtr)0;
                    default:
                        return Wgl.DefWindowProc(a, b, c, d);
                }
            });
        public WglDisplay(AppConfig config,AppListener app)
        {
            App = app;
            WNDCLASS cls = new WNDCLASS();
            cls.style = ClassStyles.OwnDC | ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw;
            cls.lpfnWndProc = WndProc;
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
            Handle = Wgl.CreateWindowEx(0, cls.lpszClassName, config.Title,
                    WindowStyles.WS_OVERLAPPEDWINDOW, 0, 0, 240, 240, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create dummy window :{0}", err));
            }
            Context = new WglContext(Handle);
        }
        internal void Run()
        {
            MSG msg;
            int ret;
            while ((ret = Wgl.GetMessage(out msg, IntPtr.Zero, 0, 0)) != 0)
            {
                if (ret == -1)
                {
                    //-1 indicates an error
                }
                else
                {
                    Wgl.TranslateMessage(ref msg);
                    Wgl.DispatchMessage(ref msg);
                }
            }
        }
        public void SetSync(OpenGL.SyncType type)
        {
            throw new NotImplementedException();
        }

        public void SetFullscreen(bool fullscreen)
        {
            throw new NotImplementedException();
        }

        public int Width
        {
            get { throw new NotImplementedException(); }
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }

        public event OnResizeDelegate OnResized;

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public event OnKeyDelegate OnKeyDown;

        public event OnKeyDelegate OnKeyUp;

        public event OnCharDelegate OnCharacter;

        public event OnMouseMoveDelegate OnMouseMove;

        public event OnMouseDelegate OnMouseDown;

        public event OnMouseDelegate OnMouseUp;

        public event OnScrollDelegate OnScroll;

        public MathUtils.Vector2 GetMousePos()
        {
            throw new NotImplementedException();
        }

        public bool IsKeyDown(Keys key)
        {
            throw new NotImplementedException();
        }

        public bool IsMouseDown(MouseButton button)
        {
            throw new NotImplementedException();
        }

        public Modifiers GetModifiers()
        {
            throw new NotImplementedException();
        }
    }
}
