using JetBrains.Annotations;

namespace Celeste.Graphics.Rendering.Buffers
{
    public struct SourceVertexBufferBinding
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access | ImplicitUseKindFlags.Assign)]
        private SourceVertexBuffer vertexBuffer;

        [UsedImplicitly(ImplicitUseKindFlags.Access | ImplicitUseKindFlags.Assign)]
        private int vertexOffset;

        [UsedImplicitly(ImplicitUseKindFlags.Access | ImplicitUseKindFlags.Assign)]
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

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceVertexBufferBinding(SourceVertexBuffer vertexBuffer, int vertexOffset, int instanceFrequency)
        {
            this.vertexBuffer = vertexBuffer;
            this.vertexOffset = vertexOffset;
            this.instanceFrequency = instanceFrequency;
        }

        public static implicit operator SourceVertexBufferBinding(SourceVertexBuffer buffer)
        {
            return new(buffer);
        }

        static SourceVertexBufferBinding()
        {
            None = new(null);
        }
    }
}
