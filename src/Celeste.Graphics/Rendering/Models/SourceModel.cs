using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;
using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Models
{
    public class SourceModel
    {
        private static Matrix4x4[] sharedDrawBoneMatrices;

        public SourceModelBoneCollection Bones { get; private set; }

        public SourceModelMeshCollection Meshes { get; private set; }

        public SourceModelBone Root { get; internal set; }

        public object Tag { get; set; }

        internal SourceModel(SourceGraphicsDevice graphicsDevice, List<SourceModelBone> bones,
            List<SourceModelMesh> meshes)
        {
            Bones = new SourceModelBoneCollection(bones);
            Meshes = new SourceModelMeshCollection(meshes);
        }

        public void Draw(Matrix4x4 world, Matrix4x4 view, Matrix4x4 projection)
        {
            int count = Bones.Count;
            if (sharedDrawBoneMatrices == null || sharedDrawBoneMatrices.Length < count)
            {
                sharedDrawBoneMatrices = new Matrix4x4[count];
            }

            CopyAbsoluteBoneTransformsTo(sharedDrawBoneMatrices);
            foreach (SourceModelMesh mesh in Meshes)
            {
                foreach (SourceEffect effect in mesh.Effects)
                {
                    ISourceEffectMatrices obj = (effect as ISourceEffectMatrices) ??
                                                throw new InvalidOperationException();
                    obj.World = SourceMatrixMath.Multiply(sharedDrawBoneMatrices[mesh.ParentBone.Index], world);
                    obj.View = view;
                    obj.Projection = projection;
                }

                mesh.Draw();
            }
        }

        public void CopyAbsoluteBoneTransformsTo(Matrix4x4[] destinationBoneTransforms)
        {
            if (destinationBoneTransforms == null)
            {
                throw new ArgumentNullException("destinationBoneTransforms");
            }

            if (destinationBoneTransforms.Length < Bones.Count)
            {
                throw new ArgumentOutOfRangeException("destinationBoneTransforms");
            }

            int count = Bones.Count;
            for (int i = 0; i < count; i++)
            {
                SourceModelBone modelBone = Bones[i];
                if (modelBone.Parent == null)
                {
                    destinationBoneTransforms[i] = modelBone.Transform;
                    continue;
                }

                int index = modelBone.Parent.Index;
                Matrix4x4 matrix = modelBone.Transform;
                SourceMatrixMath.Multiply(ref matrix, ref destinationBoneTransforms[index],
                    out destinationBoneTransforms[i]);
            }
        }

        public void CopyBoneTransformsFrom(Matrix4x4[] sourceBoneTransforms)
        {
            if (sourceBoneTransforms == null)
            {
                throw new ArgumentNullException("sourceBoneTransforms");
            }

            if (sourceBoneTransforms.Length < Bones.Count)
            {
                throw new ArgumentOutOfRangeException("sourceBoneTransforms");
            }

            for (int i = 0; i < sourceBoneTransforms.Length; i++)
            {
                Bones[i].Transform = sourceBoneTransforms[i];
            }
        }

        public void CopyBoneTransformsTo(Matrix4x4[] destinationBoneTransforms)
        {
            if (destinationBoneTransforms == null)
            {
                throw new ArgumentNullException("destinationBoneTransforms");
            }

            if (destinationBoneTransforms.Length < Bones.Count)
            {
                throw new ArgumentOutOfRangeException("destinationBoneTransforms");
            }

            for (int i = 0; i < destinationBoneTransforms.Length; i++)
            {
                destinationBoneTransforms[i] = Bones[i].Transform;
            }
        }
    }
}
