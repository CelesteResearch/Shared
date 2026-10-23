using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class ImageRow : CreditNode
        {
            private readonly Image[] images;

            public ImageRow(params Image[] images)
            {
                this.images = images;
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                var num = Height(owner, scale);
                var num2 = 0f;
                var array = images;
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var image in array) num2 += (image.Atlas[image.ImagePath].FrameWidth + 32) * scale;

                num2 -= 32f * scale;
                var vector = position - new Vector2(alignment * num2, 0f);
                array = images;
                foreach (var image2 in array)
                {
                    image2.Render(context, owner, vector + new Vector2(0f, (num - image2.Height(owner, scale)) / 2f),
                        0f, scale);
                    vector.X += (image2.Atlas[image2.ImagePath].FrameWidth + 32) * scale;
                }
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                var num = 0f;
                var array = images;
                foreach (var image in array)
                    if (image.Height(owner, scale) > num)
                        num = image.Height(owner, scale);

                return num;
            }
        }
    }
}
