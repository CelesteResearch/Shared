using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterClutterSceneClutterAbsorbEffect(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ClutterAbsorbEffect",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ClutterBlock",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ClutterBlockBase",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.ClutterCabinet",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.ClutterCabinet"]), true);
            result.Register(
                new("Celeste.ClutterDoor",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.ClutterSwitch",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }
    }
}
