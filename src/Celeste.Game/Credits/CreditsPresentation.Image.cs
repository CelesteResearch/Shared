using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Image : CreditNode
        {
            public readonly AtlasData Atlas;

            public readonly string ImagePath;

            public readonly float BottomPadding;

            public readonly float Rotation;

            public readonly bool ScreenCenter;

            public Image(AtlasData atlas, string path,
                float bottomPadding = 0f, float rotation = 0f,
                bool screenCenter = false)
            {
                Atlas = atlas;
                ImagePath = path;
                BottomPadding = bottomPadding;
                Rotation = rotation;
                ScreenCenter = screenCenter;
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                var mTexture = Atlas[ImagePath];
                var position2 = position +
                                new Vector2(mTexture.FrameWidth * (0.5f - alignment),
                                    mTexture.FrameHeight * 0.5f) * scale;
                if (ScreenCenter) position2.X = 960f;

                owner.DrawTexture(context, mTexture, position2, new(.5f, .5f), PackedColor.White, scale,
                    Rotation);
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                return (Atlas[ImagePath].FrameHeight + BottomPadding) * scale;
            }
        }
    }
}
