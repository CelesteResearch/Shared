using Celeste.Core.Platform.Steam;

namespace Celeste.Game.Platform.Steam
{
    public sealed class OriginalSteamApplicationState : ISourceSteamApplicationState
    {
        public readonly uint SteamID = 504230u;
        public uint ApplicationId => SteamID;
    }
}
