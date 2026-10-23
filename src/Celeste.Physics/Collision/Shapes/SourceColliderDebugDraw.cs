using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Physics.Collision.Shapes
{
    internal static class SourceColliderDebugDraw
    {
        public static void HollowRect(ISourceRenderContext context, object entity, float x, float y, float width,
            float height, Vector4 color)
        {
            int rx = (int)x, ry = (int)y, rw = (int)width, rh = 1;
            Emit(context, entity, rx, ry, rw, rh, color);
            ry += (int)height - 1;
            Emit(context, entity, rx, ry, rw, rh, color);
            ry -= (int)height - 1;
            rw = 1;
            rh = (int)height;
            Emit(context, entity, rx, ry, rw, rh, color);
            rx += (int)width - 1;
            Emit(context, entity, rx, ry, rw, rh, color);
        }

        private static void Emit(ISourceRenderContext context, object entity, int x, int y, int width, int height,
            Vector4 color)
        {
            var command = new SourceDebugRectangle(x, y, width, height, color);
            ((ISourceRenderCommandSink<SourceDebugRectangle>)context).Draw(in command, entity);
        }
    }
}
