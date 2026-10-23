using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    // Commands retain the owning EntityList entry and the order in which that
    // entity's Render method emitted them. Depth is diagnostic, not a sort key:
    // EntityList already established the render sequence before this is built.
    public readonly struct RoomDrawCommand
    {
        public readonly global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind Kind;
        public readonly object EntityIdentity;
        public readonly double ActualDepth;
        public readonly int EntityOrdinal;
        public readonly global::Celeste.Graphics.Display.ImagePlacement Image;
        public readonly global::Celeste.Graphics.Display.ColoredGeometry Geometry;
        public readonly global::Celeste.Simulation.Presentation.Geometry.TexturedGeometry TexturedGeometry;

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind kind)
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
            global::Celeste.Graphics.Display.ImagePlacement image)
        {
            Kind = global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind.Image;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = image;
            Geometry = null;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            global::Celeste.Graphics.Display.ColoredGeometry geometry)
        {
            Kind = global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind.ColoredGeometry;
            EntityIdentity = identity;
            ActualDepth = actualDepth;
            EntityOrdinal = ordinal;
            Image = default;
            Geometry = geometry;
            TexturedGeometry = null;
        }

        internal RoomDrawCommand(object identity, double actualDepth, int ordinal,
            global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind kind,
            global::Celeste.Graphics.Display.ColoredGeometry geometry)
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
            global::Celeste.Simulation.Presentation.Drawing.Plans.RoomDrawCommandKind kind,
            global::Celeste.Simulation.Presentation.Geometry.TexturedGeometry geometry)
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
