using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Ending : CreditNode
        {
            public readonly string Text;

            public readonly bool Spacing;

            public Ending(string text, bool spacing)
            {
                Text = text;
                Spacing = spacing;
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                if (Spacing)
                    position.Y += 540f;
                else
                    position.Y += owner.ActiveFont.LineHeight * 1.5f * scale * 0.5f;

                owner.DrawText(context, true, Text, new(960f, position.Y), new(0.5f, 0.5f),
                    Vector2.One * 1.5f * scale, PackedColor.White, 2f, owner.Process.BorderColor);
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                if (Spacing) return 540f;

                return owner.ActiveFont.LineHeight * 1.5f * scale;
            }
        }
    }
}
