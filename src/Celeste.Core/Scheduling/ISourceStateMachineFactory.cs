namespace Celeste.Core.Scheduling
{
    public interface ISourceStateMachineFactory
    {
        SimulationStateMachine Create(ISourceEngineContext engine, int maxStates = 10);
    }
}
