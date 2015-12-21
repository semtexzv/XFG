using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.OpenGL;
namespace TestApp
{
    class TestAppListener :XFG.AppListener
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Render(float delta)
        {
            GL.ClearColor(0, 1, 1, 0.5f);
            GL.Clear(ClearBufferMask.ALL);
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
