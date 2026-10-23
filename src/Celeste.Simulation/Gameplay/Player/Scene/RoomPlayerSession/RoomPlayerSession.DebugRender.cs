using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceEntityDebugRender
    {
        public override void DebugRender(ISourceRenderContext context, object actualCamera)
        {
            base.DebugRender(context, actualCamera);
            var collider = Collider;
            Collider = Hurtbox;
            SourcePrimitiveDrawing.HollowRect(context, this,
                Collider.AbsoluteLeft, Collider.AbsoluteTop, Collider.Width, Collider.Height, PackedColor.Lime);
            Collider = collider;
        }
    }
}
