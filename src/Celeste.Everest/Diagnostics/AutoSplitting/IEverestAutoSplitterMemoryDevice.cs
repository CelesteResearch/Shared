using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    public interface IEverestAutoSplitterMemoryDevice
    {
        IEverestAutoSplitterMappedFile CreateNew(string mapName, long capacity);
    }
}
