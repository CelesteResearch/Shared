namespace Celeste.Core.Diagnostics
{
    public interface ISourceSceneDiagnostics
    {
        int EntityCount { get; }
        int GetTagCount(int tagIndex);
        void LogEntities(ISourceObjectLog output);
        void LogComponents(ISourceObjectLog output);
    }
}
