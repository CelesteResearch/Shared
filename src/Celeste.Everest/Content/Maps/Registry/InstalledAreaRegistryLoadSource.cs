using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Core.Threading;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Content.Metadata;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class InstalledAreaRegistryLoadSource
    {
        private readonly SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics;
        private readonly OriginalAreaRegistryProcess registry;
        private readonly EverestContentRegistry content;
        private readonly ISourceEngineContext process;
        private readonly IOriginalAreaDataFactory areaFactory;
        private readonly IOriginalAreaKeyPolicy areas;
        private readonly IOriginalChapterMapStartPolicy mapStartPolicy;
        private readonly IOriginalChapterMapLoadPolicy mapLoadPolicy;
        private readonly InstalledAssetMetadataSource metadata;
        private readonly InstalledChapterMapProcessingSource mapProcessing;
        private readonly IEverestLoggerProcessEnvironment diagnostics;
        private List<OriginalAreaData> Areas => registry.Areas;

        public InstalledAreaRegistryLoadSource(OriginalAreaRegistryProcess registry,
            EverestContentRegistry content, ISourceEngineContext process,
            IOriginalAreaDataFactory areaFactory, IOriginalAreaKeyPolicy areas,
            IOriginalChapterMapStartPolicy mapStartPolicy, IOriginalChapterMapLoadPolicy mapLoadPolicy,
            InstalledAssetMetadataSource metadata, InstalledChapterMapProcessingSource mapProcessing,
            IEverestLoggerProcessEnvironment diagnostics,
            SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics)
        {
            this.sourceStatics = sourceStatics;
            this.registry = registry;
            this.content = content;
            this.process = process;
            this.areaFactory = areaFactory;
            this.areas = areas;
            this.mapStartPolicy = mapStartPolicy;
            this.mapLoadPolicy = mapLoadPolicy;
            this.metadata = metadata;
            this.mapProcessing = mapProcessing;
            this.diagnostics = diagnostics;
        }

        public void LoadInstalledSource()
        {
            registry.LoadOriginalSource();
            foreach (EverestArea area2 in Areas)
            {
                area2.SID = "Celeste/" + area2.Mode[0].Path;
                for (var i = 0; i < area2.Mode.Length; i++)
                {
                    var modeProperties = area2.Mode[i];
                    if (modeProperties?.Checkpoints != null)
                    {
                        var checkpoints = modeProperties.Checkpoints;
                        for (var j = 0; j < checkpoints.Length; j++)
                            ((EverestCheckpointData)checkpoints[j]).Area =
                                areas.ToKey(area2, i);
                    }
                }
            }

            var list = new List<OriginalAreaData>();
            lock (content.Map)
            {
                foreach (var item in content.Map.Values.Where(asset =>
                             asset.Type == typeof(AssetTypeMap)))
                {
                    var text = item.PathVirtual.Substring(5);
                    var areaData = (EverestArea)areaFactory.Create();
                    areaData.SID = text;
                    areaData.Name = text;
                    areaData.Icon = "areas/" + text.ToLowerInvariant();
                    if (!((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)process).GameGraphics)
                        .GuiAtlas
                        .Has(areaData.Icon))
                        areaData.Icon = "areas/null";

                    areaData.Interlude = false;
                    areaData.CanFullClear = true;
                    areaData.TitleBaseColor = SourceHexColor.HexToColor("6c7c81");
                    areaData.TitleAccentColor = SourceHexColor.HexToColor("2f344b");
                    areaData.TitleTextColor = PackedColor.White;
                    areaData.IntroType = PlayerIntroType.WakeUp;
                    areaData.Dreaming = false;
                    areaData.ColorGrade = null;
                    areaData.Mode =
                    [
                        new EverestAreaModeData
                        {
                            Inventory = RoomPlayerInventory.Default,
                            AudioState = new("event:/music/lvl1/main", "event:/env/amb/00_prologue"),
                        },
                    ];
                    areaData.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                    {
                        new AngledWipePresentation(scene, wipeIn, onComplete);
                    };
                    areaData.DarknessAlpha = 0.05f;
                    areaData.BloomBase = 0f;
                    areaData.BloomStrength = 1f;
                    areaData.Jumpthru = "wood";
                    areaData.CassseteNoteColor = SourceHexColor.HexToColor("33a9ee");
                    areaData.CassetteSong = "event:/music/cassette/01_forsaken_city";
                    var mapMeta = new EverestMapMetadata();
                    mapMeta.Mountain = new();
                    mapMeta.Mountain.Idle = new();
                    mapMeta.Mountain.Idle.Position = [10f, 16f, 10f];
                    mapMeta.Mountain.Idle.Target = [1f, 10f, 1f];
                    mapMeta.Mountain.Select =
                        new();
                    mapMeta.Mountain.Select.Position = [8f, 13f, 8f];
                    mapMeta.Mountain.Select.Target = [1f, 8f, 1f];
                    mapMeta.Mountain.Zoom = new();
                    mapMeta.Mountain.Zoom.Position = [6f, 10f, 6f];
                    mapMeta.Mountain.Zoom.Target = [1f, 6f, 1f];
                    mapMeta.Mountain.Cursor = [3f, 10f, 3f];
                    mapMeta.ApplyTo(areaData, process);
                    var meta = metadata.GetMeta<EverestMapMetadata>(item);
                    if (meta != null)
                    {
                        areaData.Metadata = null;
                        meta.ApplyTo(areaData, process);
                        mapMeta = meta;
                    }

                    if (string.IsNullOrEmpty(areaData.Mode[0].Path))
                        areaData.Mode[0].Path = item.PathVirtual.Substring(5);

                    mapMeta.Modes = mapMeta.Modes ?? new EverestModeMetadata[3];
                    if (mapMeta.Modes.Length < 3)
                    {
                        var array = new EverestModeMetadata[3];
                        for (var num = 0; num < mapMeta.Modes.Length; num++) array[num] = mapMeta.Modes[num];

                        mapMeta.Modes = array;
                    }

                    if (areaData.Mode.Length < 3)
                    {
                        var array2 = new OriginalAreaModeData[3];
                        for (var num2 = 0; num2 < areaData.Mode.Length; num2++) array2[num2] = areaData.Mode[num2];

                        areaData.Mode = array2;
                    }

                    if (areaData.LevelSet == "Celeste")
                        Areas.Add(areaData);
                    else
                        list.Add(areaData);

                    areaData.OnLevelBegin = delegate(OriginalLevelSceneRoot level)
                    {
                        _ = ((EverestArea)areas.GetArea(areas.GetSessionArea(level.Session))).Metadata;
                        if (mapProcessing.GetModeMeta((OriginalChapterMapData)level.Session.MapData)?.SeekerSlowdown ==
                            true)
                            level.ConstructSourceSeekerEffectsController();
                    };
                }
            }

            Areas.AddRange(list);
            for (var num3 = 0; num3 < Areas.Count; num3++)
            {
                var area = (EverestArea)Areas[num3];
                var num4 = Areas.FindIndex(other => ((EverestArea)other).SID == area.SID);
                if (num4 < num3)
                {
                    Areas[num4] = area;
                    Areas.RemoveAt(num3);
                    num3--;
                }
            }

            Areas.Sort(AreaComparison);
            for (var num5 = 0; num5 < Areas.Count; num5++)
            {
                var areaData2 = (EverestArea)Areas[num5];
                var path = areaData2.Mode[0].Path;
                var num6 = Areas.FindIndex(other =>
                    other.Mode.Any(otherMode => otherMode?.Path == path));
                if (num6 != -1 && num6 != num5)
                {
                    Areas.RemoveAt(num5);
                    num5--;
                    continue;
                }

                ParseName(path, out var order, out var side, out var name);
                for (var num7 = 0; num7 < Areas.Count; num7++)
                {
                    var areaData3 = (EverestArea)Areas[num7];
                    ParseName(areaData3.Mode[0].Path, out var order2, out var side2, out var name2);
                    if (areaData2.LevelSet == areaData3.LevelSet && order == order2 && name == name2 && side != side2 &&
                        !areaData3.HasMode((int)side))
                    {
                        if (areaData3.Mode[(int)side] == null)
                            areaData3.Mode[(int)side] = new EverestAreaModeData
                            {
                                Inventory = RoomPlayerInventory.Default,
                                AudioState = new("event:/music/lvl1/main", "event:/env/amb/00_prologue"),
                            };

                        areaData3.Mode[(int)side].Path = path;
                        Areas.RemoveAt(num5);
                        num5--;
                        break;
                    }
                }
            }

            for (var num8 = 0; num8 < Areas.Count; num8++)
            {
                var areaData4 = (EverestArea)Areas[num8];
                areaData4.ID = num8;
                int num9;
                for (num9 = 0; num9 < areaData4.Mode.Length; num9++)
                {
                    var modeProperties2 = areaData4.Mode[num9];
                    if (modeProperties2 == null || string.IsNullOrEmpty(modeProperties2.Path)) break;
                }

                Array.Resize(ref areaData4.Mode, num9);
                diagnostics.Logger.VerboseAreaSides(num8, areaData4);
                if (areaData4.Mode[0].MapData != null)
                    areaData4.Mode[0].MapData.Area = areas.ToKey(areaData4);
                else
                    areaData4.Mode[0].MapData =
                        new(areas.ToKey(areaData4), registry, mapStartPolicy, mapLoadPolicy);

                if (areaData4.Interlude) continue;

                if (areaData4.Mode[0].PoemID == null)
                    areaData4.Mode[0].PoemID = InstalledDialogKeySource.Keyify(areaData4.SID) + "_A";

                if (areaData4.Mode.Length > 1 && areaData4.Mode[1] != null && areaData4.Mode[1].PoemID == null)
                    areaData4.Mode[1].PoemID = InstalledDialogKeySource.Keyify(areaData4.SID) + "_B";

                for (var num10 = 1; num10 < areaData4.Mode.Length; num10++)
                    if (areaData4.Mode[num10] != null)
                    {
                        if (areaData4.Mode[num10].MapData != null)
                            areaData4.Mode[num10].MapData.Area = areas.ToKey(areaData4, num10);
                        else
                            areaData4.Mode[num10].MapData = new(areas.ToKey(areaData4, num10),
                                registry, mapStartPolicy, mapLoadPolicy);
                    }
            }

            ((IEverestMountainResourceEnvironment)process).MountainExtension.LoadMod();
            ((IEverestMountainResourceEnvironment)process).MountainExtension.LoadModData();
        }
    }
}
