using Celeste.Core.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Simulation.Rendering
{
    public sealed class ChapterSource
    {
        public readonly List<global::Celeste.Simulation.Content.Tiles.Chapters.RoomTiles> Levels = [];
        public readonly List<global::Celeste.Core.Geometry.IntRect> Filler = [];
        public global::Celeste.Core.Geometry.IntRect Bounds;

        public global::Celeste.Core.Geometry.IntRect TileBounds => new global::Celeste.Core.Geometry.IntRect(
            Bounds.X / 8, Bounds.Y / 8, (int)Math.Ceiling(Bounds.Width / 8f),
            (int)Math.Ceiling(Bounds.Height / 8f));

        public ChapterSource(MapDocument map)
        {
            foreach (global::Celeste.Core.Maps.MapElement room in map.Rooms)
                Levels.Add(new global::Celeste.Simulation.Content.Tiles.Chapters.RoomTiles
                {
                    Data = room,
                    Bounds = new global::Celeste.Core.Geometry.IntRect(room.Int("x"), room.Int("y"), room.Int("width"),
                        room.Int("height"))
                });
            foreach (global::Celeste.Core.Maps.MapElement filler in map.Fillers)
                Filler.Add(new global::Celeste.Core.Geometry.IntRect(filler.Int("x"), filler.Int("y"), filler.Int("w"),
                    filler.Int("h")));
            if (Levels.Count == 0) throw new ArgumentException("Map contains no rooms.");
            var rectangles = Levels.Select(r => r.Bounds).Concat(Filler).ToArray();
            int left = rectangles.Min(r => r.Left), top = rectangles.Min(r => r.Top);
            int right = rectangles.Max(r => r.Right), bottom = rectangles.Max(r => r.Bottom);
            Bounds = new global::Celeste.Core.Geometry.IntRect(left - 64, top - 64, right - left + 128,
                bottom - top + 128);
        }
    }
}
