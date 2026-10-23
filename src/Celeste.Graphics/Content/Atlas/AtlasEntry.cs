using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Display;
using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Graphics.Content.Atlas
{
    public class AtlasEntry
    {
        public string Name, Page;
        public string AtlasPath;
        public int X, Y, Width, Height, FrameWidth, FrameHeight;
        public float OffsetX, OffsetY;
        public VirtualTexture Texture { get; protected set; }
        public IntRect ClipRect => new(X, Y, Width, Height);
        public Vector2 DrawOffset => new(OffsetX, OffsetY);
        public Vector2 Center { get; private set; }
        public float LeftUV { get; private set; }
        public float RightUV { get; private set; }
        public float TopUV { get; private set; }
        public float BottomUV { get; private set; }
        public virtual float SourceDrawScale => 1f;

        public virtual global::Celeste.Graphics.Rendering.Textures.SourceTexture2DResource ReadTextureForSpriteBatch()
            => Texture.TextureSafe;

        public int TotalPixels => FrameWidth * FrameHeight;

        public AtlasEntry()
        {
        }

        public AtlasEntry(VirtualTexture texture)
        {
            Texture = texture;
            AtlasPath = null;
            Page = texture.Path;
            X = 0;
            Y = 0;
            Width = texture.Width;
            Height = texture.Height;
            OffsetX = 0;
            OffsetY = 0;
            FrameWidth = Width;
            FrameHeight = Height;
            SetUtil();
        }

        public AtlasEntry(AtlasEntry parent, int x, int y, int width, int height)
        {
            Texture = parent.Texture;
            AtlasPath = null;
            Page = parent.Page;
            SetClip(parent.GetRelativeRect(x, y, width, height));
            OffsetX = -Math.Min((float)x - parent.OffsetX, 0f);
            OffsetY = -Math.Min((float)y - parent.OffsetY, 0f);
            FrameWidth = width;
            FrameHeight = height;
            SetUtil();
        }

        public AtlasEntry(AtlasEntry parent, IntRect clip) : this(parent, clip.X, clip.Y, clip.Width, clip.Height)
        {
        }

        public AtlasEntry(AtlasEntry parent, string name, IntRect clip, Vector2 drawOffset, int frameWidth,
            int frameHeight)
        {
            Texture = parent.Texture;
            Name = name;
            AtlasPath = name;
            Page = parent.Page;
            SetClip(parent.GetRelativeRect(clip));
            OffsetX = drawOffset.X;
            OffsetY = drawOffset.Y;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            SetUtil();
        }

        public AtlasEntry(AtlasEntry parent, string name, IntRect clip) : this(parent, clip)
        {
            Name = name;
            AtlasPath = name;
        }

        public AtlasEntry(VirtualTexture texture, Vector2 drawOffset, int frameWidth, int frameHeight)
        {
            Texture = texture;
            Page = texture.Path;
            X = 0;
            Y = 0;
            Width = texture.Width;
            Height = texture.Height;
            OffsetX = drawOffset.X;
            OffsetY = drawOffset.Y;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            SetUtil();
        }

        protected void SetClip(IntRect clip)
        {
            X = clip.X;
            Y = clip.Y;
            Width = clip.Width;
            Height = clip.Height;
        }

        protected virtual void SetUtil()
        {
            Center = new Vector2(FrameWidth, FrameHeight) * .5f;
            LeftUV = (float)X / Texture.Width;
            RightUV = (float)(X + Width) / Texture.Width;
            TopUV = (float)Y / Texture.Height;
            BottomUV = (float)(Y + Height) / Texture.Height;
        }

        public void Unload()
        {
            Texture.Dispose();
            Texture = null;
        }

        public AtlasEntry GetSubtexture(int x, int y, int width, int height, AtlasEntry applyTo = null)
        {
            if (applyTo == null) return CreateSubtexture(x, y, width, height);
            applyTo.Texture = Texture;
            applyTo.AtlasPath = null;
            applyTo.Page = Page;
            applyTo.SetClip(GetRelativeRect(x, y, width, height));
            applyTo.OffsetX = -Math.Min((float)x - OffsetX, 0f);
            applyTo.OffsetY = -Math.Min((float)y - OffsetY, 0f);
            applyTo.FrameWidth = width;
            applyTo.FrameHeight = height;
            applyTo.SetUtil();
            return applyTo;
        }

        protected virtual AtlasEntry CreateSubtexture(int x, int y, int width, int height) =>
            new(this, x, y, width, height);

        public AtlasEntry GetSubtexture(IntRect clip) => CreateSubtexture(clip.X, clip.Y, clip.Width, clip.Height);

        public IntRect GetRelativeRect(IntRect clip) => GetRelativeRect(clip.X, clip.Y, clip.Width, clip.Height);

        public virtual IntRect GetRelativeRect(int x, int y, int width, int height)
        {
            int px = (int)((float)X - OffsetX + x);
            int py = (int)((float)Y - OffsetY + y);
            int sx = (int)Math.Max(X, Math.Min((float)px, X + Width));
            int sy = (int)Math.Max(Y, Math.Min((float)py, Y + Height));
            return new IntRect(sx, sy, Math.Max(0, Math.Min(px + width, X + Width) - sx),
                Math.Max(0, Math.Min(py + height, Y + Height) - sy));
        }

        public override string ToString()
        {
            if (AtlasPath != null) return AtlasPath;
            if (Texture.Path != null) return Texture.Path;
            return "Texture [" + Texture.Width + ", " + Texture.Height + "]";
        }

        public virtual void DrawOutline(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            var resource = ReadTextureForSpriteBatch();
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                if (x != 0 || y != 0)
                    scope.Draw.SpriteBatch.Draw(resource,
                        position + new Vector2(x, y), ClipRect, PackedColor.Black.PackedValue,
                        rotation, origin - DrawOffset, scale,
                        (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                        (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
            scope.Draw.SpriteBatch.Draw(resource, position,
                ClipRect, color.PackedValue, rotation, origin - DrawOffset, scale,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public virtual void DrawOutline(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            var resource = ReadTextureForSpriteBatch();
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                if (x != 0 || y != 0)
                    scope.Draw.SpriteBatch.Draw(resource,
                        position + new Vector2(x, y), ClipRect, PackedColor.Black.PackedValue,
                        rotation, origin - DrawOffset, scale,
                        (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                        (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
            scope.Draw.SpriteBatch.Draw(resource, position,
                ClipRect, color.PackedValue, rotation, origin - DrawOffset, scale,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public virtual void DrawClip(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation, IntRect clip)
        {
            scope.Draw.SpriteBatch.Draw(ReadTextureForSpriteBatch(), position, GetRelativeRect(clip),
                color.PackedValue, rotation, origin - DrawOffset, scale, SourceSpriteEffects.None, 0f);
        }
    }
}
