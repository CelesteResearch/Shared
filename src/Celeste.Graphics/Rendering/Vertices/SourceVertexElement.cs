using JetBrains.Annotations;

namespace Celeste.Graphics.Rendering.Vertices
{
    public struct SourceVertexElement
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private int offset;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private SourceVertexElementFormat vertexElementFormat;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private SourceVertexElementUsage vertexElementUsage;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private int usageIndex;

        public int Offset
        {
            get => offset;
            set => offset = value;
        }

        public SourceVertexElementFormat VertexElementFormat
        {
            get => vertexElementFormat;
            set => vertexElementFormat = value;
        }

        public SourceVertexElementUsage VertexElementUsage
        {
            get => vertexElementUsage;
            set => vertexElementUsage = value;
        }

        public int UsageIndex
        {
            get => usageIndex;
            set => usageIndex = value;
        }

        public SourceVertexElement(int offset, SourceVertexElementFormat elementFormat,
            SourceVertexElementUsage elementUsage, int usageIndex)
        {
            this = default;
            Offset = offset;
            UsageIndex = usageIndex;
            VertexElementFormat = elementFormat;
            VertexElementUsage = elementUsage;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "{{Offset:" + Offset + " Format:" + VertexElementFormat + " Usage:" +
                   VertexElementUsage + " UsageIndex: " + UsageIndex + "}}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != GetType()) return false;

            return this == (SourceVertexElement)obj;
        }

        public static bool operator ==(SourceVertexElement left, SourceVertexElement right)
        {
            if (left.Offset == right.Offset && left.UsageIndex == right.UsageIndex &&
                left.VertexElementUsage == right.VertexElementUsage)
                return left.VertexElementFormat == right.VertexElementFormat;

            return false;
        }

        public static bool operator !=(SourceVertexElement left, SourceVertexElement right)
        {
            return !(left == right);
        }
    }
}
