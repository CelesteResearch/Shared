namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    public static class SourceRenderDrawCommands
    {
        public static RoomDrawCommand Image(object entity, in global::Celeste.Graphics.Display.ImagePlacement value)
            => new RoomDrawCommand(entity, 0, 0, value);

        public static RoomDrawCommand Colored(object entity, global::Celeste.Graphics.Display.ColoredGeometry value)
            => new RoomDrawCommand(entity, 0, 0, value);

        public static RoomDrawCommand Textured(object entity,
            global::Celeste.Simulation.Presentation.Geometry.TexturedGeometry value)
            => new RoomDrawCommand(entity, 0, 0, RoomDrawCommandKind.DeferredTexturedVertices, value);
    }
}
