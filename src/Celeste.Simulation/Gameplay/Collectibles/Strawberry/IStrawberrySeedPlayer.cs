using System.Numerics;
using Celeste.Scene.Following;

namespace Celeste.Simulation.Gameplay.Collectibles.Strawberry
{
    public interface IStrawberrySeedPlayer
    {
        LeaderState Leader { get; }
        bool LoseShards { get; }
        Vector2 Speed { get; }
    }
}
