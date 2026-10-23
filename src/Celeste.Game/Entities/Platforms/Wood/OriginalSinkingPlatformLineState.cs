using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Platforms.Wood
{
    public class OriginalSinkingPlatformLineState : SceneEntityState
    {
        private readonly PackedColor edgeColor = SourceHexColor.HexToColor("2a1923");
        private readonly PackedColor innerColor = SourceHexColor.HexToColor("160b12");
        private float height;

        public OriginalSinkingPlatformLineState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            Depth = 9001;
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            height = (Scene as OriginalLevelSceneRoot).Bounds.Height - (Y - (Scene as OriginalLevelSceneRoot).Bounds.Y);
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, X - 1f, Y, 3f, height, edgeColor);
            SourcePrimitiveDrawing.Rect(context, this, X, Y + 1f, 1f, height, innerColor);
        }
    }
}
