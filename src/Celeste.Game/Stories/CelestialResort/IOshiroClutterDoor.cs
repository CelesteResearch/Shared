using System.Collections;
using System.Numerics;

namespace Celeste.Game.Stories.CelestialResort
{
    public interface IOshiroClutterDoor
    {
        Vector2 Position { get; }
        bool IsLocked { get; }
        IEnumerator UnlockRoutine();
        void InstantUnlock();
    }
}
