using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Game.Execution.Areas;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Everest.Content.Maps.Processing
{
    public class InstalledCoreMapDataProcessor : EverestMapDataProcessor
    {
        private readonly ISourceEngineContext process;
        public InstalledCoreMapDataProcessor(ISourceEngineContext process) => this.process = process;

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
            PlacedBerriesPerCheckpoint = new Dictionary<int, Dictionary<int, BinaryPackerElement>>();
            MaximumBerryOrderPerCheckpoint = new Dictionary<int, int>();
            AutomaticBerriesPerCheckpoint = new Dictionary<int, List<BinaryPackerElement>>();
            MaxBerryCheckpoint = -1;
            CheckpointsAuto = new List<OriginalCheckpointData>();
            CheckpointsManual = new Dictionary<int, OriginalCheckpointData>();
            MaxManualCheckpoint = -1;
            TotalStrawberriesIncludingUntracked = 0;
        }

        public override Dictionary<string, Action<BinaryPackerElement>> Init()
        {
            return new Dictionary<string, Action<BinaryPackerElement>>
            {
                {
                    "root",
                    delegate(BinaryPackerElement root)
                    {
                        foreach (BinaryPackerElement child in root.Children)
                        {
                            base.Context.Run(child.Name, child);
                        }
                    }
                },
                {
                    "Style",
                    delegate(BinaryPackerElement style)
                    {
                        if (style.Children == null)
                        {
                            style.Children = new List<BinaryPackerElement>();
                        }

                        foreach (BinaryPackerElement child2 in style.Children)
                        {
                            if ((child2.Name == "Backgrounds" || child2.Name == "Foregrounds") &&
                                child2.Children == null)
                            {
                                child2.Children = new List<BinaryPackerElement>();
                            }
                        }
                    }
                },
                {
                    "levels",
                    delegate(BinaryPackerElement levels)
                    {
                        if (levels.Children != null)
                        {
                            foreach (BinaryPackerElement child3 in levels.Children)
                            {
                                base.Context.Run("level", child3);
                                if (child3.Children != null)
                                {
                                    foreach (BinaryPackerElement child4 in child3.Children)
                                    {
                                        base.Context.Run(child4.Name, child4);
                                    }
                                }
                            }

                            bool flag = false;
                            if (!CheckpointsManual.ContainsKey(0) && CheckpointsManual.ContainsKey(1))
                            {
                                flag = true;
                                CheckpointsAuto.Insert(0, null);
                            }

                            bool shouldLog;
                            for (int i = 0; i <= MaxManualCheckpoint; i++)
                            {
                                if (CheckpointsManual.TryGetValue(i, out var value))
                                {
                                    if (i <= CheckpointsAuto.Count)
                                    {
                                        CheckpointsAuto.Insert(i, value);
                                    }
                                    else
                                    {
                                        string text = "core";
                                        string tag = text;
                                        shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                            .BeginCoreMapFixupWarning(84, 3, out var str);
                                        if (shouldLog)
                                        {
                                            str.AppendLiteral("Checkpoint ID ");
                                            str.AppendFormatted(i);
                                            str.AppendLiteral(" exceeds checkpoint count in room ");
                                            str.AppendFormatted(value.Level);
                                            str.AppendLiteral(" of map ");
                                            str.AppendFormatted(base.Mode.Path);
                                            str.AppendLiteral(". Reassigning checkpoint ID.");
                                        }

                                        ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(
                                            ref str,
                                            shouldLog);
                                        CheckpointsAuto.Add(value);
                                    }
                                }
                            }

                            if (flag)
                            {
                                CheckpointsAuto.RemoveAt(0);
                            }

                            for (int j = 0; j <= MaxBerryCheckpoint; j++)
                            {
                                if (PlacedBerriesPerCheckpoint.ContainsKey(j) ||
                                    AutomaticBerriesPerCheckpoint.ContainsKey(j))
                                {
                                    if (!PlacedBerriesPerCheckpoint.TryGetValue(j, out var value2))
                                    {
                                        value2 = (PlacedBerriesPerCheckpoint[j] =
                                            new Dictionary<int, BinaryPackerElement>());
                                        MaximumBerryOrderPerCheckpoint[j] = -1;
                                    }

                                    if (AutomaticBerriesPerCheckpoint.TryGetValue(j, out var value3))
                                    {
                                        int k = 0;
                                        foreach (BinaryPackerElement item in value3)
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

                                    int num = 0;
                                    for (int l = 0; l <= MaximumBerryOrderPerCheckpoint[j]; l++)
                                    {
                                        if (!value2.TryGetValue(l, out var value4))
                                        {
                                            if (num == 0)
                                            {
                                                string text = "core";
                                                string tag2 = text;
                                                shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                                    .BeginCoreMapFixupWarning(67, 2, out var str);
                                                if (shouldLog)
                                                {
                                                    str.AppendLiteral("Gap in berry order in checkpoint ");
                                                    str.AppendFormatted(j);
                                                    str.AppendLiteral(" of map ");
                                                    str.AppendFormatted(base.Mode.Path);
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
                                    }

                                    if (j > Checkpoint)
                                    {
                                        string text = "core";
                                        string tag3 = text;
                                        shouldLog = ((IEverestLoggerProcessEnvironment)process).Logger
                                            .BeginCoreMapFixupWarning(75, 2, out var str);
                                        if (shouldLog)
                                        {
                                            str.AppendLiteral("Invalid checkpoint ID ");
                                            str.AppendFormatted(j);
                                            str.AppendLiteral(" for berries in map ");
                                            str.AppendFormatted(base.Mode.Path);
                                            str.AppendLiteral(". Reassigning to last checkpoint.");
                                        }

                                        ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(
                                            ref str,
                                            shouldLog);
                                        int num2 = MaximumBerryOrderPerCheckpoint.GetValueOrDefault(Checkpoint, -1);
                                        foreach (KeyValuePair<int, BinaryPackerElement> item2 in value2.OrderBy((
                                                     KeyValuePair<int, BinaryPackerElement> kv) => kv.Key))
                                        {
                                            BinaryPackerElement value5 = item2.Value;
                                            value5.SetAttr("checkpointID", Checkpoint);
                                            value5.SetAttr("order", num2 + 1);
                                            num2++;
                                        }
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
                        if (LevelName.StartsWith("lvl_"))
                        {
                            LevelName = LevelName.Substring(4);
                        }

                        level.SetAttr("name", "lvl_" + LevelName);
                        BinaryPackerElement element =
                            level.Children.FirstOrDefault((BinaryPackerElement el) => el.Name == "entities");
                        BinaryPackerElement element2 =
                            level.Children.FirstOrDefault((BinaryPackerElement el) => el.Name == "triggers");
                        if (element == null)
                        {
                            List<BinaryPackerElement> children = level.Children;
                            BinaryPackerElement obj = new BinaryPackerElement
                            {
                                Name = "entities"
                            };
                            element = obj;
                            children.Add(obj);
                        }

                        if (element.Children == null)
                        {
                            element.Children = new List<BinaryPackerElement>();
                        }

                        if (element2 == null)
                        {
                            List<BinaryPackerElement> children2 = level.Children;
                            BinaryPackerElement obj2 = new BinaryPackerElement
                            {
                                Name = "triggers"
                            };
                            element2 = obj2;
                            children2.Add(obj2);
                        }

                        if (element2.Children == null)
                        {
                            element2.Children = new List<BinaryPackerElement>();
                        }

                        if (Enumerable.Contains(LevelTags, "checkpoint") || Enumerable.Contains(LevelTags, "cp"))
                        {
                            element.Children.Add(new BinaryPackerElement
                            {
                                Name = "checkpoint",
                                Attributes = new Dictionary<string, object>
                                {
                                    { "x", "0" },
                                    { "y", "0" }
                                }
                            });
                        }

                        if (level.AttrBool("space"))
                        {
                            if (level.AttrBool("spaceSkipWrap") || Enumerable.Contains(LevelTags, "nospacewrap") ||
                                Enumerable.Contains(LevelTags, "nsw"))
                            {
                                element.Children.Add(new BinaryPackerElement
                                {
                                    Name = "everest/spaceControllerBlocker"
                                });
                            }

                            if (level.AttrBool("spaceSkipGravity") ||
                                Enumerable.Contains(LevelTags, "nospacegravity") ||
                                Enumerable.Contains(LevelTags, "nsg"))
                            {
                                element.Children.Add(new BinaryPackerElement
                                {
                                    Name = "everest/spaceController"
                                });
                                level.SetAttr("space", false);
                            }

                            if (!Enumerable.Contains(LevelTags, "nospacefix") &&
                                !Enumerable.Contains(LevelTags, "nsf") &&
                                !element2.Children.Any((BinaryPackerElement el) =>
                                    el.Name == "cameraTargetTrigger") &&
                                !element.Children.Any((BinaryPackerElement el) =>
                                    el.Name == "everest/spaceControllerBlocker"))
                            {
                                int num = level.AttrInt("height");
                                num /= 8;
                                if (num % 2 == 0)
                                {
                                    num--;
                                }

                                num *= 8;
                                element2.Children.Add(new BinaryPackerElement
                                {
                                    Name = "cameraTargetTrigger",
                                    Attributes = new Dictionary<string, object>
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
                                        { "lerpStrength", 1f }
                                    },
                                    Children = new List<BinaryPackerElement>
                                    {
                                        new BinaryPackerElement
                                        {
                                            Attributes = new Dictionary<string, object>
                                            {
                                                { "x", 160f },
                                                {
                                                    "y",
                                                    (float)num / 2f
                                                }
                                            }
                                        }
                                    }
                                });
                            }
                        }
                    }
                },
                {
                    "entities",
                    delegate(BinaryPackerElement levelChild)
                    {
                        foreach (BinaryPackerElement child5 in levelChild.Children)
                        {
                            if (child5.Name == "checkpoint")
                            {
                                if (CheckpointsAuto != null)
                                {
                                    EverestMapMetadata modeMeta = base.AreaData.GetModeMeta(base.AreaKey.Mode);
                                    global::Celeste.Everest.Content.Maps.Metadata.EverestCheckpointData c =
                                        new global::Celeste.Everest.Content.Maps.Metadata.EverestCheckpointData(
                                            LevelName,
                                            InstalledDialogKeySource.Keyify(base.AreaData.SID + "_" + LevelName),
                                            EverestMapMetadata.GetInventory(child5.Attr("inventory")),
                                            (!(child5.Attr("dreaming") == ""))
                                                ? child5.AttrBool("dreaming")
                                                : (modeMeta.Dreaming ?? base.AreaData.Dreaming));
                                    c.Area = base.AreaKey;
                                    if (child5.Attr("coreMode") == "")
                                    {
                                        c.CoreMode = modeMeta.CoreMode ?? base.AreaData.CoreMode;
                                    }
                                    else
                                    {
                                        child5.AttrIf("coreMode",
                                            delegate(string v)
                                            {
                                                c.CoreMode = (RoomCoreMode)Enum.Parse(typeof(RoomCoreMode), v,
                                                    ignoreCase: true);
                                            });
                                    }

                                    int num = child5.AttrInt("checkpointID", -1);
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
                                            str.AppendFormatted(base.Mode.Path);
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
                        }

                        foreach (BinaryPackerElement child6 in levelChild.Children)
                        {
                            base.Context.Run("entity:" + child6.Name, child6);
                        }
                    }
                },
                {
                    "entity:cassette",
                    delegate
                    {
                        if (base.AreaData.CassetteCheckpointIndex < 0)
                        {
                            base.AreaData.CassetteCheckpointIndex = Checkpoint;
                        }

                        if (base.ParentAreaData.CassetteCheckpointIndex < 0)
                        {
                            EverestArea parentAreaData = base.ParentAreaData;
                            int checkpoint = Checkpoint;
                            OriginalCheckpointData[] checkpoints = base.ParentMode.Checkpoints;
                            parentAreaData.CassetteCheckpointIndex =
                                checkpoint + ((checkpoints != null) ? checkpoints.Length : 0);
                        }

                        base.MapData.DetectedCassette = true;
                        base.ParentMapData.DetectedCassette = true;
                    }
                },
                {
                    "entity:strawberry",
                    delegate(BinaryPackerElement entity)
                    {
                        if (!entity.AttrBool("moon"))
                        {
                            int num = entity.AttrInt("checkpointID", -1);
                            if (num == -1)
                            {
                                entity.SetAttr("checkpointID", Checkpoint);
                                num = Checkpoint;
                            }

                            MaxBerryCheckpoint = Math.Max(MaxBerryCheckpoint, num);
                            int num2 = entity.AttrInt("order", -1);
                            if (num2 == -1)
                            {
                                if (!AutomaticBerriesPerCheckpoint.ContainsKey(num))
                                {
                                    AutomaticBerriesPerCheckpoint[num] = new List<BinaryPackerElement>();
                                }

                                AutomaticBerriesPerCheckpoint[num].Add(entity);
                            }
                            else
                            {
                                if (!PlacedBerriesPerCheckpoint.ContainsKey(num))
                                {
                                    PlacedBerriesPerCheckpoint[num] = new Dictionary<int, BinaryPackerElement>();
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
                                        str.AppendFormatted(base.Mode.Path);
                                        str.AppendLiteral(". Reassigning berry order.");
                                    }

                                    ((IEverestLoggerProcessEnvironment)process).Logger.EndCoreMapFixupWarning(ref str,
                                        shouldLog);
                                    if (!AutomaticBerriesPerCheckpoint.ContainsKey(num))
                                    {
                                        AutomaticBerriesPerCheckpoint[num] = new List<BinaryPackerElement>();
                                    }

                                    AutomaticBerriesPerCheckpoint[num].Add(entity);
                                }
                                else
                                {
                                    PlacedBerriesPerCheckpoint[num][num2] = entity;
                                    MaximumBerryOrderPerCheckpoint[num] =
                                        Math.Max(MaximumBerryOrderPerCheckpoint[num], num2);
                                }
                            }

                            int num3 = num;
                            OriginalCheckpointData[] checkpoints = base.ParentMode.Checkpoints;
                            entity.SetAttr("checkpointIDParented",
                                num3 + ((checkpoints != null) ? checkpoints.Length : 0));
                        }
                    }
                }
            };
        }

        public override void Run(string stepName, BinaryPackerElement el)
        {
            if (((ISourceInstalledStrawberryRegistryEnvironment)process).StrawberryRegistry.IsRegisteredBerry(el.Name))
            {
                TotalStrawberriesIncludingUntracked++;
                if (((ISourceInstalledStrawberryRegistryEnvironment)process).StrawberryRegistry.TrackableContains(el))
                {
                    stepName = "entity:strawberry";
                }
            }

            base.Run(stepName, el);
        }

        public override void End()
        {
            base.Mode.Checkpoints = CheckpointsAuto.ToArray();
            if (base.Mode != base.ParentMode)
            {
                if (base.ParentMode.Checkpoints == null)
                {
                    base.ParentMode.Checkpoints = CheckpointsAuto.ToArray();
                }
                else
                {
                    base.ParentMode.Checkpoints = base.ParentMode.Checkpoints.Concat(CheckpointsAuto).ToArray();
                }
            }

            base.MapData.DetectedStrawberriesIncludingUntracked = TotalStrawberriesIncludingUntracked;
            if (base.MapData != base.ParentMapData)
            {
                base.ParentMapData.DetectedStrawberriesIncludingUntracked =
                    base.ParentMapData.DetectedStrawberriesIncludingUntracked + TotalStrawberriesIncludingUntracked;
            }
        }
    }
}
