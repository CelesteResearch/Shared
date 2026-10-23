using System.Collections.Generic;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMesh
    {
        private readonly SourceGraphicsDevice graphicsDevice;

        public BoundingSphere BoundingSphere { get; internal set; }

        public SourceModelEffectCollection Effects { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceModelMeshPartCollection MeshParts { get; private set; }

        public string Name { get; internal set; }

        public SourceModelBone ParentBone { get; internal set; }

        public object Tag { get; set; }

        internal SourceModelMesh(SourceGraphicsDevice graphicsDevice, List<SourceModelMeshPart> parts)
        {
            this.graphicsDevice = graphicsDevice;
            MeshParts = new(parts);
            foreach (var part in parts) part.parent = this;

            Effects = [];
        }

        public void Draw()
        {
            foreach (var meshPart in MeshParts)
            {
                var effect = meshPart.SourceEffect;
                if (meshPart.PrimitiveCount <= 0) continue;

                graphicsDevice.SetVertexBuffer(meshPart.SourceVertexBuffer);
                graphicsDevice.Indices = meshPart.SourceIndexBuffer;
                foreach (var pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    graphicsDevice.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, meshPart.VertexOffset, 0,
                        meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount);
                }
            }
        }
    }
}
