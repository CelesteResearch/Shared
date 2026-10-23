using System;

namespace Celeste.Input.Runtime
{
    public interface ISourceGraphicsDeviceInputMetrics
    {
        int MouseBackBufferWidth { get; set; }
        int MouseBackBufferHeight { get; set; }
        int TouchDisplayWidth { get; set; }
        int TouchDisplayHeight { get; set; }
    }
}
