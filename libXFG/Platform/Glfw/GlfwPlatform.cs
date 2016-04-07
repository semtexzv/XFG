using System;
using XFG.Platform;

namespace XFG.Glfw
{
	internal class GlfwPlatform : IPlatform
	{
		private GlfwDisplay _display;
		public GlfwPlatform ()
		{
		}

		#region IPlatform implementation

		public void Init (AppConfig config)
		{
			_display = new GlfwDisplay ();
		}

		public void Run (AppListener app)
		{
			
		}

		public IAudio Audio {
			get {
				return null;
			}
		}

		public IDisplay Display {
			get {
				return _display;
			}
		}

		public IInput Input {
			get {
				return null;	
			}
		}

		#endregion
	}
}

