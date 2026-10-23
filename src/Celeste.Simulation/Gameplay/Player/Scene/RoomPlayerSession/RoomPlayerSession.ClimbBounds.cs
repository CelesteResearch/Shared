using Celeste.Scene.Geometry;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool ClimbBoundsCheck(int direction)
        {
            if (Left + unchecked(direction * 2) >= ((ISourceSceneBounds)Level).Bounds.Left)
                return Right + unchecked(direction * 2) < ((ISourceSceneBounds)Level).Bounds.Right;
            return false;
        }
    }
}
