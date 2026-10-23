using System;
using Celeste.Game.Entities.Platforms.Wood;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IWoodPlatformScene
    {
        private IWoodPlatformAddedPolicy woodPlatformAddedPolicy;

        public void BindSourceWoodPlatformPolicy(IWoodPlatformAddedPolicy policy)
        {
            if (woodPlatformAddedPolicy != null)
                throw new InvalidOperationException("The actual Level wood platform policy is already bound.");
            woodPlatformAddedPolicy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        IWoodPlatformAddedPolicy IWoodPlatformScene.WoodPlatformAddedPolicy => woodPlatformAddedPolicy ??
                                                                               throw new InvalidOperationException(
                                                                                   "The actual Level wood platform policy has not been bound.");
    }
}
