#nullable enable annotations
namespace Celeste.Everest.Runtime.Discord
{
    public interface IEverestDiscordSdkProcess
    {
        IEverestDiscordSdkComponent? Instance { get; }
        IEverestDiscordSdkComponent? CreateInstance();
        void LoadRichPresenceIcons();
    }
}
