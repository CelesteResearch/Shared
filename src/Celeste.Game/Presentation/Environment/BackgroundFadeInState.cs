using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Environment
{
    public class BackgroundFadeInState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public PackedColor Color;
        public float Duration;
        public float Delay;
        public float Percent;

        public BackgroundFadeInState(ISourceEngineContext engine, PackedColor color, float delay, float duration)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Depth = 10100;
            Color = color;
            Delay = delay;
            Duration = duration;
            Percent = 0f;
        }

        public override void Update()
        {
            if (Delay <= 0f)
            {
                if (Percent >= 1f) RemoveSelf();
                Percent += engine.DeltaTime / Duration;
            }
            else Delay -= engine.DeltaTime;

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = (Scene as OriginalLevelSceneRoot).Camera.Position;
            SourcePrimitiveDrawing.Rect(context, this, position.X - 10f, position.Y - 10f, 340f, 200f,
                Color * (1f - Percent));
        }
    }
}
