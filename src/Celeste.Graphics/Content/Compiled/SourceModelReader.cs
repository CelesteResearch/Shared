using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Models;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceModelReader : SourceContentTypeReader<SourceModel>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ReadBoneReference(SourceContentReader reader, uint boneCount)
        {
            var num = boneCount >= 255 ? reader.ReadUInt32() : reader.ReadByte();
            if (num != 0) return (int)(num - 1);

            return -1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceModel Read(SourceContentReader reader, SourceModel existingInstance)
        {
            var num = reader.ReadUInt32();
            var list = new List<SourceModelBone>((int)num);
            for (var num2 = 0u; num2 < num; num2++)
            {
                var name = reader.ReadObject<string>();
                var transform = reader.ReadMatrix();
                var item = new SourceModelBone
                {
                    Transform = transform,
                    Index = (int)num2,
                    Name = name,
                };
                list.Add(item);
            }

            for (var i = 0; i < num; i++)
            {
                var modelBone = list[i];
                var num3 = ReadBoneReference(reader, num);
                if (num3 != -1) modelBone.Parent = list[num3];

                var num4 = reader.ReadUInt32();
                if (num4 == 0) continue;

                for (var num5 = 0u; num5 < num4; num5++)
                {
                    var num6 = ReadBoneReference(reader, num);
                    if (num6 != -1) modelBone.AddChild(list[num6]);
                }
            }

            var list2 = new List<SourceModelMesh>();
            var num7 = reader.ReadInt32();
            var graphicsDevice = reader.ContentManager.GetGraphicsDevice();
            for (var j = 0; j < num7; j++)
            {
                var name2 = reader.ReadObject<string>();
                var index = ReadBoneReference(reader, num);
                var boundingSphere = reader.ReadBoundingSphere();
                var tag = reader.ReadObject<object>();
                var num8 = reader.ReadInt32();
                var parts = new List<SourceModelMeshPart>(num8);
                for (var num9 = 0u; num9 < num8; num9++)
                {
                    var modelMeshPart = existingInstance == null
                        ? new()
                        : existingInstance.Meshes[j].MeshParts[(int)num9];
                    modelMeshPart.VertexOffset = reader.ReadInt32();
                    modelMeshPart.NumVertices = reader.ReadInt32();
                    modelMeshPart.StartIndex = reader.ReadInt32();
                    modelMeshPart.PrimitiveCount = reader.ReadInt32();
                    modelMeshPart.Tag = reader.ReadObject<object>();
                    parts.Add(modelMeshPart);
                    var jj = (int)num9;
                    reader.ReadSharedResource([MethodImpl(MethodImplOptions.NoInlining)](SourceVertexBuffer v) =>
                    {
                        parts[jj].SourceVertexBuffer = v;
                    });
                    reader.ReadSharedResource([MethodImpl(MethodImplOptions.NoInlining)](SourceIndexBuffer v) =>
                    {
                        parts[jj].SourceIndexBuffer = v;
                    });
                    reader.ReadSharedResource([MethodImpl(MethodImplOptions.NoInlining)](SourceEffect v) =>
                    {
                        parts[jj].SourceEffect = v;
                    });
                }

                if (existingInstance == null)
                {
                    var modelMesh = new SourceModelMesh(graphicsDevice, parts);
                    modelMesh.Tag = tag;
                    modelMesh.Name = name2;
                    modelMesh.ParentBone = list[index];
                    modelMesh.ParentBone.AddMesh(modelMesh);
                    modelMesh.BoundingSphere = boundingSphere;
                    list2.Add(modelMesh);
                }
            }

            if (existingInstance != null)
            {
                ReadBoneReference(reader, num);
                reader.ReadObject<object>();
                return existingInstance;
            }

            var index2 = ReadBoneReference(reader, num);
            return new(graphicsDevice, list, list2)
            {
                Root = list[index2],
                Tag = reader.ReadObject<object>(),
            };
        }
    }
}
