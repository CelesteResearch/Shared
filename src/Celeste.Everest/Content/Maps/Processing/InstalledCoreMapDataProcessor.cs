using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Everest.Content.Maps.Processing
{
    public class InstalledCoreMapDataProcessor : EverestMapDataProcessor
    {
        private readonly ISourceEngineContext process;

        public InstalledCoreMapDataProcessor(ISourceEngineContext process)
        {
            this.process = process;
        }

        public int Checkpoint;

        public Dictionary<int, Dictionary<int, BinaryPackerElement>> PlacedBerriesPerCheckpoint;

        public Dictionary<int, int> MaximumBerryOrderPerCheckpoint;

        public Dictionary<int, List<BinaryPackerElement>> AutomaticBerriesPerCheckpoint;

        public int MaxBerryCheckpoint;

        public List<OriginalCheckpointData> CheckpointsAuto;

        public Dictionary<int, OriginalCheckpointData> CheckpointsManual;

        public int MaxManualCheckpoint;

        public string[] LevelTags;

        public string LevelName;

        public int TotalStrawberriesIncludingUntracked;

        public override void Reset()
        {
            Checkpoint = 0;
            PlacedBerriesPerCheckpoint = new();
            MaximumBerryOrderPerCheckpoint = new();
            AutomaticBerriesPerCheckpoint = new();
            MaxBerryCheckpoint = -1;
            CheckpointsAuto = [];
            CheckpointsManual = new();
            MaxManualCheckpoint = -1;
            TotalStrawberriesIncludingUntracked = 0;
        }

        public override Dictionary<string, Action<BinaryPackerElement>> Init()
        {
            return new()
            {
                {
                    "root",
                    delegate(BinaryPackerElement root)
                    {
                        foreach (var child in root.Children) Context.Run(child.Name, child);
                    }
                },
                {
                    "Style",
                    delegate(BinaryPackerElement style)
                    {
                        if (style.Children == null) style.Children = [];

                        foreach (var child2 in style.Children)
                            if ((child2.Name == "Backgrounds" || child2.Name == "Foregrounds") &&
                                child2.Children == null)
                                child2.Children = [];
                    }
                },
                {
                    "levels",
                    delegate(BinaryPackerElement levels)
                    {
                        if (levels.Children != null)
                        {
                            foreach (var child3 in levels.Children)
                            {
                                Context.Run("level", child3);
                                if (child3.Children != null)
                                    foreach (var child4 in child3.Children)
                                        Context.Run(child4.Name, child4);
                            }

                            var flag = false;
                            if (!CheckpointsManual.ContainsKey(0) && CheckpointsManual.ContainsKey(1))
                            {
                                flag = true;
                                CheckpointsAuto.Insert(0, null);
                            }

                            bool shouldLog;
                            for (var i = 0; i <= MaxManualCheckpoint; i++)
                                if (CheckpointsManual.TryGetValue(i, out var value))
                                {
                                    if (i <= CheckpointsAuto.Count)
                                    {
                                        CheckpointsAuto.Insert(i, value);
                                    }
                                    else
                                    {
                                        var text = "core";
                                        var tag = text;
                                        shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                            .BeginCoreMapFixupWarning(84, 3, out var str);
                                        if (shouldLog)
                                        {
                                            str.AppendLiteral("Checkpoint ID ");
                                            str.AppendFormatted(i);
                                            str.AppendLiteral(" exceeds checkpoint count in room ");
                                            str.AppendFormatted(value.Level);
                                            str.AppendLiteral(" of map ");
                                            str.AppendFormatted(Mode.Path);
                                            str.AppendLiteral(". Reassigning checkpoint ID.");
                                        }

                                        ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(
                                            ref str,
                                            shouldLog);
                                        CheckpointsAuto.Add(value);
                                    }
                                }

                            if (flag) CheckpointsAuto.RemoveAt(0);

                            for (var j = 0; j <= MaxBerryCheckpoint; j++)
                                if (PlacedBerriesPerCheckpoint.ContainsKey(j) ||
                                    AutomaticBerriesPerCheckpoint.ContainsKey(j))
                                {
                                    if (!PlacedBerriesPerCheckpoint.TryGetValue(j, out var value2))
                                    {
                                        value2 = PlacedBerriesPerCheckpoint[j] =
                                            new();
                                        MaximumBerryOrderPerCheckpoint[j] = -1;
                                    }

                                    if (AutomaticBerriesPerCheckpoint.TryGetValue(j, out var value3))
                                    {
                                        var k = 0;
                                        foreach (var item in value3)
                                        {
                                            for (; value2.ContainsKey(k); k++)
                                            {
                                            }

                                            item.SetAttr("order", k);
                                            value2[k] = item;
                                            MaximumBerryOrderPerCheckpoint[j] =
                                                Math.Max(MaximumBerryOrderPerCheckpoint[j], k);
                                            k++;
                                        }
                                    }

                                    var num = 0;
                                    for (var l = 0; l <= MaximumBerryOrderPerCheckpoint[j]; l++)
                                        if (!value2.TryGetValue(l, out var value4))
                                        {
                                            if (num == 0)
                                            {
                                                var text = "core";
                                                var tag2 = text;
                                                shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                                    .BeginCoreMapFixupWarning(67, 2, out var str);
                                                if (shouldLog)
                                                {
                                                    str.AppendLiteral("Gap in berry order in checkpoint ");
                                                    str.AppendFormatted(j);
                                                    str.AppendLiteral(" of map ");
                                                    str.AppendFormatted(Mode.Path);
                                                    str.AppendLiteral(". Reassigning berry order.");
                                                }

                                                ((IEverestLoggerProcessEnvironment)process).Logger
                                                    .EndCoreMapFixupWarning(
                                                        ref str, shouldLog);
                                            }

                                            num++;
                                        }
                                        else
                                        {
                                            value4.SetAttr("order", value4.AttrInt("order") - num);
                                        }

                                    if (j > Checkpoint)
                                    {
                                        var text = "core";
                                        var tag3 = text;
                                        shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                            .BeginCoreMapFixupWarning(75, 2, out var str);
                                        if (shouldLog)
                                        {
                                            str.AppendLiteral("Invalid checkpoint ID ");
                                            str.AppendFormatted(j);
                                            str.AppendLiteral(" for berries in map ");
                                            str.AppendFormatted(Mode.Path);
                                            str.AppendLiteral(". Reassigning to last checkpoint.");
                                        }

                                        ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(
                                            ref str,
                                            shouldLog);
                                        var num2 = MaximumBerryOrderPerCheckpoint.GetValueOrDefault(Checkpoint, -1);
                                        foreach (var item2 in value2.OrderBy(kv => kv.Key))
                                        {
                                            var value5 = item2.Value;
                                            value5.SetAttr("checkpointID", Checkpoint);
                                            value5.SetAttr("order", num2 + 1);
                                            num2++;
                                        }
                                    }
                                }
                        }
                    }
                },
                {
                    "level",
                    delegate(BinaryPackerElement level)
                    {
                        LevelTags = level.Attr("name").Split(':');
                        LevelName = LevelTags[0];
                        if (LevelName.StartsWith("lvl_")) LevelName = LevelName.Substring(4);

                        level.SetAttr("name", "lvl_" + LevelName);
                        var element =
                            level.Children.FirstOrDefault(el => el.Name == "entities");
                        var element2 =
                            level.Children.FirstOrDefault(el => el.Name == "triggers");
                        if (element == null)
                        {
                            var children = level.Children;
                            var obj = new BinaryPackerElement
                            {
                                Name = "entities",
                            };
                            element = obj;
                            children.Add(obj);
                        }

                        if (element.Children == null) element.Children = [];

                        if (element2 == null)
                        {
                            var children2 = level.Children;
                            var obj2 = new BinaryPackerElement
                            {
                                Name = "triggers",
                            };
                            element2 = obj2;
                            children2.Add(obj2);
                        }

                        if (element2.Children == null) element2.Children = [];

                        if (LevelTags.Contains("checkpoint") || LevelTags.Contains("cp"))
                            element.Children.Add(new()
                            {
                                Name = "checkpoint",
                                Attributes = new()
                                {
                                    { "x", "0" },
                                    { "y", "0" },
                                },
                            });

                        if (level.AttrBool("space"))
                        {
                            if (level.AttrBool("spaceSkipWrap") || LevelTags.Contains("nospacewrap") ||
                                LevelTags.Contains("nsw"))
                                element.Children.Add(new()
                                {
                                    Name = "everest/spaceControllerBlocker",
                                });

                            if (level.AttrBool("spaceSkipGravity") ||
                                LevelTags.Contains("nospacegravity") ||
                                LevelTags.Contains("nsg"))
                            {
                                element.Children.Add(new()
                                {
                                    Name = "everest/spaceController",
                                });
                                level.SetAttr("space", false);
                            }

                            if (!LevelTags.Contains("nospacefix") &&
                                !LevelTags.Contains("nsf") &&
                                !element2.Children.Any(el =>
                                    el.Name == "cameraTargetTrigger") &&
                                !element.Children.Any(el =>
                                    el.Name == "everest/spaceControllerBlocker"))
                            {
                                var num = level.AttrInt("height");
                                num /= 8;
                                if (num % 2 == 0) num--;

                                num *= 8;
                                element2.Children.Add(new()
                                {
                                    Name = "cameraTargetTrigger",
                                    Attributes = new()
                                    {
                                        { "x", 0f },
                                        { "y", 0f },
                                        {
                                            "width",
                                            level.AttrInt("width")
                                        },
                                        {
                                            "height",
                                            level.AttrInt("height")
                                        },
                                        { "yOnly", true },
                                        { "lerpStrength", 1f },
                                    },
                                    Children =
                                    [
                                        new()
                                        {
                                            Attributes = new()
                                            {
                                                { "x", 160f },
                                                {
                                                    "y",
                                                    num / 2f
                                                },
                                            },
                                        },
                                    ],
                                });
                            }
                        }
                    }
                },
                {
                    "entities",
                    delegate(BinaryPackerElement levelChild)
                    {
                        foreach (var child5 in levelChild.Children)
                            if (child5.Name == "checkpoint")
                            {
                                if (CheckpointsAuto != null)
                                {
                                    var modeMeta = AreaData.GetModeMeta(AreaKey.Mode);
                                    var c =
                                        new EverestCheckpointData(
                                            LevelName,
                                            InstalledDialogKeySource.Keyify(AreaData.SID + "_" + LevelName),
                                            EverestMapMetadata.GetInventory(child5.Attr("inventory")),
                                            !(child5.Attr("dreaming") == "")
                                                ? child5.AttrBool("dreaming")
                                                : modeMeta.Dreaming ?? AreaData.Dreaming);
                                    c.Area = AreaKey;
                                    if (child5.Attr("coreMode") == "")
                                        c.CoreMode = modeMeta.CoreMode ?? AreaData.CoreMode;
                                    else
                                        child5.AttrIf("coreMode",
                                            delegate(string v)
                                            {
                                                c.CoreMode = (RoomCoreMode)Enum.Parse(typeof(RoomCoreMode), v,
                                                    true);
                                            });

                                    var num = child5.AttrInt("checkpointID", -1);
                                    if (num == -1)
                                    {
                                        CheckpointsAuto.Add(c);
                                    }
                                    else if (CheckpointsManual.TryAdd(num, c))
                                    {
                                        MaxManualCheckpoint = Math.Max(MaxManualCheckpoint, num);
                                    }
                                    else
                                    {
                                        bool shouldLog;
                                        shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                            .BeginCoreMapFixupWarning(69, 3, out var str);
                                        if (shouldLog)
                                        {
                                            str.AppendLiteral("Duplicate checkpoint ID ");
                                            str.AppendFormatted(num);
                                            str.AppendLiteral(" in room ");
                                            str.AppendFormatted(LevelName);
                                            str.AppendLiteral(" of map ");
                                            str.AppendFormatted(Mode.Path);
                                            str.AppendLiteral(". Reassigning checkpoint ID.");
                                        }

                                        ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(
                                            ref str,
                                            shouldLog);
                                        CheckpointsAuto.Add(c);
                                    }
                                }

                                Checkpoint++;
                            }

                        foreach (var child6 in levelChild.Children) Context.Run("entity:" + child6.Name, child6);
                    }
                },
                {
                    "entity:cassette",
                    delegate
                    {
                        if (AreaData.CassetteCheckpointIndex < 0) AreaData.CassetteCheckpointIndex = Checkpoint;

                        if (ParentAreaData.CassetteCheckpointIndex < 0)
                        {
                            var parentAreaData = ParentAreaData;
                            var checkpoint = Checkpoint;
                            var checkpoints = ParentMode.Checkpoints;
                            parentAreaData.CassetteCheckpointIndex =
                                checkpoint + (checkpoints != null ? checkpoints.Length : 0);
                        }

                        MapData.DetectedCassette = true;
                        ParentMapData.DetectedCassette = true;
                    }
                },
                {
                    "entity:strawberry",
                    delegate(BinaryPackerElement entity)
                    {
                        if (!entity.AttrBool("moon"))
                        {
                            var num = entity.AttrInt("checkpointID", -1);
                            if (num == -1)
                            {
                                entity.SetAttr("checkpointID", Checkpoint);
                                num = Checkpoint;
                            }

                            MaxBerryCheckpoint = Math.Max(MaxBerryCheckpoint, num);
                            var num2 = entity.AttrInt("order", -1);
                            if (num2 == -1)
                            {
                                if (!AutomaticBerriesPerCheckpoint.ContainsKey(num))
                                    AutomaticBerriesPerCheckpoint[num] = [];

                                AutomaticBerriesPerCheckpoint[num].Add(entity);
                            }
                            else
                            {
                                if (!PlacedBerriesPerCheckpoint.ContainsKey(num))
                                {
                                    PlacedBerriesPerCheckpoint[num] = new();
                                    MaximumBerryOrderPerCheckpoint[num] = -1;
                                }

                                if (PlacedBerriesPerCheckpoint[num].ContainsKey(num2))
                                {
                                    bool shouldLog;
                                    shouldLog =
                                        ((IEverestLoggerProcessEnvironment)process).Logger.BeginCoreMapFixupWarning(71,
                                            3,
                                            out var str);
                                    if (shouldLog)
                                    {
                                        str.AppendLiteral("Duplicate berry order ");
                                        str.AppendFormatted(num2);
                                        str.AppendLiteral(" in checkpoint ");
                                        str.AppendFormatted(num);
                                        str.AppendLiteral(" of map ");
                                        str.AppendFormatted(Mode.Path);
                                        str.AppendLiteral(". Reassigning berry order.");
                                    }

                                    ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(ref str,
                                        shouldLog);
                                    if (!AutomaticBerriesPerCheckpoint.ContainsKey(num))
                                        AutomaticBerriesPerCheckpoint[num] = [];

                                    AutomaticBerriesPerCheckpoint[num].Add(entity);
                                }
                                else
                                {
                                    PlacedBerriesPerCheckpoint[num][num2] = entity;
                                    MaximumBerryOrderPerCheckpoint[num] =
                                        Math.Max(MaximumBerryOrderPerCheckpoint[num], num2);
                                }
                            }

                            var num3 = num;
                            var checkpoints = ParentMode.Checkpoints;
                            entity.SetAttr("checkpointIDParented",
                                num3 + (checkpoints != null ? checkpoints.Length : 0));
                        }
                    }
                },
            };
        }

        public override void Run(string stepName, BinaryPackerElement el)
        {
            if (((ISourceInstalledStrawberryRegistryEnvironment)process).StrawberryRegistry.IsRegisteredBerry(el.Name))
            {
                TotalStrawberriesIncludingUntracked++;
                if (((ISourceInstalledStrawberryRegistryEnvironment)process).StrawberryRegistry.TrackableContains(el))
                    stepName = "entity:strawberry";
            }

            base.Run(stepName, el);
        }

        public override void End()
        {
            Mode.Checkpoints = [.. CheckpointsAuto];
            if (Mode != ParentMode)
            {
                if (ParentMode.Checkpoints == null)
                    ParentMode.Checkpoints = [.. CheckpointsAuto];
                else
                    ParentMode.Checkpoints = [.. ParentMode.Checkpoints.Concat(CheckpointsAuto)];
            }

            MapData.DetectedStrawberriesIncludingUntracked = TotalStrawberriesIncludingUntracked;
            if (MapData != ParentMapData)
                ParentMapData.DetectedStrawberriesIncludingUntracked =
                    ParentMapData.DetectedStrawberriesIncludingUntracked + TotalStrawberriesIncludingUntracked;
        }
    }
}
