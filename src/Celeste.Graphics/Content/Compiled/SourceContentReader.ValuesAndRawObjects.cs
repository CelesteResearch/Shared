using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        public T ReadExternalReference<T>()
        {
            string text = ReadString();
            if (!string.IsNullOrEmpty(text))
            {
                return contentManager.Load<T>(SourceContentFileHelpers.ResolveRelativePath(assetName, text));
            }

            return default(T);
        }

        public Matrix4x4 ReadMatrix()
        {
            return new Matrix4x4
            {
                M11 = ReadSingle(),
                M12 = ReadSingle(),
                M13 = ReadSingle(),
                M14 = ReadSingle(),
                M21 = ReadSingle(),
                M22 = ReadSingle(),
                M23 = ReadSingle(),
                M24 = ReadSingle(),
                M31 = ReadSingle(),
                M32 = ReadSingle(),
                M33 = ReadSingle(),
                M34 = ReadSingle(),
                M41 = ReadSingle(),
                M42 = ReadSingle(),
                M43 = ReadSingle(),
                M44 = ReadSingle()
            };
        }

        public Quaternion ReadQuaternion()
        {
            return new Quaternion
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle(),
                W = ReadSingle()
            };
        }

        public T ReadRawObject<T>()
        {
            return ReadRawObject(default(T));
        }

        public T ReadRawObject<T>(SourceContentTypeReader typeReader)
        {
            return ReadRawObject(typeReader, default(T));
        }

        public T ReadRawObject<T>(T existingInstance)
        {
            Type typeFromHandle = typeof(T);
            SourceContentTypeReader[] array = typeReaders;
            foreach (SourceContentTypeReader contentTypeReader in array)
            {
                if (contentTypeReader.TargetType == typeFromHandle)
                {
                    return ReadRawObject(contentTypeReader, existingInstance);
                }
            }

            throw new NotSupportedException();
        }

        public T ReadRawObject<T>(SourceContentTypeReader typeReader, T existingInstance)
        {
            return (T)typeReader.Read(this, existingInstance);
        }

        public Vector2 ReadVector2()
        {
            return new Vector2
            {
                X = ReadSingle(),
                Y = ReadSingle()
            };
        }

        public Vector3 ReadVector3()
        {
            return new Vector3
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle()
            };
        }

        public Vector4 ReadVector4()
        {
            return new Vector4
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle(),
                W = ReadSingle()
            };
        }

        public PackedColor ReadColor()
        {
            return new PackedColor
            {
                R = ReadByte(),
                G = ReadByte(),
                B = ReadByte(),
                A = ReadByte()
            };
        }
    }
}
