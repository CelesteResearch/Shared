using Celeste.Core.Display;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Diagnostics;
using Celeste.Scene.Entities;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

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
