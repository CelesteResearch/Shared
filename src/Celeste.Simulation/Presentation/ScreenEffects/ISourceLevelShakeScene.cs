using System.Numerics;

namespace Celeste.Simulation.Presentation.ScreenEffects
{
    public interface ISourceLevelShakeScene
    {
        void Shake(float time = .3f);
        void DirectionalShake(Vector2 direction, float time = .3f);
        void StopShake();
    }
}
