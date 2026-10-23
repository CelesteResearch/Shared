using System;
using Celeste.Game.Entities.Enemies.Seekers;

namespace Celeste.Everest.Entities.Enemies.Seekers
{
    public sealed class EverestSeekerEffectsAddedPolicy : ISeekerEffectsAddedPolicy
    {
        public static EverestSeekerEffectsAddedPolicy Shared { get; } = new();

        public void Added(object actualScene, Action baseAdded)
        {
            baseAdded();
        }
    }
}
