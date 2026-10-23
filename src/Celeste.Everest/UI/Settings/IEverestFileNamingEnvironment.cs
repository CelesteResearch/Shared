namespace Celeste.Everest.UI.Settings
{
    public interface IEverestFileNamingEnvironment
    {
        // Actual CoreModule.Instance._Settings as EverestCoreSettings, evaluated on every read.
        EverestCoreSettings CurrentCoreSettings { get; }

        // Actual CoreModule.Settings source getter, evaluated on every read.
        EverestCoreSettings CoreSettings { get; }
    }
}
