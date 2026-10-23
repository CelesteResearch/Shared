using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Types.Graphics;
using Celeste.Formats.Graphics.Models;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public sealed class EverestMountainExtensionProcess
    {
        private readonly ISourceEngineContext engine;

        public EverestMountainExtensionProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        /// <summary>
        ///     Maps the key to the EverestContentAsset of the map in ((IEverestMountainContentEnvironment)engine).Content to the
        ///     EverestMountainResources for it
        /// </summary>
        public Dictionary<string, EverestMountainResources> MountainMappings = new();

        /// <summary>
        ///     Stores .obj model files when they are loaded, so that they only get loaded once.
        /// </summary>
        public Dictionary<string, ObjectModel> ObjModelCache = new();

        public bool ModsLoaded { get; private set; }

        public bool ModsDataLoaded { get; private set; }

        public void ReloadModData()
        {
            ModsDataLoaded = false;
            LoadModData();
        }

        public void ReloadMod()
        {
            ModsLoaded = false;
            LoadMod();
        }

        /// <summary>
        ///     Load the custom mountain models for mods.
        /// </summary>
        public void LoadModData()
        {
            if (!ModsDataLoaded)
            {
                var stopwatch = Stopwatch.StartNew();
                lock (((IEverestMountainContentEnvironment)engine).Content.Map)
                {
                    foreach (var item in
                             ((IEverestMountainContentEnvironment)engine)
                             .Content.Map)
                    {
                        EverestMapMetadata meta;
                        if (item.Value == null || (meta = item.Value.GetMeta<EverestMapMetadata>()) == null ||
                            meta.Mountain == null || string.IsNullOrEmpty(meta.Mountain.MountainModelDirectory))
                            continue;

                        if (!MountainMappings.TryGetValue(item.Key, out var value))
                        {
                            value = new();
                            MountainMappings.Add(item.Key, value);
                        }

                        if (resolveModel(meta, "mountain", out var matchingAsset, out var path))
                            value.MountainTerrain = loadModelFile(matchingAsset, path);

                        if (resolveModel(meta, "buildings", out var matchingAsset2, out var path2))
                            value.MountainBuildings = loadModelFile(matchingAsset2, path2);

                        if (resolveModel(meta, "mountain_wall", out var matchingAsset3, out var path3))
                            value.MountainCoreWall = loadModelFile(matchingAsset3, path3);

                        if (resolveModel(meta, "bird", out var matchingAsset4, out var path4))
                            value.MountainBird = loadModelFile(matchingAsset4, path4);

                        if (resolveModel(meta, "moon", out var matchingAsset5, out var path5))
                            value.MountainMoon = loadModelFile(matchingAsset5, path5);

                        value.MountainExtraModels.Clear();
                        value.MountainExtraModelTextures.Clear();
                        EverestContentAsset matchingAsset6;
                        string path6;
                        while (resolveModel(meta, "extra" + value.MountainExtraModels.Count, out matchingAsset6,
                                   out path6))
                        {
                            var count = value.MountainExtraModels.Count;
                            value.MountainExtraModels.Add(loadModelFile(matchingAsset6, path6));
                            var array = new VirtualTexture[4];
                            for (var i = 0; i < 4; i++)
                                if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                        .Combine(meta.Mountain.MountainTextureDirectory, "extra" + count + "_" + i)
                                        .Replace('\\', '/')))
                                    array[i] = ((IOriginalMountainEnvironment)engine).MountainResources
                                        .Mountain[
                                            Path.Combine(meta.Mountain.MountainTextureDirectory,
                                                    "extra" + count + "_" + i)
                                                .Replace('\\', '/')].Texture;

                            value.MountainExtraModelTextures.Add(array);
                        }
                    }
                }

                Console.WriteLine(" - MODDED MTN DATA LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            ModsDataLoaded = true;
        }

        private bool resolveModel(EverestMapMetadata meta, string modelName, out EverestContentAsset matchingAsset,
            out string path)
        {
            if (((IEverestMountainContentEnvironment)engine).Content.TryGet(
                    Path.Combine(meta.Mountain.MountainModelDirectory, modelName + ".obj"), out matchingAsset) &&
                matchingAsset.Type == typeof(AssetTypeObjModelExport))
            {
                path = Path.Combine(meta.Mountain.MountainModelDirectory, modelName + ".export").Replace("\\", "/");
                return true;
            }

            if (((IEverestMountainContentEnvironment)engine).Content.TryGet(
                    Path.Combine(meta.Mountain.MountainModelDirectory, modelName), out matchingAsset) &&
                matchingAsset.Type == typeof(ObjectModel))
            {
                path = Path.Combine(meta.Mountain.MountainModelDirectory, modelName + ".obj").Replace("\\", "/");
                return true;
            }

            path = null;
            return false;
        }

        private ObjectModel loadModelFile(EverestContentAsset asset, string path)
        {
            if (ObjModelCache.TryGetValue(path, out var value)) return value;

            var objModel =
                ObjectModel.CreateFromStream(asset.Stream, path, (ISourceGraphicsDeviceEnvironment)engine);
            ObjModelCache[path] = objModel;
            return objModel;
        }

        /// <summary>
        ///     Load the custom mountain textures for mods.
        /// </summary>
        public void LoadMod()
        {
            if (!ModsLoaded)
            {
                var stopwatch = Stopwatch.StartNew();
                lock (((IEverestMountainContentEnvironment)engine).Content.Map)
                {
                    foreach (var item in
                             ((IEverestMountainContentEnvironment)engine)
                             .Content.Map)
                    {
                        EverestMapMetadata meta;
                        if (item.Value == null || (meta = item.Value.GetMeta<EverestMapMetadata>()) == null ||
                            meta.Mountain == null)
                            continue;

                        if (!MountainMappings.TryGetValue(item.Key, out var value))
                        {
                            value = new();
                            MountainMappings.Add(item.Key, value);
                        }

                        value.MountainTerrainTextures = new VirtualTexture[3];
                        value.MountainBuildingTextures = new VirtualTexture[3];
                        value.MountainSkyboxTextures = new VirtualTexture[3];
                        if (!string.IsNullOrEmpty(meta.Mountain.MountainTextureDirectory))
                        {
                            for (var i = 0; i < 3; i++)
                            {
                                if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                        .Combine(meta.Mountain.MountainTextureDirectory, "skybox_" + i)
                                        .Replace('\\', '/')))
                                    value.MountainSkyboxTextures[i] = ((IOriginalMountainEnvironment)engine)
                                        .MountainResources
                                        .Mountain[
                                            Path.Combine(meta.Mountain.MountainTextureDirectory, "skybox_" + i)
                                                .Replace('\\', '/')].Texture;

                                if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                        .Combine(meta.Mountain.MountainTextureDirectory, "mountain_" + i)
                                        .Replace('\\', '/')))
                                    value.MountainTerrainTextures[i] = ((IOriginalMountainEnvironment)engine)
                                        .MountainResources
                                        .Mountain[
                                            Path.Combine(meta.Mountain.MountainTextureDirectory, "mountain_" + i)
                                                .Replace('\\', '/')].Texture;

                                if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                        .Combine(meta.Mountain.MountainTextureDirectory, "buildings_" + i)
                                        .Replace('\\', '/')))
                                    value.MountainBuildingTextures[i] = ((IOriginalMountainEnvironment)engine)
                                        .MountainResources
                                        .Mountain[
                                            Path.Combine(meta.Mountain.MountainTextureDirectory, "buildings_" + i)
                                                .Replace('\\', '/')].Texture;
                            }

                            if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(
                                    Path.Combine(meta.Mountain.MountainTextureDirectory, "fog").Replace('\\', '/')))
                                value.MountainFogTexture = ((IOriginalMountainEnvironment)engine).MountainResources
                                    .Mountain[
                                        Path.Combine(meta.Mountain.MountainTextureDirectory, "fog").Replace('\\', '/')]
                                    .Texture;

                            if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(
                                    Path.Combine(meta.Mountain.MountainTextureDirectory, "moon").Replace('\\', '/')))
                                value.MountainMoonTexture = ((IOriginalMountainEnvironment)engine).MountainResources
                                    .Mountain[
                                        Path.Combine(meta.Mountain.MountainTextureDirectory, "moon").Replace('\\', '/')]
                                    .Texture;

                            if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(
                                    Path.Combine(meta.Mountain.MountainTextureDirectory, "space").Replace('\\', '/')))
                                value.MountainSpaceTexture = ((IOriginalMountainEnvironment)engine).MountainResources
                                    .Mountain[
                                        Path.Combine(meta.Mountain.MountainTextureDirectory, "space")
                                            .Replace('\\', '/')]
                                    .Texture;

                            if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                    .Combine(meta.Mountain.MountainTextureDirectory, "spacestars").Replace('\\', '/')))
                                value.MountainSpaceStarsTexture = ((IOriginalMountainEnvironment)engine)
                                    .MountainResources
                                    .Mountain[
                                        Path.Combine(meta.Mountain.MountainTextureDirectory, "spacestars")
                                            .Replace('\\', '/')].Texture;

                            if (((IOriginalMountainEnvironment)engine).MountainResources.Mountain.Has(Path
                                    .Combine(meta.Mountain.MountainTextureDirectory, "starstream").Replace('\\', '/')))
                                value.MountainStarStreamTexture = ((IOriginalMountainEnvironment)engine)
                                    .MountainResources
                                    .Mountain[
                                        Path.Combine(meta.Mountain.MountainTextureDirectory, "starstream")
                                            .Replace('\\', '/')].Texture;
                        }

                        if (meta.Mountain.StarFogColor != null)
                            value.StarFogColor = PackedColor.FromHex(meta.Mountain.StarFogColor);

                        if (meta.Mountain.StarStreamColors != null)
                            value.StarStreamColors = parseColorArray(meta.Mountain.StarStreamColors);

                        if (meta.Mountain.StarBeltColors1 != null)
                            value.StarBeltColors1 = parseColorArray(meta.Mountain.StarBeltColors1);

                        if (meta.Mountain.StarBeltColors2 != null)
                            value.StarBeltColors2 = parseColorArray(meta.Mountain.StarBeltColors2);

                        value.MountainStates[0] = new(engine,
                            value.MountainTerrainTextures[0] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainTerrainTextures[0],
                            value.MountainBuildingTextures[0] ?? ((IOriginalMountainEnvironment)engine)
                            .MountainResources
                            .MountainBuildingTextures[0],
                            value.MountainSkyboxTextures[0] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainSkyboxTextures[0], PackedColor.FromHex("010817"));
                        value.MountainStates[1] = new(engine,
                            value.MountainTerrainTextures[1] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainTerrainTextures[1],
                            value.MountainBuildingTextures[1] ?? ((IOriginalMountainEnvironment)engine)
                            .MountainResources
                            .MountainBuildingTextures[1],
                            value.MountainSkyboxTextures[1] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainSkyboxTextures[1], PackedColor.FromHex("13203E"));
                        value.MountainStates[2] = new(engine,
                            value.MountainTerrainTextures[2] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainTerrainTextures[2],
                            value.MountainBuildingTextures[2] ?? ((IOriginalMountainEnvironment)engine)
                            .MountainResources
                            .MountainBuildingTextures[2],
                            value.MountainSkyboxTextures[2] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainSkyboxTextures[2], PackedColor.FromHex("281A35"));
                        value.MountainStates[3] = new(engine,
                            value.MountainTerrainTextures[0] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainTerrainTextures[0],
                            value.MountainBuildingTextures[0] ?? ((IOriginalMountainEnvironment)engine)
                            .MountainResources
                            .MountainBuildingTextures[0],
                            value.MountainSkyboxTextures[0] ?? ((IOriginalMountainEnvironment)engine).MountainResources
                            .MountainSkyboxTextures[0], PackedColor.FromHex("010817"));
                        if (meta.Mountain.FogColors != null)
                            for (var j = 0; j < value.MountainStates.Length && j < meta.Mountain.FogColors.Length; j++)
                                value.MountainStates[j].FogColor = PackedColor.FromHex(meta.Mountain.FogColors[j]);
                    }
                }

                Console.WriteLine(" - MODDED MTN LOAD: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            ModsLoaded = true;
        }

        private PackedColor[] parseColorArray(string[] array)
        {
            var array2 = new PackedColor[array.Length];
            for (var i = 0; i < array.Length; i++) array2[i] = PackedColor.FromHex(array[i]);

            return array2;
        }
    }
}
