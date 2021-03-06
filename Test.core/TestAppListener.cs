﻿using System;
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
    public class TestAppListener :XFG.AppListener
    {
        XFG.Gfx.Texture tex;
        SpriteBatch batch;
        public void Create()
        {
            batch = new SpriteBatch();
            GL.Enable(EnableCap.BLEND);
            GL.BlendFunc(BlendingFactor.SRC_ALPHA, BlendingFactor.ONE_MINUS_SRC_ALPHA);

            Graphics.SetVSync(true);
           
            tex = new Texture(Files.Internal("image.png"));

            Input.OnMouseMove += Input_OnMouseMove;
            Graphics.OnResize += (int width, int height) =>
            {
                batch.View = Matrix4.Ortho(width, height);
            };
            Input.OnKeyDown += (key, mods) =>
            {
                Logger.Debug("KeyDown {0} , {1}", key, mods);
            };
            Input.OnMouseDown += (button) => {
                Logger.Debug("Mouse {0}",button);
            };
            Input.OnScroll += (amount) => {
                Logger.Debug("Scroll {0}",amount);
            };
        }

        private void Input_OnMouseMove(int x, int y)
        {
            Logger.Log("{0},{1},", x, y);
        }
        float time = 0;
        public void Render(float delta)
        {
            time += delta;
            GL.ClearColor(0, 1, 1, 0.5f);
            GL.Clear(ClearBufferMask.ALL);
            float dim = XFG.MathUtils.Math.Min(Graphics.Width, Graphics.Height);
            batch.Draw(tex, 0, 0, dim,dim,-time);
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
