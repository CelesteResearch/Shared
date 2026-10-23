using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Effects;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMesh
    {
        private SourceGraphicsDevice graphicsDevice;

        public BoundingSphere BoundingSphere { get; internal set; }

        public SourceModelEffectCollection Effects { get; private set; }

        public SourceModelMeshPartCollection MeshParts { get; private set; }

        public string Name { get; internal set; }

        public SourceModelBone ParentBone { get; internal set; }

        public object Tag { get; set; }

        internal SourceModelMesh(SourceGraphicsDevice graphicsDevice, List<SourceModelMeshPart> parts)
        {
            this.graphicsDevice = graphicsDevice;
            MeshParts = new SourceModelMeshPartCollection(parts);
            foreach (SourceModelMeshPart part in parts)
            {
                part.parent = this;
            }

            Effects = new SourceModelEffectCollection();
        }

        public void Draw()
        {
            foreach (SourceModelMeshPart meshPart in MeshParts)
            {
                SourceEffect effect = meshPart.SourceEffect;
                if (meshPart.PrimitiveCount <= 0)
                {
                    continue;
                }

                graphicsDevice.SetVertexBuffer(meshPart.SourceVertexBuffer);
                graphicsDevice.Indices = meshPart.SourceIndexBuffer;
                foreach (SourceEffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    graphicsDevice.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, meshPart.VertexOffset, 0,
                        meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount);
                }
            }
        }
    }
}
