using System;

namespace Celeste.Core.Components.Rendering
{
    public sealed class CustomBloomCallbackComponentState : SourceComponentState, IBloomCallback
    {
        public Action OnRenderBloom;

        public CustomBloomCallbackComponentState(Action onRenderBloom) : base(false, true)
        {
            OnRenderBloom = onRenderBloom;
        }

        bool IBloomCallback.Visible => Visible;
        Action IBloomCallback.OnRenderBloom => OnRenderBloom;
    }
}
