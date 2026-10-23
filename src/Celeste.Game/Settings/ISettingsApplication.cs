namespace Celeste.Game.Settings
{
    // Engine operations invoked at the original settings initialization phases.
    public interface ISettingsApplication
    {
        void ApplyWindowPreference(SettingsState settings, int maximumWindowScale);
        void LaunchDebugMode();
    }
}
