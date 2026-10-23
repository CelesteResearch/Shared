using System;

namespace Celeste.Core.Rendering.Diagnostics
{
    public interface ISourceCycleHitboxPhase
    {
        void BeforeUpdate(object actualScene, Action originalBeforeUpdate);
        void Begin(Action originalLevelBegin);
        bool TryDebugRender(object actualEntity, object actualCamera, ISourceRenderContext context);
    }
}
