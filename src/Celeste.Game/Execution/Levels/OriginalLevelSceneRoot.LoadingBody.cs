using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Hud.GrabIndicators;
using Celeste.Graphics.Particles.Sources;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public Vector2? StartPosition;

        public void LoadSourceLevelContent(
            ChapterCompletionSession actualIncomingSession, IChapterSessionMapData actualMap,
            IOriginalAreaData actualArea, Vector2? startPosition)
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            var processAudio = process.AudioSession;
            var processSave = process.SaveContext;
            if (actualIncomingSession.AreaID == 0)
                processSave.CurrentSave.Assists.DashMode = DashMode.Normal;
            ConstructSourceLoadingRenderers(actualIncomingSession.AreaID,
                (ISourceRenderEnvironment)EngineContext,
                ((ISourceSoundSourceEnvironment)EngineContext).SoundSources);
            LoadSourceBackdropContent((OriginalChapterMapData)actualMap, actualArea.DarknessAlpha, actualArea.BloomBase,
                actualArea.BloomStrength,
                processAudio);
            PublishSourceLoaderSession(actualIncomingSession, processSave);
            ConstructSourceParticleSystems((ISourceParticleTextureEnvironment)EngineContext);
            ConstructSourceTotalStrawberriesDisplay();
            ConstructSourceSpeedrunTimer();
            ConstructSourceGameplayStats();
            Scheduler.QueueSourceEntity(
                new OriginalGrabbyIconState(EngineContext));
            var sourceMap = (OriginalChapterMapData)actualMap;
            var tileBounds = sourceMap.TileBounds;
            var terrain = ConstructSourceTerrain(tileBounds, sourceMap);
            var position = terrain.Position;
            ApplySourceSceneryOverlays(sourceMap, position, tileBounds,
                terrain.BackgroundTiles, terrain.SolidTiles);
            if (actualArea.OnLevelBegin != null)
                actualArea.OnLevelBegin(this);
            StartPosition = startPosition;
            ConstructSourcePathfinder();
        }
    }
}
