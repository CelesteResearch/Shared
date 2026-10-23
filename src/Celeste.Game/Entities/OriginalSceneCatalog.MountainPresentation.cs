using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMountainPresentationSceneMaddy3D(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Maddy3D",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMountainPresentationSceneMoonParticle3D(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MoonParticle3D",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.MoonParticle3D.Particle",
                    (string[])["Celeste.Billboard", "Monocle.Component"], (string[])["Celeste.Billboard"]));
        }

        private static void RegisterMountainPresentationSceneSnow3D(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Snow3D",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Snow3D.Particle",
                    (string[])["Celeste.Billboard", "Monocle.Component"],
                    (string[])["Celeste.Snow3D.Particle", "Celeste.Billboard"]), true);
        }
    }
}
