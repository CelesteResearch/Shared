namespace Celeste.Core.Diagnostics
{
    public interface ISourceFnaLoggingDevice
    {
        void HookLogFunctions(SourceFnaLogFunction info, SourceFnaLogFunction warning,
            SourceFnaLogFunction error);
    }
}
