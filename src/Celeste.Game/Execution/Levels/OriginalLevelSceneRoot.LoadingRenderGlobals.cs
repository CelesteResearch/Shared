using System;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Presentation.Effects.Mirrors;

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
            LightningRenderer = new LightningRendererState(EngineContext, environment, soundSources);
            Scheduler.QueueSourceEntity(LightningRenderer);
            SeekerBarrierRenderer = new SeekerBarrierRendererState(EngineContext, environment);
            Scheduler.QueueSourceEntity(SeekerBarrierRenderer);
            if (((Celeste.Game.Execution.Threading.IOriginalThreadEnvironment)EngineContext)
                .Threads.Profile == Celeste.Game.Execution.Threading.OriginalGameThreadProfile.Installed)
                ConstructSourceSubHudRenderer(
                    ((Celeste.Game.Presentation.Hud.IOriginalSubHudRendererEnvironment)EngineContext)
                    .SubHudRenderers);
            ConstructSourceHudRenderer();
            if (areaId == 9) ConstructSourceIceTileOverlay();
        }
    }
}
