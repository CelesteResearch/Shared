namespace Celeste.Core.Collections
{
    public class VirtualMap<T>
    {
        public const int SegmentSize = 50;

        public readonly int Columns;

        public readonly int Rows;

        public readonly int SegmentColumns;

        public readonly int SegmentRows;

        public readonly T EmptyValue;

        private readonly T[,][,] _segments;

        public virtual T this[int x, int y]
        {
            get
            {
                var num = x / 50;
                var num2 = y / 50;
                var array = _segments[num, num2];
                if (array == null) return EmptyValue;

                return array[x - num * 50, y - num2 * 50];
            }
            set
            {
                var num = x / 50;
                var num2 = y / 50;
                if (_segments[num, num2] == null)
                {
                    _segments[num, num2] = new T[50, 50];
                    if (EmptyValue != null && !EmptyValue.Equals(default(T)))
                        for (var i = 0; i < 50; i++)
                        for (var j = 0; j < 50; j++)
                            _segments[num, num2][i, j] = EmptyValue;
                }

                _segments[num, num2][x - num * 50, y - num2 * 50] = value;
            }
        }

        public VirtualMap(int columns, int rows, T emptyValue = default)
        {
            Columns = columns;
            Rows = rows;
            SegmentColumns = columns / 50 + 1;
            SegmentRows = rows / 50 + 1;
            _segments = new T[SegmentColumns, SegmentRows][,];
            EmptyValue = emptyValue;
        }

        public VirtualMap(T[,] map, T emptyValue = default)
            : this(map.GetLength(0), map.GetLength(1), emptyValue)
        {
            for (var i = 0; i < Columns; i++)
            for (var j = 0; j < Rows; j++)
                this[i, j] = map[i, j];
        }

        public bool AnyInSegmentAtTile(int x, int y)
        {
            var num = x / 50;
            var num2 = y / 50;
            return _segments[num, num2] != null;
        }

        public bool AnyInSegment(int segmentX, int segmentY)
        {
            return _segments[segmentX, segmentY] != null;
        }

        public T InSegment(int segmentX, int segmentY, int x, int y)
        {
            return _segments[segmentX, segmentY][x, y];
        }

        public T[,] GetSegment(int segmentX, int segmentY)
        {
            return _segments[segmentX, segmentY];
        }

        public T SafeCheck(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Columns && y < Rows) return this[x, y];

            return EmptyValue;
        }

        public T[,] ToArray()
        {
            var array = new T[Columns, Rows];
            for (var i = 0; i < Columns; i++)
            for (var j = 0; j < Rows; j++)
                array[i, j] = this[i, j];

            return array;
        }

        public VirtualMap<T> Clone()
        {
            var virtualMap = new VirtualMap<T>(Columns, Rows, EmptyValue);
            for (var i = 0; i < Columns; i++)
            for (var j = 0; j < Rows; j++)
                virtualMap[i, j] = this[i, j];

            return virtualMap;
        }
    }
}
