using Celeste.Core.Interop;
using Celeste.Core.Rendering.Resources;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Buffers
{
    public struct SourceVertexBufferBinding
    {
        private SourceVertexBuffer vertexBuffer;

        private int vertexOffset;

        private int instanceFrequency;

        internal static readonly SourceVertexBufferBinding None;

        public int InstanceFrequency => instanceFrequency;

        public SourceVertexBuffer VertexBuffer => vertexBuffer;

        public int VertexOffset => vertexOffset;

        public SourceVertexBufferBinding(SourceVertexBuffer vertexBuffer)
        {
            this.vertexBuffer = vertexBuffer;
            vertexOffset = 0;
            instanceFrequency = 0;
        }

        public SourceVertexBufferBinding(SourceVertexBuffer vertexBuffer, int vertexOffset)
        {
            this.vertexBuffer = vertexBuffer;
            this.vertexOffset = vertexOffset;
            instanceFrequency = 0;
        }

        public SourceVertexBufferBinding(SourceVertexBuffer vertexBuffer, int vertexOffset, int instanceFrequency)
        {
            this.vertexBuffer = vertexBuffer;
            this.vertexOffset = vertexOffset;
            this.instanceFrequency = instanceFrequency;
        }

        public static implicit operator SourceVertexBufferBinding(SourceVertexBuffer buffer)
        {
            return new SourceVertexBufferBinding(buffer);
        }

        static SourceVertexBufferBinding()
        {
            None = new SourceVertexBufferBinding(null);
        }
    }
}
