using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Hud.GrabIndicators
{
    public class OriginalGrabbyIconState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private bool enabled;
        private WigglerComponent wiggler;

        public OriginalGrabbyIconState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = -1000001;
            var tags = ((IOriginalGameTagsEnvironment)engine).Tags;
            Tags = tags.Global.Value | tags.PauseUpdate.Value | tags.TransitionUpdate.Value;
            Components.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.1f, .3f));
        }

        public override void Update()
        {
            base.Update();
            bool flag = false;
            if (!((OriginalLevelSceneRoot)Scene).InCutscene)
            {
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && !entity.Dead &&
                    ((ISettingsContext)engine).Settings.GrabMode == GrabMode.Toggle &&
                    ((ISourceGameInputEnvironment)engine).Input.GrabCheck)
                    flag = true;
            }

            if (flag != enabled)
            {
                enabled = flag;
                wiggler.Start();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (enabled)
            {
                Vector2 scale = Vector2.One * (1f + wiggler.Value * .2f);
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null)
                    SourceAtlasDrawing.DrawJustified(context, this,
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["util/glove"],
                        new Vector2(entity.Position.X, entity.Position.Y - 16f), new Vector2(.5f, 1f),
                        PackedColor.White,
                        scale);
            }
        }
    }
}
