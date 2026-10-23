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
        private class ImageRow : CreditNode
        {
            private Image[] images;

            public ImageRow(params Image[] images)
            {
                this.images = images;
            }

            public override void Render(ISourceRenderContext context,
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                float num = Height(owner, scale);
                float num2 = 0f;
                Image[] array = images;
                foreach (Image image in array)
                {
                    num2 += (float)(image.Atlas[image.ImagePath].FrameWidth + 32) * scale;
                }

                num2 -= 32f * scale;
                Vector2 vector = position - new Vector2(alignment * num2, 0f);
                array = images;
                foreach (Image image2 in array)
                {
                    image2.Render(context, owner, vector + new Vector2(0f, (num - image2.Height(owner, scale)) / 2f),
                        0f, scale);
                    vector.X += (float)(image2.Atlas[image2.ImagePath].FrameWidth + 32) * scale;
                }
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                float num = 0f;
                Image[] array = images;
                foreach (Image image in array)
                {
                    if (image.Height(owner, scale) > num)
                    {
                        num = image.Height(owner, scale);
                    }
                }

                return num;
            }
        }
    }
}
