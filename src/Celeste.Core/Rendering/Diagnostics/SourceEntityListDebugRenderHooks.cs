using System;

namespace Celeste.Core.Rendering.Diagnostics
{
    public sealed class SourceEntityListDebugRenderHooks
    {
        public event Action<object> BeforeDebugRender;
        public event Action<object, object> AfterDebugRender;

        public void InvokeAfterDebugRender(object actualEntityList, object actualCamera) =>
            AfterDebugRender?.Invoke(actualEntityList, actualCamera);

        public void InvokeBeforeDebugRender(object actualCamera) => BeforeDebugRender?.Invoke(actualCamera);
    }
}
