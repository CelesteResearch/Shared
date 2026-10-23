using Celeste.Core.Display;

namespace Celeste.Game.Entities.StarJump
{
    public sealed class OriginalFallEffectsProcessState
    {
        public readonly PackedColor[] Colors = [PackedColor.White, PackedColor.LightGray];
        public readonly PackedColor[] Faded = new PackedColor[2];
        public float SpeedMultiplier = 1f;
    }
}
