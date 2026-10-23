namespace Celeste.Graphics.Rendering.Vertices
{
    public struct SourceVertexElement
    {
        private int offset;

        private SourceVertexElementFormat vertexElementFormat;

        private SourceVertexElementUsage vertexElementUsage;

        private int usageIndex;

        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public SourceVertexElementFormat VertexElementFormat
        {
            get { return vertexElementFormat; }
            set { vertexElementFormat = value; }
        }

        public SourceVertexElementUsage VertexElementUsage
        {
            get { return vertexElementUsage; }
            set { vertexElementUsage = value; }
        }

        public int UsageIndex
        {
            get { return usageIndex; }
            set { usageIndex = value; }
        }

        public SourceVertexElement(int offset, SourceVertexElementFormat elementFormat,
            SourceVertexElementUsage elementUsage, int usageIndex)
        {
            this = default(SourceVertexElement);
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
            return "{{Offset:" + Offset + " Format:" + VertexElementFormat.ToString() + " Usage:" +
                   VertexElementUsage.ToString() + " UsageIndex: " + UsageIndex + "}}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return this == (SourceVertexElement)obj;
        }

        public static bool operator ==(SourceVertexElement left, SourceVertexElement right)
        {
            if (left.Offset == right.Offset && left.UsageIndex == right.UsageIndex &&
                left.VertexElementUsage == right.VertexElementUsage)
            {
                return left.VertexElementFormat == right.VertexElementFormat;
            }

            return false;
        }

        public static bool operator !=(SourceVertexElement left, SourceVertexElement right)
        {
            return !(left == right);
        }
    }
}
