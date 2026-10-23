using Celeste.Scene.Tracking;

namespace Celeste.Everest.Modules.Capabilities
{
    public interface ISourceCollabLobbyMaps
    {
        bool TryGetActiveWarps(ISourceScene scene, out string[] activeWarps);
        void ClearLobbyMap(string sid);
    }
}
