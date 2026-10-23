using Celeste.Graphics.Display;
using Celeste.Simulation.Presentation.Geometry;

namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    // Commands retain the owning EntityList entry and the order in which that
    // entity's Render method emitted them. Depth is diagnostic, not a sort key:
    // EntityList already established the render sequence before this is built.
    public readonly struct RoomDrawCommand
    {
        public readonly RoomDrawCommandKind Kind;
        public readonly object EntityIdentity;
        public readonly double ActualDepth;
        public readonly int EntityOrdinal;
        public readonly ImagePlacement Image;
        public readonly ColoredGeometry Geometry;
        public readonly TexturedGeometry TexturedGeometry;

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            RoomDrawCommandKind kind)
        {
            Kind = kind;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = default;
            Geometry = null;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            ImagePlacement image)
        {
            Kind = RoomDrawCommandKind.Image;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = image;
            Geometry = null;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            ColoredGeometry geometry)
        {
            Kind = RoomDrawCommandKind.ColoredGeometry;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = default;
            Geometry = geometry;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            RoomDrawCommandKind kind,
            ColoredGeometry geometry)
        {
            Kind = kind;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = default;
            Geometry = geometry;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            RoomDrawCommandKind kind,
            TexturedGeometry geometry)
        {
            Kind = kind;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = default;
            Geometry = null;
            TexturedGeometry = geometry;
        }
    }
}
