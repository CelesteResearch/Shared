using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMeshPart
    {
        internal SourceModelMesh parent;

        private SourceEffect INTERNAL_effect;

        public SourceEffect SourceEffect
        {
            get { return INTERNAL_effect; }
            set
            {
                if (value == INTERNAL_effect)
                {
                    return;
                }

                if (INTERNAL_effect != null)
                {
                    bool flag = true;
                    foreach (SourceModelMeshPart meshPart in parent.MeshParts)
                    {
                        if (meshPart != this && meshPart.INTERNAL_effect == INTERNAL_effect)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        parent.Effects.Remove(INTERNAL_effect);
                    }
                }

                INTERNAL_effect = value;
                if (INTERNAL_effect != null && !parent.Effects.Contains(INTERNAL_effect))
                {
                    parent.Effects.Add(value);
                }
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
