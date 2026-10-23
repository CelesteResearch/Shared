using Celeste.Core.Display;
using Celeste.Game.Presentation.Hud;
using Celeste.Scene.Tracking;
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
using global::Celeste.Game.Execution;

namespace Celeste.Game.Menus.Chapters
{
    public class ChapterSelectIconPresentation : SceneEntityState
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
        protected Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio => Process.AudioSession;
        protected IOriginalAreaSourceTable Areas => ((IOriginalSessionConstructionProcess)engine).AreaTable;

        protected float Approach(float value, float target, float amount) => ScalarMath.Approach(value, target, amount,
            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

        public const float IdleSize = 100f;

        public const float HoverSize = 144f;

        public const float HoverSpacing = 80f;

        public const float IdleY = 130f;

        public const float HoverY = 140f;

        public const float Spacing = 32f;

        public int Area;

        public bool New;

        public Vector2 Scale = Vector2.One;

        public float Rotation;

        public float sizeEase = 1f;

        public bool AssistModeUnlockable;

        public bool HideIcon;

        private OscillationPulseState newWiggle;

        protected bool hidden = true;

        private bool selected;

        public bool Selected
        {
            get => selected;
            set => selected = value;
        }

        public bool Hidden
        {
            get => hidden;
            set => hidden = value;
        }

        private SourceTweenState tween;

        private OscillationPulseState wiggler;

        private bool wiggleLeft;

        private int rotateDir = -1;

        private Vector2 shake;

        private float spotlightAlpha;

        private float spotlightRadius;

        protected AtlasEntry front;

        protected AtlasEntry back;

        public Vector2 IdlePosition
        {
            get
            {
                float num = 960f + (float)(Area - Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID) *
                    132f;
                if (Area < Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID)
                {
                    num -= 80f;
                }
                else if (Area > Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID)
                {
                    num += 80f;
                }

                float y = 130f;
                if (Area == Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID)
                {
                    y = 140f;
                }

                return new Vector2(num, y);
            }
        }

        public Vector2 HiddenPosition => new Vector2(IdlePosition.X, -100f);

        public ChapterSelectIconPresentation(ISourceEngineContext engine, int area, AtlasEntry front, AtlasEntry back)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            Position = new Vector2(0f, -100f);
            Area = area;
            this.front = front;
            this.back = back;
            Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.35f, 2f, delegate(float f)
            {
                Rotation = (wiggleLeft ? (0f - f) : f) * 0.4f;
                Scale = Vector2.One * (1f + f * 0.5f);
            }));
            Add(newWiggle = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.8f, 2f));
            newWiggle.StartZero = true;
        }

        public void Hovered(int dir)
        {
            wiggleLeft = dir < 0;
            wiggler.Start();
        }

        public void Select()
        {
            Audio.Play("event:/ui/world_map/icon/flip_right");
            selected = true;
            hidden = false;
            Vector2 from = Position;
            StartTween(0.6f, delegate(SourceTweenState t) { SetSelectedPercent(from, t.Percent); });
        }

        public void SnapToSelected()
        {
            selected = true;
            hidden = false;
            StopTween();
        }

        public void Unselect()
        {
            Audio.Play("event:/ui/world_map/icon/flip_left");
            hidden = false;
            selected = false;
            Vector2 to = IdlePosition;
            StartTween(0.6f, delegate(SourceTweenState t) { SetSelectedPercent(to, 1f - t.Percent); });
        }

        public void Hide()
        {
            Scale = Vector2.One;
            hidden = true;
            selected = false;
            Vector2 from = Position;
            StartTween(0.25f,
                delegate
                {
                    Position = Vector2Math.Lerp(from, HiddenPosition, tween.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                });
        }

        public void Show()
        {
            if (Process.SaveContext.CurrentSave != null)
            {
                New = Counters.GetAreasSafe(Process.SaveContext.CurrentSave)[Area].Modes[0].TimePlayed <= 0;
            }

            Scale = Vector2.One;
            hidden = false;
            selected = false;
            Vector2 from = Position;
            StartTween(0.25f,
                delegate
                {
                    Position = Vector2Math.Lerp(from, IdlePosition, tween.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                });
        }

        public void AssistModeUnlock(Action onComplete)
        {
            Add(new SimulationCoroutine(engine, AssistModeUnlockRoutine(onComplete)));
        }

        private IEnumerator AssistModeUnlockRoutine(Action onComplete)
        {
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                spotlightRadius = Easing.CubeOut(p) * 128f;
                spotlightAlpha = Easing.CubeOut(p) * 0.8f;
                yield return null;
            }

            shake.X = 6f;
            for (int i = 0; i < 10; i++)
            {
                shake.X = 0f - shake.X;
                yield return 0.01f;
            }

            shake = Vector2.Zero;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                float num = Easing.CubeIn(p);
                shake = new Vector2(0f, -160f * num);
                Scale = new Vector2(1f - p, 1f + p * 0.25f);
                yield return null;
            }

            shake = Vector2.Zero;
            Scale = Vector2.One;
            AssistModeUnlockable = false;
            Progression.SetUnlockedAreasSafe(Process.SaveContext.CurrentSave,
                Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) + 1);
            wiggler.Start();
            yield return 1f;
            for (float p = 1f; p > 0f; p -= engine.DeltaTime * 4f)
            {
                spotlightRadius = 128f + (1f - Easing.CubeOut(p)) * 128f;
                spotlightAlpha = Easing.CubeOut(p) * 0.8f;
                yield return null;
            }

            spotlightAlpha = 0f;
            onComplete?.Invoke();
        }

        public void HighlightUnlock(Action onComplete)
        {
            HideIcon = true;
            Add(new SimulationCoroutine(engine, HighlightUnlockRoutine(onComplete)));
        }

        private IEnumerator HighlightUnlockRoutine(Action onComplete)
        {
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 2f)
            {
                spotlightRadius = 128f + (1f - Easing.CubeOut(p)) * 128f;
                spotlightAlpha = Easing.CubeOut(p) * 0.8f;
                yield return null;
            }

            Audio.Play("event:/ui/postgame/unlock_newchapter_icon");
            HideIcon = false;
            wiggler.Start();
            yield return 2f;
            for (float p = 1f; p > 0f; p -= engine.DeltaTime * 2f)
            {
                spotlightRadius = 128f + (1f - Easing.CubeOut(p)) * 128f;
                spotlightAlpha = Easing.CubeOut(p) * 0.8f;
                yield return null;
            }

            spotlightAlpha = 0f;
            onComplete?.Invoke();
        }

        public void StartTween(float duration, Action<SourceTweenState> callback)
        {
            StopTween();
            Add(tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot, null, duration,
                start: true));
            tween.OnUpdate = callback;
            tween.OnComplete = delegate { tween = null; };
        }

        private void StopTween()
        {
            if (tween != null)
            {
                Remove(tween);
            }

            tween = null;
        }

        private void SetSelectedPercent(Vector2 from, float p)
        {
            ChapterPanelSequence uI = (base.Scene as OverworldSequence).GetUI<ChapterPanelSequence>();
            Vector2 vector = uI.OpenPosition + uI.IconOffset;
            SimpleCurve simpleCurve = new SimpleCurve(from, vector, (from + vector) / 2f + new Vector2(0f, 30f));
            float num = 1f + ((p < 0.5f) ? (p * 2f) : ((1f - p) * 2f));
            Scale.X = (float)Math.Cos(Easing.SineInOut(p) * ((float)Math.PI * 2f)) * num;
            Scale.Y = num;
            Position = simpleCurve.GetPoint(SourceEasingComposition.Invert(Easing.CubeInOut)(p),
                ((ISourceCurveEnvironment)engine).CurveArithmetic);
            Rotation = SourceEasingComposition.UpDown(Easing.SineInOut(p)) * ((float)Math.PI / 180f) * 15f *
                       (float)rotateDir;
            if (p <= 0f)
            {
                rotateDir = -1;
            }
            else if (p >= 1f)
            {
                rotateDir = 1;
            }
        }

        public override void Update()
        {
            if (Process.SaveContext.CurrentSave == null)
            {
                return;
            }

            sizeEase = Approach(sizeEase,
                (Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID == Area) ? 1f : 0f,
                engine.DeltaTime * 4f);
            if (Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID == Area)
            {
                base.Depth = -50;
            }
            else
            {
                base.Depth = -45;
            }

            if (tween == null)
            {
                if (selected)
                {
                    ChapterPanelSequence uI = (base.Scene as OverworldSequence).GetUI<ChapterPanelSequence>();
                    Position = ((!uI.EnteringChapter) ? uI.OpenPosition : uI.Position) + uI.IconOffset;
                }
                else if (!hidden)
                {
                    Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(Position, IdlePosition,
                        2400f * engine.DeltaTime);
                }
            }

            if (New && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(1.5f, engine))
            {
                newWiggle.Start();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            AtlasEntry mTexture = front;
            Vector2 scale = Scale;
            int num = mTexture.FrameWidth;
            if (scale.X < 0f)
            {
                mTexture = back;
            }

            if (AssistModeUnlockable)
            {
                mTexture = Graphics.GuiAtlas["areas/lock"];
                num -= 32;
            }

            if (!HideIcon)
            {
                scale *= (100f + 44f * Easing.CubeInOut(sizeEase)) / (float)num;
                if (Process.SaveContext.CurrentSave != null && Process.SaveContext.CurrentSave.Assists.MirrorMode)
                {
                    scale.X = 0f - scale.X;
                }

                SourceAtlasDrawing.DrawCentered(context, this, mTexture, Position + shake, PackedColor.White, scale,
                    Rotation);
                if (New && Process.SaveContext.CurrentSave != null && !Process.SaveContext.CurrentSave.CheatMode &&
                    Area == Progression.GetUnlockedAreasSafe(Process.SaveContext.CurrentSave) && !selected &&
                    tween == null && !AssistModeUnlockable && ((IOriginalGamePlayModeEnvironment)engine).PlayMode !=
                    GameRuntime.PlayModes.Event)
                {
                    Vector2 position =
                        Position + new Vector2((float)num * 0.25f, (float)(-mTexture.FrameHeight) * 0.25f);
                    position += Vector2.UnitY * (0f - Math.Abs(newWiggle.Value * 30f));
                    SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["areas/new"], position,
                        PackedColor.White);
                }
            }

            if (spotlightAlpha > 0f)
            {
                OriginalHiresRendererBatch.EndRender(context);
                SpotlightWipePresentation.DrawSpotlight(engine, new Vector2(Position.X, IdlePosition.Y),
                    spotlightRadius,
                    PackedColor.Black * spotlightAlpha);
                OriginalHiresRendererBatch.BeginRender(context);
            }
            else if (AssistModeUnlockable &&
                     Selections.GetLastAreaReference(Process.SaveContext.CurrentSave).ID == Area &&
                     !hidden)
            {
                Text.ActiveFont.DrawOutline(context, this, Text.Dialog.Clean("ASSIST_SKIP"),
                    Position + new Vector2(0f, 100f), new Vector2(0.5f, 0f), Vector2.One * 0.7f, PackedColor.White, 2f,
                    PackedColor.Black);
            }
        }
    }
}
