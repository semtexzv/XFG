using XFG.Platform;
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
        private static IDisplay Platform;
        internal static void SetPlatform(IDisplay graphics)
        {
            Platform = graphics;
        }

        public static void SetSync(SyncType type)
        {
            Platform.SetSync(type);
        }
        

    }
}
