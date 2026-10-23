using System;

namespace Celeste.Input.Runtime
{
    public interface ISourceWindowInputMetrics
    {
        IntPtr MouseWindowHandle { get; set; }
        IntPtr TouchWindowHandle { get; set; }
        int MouseWindowWidth { get; set; }
        int MouseWindowHeight { get; set; }
    }
}
