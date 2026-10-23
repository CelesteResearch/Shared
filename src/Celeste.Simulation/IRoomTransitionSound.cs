namespace Celeste.Simulation
{
    public interface IRoomTransitionSound
    {
        bool DisposeOnTransition { get; }
        void Stop();
    }
}
