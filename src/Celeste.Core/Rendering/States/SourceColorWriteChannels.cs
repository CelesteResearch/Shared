using System;

namespace Celeste.Core.Rendering.States
{
    [Flags]
    public enum SourceColorWriteChannels
    {
        None = 0,
        Red = 1,
        Green = 2,
        Blue = 4,
        Alpha = 8,
        All = 0xF
    }
}
