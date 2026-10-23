using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Game.Execution.LevelLoader.Terrain
{
    public class OriginalIceTileOverlayState : SceneEntityState
    {
        private readonly IReadOnlyList<AtlasEntry> surfaces;
        private float alpha;
        private readonly ISourceEngineContext engine;

        public OriginalIceTileOverlayState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = -10010;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.Global.Value);
            Visible = false;
            surfaces = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("scenery/iceSurface");
        }

        public override void Update()
        {
            base.Update();
            alpha = ScalarMath.Approach(alpha, (Scene as OriginalLevelSceneRoot).CoreMode == RoomCoreMode.Cold ? 1 : 0,
                engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Visible = alpha > 0f;
        }

        public override void Render(ISourceRenderContext context)
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            var camera = level.Camera;
            PackedColor color = PackedColor.White * alpha;
            int num = (int)(Math.Floor((camera.Left - level.SolidTiles.X) / 8f) - 1.0);
            int num2 = (int)(Math.Floor((camera.Top - level.SolidTiles.Y) / 8f) - 1.0);
            int num3 = (int)(Math.Ceiling((camera.Right - level.SolidTiles.X) / 8f) + 1.0);
            int num4 = (int)(Math.Ceiling((camera.Bottom - level.SolidTiles.Y) / 8f) + 1.0);
            for (int i = num; i < num3; i++)
            {
                for (int j = num2; j < num4; j++)
                {
                    if (level.SolidsData.SafeCheck(i, j) != '0' && level.SolidsData.SafeCheck(i, j - 1) == '0')
                    {
                        Vector2 position = level.SolidTiles.Position + new Vector2(i, j) * 8f;
                        int index = (i * 5 + j * 17) % surfaces.Count;
                        var draw = new AtlasTextureDraw(surfaces[index], position, Vector2.Zero, color, Vector2.One);
                        ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
                    }
                }
            }
        }
    }
}
