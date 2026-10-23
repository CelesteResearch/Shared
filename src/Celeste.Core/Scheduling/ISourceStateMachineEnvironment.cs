namespace Celeste.Core.Scheduling
{
    public interface ISourceStateMachineEnvironment
    {
        ISourceStateMachineFactory StateMachines { get; }
    }
}
