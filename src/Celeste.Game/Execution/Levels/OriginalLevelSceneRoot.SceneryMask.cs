using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Scene.Entities;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Graphics.Content.Tiles;

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
            FgTilesLightMask = new TileGrid(8, 8, tileBounds.Width, tileBounds.Height);
            maskOwner.Components.Add(FgTilesLightMask);
            FgTilesLightMask.Color = global::Celeste.Core.Display.PackedColor.Black;
            foreach (var level in sourceMap.Levels)
            {
                var bounds = level.TileBounds;
                int offsetX = bounds.Left - tileBounds.X;
                int offsetY = bounds.Top - tileBounds.Y;
                string backgroundCsv = level.BgTiles;
                string foregroundCsv = level.FgTiles;
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
            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = -1;
            string[] rows = csv.Split('\n');
            for (int y = 0; y < height && y < rows.Length; y++)
            {
                string[] cells = rows[y].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < width && x < cells.Length; x++) result[x, y] = Convert.ToInt32(cells[x]);
            }

            return result;
        }
    }
}
