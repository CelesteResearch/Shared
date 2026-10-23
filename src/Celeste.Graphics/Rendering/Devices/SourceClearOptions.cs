using System;

namespace Celeste.Graphics.Rendering.Devices
{
    [Flags]
    public enum SourceClearOptions
    {
        Target = 1,
        DepthBuffer = 2,
        Stencil = 4,
    }
}
