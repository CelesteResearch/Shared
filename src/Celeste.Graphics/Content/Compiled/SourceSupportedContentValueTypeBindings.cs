using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Audio.Media;
using Celeste.Audio.Sound;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Geometry.Intersections;
using Celeste.Core.Mathematics.Curves;
using Celeste.Core.Reflection;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Media;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Models;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceSupportedContentValueTypeBindings
    {
        internal static IReadOnlyDictionary<string, Type> Types { get; } =
            new Dictionary<string, Type>(StringComparer.Ordinal)
            {
                ["Microsoft.Xna.Framework.Rectangle"] = typeof(IntRect),
                ["Microsoft.Xna.Framework.Vector2"] = typeof(Vector2),
                ["Microsoft.Xna.Framework.Vector3"] = typeof(Vector3),
                ["Microsoft.Xna.Framework.Vector4"] = typeof(Vector4),
                ["Microsoft.Xna.Framework.Matrix"] = typeof(Matrix4x4),
                ["Microsoft.Xna.Framework.Quaternion"] = typeof(Quaternion),
                ["Microsoft.Xna.Framework.Color"] = typeof(PackedColor),
                ["Microsoft.Xna.Framework.BoundingBox"] =
                    typeof(BoundingBox),
                ["Microsoft.Xna.Framework.BoundingSphere"] =
                    typeof(BoundingSphere),
                ["Microsoft.Xna.Framework.BoundingFrustum"] =
                    typeof(BoundingFrustum),
                ["Microsoft.Xna.Framework.Ray"] = typeof(Ray),
                ["Microsoft.Xna.Framework.Graphics.SpriteEffects"] =
                    typeof(SourceSpriteEffects),
                ["Microsoft.Xna.Framework.Graphics.Blend"] = typeof(SourceBlendFactor),
                ["Microsoft.Xna.Framework.Curve"] = typeof(SourceCurve),
                ["Microsoft.Xna.Framework.Graphics.SpriteFont"] =
                    typeof(SourceSpriteFont),
                ["Microsoft.Xna.Framework.Graphics.Texture2D"] =
                    typeof(SourceTexture2DResource),
                ["Microsoft.Xna.Framework.Graphics.Model"] =
                    typeof(SourceModel),
                ["Microsoft.Xna.Framework.Graphics.Effect"] =
                    typeof(SourceEffect),
                ["Microsoft.Xna.Framework.Graphics.BasicEffect"] =
                    typeof(SourceBasicEffect),
                ["Microsoft.Xna.Framework.Graphics.AlphaTestEffect"] =
                    typeof(SourceAlphaTestEffect),
                ["Microsoft.Xna.Framework.Graphics.EffectMaterial"] =
                    typeof(SourceEffectMaterial),
                ["Microsoft.Xna.Framework.Graphics.VertexBuffer"] =
                    typeof(SourceVertexBuffer),
                ["Microsoft.Xna.Framework.Graphics.IndexBuffer"] =
                    typeof(SourceIndexBuffer),
                ["Microsoft.Xna.Framework.Graphics.VertexDeclaration"] =
                    typeof(SourceVertexDeclaration),
                ["Microsoft.Xna.Framework.Audio.SoundEffect"] = typeof(SourceSoundEffect),
                ["Microsoft.Xna.Framework.Media.Song"] = typeof(SourceSong),
                ["Microsoft.Xna.Framework.Media.Video"] = typeof(SourceVideo),
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
