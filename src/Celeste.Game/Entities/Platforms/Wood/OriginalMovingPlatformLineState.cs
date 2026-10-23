using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Moving;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public class OriginalMovingPlatformLineState : SceneEntityState
    {
        private PackedColor edgeColor, innerColor;
        private readonly ISourceEngineContext engine;
        private Vector2 end;

        public OriginalMovingPlatformLineState(ISourceEngineContext engine, Vector2 position, Vector2 end)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            Depth = 9001;
            this.end = end;
        }

        public override void Added(object actualScene)
        {
            if ((actualScene as OriginalLevelSceneRoot).Session.AreaID == 4)
            {
                edgeColor = SourceHexColor.HexToColor("a4464a");
                innerColor = SourceHexColor.HexToColor("86354e");
            }
            else
            {
                edgeColor = SourceHexColor.HexToColor("2a1923");
                innerColor = SourceHexColor.HexToColor("160b12");
            }

            base.Added(actualScene);
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 direction = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(end - Position);
            Vector2 normal = new Vector2(0f - direction.Y, direction.X);
            SourcePrimitiveDrawing.Line(context, this, Position - direction - normal, end + direction - normal,
                edgeColor,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, Position - direction, end + direction, edgeColor,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, Position - direction + normal, end + direction + normal,
                edgeColor,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, Position, end, innerColor,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
        }
    }
}
