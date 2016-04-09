using System;
using XFG.Platform;
using XFG.OpenGL;

namespace XFG.Glfw
{
	public class GlfwDisplay : IDisplay,IInput
	{
		IntPtr _win;
		public GlfwDisplay (AppConfig config)
		{
			Glfw.Init ();
			_win = Glfw.CreateWindow (config.Width, config.Height, config.Title, IntPtr.Zero, IntPtr.Zero);
			Glfw.SetWindowSizeCallback (_win, resize_cb);
			Glfw.SetKeyCallback (_win, key_cb);
			Glfw.MakeContextCurrent (_win);

			GL.Load (name => Glfw.GetProcAddress (name));
		}
		internal void resize_cb(IntPtr window, int w, int h)
		{
			GL.Viewport (0, 0, w, h);
			OnResized (w, h);
		}
		internal void key_cb(IntPtr window, Keys key, int scan, KeyAction action, Mods mods)
		{
			
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
				Logger.Debug ("Time: {0}", newTime - time);
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
			Glfw.HideWindow ();
		}

		public void Show ()
		{
			
		}

		public int Width {
			get {
				int w, h;
				Glfw.GetWindowSize (_win, out w, out h);
				return w;
			}
		}

		public int Height {
			get {

				int w, h;
				Glfw.GetWindowSize (_win, out w, out h);
				return h;
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

		public bool IsKeyDown ( global::XFG.Keys key)
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

