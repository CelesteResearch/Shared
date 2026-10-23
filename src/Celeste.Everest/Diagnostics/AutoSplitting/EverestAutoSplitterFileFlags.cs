using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    [Flags]
    public enum EverestAutoSplitterFileFlags : uint
    {
        IsDebug = 1,
        AssistMode = 2,
        VariantsMode = 4,
        StartingNewFile = 0x40000000,
        FileActive = 0x80000000,
    }
}
