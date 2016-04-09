using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.OpenGL;

namespace XFG.Platform
{
    public interface IDisplay
    {
        bool SupportsVSync();
        void SetVSync(bool sync);
		// Is is a god idea to add this functionality ?
		// It will probably require context re-creation.
        void SetMode(DisplayMode mode);
        int Width { get; }
        int Height { get; }
        void Hide();
        void Show();

        event OnResizeDelegate OnResized;
      
    }
}
