using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Maps.Grids;
using Celeste.Core.Randomness;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceLevelTileBoundsScene
    {
        public OriginalBackgroundTiles BgTiles;
        public OriginalSolidTiles SolidTiles;
        public VirtualMap<char> BgData;
        public VirtualMap<char> SolidsData;
        public IntRect TileBounds => ((OriginalChapterMapData)Session.MapData).TileBounds;

        public void ConstructSourceIceTileOverlay()
        {
            Scheduler.QueueSourceEntity(new OriginalIceTileOverlayState(EngineContext));
        }

        public (OriginalBackgroundTiles BackgroundTiles, OriginalSolidTiles SolidTiles, Vector2 Position)
            ConstructSourceTerrain(
                IntRect tileBounds, OriginalChapterMapData sourceMap)
        {
            var maps = OriginalLevelTerrainSourceRecipe.Build(tileBounds, sourceMap,
                graphicsResources, ((ISourceVirtualMapFactoryEnvironment)EngineContext).VirtualMapFactory);
            var position = new Vector2(tileBounds.X, tileBounds.Y) * 8f;
            var processRandom = ((ISourceRandomProcessEnvironment)EngineContext).RandomProcess;
            processRandom.PushRandom(sourceMap.LoadSeed);
            OriginalBackgroundTiles backgroundTiles = null;
            OriginalSolidTiles solidTiles = null;
            Scheduler.QueueSourceEntity(
                BgTiles = backgroundTiles = CreateSourceBackgroundTiles(position, maps.Background));
            Scheduler.QueueSourceEntity(SolidTiles = solidTiles = CreateSourceSolidTiles(position, maps.Solids));
            BgData = maps.Background;
            SolidsData = maps.Solids;
            processRandom.PopRandom();
            return (backgroundTiles, solidTiles, position);
        }
    }
}
