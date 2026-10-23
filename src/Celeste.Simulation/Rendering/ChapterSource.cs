using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Simulation.Content.Tiles.Chapters;

namespace Celeste.Simulation.Rendering
{
    public sealed class ChapterSource
    {
        public readonly List<RoomTiles> Levels = [];
        public readonly List<IntRect> Filler = [];
        public IntRect Bounds;

        public IntRect TileBounds => new(
            Bounds.X / 8, Bounds.Y / 8, (int)Math.Ceiling(Bounds.Width / 8f),
            (int)Math.Ceiling(Bounds.Height / 8f));

        public ChapterSource(MapDocument map)
        {
            foreach (var room in map.Rooms)
                Levels.Add(new()
                {
                    Data = room,
                    Bounds = new(room.Int("x"), room.Int("y"), room.Int("width"),
                        room.Int("height")),
                });
            foreach (var filler in map.Fillers)
                Filler.Add(new(filler.Int("x"), filler.Int("y"), filler.Int("w"),
                    filler.Int("h")));
            if (Levels.Count == 0) throw new ArgumentException("Map contains no rooms.");
            var rectangles = Levels.Select(r => r.Bounds).Concat(Filler).ToArray();
            int left = rectangles.Min(r => r.Left), top = rectangles.Min(r => r.Top);
            int right = rectangles.Max(r => r.Right), bottom = rectangles.Max(r => r.Bottom);
            Bounds = new(left - 64, top - 64, right - left + 128,
                bottom - top + 128);
        }
    }
}
