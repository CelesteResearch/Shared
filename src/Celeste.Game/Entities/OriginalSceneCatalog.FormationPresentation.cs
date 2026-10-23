using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterFormationPresentationSceneFormationBackdrop(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FormationBackdrop",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
