using System;

namespace Celeste.Core.Components.Rendering
{
    public interface IBloomCallback
    {
        bool Visible { get; }
        Action OnRenderBloom { get; }
    }
}
