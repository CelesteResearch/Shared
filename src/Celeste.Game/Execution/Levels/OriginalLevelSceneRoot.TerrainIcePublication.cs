using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Maps.Grids;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using System.Collections.Generic;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Presentation.Environment.Ice;
using Celeste.Simulation.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;

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
            => Scheduler.QueueSourceEntity(new OriginalIceTileOverlayState(EngineContext));

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
                BgTiles = (backgroundTiles = CreateSourceBackgroundTiles(position, maps.Background)));
            Scheduler.QueueSourceEntity(SolidTiles = (solidTiles = CreateSourceSolidTiles(position, maps.Solids)));
            BgData = maps.Background;
            SolidsData = maps.Solids;
            processRandom.PopRandom();
            return (backgroundTiles, solidTiles, position);
        }
    }
}
