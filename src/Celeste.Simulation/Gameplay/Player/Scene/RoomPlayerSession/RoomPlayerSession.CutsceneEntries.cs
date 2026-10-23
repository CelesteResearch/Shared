using System.Collections;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public IEnumerator DummyWalkTo(float target, bool walkBackwards = false,
            float speedMultiplier = 1f, bool keepWalkingIntoWalls = false)
        {
            return Dummy.WalkTo(target, walkBackwards, speedMultiplier, keepWalkingIntoWalls);
        }

        public IEnumerator DummyWalkToExact(int target, bool walkBackwards = false,
            float speedMultiplier = 1f, bool cancelOnFall = false)
        {
            return Dummy.WalkToExact(target, walkBackwards, speedMultiplier, cancelOnFall);
        }

        public void Drop()
        {
            Holding.Drop();
        }

        public void Throw()
        {
            Holding.Throw();
        }
    }
}
