using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelBone
    {
        private readonly List<SourceModelBone> children = [];

        private readonly List<SourceModelMesh> meshes = [];

        public SourceModelBoneCollection Children { get; private set; }

        public int Index { get; internal set; }

        public string Name { get; internal set; }

        public SourceModelBone Parent { get; internal set; }

        public Matrix4x4 Transform { get; set; }

        internal SourceModelBone()
        {
            Children = new(new List<SourceModelBone>());
            meshes = [];
        }

        internal void AddMesh(SourceModelMesh mesh)
        {
            meshes.Add(mesh);
        }

        internal void AddChild(SourceModelBone modelBone)
        {
            children.Add(modelBone);
            Children = new(children);
        }
    }
}
