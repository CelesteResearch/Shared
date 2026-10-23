using System.Collections.Generic;

namespace Celeste.Graphics.Animation.Replay
{
    // The same process-owned dictionary and lists; this capability never clones timelines.
    public interface ISourcePlaybackTimelineEnvironment
    {
        IReadOnlyDictionary<string, List<CharacterReplayFrame>> PlaybackTimelines { get; }
    }
}
