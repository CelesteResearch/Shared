using System;

namespace Celeste.Core.Components.Rendering
{
    public class BeforeRenderCallbackComponentState(Action callback) : SourceComponentState(false, true)
    {
        public Action Callback = callback;
    }
}
