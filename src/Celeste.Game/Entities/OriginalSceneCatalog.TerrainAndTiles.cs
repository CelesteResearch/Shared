using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterTerrainAndTilesSceneAnimatedTiles(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AnimatedTiles", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterTerrainAndTilesSceneBackgroundTiles(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BackgroundTiles",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTerrainAndTilesSceneBlockField(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BlockField",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTerrainAndTilesSceneIceTileOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IceTileOverlay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTerrainAndTilesSceneSolidTiles(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SolidTiles",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.SolidTiles", "Celeste.Solid", "Celeste.Platform"]), true);
        }
    }
}
