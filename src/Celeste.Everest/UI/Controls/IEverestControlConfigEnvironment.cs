namespace Celeste.Everest.UI.Controls
{
    public interface IEverestControlConfigEnvironment
    {
        // Late read of actual CoreModule.Settings, no binding cache or controls table.
        EverestCoreSettings CoreSettings { get; }
    }
}
