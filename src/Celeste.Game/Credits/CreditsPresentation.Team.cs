using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class Team : CreditNode
        {
            public const float TeamScale = 1.4f;

            public static readonly PackedColor TeamColor = PackedColor.White;

            public readonly string Name;

            public readonly string[] Members;

            public readonly string Roles;

            public Team(string name, string[] members, params string[] roles)
            {
                Name = name;
                Members = members;
                Roles = string.Join(", ", roles);
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                owner.DrawText(context, false, Name, Floor(position), new(alignment, 0f),
                    Vector2.One * 1.8f * scale,
                    Role.NameColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.8f + 8f) * scale;
                for (var i = 0; i < Members.Length; i++)
                {
                    owner.DrawText(context, false, Members[i], Floor(position), new(alignment, 0f),
                        Vector2.One * 1.4f * scale, TeamColor, 2f, owner.Process.BorderColor);
                    position.Y += owner.LineHeight * 1.4f * scale;
                }

                owner.DrawText(context, false, Roles, Floor(position), new(alignment, 0f),
                    Vector2.One * 1f * scale,
                    Role.RolesColor, 2f, owner.Process.BorderColor);
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                return (owner.LineHeight * (1.8f + Members.Length * 1.4f + 1f) + 8f + 64f) * scale;
            }
        }
    }
}
