using System;
using System.Runtime.InteropServices;
using System.Security;
using OKeys = XFG.Keys;
using OMods = XFG.Modifiers;
using OMouse = XFG.MouseButton;

namespace XFG.Glfw
{
	[StructLayout(LayoutKind.Sequential)]
	struct GlfwVidmode
	{
		int width;
		int height;
		int redBits;
		int greenBits;
		int blueBits;
		int refreshRate;
	}

	[StructLayout(LayoutKind.Sequential)]
	struct GlfwGammaRamp
	{
		short[] red;
		short[] green;
		short[] blue;
		uint size;
	}


	[StructLayout(LayoutKind.Sequential)]
	struct GlfwImage
	{
		int width;
		int height;
		byte[] pixels;
	}

	internal enum KeyAction :int
	{
		Release=0,
		Press=1,
		Repeat=2
	}


    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void ErrorFun(int error,string desc);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowPosFun(IntPtr window, int x, int y);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowSizeFun(IntPtr window, int w, int h);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowCloseFun(IntPtr window);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowRefreshFun(IntPtr window);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowFocusFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool focused);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void WindowIconifyFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool icon);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void FramebufferSizeFun(IntPtr window, int width, int height);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void MouseButtonFun(IntPtr window, Glfw.MouseButton button, KeyAction action, Glfw.Mods mods);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void CursorPosFun(IntPtr window, double x , double y);


	internal delegate void CursorenterFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool entered);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void ScrollFun(IntPtr window, double xoff, double yoff);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void KeyFun(IntPtr window, Glfw.Keys key, int scan, KeyAction action, Glfw.Mods mods);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void CharFun(IntPtr window, uint codepoint);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void CharModsFun(IntPtr window, uint codepoint , int mods);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void DropFun(IntPtr window, int count, string[] paths);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
    internal delegate void MonitorFun(IntPtr monitor, int connect_event);

	internal static class Glfw
	{

		internal enum MouseButton{
			GLFW_MOUSE_BUTTON_1=  0,
			GLFW_MOUSE_BUTTON_2 =  1,
			GLFW_MOUSE_BUTTON_3  = 2,
			GLFW_MOUSE_BUTTON_4  = 3,
			GLFW_MOUSE_BUTTON_5   =4,
			GLFW_MOUSE_BUTTON_6=   5,
			GLFW_MOUSE_BUTTON_7 =  6,
			GLFW_MOUSE_BUTTON_8  = 7,
			GLFW_MOUSE_BUTTON_LAST=   GLFW_MOUSE_BUTTON_8,
			GLFW_MOUSE_BUTTON_LEFT =  GLFW_MOUSE_BUTTON_1,
			GLFW_MOUSE_BUTTON_RIGHT =  GLFW_MOUSE_BUTTON_2,
			GLFW_MOUSE_BUTTON_MIDDLE =  GLFW_MOUSE_BUTTON_3,
		}

		[Flags]
		internal enum Mods : int
		{
			Shift = 0x0001,
			Control = 0x0002,
			Alt = 0x0004,
			Super = 0x0008
		}

		internal enum Keys {

			GLFW_KEY_UNKNOWN = 1,
			GLFW_KEY_SPACE = 32,
			GLFW_KEY_APOSTROPHE = 39,
			GLFW_KEY_COMMA = 44,
			GLFW_KEY_MINUS = 45,
			GLFW_KEY_PERIOD = 46,
			GLFW_KEY_SLASH = 47,
			GLFW_KEY_0 = 48,
			GLFW_KEY_1 = 49,
			GLFW_KEY_2 = 50,
			GLFW_KEY_3 = 51,
			GLFW_KEY_4 = 52,
			GLFW_KEY_5 = 53,
			GLFW_KEY_6 = 54,
			GLFW_KEY_7 = 55,
			GLFW_KEY_8 = 56,
			GLFW_KEY_9 = 57,
			GLFW_KEY_SEMICOLON = 59,
			GLFW_KEY_EQUAL = 61,
			GLFW_KEY_A = 65,
			GLFW_KEY_B = 66,
			GLFW_KEY_C = 67,
			GLFW_KEY_D = 68,
			GLFW_KEY_E = 69,
			GLFW_KEY_F = 70,
			GLFW_KEY_G = 71,
			GLFW_KEY_H = 72,
			GLFW_KEY_I = 73,
			GLFW_KEY_J = 74,
			GLFW_KEY_K = 75,
			GLFW_KEY_L = 76,
			GLFW_KEY_M = 77,
			GLFW_KEY_N = 78,
			GLFW_KEY_O = 79,
			GLFW_KEY_P = 80,
			GLFW_KEY_Q = 81,
			GLFW_KEY_R = 82,
			GLFW_KEY_S = 83,
			GLFW_KEY_T = 84,
			GLFW_KEY_U = 85,
			GLFW_KEY_V = 86,
			GLFW_KEY_W = 87,
			GLFW_KEY_X = 88,
			GLFW_KEY_Y = 89,
			GLFW_KEY_Z = 90,
			GLFW_KEY_LEFT_BRACKET = 91,
			GLFW_KEY_BACKSLASH = 92,
			GLFW_KEY_RIGHT_BRACKET = 93,
			GLFW_KEY_GRAVE_ACCENT = 96,
			GLFW_KEY_WORLD_1 = 161,
			GLFW_KEY_WORLD_2 = 162,
			GLFW_KEY_ESCAPE = 256,
			GLFW_KEY_ENTER = 257,
			GLFW_KEY_TAB = 258,
			GLFW_KEY_BACKSPACE = 259,
			GLFW_KEY_INSERT = 260,
			GLFW_KEY_DELETE = 261,
			GLFW_KEY_RIGHT = 262,
			GLFW_KEY_LEFT = 263,
			GLFW_KEY_DOWN = 264,
			GLFW_KEY_UP = 265,
			GLFW_KEY_PAGE_UP = 266,
			GLFW_KEY_PAGE_DOWN = 267,
			GLFW_KEY_HOME = 268,
			GLFW_KEY_END = 269,
			GLFW_KEY_CAPS_LOCK = 280,
			GLFW_KEY_SCROLL_LOCK = 281,
			GLFW_KEY_NUM_LOCK = 282,
			GLFW_KEY_PRINT_SCREEN = 283,
			GLFW_KEY_PAUSE = 284,
			GLFW_KEY_F1 = 290,
			GLFW_KEY_F2 = 291,
			GLFW_KEY_F3 = 292,
			GLFW_KEY_F4 = 293,
			GLFW_KEY_F5 = 294,
			GLFW_KEY_F6 = 295,
			GLFW_KEY_F7 = 296,
			GLFW_KEY_F8 = 297,
			GLFW_KEY_F9 = 298,
			GLFW_KEY_F10 = 299,
			GLFW_KEY_F11 = 300,
			GLFW_KEY_F12 = 301,
			GLFW_KEY_F13 = 302,
			GLFW_KEY_F14 = 303,
			GLFW_KEY_F15 = 304,
			GLFW_KEY_F16 = 305,
			GLFW_KEY_F17 = 306,
			GLFW_KEY_F18 = 307,
			GLFW_KEY_F19 = 308,
			GLFW_KEY_F20 = 309,
			GLFW_KEY_F21 = 310,
			GLFW_KEY_F22 = 311,
			GLFW_KEY_F23 = 312,
			GLFW_KEY_F24 = 313,
			GLFW_KEY_KP_2 = 322,
			GLFW_KEY_F25 = 314,
			GLFW_KEY_KP_0 = 320,
			GLFW_KEY_KP_1 = 321,
			GLFW_KEY_KP_3 = 323,
			GLFW_KEY_KP_4 = 324,
			GLFW_KEY_KP_5 = 325,
			GLFW_KEY_KP_6 = 326,
			GLFW_KEY_KP_7 = 327,
			GLFW_KEY_KP_8 = 328,
			GLFW_KEY_KP_9 = 329,
			GLFW_KEY_KP_DECIMAL = 330,
			GLFW_KEY_KP_DIVIDE = 331,
			GLFW_KEY_KP_MULTIPLY = 332,
			GLFW_KEY_KP_SUBTRACT = 333,
			GLFW_KEY_KP_ADD = 334,
			GLFW_KEY_KP_ENTER = 335,
			GLFW_KEY_KP_EQUAL = 336,
			GLFW_KEY_LEFT_SHIFT = 340,
			GLFW_KEY_LEFT_CONTROL = 341,
			GLFW_KEY_LEFT_ALT = 342,
			GLFW_KEY_LEFT_SUPER = 343,
			GLFW_KEY_RIGHT_SHIFT = 344,
			GLFW_KEY_RIGHT_CONTROL = 345,
			GLFW_KEY_RIGHT_ALT = 346,
			GLFW_KEY_RIGHT_SUPER = 347,
			GLFW_KEY_MENU = 348,
			GLFW_KEY_LAST = GLFW_KEY_MENU
		}
		private const string lib = "glfw";

		[DllImport(lib,EntryPoint="glfwInit", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Init();

		[DllImport(lib,EntryPoint="glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Terminate();


		[DllImport(lib,EntryPoint="glfwGetVersion", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetVersion(out int major, out int minor, out int rev);

		[DllImport(lib,EntryPoint="glfwGetVersionString", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr _GetVersionString();

		public static string GetVersionString(){
			return Marshal.PtrToStringAnsi (_GetVersionString ());
		}

		[DllImport(lib,EntryPoint="glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern ErrorFun SetErrorCallback(ErrorFun cbfun);

		[DllImport(lib,EntryPoint="glfwGetMonitors", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr[] GetMonitors(out int count);

		[DllImport(lib,EntryPoint="glfwGetPrimaryMonitor", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetPrimaryMonitor();

		[DllImport(lib,EntryPoint="glfwGetMonitorPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos);

		[DllImport(lib,EntryPoint="glfwGetMonitorPhysicalSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetMonitorPhysicalSize(IntPtr monitor , out int w, out int h);

		[DllImport(lib,EntryPoint="glfwGetMonitorName", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetMonitorName(IntPtr monitr);

		[DllImport(lib,EntryPoint="glfwSetMonitorCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern MonitorFun SetMonitorCallback(MonitorFun cbfun);

		[DllImport(lib,EntryPoint="glfwGetVideoModes", CallingConvention = CallingConvention.Cdecl)]
		public static extern GlfwVidmode[] GetVideoModes(IntPtr monitor, out int count);

		[DllImport(lib,EntryPoint="glfwGetVideoMode", CallingConvention = CallingConvention.Cdecl)]
		public static extern GlfwVidmode GetVideoMode (IntPtr monitor);

		[DllImport(lib,EntryPoint="glfwSetGamma", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetGamma(IntPtr monitor, float gamma);

		[DllImport(lib,EntryPoint="glfwGetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
		public static extern GlfwGammaRamp GetGammaRamp(IntPtr monitor);

		[DllImport(lib,EntryPoint="glfwSetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetGammaRamp(IntPtr monitor, ref GlfwGammaRamp ramp);



		[DllImport(lib,EntryPoint="glfwCreateWindow",CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CreateWindow(int width, int height, string title,
			IntPtr monitor, IntPtr share);

		[DllImport(lib,EntryPoint="glfwDefaultWindowHints", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DefaultWindowHints();

		[DllImport(lib,EntryPoint="glfwDestroyWindow", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DestroyWindow(IntPtr window);

		[DllImport(lib,EntryPoint="glfwGetFramebufferSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetFrameBufferSize( IntPtr window, out int width, out int height);

		[DllImport(lib,EntryPoint="glfwGetWindowAttrib", CallingConvention = CallingConvention.Cdecl)]
		public static extern int GetWindowAttrib(IntPtr window, int attrib);

		[DllImport(lib,EntryPoint="glfwGetWindowFrameSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right , out int bottoms);

		[DllImport(lib,EntryPoint="glfwGetWindowMonitor", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetWindowMonitor(IntPtr window);

		[DllImport(lib,EntryPoint="glfwGetWindowPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetWindowPos(IntPtr window, out int xpos, out int ypos);

		[DllImport(lib,EntryPoint="glfwGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetWindowSize(IntPtr window, out int width, out int height);

		[DllImport(lib,EntryPoint="glfwGetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetWindowUserPointer(IntPtr window);

		[DllImport(lib,EntryPoint="glfwHideWindow", CallingConvention = CallingConvention.Cdecl)]
		public static extern void HideWindow();

		[DllImport(lib,EntryPoint="glfwIconifyWindow", CallingConvention = CallingConvention.Cdecl)]
		public static extern void IconifyWindow(IntPtr window);

		[DllImport(lib,EntryPoint="glfwPollEvents", CallingConvention = CallingConvention.Cdecl)]
		public static extern void PollEvents();

		[DllImport(lib,EntryPoint="glfwPostEmptyEvent", CallingConvention = CallingConvention.Cdecl)]
		public static extern void PostEmptyEvent();

		[DllImport(lib,EntryPoint="glfwRestoreWindow", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RestoreWindow(IntPtr window);



		[DllImport(lib,EntryPoint="glfwSetFramebufferSizeCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern FramebufferSizeFun SetFramebufferSizeCallback(IntPtr window,FramebufferSizeFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowCloseCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowCloseFun SetWindowCloseCallback(IntPtr window, WindowCloseFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowFocusCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowFocusFun SetWindowFocusCallback(IntPtr window, WindowFocusFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowIconifyCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowIconifyFun SetWindowIconifyCallback(IntPtr window, WindowIconifyFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetWindowPosCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowPosFun SetWindowPosCallback(IntPtr window, WindowPosFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowRefreshCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowRefreshFun SetWindowRefreshCallback(IntPtr window, WindowRefreshFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowSizeCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern WindowSizeFun SetWindowSizeCallback(IntPtr window, WindowSizeFun cbfun);



		[DllImport(lib,EntryPoint="glfwSetWindowPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWindowPos(IntPtr window, int width, int height);

		[DllImport(lib,EntryPoint="glfwSetWindowSouldClose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWindowShouldClose(IntPtr window, int value);

		[DllImport(lib,EntryPoint="glfwSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWindowSize(IntPtr window, int width, int height);

		[DllImport(lib,EntryPoint="glfwSetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWindowTitle(IntPtr window, string title);

		[DllImport(lib,EntryPoint="glfwSetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

		[DllImport(lib,EntryPoint="glfwShowWindow", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ShowWindow(IntPtr window);

		[DllImport(lib,EntryPoint="glfwWaitEvents", CallingConvention = CallingConvention.Cdecl)]
		public static extern void WaitEvents();

		[DllImport(lib,EntryPoint="glfwWindowHint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ShowWindow(int target, int hint);

		[DllImport(lib,EntryPoint="glfwWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
		public static extern int WindowShouldClose(IntPtr window);

		[DllImport(lib,EntryPoint="glfwGetInputMode", CallingConvention = CallingConvention.Cdecl)]
		public static extern int GetInputMode(IntPtr window, int mode);

		[DllImport(lib,EntryPoint="glfwSetInputMode", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetInputMode(IntPtr window, int mode,int value);

		[DllImport(lib,EntryPoint="glfwGetKey", CallingConvention = CallingConvention.Cdecl)]
		public static extern KeyAction GetKey(IntPtr window, Keys key);

		[DllImport(lib,EntryPoint="glfwGetMouseButton", CallingConvention = CallingConvention.Cdecl)]
		public static extern KeyAction GetMouseButton(IntPtr window, MouseButton buton);

		[DllImport(lib,EntryPoint="glfwGetCursorPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetCursorPos(IntPtr window, out int x, out int y);

		[DllImport(lib,EntryPoint="glfwSetCursorPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetCursorPos(IntPtr window, int x, int y);

		[DllImport(lib,EntryPoint="glfwCreateCursor", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CreateCursor(GlfwImage image, int xhot, int yhot);

		[DllImport(lib,EntryPoint="glfwCreateStandardCursor", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CreateStandardCursor(int shape);

		[DllImport(lib,EntryPoint="glfwDestroyCursor", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DestroyCursor(IntPtr cursor);

		[DllImport(lib,EntryPoint="glfwSetCursor", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetCursor(IntPtr window, IntPtr cursor);


		[DllImport(lib,EntryPoint="glfwSetKeyCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern KeyFun SetKeyCallback(IntPtr window, KeyFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetCharCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern CharFun SetCharCallback(IntPtr window, CharFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetCharModsCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern CharModsFun SetCharModsCallback(IntPtr window, CharModsFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetMouseButtonCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern MouseButtonFun SetMouseButtonCallback(IntPtr window, MouseButtonFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetCursorPosCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern CursorPosFun SetCursorPosCallback(IntPtr window, CursorPosFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetCursorEnterCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern CursorenterFun SetCursorEnterCallback(IntPtr window, CursorenterFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetScrollCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern ScrollFun SetScrollCallback(IntPtr window, ScrollFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetDropCallback", CallingConvention = CallingConvention.Cdecl)]
		public static extern DropFun SetDropCallback(IntPtr window, DropFun cbfun);

		#region Joystick
		 // Todo, add support for joysticks
		#endregion


		[DllImport(lib,EntryPoint="glfwSetClipboardString", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetClipboardString(IntPtr window, string value);


		[DllImport(lib,EntryPoint="glfwGetClipboardString", CallingConvention = CallingConvention.Cdecl)]
		public static extern string GetClipboardString(IntPtr window);


		[DllImport(lib,EntryPoint="glfwGetTime", CallingConvention = CallingConvention.Cdecl)]
		public static extern double GetTime();


		[DllImport(lib,EntryPoint="glfwSetTime", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetTime(double time);

		[DllImport(lib,EntryPoint="glfwMakeContextCurrent", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MakeContextCurrent(IntPtr window);


		[DllImport(lib,EntryPoint="glfwGetCurrentContext", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetCurrentCotext();


		[DllImport(lib,EntryPoint="glfwSwapBuffers", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SwapBuffers(IntPtr window);


		[DllImport(lib,EntryPoint="glfwSwapInterval", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SwapInterval(int interval);


		[DllImport(lib,EntryPoint="glfwExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ExtensionSupported(string name);


		[DllImport(lib,EntryPoint="glfwGetProcAddress", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetProcAddress(string procname);



		internal static OKeys MapKey(Keys key)
		{
			switch (key) {
			case Keys.GLFW_KEY_SPACE:
				return OKeys.SPACE;
			case Keys.GLFW_KEY_APOSTROPHE:
				return OKeys.APOSTROPHE;
			case Keys.GLFW_KEY_COMMA:
				return OKeys.COMMA;
			case Keys.GLFW_KEY_MINUS:
				return OKeys.MINUS;
			case Keys.GLFW_KEY_PERIOD:
				return OKeys.PERIOD;
			case Keys.GLFW_KEY_SLASH:
				return OKeys.SLASH;
			case Keys.GLFW_KEY_SEMICOLON:
				return OKeys.SEMICOLON;
			case Keys.GLFW_KEY_EQUAL:
				return OKeys.EQUALS;
			case Keys.GLFW_KEY_LEFT_BRACKET:
				return OKeys.LEFT_BRACKET;
			case Keys.GLFW_KEY_BACKSLASH:
				return OKeys.BACKSLASH;
			case Keys.GLFW_KEY_RIGHT_BRACKET:
				return OKeys.RIGHT_BRACKET;
			case Keys.GLFW_KEY_GRAVE_ACCENT:
				return OKeys.GRAVE;
			case Keys.GLFW_KEY_WORLD_1:
			case Keys.GLFW_KEY_WORLD_2:
				return OKeys.UNKNOWN;
			case Keys.GLFW_KEY_ESCAPE:
				return OKeys.ESCAPE;
			case Keys.GLFW_KEY_ENTER:
				return OKeys.ENTER;
			case Keys.GLFW_KEY_TAB:
				return OKeys.TAB;
			case Keys.GLFW_KEY_BACKSPACE:
				return OKeys.BACKSPACE;
			case Keys.GLFW_KEY_INSERT:
				return OKeys.INSERT_TEXT;
			case Keys.GLFW_KEY_DELETE:
				return OKeys.DELETE;
			case Keys.GLFW_KEY_RIGHT:
				return OKeys.RIGHT;

			case Keys.GLFW_KEY_LEFT:
				return OKeys.LEFT;

			case Keys.GLFW_KEY_DOWN:
				return OKeys.DOWN;
			case Keys.GLFW_KEY_UP:
				return OKeys.UP;
			case Keys.GLFW_KEY_PAGE_UP:
				return OKeys.PAGE_UP;
			case Keys.GLFW_KEY_PAGE_DOWN:
				return OKeys.PAGE_DOWN;
			case Keys.GLFW_KEY_HOME:
				return OKeys.HOME;
			case Keys.GLFW_KEY_END:
				return OKeys.END_TEXT;
			case Keys.GLFW_KEY_CAPS_LOCK:
				return OKeys.CAPS_LOCK;
			case Keys.GLFW_KEY_SCROLL_LOCK:
				return OKeys.SCROLL_LOCK;
			case Keys.GLFW_KEY_NUM_LOCK:
				return OKeys.NUM_LOCK;

			case Keys.GLFW_KEY_PRINT_SCREEN:
				return OKeys.PRINT_SCREEN;
			case Keys.GLFW_KEY_PAUSE:
				return OKeys.PAUSE;
			case Keys.GLFW_KEY_KP_DECIMAL:
				return OKeys.NUMPAD_DOT;
			case Keys.GLFW_KEY_KP_DIVIDE:
				return OKeys.NUMPAD_DIV;
			case Keys.GLFW_KEY_KP_MULTIPLY:
				return OKeys.NUMPAD_MUL;
			case Keys.GLFW_KEY_KP_SUBTRACT:
				return OKeys.NUMPAD_SUB;
			case Keys.GLFW_KEY_KP_ADD:
				return OKeys.NUMPAD_ADD;
			case Keys.GLFW_KEY_KP_ENTER:
				return OKeys.NUMPAD_ENTER;
			case Keys.GLFW_KEY_LEFT_SHIFT:
				return OKeys.SHIFT_LEFT;

			case Keys.GLFW_KEY_LEFT_CONTROL:
				return OKeys.CTRL_LEFT;
			case Keys.GLFW_KEY_LEFT_ALT:
				return OKeys.ALT_LEFT;
			case Keys.GLFW_KEY_LEFT_SUPER:
				return OKeys.META_LEFT;
			case Keys.GLFW_KEY_RIGHT_SHIFT:
				return OKeys.SHIFT_RIGHT;
			case Keys.GLFW_KEY_RIGHT_CONTROL:
				return OKeys.CTRL_RIGHT;

			case Keys.GLFW_KEY_RIGHT_ALT:
				return OKeys.ALT_RIGHT;
			case Keys.GLFW_KEY_RIGHT_SUPER:
				return OKeys.META_RIGHT;
			case Keys.GLFW_KEY_MENU:
				return OKeys.MENU;
			
			}

			if(key >= Keys.GLFW_KEY_0 && key <= Keys.GLFW_KEY_9){
				return (OKeys)key - 41;
			}

			if(key >= Keys.GLFW_KEY_A && key <= Keys.GLFW_KEY_Z){
				return (OKeys)key - 36;
			}


			if(key >= Keys.GLFW_KEY_F1 && key <= Keys.GLFW_KEY_F12){
				return (OKeys)key - 159;
			}

			if(key >= Keys.GLFW_KEY_KP_0 && key <= Keys.GLFW_KEY_KP_9){
				return (OKeys)key - 176;
			}
			return OKeys.UNKNOWN;
		}

		internal static OMods MapMods(Mods mods)
		{
			OMods res = OMods.None;
			if (mods.HasFlag (Mods.Alt)) {
				res |= OMods.Alt;
			}
			if (mods.HasFlag (Mods.Control)) {
				res |= OMods.Control;
			}
			if (mods.HasFlag (Mods.Shift)) {
				res |= OMods.Shift;
			}
			if (mods.HasFlag(Mods.Super)) {
				res |= OMods.Meta;
			}
			return res;
		}
		internal static OMouse MapMouseButton(MouseButton button){
			return (OMouse) (button + 1);
		}


	}
}

