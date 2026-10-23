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
        private class Team : CreditNode
        {
            public const float TeamScale = 1.4f;

            public static readonly PackedColor TeamColor = PackedColor.White;

            public string Name;

            public string[] Members;

            public string Roles;

            public Team(string name, string[] members, params string[] roles)
            {
                Name = name;
                Members = members;
                Roles = string.Join(", ", roles);
            }

            public override void Render(ISourceRenderContext context,
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                owner.DrawText(context, false, Name, Floor(position), new Vector2(alignment, 0f),
                    Vector2.One * 1.8f * scale,
                    Role.NameColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.8f + 8f) * scale;
                for (int i = 0; i < Members.Length; i++)
                {
                    owner.DrawText(context, false, Members[i], Floor(position), new Vector2(alignment, 0f),
                        Vector2.One * 1.4f * scale, TeamColor, 2f, owner.Process.BorderColor);
                    position.Y += owner.LineHeight * 1.4f * scale;
                }

                owner.DrawText(context, false, Roles, Floor(position), new Vector2(alignment, 0f),
                    Vector2.One * 1f * scale,
                    Role.RolesColor, 2f, owner.Process.BorderColor);
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                return (owner.LineHeight * (1.8f + (float)Members.Length * 1.4f + 1f) + 8f + 64f) * scale;
            }
        }
    }
}
