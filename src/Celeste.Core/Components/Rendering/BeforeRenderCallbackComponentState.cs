using System;

namespace Celeste.Core.Components.Rendering
{
    public class BeforeRenderCallbackComponentState : SourceComponentState
    {
        public Action Callback;

        public BeforeRenderCallbackComponentState(Action callback) : base(false, true)
        {
            Callback = callback;
        }
    }
}
