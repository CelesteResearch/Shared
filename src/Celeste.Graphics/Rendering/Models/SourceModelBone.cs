using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelBone
    {
        private List<SourceModelBone> children = new List<SourceModelBone>();

        private List<SourceModelMesh> meshes = new List<SourceModelMesh>();

        public SourceModelBoneCollection Children { get; private set; }

        public int Index { get; internal set; }

        public string Name { get; internal set; }

        public SourceModelBone Parent { get; internal set; }

        public Matrix4x4 Transform { get; set; }

        internal SourceModelBone()
        {
            Children = new SourceModelBoneCollection(new List<SourceModelBone>());
            meshes = new List<SourceModelMesh>();
        }

        internal void AddMesh(SourceModelMesh mesh)
        {
            meshes.Add(mesh);
        }

        internal void AddChild(SourceModelBone modelBone)
        {
            children.Add(modelBone);
            Children = new SourceModelBoneCollection(children);
        }
    }
}
