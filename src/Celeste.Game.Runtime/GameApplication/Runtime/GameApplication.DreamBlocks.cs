using System.Numerics;
using Celeste.Everest.Gameplay.Platforms.Dream;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalDreamBlockRuntimeEnvironment
    {
        private IOriginalDreamBlockRuntimePolicy sourceDreamBlockRuntimePolicy;

        public IOriginalDreamBlockRuntimePolicy DreamBlockRuntimePolicy
            => sourceDreamBlockRuntimePolicy ??= SourceProfile == GameProfile.Original
                ? new OriginalDreamBlockRuntimePolicy(this)
                : new InstalledDreamBlockRuntimePolicy();

        public OriginalDreamBlockState CreateDreamBlock(EntityData data, Vector2 offset,
            OriginalLevelSceneRoot level)
        {
            return SourceProfile == GameProfile.Original
                ? OriginalDreamBlockState.CreateFromMapData(data, offset, level)
                : EverestDreamBlockState.CreateFromMapData(data, offset, level);
        }
    }
}
