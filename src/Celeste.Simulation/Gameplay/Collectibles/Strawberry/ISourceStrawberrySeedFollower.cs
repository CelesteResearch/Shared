using Celeste.Scene.Following;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface ISourceStrawberrySeedFollower
    {
        FollowerState Follower { get; }
        bool Collected { get; }
    }
}
