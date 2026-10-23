using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Content.Textures
{
    public partial class EverestAtlasEntry : AtlasEntry
    {
        public EverestAtlasEntry Parent;
        private AtlasData atlas;
        private bool hasOriginal;
        private VirtualTexture originalTexture;
        private IntRect originalClip;
        private Vector2 originalDrawOffset;
        private int originalWidth, originalHeight;
        private float scaleFix;

        public AtlasData Atlas
        {
            get => atlas ?? Parent?.Atlas;
            set => atlas = value;
        }

        public bool IsPacked => FrameWidth != Texture.Width || FrameHeight != Texture.Height;

        public float ScaleFix
        {
            get => Parent != null ? Parent.ScaleFix * scaleFix : scaleFix;
            set => scaleFix = value;
        }

        public override SourceTexture2DResource ReadTextureForSpriteBatch()
        {
            return Texture.TextureSafe;
        }

        public override float SourceDrawScale => ScaleFix;

        public EverestAtlasEntry()
        {
        }

        public EverestAtlasEntry(VirtualTexture texture) : base(texture)
        {
        }

        public EverestAtlasEntry(VirtualTexture texture, Vector2 drawOffset, int width, int height)
            : base(texture, drawOffset, width, height)
        {
        }

        public EverestAtlasEntry(EverestAtlasEntry parent, int x, int y, int width, int height)
            : base(parent, x, y, width, height)
        {
            Parent = parent;
        }

        public EverestAtlasEntry(EverestAtlasEntry parent, IntRect clip)
            : this(parent, clip.X, clip.Y, clip.Width, clip.Height)
        {
        }

        public EverestAtlasEntry(EverestAtlasEntry parent, string name, IntRect clip, Vector2 drawOffset, int width,
            int height)
            : base(parent, name, clip, drawOffset, width, height)
        {
            Parent = parent;
        }

        public EverestAtlasEntry(EverestAtlasEntry parent, string name, IntRect clip)
            : base(parent, name, clip)
        {
            Parent = parent;
        }

        protected override void SetUtil()
        {
            base.SetUtil();
            if (scaleFix <= 0f) scaleFix = 1f;
        }

        protected override AtlasEntry CreateSubtexture(int x, int y, int width, int height)
        {
            return new EverestAtlasEntry(this, x, y, width, height);
        }

        public override IntRect GetRelativeRect(int x, int y, int width, int height)
        {
            return SourceAtlasClipGeometry.RelativeRect(ClipRect, DrawOffset, x, y, width, height);
        }

        public void SetOverride(VirtualTexture texture, Vector2 drawOffset, int width, int height)
        {
            if (!hasOriginal)
            {
                originalTexture = Texture;
                originalClip = ClipRect;
                originalDrawOffset = DrawOffset;
                originalWidth = FrameWidth;
                originalHeight = FrameHeight;
                hasOriginal = true;
            }

            Texture = texture;
            SetClip(new(0, 0, texture.Width, texture.Height));
            OffsetX = drawOffset.X;
            OffsetY = drawOffset.Y;
            FrameWidth = width;
            FrameHeight = height;
            SetUtil();
        }

        // The asset stack must run before this restore in the installed UndoOverride body.
        // Its source content/metadata construction policy is a required successor.
        private void RestoreOriginalTexture()
        {
            if (!hasOriginal)
                return;
            Texture = originalTexture;
            originalTexture = null;
            SetClip(originalClip);
            OffsetX = originalDrawOffset.X;
            OffsetY = originalDrawOffset.Y;
            FrameWidth = originalWidth;
            FrameHeight = originalHeight;
            SetUtil();
            hasOriginal = false;
        }

        public override void DrawOutline(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            var scaleFix = ScaleFix;
            scale *= scaleFix;
            var clip = ClipRect;
            var adjustedOrigin = (origin - DrawOffset) / scaleFix;
            for (var x = -1; x <= 1; x++)
            for (var y = -1; y <= 1; y++)
                if (x != 0 || y != 0)
                    scope.Draw.SpriteBatch.Draw(Texture.TextureSafe,
                        position + new Vector2(x, y), clip, PackedColor.Black.PackedValue,
                        rotation, adjustedOrigin, scale,
                        (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                        (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
            scope.Draw.SpriteBatch.Draw(Texture.TextureSafe, position,
                clip, color.PackedValue, rotation, adjustedOrigin, scale,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public override void DrawOutline(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            var scaleFix = ScaleFix;
            scale *= scaleFix;
            var clip = ClipRect;
            var adjustedOrigin = (origin - DrawOffset) / scaleFix;
            for (var x = -1; x <= 1; x++)
            for (var y = -1; y <= 1; y++)
                if (x != 0 || y != 0)
                    scope.Draw.SpriteBatch.Draw(Texture.TextureSafe,
                        position + new Vector2(x, y), clip, PackedColor.Black.PackedValue,
                        rotation, adjustedOrigin, scale,
                        (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                        (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
            scope.Draw.SpriteBatch.Draw(Texture.TextureSafe, position,
                clip, color.PackedValue, rotation, adjustedOrigin, scale,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public override void DrawClip(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation, IntRect clip)
        {
            var scaleFix = ScaleFix;
            SourceAtlasClipDrawing.Draw(scope, this, position, origin,
                color, scale, rotation, clip, scaleFix);
        }
    }
}
