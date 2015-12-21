using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    public class Mesh<T>
    {
        public T[] Vertices;
        public short[] Indices;

        public void Add(Mesh<T> other)
        {
            short VertexCount = (short)Vertices.Length;
            short indexCount = (short)Indices.Length;
            Array.Resize(ref Vertices, Vertices.Length + other.Vertices.Length);
            Array.Resize(ref Indices, Indices.Length + other.Indices.Length);

            Array.Copy(other.Vertices, 0, Vertices, VertexCount, other.Vertices.Length);
            for (int i = 0; i < other.Indices.Length; i++)
            {
                Indices[indexCount + i] = (short)( other.Indices[i] + VertexCount);
            }
        }
    }
}
