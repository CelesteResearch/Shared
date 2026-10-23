using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    public interface IEverestAutoSplitterMemoryManager
    {
        Memory<byte> Memory { get; }
        IntPtr GetAddress(int offset);
    }
}
