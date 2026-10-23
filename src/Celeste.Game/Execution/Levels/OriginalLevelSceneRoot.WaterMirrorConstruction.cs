using Celeste.Game.Presentation.Effects.Mirrors;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public MirrorSurfacesState MirrorSurfaces { get; private set; }

        public void ConstructSourceMirrorSurfaces()
        {
            MirrorSurfaces =
                new(EngineContext);
            Scheduler.QueueSourceEntity(MirrorSurfaces);
        }
    }
}
