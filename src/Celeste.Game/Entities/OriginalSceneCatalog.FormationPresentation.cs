using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterFormationPresentationSceneFormationBackdrop(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FormationBackdrop",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
