using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMeshPart
    {
        internal SourceModelMesh parent;

        private SourceEffect INTERNAL_effect;

        public SourceEffect SourceEffect
        {
            get => INTERNAL_effect;
            set
            {
                if (value == INTERNAL_effect) return;

                if (INTERNAL_effect != null)
                {
                    var flag = true;
                    foreach (var meshPart in parent.MeshParts)
                        if (meshPart != this && meshPart.INTERNAL_effect == INTERNAL_effect)
                        {
                            flag = false;
                            break;
                        }

                    if (flag) parent.Effects.Remove(INTERNAL_effect);
                }

                INTERNAL_effect = value;
                if (INTERNAL_effect != null && !parent.Effects.Contains(INTERNAL_effect)) parent.Effects.Add(value);
            }
        }

        public SourceIndexBuffer SourceIndexBuffer { get; internal set; }

        public int NumVertices { get; internal set; }

        public int PrimitiveCount { get; internal set; }

        public int StartIndex { get; internal set; }

        public object Tag { get; set; }

        public SourceVertexBuffer SourceVertexBuffer { get; internal set; }

        public int VertexOffset { get; internal set; }

        internal SourceModelMeshPart()
        {
        }
    }
}
