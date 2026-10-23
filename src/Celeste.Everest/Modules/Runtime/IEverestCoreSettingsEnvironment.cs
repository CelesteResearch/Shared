namespace Celeste.Everest.Modules.Runtime
{
    public interface IEverestCoreSettingsEnvironment
    {
        // Late actual CoreModule.Instance._Settings, not an independent settings copy.
        EverestCoreSettings CurrentCoreSettings { get; }
    }
}
