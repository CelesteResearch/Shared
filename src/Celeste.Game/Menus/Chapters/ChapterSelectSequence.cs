using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Menus.Chapters
{
    public class ChapterSelectSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        protected IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)engine).AreaKeys;

        protected IOriginalSaveProgressionPolicy Progression =>
            ((IOriginalSaveProgressionEnvironment)engine).SaveProgression;

        protected IOriginalSaveSessionSelectionPolicy Selections =>
            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection;

        protected IOriginalSaveCounterQueries Counters => ((IOriginalSaveCounterEnvironment)engine).SaveCounters;
        protected OriginalGameAudioSession Audio => Process.AudioSession;
        protected IOriginalAreaSourceTable Areas => ((IOriginalSessionConstructionProcess)engine).AreaTable;

        public ChapterSelectSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            scarf = Graphics.GuiAtlas["areas/hover"];
        }

        protected virtual ChapterSelectIconPresentation CreateIcon(int area, AtlasEntry front, AtlasEntry back)
        {
            return new(engine, area, front, back);
        }

        protected float Approach(float value, float target, float amount)
        {
            return ScalarMath.Approach(value, target, amount,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        protected List<ChapterSelectIconPresentation> icons = [];

        protected int indexToSnap = -1;

        protected const int scarfSegmentSize = 2;

        protected AtlasEntry scarf;

        protected AtlasEntry[] scarfSegments;

        protected float ease;

        protected float journalEase;

        protected bool journalEnabled;

        protected bool disableInput;

        protected bool display;

        protected float inputDelay;

        protected bool autoAdvancing;

        protected int area
        {
            get => Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID;
            set => Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID = value;
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            if (start == OverworldStartMode.AreaComplete || start == OverworldStartMode.AreaQuit) indexToSnap = area;

            return false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var count = Areas.Areas.Count;
            for (var i = 0; i < count; i++)
            {
                var mTexture = Graphics.GuiAtlas[Areas.Areas[i].Icon];
                var back = Graphics.GuiAtlas.Has(Areas.Areas[i].Icon + "_back")
                    ? Graphics.GuiAtlas[Areas.Areas[i].Icon + "_back"]
                    : mTexture;
                icons.Add(CreateIcon(i, mTexture, back));
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(icons[i]);
            }

            scarfSegments = new AtlasEntry[scarf.FrameHeight / 2];
            for (var j = 0; j < scarfSegments.Length; j++)
                scarfSegments[j] = scarf.GetSubtexture(0, j * 2, scarf.FrameWidth, 2);

            if (indexToSnap >= 0)
            {
                area = indexToSnap;
                icons[indexToSnap].SnapToSelected();
            }

            Depth = -20;
        }

        public override IEnumerator Enter(OuiState from)
        {
            Visible = true;
            EaseCamera();
            display = true;
            journalEnabled =
                ((IOriginalGamePlayModeEnvironment)engine).PlayMode == GameRuntime.PlayModes.Debug ||
                Process.SaveContext.CurrentSave.CheatMode;
            for (var i = 0; i <= Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave); i++)
            {
                if (journalEnabled) break;

                if (Counters.GetAreasSafe(Process.SaveContext.CurrentSave)[i].Modes[0].TimePlayed > 0 &&
                    !AreaKeys.GetAreaById(i).Interlude)
                    journalEnabled = true;
            }

            ChapterSelectIconPresentation unselected = null;
            if (from is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                unselected = ouiChapterSelectIcon = icons[area];
                ouiChapterSelectIcon.Unselect();
            }

            foreach (var icon in icons)
            {
                if (icon.Area <= Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) &&
                    icon != unselected)
                {
                    icon.Position = icon.HiddenPosition;
                    icon.Show();
                    icon.AssistModeUnlockable = false;
                }
                else if (Process.SaveContext.CurrentSave.AssistMode &&
                         icon.Area == Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) + 1 &&
                         icon.Area <= Progression.GetMaxAssistArea(Process.SaveContext.CurrentSave))
                {
                    icon.Position = icon.HiddenPosition;
                    icon.Show();
                    icon.AssistModeUnlockable = true;
                }

                yield return 0.01f;
            }

            if (!autoAdvancing && Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) == 10 &&
                !Process.SaveContext.CurrentSave.RevealedChapter9)
            {
                var ch = area;
                yield return SetupCh9Unlock();
                yield return PerformCh9Unlock(ch != 10);
            }

            if (from is ChapterPanelSequence) yield return 0.25f;
        }

        public override IEnumerator Leave(OuiState next)
        {
            display = false;
            if (next is MainMenuSequence)
            {
                while (area > Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave)) area--;

                ((IOriginalUserIOEnvironment)engine).UserIO.SaveHandler(true, false);
                yield return EaseOut(next);
                while (((IOriginalUserIOEnvironment)engine).UserIO.Saving) yield return null;
            }
            else
            {
                yield return EaseOut(next);
            }
        }

        protected virtual IEnumerator EaseOut(OuiState next)
        {
            ChapterSelectIconPresentation selected = null;
            if (next is ChapterPanelSequence)
            {
                ChapterSelectIconPresentation ouiChapterSelectIcon;
                selected = ouiChapterSelectIcon = icons[area];
                ouiChapterSelectIcon.Select();
            }

            foreach (var icon in icons)
            {
                if (selected != icon) icon.Hide();

                yield return 0.01f;
            }

            Visible = false;
        }

        public void AdvanceToNext()
        {
            autoAdvancing = true;
            Overworld.ShowInputUI = false;
            Focused = false;
            disableInput = true;
            Add(new SimulationCoroutine(engine, AutoAdvanceRoutine()));
        }

        protected IEnumerator AutoAdvanceRoutine()
        {
            if (area < Progression.GetMaxArea(Process.SaveContext.CurrentSave))
            {
                var nextArea = area + 1;
                if (nextArea == 9 || nextArea == 10) icons[nextArea].HideIcon = true;

                while (!Selected) yield return null;

                yield return 1f;
                switch (nextArea)
                {
                    case 10:
                        yield return PerformCh9Unlock();
                        break;
                    case 9:
                        yield return PerformCh8Unlock();
                        break;
                    default:
                        Audio.Play("event:/ui/postgame/unlock_newchapter");
                        Audio.Play("event:/ui/world_map/icon/roll_right");
                        area = nextArea;
                        EaseCamera();
                        Overworld.Maddy.Hide();
                        break;
                }

                yield return 0.25f;
            }

            autoAdvancing = false;
            disableInput = false;
            Focused = true;
            Overworld.ShowInputUI = true;
        }

        public override void Update()
        {
            if (Focused && !disableInput)
            {
                inputDelay -= engine.DeltaTime;
                if (area >= 0 && area < Areas.Areas.Count)
                    Input.SetLightbarColor(AreaKeys.GetAreaById(area).TitleBaseColor);

                if (Input.MenuCancel.Pressed)
                {
                    Audio.Play("event:/ui/main/button_back");
                    Overworld.Goto<MainMenuSequence>();
                    Overworld.Maddy.Hide();
                }
                else if (Input.MenuJournal.Pressed && journalEnabled)
                {
                    Audio.Play("event:/ui/world_map/journal/select");
                    Overworld.Goto<OuiJournalSequence>();
                }
                else if (inputDelay <= 0f)
                {
                    if (area > 0 && Input.MenuLeft.Pressed)
                    {
                        Audio.Play("event:/ui/world_map/icon/roll_left");
                        inputDelay = 0.15f;
                        area--;
                        icons[area].Hovered(-1);
                        EaseCamera();
                        Overworld.Maddy.Hide();
                    }
                    else if (Input.MenuRight.Pressed)
                    {
                        var flag = Process.SaveContext.CurrentSave.AssistMode &&
                                   area == Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) &&
                                   area < Progression.GetMaxAssistArea(Process.SaveContext.CurrentSave);
                        if (area < Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) || flag)
                        {
                            Audio.Play("event:/ui/world_map/icon/roll_right");
                            inputDelay = 0.15f;
                            area++;
                            icons[area].Hovered(1);
                            if (area <= Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave)) EaseCamera();

                            Overworld.Maddy.Hide();
                        }
                    }
                    else if (Input.MenuConfirm.Pressed)
                    {
                        if (icons[area].AssistModeUnlockable)
                        {
                            Audio.Play("event:/ui/world_map/icon/assist_skip");
                            Focused = false;
                            Overworld.ShowInputUI = false;
                            icons[area].AssistModeUnlock(delegate
                            {
                                Focused = true;
                                Overworld.ShowInputUI = true;
                                EaseCamera();
                                if (area == 10) Process.SaveContext.CurrentSave.RevealedChapter9 = true;

                                if (area < Progression.GetMaxAssistArea(Process.SaveContext.CurrentSave))
                                {
                                    var ouiChapterSelectIcon = icons[area + 1];
                                    ouiChapterSelectIcon.AssistModeUnlockable = true;
                                    ouiChapterSelectIcon.Position = ouiChapterSelectIcon.HiddenPosition;
                                    ouiChapterSelectIcon.Show();
                                }
                            });
                        }
                        else
                        {
                            Audio.Play("event:/ui/world_map/icon/select");
                            Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).Mode =
                                (int)OriginalAreaMode.Normal;
                            Overworld.Goto<ChapterPanelSequence>();
                        }
                    }
                }
            }

            ease = Approach(ease, display ? 1f : 0f, engine.DeltaTime * 3f);
            journalEase = Approach(journalEase, display && !disableInput && Focused && journalEnabled ? 1f : 0f,
                engine.DeltaTime * 4f);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = new Vector2(960f, -scarf.FrameHeight * Easing.CubeInOut(1f - ease));
            for (var i = 0; i < scarfSegments.Length; i++)
            {
                var num = Easing.CubeIn(i / (float)scarfSegments.Length);
                var x = num *
                        (float)Math.Sin(((ISourceScene)Scene).SourceScene.Clock.RawTimeActive * 4f +
                                        i * 0.05f) *
                        4f -
                        num * 16f;
                SourceAtlasDrawing.DrawJustified(context, this, scarfSegments[i], vector + new Vector2(x, i * 2),
                    new(0.5f, 0f), PackedColor.White);
            }

            if (journalEase > 0f)
            {
                var position = new Vector2(128f * Easing.CubeOut(journalEase), 952f);
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["menu/journal"], position,
                    PackedColor.White * Easing.CubeOut(journalEase));
                SourceAtlasDrawing.Draw(context, this, Input.GuiButton(Input.MenuJournal), position, Vector2.Zero,
                    PackedColor.White * Easing.CubeOut(journalEase));
            }
        }

        protected virtual void EaseCamera()
        {
            var areaData = Areas.Areas[area];
            Overworld.Mountain.EaseCamera(area, areaData.MountainIdle, null, true,
                area == 10);
            Overworld.Mountain.Model.EaseState(areaData.MountainState);
        }

        protected IEnumerator PerformCh8Unlock()
        {
            Audio.Play("event:/ui/postgame/unlock_newchapter");
            Audio.Play("event:/ui/world_map/icon/roll_right");
            area = 9;
            EaseCamera();
            Overworld.Maddy.Hide();
            var ready = false;
            icons[9].HighlightUnlock(delegate { ready = true; });
            while (!ready) yield return null;
        }

        protected IEnumerator SetupCh9Unlock()
        {
            icons[10].HideIcon = true;
            yield return 0.25f;
            while (area < 9)
            {
                area++;
                yield return 0.1f;
            }
        }

        protected IEnumerator PerformCh9Unlock(bool easeCamera = true)
        {
            Audio.Play("event:/ui/postgame/unlock_newchapter");
            Audio.Play("event:/ui/world_map/icon/roll_right");
            area = 10;
            yield return 0.25f;
            var ready = false;
            icons[10].HighlightUnlock(delegate { ready = true; });
            while (!ready) yield return null;

            if (easeCamera) EaseCamera();

            Overworld.Maddy.Hide();
            Process.SaveContext.CurrentSave.RevealedChapter9 = true;
        }
    }
}
