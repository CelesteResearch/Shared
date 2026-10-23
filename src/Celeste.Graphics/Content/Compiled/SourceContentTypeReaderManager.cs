using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Celeste.Graphics.Rendering.Effects;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceContentTypeReaderManager
    {
        private Dictionary<Type, SourceContentTypeReader> contentReaders;

        private readonly SourceContentProcessState process;
        private object locker => process.ReaderLock;
        private string assemblyName => process.ReaderAssemblyName;
        private Dictionary<Type, SourceContentTypeReader> contentReadersCache => process.ReaderCache;
        private string[] nestedMark => process.ReaderNestedMark;
        private bool falseflag => process.ReaderFalseFlag;
        private Dictionary<string, Func<SourceContentTypeReader>> typeCreators => process.ReaderTypeCreators;

        internal SourceContentTypeReaderManager(SourceContentProcessState actualProcess)
        {
            process = actualProcess;
        }

        public SourceContentTypeReader GetTypeReader(Type targetType)
        {
            if (contentReaders.TryGetValue(targetType, out var value))
            {
                return value;
            }

            Type type = process.TypeIdentity.ResolveActualType(PrepareType(targetType.FullName));
            if (type != null && contentReaders.TryGetValue(type, out value))
            {
                return value;
            }

            return null;
        }

        internal SourceContentTypeReader[] LoadAssetReaders(SourceContentReader reader)
        {
            if (falseflag)
            {
                new SourceByteReader();
                new SourceSByteReader();
                new SourceDateTimeReader();
                new SourceDecimalReader();
                new SourceBoundingSphereReader();
                new SourceBoundingFrustumReader();
                new SourceRayReader();
                new SourceListReader<char>();
                new SourceListReader<IntRect>();
                new SourceArrayReader<IntRect>();
                new SourceListReader<Vector3>();
                new SourceListReader<SourceStringReader>();
                new SourceListReader<int>();
                new SourceSpriteFontReader();
                new SourceTexture2DReader();
                new SourceCharReader();
                new SourceRectangleReader();
                new SourceStringReader();
                new SourceVector2Reader();
                new SourceVector3Reader();
                new SourceVector4Reader();
                new SourceCurveReader();
                new SourceIndexBufferReader();
                new SourceBoundingBoxReader();
                new SourceMatrixReader();
                new SourceBasicEffectReader();
                new SourceVertexBufferReader();
                new SourceAlphaTestEffectReader();
                new SourceEnumReader<SourceSpriteEffects>();
                new SourceArrayReader<float>();
                new SourceArrayReader<Vector2>();
                new SourceListReader<Vector2>();
                new SourceArrayReader<Matrix4x4>();
                new SourceEnumReader<SourceBlendFactor>();
                new SourceNullableReader<IntRect>();
                new SourceEffectMaterialReader();
                new SourceExternalReferenceReader();
                new SourceSoundEffectReader();
                new SourceSongReader();
                new SourceModelReader();
                new SourceInt32Reader();
            }

            int num = reader.Read7BitEncodedInt();
            SourceContentTypeReader[] array = new SourceContentTypeReader[num];
            BitArray bitArray = new BitArray(num);
            contentReaders = new Dictionary<Type, SourceContentTypeReader>(num);
            lock (locker)
            {
                for (int i = 0; i < num; i++)
                {
                    string text = reader.ReadString();
                    if (typeCreators.TryGetValue(text, out var value))
                    {
                        array[i] = value();
                        bitArray[i] = true;
                    }
                    else
                    {
                        string type = text;
                        type = PrepareType(type);
                        Type type2 = process.TypeIdentity.ResolveActualType(type);
                        if (!(type2 != null))
                        {
                            throw new SourceContentLoadException(
                                "Could not find ContentTypeReader Type. Please ensure the name of the Assembly that contains the Type matches the assembly in the full type name: " +
                                text + " (" + type + ")");
                        }

                        if (!contentReadersCache.TryGetValue(type2, out var value2))
                        {
                            try
                            {
                                value2 =
                                    SourceContentTypeReflection.GetDefaultConstructor(type2).Invoke(null) as
                                        SourceContentTypeReader;
                            }
                            catch (TargetInvocationException innerException)
                            {
                                throw new InvalidOperationException(
                                    "Failed to get default constructor for ContentTypeReader. To work around, add a creation function to ContentTypeReaderManager.AddTypeCreator() with the following failed type string: " +
                                    text, innerException);
                            }

                            bitArray[i] = true;
                            contentReadersCache.Add(type2, value2);
                        }

                        array[i] = value2;
                    }

                    if (array[i].TargetType != null)
                    {
                        contentReaders.Add(array[i].TargetType, array[i]);
                    }

                    reader.ReadInt32();
                }

                for (int j = 0; j < array.Length; j++)
                {
                    if (bitArray.Get(j))
                    {
                        array[j].Initialize(this);
                    }
                }

                return array;
            }
        }

        /// <summary>
        /// Adds the type creator.
        /// </summary>
        /// <param name="typeString">
        /// Type string.
        /// </param>
        /// <param name="createFunction">
        /// Create function.
        /// </param>
        internal void AddTypeCreator(string typeString, Func<SourceContentTypeReader> createFunction)
        {
            if (!typeCreators.ContainsKey(typeString))
            {
                typeCreators.Add(typeString, createFunction);
            }
        }

        internal void ClearTypeCreators()
        {
            typeCreators.Clear();
        }

        /// <summary>
        /// Removes Version, Culture and PublicKeyToken from a type string.
        /// </summary>
        /// <remarks>
        /// Supports multiple generic types (e.g. Dictionary&lt;TKey,TValue&gt;)
        /// and nested generic types (e.g. List&lt;List&lt;int&gt;&gt;).
        /// </remarks>
        /// <param name="type">
        /// A <see cref="T:System.String" />
        /// </param>
        /// <returns>
        /// A <see cref="T:System.String" />
        /// </returns>
        internal string PrepareType(string type)
        {
            int num = type.Split(nestedMark, StringSplitOptions.None).Length - 1;
            string text = type;
            for (int i = 0; i < num; i++)
            {
                text = Regex.Replace(text, "\\[(.+?), Version=.+?\\]", "[$1]");
            }

            if (text.Contains("PublicKeyToken"))
            {
                text = Regex.Replace(text, "(.+?), Version=.+?$", "$1");
            }

            text = text.Replace(", Microsoft.Xna.Framework.Graphics", $", {assemblyName}");
            text = text.Replace(", Microsoft.Xna.Framework.Video", $", {assemblyName}");
            text = text.Replace(", Microsoft.Xna.Framework", $", {assemblyName}");
            return text.Replace(", MonoGame.Framework", $", {assemblyName}");
        }
    }
}
