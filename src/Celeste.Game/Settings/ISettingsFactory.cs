using Celeste.Input.Bindings;

namespace Celeste.Game.Settings
{
    public interface ISettingsFactory
    {
        Celeste.Input.Bindings.ISourceInputBindingFactory InputBindings { get; }
        SettingsState Create();
    }
}
