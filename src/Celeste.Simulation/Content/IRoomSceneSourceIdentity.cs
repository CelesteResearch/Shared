using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    // A Scene source ledger uses names; persistent map entities use typed identities.
    // Hosts provide the content format's naming rule once per chapter.
    public interface IRoomSceneSourceIdentity
    {
        MapEntityId EntityId(MapElement room, MapElement source);
        MapEntityId EntityId(string roomName, MapElement source);
        MapEntityId ListedEntityId(string roomName, int entityId);
        MapEntityId LiteralEntityId(string levelName, MapElement source);
        string RoomPrefix(MapElement room);
        string EntityKey(MapElement room, MapElement source);
        string EntityKey(string roomName, MapElement source);
        string EntityKeyFromPrefix(string roomPrefix, MapElement source);
        string ListedEntityKey(string roomName, string entityId);
        string LiteralEntityKey(string levelName, MapElement source);
        string DecorLoopKey(MapElement room, MapElement source, string slot);
        string GeneratedClutterKey(MapElement room);
        string GeneratedClutterKeyFromPrefix(string roomPrefix);
        string DecalKeyFromPrefix(string roomPrefix, string layer, MapElement source);
        string PlayerKeyFromPrefix(string roomPrefix);
        string DecalSolidKeyFromPrefix(string roomPrefix);
    }
}
