using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private abstract class CreditNode
        {
            public abstract void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f);

            public abstract float Height(CreditsPresentation owner,
                float scale = 1f);
        }
    }
}
