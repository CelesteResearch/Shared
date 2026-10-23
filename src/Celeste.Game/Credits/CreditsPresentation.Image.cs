using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Simulation;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Image : CreditNode
        {
            public global::Celeste.Graphics.Content.Atlas.AtlasData Atlas;

            public string ImagePath;

            public float BottomPadding;

            public float Rotation;

            public bool ScreenCenter;

            public Image(global::Celeste.Graphics.Content.Atlas.AtlasData atlas, string path,
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
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                var mTexture = Atlas[ImagePath];
                Vector2 position2 = position +
                                    new Vector2((float)mTexture.FrameWidth * (0.5f - alignment),
                                        (float)mTexture.FrameHeight * 0.5f) * scale;
                if (ScreenCenter)
                {
                    position2.X = 960f;
                }

                owner.DrawTexture(context, mTexture, position2, new Vector2(.5f, .5f), PackedColor.White, scale,
                    Rotation);
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                return ((float)Atlas[ImagePath].FrameHeight + BottomPadding) * scale;
            }
        }
    }
}
