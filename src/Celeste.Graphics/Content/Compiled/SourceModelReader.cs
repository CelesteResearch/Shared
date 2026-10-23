using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Models;
using Celeste.Core.Rendering.States;
using Celeste.Core.Geometry.Intersections;
using System.Numerics;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceModelReader : SourceContentTypeReader<SourceModel>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ReadBoneReference(SourceContentReader reader, uint boneCount)
        {
            uint num = ((boneCount >= 255) ? reader.ReadUInt32() : reader.ReadByte());
            if (num != 0)
            {
                return (int)(num - 1);
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceModel Read(SourceContentReader reader, SourceModel existingInstance)
        {
            uint num = reader.ReadUInt32();
            List<SourceModelBone> list = new List<SourceModelBone>((int)num);
            for (uint num2 = 0u; num2 < num; num2++)
            {
                string name = reader.ReadObject<string>();
                Matrix4x4 transform = reader.ReadMatrix();
                SourceModelBone item = new SourceModelBone
                {
                    Transform = transform,
                    Index = (int)num2,
                    Name = name
                };
                list.Add(item);
            }

            for (int i = 0; i < num; i++)
            {
                SourceModelBone modelBone = list[i];
                int num3 = ReadBoneReference(reader, num);
                if (num3 != -1)
                {
                    modelBone.Parent = list[num3];
                }

                uint num4 = reader.ReadUInt32();
                if (num4 == 0)
                {
                    continue;
                }

                for (uint num5 = 0u; num5 < num4; num5++)
                {
                    int num6 = ReadBoneReference(reader, num);
                    if (num6 != -1)
                    {
                        modelBone.AddChild(list[num6]);
                    }
                }
            }

            List<SourceModelMesh> list2 = new List<SourceModelMesh>();
            int num7 = reader.ReadInt32();
            SourceGraphicsDevice graphicsDevice = reader.ContentManager.GetGraphicsDevice();
            for (int j = 0; j < num7; j++)
            {
                string name2 = reader.ReadObject<string>();
                int index = ReadBoneReference(reader, num);
                BoundingSphere boundingSphere = reader.ReadBoundingSphere();
                object tag = reader.ReadObject<object>();
                int num8 = reader.ReadInt32();
                List<SourceModelMeshPart> parts = new List<SourceModelMeshPart>(num8);
                for (uint num9 = 0u; num9 < num8; num9++)
                {
                    SourceModelMeshPart modelMeshPart = ((existingInstance == null)
                        ? new SourceModelMeshPart()
                        : existingInstance.Meshes[j].MeshParts[(int)num9]);
                    modelMeshPart.VertexOffset = reader.ReadInt32();
                    modelMeshPart.NumVertices = reader.ReadInt32();
                    modelMeshPart.StartIndex = reader.ReadInt32();
                    modelMeshPart.PrimitiveCount = reader.ReadInt32();
                    modelMeshPart.Tag = reader.ReadObject<object>();
                    parts.Add(modelMeshPart);
                    int jj = (int)num9;
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
                    SourceModelMesh modelMesh = new SourceModelMesh(graphicsDevice, parts);
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

            int index2 = ReadBoneReference(reader, num);
            return new SourceModel(graphicsDevice, list, list2)
            {
                Root = list[index2],
                Tag = reader.ReadObject<object>()
            };
        }
    }
}
