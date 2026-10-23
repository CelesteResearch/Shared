using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public sealed partial class PlayerHair : ISourceComponentRender
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public PackedColor GetHairColor(int index)
        {
            return Color * Alpha;
        }

        public override void Render(ISourceRenderContext ctx)
        {
            if (!Sprite.HasHair) return;
            var border = Border * Alpha;
            var color = useHairSegmentColorGetter ? default : Color * Alpha;
            if (DrawPlayerSpriteOutline)
            {
                var savedColor = Sprite.Color;
                var savedPosition = Sprite.Position;
                Sprite.Color = border;
                Sprite.Position = savedPosition - Vector2.UnitY;
                Sprite.Render(ctx);
                Sprite.Position = savedPosition + Vector2.UnitY;
                Sprite.Render(ctx);
                Sprite.Position = savedPosition - Vector2.UnitX;
                Sprite.Render(ctx);
                Sprite.Position = savedPosition + Vector2.UnitX;
                Sprite.Render(ctx);
                Sprite.Color = savedColor;
                Sprite.Position = savedPosition;
            }

            Nodes[0] = Vector2Geometry.Floor(Nodes[0]);
            if (border.A > 0)
                for (var i = 0; i < Sprite.HairCount; i++)
                {
                    Draw(i, Nodes[i] - Vector2.UnitX, border);
                    Draw(i, Nodes[i] + Vector2.UnitX, border);
                    Draw(i, Nodes[i] - Vector2.UnitY, border);
                    Draw(i, Nodes[i] + Vector2.UnitY, border);
                }

            for (var i = Sprite.HairCount - 1; i >= 0; i--)
                Draw(i, Nodes[i], useHairSegmentColorGetter ? GetHairColor(i) : color);

            void Draw(int index, Vector2 position, PackedColor tint)
            {
                var texture = index == 0 ? bangs[Sprite.HairFrame] : CurrentAtlas.Entries["characters/player/hair00"];
                var draw = new AtlasTextureDraw(texture, position, new(5f, 5f), tint, GetHairScale(index));
                ((ISourceRenderCommandSink<AtlasTextureDraw>)ctx).Draw(in draw, Entity);
            }
        }
    }
}
