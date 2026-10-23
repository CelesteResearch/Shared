using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class EverestAreaRegistryLoadPolicy : IOriginalAreaRegistryLoadPolicy
    {
        private readonly InstalledAreaRegistryLoadSource source;

        public EverestAreaRegistryLoadPolicy(InstalledAreaRegistryLoadSource source)
            => this.source = source;

        public void Load() => source.LoadInstalledSource();
    }
}
