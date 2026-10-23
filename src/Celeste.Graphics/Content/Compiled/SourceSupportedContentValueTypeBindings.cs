using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;

namespace Celeste.Graphics.Content.Compiled
{
    public static class SourceSupportedContentValueTypeBindings
    {
        internal static IReadOnlyDictionary<string, Type> Types { get; } =
            new Dictionary<string, Type>(StringComparer.Ordinal)
            {
                ["Microsoft.Xna.Framework.Rectangle"] = typeof(global::Celeste.Core.Geometry.IntRect),
                ["Microsoft.Xna.Framework.Vector2"] = typeof(global::System.Numerics.Vector2),
                ["Microsoft.Xna.Framework.Vector3"] = typeof(global::System.Numerics.Vector3),
                ["Microsoft.Xna.Framework.Vector4"] = typeof(global::System.Numerics.Vector4),
                ["Microsoft.Xna.Framework.Matrix"] = typeof(global::System.Numerics.Matrix4x4),
                ["Microsoft.Xna.Framework.Quaternion"] = typeof(global::System.Numerics.Quaternion),
                ["Microsoft.Xna.Framework.Color"] = typeof(global::Celeste.Core.Display.PackedColor),
                ["Microsoft.Xna.Framework.BoundingBox"] =
                    typeof(global::Celeste.Core.Geometry.Intersections.BoundingBox),
                ["Microsoft.Xna.Framework.BoundingSphere"] =
                    typeof(global::Celeste.Core.Geometry.Intersections.BoundingSphere),
                ["Microsoft.Xna.Framework.BoundingFrustum"] =
                    typeof(global::Celeste.Core.Geometry.Intersections.BoundingFrustum),
                ["Microsoft.Xna.Framework.Ray"] = typeof(global::Celeste.Core.Geometry.Intersections.Ray),
                ["Microsoft.Xna.Framework.Graphics.SpriteEffects"] =
                    typeof(global::Celeste.Core.Rendering.States.SourceSpriteEffects),
                ["Microsoft.Xna.Framework.Graphics.Blend"] = typeof(global::Celeste.Core.Rendering.SourceBlendFactor),
                ["Microsoft.Xna.Framework.Curve"] = typeof(global::Celeste.Core.Mathematics.Curves.SourceCurve),
                ["Microsoft.Xna.Framework.Graphics.SpriteFont"] =
                    typeof(global::Celeste.Graphics.Text.Fonts.SourceSpriteFont),
                ["Microsoft.Xna.Framework.Graphics.Texture2D"] =
                    typeof(global::Celeste.Graphics.Rendering.Textures.SourceTexture2DResource),
                ["Microsoft.Xna.Framework.Graphics.Model"] =
                    typeof(global::Celeste.Graphics.Rendering.Models.SourceModel),
                ["Microsoft.Xna.Framework.Graphics.Effect"] =
                    typeof(global::Celeste.Graphics.Rendering.Effects.SourceEffect),
                ["Microsoft.Xna.Framework.Graphics.BasicEffect"] =
                    typeof(global::Celeste.Graphics.Rendering.Effects.SourceBasicEffect),
                ["Microsoft.Xna.Framework.Graphics.AlphaTestEffect"] =
                    typeof(global::Celeste.Graphics.Rendering.Effects.SourceAlphaTestEffect),
                ["Microsoft.Xna.Framework.Graphics.EffectMaterial"] =
                    typeof(global::Celeste.Graphics.Rendering.Effects.SourceEffectMaterial),
                ["Microsoft.Xna.Framework.Graphics.VertexBuffer"] =
                    typeof(global::Celeste.Graphics.Rendering.Buffers.SourceVertexBuffer),
                ["Microsoft.Xna.Framework.Graphics.IndexBuffer"] =
                    typeof(global::Celeste.Graphics.Rendering.Buffers.SourceIndexBuffer),
                ["Microsoft.Xna.Framework.Graphics.VertexDeclaration"] =
                    typeof(global::Celeste.Graphics.Rendering.Vertices.SourceVertexDeclaration),
                ["Microsoft.Xna.Framework.Audio.SoundEffect"] = typeof(global::Celeste.Audio.Sound.SourceSoundEffect),
                ["Microsoft.Xna.Framework.Media.Song"] = typeof(global::Celeste.Audio.Media.SourceSong),
                ["Microsoft.Xna.Framework.Media.Video"] = typeof(global::Celeste.Graphics.Media.SourceVideo),
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
