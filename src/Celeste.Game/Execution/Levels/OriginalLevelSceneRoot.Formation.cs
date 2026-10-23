using System;
using Celeste.Simulation.Presentation.Backdrops.Formation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IFormationBackdropScene
    {
        public FormationBackdropPresentation FormationBackdrop { get; private set; }

        global::Celeste.Simulation.Presentation.Backdrops.Rendering.BackdropRendererPresentation IFormationBackdropScene
            .
            Foreground => Foreground;

        global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState IFormationBackdropScene.Camera => Camera;

        public void ConstructSourceFormationBackdrop()
        {
            if (FormationBackdrop != null)
                throw new InvalidOperationException("This Level already constructed its FormationBackdrop.");
            FormationBackdrop = new FormationBackdropPresentation(EngineContext,
                ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext).Tags.FrozenUpdate
                .Value,
                ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext).Tags.Global
                .Value);
            Scheduler.QueueSourceEntity(FormationBackdrop);
        }
    }
}
