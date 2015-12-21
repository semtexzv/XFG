using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG.Platform.Windows
{
    class WglDisplay : IDisplay,IInput
    {
        private IntPtr Handle;
        AppListener App;

        private IntPtr WindowProc(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM.PAINT:
                    //Render here
                    App.Render(0);
                    return (IntPtr)0;
                case WM.CLOSE:
                    Logger.Log("Quitting");
                    Environment.Exit(0);
                    return IntPtr.Zero;
                default:
                    return Winapi.DefWindowProc(hWnd, msg, wParam, lParam);
            }
        }
        public WglDisplay(AppConfig config,AppListener app)
        {
            App = app;
            WNDCLASSEX cls = new WNDCLASSEX();
            cls.style = ClassStyles.OwnDC | ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw;
            cls.lpfnWndProc = WindowProc;
            cls.hInstance = Winapi.GetModuleHandle(null);
            cls.hIcon = IntPtr.Zero;
            cls.hCursor = IntPtr.Zero;
            cls.hbrBackground = IntPtr.Zero;
            cls.lpszMenuName = null;
            cls.lpszClassName = Utils.Extensions.RandomString(10) + "Class";
            short windowClass = Winapi.RegisterClassEx(ref cls);
            if (windowClass == 0)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create register window class :{0}", err));
            }
            Handle = Winapi.CreateWindowEx(0, cls.lpszClassName, config.Title,
                    WindowStyles.WS_OVERLAPPEDWINDOW, Wgl.CW_USEDEFAULT, Wgl.CW_USEDEFAULT, config.Width, config.Height, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create dummy window :{0}", err));
            }
            Winapi.ShowWindow(Handle, ShowWindowCommands.Show);
        }

    
        internal void MessageLoop()
        {
            MSG msg;
            int ret;
            while ((ret = Winapi.GetMessage(out msg, Handle, 0, 0)) != 0)
            {
                if (ret == -1)
                {
                    //-1 indicates an error
                    Environment.Exit(1);
                }
                else
                {
                    Winapi.TranslateMessage(ref msg);
                    Winapi.DispatchMessage(ref msg);
                }
            }
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

        public void SetSync(OpenGL.SyncType type)
        {
            throw new NotImplementedException();
        }

        public void SetMode(OpenGL.DisplayMode mode)
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

        public int X
        {
            get { throw new NotImplementedException(); }
        }

        public int Y
        {
            get { throw new NotImplementedException(); }
        }

        public void MakeCurrent()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetProc(string name)
        {
            throw new NotImplementedException();
        }

        public void SwapBuffers()
        {
            throw new NotImplementedException();
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
    }
}
