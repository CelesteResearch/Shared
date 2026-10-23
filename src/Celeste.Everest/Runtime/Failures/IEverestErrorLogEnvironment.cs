using Celeste.Game.Execution.Diagnostics;

namespace Celeste.Everest.Runtime.Failures
{
    public interface IEverestErrorLogEnvironment : IOriginalErrorLogEnvironment
    {
        string Platform { get; }
        string BaseDirectory { get; }
        string VersionCelesteString { get; }
        string GetEnvironmentVariable(string name);
        string GetPrefPath(string organization, string application);
        EverestCoreSettings Settings { get; }
        bool IsHeadless { get; }
    }
}
