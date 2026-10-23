using Celeste.Input.Bindings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceMenuInputEnvironment
    {
        public ISourceMenuInput MenuInput => InputSource;
    }
}
