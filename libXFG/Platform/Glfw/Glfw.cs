using System;
using System.Runtime.InteropServices;

namespace XFG.Glfw
{
	public static class Glfw
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
		public static extern IntPtr SetErrorCallback(IntPtr cbfun);

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
		public static extern IntPtr SetFramebufferSizeCallback(IntPtr window,IntPtr cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowCloseCallback")]
		public static extern IntPtr SetWindowCloseCallback(IntPtr window, IntPtr cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowFocusCallback")]
		public static extern IntPtr SetWindowFocusCallback(IntPtr window, IntPtr cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowIconifyCallback")]
		public static extern IntPtr SetWindowIconifyCallback(IntPtr window, IntPtr cbfun);


		[DllImport(lib,EntryPoint="glfwSetWindowPosCallback")]
		public static extern IntPtr SetWindowPosCallback(IntPtr window, IntPtr cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowRefreshCallback")]
		public static extern IntPtr SetWindowRefreshCallback(IntPtr window, IntPtr cbfun);

		[DllImport(lib,EntryPoint="glfwSetWindowSizeCallback")]
		public static extern IntPtr SetWindowSizeCallback(IntPtr window, IntPtr cbfun);



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

		[DllImport(lib,EntryPoint="glfwSwapBuffers")]
		public static extern void SwapBuffers(IntPtr window);

		[DllImport(lib,EntryPoint="glfwWaitEvents")]
		public static extern void WaitEvents();

		[DllImport(lib,EntryPoint="glfwWindowHint")]
		public static extern void ShowWindow(int target, int hint);

		[DllImport(lib,EntryPoint="glfwWindowShouldClose")]
		public static extern int WindowShouldClose(IntPtr window);












	
	}
}

