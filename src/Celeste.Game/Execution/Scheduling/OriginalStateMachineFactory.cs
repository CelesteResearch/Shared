using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Scheduling
{
    public sealed class OriginalStateMachineFactory : ISourceStateMachineFactory
    {
        public SimulationStateMachine Create(ISourceEngineContext engine, int maxStates = 10)
        {
            return new(engine, maxStates);
        }
    }
}
