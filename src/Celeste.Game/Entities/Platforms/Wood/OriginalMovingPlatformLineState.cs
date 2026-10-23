using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public class OriginalMovingPlatformLineState : SceneEntityState
    {
        private PackedColor edgeColor, innerColor;
        private readonly ISourceEngineContext engine;
        private readonly Vector2 end;

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
            var direction = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(end - Position);
            var normal = new Vector2(0f - direction.Y, direction.X);
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
