using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Timing;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Render(ISourceRenderContext context)
        {
            var num = index;
            if (UseKeyboardInput) index = -1;

            base.Render(context);
            index = num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void DrawOptionText(ISourceRenderContext context, string text, Vector2 at, Vector2 justify,
            Vector2 scale, bool selected, bool disabled = false)
        {
            if (UseKeyboardInput)
            {
                selected = false;
                disabled = true;
            }

            base.DrawOptionText(context, text, at, justify, scale, selected, disabled);
        }

        protected override PackedColor GetTextColor(bool selected)
        {
            if (selected)
            {
                if (!Environment.CoreSettings.AllowTextHighlight) return selectColorA;

                return !IntervalQueries.BetweenInterval(timer, 0.1f) ? selectColorB : selectColorA;
            }

            return unselectColor;
        }
    }
}
