namespace Celeste.Simulation
{
    public interface INpcComponent
    {
        bool Active { get; }
        void Update(float dt, float rawDt);
    }
}
