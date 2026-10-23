using System.Collections;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public IEnumerator DummyWalkTo(float target, bool walkBackwards = false,
            float speedMultiplier = 1f, bool keepWalkingIntoWalls = false)
            => Dummy.WalkTo(target, walkBackwards, speedMultiplier, keepWalkingIntoWalls);

        public IEnumerator DummyWalkToExact(int target, bool walkBackwards = false,
            float speedMultiplier = 1f, bool cancelOnFall = false)
            => Dummy.WalkToExact(target, walkBackwards, speedMultiplier, cancelOnFall);

        public void Drop() => Holding.Drop();
        public void Throw() => Holding.Throw();
    }
}
