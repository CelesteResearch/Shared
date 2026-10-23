using System.Numerics;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Entities.Decoration.Decals;

namespace Celeste.Game.Content.Maps.Levels
{
    public interface IOriginalLevelRoomDataExtensions
    {
        bool TrackableContains(BinaryPackerElement entity);
        void CheckForDefaultSpawn(OriginalLevelRoomData room, BinaryPackerElement entity, Vector2 spawn);
        void ReadDecalExtensions(BinaryPackerElement source, OriginalDecalPlacement decal);
        void CompleteConstruction(OriginalLevelRoomData room, BinaryPackerElement source);
    }
}
