using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCoreModeSceneCoreMessage(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CoreMessage",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CoreModeListener", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.CoreModeListener" }), true);
            result.Register(
                new SceneEntityType("Celeste.CoreModeToggle",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
