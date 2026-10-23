using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Scene.Entities;
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
            var level = Scene as OriginalLevelSceneRoot;
            var camera = level.Camera;
            var color = PackedColor.White * alpha;
            var num = (int)(Math.Floor((camera.Left - level.SolidTiles.X) / 8f) - 1.0);
            var num2 = (int)(Math.Floor((camera.Top - level.SolidTiles.Y) / 8f) - 1.0);
            var num3 = (int)(Math.Ceiling((camera.Right - level.SolidTiles.X) / 8f) + 1.0);
            var num4 = (int)(Math.Ceiling((camera.Bottom - level.SolidTiles.Y) / 8f) + 1.0);
            for (var i = num; i < num3; i++)
            for (var j = num2; j < num4; j++)
                if (level.SolidsData.SafeCheck(i, j) != '0' && level.SolidsData.SafeCheck(i, j - 1) == '0')
                {
                    var position = level.SolidTiles.Position + new Vector2(i, j) * 8f;
                    var index = (i * 5 + j * 17) % surfaces.Count;
                    var draw = new AtlasTextureDraw(surfaces[index], position, Vector2.Zero, color, Vector2.One);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
                }
        }
    }
}
