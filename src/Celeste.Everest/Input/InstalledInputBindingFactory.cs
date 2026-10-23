using Celeste.Input.Bindings;

namespace Celeste.Everest.Input
{
    public sealed class InstalledInputBindingFactory : ISourceInputBindingFactory
    {
        public SourceInputBinding Create()
        {
            return new InstalledSourceInputBinding();
        }
    }
}
