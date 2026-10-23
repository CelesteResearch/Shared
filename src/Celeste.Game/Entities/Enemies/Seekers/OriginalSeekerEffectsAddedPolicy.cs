using System;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Entities.Enemies.Seekers
{
    public sealed class OriginalSeekerEffectsAddedPolicy : ISeekerEffectsAddedPolicy
    {
        public static OriginalSeekerEffectsAddedPolicy Shared { get; } = new();

        public void Added(object actualScene, Action baseAdded)
        {
            baseAdded();
            var actualLevel = actualScene as OriginalLevelSceneRoot;
            actualLevel.Session.Audio.Music.Layer(3, 0f);
            var process = (IOriginalGameplayProcess)actualLevel.EngineContext;
            OriginalAudioSession.Apply(actualLevel.Session.Audio, process.AudioSession.ChannelOutput,
                process.AudioApplyPolicy);
        }
    }
}
