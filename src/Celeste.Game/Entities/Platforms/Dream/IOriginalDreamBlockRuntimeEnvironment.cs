using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public interface IOriginalDreamBlockRuntimeEnvironment
    {
        IOriginalDreamBlockRuntimePolicy DreamBlockRuntimePolicy { get; }
        OriginalDreamBlockState CreateDreamBlock(EntityData data, Vector2 offset, OriginalLevelSceneRoot level);
    }
}
