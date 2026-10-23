using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Game.Save.Runtime;
using Celeste.Input.Gameplay;

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
            var diagnostics = SourceFrameDiagnostics.Current;
            long audioUpdateStarted = 0;
            var measuringAudioUpdate = diagnostics?.BeginAudioUpdate(out audioUpdateStarted) ?? false;
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
            SourceRuntimeExtensions
                .Get<ISourceGameUpdateObserver>(EngineRuntime.Instance.Process)
                ?.AfterGameUpdate();
        }
    }
}
