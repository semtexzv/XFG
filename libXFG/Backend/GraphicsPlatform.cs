using XFG.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Backend
{

    public interface IGraphicsPlatform : IDisposable
    {
        void SetSync(SyncType type);
        void SetFullscreen(bool fullscreen);
        int Width { get; }
        int Height { get; }
        event OnResizeDelegate OnResized;
    }


}
