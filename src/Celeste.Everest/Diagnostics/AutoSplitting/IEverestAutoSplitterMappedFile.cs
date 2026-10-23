using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    public interface IEverestAutoSplitterMappedFile : IDisposable
    {
        IEverestAutoSplitterMemoryManager CreateMemoryManager();
    }
}
