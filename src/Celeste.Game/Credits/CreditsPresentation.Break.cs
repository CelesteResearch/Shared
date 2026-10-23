using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Break : CreditNode
        {
            public readonly float Size;

            public Break(float size = 64f)
            {
                Size = size;
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                return Size * scale;
            }
        }
    }
}
