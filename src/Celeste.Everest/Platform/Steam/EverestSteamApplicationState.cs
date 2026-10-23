using Celeste.Core.Platform.Steam;

namespace Celeste.Everest.Platform.Steam
{
    public sealed class EverestSteamApplicationState : ISourceSteamApplicationState
    {
        public uint SteamID = 504230u;
        public uint ApplicationId => SteamID;
    }
}
