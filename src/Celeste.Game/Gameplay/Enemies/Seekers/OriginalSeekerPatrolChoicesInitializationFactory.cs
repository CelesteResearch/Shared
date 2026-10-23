using Celeste.Core.Threading;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public sealed class
        OriginalSeekerPatrolChoicesInitializationFactory : ISourceTypeInitializationFactory<SeekerPatrolPoint[]>
    {
        public SeekerPatrolPoint[] Allocate() => new SeekerPatrolPoint[3];

        public void Initialize(SeekerPatrolPoint[] instance)
        {
        }
    }
}
