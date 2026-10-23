using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Dialogs;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Menus.MapList;
using Celeste.Everest.Menus.MapSearch;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Menus.Chapters
{
    public class EverestChapterSelectSequence : ChapterSelectSequence
    {
        public EverestChapterSelectSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override ChapterSelectIconPresentation CreateIcon(int area, AtlasEntry front, AtlasEntry back)
        {
            return new EverestChapterSelectIconPresentation(engine, area, front, back);
        }

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
                var areaData =
                    AreaKeys.GetAreaById(Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID);
                areaData = AreaKeys.GetAreaBySID((areaData as EverestArea)?.Metadata?.Parent) ?? areaData;
                if (areaData != null) Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID = areaData.ID;
            }

            return base.IsStart(overworld, start);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            _ = Process.SaveContext.CurrentSave;
            for (var num = icons.Count - 1; num > -1; num--)
                if (!string.IsNullOrEmpty((AreaKeys.GetAreaById(icons[num].Area) as EverestArea)?.Metadata?.Parent))
                {
                    icons[num].Area = -1;
                    icons[num].Hide();
                }
        }

        public override IEnumerator Enter(OuiState from)
        {
            GetMinMaxArea(out var areaOffs, out var areaMax);
            var num = area;
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
            for (var i = 0; i <= Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave); i++)
            {
                if (journalEnabled) break;

                if (Counters.GetAreasSafe(Process.SaveContext.CurrentSave)[i].Modes[0].TimePlayed > 0 &&
                    !EverestAreaSafeQueries.GetInterlude(engine, AreaKeys.GetAreaById(i)))
                    journalEnabled = true;
            }

            ChapterSelectIconPresentation unselected = null;
            if (from is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                unselected = ouiChapterSelectIcon = icons[num];
                ouiChapterSelectIcon.Unselect();
                if (num != area) unselected.Hide();
            }

            levelSetScarf =
                Graphics.GuiAtlas.GetOrDefault("areas/" + currentLevelSet + "/hover", Graphics.GuiAtlas["areas/hover"]);
            updateScarf();
            var isVanilla = currentLevelSet == "Celeste";
            foreach (var icon in icons)
            {
                var areaData = AreaKeys.GetAreaById(icon.Area);
                if (areaData != null && !(areaData.LevelSet != currentLevelSet))
                {
                    var iD = AreaKeys.ToKey(areaData).ID;
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

                    if (isVanilla) yield return 0.01f;
                }
            }

            if (from is ChapterPanelSequence) yield return 0.25f;
        }

        protected override IEnumerator EaseOut(OuiState next)
        {
            ChapterSelectIconPresentation selected = null;
            if (next is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                selected = ouiChapterSelectIcon = icons[area];
                ouiChapterSelectIcon.Select();
            }

            var isVanilla = currentLevelSet == "Celeste";
            foreach (var icon in icons)
            {
                var areaData = AreaKeys.GetAreaById(icon.Area);
                if (areaData != null && !(areaData.LevelSet != currentLevelSet))
                {
                    if (selected != icon) icon.Hide();

                    if (isVanilla) yield return 0.01f;
                }
            }

            Visible = false;
        }

        public override void Update()
        {
            _ = _keys;
            var state = ((ISourceFnaKeyboardStateEnvironment)engine).KeyboardState.GetState();
            _keys = state;
            if (Focused && !disableInput && display)
            {
                if (Input.Pause.Pressed || Input.ESC.Pressed)
                {
                    Overworld.Maddy.Hide();
                    Audio.Play("event:/ui/main/button_select");
                    Audio.Play("event:/ui/main/whoosh_large_in");
                    Overworld.Goto<EverestMapListSequence>().OuiIcons = icons;
                    return;
                }

                if (Input.QuickRestart.Pressed)
                {
                    Overworld.Maddy.Hide();
                    Audio.Play("event:/ui/main/button_select");
                    Audio.Play("event:/ui/main/whoosh_large_in");
                    Overworld.Goto<EverestMapSearchSequence>().OuiIcons = icons;
                    return;
                }
            }

            if (Focused && display && !disableInput && inputDelay <= engine.DeltaTime)
            {
                if (Input.MenuUp.Pressed)
                {
                    Audio.Play("event:/ui/world_map/chapter/pane_contract");
                    Audio.Play("event:/ui/world_map/icon/roll_left");
                    Overworld.Goto<EverestChapterLevelSetPickerSequence>().Direction = -1;
                    return;
                }

                if (Input.MenuDown.Pressed)
                {
                    Audio.Play("event:/ui/world_map/chapter/pane_expand");
                    Audio.Play("event:/ui/world_map/icon/roll_right");
                    Overworld.Goto<EverestChapterLevelSetPickerSequence>().Direction = 1;
                    return;
                }

                GetMinMaxArea(out var areaOffs, out var areaMax);
                if (area < areaOffs)
                {
                    area = areaOffs;
                }
                else
                {
                    if (area > areaMax) area = areaMax;

                    while (area > 0 && ((EverestChapterSelectIconPresentation)icons[area]).IsHidden) area--;
                }

                if ((Input.MenuLeft.Pressed &&
                     (area - 1 < 0 || ((EverestChapterSelectIconPresentation)icons[area - 1]).IsHidden)) ||
                    (Input.MenuRight.Pressed && (area + 1 >= icons.Count ||
                                                 ((EverestChapterSelectIconPresentation)icons[area + 1]).IsHidden)))
                    return;
            }

            base.Update();
            if (Focused && display) updateScarf();

            maplistEase = Approach(maplistEase, display && !disableInput && Focused ? 1f : 0f, engine.DeltaTime * 4f);
            searchEase = Approach(searchEase, display && !disableInput && Focused ? 1f : 0f, engine.DeltaTime * 4f);
            levelsetEase = Approach(levelsetEase, display && !disableInput && Focused ? 1f : 0f,
                engine.DeltaTime * 4f);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (maplistEase > 0f)
            {
                var position = new Vector2(128f * Easing.CubeOut(maplistEase), 952f);
                if (journalEnabled) position.Y -= 128f;

                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["menu/maplist"], position,
                    PackedColor.White * Easing.CubeOut(maplistEase));
                SourceAtlasDrawing.Draw(context, this,
                    Input.GuiInputController() ? Input.GuiButton(Input.Pause) : Input.GuiButton(Input.ESC), position,
                    Vector2.Zero, PackedColor.White * Easing.CubeOut(maplistEase));
            }

            if (searchEase > 0f)
            {
                var position2 = new Vector2(128f * Easing.CubeOut(searchEase), 952f);
                if (journalEnabled)
                    position2.Y -= 256f;
                else
                    position2.Y -= 128f;

                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["menu/mapsearch"], position2,
                    PackedColor.White * Easing.CubeOut(searchEase));
                SourceAtlasDrawing.Draw(context, this, Input.GuiKey(Input.FirstKey(Input.QuickRestart)), position2,
                    Vector2.Zero, PackedColor.White * Easing.CubeOut(searchEase));
            }

            if (levelsetEase > 0f)
            {
                var vector = new Vector2(1920f - 64f * Easing.CubeOut(maplistEase), 952f);
                var text =
                    ((IEverestDialogLevelSetEnvironment)engine).DialogLevelSets.CleanLevelSet(currentLevelSet);
                Text.ActiveFont.DrawOutline(context, this, text, vector, new(1f, 0.5f), Vector2.One * 0.7f,
                    PackedColor.White * Easing.CubeOut(maplistEase), 2f,
                    PackedColor.Black * Easing.CubeOut(maplistEase));
                var vector2 = Text.ActiveFont.Measure(text) * 0.7f;
                SourceAtlasDrawing.DrawCentered(context, this, Input.GuiDirection(new(0f, -1f)),
                    vector + new Vector2((0f - vector2.X) * 0.5f, (0f - vector2.Y) * 0.5f - 16f),
                    PackedColor.White * Easing.CubeOut(maplistEase), 0.5f);
                SourceAtlasDrawing.DrawCentered(context, this, Input.GuiDirection(new(0f, 1f)),
                    vector + new Vector2((0f - vector2.X) * 0.5f, vector2.Y * 0.5f + 16f),
                    PackedColor.White * Easing.CubeOut(maplistEase), 0.5f);
            }
        }

        protected override void EaseCamera()
        {
            var areaData = Areas.Areas[area];
            Overworld.Mountain.EaseCamera(area, areaData.MountainIdle, null, true,
                (areaData as EverestArea)?.Metadata?.Mountain?.Rotate ??
                (areaData.LevelSet == "Celeste" && area == 10));
            Overworld.Mountain.Model.EaseState(areaData.MountainState);
        }

        private void GetMinMaxArea(out int areaOffs, out int areaMax)
        {
            var areaOffsRaw = LevelSets.GetLevelSetStats(Process.SaveContext.CurrentSave).AreaOffset;
            var areaMaxRaw = Math.Max(areaOffsRaw, Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave));
            do
            {
                areaOffs = icons.FindIndex(i => i != null && i.Area == areaOffsRaw);
            } while (areaOffs == -1 && ++areaOffsRaw < areaMaxRaw);

            if (areaOffs == -1) areaOffs = areaOffsRaw;

            do
            {
                areaMax = icons.FindLastIndex(i =>
                    (i != null && i.Area == areaMaxRaw) || i.AssistModeUnlockable);
            } while (areaMax == -1 && --areaMaxRaw < areaOffsRaw);

            if (areaMax == -1) areaMax = areaMaxRaw;
        }

        private void updateScarf()
        {
            var text = "areas/" + Areas.Areas[area].Name.ToLowerInvariant() + "_hover";
            if (!text.Equals(scarf.Name))
            {
                scarf = Graphics.GuiAtlas.GetOrDefault(text, levelSetScarf);
                scarfSegments = new AtlasEntry[scarf.FrameHeight / 2];
                for (var i = 0; i < scarfSegments.Length; i++)
                    scarfSegments[i] = scarf.GetSubtexture(0, i * 2, scarf.FrameWidth, 2);
            }
        }
    }
}
