using Celeste.Input.Bindings;

namespace Celeste.Game.Settings
{
    public sealed class OriginalSettingsAllocationPolicy : ISettingsFactory
    {
        private readonly OriginalInputBindingFactory bindings;

        public OriginalSettingsAllocationPolicy(OriginalInputBindingFactory bindings)
        {
            this.bindings = bindings;
        }

        public Celeste.Input.Bindings.ISourceInputBindingFactory InputBindings => bindings;
        public SettingsState Create() => new SettingsState(bindings);
    }
}
