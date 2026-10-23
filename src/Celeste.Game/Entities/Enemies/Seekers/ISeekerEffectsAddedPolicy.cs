using System;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Enemies.Seekers
{
    public interface ISeekerEffectsAddedPolicy
    {
        void Added(object actualScene, Action baseAdded);
    }
}
