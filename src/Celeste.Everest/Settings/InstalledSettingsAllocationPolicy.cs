using Celeste.Input.Bindings;
using Celeste.Everest.Input;
using Celeste.Game.Settings;

namespace Celeste.Everest.Settings
{
    public sealed class InstalledSettingsAllocationPolicy : ISettingsFactory
    {
        private readonly InstalledInputBindingFactory bindings;

        public InstalledSettingsAllocationPolicy(InstalledInputBindingFactory bindings)
        {
            this.bindings = bindings;
        }

        public Celeste.Input.Bindings.ISourceInputBindingFactory InputBindings => bindings;
        public SettingsState Create() => new SettingsState(bindings);
    }
}
