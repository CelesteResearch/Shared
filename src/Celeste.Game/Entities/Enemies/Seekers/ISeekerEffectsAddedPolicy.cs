using System;

namespace Celeste.Game.Entities.Enemies.Seekers
{
    public interface ISeekerEffectsAddedPolicy
    {
        void Added(object actualScene, Action baseAdded);
    }
}
