using Celeste.Game.Content.Playback;

namespace Celeste.Everest.Content.Registry
{
    public interface IEverestContentUpdateEnvironment
    {
        OriginalPlaybackData PlaybackData { get; }
    }
}
