using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XFG;
using XFG.OpenGL;

namespace XFG.Platform.Windows
{
    internal class WglContext : GLContext
    {
        public IntPtr WindowHandle;
        public IntPtr WindowDC;
        private UIntPtr ContextHandle;

        private static List<string> WglExtensions = new List<string>();
        private static List<string> Extensions = new List<string>();
        private static int VersionMax = 0;
        private static bool InitializedFunctions = false;
        private static object threadLocker = new object();
        private static bool ES2Support = false;

        public DisplayFormat Format
        {
            get;
            private set;
        }
        private SyncType _sync;
        private IntPtr Handle;
        public override SyncType Sync
        {
            get
            {
                return _sync;
            }

            set
            {
                _sync = value;
                if (_sync == SyncType.AVSync && !AVsyncAvailable())
                    _sync = SyncType.VSync;
                if (_sync == SyncType.VSync && !VsyncAvailable())
                    _sync = SyncType.None;

                Wgl.SwapIntervalEXT((int)_sync);
            }
        }
        public override bool VsyncAvailable()
        {
            return WglExtensions.Contains("WGL_EXT_swap_control");
        }

        public override bool AVsyncAvailable()
        {
            return WglExtensions.Contains("WGL_EXT_swap_control_tear");
        }
        //We use rgb888 as default
        public WglContext(IntPtr windowHandle,DisplayFormat format= null)
        {
            WindowHandle = windowHandle;
            WindowDC = Wgl.GetDC(windowHandle);
            if(!InitializedFunctions)
                CreateDummyContext();
            if (format == null)
                format = DisplayFormat.RGB888;
            Create(format);
            
        }

