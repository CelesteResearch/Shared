#nullable enable annotations
namespace Celeste.Everest.Runtime.Discord
{
    public interface IEverestDiscordSdkEnvironment
    {
        IEverestDiscordSdkProcess? DiscordSdk { get; }
    }
}
