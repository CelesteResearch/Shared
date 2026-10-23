using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Graphics.Content.Tiles;
using Celeste.Scene.Entities;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public TileGrid FgTilesLightMask;

        public void ApplySourceSceneryOverlays(OriginalChapterMapData sourceMap, Vector2 position, IntRect tileBounds,
            OriginalBackgroundTiles backgroundTiles, OriginalSolidTiles solidTiles)
        {
            var maskOwner = new SceneEntityState(
                ((ISourceEntitySourceDataEnvironment)EngineContext).EntitySourceDataRegistration,
                position);
            FgTilesLightMask = new(8, 8, tileBounds.Width, tileBounds.Height);
            maskOwner.Components.Add(FgTilesLightMask);
            FgTilesLightMask.Color = PackedColor.Black;
            foreach (var level in sourceMap.Levels)
            {
                var bounds = level.TileBounds;
                var offsetX = bounds.Left - tileBounds.X;
                var offsetY = bounds.Top - tileBounds.Y;
                var backgroundCsv = level.BgTiles;
                var foregroundCsv = level.FgTiles;
                if (!string.IsNullOrEmpty(backgroundCsv))
                {
                    var background = ReadSourceCsvIntGrid(backgroundCsv, bounds.Width, bounds.Height);
                    backgroundTiles.Tiles.Overlay(graphicsResources.SceneryTiles, background, offsetX, offsetY);
                }

                if (!string.IsNullOrEmpty(foregroundCsv))
                {
                    var foreground = ReadSourceCsvIntGrid(foregroundCsv, bounds.Width, bounds.Height);
                    solidTiles.Tiles.Overlay(graphicsResources.SceneryTiles, foreground, offsetX, offsetY);
                    FgTilesLightMask.Overlay(graphicsResources.SceneryTiles, foreground, offsetX, offsetY);
                }
            }
        }

        private static int[,] ReadSourceCsvIntGrid(string csv, int width, int height)
        {
            var result = new int[width, height];
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                result[x, y] = -1;
            var rows = csv.Split('\n');
            for (var y = 0; y < height && y < rows.Length; y++)
            {
                var cells = rows[y].Split([','], StringSplitOptions.RemoveEmptyEntries);
                for (var x = 0; x < width && x < cells.Length; x++) result[x, y] = Convert.ToInt32(cells[x]);
            }

            return result;
        }
    }
}
