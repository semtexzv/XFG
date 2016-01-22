using XFG.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{

   public class VertexBuffer<T>
        where T: struct
    { 
        public int VBOHandle
        {
            get;
            private set;
        }
        public int IBOHandle
        {
            get;
            private set;
        }

        public BufferUsage Usage;
        public List<VertexAttribute> Attributes = new List<VertexAttribute>();


        public Mesh<T> Mesh;

        private int TSize = 0;
        private bool Dirty = true;
        public VertexBuffer() : this(BufferUsage.STATIC_DRAW)
        {

        }
        public VertexBuffer(BufferUsage usage)
        {
            Usage = usage;
            Mesh = new Mesh<T>();
            TSize = Marshal.SizeOf(typeof(T));
            VBOHandle = GL.GenBuffer();
            IBOHandle = GL.GenBuffer();
           
        }
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ARRAY_BUFFER, VBOHandle);
            GL.BindBuffer(BufferTarget.ELEMENT_ARRAY_BUFFER, IBOHandle);
        }
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ARRAY_BUFFER, 0);
            GL.BindBuffer(BufferTarget.ELEMENT_ARRAY_BUFFER, 0);
        }
        public void Upload()
        {
            Bind();
            GL.BufferData(BufferTarget.ARRAY_BUFFER, (uint)(Mesh.VertexCount * TSize), Mesh.Vertices, Usage);
            GL.BufferData(BufferTarget.ELEMENT_ARRAY_BUFFER, (uint)(Mesh.IndexCount * sizeof(short)), Mesh.Indices, Usage);
            Dirty = false;
        }
        public void Clear()
        {
            Mesh.Clear();
            Dirty = true;
            
        }
        public void Draw(PrimitiveType type)
        {
            if (Dirty)
            {
                Upload();
            }
            Bind();
            EnableAttribs();
            GL.DrawElements(type, (uint)Mesh.IndexCount, ElementsType.UNSIGNED_SHORT, IntPtr.Zero);
            //We must disable attribs, in case different VBO uses different set of attribs
            DisableAttribs();
        }
        public void Draw(PrimitiveType type, uint offset, uint numIndices)
        {
            if (Dirty)
            {
                Upload();
            }
            Bind();
            EnableAttribs();
            GL.DrawElements(type, numIndices, ElementsType.UNSIGNED_SHORT, (IntPtr) offset);
            //We must disable attribs, in case different VBO uses different set of attribs
            DisableAttribs();
        }
        public void EnableAttribs()
        {
            foreach(var a in Attributes)
            {
                int i = a.Index;
                GL.EnableVertexAttribArray(i);
                GL.VertexAttribPointer(i, a.Elements, a.Type, a.Normalized, TSize, a.Offset);
            }
        }
        public void DisableAttribs()
        {
            foreach (var a in Attributes)
            {
                GL.DisableVertexAttribArray(a.Index);
            }
        }
    }
    public class VertexAttribute
    {
        internal int Index;
        public int Elements;
        public VertexPointerType Type;
        public bool Normalized;
        /// <summary>
        /// Offset from beginning of the structure, in bytes
        /// </summary>
        /// <returns></returns>
        public int Offset;
        public VertexAttribute(int index, int elements, VertexPointerType type, bool normalized,int offset)
        {
            Index = index;
            Elements = elements;
            Type = type;
            Normalized = normalized;
            Offset = offset;
        }
            public VertexAttribute(int index, int elements, VertexPointerType type, int offset) : this(index,elements,type,true,offset)
        {

        }
    }
}
