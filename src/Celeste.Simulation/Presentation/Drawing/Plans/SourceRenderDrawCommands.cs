using Celeste.Graphics.Display;
using Celeste.Simulation.Presentation.Geometry;

namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    public static class SourceRenderDrawCommands
    {
        public static RoomDrawCommand Image(object entity, in ImagePlacement value)
        {
            return new(entity, 0, 0, value);
        }

        public static RoomDrawCommand Colored(object entity, ColoredGeometry value)
        {
            return new(entity, 0, 0, value);
        }

        public static RoomDrawCommand Textured(object entity,
            TexturedGeometry value)
        {
            return new(entity, 0, 0, RoomDrawCommandKind.DeferredTexturedVertices, value);
        }
    }
}
