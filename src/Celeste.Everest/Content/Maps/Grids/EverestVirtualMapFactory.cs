using Celeste.Core.Collections;
using Celeste.Core.Maps.Grids;

namespace Celeste.Everest.Content.Maps.Grids
{
    public sealed class EverestVirtualMapFactory : IVirtualMapFactory
    {
        public static readonly EverestVirtualMapFactory Instance = new();

        private EverestVirtualMapFactory()
        {
        }

        public VirtualMap<T> Create<T>(int columns, int rows, T emptyValue = default)
            => new EverestVirtualMap<T>(columns, rows, emptyValue);
    }
}
