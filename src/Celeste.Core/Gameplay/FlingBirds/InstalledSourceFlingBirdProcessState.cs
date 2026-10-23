using System.Numerics;

namespace Celeste.Core.Gameplay.FlingBirds
{
    public sealed class InstalledSourceFlingBirdProcessState : SourceFlingBirdProcessState
    {
        public Vector2 SourceFlingSpeed = new(380f, -100f);
        public override Vector2 FlingSpeed => SourceFlingSpeed;
    }
}
