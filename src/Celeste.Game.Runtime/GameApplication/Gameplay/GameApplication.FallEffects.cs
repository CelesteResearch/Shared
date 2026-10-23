using Celeste.Game.Entities.StarJump;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFallEffectsEnvironment
    {
        private readonly OriginalFallEffectsProcessState sourceFallEffectsProcess = new();
        public OriginalFallEffectsProcessState FallEffectsProcess => sourceFallEffectsProcess;
    }
}
