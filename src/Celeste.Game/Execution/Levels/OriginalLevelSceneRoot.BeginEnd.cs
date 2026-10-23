using Celeste.Core.Display;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Execution.Levels.Hooks;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public override void Begin()
        {
            BeginSourceBody();
            ((IOriginalLevelLifecycleSourceHooksEnvironment)EngineContext)
                .LevelSourceHooks.InvokeAfterBegin(this);
        }

        private void BeginSourceBody()
        {
            WipeColor = PackedColor.Black;
            CreateSourceGameplayBuffers();
            EngineContext.Effects.WaterAlpha = 1f;
            EngineContext.Effects.WaterSineDirection = 1f;
            sourceAudioSession.MusicUnderwater = false;
            sourceAudioSession.EndSnapshot(DialogSnapshot);
            base.Begin();
        }

        public override void End()
        {
            base.End();
            Foreground.Ended(this);
            Background.Ended(this);
            EndPauseEffects();
            sourceAudioSession.Runtime.StopGameplaySfx();
            sourceAudioSession.MusicUnderwater = false;
            sourceAudioSession.ChannelOutput.SetAmbience(null);
            sourceAudioSession.ChannelOutput.SetAltMusic(null);
            sourceAudioSession.EndSnapshot(DialogSnapshot);
            sourceAudioSession.ReleaseSnapshot(AssistSpeedSnapshot);
            AssistSpeedSnapshot = null;
            AssistSpeedSnapshotValue = -1;
            UnloadSourceGameplayBuffers();
            DisposeSourceClutterGenerator();
            EngineContext.Effects.TimeRateB = 1f;
            ((IOriginalLevelLifecycleSourceHooksEnvironment)EngineContext)
                .LevelSourceHooks.InvokeAfterEnd(this);
        }
    }
}
