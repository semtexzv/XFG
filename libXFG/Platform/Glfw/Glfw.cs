using System;
using System.Runtime.InteropServices;

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


	internal delegate void ErrorFun(int error,string desc);
	internal delegate void WindowPosFun(IntPtr window, int x, int y);
	internal delegate void WindowSizeFun(IntPtr window, int w, int h);
	internal delegate void WindowCloseFun(IntPtr window);
	internal delegate void WindowRefreshFun(IntPtr window);
	internal delegate void WindowFocusFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool focused); 
	internal delegate void WindowIconifyFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool icon);
	internal delegate void FramebufferSizeFun(IntPtr window, int width, int height);
	internal delegate void MouseButtonFun(IntPtr window, int button, int action, int mods);
	internal delegate void CursorPosFun(IntPtr window, double x , double y);
	internal delegate void CursorenterFun(IntPtr window, [MarshalAs(UnmanagedType.I4)] bool entered);
	internal delegate void ScrollFun(IntPtr window, double xoff, double yoff);
	internal delegate void KeyFun(IntPtr window, int key, int scan, int action, int mods);
	internal delegate void CharFun(IntPtr window, uint codepoint);
	internal delegate void CharModsFun(IntPtr window, uint codepoint , int mods);
	internal delegate void DropFun(IntPtr window, int count, string[] paths);
	internal delegate void MonitorFun(IntPtr monitor, int connect_event);

	internal static class Glfw
	{
		private const string lib = "glfw";

		[DllImport(lib,EntryPoint="glfwInit")]
		public static extern int Init();
		[DllImport(lib,EntryPoint="glfwTerminate")]
		public static extern void Terminate();


		[DllImport(lib,EntryPoint="glfwGetVersion")]
		public static extern void GetVersion(out int major, out int minor, out int rev);

		[DllImport(lib,EntryPoint="glfwGetVersionString")]
		public static extern IntPtr _GetVersionString();

		public static string GetVersionString(){
			return Marshal.PtrToStringAnsi (_GetVersionString ());
		}

		[DllImport(lib,EntryPoint="glfwSetErrorCallback")]
		public static extern ErrorFun SetErrorCallback(ErrorFun cbfun);

		[DllImport(lib,EntryPoint="glfwGetMonitors")]
		public static extern IntPtr[] GetMonitors(out int count);

		[DllImport(lib,EntryPoint="glfwGetPrimaryMonitor")]
		public static extern IntPtr GetPrimaryMonitor();

		[DllImport(lib,EntryPoint="glfwGetMonitorPos")]
		public static extern void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos);

		[DllImport(lib,EntryPoint="glfwGetMonitorPhysicalSize")]
		public static extern void GetMonitorPhysicalSize(IntPtr monitor , out int w, out int h);

		[DllImport(lib,EntryPoint="glfwGetMonitorName")]
		public static extern void GetMonitorName(IntPtr monitr);

		[DllImport(lib,EntryPoint="glfwSetMonitorCallback")]
		public static extern MonitorFun SetMonitorCallback(MonitorFun cbfun);

		[DllImport(lib,EntryPoint="glfwGetVideoModes")]
		public static extern GlfwVidmode[] GetVideoModes(IntPtr monitor, out int count);

		[DllImport(lib,EntryPoint="glfwGetVideoMode")]
		public static extern GlfwVidmode GetVideoMode (IntPtr monitor);

		[DllImport(lib,EntryPoint="glfwSetGamma")]
		public static extern void SetGamma(IntPtr monitor, float gamma);

		[DllImport(lib,EntryPoint="glfwGetGammaRamp")]
		public static extern GlfwGammaRamp GetGammaRamp(IntPtr monitor);

		[DllImport(lib,EntryPoint="glfwSetGammaRamp")]
		public static extern void SetGammaRamp(IntPtr monitor, ref GlfwGammaRamp ramp);



		[DllImport(lib,EntryPoint="glfwCreateWindow")]
		public static extern IntPtr CreateWindow(int width, int height, string title,
			IntPtr monitor, IntPtr share);

		[DllImport(lib,EntryPoint="glfwDefaultWindowHints")]
		public static extern void DefaultWindowHints();

		[DllImport(lib,EntryPoint="glfwDestroyWindow")]
		public static extern void DestroyWindow(IntPtr window);

		[DllImport(lib,EntryPoint="glfwGetFramebufferSize")]
		public static extern void GetFrameBufferSize( IntPtr window, out int width, out int height);

		[DllImport(lib,EntryPoint="glfwGetWindowAttrib")]
		public static extern int GetWindowAttrib(IntPtr window, int attrib);

		[DllImport(lib,EntryPoint="glfwGetWindowFrameSize")]
		public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right , out int bottoms);

		[DllImport(lib,EntryPoint="glfwGetWindowMonitor")]
		public static extern IntPtr GetWindowMonitor(IntPtr window);

		[DllImport(lib,EntryPoint="glfwGetWindowPos")]
		public static extern void GetWindowPos(IntPtr window, out int xpos, out int ypos);

		[DllImport(lib,EntryPoint="glfwGetWindowSize")]
		public static extern void GetWindowSize(IntPtr window, out int width, out int height);

		[DllImport(lib,EntryPoint="glfwGetWindowUserPointer")]
		public static extern IntPtr GetWindowUserPointer(IntPtr window);

		[DllImport(lib,EntryPoint="glfwHideWindow")]
		public static extern void HideWindow();

		[DllImport(lib,EntryPoint="glfwIconifyWindow")]
		public static extern void IconifyWindow(IntPtr window);

		[DllImport(lib,EntryPoint="glfwPollEvents")]
		public static extern void PollEvents();

		[DllImport(lib,EntryPoint="glfwPostEmptyEvent")]
		public static extern void PostEmptyEvent();

		[DllImport(lib,EntryPoint="glfwRestoreWindow")]
		public static extern void RestoreWindow(IntPtr window);



		[DllImport(lib,EntryPoint="glfwSetFramebufferSizeCallback")]
		public static extern FramebufferSizeFun SetFramebufferSizeCallback(IntPtr window,FramebufferSizeFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowCloseCallback")]
		public static extern WindowCloseFun SetWindowCloseCallback(IntPtr window, WindowCloseFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowFocusCallback")]
		public static extern WindowFocusFun SetWindowFocusCallback(IntPtr window, WindowFocusFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowIconifyCallback")]
		public static extern WindowIconifyFun SetWindowIconifyCallback(IntPtr window, WindowIconifyFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetWindowPosCallback")]
		public static extern WindowPosFun SetWindowPosCallback(IntPtr window, WindowPosFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowRefreshCallback")]
		public static extern WindowRefreshFun SetWindowRefreshCallback(IntPtr window, WindowRefreshFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowSizeCallback")]
		public static extern WindowSizeFun SetWindowSizeCallback(IntPtr window, WindowSizeFun cbfun);



		[DllImport(lib,EntryPoint="glfwSetWindowPos")]
		public static extern void SetWindowPos(IntPtr window, int width, int height);

		[DllImport(lib,EntryPoint="glfwSetWindowSouldClose")]
		public static extern void SetWindowShouldClose(IntPtr window, int value);

		[DllImport(lib,EntryPoint="glfwSetWindowSize")]
		public static extern void SetWindowSize(IntPtr window, int width, int height);

		[DllImport(lib,EntryPoint="glfwSetWindowTitle")]
		public static extern void SetWindowTitle(IntPtr window, string title);

		[DllImport(lib,EntryPoint="glfwSetWindowUserPointer")]
		public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

		[DllImport(lib,EntryPoint="glfwShowWindow")]
		public static extern void ShowWindow(IntPtr window);


		[DllImport(lib,EntryPoint="glfwWaitEvents")]
		public static extern void WaitEvents();

		[DllImport(lib,EntryPoint="glfwWindowHint")]
		public static extern void ShowWindow(int target, int hint);

		[DllImport(lib,EntryPoint="glfwWindowShouldClose")]
		public static extern int WindowShouldClose(IntPtr window);



		[DllImport(lib,EntryPoint="glfwGetInputMode")]
		public static extern int GetInputMode(IntPtr window, int mode);

		[DllImport(lib,EntryPoint="glfwSetInputMode")]
		public static extern void SetInputMode(IntPtr window, int mode,int value);

		[DllImport(lib,EntryPoint="glfwGetKey")]
		public static extern int GetKey(IntPtr window, int key);

		[DllImport(lib,EntryPoint="glfwGetMouseButton")]
		public static extern int GetMouseButton(IntPtr window, int buton);


		[DllImport(lib,EntryPoint="glfwGetCursorPos")]
		public static extern void GetCursorPos(IntPtr window, out int x, out int y);

		[DllImport(lib,EntryPoint="glfwSetCursorPos")]
		public static extern void SetCursorPos(IntPtr window, int x, int y);

		[DllImport(lib,EntryPoint="glfwCreateCursor")]
		public static extern IntPtr CreateCursor(GlfwImage image, int xhot, int yhot);

		[DllImport(lib,EntryPoint="glfwCreateStandardCursor")]
		public static extern IntPtr CreateStandardCursor(int shape);


		[DllImport(lib,EntryPoint="glfwDestroyCursor")]
		public static extern void DestroyCursor(IntPtr cursor);


		[DllImport(lib,EntryPoint="glfwSetCursor")]
		public static extern int GetKey(IntPtr window, IntPtr cursor);


		[DllImport(lib,EntryPoint="glfwSetKeyCallback")]
		public static extern KeyFun SetKeyCallback(IntPtr window, KeyFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetCharCallback")]
		public static extern CharFun SetCharCallback(IntPtr window, CharFun cbfun);

		[DllImport(lib,EntryPoint="glfwSetCharModsCallback")]
		public static extern CharModsFun SetCharModsCallback(IntPtr window, CharModsFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetMouseButtonCallback")]
		public static extern MouseButtonFun SetMouseButtonCallback(IntPtr window, MouseButtonFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetCursorPosCallback")]
		public static extern CursorPosFun SetCursorPosCallback(IntPtr window, CursorPosFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetCursorEnterCallback")]
		public static extern CursorenterFun SetCursorEnterCallback(IntPtr window, CursorenterFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetScrollCallback")]
		public static extern ScrollFun SetScrollCallback(IntPtr window, ScrollFun cbfun);


		[DllImport(lib,EntryPoint="glfwSetDropCallback")]
		public static extern DropFun SetDropCallback(IntPtr window, DropFun cbfun);

		#region Joystick
		 // Todo, add support for joysticks
		#endregion


		[DllImport(lib,EntryPoint="glfwSetClipboardString")]
		public static extern void SetClipboardString(IntPtr window, string value);


		[DllImport(lib,EntryPoint="glfwGetClipboardString")]
		public static extern string GetClipboardString(IntPtr window);


		[DllImport(lib,EntryPoint="glfwGetTime")]
		public static extern double GetTime();


		[DllImport(lib,EntryPoint="glfwSetTime")]
		public static extern void SetTime(double time);

		[DllImport(lib,EntryPoint="glfwMakeContextCurrent")]
		public static extern void MakeContextCurrent(IntPtr window);


		[DllImport(lib,EntryPoint="glfwGetCurrentContext")]
		public static extern IntPtr GetCurrentCotext();


		[DllImport(lib,EntryPoint="glfwSwapBuffers")]
		public static extern void SwapBuffers(IntPtr window);


		[DllImport(lib,EntryPoint="glfwSwapInterval")]
		public static extern void SwapInterval(int interval);


		[DllImport(lib,EntryPoint="glfwExtensionSupported")]
		public static extern bool ExtensionSupported(string name);


		[DllImport(lib,EntryPoint="glfwGetProcAddress")]
		public static extern IntPtr GetProcAddress(string procname);






	}
}

