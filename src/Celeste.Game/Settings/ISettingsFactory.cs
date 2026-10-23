using Celeste.Input.Bindings;

namespace Celeste.Game.Settings
{
    public interface ISettingsFactory
    {
        ISourceInputBindingFactory InputBindings { get; }
        SettingsState Create();
    }
}
