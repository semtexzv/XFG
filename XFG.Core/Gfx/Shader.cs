using XFG.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    public class ShaderProgram
    {
        public uint ProgramHandle
        {
            get;
            private set;
        }
        public uint VertexHandle
        {
            get;
            private set;
        }
        public uint FragmentHandle
        {
            get;
            private set;
        }
        public string VertexSource
        {
            get
            {
                return GL.GetShaderSource(VertexHandle);
            }
        }
        public string FragmentSource
        {
            get
            {
                return GL.GetShaderSource(FragmentHandle);
            }
        }
        public bool Complete
        {
            get
            {
                return GL.GetProgramiv(ProgramHandle, ProgramInfoParam.LINK_STATUS)!=0;
            }
        }
        public ShaderProgram(string VertexSource, string FragmentSource)
        {
            ProgramHandle = GL.CreateProgram();
            AddVertexShader(VertexSource);
            AddFragmentShader(FragmentSource);
            Link();
        }
        public bool AddVertexShader(string vertexSource)
        {
            if (VertexHandle != 0)
            {
                return false;
            }
            VertexHandle = GL.CreateShader(ShaderType.VERTEX_SHADER);
            GL.ShaderSource(VertexHandle, vertexSource);
            GL.CompileShader(VertexHandle);
            if (GL.GetShaderiv(VertexHandle, ShaderParam.COMPILE_STATUS) == 0)
            {
                // Logger.Error("Could not compile vertex shader:\n" + GL.GetShaderInfoLog(VertexHandle));
                Logger.Error(VertexSource);
                Logger.Error("Could not compile vertex shader:\n{0}", GL.GetShaderInfoLog(FragmentHandle));
                GL.DeleteShader(VertexHandle);
                VertexHandle = 0;
                return false;
            }
           
            return true;
        }
        public bool AddFragmentShader(string fragSource)
        {
            if (FragmentHandle != 0)
            {
                return false;
            }
            FragmentHandle = GL.CreateShader(ShaderType.FRAGMENT_SHADER);
            GL.ShaderSource(FragmentHandle, fragSource);
            GL.CompileShader(FragmentHandle);
            if (GL.GetShaderiv(FragmentHandle, ShaderParam.COMPILE_STATUS) == 0)
            {
                Logger.Error(FragmentSource);
                Logger.Error("Could not compile Fragment shader:\n{0}", GL.GetShaderInfoLog(FragmentHandle));
                GL.DeleteShader(FragmentHandle);
                FragmentHandle = 0;
                return false;
            }
            return true;
        }
        public bool Link()
        {
            bool res;
            GL.AttachShader(ProgramHandle, VertexHandle);
            GL.AttachShader(ProgramHandle, FragmentHandle);
            
            GL.LinkProgram(ProgramHandle);

            
            if (GL.GetProgramiv(ProgramHandle, ProgramInfoParam.LINK_STATUS) == 0)
            {
                Logger.Log(LogType.Error, VertexSource);
                Logger.Log(LogType.Error, FragmentSource);
                
                Logger.Error("Could not link program:\n|{0}", GL.GetProgramInfoLog(ProgramHandle));
                res = false;
            }
            else
                res =true;
            GL.DetachShader(ProgramHandle, VertexHandle);
            GL.DetachShader(ProgramHandle, FragmentHandle);

            return res;
        }
        public void Reset()
        {
            GL.DeleteShader(VertexHandle);
            VertexHandle = 0;
            GL.DeleteShader(FragmentHandle);
            FragmentHandle = 0;
            GL.DeleteProgram(ProgramHandle);
            ProgramHandle = 0;
        }
        public int Attribute(string name)
        {
            int res = GL.GetAttribLocation(ProgramHandle, name);
            return res;

        }
        public int Uniform(string name)
        {
            return GL.GetUniformLocation(ProgramHandle, name);
        }
        public void Bind()
        {
            GL.UseProgram(ProgramHandle);
          
        }
    }
}
