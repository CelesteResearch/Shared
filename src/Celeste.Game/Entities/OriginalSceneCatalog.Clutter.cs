using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterClutterSceneClutterAbsorbEffect(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ClutterAbsorbEffect",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.ClutterBlock",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.ClutterBlockBase",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.ClutterCabinet",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.ClutterCabinet" }), true);
            result.Register(
                new SceneEntityType("Celeste.ClutterDoor",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.ClutterSwitch",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }
    }
}
