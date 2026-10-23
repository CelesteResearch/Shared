using System;
using System.Collections.Generic;

namespace Celeste.Core.Maps
{
    // Explicit domain views. SourceData is opaque importer provenance, never a runtime schema decoder.
    public sealed class MapDocument
    {
        private readonly Func<IEnumerable<MapElement>> rooms;
        private readonly Func<IEnumerable<MapElement>> fillers;
        private readonly Func<MapElement> style;
        public string Package { get; }
        public object SourceData { get; }
        public int AreaID { get; private set; } = -1;
        public IEnumerable<MapElement> Rooms => rooms();
        public IEnumerable<MapElement> Fillers => fillers();
        public MapElement Style => style();

        public MapDocument(string package, Func<IEnumerable<MapElement>> rooms,
            Func<IEnumerable<MapElement>> fillers, Func<MapElement> style, object sourceData = null)
        {
            Package = package;
            this.rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            this.fillers = fillers ?? throw new ArgumentNullException(nameof(fillers));
            this.style = style ?? throw new ArgumentNullException(nameof(style));
            SourceData = sourceData;
        }

        public void BindAreaID(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            AreaID = id;
        }
    }
}
