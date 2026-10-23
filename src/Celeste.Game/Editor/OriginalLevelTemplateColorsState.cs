using Celeste.Core.Display;

namespace Celeste.Game.Editor
{
    public sealed class OriginalLevelTemplateColorsState : LevelTemplateColorsState
    {
        public readonly PackedColor bgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor BgTilesColor => bgTilesColor;

        public readonly PackedColor[] fgTilesColor =
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
        public readonly PackedColor inactiveBorderColor = PackedColor.DarkSlateGray;
        public override PackedColor InactiveBorderColor => inactiveBorderColor;
        public readonly PackedColor selectedBorderColor = PackedColor.Red;
        public override PackedColor SelectedBorderColor => selectedBorderColor;
        public readonly PackedColor hoveredBorderColor = PackedColor.Yellow;
        public override PackedColor HoveredBorderColor => hoveredBorderColor;
        public readonly PackedColor dummyBgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor DummyBgTilesColor => dummyBgTilesColor;
        public readonly PackedColor dummyFgTilesColor = PackedColor.LightGray;
        public override PackedColor DummyFgTilesColor => dummyFgTilesColor;
        public readonly PackedColor dummyInactiveBorderColor = PackedColor.DarkOrange;
        public override PackedColor DummyInactiveBorderColor => dummyInactiveBorderColor;
        public readonly PackedColor firstBorderColor = PackedColor.Aqua;
        public override PackedColor FirstBorderColor => firstBorderColor;
    }
}
