using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterPlayerPresentationSceneGrabbyIcon(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GrabbyIcon",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterPlayerPresentationScenePlayer(SceneEntityCatalog result)
        {
            result.Register(
                new(typeof(RoomPlayerSession).FullName,
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(RoomPlayerSession).FullName,
                        typeof(SourceActorEntityState).FullName,
                    ]), true);
        }

        private static void RegisterPlayerPresentationScenePlayerDashAssist(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlayerDashAssist",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.PlayerDashAssist"]), true);
            result.Register(
                new("Celeste.PlayerDeadBody",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.PlayerHair", (string[])["Monocle.Component"],
                    (string[])["Celeste.PlayerHair"]), true);
        }

        private static void RegisterPlayerPresentationScenePlayerSprite(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlayerSprite",
                    (string[])["Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
        }

        private static void RegisterPlayerPresentationSceneStaminaDisplay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.StaminaDisplay", (string[])["Monocle.Component"], (string[])[]));
        }
    }
}
