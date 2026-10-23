using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.Platforms.ZipMovers
{
    public sealed class OriginalZipMoverColorsState : IOriginalZipMoverColors
    {
        private readonly PackedColor ropeColor = PackedColor.FromHex("663931");
        private readonly PackedColor ropeLightColor = PackedColor.FromHex("9b6157");
        public PackedColor RopeColor => ropeColor;
        public PackedColor RopeLightColor => ropeLightColor;
    }
}
