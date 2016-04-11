using System;
using XFG.Platform;
using XFG.OpenGL;
using System.Text;

namespace XFG.Glfw
{
	public class GlfwDisplay : IDisplay,IInput
	{
		IntPtr _win;
        private WindowSizeFun _resize_cb;
        private KeyFun _key_cb;
        private CursorPosFun _mouse_move_cb;
        private MouseButtonFun _mouse_button_cb;
        private ScrollFun _scroll_cb;
        private CharFun _char_cb;
        public GlfwDisplay (AppConfig config)
		{
			Glfw.Init ();

            _resize_cb = new WindowSizeFun(resize_cb);
            _key_cb = new KeyFun(key_cb);
            _mouse_move_cb = new CursorPosFun(mouse_move_cb);
            _mouse_button_cb = new MouseButtonFun(mouse_button_cb);
            _scroll_cb = new ScrollFun(scroll_cb);
            _char_cb = new CharFun(char_cb);

            _win = Glfw.CreateWindow (config.Width, config.Height, config.Title, IntPtr.Zero, IntPtr.Zero);
			Glfw.SetWindowSizeCallback (_win, _resize_cb);
			Glfw.SetKeyCallback (_win, _key_cb);
			Glfw.SetCursorPosCallback (_win, _mouse_move_cb);
			Glfw.SetMouseButtonCallback (_win, _mouse_button_cb);
			Glfw.SetScrollCallback (_win, _scroll_cb);
			Glfw.SetCharCallback (_win, _char_cb);
			Glfw.MakeContextCurrent (_win);

			GL.Load (name => Glfw.GetProcAddress (name));
		}
		internal void resize_cb(IntPtr window, int w, int h)
		{
			GL.Viewport (0, 0, w, h);
			OnResized (w, h);
		}
		internal void key_cb(IntPtr window, Glfw.Keys key, int scan, KeyAction action, Glfw.Mods mods)
		{
			if (action == KeyAction.Press && OnKeyDown != null) {
				OnKeyDown (Glfw.MapKey (key), Glfw.MapMods (mods));
			}

			if (action == KeyAction.Release && OnKeyUp != null) {
				OnKeyUp (Glfw.MapKey (key), Glfw.MapMods (mods));
			}
		}
		internal void mouse_move_cb(IntPtr window, double x , double y){
			if (OnMouseMove != null) {
				OnMouseMove ((int)x, (int)y);
			}
		}
		internal void mouse_button_cb(IntPtr window,Glfw.MouseButton button,KeyAction action, Glfw.Mods mods)
		{
			if (action == KeyAction.Press && OnMouseDown != null) {
				OnMouseDown (Glfw.MapMouseButton (button));
			
			}
			if (action == KeyAction.Release && OnMouseUp != null) {
				OnMouseUp (Glfw.MapMouseButton (button));
			}
		}
		internal void scroll_cb(IntPtr window, double xoff, double yoff)
		{
			if (OnScroll != null) {
				OnScroll ((int)yoff);
			}
		}
		internal void char_cb(IntPtr window, uint codepoint)
		{
			string x = Char.ConvertFromUtf32 ((int)codepoint);
			if (OnCharacter != null) {
				foreach (var c in x) {
					OnCharacter (c);
				}
			}
		}
		#region IDisplay implementation

		public event OnResizeDelegate OnResized;

		public bool SupportsVSync ()
		{
			return Glfw.ExtensionSupported ("WGL_EXT_swap_control") |
				Glfw.ExtensionSupported ("GLX_EXT_swap_control");
			
		}

		public void Run (AppListener app){
			double time = Glfw.GetTime ();
			int w, h;
			Glfw.GetWindowSize (_win, out w, out h);
			resize_cb (_win, w, h);
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
			bool avsync = Glfw.ExtensionSupported ("WGL_EXT_swap_control_tear") |
			              Glfw.ExtensionSupported ("GLX_EXT_swap_control_tear");
			
			Glfw.SwapInterval( sync ? ( avsync ? -1 : 1): 0);
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
			Glfw.ShowWindow (_win);	
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
			int x, y;
			Glfw.GetCursorPos (_win, out x, out y);
			return new global::XFG.MathUtils.Vector2 (x, y);
		}

		public bool IsKeyDown ( global::XFG.Keys key)
		{
			// Todo, throw away this ugly solution and create mapping array so
			// reverse mapping will take only one pass through this array
			Glfw.Keys mapped = Glfw.Keys.GLFW_KEY_UNKNOWN;

			for(int i=(int)Glfw.Keys.GLFW_KEY_UNKNOWN; i<=(int)Glfw.Keys.GLFW_KEY_LAST; i++) {
				if (Glfw.MapKey ((Glfw.Keys)i) == key) {
					mapped = (Glfw.Keys)i;
				}
			}
			KeyAction state = Glfw.GetKey(_win,mapped);
			return state == KeyAction.Press;
		}

		public bool IsMouseDown (MouseButton button)
		{
			var state = Glfw.GetMouseButton(_win, (Glfw.MouseButton) (button - 1));
			return state == KeyAction.Press;
		}

		public Modifiers GetModifiers ()
		{
			var res = Modifiers.None;
			res |= (IsKeyDown (Keys.ALT_LEFT) | IsKeyDown (Keys.ALT_RIGHT)) ? Modifiers.Alt : Modifiers.None;
			res |= (IsKeyDown (Keys.CTRL_LEFT) | IsKeyDown (Keys.CTRL_RIGHT)) ? Modifiers.Control : Modifiers.None;
			res |= (IsKeyDown (Keys.SHIFT_LEFT) | IsKeyDown (Keys.SHIFT_RIGHT)) ? Modifiers.Shift : Modifiers.None;

			res |= (IsKeyDown (Keys.META_LEFT) | IsKeyDown (Keys.META_RIGHT)) ? Modifiers.Super : Modifiers.None;
			return res;
		}

		#endregion
	}
}

