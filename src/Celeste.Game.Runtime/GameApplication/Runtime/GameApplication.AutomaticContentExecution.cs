using System;
using System.Collections.Generic;
using Celeste.Everest.Runtime.Startup;
using Celeste.Game.Content.Playback;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Graphics.Drawing;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLoadContentEnvironment,
        IOriginalMonocleDrawInitializationEnvironment,
        ISourcePlaybackTimelineEnvironment
    {
        IReadOnlyDictionary<string,
                List<CharacterReplayFrame>>
            ISourcePlaybackTimelineEnvironment.PlaybackTimelines
            => PlaybackData.Tutorials;

        private OriginalOverworldGraphicsResources sourceOverworldGraphics;
        private OriginalPlaybackData sourcePlaybackData;
        private IOriginalCelesteContentLifecycle sourceCelesteContentLifecycle;

        public OriginalOverworldGraphicsResources OverworldGraphics => sourceOverworldGraphics ??
                                                                       throw new InvalidOperationException(
                                                                           "The source overworld graphics are not constructed.");

        public OriginalPlaybackData PlaybackData => sourcePlaybackData ??
                                                    throw new InvalidOperationException(
                                                        "The source playback data is not constructed.");

        public IOriginalCelesteContentLifecycle SourceLoadContent => sourceCelesteContentLifecycle ??
                                                                     throw new InvalidOperationException(
                                                                         "The source content lifecycle is not constructed.");

        internal void BindSourceGameContentLifecycle()
        {
            if (sourceCelesteContentLifecycle != null)
                throw new InvalidOperationException("The source content lifecycle is already bound.");
            sourceOverworldGraphics = new();
            sourcePlaybackData = SourceProfile == GameProfile.Original
                ? new()
                : new OriginalPlaybackData(tutorials =>
                        SourceContentRegistry.LoadPlaybackTutorials(tutorials),
                    (tutorials, name, bytes) => SourceContentRegistry.LoadPlaybackTutorial(tutorials, name, bytes));
            var original = new OriginalCelesteLoadContent(StartupResources, sourceOverworldGraphics,
                sourcePlaybackData, EngineGraphics, ActualGame.Content, this, StockEffects);
            sourceCelesteContentLifecycle = SourceProfile == GameProfile.Original
                ? original
                : new EverestCelesteContentLifecycle(original, this, EverestRuntime);
        }
    }
}
