using Celeste.Core.Components;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public sealed class MoveBlockBorderState(MoveBlockState parent, ISourceEntitySourceDataRegistration sourceData)
        : MovingBlockBorderState(parent, sourceData);
}
