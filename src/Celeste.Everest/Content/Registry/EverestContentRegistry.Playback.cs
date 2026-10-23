using System.Collections.Generic;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public void LoadPlaybackTutorial(IDictionary<string, List<CharacterReplayFrame>> tutorials, string name,
            byte[] bytes)
            => Celeste.Everest.Content.Playback.EverestTutorialTimelineLoader.LoadVanilla(tutorials, name, bytes,
                Diagnostics);

        public void LoadPlaybackTutorials(IDictionary<string, List<CharacterReplayFrame>> tutorials)
            => Celeste.Everest.Content.Playback.EverestTutorialTimelineLoader.Load(this, tutorials, Diagnostics);
    }
}
