using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates.Presentation
{
    public static class SwitchGateRendering
    {
        public static AtlasEntry[,] CreateNineSlice(AtlasEntry texture)
        {
            var slices = new AtlasEntry[3, 3];
            for (var x = 0; x < 3; x++)
            for (var y = 0; y < 3; y++)
                slices[x, y] = texture.GetSubtexture(x * 8, y * 8, 8, 8);
            return slices;
        }

        public static void RenderFrame(ISourceRenderContext context, SourceSolidEntityState gate,
            AtlasEntry[,] nineSlice)
        {
            var num = gate.Collider.Width / 8f - 1f;
            var num2 = gate.Collider.Height / 8f - 1f;
            for (var i = 0; i <= num; i++)
            for (var j = 0; j <= num2; j++)
            {
                var num3 = i < num ? Math.Min(i, 1) : 2;
                var num4 = j < num2 ? Math.Min(j, 1) : 2;
                SourceAtlasDrawing.Draw(context, gate, nineSlice[num3, num4],
                    gate.Position + gate.Shake + new Vector2(i * 8, j * 8), Vector2.Zero, PackedColor.White,
                    Vector2.One);
            }
        }
    }
}
