using System;
using System.Numerics;
using Celeste.Game.Entities.Environment.Wind;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void Reload()
        {
            if (Completed) return;
            ReloadSourceTimerPrefix();
            Glitch.Value = 0f;
            EngineContext.Effects.TimeRate = 1f;
            EngineContext.Effects.Anxiety = 0f;
            EngineContext.Effects.GameRate = 1f;
            sourceAudioSession.ChannelOutput.SetMusicParam("fade", 1f);
            ParticlesBG.Clear();
            Particles.Clear();
            ParticlesFG.Clear();
            TrailManagerState.Clear(EngineContext);
            UnloadLevel();
            // The selected source hook gates the original collection point.
            var collectionPolicy =
                ((global::Celeste.Core.Framework.GarbageCollection.ISourceGarbageCollectionEnvironment)
                    EngineContext).GarbageCollectionPolicy;
            if (!collectionPolicy.ShouldSkipCollection)
                collectionPolicy.CollectOnReload();

            LoadLevel(PlayerIntroType.Respawn);
            strawberriesDisplay.DrawLerp = 0f;
            var controller = Scheduler.Entities.FindFirst<OriginalWindController>();
            if (controller != null)
                controller.SnapWind();
            else
                Wind = Vector2.Zero;
        }
    }
}
