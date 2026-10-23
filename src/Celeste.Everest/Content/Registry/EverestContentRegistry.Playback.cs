using System.Collections.Generic;
using Celeste.Everest.Content.Playback;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public void LoadPlaybackTutorial(IDictionary<string, List<CharacterReplayFrame>> tutorials, string name,
            byte[] bytes)
        {
            EverestTutorialTimelineLoader.LoadVanilla(tutorials, name, bytes,
                Diagnostics);
        }

        public void LoadPlaybackTutorials(IDictionary<string, List<CharacterReplayFrame>> tutorials)
        {
            EverestTutorialTimelineLoader.Load(this, tutorials, Diagnostics);
        }
    }
}
