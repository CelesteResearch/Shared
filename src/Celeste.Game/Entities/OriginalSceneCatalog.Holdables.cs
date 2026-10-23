using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterHoldablesSceneGlider(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Glider",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
        }

        private static void RegisterHoldablesSceneTheoCrystal(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TheoCrystal",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        "Celeste.TheoCrystal",
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
            result.Register(
                new SceneEntityType("Celeste.TheoCrystalPedestal",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }
    }
}
