using Celeste.Everest.Input;
using Celeste.Game.Settings;
using Celeste.Input.Bindings;

namespace Celeste.Everest.Settings
{
    public sealed class InstalledSettingsAllocationPolicy : ISettingsFactory
    {
        private readonly InstalledInputBindingFactory bindings;

        public InstalledSettingsAllocationPolicy(InstalledInputBindingFactory bindings)
        {
            this.bindings = bindings;
        }

        public ISourceInputBindingFactory InputBindings => bindings;

        public SettingsState Create()
        {
            return new(bindings);
        }
    }
}
