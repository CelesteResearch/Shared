using System;
using System.Collections.Generic;

namespace Celeste.Core.Maps
{
    // Explicit domain views. SourceData is opaque importer provenance, never a runtime schema decoder.
    public sealed class MapDocument
    {
        private readonly Func<IEnumerable<MapElement>> _rooms;
        private readonly Func<IEnumerable<MapElement>> _fillers;
        private readonly Func<MapElement> _style;
        public string Package { get; }
        public object SourceData { get; }
        public int AreaID { get; private set; } = -1;
        public IEnumerable<MapElement> Rooms => _rooms();
        public IEnumerable<MapElement> Fillers => _fillers();
        public MapElement Style => _style();

        public MapDocument(string package, Func<IEnumerable<MapElement>> rooms,
            Func<IEnumerable<MapElement>> fillers, Func<MapElement> style, object sourceData = null)
        {
            Package = package;
            _rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            _fillers = fillers ?? throw new ArgumentNullException(nameof(fillers));
            _style = style ?? throw new ArgumentNullException(nameof(style));
            SourceData = sourceData;
        }

        public void BindAreaID(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            AreaID = id;
        }
    }
}
