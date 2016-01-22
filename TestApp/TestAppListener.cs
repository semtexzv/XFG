using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG;
using XFG.Gfx;
using XFG.MathUtils;
using XFG.OpenGL;
namespace TestApp
{
    class TestAppListener :XFG.AppListener
    {
        XFG.Gfx.Texture tex;
        SpriteBatch batch;
        public void Create()
        {
            batch = new SpriteBatch();
            tex = new XFG.Gfx.Texture("Assets/images.png");

            XFG.Input.OnMouseMove += Input_OnMouseMove;
        }

        private void Input_OnMouseMove(int x, int y)
        {
            Logger.Log("{},{},", x, y);
        }

        public void Render(float delta)
        {
            GL.ClearColor(0, 1, 1, 0.5f);
            GL.Clear(ClearBufferMask.ALL);
            batch.View = Matrix4.Ortho(10, 10);
            batch.Transform *= Matrix4.Translation(new Vector3(0, 0.1f, 0f));
            batch.Draw(tex, 0, 0, 10, 10, 0);
            batch.Flush();
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
