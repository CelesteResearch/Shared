using System;
using System.Numerics;
using Celeste.Game.Execution.Levels.Spawning;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private IOriginalLevelSpawnPolicy spawnPolicy;
        public Vector2 DefaultSpawnPoint => spawnPolicy.GetDefaultSpawnPoint(this);

        public void BindSourceSpawnPolicy(IOriginalLevelSpawnPolicy actualPolicy)
        {
            if (spawnPolicy != null) throw new InvalidOperationException("Source spawn policy is already bound.");
            spawnPolicy = actualPolicy ?? throw new ArgumentNullException(nameof(actualPolicy));
        }
    }
}
