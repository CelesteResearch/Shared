namespace Celeste.Core.Platform.Steam
{
    public interface ISourceSteamRuntimeIO
    {
        bool RestartAppIfNecessary(uint applicationId);
        bool Initialize();
        string GetCurrentGameLanguage();
        void RunCallbacks();
    }
}
