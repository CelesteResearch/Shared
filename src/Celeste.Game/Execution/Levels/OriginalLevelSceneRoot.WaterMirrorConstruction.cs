using System;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public global::Celeste.Game.Presentation.Effects.Mirrors.MirrorSurfacesState MirrorSurfaces
        {
            get;
            private set;
        }

        public void ConstructSourceMirrorSurfaces()
        {
            MirrorSurfaces =
                new global::Celeste.Game.Presentation.Effects.Mirrors.MirrorSurfacesState(EngineContext);
            Scheduler.QueueSourceEntity(MirrorSurfaces);
        }
    }
}
