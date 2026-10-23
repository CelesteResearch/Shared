using Celeste.Core.Display;

namespace Celeste.Game.Editor
{
    public abstract class LevelTemplateColorsState
    {
        public abstract PackedColor BgTilesColor { get; }
        public abstract PackedColor[] FgTilesColor { get; }
        public abstract PackedColor InactiveBorderColor { get; }
        public abstract PackedColor SelectedBorderColor { get; }
        public abstract PackedColor HoveredBorderColor { get; }
        public abstract PackedColor DummyBgTilesColor { get; }
        public abstract PackedColor DummyFgTilesColor { get; }
        public abstract PackedColor DummyInactiveBorderColor { get; }
        public abstract PackedColor FirstBorderColor { get; }
    }
}
