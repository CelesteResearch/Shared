namespace Celeste.Input.Bindings
{
    public sealed class OriginalInputBindingFactory : ISourceInputBindingFactory
    {
        public SourceInputBinding Create() => new SourceInputBinding();
    }
}
