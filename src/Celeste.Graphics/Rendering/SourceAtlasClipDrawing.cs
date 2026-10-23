using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Graphics.Rendering
{
    public static class SourceAtlasClipDrawing
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Draw(ISourceDrawScope scope, AtlasEntry texture, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation, IntRect clip, float scaleFix)
        {
            scope.Draw.SpriteBatch.Draw(texture.Texture.TextureSafe, position, texture.GetRelativeRect(clip),
                color.PackedValue, rotation, (origin - texture.DrawOffset) / scaleFix,
                scale * scaleFix, SourceSpriteEffects.None, 0f);
        }
    }
}
