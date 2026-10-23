using Celeste.Input.Devices.Keyboard;
using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Title;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Data;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Content.Dialogs;
using Celeste.Everest.Menus.MapList;
using Celeste.Everest.Menus.MapSearch;
using Celeste.Game.Menus.Chapters;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.Menus.Chapters
{
    public class EverestChapterSelectSequence : ChapterSelectSequence
    {
        public EverestChapterSelectSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override ChapterSelectIconPresentation CreateIcon(int area, AtlasEntry front, AtlasEntry back) =>
            new EverestChapterSelectIconPresentation(engine, area, front, back);

        private AtlasEntry levelSetScarf;
#pragma warning disable CS0169
        private float journallEase;
#pragma warning restore CS0169
        private float maplistEase, searchEase, levelsetEase;
        private string currentLevelSet;
        private SourceKeyboardState _keys;
        private IOriginalSaveLevelSetQueries LevelSets => ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets;

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            if (start == OverworldStartMode.AreaComplete || start == OverworldStartMode.AreaQuit)
            {
                IOriginalAreaData areaData =
                    AreaKeys.GetAreaById(Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID);
                areaData = AreaKeys.GetAreaBySID((areaData as EverestArea)?.Metadata?.Parent) ?? areaData;
                if (areaData != null)
                {
                    Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID = areaData.ID;
                }
            }

            return base.IsStart(overworld, start);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            _ = Process.SaveContext.CurrentSave;
            for (int num = icons.Count - 1; num > -1; num--)
            {
                if (!string.IsNullOrEmpty((AreaKeys.GetAreaById(icons[num].Area) as EverestArea)?.Metadata?.Parent))
                {
                    icons[num].Area = -1;
                    icons[num].Hide();
                }
            }
        }

        public override IEnumerator Enter(OuiState from)
        {
            GetMinMaxArea(out var areaOffs, out var areaMax);
            int num = area;
            area = ScalarMath.Clamp(area, areaOffs, areaMax);
            Visible = true;
            EaseCamera();
            display = true;
            currentLevelSet =
                (Process.SaveContext.CurrentSave == null
                    ? null
                    : LevelSets.GetLevelSet(Process.SaveContext.CurrentSave)) ??
                "Celeste";
            journalEnabled = string.IsNullOrEmpty(currentLevelSet) ||
                             ((IOriginalGamePlayModeEnvironment)engine).PlayMode ==
                             GameRuntime.PlayModes.Debug ||
                             (Process.SaveContext.CurrentSave?.CheatMode ?? false);
            for (int i = 0; i <= Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave); i++)
            {
                if (journalEnabled)
                {
                    break;
                }

                if (Counters.GetAreasSafe(Process.SaveContext.CurrentSave)[i].Modes[0].TimePlayed > 0 &&
                    !EverestAreaSafeQueries.GetInterlude(engine, AreaKeys.GetAreaById(i)))
                {
                    journalEnabled = true;
                }
            }

            ChapterSelectIconPresentation unselected = null;
            if (from is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                unselected = (ouiChapterSelectIcon = icons[num]);
                ouiChapterSelectIcon.Unselect();
                if (num != area)
                {
                    unselected.Hide();
                }
            }

            levelSetScarf =
                Graphics.GuiAtlas.GetOrDefault("areas/" + currentLevelSet + "/hover", Graphics.GuiAtlas["areas/hover"]);
            updateScarf();
            bool isVanilla = currentLevelSet == "Celeste";
            foreach (ChapterSelectIconPresentation icon in icons)
            {
                IOriginalAreaData areaData = AreaKeys.GetAreaById(icon.Area);
                if (areaData != null && !(areaData.LevelSet != currentLevelSet))
                {
                    int iD = AreaKeys.ToKey(areaData).ID;
                    if ((string.IsNullOrEmpty(currentLevelSet) || iD <= Math.Max(1,
                            Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave))) && icon != unselected)
                    {
                        icon.Position = icon.HiddenPosition;
                        icon.Show();
                        icon.AssistModeUnlockable = false;
                    }
                    else if (Process.SaveContext.CurrentSave.AssistMode &&
                             iD == Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) + 1)
                    {
                        icon.Position = icon.HiddenPosition;
                        icon.Show();
                        icon.AssistModeUnlockable = true;
                    }

                    if (isVanilla)
                    {
                        yield return 0.01f;
                    }
                }
            }

            if (from is ChapterPanelSequence)
            {
                yield return 0.25f;
            }
        }

        protected override IEnumerator EaseOut(OuiState next)
        {
            ChapterSelectIconPresentation selected = null;
            if (next is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                selected = (ouiChapterSelectIcon = icons[area]);
                ouiChapterSelectIcon.Select();
            }

            bool isVanilla = currentLevelSet == "Celeste";
            foreach (ChapterSelectIconPresentation icon in icons)
            {
                IOriginalAreaData areaData = AreaKeys.GetAreaById(icon.Area);
                if (areaData != null && !(areaData.LevelSet != currentLevelSet))
                {
                    if (selected != icon)
                    {
                        icon.Hide();
                    }

                    if (isVanilla)
                    {
                        yield return 0.01f;
                    }
                }
            }

            Visible = false;
        }

        public override void Update()
        {
            _ = _keys;
            SourceKeyboardState state = ((ISourceFnaKeyboardStateEnvironment)engine).KeyboardState.GetState();
            _keys = state;
            if (Focused && !disableInput && display)
            {
                if (Input.Pause.Pressed || Input.ESC.Pressed)
                {
                    base.Overworld.Maddy.Hide();
                    Audio.Play("event:/ui/main/button_select");
                    Audio.Play("event:/ui/main/whoosh_large_in");
                    base.Overworld.Goto<EverestMapListSequence>().OuiIcons = icons;
                    return;
                }

                if (Input.QuickRestart.Pressed)
                {
                    base.Overworld.Maddy.Hide();
                    Audio.Play("event:/ui/main/button_select");
                    Audio.Play("event:/ui/main/whoosh_large_in");
                    base.Overworld.Goto<EverestMapSearchSequence>().OuiIcons = icons;
                    return;
                }
            }

            if (Focused && display && !disableInput && inputDelay <= engine.DeltaTime)
            {
                if (Input.MenuUp.Pressed)
                {
                    Audio.Play("event:/ui/world_map/chapter/pane_contract");
                    Audio.Play("event:/ui/world_map/icon/roll_left");
                    base.Overworld.Goto<EverestChapterLevelSetPickerSequence>().Direction = -1;
                    return;
                }

                if (Input.MenuDown.Pressed)
                {
                    Audio.Play("event:/ui/world_map/chapter/pane_expand");
                    Audio.Play("event:/ui/world_map/icon/roll_right");
                    base.Overworld.Goto<EverestChapterLevelSetPickerSequence>().Direction = 1;
                    return;
                }

                GetMinMaxArea(out var areaOffs, out var areaMax);
                if (area < areaOffs)
                {
                    area = areaOffs;
                }
                else
                {
                    if (area > areaMax)
                    {
                        area = areaMax;
                    }

                    while (area > 0 && ((EverestChapterSelectIconPresentation)icons[area]).IsHidden)
                    {
                        area--;
                    }
                }

                if ((Input.MenuLeft.Pressed &&
                     (area - 1 < 0 || ((EverestChapterSelectIconPresentation)icons[area - 1]).IsHidden)) ||
                    (Input.MenuRight.Pressed && (area + 1 >= icons.Count ||
                                                 ((EverestChapterSelectIconPresentation)icons[area + 1]).IsHidden)))
                {
                    return;
                }
            }

            base.Update();
            if (Focused && display)
            {
                updateScarf();
            }

            maplistEase = Approach(maplistEase, (display && !disableInput && Focused) ? 1f : 0f, engine.DeltaTime * 4f);
            searchEase = Approach(searchEase, (display && !disableInput && Focused) ? 1f : 0f, engine.DeltaTime * 4f);
            levelsetEase = Approach(levelsetEase, (display && !disableInput && Focused) ? 1f : 0f,
                engine.DeltaTime * 4f);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (maplistEase > 0f)
            {
                Vector2 position = new Vector2(128f * Easing.CubeOut(maplistEase), 952f);
                if (journalEnabled)
                {
                    position.Y -= 128f;
                }

                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["menu/maplist"], position,
                    PackedColor.White * Easing.CubeOut(maplistEase));
                SourceAtlasDrawing.Draw(context, this,
                    (Input.GuiInputController() ? Input.GuiButton(Input.Pause) : Input.GuiButton(Input.ESC)), position,
                    Vector2.Zero, PackedColor.White * Easing.CubeOut(maplistEase));
            }

            if (searchEase > 0f)
            {
                Vector2 position2 = new Vector2(128f * Easing.CubeOut(searchEase), 952f);
                if (journalEnabled)
                {
                    position2.Y -= 256f;
                }
                else
                {
                    position2.Y -= 128f;
                }

                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["menu/mapsearch"], position2,
                    PackedColor.White * Easing.CubeOut(searchEase));
                SourceAtlasDrawing.Draw(context, this, Input.GuiKey(Input.FirstKey(Input.QuickRestart)), position2,
                    Vector2.Zero, PackedColor.White * Easing.CubeOut(searchEase));
            }

            if (levelsetEase > 0f)
            {
                Vector2 vector = new Vector2(1920f - 64f * Easing.CubeOut(maplistEase), 952f);
                string text =
                    ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(currentLevelSet);
                Text.ActiveFont.DrawOutline(context, this, text, vector, new Vector2(1f, 0.5f), Vector2.One * 0.7f,
                    PackedColor.White * Easing.CubeOut(maplistEase), 2f,
                    PackedColor.Black * Easing.CubeOut(maplistEase));
                Vector2 vector2 = Text.ActiveFont.Measure(text) * 0.7f;
                SourceAtlasDrawing.DrawCentered(context, this, Input.GuiDirection(new Vector2(0f, -1f)),
                    vector + new Vector2((0f - vector2.X) * 0.5f, (0f - vector2.Y) * 0.5f - 16f),
                    PackedColor.White * Easing.CubeOut(maplistEase), 0.5f);
                SourceAtlasDrawing.DrawCentered(context, this, Input.GuiDirection(new Vector2(0f, 1f)),
                    vector + new Vector2((0f - vector2.X) * 0.5f, vector2.Y * 0.5f + 16f),
                    PackedColor.White * Easing.CubeOut(maplistEase), 0.5f);
            }
        }

        protected override void EaseCamera()
        {
            IOriginalAreaData areaData = Areas.Areas[area];
            base.Overworld.Mountain.EaseCamera(area, areaData.MountainIdle, null, nearTarget: true,
                targetRotate: (areaData as EverestArea)?.Metadata?.Mountain?.Rotate ??
                              (areaData.LevelSet == "Celeste" && area == 10));
            base.Overworld.Mountain.Model.EaseState(areaData.MountainState);
        }

        private void GetMinMaxArea(out int areaOffs, out int areaMax)
        {
            int areaOffsRaw = LevelSets.GetLevelSetStats(Process.SaveContext.CurrentSave).AreaOffset;
            int areaMaxRaw = Math.Max(areaOffsRaw, Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave));
            do
            {
                areaOffs = icons.FindIndex((ChapterSelectIconPresentation i) => i != null && i.Area == areaOffsRaw);
            } while (areaOffs == -1 && ++areaOffsRaw < areaMaxRaw);

            if (areaOffs == -1)
            {
                areaOffs = areaOffsRaw;
            }

            do
            {
                areaMax = icons.FindLastIndex((ChapterSelectIconPresentation i) =>
                    (i != null && i.Area == areaMaxRaw) || i.AssistModeUnlockable);
            } while (areaMax == -1 && --areaMaxRaw < areaOffsRaw);

            if (areaMax == -1)
            {
                areaMax = areaMaxRaw;
            }
        }

        private void updateScarf()
        {
            string text = "areas/" + Areas.Areas[area].Name.ToLowerInvariant() + "_hover";
            if (!text.Equals(scarf.Name))
            {
                scarf = Graphics.GuiAtlas.GetOrDefault(text, levelSetScarf);
                scarfSegments = new AtlasEntry[scarf.FrameHeight / 2];
                for (int i = 0; i < scarfSegments.Length; i++)
                {
                    scarfSegments[i] = scarf.GetSubtexture(0, i * 2, scarf.FrameWidth, 2);
                }
            }
        }
    }
}
