using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using XFG.MathUtils;
using XFG.OpenGL;

namespace XFG.Platform.Windows
{
    class WglDisplay : IDisplay,IInput
    {
        private IntPtr WindowHandle;
        private IntPtr Instance;
        private WglContext Context;

        public DisplayFormat Format
        {
            get;
            private set;
        }

		public WglDisplay(AppConfig config)
		{
			CreateWindow(config);
			Context = new WglContext(WindowHandle, null);

			Winapi.ShowWindow(WindowHandle, ShowWindowCommands.Show);
		}
        

        private IntPtr WindowProc(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM.CREATE:
                    return IntPtr.Zero;
                case WM.SIZE:
                    Width = (int)lParam & 0x0000FFFF;
                    Height = (int)lParam >> 16;
                    Logger.Debug("size changedto {0} {1} ", Width, Height);
                    if (OnResized != null)
                    {
                        OnResized(Width, Height);
                    }
                    if (GL.Viewport != null)
                    {
                        GL.Viewport(0, 0, Width, Height);
                    }
                    return IntPtr.Zero;
                case WM.PAINT:
                    Context.MakeCurrent();
                    App.Render(0);
                    Context.SwapBuffers();
                    return (IntPtr)0;
                case WM.CLOSE:
                    Logger.Log("Quitting");
                    Environment.Exit(0);
                    return IntPtr.Zero;
                default:
                    return Winapi.DefWindowProc(hWnd, msg, wParam, lParam);
            }
        }
        internal AppListener App;
        internal void MessageLoop(AppListener app)
        {
            App = app;
            MSG msg;
            int ret;
            while ((ret = Winapi.GetMessage(out msg, WindowHandle, 0, 0)) != 0)
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
        public bool SupportsVSync()
        {
            return Context.SupportsVSync();
        }
        public void SetVSync(bool sync)
        {
            Context.SetVSync(sync);
        }

        public void SetMode(OpenGL.DisplayMode mode)
        {
            throw new NotImplementedException();
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }
        public event OnResizeDelegate OnResized;
        public event OnKeyDelegate OnKeyDown;
        public event OnKeyDelegate OnKeyUp;
        public event OnCharDelegate OnCharacter;
        public event OnMouseMoveDelegate OnMouseMove;
        public event OnMouseDelegate OnMouseDown;
        public event OnMouseDelegate OnMouseUp;
        public event OnScrollDelegate OnScroll;

        public void Hide()
        {
            Winapi.ShowWindow(WindowHandle, ShowWindowCommands.Hide);
        }

        public void Show()
        {
            Winapi.ShowWindow(WindowHandle, ShowWindowCommands.Show);
        }
        internal void CreateWindow(AppConfig config)
        {
            Instance = Winapi.GetModuleHandle(null);
            WNDCLASSEX cls = new WNDCLASSEX();
            cls.cbSize = Marshal.SizeOf(cls);
            cls.style = ClassStyles.OwnDC | ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw;
            cls.lpfnWndProc = WindowProc;
            cls.hInstance = Instance;
            cls.hIcon = IntPtr.Zero;
            cls.hCursor = IntPtr.Zero;
            cls.hbrBackground = IntPtr.Zero;
            cls.lpszMenuName = null;
            cls.lpszClassName = Utils.Extensions.RandomString(2) + "Class";
            uint windowClass = Winapi.RegisterClassEx(ref cls);
            if (windowClass == 0)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create register window class :{0}", err));
            }
            WindowHandle = Winapi.CreateWindowEx(0, (IntPtr)windowClass, config.Title,
                    WindowStyles.WS_OVERLAPPEDWINDOW, Wgl.CW_USEDEFAULT, Wgl.CW_USEDEFAULT, config.Width, config.Height, IntPtr.Zero, IntPtr.Zero, Instance, IntPtr.Zero);
            if (WindowHandle == IntPtr.Zero)
            {
                int err = Marshal.GetLastWin32Error();
                throw new Exception(String.Format("Could not create window :{0}", err));
            }
            RECT rect = Winapi.GetWindowRect(WindowHandle);
            Winapi.AdjustWindowRectEx(ref rect, (uint)(WindowStyles.WS_CAPTION | WindowStyles.WS_SYSMENU | WindowStyles.WS_MINIMIZEBOX), false, 0);
            Winapi.SetWindowPos(WindowHandle, IntPtr.Zero, 0, 0, rect.Right - rect.Left, rect.Bottom - rect.Top, SetWindowPosFlags.NOMOVE | SetWindowPosFlags.NOZORDER);

        }

        public Vector2 GetMousePos()
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
