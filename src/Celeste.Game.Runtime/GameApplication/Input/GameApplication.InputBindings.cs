using Celeste.Input.Bindings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceInputBindingEnvironment
    {
        public ISourceInputBindingFactory InputBindings => SettingsAllocation.InputBindings;
    }
}
