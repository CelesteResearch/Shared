namespace Celeste.Simulation.Rendering
{
    public interface IMapMachineSound
    {
        bool Playing { get; }
        void Added();
        void Update(float dt, float rawDt);
        void Play(string name);
        void Param(string name, float value);
        void Stop(bool allowFadeout = true);
        void Release(); // EventInstance.release()
        void RemoveSelf(); // Component.RemoveSelf (PicoConsole.SceneEnd)
    }
}
