using System.Numerics;

namespace Celeste.Core.Rendering
{
    public interface ISourceRenderTargetContext : ISourceRenderContext
    {
        object CurrentTarget { get; }
        void SetTarget(object target);
        void Clear(Vector4 clear);
        void SetTargetAndClear(object target, Vector4 clear);
    }
}
