using Celeste.Core.Collections;

namespace Celeste.Everest.Content.Maps.Grids
{
    public sealed class EverestVirtualMap<T> : VirtualMap<T>
    {
        public EverestVirtualMap(int columns, int rows, T emptyValue = default) : base(columns, rows, emptyValue)
        {
        }

        public override T this[int x, int y]
        {
            get => x < 0 || y < 0 || Columns <= x || Rows <= y ? EmptyValue : base[x, y];
            set
            {
                if (x >= 0 && y >= 0 && Columns > x && Rows > y) base[x, y] = value;
            }
        }
    }
}
