using System;
using System.Diagnostics;
using System.IO;
using Celeste.Core.IO;
using Celeste.Core.IO.Content;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Formats.Graphics.Models;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Execution.Graphics
{
    public sealed class OriginalMountainResources
    {
        public AtlasData FileSelect;
        public AtlasData Journal;
        public AtlasData Mountain;
        public AtlasData Checkpoints;
        public ObjectModel MountainTerrain;
        public ObjectModel MountainBuildings;
        public ObjectModel MountainCoreWall;
        public ObjectModel MountainMoon;
        public ObjectModel MountainBird;
        public VirtualTexture[] MountainTerrainTextures;
        public VirtualTexture[] MountainBuildingTextures;
        public VirtualTexture[] MountainSkyboxTextures;
        public VirtualTexture MountainFogTexture;
        public VirtualTexture MountainMoonTexture;
        public VirtualTexture MountainStarSky;
        public VirtualTexture MountainStars;
        public VirtualTexture MountainStarStream;
        public bool Loaded { get; private set; }
        public bool DataLoaded { get; private set; }

        public void Load(ISourceAtlasLoaderEnvironment environment)
        {
            if (!Loaded)
            {
                var stopwatch = Stopwatch.StartNew();
                FileSelect = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "FileSelect"),
                    AtlasDataFormat.Packer, environment);
                Journal = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Journal"),
                    AtlasDataFormat.Packer, environment);
                Mountain = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Mountain"),
                    AtlasDataFormat.PackerNoAtlas, environment);
                Checkpoints = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Checkpoints"),
                    AtlasDataFormat.PackerNoAtlas, environment);
                MountainTerrainTextures = new VirtualTexture[3];
                MountainBuildingTextures = new VirtualTexture[3];
                MountainSkyboxTextures = new VirtualTexture[3];
                for (var i = 0; i < 3; i++)
                {
                    MountainSkyboxTextures[i] = Mountain["skybox_" + i].Texture;
                    MountainTerrainTextures[i] = Mountain["mountain_" + i].Texture;
                    MountainBuildingTextures[i] = Mountain["buildings_" + i].Texture;
                }

                MountainMoonTexture = Mountain["moon"].Texture;
                MountainFogTexture = Mountain["fog"].Texture;
                MountainStarSky = Mountain["space"].Texture;
                MountainStars = Mountain["spacestars"].Texture;
                MountainStarStream = Mountain["starstream"].Texture;
                Console.WriteLine(" - MTN LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            Loaded = true;
        }

        public void LoadData(ISourceGraphicsDeviceEnvironment environment)
        {
            if (!DataLoaded)
            {
                var stopwatch = Stopwatch.StartNew();
                var extension = ".obj";
                var files = environment is ISourceAtlasLoaderEnvironment atlas
                            && atlas.ContentFiles is ResidentContentSource
                    ? atlas.ContentFiles
                    : null;
                MountainTerrain =
                    ObjectModel.Create(
                        Path.Combine(((ISourceContentDirectoryEnvironment)environment).ContentDirectory, "Overworld",
                            "mountain" + extension), environment, files);
                MountainBuildings =
                    ObjectModel.Create(
                        Path.Combine(((ISourceContentDirectoryEnvironment)environment).ContentDirectory, "Overworld",
                            "buildings" + extension), environment, files);
                MountainCoreWall =
                    ObjectModel.Create(
                        Path.Combine(((ISourceContentDirectoryEnvironment)environment).ContentDirectory, "Overworld",
                            "mountain_wall" + extension), environment, files);
                MountainMoon =
                    ObjectModel.Create(
                        Path.Combine(((ISourceContentDirectoryEnvironment)environment).ContentDirectory, "Overworld",
                            "moon" + extension), environment, files);
                MountainBird =
                    ObjectModel.Create(
                        Path.Combine(((ISourceContentDirectoryEnvironment)environment).ContentDirectory, "Overworld",
                            "bird" + extension), environment, files);
                Console.WriteLine(" - MTN DATA LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            DataLoaded = true;
        }

        public void Unload()
        {
            if (Loaded)
            {
                Journal.Dispose();
                Journal = null;
                Mountain.Dispose();
                Mountain = null;
                Checkpoints.Dispose();
                Checkpoints = null;
                FileSelect.Dispose();
                FileSelect = null;
            }

            Loaded = false;
        }

        public void UnloadData()
        {
            if (DataLoaded)
            {
                MountainTerrain.Dispose();
                MountainTerrain = null;
                MountainBuildings.Dispose();
                MountainBuildings = null;
                MountainCoreWall.Dispose();
                MountainCoreWall = null;
                MountainMoon.Dispose();
                MountainMoon = null;
                MountainBird.Dispose();
                MountainBird = null;
            }

            DataLoaded = false;
        }
    }
}
