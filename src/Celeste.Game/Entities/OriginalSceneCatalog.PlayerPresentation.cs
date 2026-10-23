using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterPlayerPresentationSceneGrabbyIcon(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GrabbyIcon",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterPlayerPresentationScenePlayer(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName,
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName,
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
        }

        private static void RegisterPlayerPresentationScenePlayerDashAssist(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlayerDashAssist",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.PlayerDashAssist" }), true);
            result.Register(
                new SceneEntityType("Celeste.PlayerDeadBody",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.PlayerHair", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.PlayerHair" }), true);
        }

        private static void RegisterPlayerPresentationScenePlayerSprite(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlayerSprite",
                    new string[]
                        { "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
        }

        private static void RegisterPlayerPresentationSceneStaminaDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.StaminaDisplay", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }
    }
}
