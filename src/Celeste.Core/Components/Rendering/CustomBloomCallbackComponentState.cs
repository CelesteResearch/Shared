using System;

namespace Celeste.Core.Components.Rendering
{
    public sealed class CustomBloomCallbackComponentState(Action onRenderBloom)
        : SourceComponentState(false, true), IBloomCallback
    {
        public Action OnRenderBloom = onRenderBloom;
        bool IBloomCallback.Visible => Visible;

        Action IBloomCallback.OnRenderBloom => OnRenderBloom;
    }
}
