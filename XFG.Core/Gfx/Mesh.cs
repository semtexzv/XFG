using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    /// <summary>
    /// Serves as a container for vertex data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Mesh<T> where T : struct
    {
        public T[] Vertices;
        public short[] Indices;
        public int VertexCount;
        public int IndexCount;
        public Mesh()
        {
            Vertices = new T[8];
            Indices = new short[8];
        }
        public void MakeSpace(int vertCount,int indCount)
        {
            if(VertexCount + vertCount >= Vertices.Length)
            {
                Array.Resize(ref Vertices, Math.Max(Vertices.Length * 2,VertexCount+vertCount));
            }
            if (IndexCount + indCount >= Indices.Length)
            {
                Array.Resize(ref Indices, Math.Max(Indices.Length * 2, IndexCount + indCount));
            }            
        }
        public void AddVertex(T Vertex)
        {
            MakeSpace(1, 1);
            Vertices[VertexCount] = Vertex;
            Indices[IndexCount] = (short) VertexCount;
            VertexCount++;
            IndexCount++;
        }
        public void Add(short[] _indices, params T[] _vertices)
        {
            int res = IndexCount;
            int vertexcount = VertexCount;

            MakeSpace(_vertices.Length, _indices.Length);

            Array.Copy(_vertices, 0, Vertices, vertexcount, _vertices.Length);
            for (int i = 0; i < _indices.Length; i++)
            {
                Indices[res + i] = (short)(_indices[i] + res);
            }
            VertexCount += _vertices.Length;
            IndexCount += _indices.Length;
        }
        public void Add(Mesh<T> other)
        {
            Add(other.Indices, other.Vertices);
        }

        public void Clear()
        {
            VertexCount = IndexCount = 0;
        }
    }
}
