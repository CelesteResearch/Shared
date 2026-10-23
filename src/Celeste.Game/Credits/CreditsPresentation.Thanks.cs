using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Thanks : CreditNode
        {
            public const float TitleScale = 1.4f;

            public const float CreditsScale = 1.15f;

            public const float Spacing = 8f;

            public readonly PackedColor TitleColor = PackedColor.White;

            public readonly PackedColor CreditsColor = PackedColor.White * .8f;

            public readonly int TopPadding;

            public readonly string Title;

            public readonly string[] Credits;

            private readonly string[] linkedImages;

            public Thanks(string title, params string[] to)
                : this(0, title, to)
            {
            }

            public Thanks(int topPadding, string title, params string[] to)
            {
                TopPadding = topPadding;
                Title = title;
                Credits = to;
                linkedImages = new string[Credits.Length];
                for (var i = 0; i < linkedImages.Length; i++)
                {
                    linkedImages[i] = null;
                    if (Credits[i].StartsWith("image:")) linkedImages[i] = Credits[i].Substring(6);
                }
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                position.Y += TopPadding * scale;
                owner.DrawText(context, false, Title, Floor(position), new(alignment, 0f),
                    Vector2.One * 1.4f * scale,
                    TitleColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.4f + 8f) * scale;
                for (var i = 0; i < Credits.Length; i++)
                    if (linkedImages[i] != null)
                    {
                        var mTexture = owner.Graphics.GuiAtlas[linkedImages[i]];
                        owner.DrawTexture(context, mTexture, Floor(position) + new Vector2(0f, -2f),
                            new(alignment, 0f),
                            owner.Process.BorderColor, 1.15f * scale, 0f);
                        owner.DrawTexture(context, mTexture, Floor(position) + new Vector2(0f, 2f),
                            new(alignment, 0f),
                            owner.Process.BorderColor, 1.15f * scale, 0f);
                        owner.DrawTexture(context, mTexture, Floor(position) + new Vector2(-2f, 0f),
                            new(alignment, 0f),
                            owner.Process.BorderColor, 1.15f * scale, 0f);
                        owner.DrawTexture(context, mTexture, Floor(position) + new Vector2(2f, 0f),
                            new(alignment, 0f),
                            owner.Process.BorderColor, 1.15f * scale, 0f);
                        owner.DrawTexture(context, mTexture, Floor(position), new(alignment, 0f), CreditsColor,
                            1.15f * scale, 0f);
                        position.Y += mTexture.FrameHeight * 1.15f * scale;
                    }
                    else
                    {
                        owner.DrawText(context, false, Credits[i], Floor(position), new(alignment, 0f),
                            Vector2.One * 1.15f * scale, CreditsColor, 2f, owner.Process.BorderColor);
                        position.Y += owner.LineHeight * 1.15f * scale;
                    }
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                return (owner.LineHeight * (1.4f + Credits.Length * 1.15f) + (Credits.Length != 0 ? 8f : 0f) +
                        TopPadding) * scale;
            }
        }
    }
}
