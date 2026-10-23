namespace Celeste.Game.Execution.Areas
{
    public sealed class OriginalAreaRegistryLoadPolicy : IOriginalAreaRegistryLoadPolicy
    {
        private readonly OriginalAreaRegistryProcess registry;

        public OriginalAreaRegistryLoadPolicy(OriginalAreaRegistryProcess registry)
            => this.registry = registry;

        public void Load() => registry.LoadOriginalSource();
    }
}