        public WglContext(IntPtr Handle)
        {
            // TODO: Complete member initialization
            this.Handle = Handle;
        }
        private void CreateDummyContext()
        {
            lock(threadLocker)
            {
                if (InitializedFunctions)
                    return;
                IntPtr hInstance = Process.GetCurrentProcess().Handle;
                PixelFormat DefPixelFormat = PixelFormat.Default;
                int err = 0;
                //Define new WndClass
                WNDCLASS cls = new WNDCLASS();
                cls.style = ClassStyles.OwnDC;
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
                string szName = "SMGF Dummy";

                cls.hInstance = Wgl.GetModuleHandle(null);
                cls.hIcon = IntPtr.Zero;
                cls.hCursor = IntPtr.Zero;
                cls.hbrBackground = IntPtr.Zero;
                cls.lpszMenuName = null;
                cls.lpszClassName = szName;

                ushort windowClass = Wgl.RegisterClass(ref cls);
                if (windowClass == 0)
                {
                    err = Marshal.GetLastWin32Error();
                    throw new Exception(String.Format("Could not create register window class :{0}", err));
                }

                //Create dummy window
                IntPtr dummyWin = Wgl.CreateWindowEx(0, szName, "a",
                    WindowStyles.WS_OVERLAPPEDWINDOW, 0, 0, 240, 240, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

                if (dummyWin == IntPtr.Zero)
                {
                    err = Marshal.GetLastWin32Error();
                    throw new Exception(String.Format("Could not create dummy window :{0}", err));
                }
                IntPtr dummyDC = Wgl.GetDC(dummyWin);
                int tmpPixForm = Wgl.ChoosePixelFormat(dummyDC, ref DefPixelFormat);
                if (tmpPixForm == 0)
                {
                    err = Marshal.GetLastWin32Error();
                    throw new Exception(String.Format("Could not obtain pixel formats :{0}", err));
                }

                if (!Wgl.SetPixelFormat(dummyDC, tmpPixForm, ref DefPixelFormat))
                {
                    err = Marshal.GetLastWin32Error();
                    throw new Exception(String.Format("Could not set pixel format on dummy window :{0}", err));
                }
                ContextHandle = Wgl.CreateContext(dummyDC);
                if (ContextHandle == UIntPtr.Zero)
                {
                    err = Marshal.GetLastWin32Error();
                    throw new Exception(String.Format("Could not create dummy context :{0}", err));
                }
                Wgl.MakeCurrent(dummyDC, ContextHandle);

                Wgl.LoadFuncs();
                
                string ver = Wgl.GlGetString(StringName.VERSION);
                VersionMax = int.Parse(ver.Split('.')[0]) * 10 + int.Parse(ver.Split('.')[1]);

                WglExtensions.Clear();
                WglExtensions.AddRange(Wgl.GetExtensionsString(dummyDC).Split(' '));

                ES2Support = WglExtensions.Contains("WGL_EXT_create_context_es2_profile");
                if (!WglExtensions.Contains("WGL_ARB_create_context_profile"))
                {
                    throw new Exception(String.Format("Sorry, your gpu does not support ARB_create_context_profile"));
                }
                if (!WglExtensions.Contains("WGL_ARB_pixel_format"))
                {
                    throw new Exception(String.Format("Sorry, your gpu does not support ARB_create_context_profile"));
                }
                
                InitializedFunctions = true;

                //Sometimes fails , dont know why .... sigh
                for (int i = 0;i<10;i++)
                {
                    if (Wgl.MakeCurrent(dummyDC, UIntPtr.Zero)) break;
                }

                bool res = Wgl.DeleteContext(ContextHandle);
                ContextHandle = UIntPtr.Zero;
                Wgl.ReleaseDC(dummyWin, dummyDC);
                Wgl.DestroyWindow(dummyWin);
            }
        }
        internal void Create(DisplayFormat requestFormat)
        {
            PixelFormat tmp = PixelFormat.Default;

            var fAttribs = new float[] { 0, 0 };

            var iAttributes = new int[]
                                 {
                                     Wgl.DRAW_TO_WINDOW_ARB, 1,
                                     Wgl.SUPPORT_OPENGL_ARB, 1,
                                     Wgl.DOUBLE_BUFFER_ARB,1,
                                     Wgl.ACCELERATION_ARB, Wgl.FULL_ACCELERATION_ARB,

                                     Wgl.PIXEL_TYPE_ARB,Wgl.TYPE_RGBA_ARB,
                                     Wgl.COLOR_BITS_ARB,requestFormat.Red+requestFormat.Green+requestFormat.Blue,

                                     Wgl.RED_BITS_ARB,requestFormat.Red,
                                     Wgl.GREEN_BITS_ARB,requestFormat.Green,
                                     Wgl.BLUE_BITS_ARB,requestFormat.Blue,

                                     Wgl.ALPHA_BITS_ARB,requestFormat.Alpha,
                                     Wgl.DEPTH_BITS_ARB, requestFormat.Depth,
                                     Wgl.STENCIL_BITS_ARB, requestFormat.Stencil,

                                     //We dont use Accum buffers since GL ES  does not support them,
                                     //If we can obtain buffer without accumulator, we save some memory
                                     Wgl.ACCUM_BITS_ARB,0,

                                     Wgl.SAMPLES_ARB,requestFormat.Samples,
                                     Wgl.SAMPLE_BUFFERS_ARB,requestFormat.SampleBuffers,
                                     0,0        //End
                                 };
            uint nFormats = 0;
            int pFormat = 0;
            if (!Wgl.ChoosePixelFormatARB(WindowDC, iAttributes, fAttribs, 1, ref pFormat, ref nFormats))
            {
                throw new Exception("Could not get pixel format");
            }
            int[] att = new int[]
            {
                Wgl.SUPPORT_OPENGL_ARB,
                Wgl.ACCELERATION_ARB,
                Wgl.DOUBLE_BUFFER_ARB,
                Wgl.PIXEL_TYPE_ARB,
                Wgl.COLOR_BITS_ARB,
                Wgl.RED_BITS_ARB,
                Wgl.GREEN_BITS_ARB,
                Wgl.BLUE_BITS_ARB,
                Wgl.ALPHA_BITS_ARB,
                Wgl.DEPTH_BITS_ARB,
                Wgl.STENCIL_BITS_ARB,
                Wgl.SAMPLES_ARB,
                Wgl.SAMPLE_BUFFERS_ARB,
            };
            int[] res = new int[att.Length];
            Wgl.GetPixelFormatAttribiv(WindowDC, pFormat, 0, (uint)res.Length, att, res);

            if (res[0] == 0 || res[1] == 0)
                throw new Exception("Could create HW accelerated pixel format");
            DoubleBuffer = res[1] != 0;
            Format = new DisplayFormat(res[5], res[6], res[7], res[8], res[9], res[10], res[11]);
            Logger.Debug("Requested Display Format: " + requestFormat.ToString());
            Logger.Debug("Returned Display Format: " + Format.ToString());
            if (!Wgl.SetPixelFormat(WindowDC, pFormat, ref tmp))
            {
                throw new Exception("Could not apply pixel format");
            }
            
            int Version = 20;
            if(!ES2Support)
            {
                //We need 3.0 -framebuffers , glsl migh be a problem
                Version = 40;
            }
          
            int majorVer = Version/10;
            int minorVer = Version%10;
            
            int contextMask = ES2Support ? Wgl.CONTEXT_ES2_PROFILE_BIT_EXT : Wgl.CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB;

            int[] attribs = new int[]
                     {
                        Wgl.CONTEXT_MAJOR_VERSION_ARB, majorVer,
                        Wgl.CONTEXT_MINOR_VERSION_ARB, minorVer,
                        Wgl.CONTEXT_FLAGS_ARB,0,
                        Wgl. CONTEXT_PROFILE_MASK_ARB,  contextMask,
                        0 };
            ContextHandle = Wgl.CreateContextAttribs(WindowDC, IntPtr.Zero, attribs);
            if (ContextHandle == UIntPtr.Zero)
            {
                throw new NotSupportedException("Could not create Context");
            }
            
            MakeCurrent();
            GL.Load(loadFunc);
            //We get extensions from our context ( ES2)
            Extensions.AddRange(Wgl.GlGetString(StringName.EXTENSIONS).Split(' '));
        }
        private IntPtr loadFunc(string name)
        {
            return Wgl.GlGetProcAddress(name);
        }
        public override void MakeCurrent()
        {
            Current = this;
            Wgl.MakeCurrent(WindowDC, ContextHandle);
        }

        public override void Dispose()
        {
            Wgl.MakeCurrent((IntPtr)0, (UIntPtr)0);
            Wgl.DeleteContext(ContextHandle);
        }

        public override void SwapBuffers()
        {
            Wgl.SwapBuffers(WindowDC);
        }

        public override bool IsExtensionAvailable(string ext)
        {
            return Extensions.Contains(ext) || WglExtensions.Contains(ext);
        }
    }
}
