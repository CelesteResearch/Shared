using System;

namespace Celeste.Core.Maps.Grids
{
    public static class CsvIntegerGrid
    {
        public static int[,] Read(string csv, int width, int height)
        {
            var grid = new int[width, height];
            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                grid[x, y] = -1;
            string[] rows = csv.Split('\n');
            for (int y = 0; y < height && y < rows.Length; y++)
            {
                string[] values = rows[y].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < width && x < values.Length; x++)
                    grid[x, y] = Convert.ToInt32(values[x]);
            }

            return grid;
        }
    }
}
