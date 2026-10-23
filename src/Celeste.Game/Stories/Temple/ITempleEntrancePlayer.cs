using System.Numerics;

namespace Celeste.Game.Stories.Temple
{
    public interface ITempleEntrancePlayer
    {
        Vector2 Position { get; set; }
        int State { get; set; }
        int Facing { get; set; }
        bool Locked { get; set; }
        bool ForceCameraUpdate { get; set; }
    }
}
