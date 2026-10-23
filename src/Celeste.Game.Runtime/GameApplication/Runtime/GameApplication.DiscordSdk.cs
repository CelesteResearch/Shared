using Celeste.Everest.Runtime.Discord;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDiscordSdkEnvironment
    {
        public IEverestDiscordSdkProcess? DiscordSdk => PhysicalIO.DiscordSdk;
    }
}
