using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Game.Entities.Platforms.ZipMovers;

namespace Celeste.Everest.Entities.Platforms.ZipMovers
{
    public sealed class EverestZipMoverColorsState : IOriginalZipMoverColors
    {
        private PackedColor ropeColor = PackedColor.FromHex("663931");
        private PackedColor ropeLightColor = PackedColor.FromHex("9b6157");
        public PackedColor RopeColor => ropeColor;
        public PackedColor RopeLightColor => ropeLightColor;
    }
}
