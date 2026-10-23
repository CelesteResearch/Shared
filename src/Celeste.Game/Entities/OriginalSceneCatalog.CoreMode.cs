using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCoreModeSceneCoreMessage(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CoreMessage",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CoreModeListener", (string[])["Monocle.Component"],
                    (string[])["Celeste.CoreModeListener"]), true);
            result.Register(
                new("Celeste.CoreModeToggle",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
