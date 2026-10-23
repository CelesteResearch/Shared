using Celeste.Core.Display;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public sealed class MoveBlockVisuals
    {
        public static MoveBlockVisuals Default { get; } = new("objects/moveBlock", -1,
            MoveBlockState.IdleColor, MoveBlockState.MovingColor, MoveBlockState.BreakingColor,
            MoveBlockState.IdleColor);

        public string SpritePath { get; }
        public string BrokenIconPath { get; }
        public int Depth { get; }
        public PackedColor IdleColor { get; }
        public PackedColor MovingColor { get; }
        public PackedColor BreakingColor { get; }
        public PackedColor InitialFillColor { get; }

        public MoveBlockVisuals(string spritePath, int depth, PackedColor idleColor, PackedColor movingColor,
            PackedColor breakingColor, PackedColor initialFillColor)
        {
            SpritePath = spritePath;
            BrokenIconPath = spritePath + "/x";
            Depth = depth;
            IdleColor = idleColor;
            MovingColor = movingColor;
            BreakingColor = breakingColor;
            InitialFillColor = initialFillColor;
        }
    }
}
