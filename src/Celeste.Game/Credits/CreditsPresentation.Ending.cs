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
        private class Ending : CreditNode
        {
            public string Text;

            public bool Spacing;

            public Ending(string text, bool spacing)
            {
                Text = text;
                Spacing = spacing;
            }

            public override void Render(ISourceRenderContext context,
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                if (Spacing)
                {
                    position.Y += 540f;
                }
                else
                {
                    position.Y += owner.ActiveFont.LineHeight * 1.5f * scale * 0.5f;
                }

                owner.DrawText(context, true, Text, new Vector2(960f, position.Y), new Vector2(0.5f, 0.5f),
                    Vector2.One * 1.5f * scale, PackedColor.White, 2f, owner.Process.BorderColor);
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                if (Spacing)
                {
                    return 540f;
                }

                return owner.ActiveFont.LineHeight * 1.5f * scale;
            }
        }
    }
}
