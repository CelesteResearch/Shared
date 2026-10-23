using Celeste.Scene.Geometry;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool ClimbBoundsCheck(int direction)
        {
            if (Left + (float)unchecked(direction * 2) >= (float)((ISourceSceneBounds)Level).Bounds.Left)
                return Right + (float)unchecked(direction * 2) < (float)((ISourceSceneBounds)Level).Bounds.Right;
            return false;
        }
    }
}
