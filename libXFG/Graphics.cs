using XFG.Backend;
using XFG.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XFG
{
    public delegate void OnResizeDelegate(int width, int height);


    public static class Graphics
    {
        
        static Graphics()
        {
        }

        public static int Width { get { return Platform.Width; } }
        public static int Height { get { return Platform.Height; } }

        public static event OnResizeDelegate OnResize
        {
            add { Platform.OnResized += value; }
            remove { Platform.OnResized -= value; }
        }

        private static IGraphicsPlatform Platform;
       internal static void SetPlatform(IGraphicsPlatform graphics)
        {
            Platform = graphics;
        }

        public static void SetSync(SyncType type)
        {
            Platform.SetSync(type);
        }
        

    }
}
