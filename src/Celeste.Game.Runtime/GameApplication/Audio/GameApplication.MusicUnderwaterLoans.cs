using Celeste.Core.Audio;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceMusicUnderwaterEnvironment
    {
        bool ISourceMusicUnderwaterEnvironment.MusicUnderwater
        {
            get => AudioSession.MusicUnderwater;
            set => AudioSession.MusicUnderwater = value;
        }
    }
}
