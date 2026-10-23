using Celeste.Game.Entities.StarJump;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFallEffectsEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly OriginalFallEffectsProcessState sourceFallEffectsProcess = new();

        public OriginalFallEffectsProcessState FallEffectsProcess => sourceFallEffectsProcess;
    }
}
