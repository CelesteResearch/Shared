using Celeste.Core.Display;

namespace Celeste.Game.Entities.Platforms.ZipMovers
{
    public sealed class OriginalZipMoverColorsState : IOriginalZipMoverColors
    {
        public PackedColor RopeColor { get; } = PackedColor.FromHex("663931");

        public PackedColor RopeLightColor { get; } = PackedColor.FromHex("9b6157");
    }
}
