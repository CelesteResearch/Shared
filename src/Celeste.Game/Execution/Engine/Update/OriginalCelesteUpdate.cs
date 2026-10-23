using System;
using Celeste.Core.Framework.Components;
using Celeste.Input.Gameplay;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Engine.Update
{
    public sealed class OriginalCelesteUpdate
    {
        private readonly OriginalEngineFrame engine;
        private readonly IOriginalSteamCallbacks steam;
        private readonly IOriginalUserIOProcess userIO;
        private readonly OriginalAutoSplitterInfo autoSplitter;
        private readonly OriginalGameAudioSession audio;
        private readonly ISourceGameInput input;

        public OriginalCelesteUpdate(OriginalEngineFrame actualEngine, IOriginalSteamCallbacks actualSteam,
            IOriginalUserIOProcess actualUserIO, OriginalAutoSplitterInfo actualAutoSplitter,
            OriginalGameAudioSession actualAudio, ISourceGameInput actualInput)
        {
            engine = actualEngine ?? throw new ArgumentNullException(nameof(actualEngine));
            steam = actualSteam ?? throw new ArgumentNullException(nameof(actualSteam));
            userIO = actualUserIO ?? throw new ArgumentNullException(nameof(actualUserIO));
            autoSplitter = actualAutoSplitter ?? throw new ArgumentNullException(nameof(actualAutoSplitter));
            audio = actualAudio ?? throw new ArgumentNullException(nameof(actualAudio));
            input = actualInput ?? throw new ArgumentNullException(nameof(actualInput));
        }

        public void Update(SourceGameTime gameTime)
        {
            steam.RunCallbacks();
            if (userIO.SaveRoutine != null)
                userIO.SaveRoutine.Update();
            autoSplitter.Update();
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long audioUpdateStarted = 0;
            bool measuringAudioUpdate = diagnostics?.BeginAudioUpdate(out audioUpdateStarted) ?? false;
            try
            {
                audio.Update();
            }
            finally
            {
                if (measuringAudioUpdate) diagnostics.EndAudioUpdate(audioUpdateStarted);
            }

            engine.Update(gameTime);
            input.UpdateGrab();
            global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<global::Celeste.Core.Scheduling.ISourceGameUpdateObserver>(global::Celeste.Game.Execution
                    .EngineRuntime.Instance.Process)
                ?.AfterGameUpdate();
        }
    }
}
