namespace Celeste.Core.Diagnostics.Commands
{
    public interface ISourceCommandsObservationEnvironment
    {
        void AfterSourceCommandsUpdateClosed();
        void AfterSourceCommandsRendered();
    }
}
