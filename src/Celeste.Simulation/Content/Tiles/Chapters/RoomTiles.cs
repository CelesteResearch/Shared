using System;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Content.Tiles.Chapters
{
    public sealed class RoomTiles
    {
        public MapElement Data;
        public IntRect Bounds;

        public IntRect TileBounds => new(
            Bounds.X / 8, Bounds.Y / 8, (int)Math.Ceiling(Bounds.Width / 8f),
            (int)Math.Ceiling(Bounds.Height / 8f));

        public string Bg => Data.Child("bg")?.Text("innerText") ?? "";
        public string Solids => Data.Child("solids")?.Text("innerText") ?? "";
    }
}
