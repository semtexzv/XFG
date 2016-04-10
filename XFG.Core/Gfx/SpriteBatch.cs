using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.MathUtils;
using XFG.OpenGL;
using System.Runtime.InteropServices;

namespace XFG.Gfx
{
    /// <summary>
    /// Simple vertex with 2d position, one texture and RGBA color
    /// </summary>
    public struct SimpleVertex
    {
        public Vector2 pos;
        public Vector2 tex;
        public int col;
    }
    /// <summary>
    /// Class for drawing 2d sprites, optimized for perf. Performs batching using Vertex Buffer
    /// </summary>
    public class SpriteBatch
    {
        /// <summary>
        /// Color tint, applied to every draw call after this variable is changed
        /// </summary>
        public Color Color = new Color(1, 1, 1, 1f);
        /// <summary>
        /// Does this instance support transparency, if not, disabling it could improve performance
        /// </summary>
        public bool Transparency;
        /// <summary>
        /// Transform is applied to every vertex. Probably combined camera matrix.
        /// </summary>
        public Matrix4 Transform = Matrix4.Identity;
        public Matrix4 View = Matrix4.Identity;

        private VertexBuffer<SimpleVertex> Buffer;
        private ShaderProgram Program;
        private bool Dirty = false;
        private Texture CurrentTexture = null;

        public SpriteBatch()
        {
            GenerateShader();
            Buffer = new VertexBuffer<SimpleVertex>(OpenGL.BufferUsage.STATIC_DRAW);
            Buffer.Attributes.Add(new VertexAttribute(Program.Attribute(PositionAttribName), 2, VertexPointerType.FLOAT, 0));
            Buffer.Attributes.Add(new VertexAttribute(Program.Attribute(TexCoordAttribName), 2, VertexPointerType.FLOAT, 8));
            Buffer.Attributes.Add(new VertexAttribute(Program.Attribute(ColorAttribName), 4, VertexPointerType.UNSIGNED_BYTE,true, 16));
        }
        /// <summary>
        /// Flushes all data stored for rendedring. This will get called automaticly 
        /// if you render sprites with different textures
        /// </summary>
        public void Flush()
        {
            if (Dirty)
            {
                Program.Bind();
                Buffer.Bind();
                if (Transparency)
                {
                    GL.Enable(EnableCap.BLEND);
                    GL.BlendFunc(BlendingFactor.SRC_ALPHA, BlendingFactor.ONE_MINUS_SRC_ALPHA);
                }
                GL.UniformMatrix4fv(Program.Uniform(ProjTransName), 1, false,View*Transform);
                
                CurrentTexture.Bind();
                GL.Uniform1i(Program.Uniform(TextureUniformName), CurrentTexture.Unit);
                Buffer.Draw(OpenGL.PrimitiveType.TRIANGLES);
                Buffer.Clear();
            }

        }
        /// <summary>
        /// Draws a texture at xCenter,yCenter, with desired width, height, and rotationn
        /// </summary>
        public void Draw(Texture text, float xCenter, float yCenter, float width, float height, float rotation = 0)
        {
            Draw(new TextureRegion(text), xCenter, yCenter, width, height, rotation);
        }
        /// <summary>
        /// Draws a TextureRegion at xCenter,yCenter, with desired width, height, and rotationn
        /// </summary>
        public void Draw(TextureRegion region, float xCenter, float yCenter, float width, float height, float rotation=0)
        {
            if(Dirty && CurrentTexture != null && region.Texture != CurrentTexture)
            {
                Flush();
            }
            CurrentTexture = region.Texture;
            Dirty = true;
            float hw = width * 0.5f;
            float hh = height * 0.5f;
            float s = MathUtils.Math.Sin(rotation);
            float c = MathUtils.Math.Cos(rotation);
            int ic = Color.ToRGBA8888(Color);
            SimpleVertex v1 = new SimpleVertex() { pos = new Vector2(-hw, -hh), col =ic, tex = new Vector2(region.U1, region.V2) };
            SimpleVertex v2 = new SimpleVertex() { pos = new Vector2(hw, -hh), col = ic, tex = new Vector2(region.U2, region.V2) };
            SimpleVertex v3 = new SimpleVertex() { pos = new Vector2(hw, hh), col = ic, tex = new Vector2(region.U2, region.V1) };
            SimpleVertex v4 = new SimpleVertex() { pos = new Vector2(-hw, hh), col = ic, tex = new Vector2(region.U1, region.V1) };
            if (rotation != 0 && rotation != MathUtils.Math.PI * 2)
            {
                v1.pos.Rotate(rotation);
                v2.pos.Rotate(rotation);
                v3.pos.Rotate(rotation);
                v4.pos.Rotate(rotation);
            }
            v1.pos.Add(xCenter, yCenter);
            v2.pos.Add(xCenter, yCenter);
            v3.pos.Add(xCenter, yCenter);
            v4.pos.Add(xCenter, yCenter);
            Buffer.Mesh.Add(new short[] { 0, 1, 2, 2, 3, 0 }, v1, v2, v3, v4);
        }

        private string PositionAttribName = "a_pos";
        private string TexCoordAttribName = "a_tex";
        private string ColorAttribName = "a_col";
        private string ProjTransName = "u_projTrans";
        private string TextureUniformName = "u_texture";
      
        private void SetShader(ShaderProgram program,string positionAttrib,string TexCoordAttrib,string ColorAttrib,string transformUniform,string textureUniform)
        {
            Program = program;
            PositionAttribName = positionAttrib;
            TexCoordAttribName = TexCoordAttrib;
            ColorAttribName = ColorAttrib;
            ProjTransName = transformUniform;
            TextureUniformName = textureUniform;
           
        }
        private void GenerateShader()
      {

          Program = new ShaderProgram(
@"
attribute vec2 a_pos;
attribute vec2 a_tex;
attribute vec4 a_col;

uniform mat4 u_projTrans;

varying vec2 v_tex;
varying vec4 v_col;
void main()
{
    v_tex=a_tex;
    v_col=a_col;
    gl_Position = u_projTrans*vec4(a_pos,0.0,1.0);
}
",


@"
#ifdef GL_ES
#define LOWP lowp
precision mediump float;
#else
#define LOWP
#endif


varying vec2 v_tex;
varying LOWP vec4 v_col;

uniform sampler2D u_texture;

void main()
{
    gl_FragColor  =  v_col*texture2D(u_texture,v_tex);
}
"); 
            
        }
    }
}

