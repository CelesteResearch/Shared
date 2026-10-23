using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using Celeste.Core.IO.Content;
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

        public List<Mesh> Meshes = [];

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
                Vertices = new(Device, typeof(SourceVertexPositionTexture), verts.Length,
                    SourceBufferUsage.None);
                Vertices.SetData(verts);
                return true;
            }

            return false;
        }

        public void ReassignVertices()
        {
            if (!ResetVertexBuffer()) Vertices.SetData(verts);
        }

        public void Draw(SourceEffect effect)
        {
            ResetVertexBuffer();
            Device.SetVertexBuffer(Vertices);
            foreach (var pass in effect.CurrentTechnique.Passes)
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
            IContentSource files = null)
        {
            Path.GetDirectoryName(filename);
            var objModel = ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);
            var list = new List<SourceVertexPositionTexture>();
            var list2 = new List<Vector3>();
            var list3 = new List<Vector2>();
            Mesh mesh = null;
            if (files == null ? File.Exists(filename + ".export") : files.FileExists(filename + ".export"))
            {
                using var binaryReader = new BinaryReader(files == null
                    ? File.OpenRead(filename + ".export")
                    : files.OpenTitleStream(filename + ".export"));
                var num = binaryReader.ReadInt32();
                for (var i = 0; i < num; i++)
                {
                    if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

                    mesh = new();
                    mesh.Name = binaryReader.ReadString();
                    mesh.VertexStart = list.Count;
                    objModel.Meshes.Add(mesh);
                    var num2 = binaryReader.ReadInt32();
                    for (var j = 0; j < num2; j++)
                    {
                        var x = binaryReader.ReadSingle();
                        var y = binaryReader.ReadSingle();
                        var z = binaryReader.ReadSingle();
                        list2.Add(new(x, y, z));
                    }

                    var num3 = binaryReader.ReadInt32();
                    for (var k = 0; k < num3; k++)
                    {
                        var x2 = binaryReader.ReadSingle();
                        var y2 = binaryReader.ReadSingle();
                        list3.Add(new(x2, y2));
                    }

                    var num4 = binaryReader.ReadInt32();
                    for (var l = 0; l < num4; l++)
                    {
                        var index = binaryReader.ReadInt32() - 1;
                        var index2 = binaryReader.ReadInt32() - 1;
                        list.Add(new()
                        {
                            Position = list2[index],
                            TextureCoordinate = list3[index2],
                        });
                    }
                }
            }
            else
            {
                using var streamReader = files == null
                    ? new StreamReader(filename)
                    : new StreamReader(files.OpenTitleStream(filename));
                string text;
                while ((text = streamReader.ReadLine()) != null)
                {
                    var array = text.Split(' ');
                    if (array.Length == 0) continue;

                    switch (array[0])
                    {
                        case "o":
                            if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

                            mesh = new();
                            mesh.Name = array[1];
                            mesh.VertexStart = list.Count;
                            objModel.Meshes.Add(mesh);
                            break;
                        case "v":
                        {
                            var item3 = new Vector3(Float(array[1]), Float(array[2]), Float(array[3]));
                            list2.Add(item3);
                            break;
                        }
                        case "vt":
                        {
                            var item2 = new Vector2(Float(array[1]), Float(array[2]));
                            list3.Add(item2);
                            break;
                        }
                        case "f":
                        {
                            for (var m = 1; m < Math.Min(4, array.Length); m++)
                            {
                                var item = default(SourceVertexPositionTexture);
                                var array2 = array[m].Split('/');
                                if (array2[0].Length > 0) item.Position = list2[int.Parse(array2[0]) - 1];

                                if (array2[1].Length > 0) item.TextureCoordinate = list3[int.Parse(array2[1]) - 1];

                                list.Add(item);
                            }

                            break;
                        }
                    }
                }
            }

            if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

            objModel.verts = [.. list];
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
                return ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);

            var objModel = ((ISourceObjModelEnvironment)environment).ObjModelPolicy.CreateModel(environment);
            var list = new List<SourceVertexPositionTexture>();
            var list2 = new List<Vector3>();
            var list3 = new List<Vector2>();
            Mesh mesh = null;
            if (fname.EndsWith(".export"))
            {
                using var binaryReader = new BinaryReader(stream);
                var num = binaryReader.ReadInt32();
                for (var i = 0; i < num; i++)
                {
                    if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

                    mesh = new();
                    mesh.Name = binaryReader.ReadString();
                    mesh.VertexStart = list.Count;
                    objModel.Meshes.Add(mesh);
                    var num2 = binaryReader.ReadInt32();
                    for (var j = 0; j < num2; j++)
                    {
                        var x = binaryReader.ReadSingle();
                        var y = binaryReader.ReadSingle();
                        var z = binaryReader.ReadSingle();
                        list2.Add(new(x, y, z));
                    }

                    var num3 = binaryReader.ReadInt32();
                    for (var k = 0; k < num3; k++)
                    {
                        var x2 = binaryReader.ReadSingle();
                        var y2 = binaryReader.ReadSingle();
                        list3.Add(new(x2, y2));
                    }

                    var num4 = binaryReader.ReadInt32();
                    for (var l = 0; l < num4; l++)
                    {
                        var index = binaryReader.ReadInt32() - 1;
                        var index2 = binaryReader.ReadInt32() - 1;
                        list.Add(new()
                        {
                            Position = list2[index],
                            TextureCoordinate = list3[index2],
                        });
                    }
                }
            }
            else
            {
                using var streamReader = new StreamReader(stream);
                string text;
                while ((text = streamReader.ReadLine()) != null)
                {
                    var array = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (array.Length == 0) continue;

                    switch (array[0])
                    {
                        case "o":
                            if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

                            mesh = new();
                            mesh.Name = array[1];
                            mesh.VertexStart = list.Count;
                            objModel.Meshes.Add(mesh);
                            break;
                        case "v":
                        {
                            var item3 = new Vector3(Float(array[1]), Float(array[2]), Float(array[3]));
                            list2.Add(item3);
                            break;
                        }
                        case "vt":
                        {
                            var item2 = new Vector2(Float(array[1]), Float(array[2]));
                            list3.Add(item2);
                            break;
                        }
                        case "f":
                        {
                            for (var m = 1; m < Math.Min(4, array.Length); m++)
                            {
                                var item = default(SourceVertexPositionTexture);
                                var array2 = array[m].Split('/');
                                if (array2[0].Length > 0) item.Position = list2[int.Parse(array2[0]) - 1];

                                if (array2[1].Length > 0) item.TextureCoordinate = list3[int.Parse(array2[1]) - 1];

                                list.Add(item);
                            }

                            break;
                        }
                    }
                }
            }

            if (mesh != null) mesh.VertexCount = list.Count - mesh.VertexStart;

            objModel.verts = [.. list];
            objModel.ResetVertexBuffer();
            return objModel;
        }
    }
}
