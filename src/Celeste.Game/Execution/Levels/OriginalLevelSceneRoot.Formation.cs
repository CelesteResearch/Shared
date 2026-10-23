using System;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation.Presentation.Backdrops.Formation;
using Celeste.Simulation.Presentation.Backdrops.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IFormationBackdropScene
    {
        public FormationBackdropPresentation FormationBackdrop { get; private set; }

        BackdropRendererPresentation IFormationBackdropScene
            .
            Foreground => Foreground;

        CameraState IFormationBackdropScene.Camera => Camera;

        public void ConstructSourceFormationBackdrop()
        {
            if (FormationBackdrop != null)
                throw new InvalidOperationException("This Level already constructed its FormationBackdrop.");
            FormationBackdrop = new(EngineContext,
                ((IOriginalGameTagsEnvironment)EngineContext).Tags.FrozenUpdate
                .Value,
                ((IOriginalGameTagsEnvironment)EngineContext).Tags.Global
                .Value);
            Scheduler.QueueSourceEntity(FormationBackdrop);
        }
    }
}
