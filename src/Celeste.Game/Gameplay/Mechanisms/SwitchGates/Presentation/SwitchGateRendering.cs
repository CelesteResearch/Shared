using System;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates.Presentation
{
    public static class SwitchGateRendering
    {
        public static AtlasEntry[,] CreateNineSlice(AtlasEntry texture)
        {
            var slices = new AtlasEntry[3, 3];
            for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                slices[x, y] = texture.GetSubtexture(x * 8, y * 8, 8, 8);
            return slices;
        }

        public static void RenderFrame(ISourceRenderContext context, SourceSolidEntityState gate,
            AtlasEntry[,] nineSlice)
        {
            float num = gate.Collider.Width / 8f - 1f;
            float num2 = gate.Collider.Height / 8f - 1f;
            for (int i = 0; (float)i <= num; i++)
            {
                for (int j = 0; (float)j <= num2; j++)
                {
                    int num3 = (((float)i < num) ? Math.Min(i, 1) : 2);
                    int num4 = (((float)j < num2) ? Math.Min(j, 1) : 2);
                    SourceAtlasDrawing.Draw(context, gate, nineSlice[num3, num4],
                        gate.Position + gate.Shake + new Vector2(i * 8, j * 8), Vector2.Zero, PackedColor.White,
                        Vector2.One);
                }
            }
        }
    }
}
