using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Solids.Nega;

namespace Celeste.Game.Entities.Platforms.Nega
{
    public static class OriginalNegaBlockConstruction
    {
        public static NegaBlockState CreateFromMapData(EntityData data, Vector2 offset,
            ISourceSolidWorldFactory worlds)
        {
            var position = data.Position + offset;
            float width = data.Width;
            float height = data.Height;
            return new(position, width, height, worlds.Create(position, false));
        }
    }
}
