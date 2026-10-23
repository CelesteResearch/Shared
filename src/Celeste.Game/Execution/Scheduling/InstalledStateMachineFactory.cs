using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Scheduling
{
    public sealed class InstalledStateMachineFactory : ISourceStateMachineFactory
    {
        public SimulationStateMachine Create(ISourceEngineContext engine, int maxStates = 10)
        {
            return new NamedSimulationStateMachine(engine, maxStates);
        }
    }
}
