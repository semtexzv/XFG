using System;
using XFG.Platform;

namespace XFG.Glfw
{
	public class GlfwDisplay : IDisplay
	{
		IntPtr _win;
		public GlfwDisplay ()
		{
			Glfw.Init ();
			_win = Glfw.CreateWindow (480, 480, "hello", IntPtr.Zero, IntPtr.Zero);
		}

		#region IDisplay implementation

		public event OnResizeDelegate OnResized;

		public bool SupportsVSync ()
		{
			throw new NotImplementedException ();
		}

		public void SetVSync (bool sync)
		{
			throw new NotImplementedException ();
		}

		public void SetMode (global::XFG.OpenGL.DisplayMode mode)
		{
			throw new NotImplementedException ();
		}

		public void Hide ()
		{
			throw new NotImplementedException ();
		}

		public void Show ()
		{
			throw new NotImplementedException ();
		}

		public int Width {
			get {
				throw new NotImplementedException ();
			}
		}

		public int Height {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

