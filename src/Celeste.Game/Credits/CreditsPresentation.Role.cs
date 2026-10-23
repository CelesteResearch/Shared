using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;

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

            public readonly string Name;

            public readonly string Roles;

            public Role(string name, params string[] roles)
            {
                Name = name;
                Roles = string.Join(", ", roles);
            }

            public override void Render(ISourceRenderContext context,
                CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                owner.DrawText(context, false, Name, Floor(position), new(alignment, 0f),
                    Vector2.One * 1.8f * scale,
                    NameColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.8f + 8f) * scale;
                owner.DrawText(context, false, Roles, Floor(position), new(alignment, 0f),
                    Vector2.One * 1f * scale,
                    RolesColor, 2f, owner.Process.BorderColor);
            }

            public override float Height(CreditsPresentation owner,
                float scale = 1f)
            {
                return (owner.LineHeight * 2.8f + 8f + 64f) * scale;
            }
        }
    }
}
