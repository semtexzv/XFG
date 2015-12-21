﻿using XFG.MathUtils;
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
        void SetSync(SyncType type);
        void SetMode(DisplayMode mode);
        int Width { get; }
        int Height { get; }
        int X { get; }
        int Y { get; }
        void MakeCurrent();
        IntPtr GetProc(string name);
        void SwapBuffers();
        event OnResizeDelegate OnResized;
        void Hide();
        void Show();
      
    }
}
