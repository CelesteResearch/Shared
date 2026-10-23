using Celeste.Core.Display;
using Celeste.Game.Entities.Platforms.ZipMovers;

namespace Celeste.Everest.Entities.Platforms.ZipMovers
{
    public sealed class EverestZipMoverColorsState : IOriginalZipMoverColors
    {
        public PackedColor RopeColor { get; } = PackedColor.FromHex("663931");

        public PackedColor RopeLightColor { get; } = PackedColor.FromHex("9b6157");
    }
}
