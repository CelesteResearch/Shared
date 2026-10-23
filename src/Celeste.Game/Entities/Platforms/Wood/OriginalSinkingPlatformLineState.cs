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
    public class OriginalSinkingPlatformLineState : SceneEntityState
    {
        private PackedColor edgeColor = SourceHexColor.HexToColor("2a1923");
        private PackedColor innerColor = SourceHexColor.HexToColor("160b12");
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
