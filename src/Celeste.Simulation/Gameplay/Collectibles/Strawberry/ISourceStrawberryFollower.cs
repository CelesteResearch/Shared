using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Scene.Following;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface ISourceStrawberryFollower : ISourceEntityPosition
    {
        bool Golden { get; }
        bool Winged { get; }
        MapEntityId ID { get; }
        FollowerState Follower { get; }
    }
}
