using System;
using XFG.Platform;
using XFG.OpenGL;

namespace XFG.Glfw
{
	public class GlfwDisplay : IDisplay,IInput
	{
		IntPtr _win;
		public GlfwDisplay ()
		{
			Glfw.Init ();
			_win = Glfw.CreateWindow (480, 480, "hello", IntPtr.Zero, IntPtr.Zero);
			Glfw.MakeContextCurrent (_win);
			GL.Load (name => Glfw.GetProcAddress (name));
		}

		#region IDisplay implementation

		public event OnResizeDelegate OnResized;

		public bool SupportsVSync ()
		{
			throw new NotImplementedException ();
		}
		public void Run (AppListener app){
			double time = Glfw.GetTime ();
			while (Glfw.WindowShouldClose (_win) != 1) {
				double newTime = Glfw.GetTime ();
				app.Render ((float)(newTime - time));
				Glfw.SwapBuffers (_win);
				Glfw.PollEvents ();
				time = newTime;
			}
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

		#region IInput implementation

		public event OnKeyDelegate OnKeyDown;

		public event OnKeyDelegate OnKeyUp;

		public event OnCharDelegate OnCharacter;

		public event OnMouseMoveDelegate OnMouseMove;

		public event OnMouseDelegate OnMouseDown;

		public event OnMouseDelegate OnMouseUp;

		public event OnScrollDelegate OnScroll;

		public global::XFG.MathUtils.Vector2 GetMousePos ()
		{
			throw new NotImplementedException ();
		}

		public bool IsKeyDown (Keys key)
		{
			throw new NotImplementedException ();
		}

		public bool IsMouseDown (MouseButton button)
		{
			throw new NotImplementedException ();
		}

		public Modifiers GetModifiers ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

