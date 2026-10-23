using Celeste.Core.Collections;

namespace Celeste.Core.Maps.Grids
{
    public sealed class VirtualMapFactory : IVirtualMapFactory
    {
        public static readonly VirtualMapFactory Instance = new();

        private VirtualMapFactory()
        {
        }

        public VirtualMap<T> Create<T>(int columns, int rows, T emptyValue = default)
        {
            return new(columns, rows, emptyValue);
        }
    }
}
