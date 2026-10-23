using System;

namespace Celeste.Core.Maps.Grids
{
    public static class CsvIntegerGrid
    {
        public static int[,] Read(string csv, int width, int height)
        {
            var grid = new int[width, height];
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                grid[x, y] = -1;
            var rows = csv.Split('\n');
            for (var y = 0; y < height && y < rows.Length; y++)
            {
                var values = rows[y].Split([','], StringSplitOptions.RemoveEmptyEntries);
                for (var x = 0; x < width && x < values.Length; x++)
                    grid[x, y] = Convert.ToInt32(values[x]);
            }

            return grid;
        }
    }
}
