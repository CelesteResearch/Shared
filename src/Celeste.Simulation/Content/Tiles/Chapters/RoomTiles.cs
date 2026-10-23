using System;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Content.Tiles.Chapters
{
    public sealed class RoomTiles
    {
        public global::Celeste.Core.Maps.MapElement Data;
        public global::Celeste.Core.Geometry.IntRect Bounds;

        public global::Celeste.Core.Geometry.IntRect TileBounds => new global::Celeste.Core.Geometry.IntRect(
            Bounds.X / 8, Bounds.Y / 8, (int)Math.Ceiling(Bounds.Width / 8f),
            (int)Math.Ceiling(Bounds.Height / 8f));

        public string Bg => Data.Child("bg")?.Text("innerText") ?? "";
        public string Solids => Data.Child("solids")?.Text("innerText") ?? "";
    }
}
