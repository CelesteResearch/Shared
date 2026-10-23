using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMountainPresentationSceneMaddy3D(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Maddy3D",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterMountainPresentationSceneMoonParticle3D(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MoonParticle3D",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.MoonParticle3D.Particle",
                    new string[] { "Celeste.Billboard", "Monocle.Component" }, new string[] { "Celeste.Billboard" }),
                false);
        }

        private static void RegisterMountainPresentationSceneSnow3D(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Snow3D",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Snow3D.Particle",
                    new string[] { "Celeste.Billboard", "Monocle.Component" },
                    new string[] { "Celeste.Snow3D.Particle", "Celeste.Billboard" }), true);
        }
    }
}
