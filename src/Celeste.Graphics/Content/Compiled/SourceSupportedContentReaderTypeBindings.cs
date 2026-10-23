using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceSupportedContentReaderTypeBindings
    {
        internal static IReadOnlyDictionary<string, Type> Types { get; } =
            new Dictionary<string, Type>(StringComparer.Ordinal)
            {
                ["Microsoft.Xna.Framework.Content.AlphaTestEffectReader"] = typeof(SourceAlphaTestEffectReader),
                ["Microsoft.Xna.Framework.Content.ArrayReader`1"] = typeof(SourceArrayReader<>),
                ["Microsoft.Xna.Framework.Content.BasicEffectReader"] = typeof(SourceBasicEffectReader),
                ["Microsoft.Xna.Framework.Content.BoundingBoxReader"] = typeof(SourceBoundingBoxReader),
                ["Microsoft.Xna.Framework.Content.BoundingFrustumReader"] = typeof(SourceBoundingFrustumReader),
                ["Microsoft.Xna.Framework.Content.BoundingSphereReader"] = typeof(SourceBoundingSphereReader),
                ["Microsoft.Xna.Framework.Content.ByteReader"] = typeof(SourceByteReader),
                ["Microsoft.Xna.Framework.Content.CharReader"] = typeof(SourceCharReader),
                ["Microsoft.Xna.Framework.Content.CurveReader"] = typeof(SourceCurveReader),
                ["Microsoft.Xna.Framework.Content.DateTimeReader"] = typeof(SourceDateTimeReader),
                ["Microsoft.Xna.Framework.Content.DecimalReader"] = typeof(SourceDecimalReader),
                ["Microsoft.Xna.Framework.Content.EffectMaterialReader"] = typeof(SourceEffectMaterialReader),
                ["Microsoft.Xna.Framework.Content.EffectReader"] = typeof(SourceEffectReader),
                ["Microsoft.Xna.Framework.Content.EnumReader`1"] = typeof(SourceEnumReader<>),
                ["Microsoft.Xna.Framework.Content.ExternalReferenceReader"] = typeof(SourceExternalReferenceReader),
                ["Microsoft.Xna.Framework.Content.IndexBufferReader"] = typeof(SourceIndexBufferReader),
                ["Microsoft.Xna.Framework.Content.Int32Reader"] = typeof(SourceInt32Reader),
                ["Microsoft.Xna.Framework.Content.ListReader`1"] = typeof(SourceListReader<>),
                ["Microsoft.Xna.Framework.Content.MatrixReader"] = typeof(SourceMatrixReader),
                ["Microsoft.Xna.Framework.Content.ModelReader"] = typeof(SourceModelReader),
                ["Microsoft.Xna.Framework.Content.NullableReader`1"] = typeof(SourceNullableReader<>),
                ["Microsoft.Xna.Framework.Content.RayReader"] = typeof(SourceRayReader),
                ["Microsoft.Xna.Framework.Content.RectangleReader"] = typeof(SourceRectangleReader),
                ["Microsoft.Xna.Framework.Content.SByteReader"] = typeof(SourceSByteReader),
                ["Microsoft.Xna.Framework.Content.SongReader"] = typeof(SourceSongReader),
                ["Microsoft.Xna.Framework.Content.SoundEffectReader"] = typeof(SourceSoundEffectReader),
                ["Microsoft.Xna.Framework.Content.SpriteFontReader"] = typeof(SourceSpriteFontReader),
                ["Microsoft.Xna.Framework.Content.StringReader"] = typeof(SourceStringReader),
                ["Microsoft.Xna.Framework.Content.Texture2DReader"] = typeof(SourceTexture2DReader),
                ["Microsoft.Xna.Framework.Content.Vector2Reader"] = typeof(SourceVector2Reader),
                ["Microsoft.Xna.Framework.Content.Vector3Reader"] = typeof(SourceVector3Reader),
                ["Microsoft.Xna.Framework.Content.Vector4Reader"] = typeof(SourceVector4Reader),
                ["Microsoft.Xna.Framework.Content.VertexBufferReader"] = typeof(SourceVertexBufferReader),
                ["Microsoft.Xna.Framework.Content.VertexDeclarationReader"] = typeof(SourceVertexDeclarationReader),
                ["Microsoft.Xna.Framework.Content.VideoReader"] = typeof(SourceVideoReader),
            };

        public static void Register(ISourceActualTypeCatalog catalog,
            string actualSourceFnaAssemblyIdentity, string actualSourceFnaAssemblySimpleName)
        {
            foreach (var entry in Types)
                catalog.RegisterActualType(entry.Key, entry.Key.Substring(entry.Key.LastIndexOf('.') + 1),
                    actualSourceFnaAssemblyIdentity, actualSourceFnaAssemblySimpleName, entry.Value);
        }
    }
}
