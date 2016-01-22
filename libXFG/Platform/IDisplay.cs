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
        void SetMode(DisplayMode mode);
        int Width { get; }
        int Height { get; }
        void Hide();
        void Show();

        event OnResizeDelegate OnResized;
      
    }
}
