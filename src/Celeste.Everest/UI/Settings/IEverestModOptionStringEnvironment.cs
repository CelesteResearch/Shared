namespace Celeste.Everest.UI.Settings
{
    public interface IEverestModOptionStringEnvironment
    {
        EverestModOptionStringProcessState ModOptionStringProcess { get; }

        // Must evaluate the actual current CoreModule.Instance._Settings as EverestCoreSettings.
        // Do not capture a bool or substitute a default module/settings object.
        EverestCoreSettings CurrentCoreSettings { get; }
    }
}
