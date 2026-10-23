using Celeste.Core.Display;
using Celeste.Game.Editor;

namespace Celeste.Everest.Editor
{
    public sealed class EverestLevelTemplateColorsState : LevelTemplateColorsState
    {
        public PackedColor bgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor BgTilesColor => bgTilesColor;

        public PackedColor[] fgTilesColor =
        [
            PackedColor.White,
            PackedColor.FromHex("f6735e"),
            PackedColor.FromHex("85f65e"),
            PackedColor.FromHex("37d7e3"),
            PackedColor.FromHex("376be3"),
            PackedColor.FromHex("c337e3"),
            PackedColor.FromHex("e33773"),
        ];

        public override PackedColor[] FgTilesColor => fgTilesColor;
        public PackedColor inactiveBorderColor = PackedColor.DarkSlateGray;
        public override PackedColor InactiveBorderColor => inactiveBorderColor;
        public PackedColor selectedBorderColor = PackedColor.Red;
        public override PackedColor SelectedBorderColor => selectedBorderColor;
        public PackedColor hoveredBorderColor = PackedColor.Yellow;
        public override PackedColor HoveredBorderColor => hoveredBorderColor;
        public PackedColor dummyBgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor DummyBgTilesColor => dummyBgTilesColor;
        public PackedColor dummyFgTilesColor = PackedColor.LightGray;
        public override PackedColor DummyFgTilesColor => dummyFgTilesColor;
        public PackedColor dummyInactiveBorderColor = PackedColor.DarkOrange;
        public override PackedColor DummyInactiveBorderColor => dummyInactiveBorderColor;
        public PackedColor firstBorderColor = PackedColor.Aqua;
        public override PackedColor FirstBorderColor => firstBorderColor;
    }
}
