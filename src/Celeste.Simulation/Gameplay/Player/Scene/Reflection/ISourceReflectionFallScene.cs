using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Player.Scene.Reflection
{
    public interface ISourceReflectionFallScene
    {
        string ReflectionFallLevelSet { get; }
        bool OnReflectionFallInterval(float interval);
        bool CheckReflectionFallWater(RoomPlayerSession player);
        void ShowReflectionFallEffects(bool visible);
        void RemoveReflectionFallFeathers();
        void DestroyReflectionFallSpinner(IntRect rectangle);
        void StartReflectionFallCutscene(RoomPlayerSession player);
        void EndReflectionFallCutscene();
        void ApplyReflectionFallMusic();
    }
}
