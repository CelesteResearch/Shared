using System.Numerics;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // Sound component view shared by the ported props that own a SoundSource.
    public interface IFarewellPropSound
    {
        bool ComponentPresent { get; }
        void Added();
        void Update(float deltaTime, float rawDeltaTime);
        void Play(string sound);
        void Play(string sound, Vector2 position);
        void Stop(bool fade = true);
        void UpdateSfxPosition(Vector2 position);
    }
}
