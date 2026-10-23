using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Render(ISourceRenderContext context)
        {
            int num = index;
            if (UseKeyboardInput)
            {
                index = -1;
            }

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
                if (!Environment.CoreSettings.AllowTextHighlight)
                {
                    return selectColorA;
                }

                if (!IntervalQueries.BetweenInterval(timer, 0.1f))
                {
                    return selectColorB;
                }

                return selectColorA;
            }

            return unselectColor;
        }
    }
}
