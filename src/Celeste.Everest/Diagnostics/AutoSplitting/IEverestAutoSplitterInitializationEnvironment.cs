using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    public interface IEverestAutoSplitterInitializationEnvironment
    {
        Version CelesteVersion { get; }
        string EverestVersionString { get; }
    }
}
