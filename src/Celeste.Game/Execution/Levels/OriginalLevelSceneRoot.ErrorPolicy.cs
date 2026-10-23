using System;
using Celeste.Game.Execution.Levels.Update;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private IOriginalLevelErrorPolicy sourceErrorPolicy;

        public void BindSourceErrorPolicy(IOriginalLevelErrorPolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));
            if (sourceErrorPolicy != null)
                throw new InvalidOperationException("The actual Level error policy is already bound.");
            sourceErrorPolicy = policy;
        }

        public bool CheckForErrors()
            => (sourceErrorPolicy ?? throw new InvalidOperationException("The actual Level error policy is not bound."))
                .CheckForErrors(Session);
    }
}
