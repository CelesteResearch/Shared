using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Atlas
{
    /// <summary>A reusable view with installed atlas clipping and draw semantics.</summary>
    /// <remarks>Reset before drawing. Clip metadata snapshots the frame at Reset; draw scale remains live.</remarks>
    public sealed class ReusableAtlasSlice : AtlasEntry
    {
        private AtlasEntry source;

        public ReusableAtlasSlice Reset(AtlasEntry frame, int x, int y, int width, int height)
        {
            frame.GetSubtexture(x, y, width, height, this);
            source = frame;
            return this;
        }

        public override IntRect GetRelativeRect(int x, int y, int width, int height)
        {
            return SourceAtlasClipGeometry.RelativeRect(ClipRect, DrawOffset, x, y, width, height);
        }

        public override float SourceDrawScale => source.SourceDrawScale;

        public override SourceTexture2DResource ReadTextureForSpriteBatch()
        {
            return Texture.TextureSafe;
        }

        public override void DrawClip(ISourceDrawScope scope, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation, IntRect clip)
        {
            var scaleFix = SourceDrawScale;
            SourceAtlasClipDrawing.Draw(scope, this, position, origin, color, scale, rotation, clip, scaleFix);
        }
    }
}
