using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHoldablesSceneGlider(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Glider",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
        }

        private static void RegisterHoldablesSceneTheoCrystal(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TheoCrystal",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        "Celeste.TheoCrystal",
                        typeof(SourceActorEntityState).FullName,
                    ]), true);
            result.Register(
                new("Celeste.TheoCrystalPedestal",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }
    }
}
