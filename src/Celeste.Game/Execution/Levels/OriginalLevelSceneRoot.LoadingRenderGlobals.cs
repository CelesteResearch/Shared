using Celeste.Core.Rendering;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Presentation.Hud;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public LightningRendererState LightningRenderer { get; private set; }
        public SeekerBarrierRendererState SeekerBarrierRenderer { get; private set; }

        public void ConstructSourceLoadingRenderers(int areaId,
            ISourceRenderEnvironment environment,
            ISourceSoundSourceFactory soundSources)
        {
            ConstructSourceGameplayRenderer();
            ConstructSourceLightingRenderer();
            ConstructSourceBloomRenderer();
            ConstructSourceDisplacementRenderer();
            ConstructSourceBackdropRenderers();
            ConstructSourceDustEdges();
            ConstructSourceWaterSurface();
            ConstructSourceMirrorSurfaces();
            ConstructSourceGlassBlockBackground();
            LightningRenderer = new(EngineContext, environment, soundSources);
            Scheduler.QueueSourceEntity(LightningRenderer);
            SeekerBarrierRenderer = new(EngineContext, environment);
            Scheduler.QueueSourceEntity(SeekerBarrierRenderer);
            if (((IOriginalThreadEnvironment)EngineContext)
                .Threads.Profile == OriginalGameThreadProfile.Installed)
                ConstructSourceSubHudRenderer(
                    ((IOriginalSubHudRendererEnvironment)EngineContext)
                    .SubHudRenderers);
            ConstructSourceHudRenderer();
            if (areaId == 9) ConstructSourceIceTileOverlay();
        }
    }
}
