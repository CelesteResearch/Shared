using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterTerrainAndTilesSceneAnimatedTiles(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AnimatedTiles", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterTerrainAndTilesSceneBackgroundTiles(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BackgroundTiles",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterTerrainAndTilesSceneBlockField(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BlockField",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterTerrainAndTilesSceneIceTileOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IceTileOverlay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterTerrainAndTilesSceneSolidTiles(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SolidTiles",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.SolidTiles", "Celeste.Solid", "Celeste.Platform" }), true);
        }
    }
}
