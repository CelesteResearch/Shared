using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterClassicMinigameScenePicoConsole(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PicoConsole",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterClassicMinigameSceneUnlockedPico8Message(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.UnlockedPico8Message",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
