using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterClassicMinigameScenePicoConsole(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PicoConsole",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterClassicMinigameSceneUnlockedPico8Message(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.UnlockedPico8Message",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
