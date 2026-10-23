using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Effects.Outlines
{
    // One logical graphics owner; the caller disposes the cache with its content lifecycle.
    public sealed class CachedImageOutline : IDisposable
    {
        private readonly VirtualContent content;
        private readonly SourceGraphicsDevice device;
        private readonly Func<AtlasEntry, AtlasEntry> resolveAtlasTexture;
        private readonly Dictionary<(string, IntRect), CachedMask> masks = new();

        private readonly SourceRenderTargetBinding[][] bindings =
        {
            Array.Empty<SourceRenderTargetBinding>(), new SourceRenderTargetBinding[1],
            new SourceRenderTargetBinding[2], new SourceRenderTargetBinding[3], new SourceRenderTargetBinding[4]
        };

        private static readonly Vector2[] offsets =
        {
            -Vector2.UnitY, Vector2.UnitY, -Vector2.UnitX, Vector2.UnitX,
            -Vector2.One, Vector2.One, new(-1f, 1f), new(1f, -1f)
        };

        public CachedImageOutline(VirtualContent content, SourceGraphicsDevice device,
            Func<AtlasEntry, AtlasEntry> resolveAtlasTexture)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.device = device ?? throw new ArgumentNullException(nameof(device));
            this.resolveAtlasTexture =
                resolveAtlasTexture ?? throw new ArgumentNullException(nameof(resolveAtlasTexture));
        }

        public void Render(ISourceRenderContext context, SpriteImage image, PackedColor color,
            bool eightWay, Action beginGameplay)
        {
            var texture = image.Texture;
            var atlasTexture = resolveAtlasTexture(texture);
            var key = (atlasTexture.AtlasPath, texture.ClipRect);
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            if (!masks.TryGetValue(key, out var mask))
            {
                mask = new CachedMask(content.CreateRenderTarget("cached-image-outline",
                    atlasTexture.FrameWidth + 2 + (int)atlasTexture.DrawOffset.X,
                    atlasTexture.FrameHeight + 2 + (int)atlasTexture.DrawOffset.Y));
                try
                {
                    Capture(batch, atlasTexture, texture.ClipRect, mask, eightWay, beginGameplay);
                    masks.Add(key, mask);
                }
                catch
                {
                    mask.Target.Dispose();
                    throw;
                }
            }
            else if (!ReferenceEquals(mask.CapturedResource, mask.Target.Target))
            {
                // VirtualContent reload recreates targets. Rebuild the white mask once, not per frame.
                Capture(batch, atlasTexture, texture.ClipRect, mask, mask.EightWay, beginGameplay);
            }

            float scaleFix = texture.SourceDrawScale;
            batch.Draw(mask.Target.Target, image.RenderPosition, null, color.PackedValue, image.Rotation,
                (image.Origin + Vector2.One - texture.DrawOffset) / scaleFix,
                scaleFix, SourceSpriteEffects.None, 0f);
        }

        private void Capture(SourceSpriteBatch batch, AtlasEntry texture, IntRect clip,
            CachedMask mask, bool eightWay, Action beginGameplay)
        {
            var previous = bindings[device.GetRenderTargetsNoAllocEXT(null)];
            device.GetRenderTargetsNoAllocEXT(previous);
            batch.End();
            try
            {
                // These are SpriteBatch.Begin() defaults, not the gameplay point-sampled camera batch.
                batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                    SourceRasterizerState.CullCounterClockwise, null, Matrix4x4.Identity);
                device.SetRenderTarget(mask.Target.Target);
                device.Clear(PackedColor.Transparent);
                var resource = texture.ReadTextureForSpriteBatch();
                float scaleFix = texture.SourceDrawScale;
                for (int i = 0; i < (eightWay ? 8 : 4); i++)
                    batch.Draw(resource, Vector2.One + offsets[i], clip, PackedColor.White.PackedValue,
                        0f, Vector2.Zero, scaleFix, SourceSpriteEffects.None, 0f);
                batch.End();
                beginGameplay();
                device.SetRenderTargets(previous);
                mask.CapturedResource = mask.Target.Target;
                mask.EightWay = eightWay;
            }
            catch
            {
                if (batch.IsBatchOpen) batch.End();
                device.SetRenderTargets(previous);
                beginGameplay();
                throw;
            }
        }

        public static void RenderFast(ISourceRenderContext context, SpriteImage image, PackedColor color)
        {
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            var texture = image.Texture;
            var resource = texture.ReadTextureForSpriteBatch();
            float scaleFix = texture.SourceDrawScale;
            var origin = (image.Origin - texture.DrawOffset) / scaleFix;
            var scale = image.Scale * scaleFix;
            var position = image.RenderPosition;
            for (int i = 0; i < offsets.Length; i++)
                batch.Draw(resource, position + offsets[i], texture.ClipRect, color.PackedValue,
                    image.Rotation, origin, scale, SourceSpriteEffects.None, 0f);
        }

        public void Dispose()
        {
            foreach (var mask in masks.Values) mask.Target.Dispose();
            masks.Clear();
        }

        private sealed class CachedMask
        {
            public readonly VirtualRenderTarget Target;
            public SourceRenderTarget2DResource CapturedResource;
            public bool EightWay;

            public CachedMask(VirtualRenderTarget target) => Target = target;
        }
    }
}
