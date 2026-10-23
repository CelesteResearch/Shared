using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Formats.Graphics.Models
{
    public class ObjectModel : IDisposable
    {
        public class Mesh
        {
            public string Name = "";

            public ObjectModel Model;

            public int VertexStart;

            public int VertexCount;
        }

        public List<Mesh> Meshes = new List<Mesh>();

        protected readonly ISourceGraphicsDeviceEnvironment environment;
        protected SourceGraphicsDevice Device => environment.GraphicsDevice;

        public ObjectModel(ISourceGraphicsDeviceEnvironment environment)
        {
            this.environment = environment;
        }

        public SourceVertexBuffer Vertices;

        protected SourceVertexPositionTexture[] verts;

        protected virtual bool ResetVertexBuffer()
        {
            if (Vertices == null || Vertices.IsDisposed || Vertices.GraphicsDevice.IsDisposed)
            {
                Vertices = new SourceVertexBuffer(Device, typeof(SourceVertexPositionTexture), verts.Length,
                    SourceBufferUsage.None);
                Vertices.SetData(verts);
                return true;
            }

            return false;
        }

        public void ReassignVertices()
        {
            if (!ResetVertexBuffer())
            {
                Vertices.SetData(verts);
            }
        }

        public void Draw(SourceEffect effect)
        {
            ResetVertexBuffer();
            Device.SetVertexBuffer(Vertices);
            foreach (SourceEffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawPrimitives(SourcePrimitiveType.TriangleList, 0, Vertices.VertexCount / 3);
            }
        }

        public void Dispose()
        {
            Vertices.Dispose();
            Meshes = null;
        }

        public static ObjectModel Create(string filename, ISourceGraphicsDeviceEnvironment environment,
            global::Celeste.Core.IO.Content.IContentSource files = null)
        {
            Path.GetDirectoryName(filename);
            ObjectModel objModel = ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);
            List<SourceVertexPositionTexture> list = new List<SourceVertexPositionTexture>();
            List<Vector3> list2 = new List<Vector3>();
            List<Vector2> list3 = new List<Vector2>();
            Mesh mesh = null;
            if (files == null ? File.Exists(filename + ".export") : files.FileExists(filename + ".export"))
            {
                using BinaryReader binaryReader = new BinaryReader(files == null
                    ? File.OpenRead(filename + ".export")
                    : files.OpenTitleStream(filename + ".export"));
                int num = binaryReader.ReadInt32();
                for (int i = 0; i < num; i++)
                {
                    if (mesh != null)
                    {
                        mesh.VertexCount = list.Count - mesh.VertexStart;
                    }

                    mesh = new Mesh();
                    mesh.Name = binaryReader.ReadString();
                    mesh.VertexStart = list.Count;
                    objModel.Meshes.Add(mesh);
                    int num2 = binaryReader.ReadInt32();
                    for (int j = 0; j < num2; j++)
                    {
                        float x = binaryReader.ReadSingle();
                        float y = binaryReader.ReadSingle();
                        float z = binaryReader.ReadSingle();
                        list2.Add(new Vector3(x, y, z));
                    }

                    int num3 = binaryReader.ReadInt32();
                    for (int k = 0; k < num3; k++)
                    {
                        float x2 = binaryReader.ReadSingle();
                        float y2 = binaryReader.ReadSingle();
                        list3.Add(new Vector2(x2, y2));
                    }

                    int num4 = binaryReader.ReadInt32();
                    for (int l = 0; l < num4; l++)
                    {
                        int index = binaryReader.ReadInt32() - 1;
                        int index2 = binaryReader.ReadInt32() - 1;
                        list.Add(new SourceVertexPositionTexture
                        {
                            Position = list2[index],
                            TextureCoordinate = list3[index2]
                        });
                    }
                }
            }
            else
            {
                using StreamReader streamReader = files == null
                    ? new StreamReader(filename)
                    : new StreamReader(files.OpenTitleStream(filename));
                string text;
                while ((text = streamReader.ReadLine()) != null)
                {
                    string[] array = text.Split(' ');
                    if (array.Length == 0)
                    {
                        continue;
                    }

                    switch (array[0])
                    {
                        case "o":
                            if (mesh != null)
                            {
                                mesh.VertexCount = list.Count - mesh.VertexStart;
                            }

                            mesh = new Mesh();
                            mesh.Name = array[1];
                            mesh.VertexStart = list.Count;
                            objModel.Meshes.Add(mesh);
                            break;
                        case "v":
                        {
                            Vector3 item3 = new Vector3(Float(array[1]), Float(array[2]), Float(array[3]));
                            list2.Add(item3);
                            break;
                        }
                        case "vt":
                        {
                            Vector2 item2 = new Vector2(Float(array[1]), Float(array[2]));
                            list3.Add(item2);
                            break;
                        }
                        case "f":
                        {
                            for (int m = 1; m < Math.Min(4, array.Length); m++)
                            {
                                SourceVertexPositionTexture item = default(SourceVertexPositionTexture);
                                string[] array2 = array[m].Split('/');
                                if (array2[0].Length > 0)
                                {
                                    item.Position = list2[int.Parse(array2[0]) - 1];
                                }

                                if (array2[1].Length > 0)
                                {
                                    item.TextureCoordinate = list3[int.Parse(array2[1]) - 1];
                                }

                                list.Add(item);
                            }

                            break;
                        }
                    }
                }
            }

            if (mesh != null)
            {
                mesh.VertexCount = list.Count - mesh.VertexStart;
            }

            objModel.verts = list.ToArray();
            objModel.ResetVertexBuffer();
            return objModel;
        }

        private static float Float(string data)
        {
            return float.Parse(data, CultureInfo.InvariantCulture);
        }

        public static ObjectModel CreateFromStream(Stream stream, string fname,
            ISourceGraphicsDeviceEnvironment environment)
        {
            if (((ISourceObjModelEnvironment)environment).ObjModelPolicy.SkipStreamRead(environment))
            {
                return ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);
            }

            ObjectModel objModel = ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);
            List<SourceVertexPositionTexture> list = new List<SourceVertexPositionTexture>();
            List<Vector3> list2 = new List<Vector3>();
            List<Vector2> list3 = new List<Vector2>();
            Mesh mesh = null;
            if (fname.EndsWith(".export"))
            {
                using BinaryReader binaryReader = new BinaryReader(stream);
                int num = binaryReader.ReadInt32();
                for (int i = 0; i < num; i++)
                {
                    if (mesh != null)
                    {
                        mesh.VertexCount = list.Count - mesh.VertexStart;
                    }

                    mesh = new Mesh();
                    mesh.Name = binaryReader.ReadString();
                    mesh.VertexStart = list.Count;
                    objModel.Meshes.Add(mesh);
                    int num2 = binaryReader.ReadInt32();
                    for (int j = 0; j < num2; j++)
                    {
                        float x = binaryReader.ReadSingle();
                        float y = binaryReader.ReadSingle();
                        float z = binaryReader.ReadSingle();
                        list2.Add(new Vector3(x, y, z));
                    }

                    int num3 = binaryReader.ReadInt32();
                    for (int k = 0; k < num3; k++)
                    {
                        float x2 = binaryReader.ReadSingle();
                        float y2 = binaryReader.ReadSingle();
                        list3.Add(new Vector2(x2, y2));
                    }

                    int num4 = binaryReader.ReadInt32();
                    for (int l = 0; l < num4; l++)
                    {
                        int index = binaryReader.ReadInt32() - 1;
                        int index2 = binaryReader.ReadInt32() - 1;
                        list.Add(new SourceVertexPositionTexture
                        {
                            Position = list2[index],
                            TextureCoordinate = list3[index2]
                        });
                    }
                }
            }
            else
            {
                using StreamReader streamReader = new StreamReader(stream);
                string text;
                while ((text = streamReader.ReadLine()) != null)
                {
                    string[] array = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (array.Length == 0)
                    {
                        continue;
                    }

                    switch (array[0])
                    {
                        case "o":
                            if (mesh != null)
                            {
                                mesh.VertexCount = list.Count - mesh.VertexStart;
                            }

                            mesh = new Mesh();
                            mesh.Name = array[1];
                            mesh.VertexStart = list.Count;
                            objModel.Meshes.Add(mesh);
                            break;
                        case "v":
                        {
                            Vector3 item3 = new Vector3(Float(array[1]), Float(array[2]), Float(array[3]));
                            list2.Add(item3);
                            break;
                        }
                        case "vt":
                        {
                            Vector2 item2 = new Vector2(Float(array[1]), Float(array[2]));
                            list3.Add(item2);
                            break;
                        }
                        case "f":
                        {
                            for (int m = 1; m < Math.Min(4, array.Length); m++)
                            {
                                SourceVertexPositionTexture item = default(SourceVertexPositionTexture);
                                string[] array2 = array[m].Split('/');
                                if (array2[0].Length > 0)
                                {
                                    item.Position = list2[int.Parse(array2[0]) - 1];
                                }

                                if (array2[1].Length > 0)
                                {
                                    item.TextureCoordinate = list3[int.Parse(array2[1]) - 1];
                                }

                                list.Add(item);
                            }

                            break;
                        }
                    }
                }
            }

            if (mesh != null)
            {
                mesh.VertexCount = list.Count - mesh.VertexStart;
            }

            objModel.verts = list.ToArray();
            objModel.ResetVertexBuffer();
            return objModel;
        }
    }
}
