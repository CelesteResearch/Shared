using Celeste.Core.Collections;

namespace Celeste.Core.Maps.Grids
{
    public interface IVirtualMapFactory
    {
        VirtualMap<T> Create<T>(int columns, int rows, T emptyValue = default);
    }
}
