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
        private class Role : CreditNode
        {
            public const float NameScale = 1.8f;

            public const float RolesScale = 1f;

            public const float Spacing = 8f;

            public const float BottomSpacing = 64f;

            public static readonly PackedColor NameColor = PackedColor.White;

            public static readonly PackedColor RolesColor = PackedColor.White * .8f;

            public string Name;

            public string Roles;

            public Role(string name, params string[] roles)
            {
                Name = name;
                Roles = string.Join(", ", roles);
            }

            public override void Render(ISourceRenderContext context,
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                owner.DrawText(context, false, Name, Floor(position), new Vector2(alignment, 0f),
                    Vector2.One * 1.8f * scale,
                    NameColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.8f + 8f) * scale;
                owner.DrawText(context, false, Roles, Floor(position), new Vector2(alignment, 0f),
                    Vector2.One * 1f * scale,
                    RolesColor, 2f, owner.Process.BorderColor);
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                return (owner.LineHeight * 2.8f + 8f + 64f) * scale;
            }
        }
    }
}
