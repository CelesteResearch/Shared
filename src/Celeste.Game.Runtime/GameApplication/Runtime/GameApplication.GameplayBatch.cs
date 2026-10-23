using System;
using Celeste.Game.Presentation.Rendering;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceGameplayBatchScopeEnvironment
    {
        private ISourceGameplayBatchScope sourceGameplayBatchScope;

        public ISourceGameplayBatchScope GameplayBatchScope => sourceGameplayBatchScope ??
                                                               throw new InvalidOperationException(
                                                                   "The actual gameplay batch scope is not constructed.");

        public void ConstructSourceGameplayBatchScope()
        {
            if (sourceGameplayBatchScope != null)
                throw new InvalidOperationException("The actual gameplay batch scope is already constructed.");
            sourceGameplayBatchScope = new OriginalGameplayBatchScope();
        }
    }
}
