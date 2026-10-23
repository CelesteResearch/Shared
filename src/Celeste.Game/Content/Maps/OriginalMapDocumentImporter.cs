using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Core.Maps;
using Celeste.Formats.Map;
using Celeste.Formats.Map.Binary;

namespace Celeste.Game.Content.Maps
{
    public static class OriginalMapDocumentImporter
    {
        public static MapDocument Read(string path) => Import(MapBinaryCodec.Read(path));
        public static MapDocument Read(Stream stream) => Import(MapBinaryCodec.Read(stream));

        public static MapDocument Import(MapBinaryData source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // Keep live tree/list identities: Everest processors can replace root containers after import.
            return new MapDocument(source.Package,
                () => source.Root.Child("levels")?.Children ?? Enumerable.Empty<MapElement>(),
                () => source.Root.Child("Filler")?.Children ?? new List<MapElement>(),
                () => source.Root.Child("Style"), source);
        }

        public static MapBinaryData GetSource(MapDocument map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            return map.SourceData as MapBinaryData ??
                   throw new InvalidOperationException(
                       "The document was not imported from the original binary format.");
        }
    }
}
