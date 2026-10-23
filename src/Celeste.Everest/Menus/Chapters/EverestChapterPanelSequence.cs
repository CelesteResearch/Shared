using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Menus.MapSearch;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Menus.Chapters
{
    public class EverestChapterPanelSequence : ChapterPanelSequence
    {
        private bool instantClose;

        public EverestChapterPanelSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            var selections = ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection;
            if (Process.SaveContext.CurrentSave != null &&
                selections.GetLastAreaSafe(Process.SaveContext.CurrentSave).ID == -1)
            {
                selections.SetLastAreaSafe(Process.SaveContext.CurrentSave, AreaKeys.Default);
                instantClose = true;
            }

            if (start == OverworldStartMode.AreaComplete || start == OverworldStartMode.AreaQuit)
            {
                var areaData =
                    AreaKeys.GetAreaById(selections.GetLastAreaSafe(Process.SaveContext.CurrentSave).ID);
                areaData = AreaKeys.GetAreaBySID((areaData as EverestArea)?.Metadata?.Parent) ?? areaData;
                if (areaData != null)
                    selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID = areaData.ID;
            }

            var result = base.IsStart(overworld, start);
            if (result && option >= options.Count && options.Count == 1)
                AddRemixButton();
            if (result && option >= options.Count && options.Count == 2)
                options.Add(new(engine)
                {
                    Label = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("overworld_remix2"),
                    Icon = Graphics.GuiAtlas[ModMenuTexture("menu/rmx2")],
                    ID = "C",
                    Bg = Graphics.GuiAtlas[ModAreaselectTexture("areaselect/tab")],
                });
            return result;
        }

        public override IEnumerator Enter(OuiState from)
        {
            return instantClose ? EnterClose(from) : base.Enter(from);
        }

        private IEnumerator EnterClose(OuiState from)
        {
            Overworld.Goto<ChapterSelectSequence>();
            Visible = false;
            instantClose = false;
            yield break;
        }

        public override void Update()
        {
            if (Selected && Focused && Input.QuickRestart.Pressed)
            {
                Overworld.Goto<ChapterSelectSequence>();
                Overworld.Goto<EverestMapSearchSequence>();
            }
            else if (instantClose)
            {
                Overworld.Goto<ChapterSelectSequence>();
                Visible = false;
                instantClose = false;
            }
            else
            {
                base.Update();
            }
        }

        protected override string GetStartLabel()
        {
            var name = $"{AreaKeys.GetSID(Area)}/{(char)(65 + Area.Mode)}/start";
            var dialog = ((IOriginalGameTextEnvironment)engine).Text.Dialog;
            if (AreaKeys.GetArea(Area).LevelSet == "Celeste" || !dialog.Has(name))
                return dialog.Clean("overworld_start");
            return dialog.Clean(name);
        }

        protected override string GetCheckpointLabel(string level)
        {
            return AreaKeys.GetCheckpointName(Area, level, engine);
        }

        protected override HashSet<string> GetPanelCheckpoints()
        {
            var save = Process.SaveContext.CurrentSave;
            var area = Area;
            if (((IOriginalGamePlayModeEnvironment)engine).PlayMode == GameRuntime.PlayModes.Event)
                return [];
            var areaData = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[area.ID];
            var mode = areaData.Mode[area.Mode];
            HashSet<string> checkpoints;
            if (save.DebugMode || save.CheatMode)
            {
                checkpoints = [];
                if (mode.Checkpoints != null)
                    foreach (var checkpoint in mode.Checkpoints)
                        checkpoints.Add(
                            $"{(AreaKeys.GetArea(((EverestCheckpointData)checkpoint).Area) ?? areaData).SID}|{checkpoint.Level}");
                return checkpoints;
            }

            checkpoints = ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(save)[area.ID]
                .Modes[area.Mode].Checkpoints;
            if (mode == null)
            {
                checkpoints.Clear();
                return checkpoints;
            }

            checkpoints.RemoveWhere(a => !mode.Checkpoints.Any(b => b.Level == a));
            var subs = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas
                .Where(other => (other as EverestArea)?.Metadata?.Parent == areaData.SID && other.HasMode(area.Mode))
                .ToArray();
            return /* ReSharper disable once UseCollectionExpression */ new(checkpoints.Select(value =>
            {
                foreach (var sub in subs)
                foreach (var checkpoint in sub.Mode[area.Mode].Checkpoints)
                    if (checkpoint.Level == value)
                        return $"{sub.SID}|{value}";
                return value;
            }));
        }

        private string ModAreaselectTexture(string textureName)
        {
            var name = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Area.ID].Name;
            var text = textureName.Replace("areaselect/", $"areaselect/{name}_");
            if (Graphics.GuiAtlas.Has(text))
            {
                textureName = text;
                return textureName;
            }

            var arg = (Process.SaveContext.CurrentSave == null
                          ? null
                          : ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSet(Process.SaveContext
                              .CurrentSave)) ??
                      "Celeste";
            var text2 = textureName.Replace("areaselect/", $"areaselect/{arg}/");
            if (Graphics.GuiAtlas.Has(text2))
            {
                textureName = text2;
                return textureName;
            }

            return textureName;
        }

        private string ModMenuTexture(string textureName)
        {
            var name = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Area.ID].Name;
            var text = textureName.Replace("menu/", "menu/" + name + "_");
            if (Graphics.GuiAtlas.Has(text))
            {
                textureName = text;
                return textureName;
            }

            var text2 =
                (Process.SaveContext.CurrentSave == null
                    ? null
                    : ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets
                    .GetLevelSet(Process.SaveContext.CurrentSave)) ?? "Celeste";
            var text3 = textureName.Replace("menu/", "menu/" + text2 + "/");
            if (Graphics.GuiAtlas.Has(text3))
            {
                textureName = text3;
                return textureName;
            }

            return textureName;
        }


        private static float vanillaOffsetForStrawberryWidth;

        protected override string GetAreaselectTexture(string path)
        {
            return ModAreaselectTexture(path);
        }

        protected override string GetMenuTexture(string path)
        {
            return ModMenuTexture(path);
        }

        protected override float GetTitleOffset(float originalValue)
        {
            var x = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont
                .Measure(((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(AreaKeys.GetArea(Area).Name)).X;
            return originalValue - Math.Max(0f, x + originalValue - 490f);
        }

        protected override float GetStrawberryWidth(float originalValue, int strawberryCount, int checkpointIndex)
        {
            float limit = Area.Mode == (int)OriginalAreaMode.Normal && Data.CassetteCheckpointIndex == checkpointIndex
                ? 440
                : 520;
            var width = originalValue;
            if (originalValue * strawberryCount > limit) width = limit / strawberryCount;
            vanillaOffsetForStrawberryWidth = originalValue - width;
            return width;
        }

        protected override Vector2 CorrectInitialStrawberryOffset(Vector2 offset, Vector2 direction)
        {
            offset -= direction * vanillaOffsetForStrawberryWidth;
            return offset;
        }

        protected override AtlasEntry GetCheckpointPreview(OriginalAreaKey area, string level)
        {
            var name = EverestCheckpointPreviewNames.Get(engine, area, level);
            return MountainResources.Checkpoints.Has(name) ? MountainResources.Checkpoints[name] : null;
        }

        protected override void DrawCheckpoint(ISourceRenderContext context, Vector2 center, Option option,
            int checkpointIndex)
        {
            var areaData = ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[Area.ID];
            var mode = areaData.Mode[Area.Mode];
            if (mode.Checkpoints != null)
                for (var i = 0; i < mode.Checkpoints.Length; i++)
                {
                    var checkpoint = mode.Checkpoints[i];
                    if (option.CheckpointLevelName == checkpoint.Level || option.CheckpointLevelName ==
                        (AreaKeys.GetArea(((EverestCheckpointData)checkpoint).Area) ?? areaData).SID + "|" +
                        checkpoint.Level)
                    {
                        checkpointIndex = i + 1;
                        break;
                    }
                }

            base.DrawCheckpoint(context, center, option, checkpointIndex);
        }

        protected override void ApplyOptionBackground(Option option)
        {
            option.Bg = Graphics.GuiAtlas[ModAreaselectTexture("areaselect/tab")];
        }

        protected override bool GetAreaInterlude(IOriginalAreaData area)
        {
            return EverestAreaSafeQueries.GetInterlude(engine, area);
        }

        protected override bool GetAreaIsFinal(IOriginalAreaData area)
        {
            return EverestAreaSafeQueries.GetIsFinal(engine, area);
        }

        protected override ChapterCompletionSession CreateStartSession(string checkpoint)
        {
            ChapterCompletionSession session = null;
            try
            {
                session = ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(Area, checkpoint);
            }
            catch (Exception e)
            {
                ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Error, "OuiChapterPanel",
                    "Failed to construct session!");
                ((IEverestLoggerProcessEnvironment)engine).Logger.LogDetailed(e, "OuiChapterPanel");
                if (((IOriginalLevelEnterStaticEnvironment)engine).LevelEnterStatics.ErrorMessage == null) throw;
            }

            return session;
        }
    }
}
