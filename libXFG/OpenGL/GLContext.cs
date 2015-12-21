using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.OpenGL
{
    public abstract class GLContext :IDisposable
    {
        public IntPtr GLHandle;
        public static GLContext Current { get; protected set; }

        public bool DoubleBuffer
        {
            get;
            protected set;
        }
        public bool IsCurrent()
        {
            return Current == this;
        }
        public abstract bool VsyncAvailable();
        public abstract bool AVsyncAvailable();
        public abstract SyncType Sync
        {
            get;
            set;
        }
        public abstract void MakeCurrent();

        public abstract void Dispose();

        public abstract void SwapBuffers();

        public abstract bool IsExtensionAvailable(string ext);
    }
}
