using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Menus.Journal
{
    public class OuiJournalPoemPage : OuiJournalPage
    {
        private class PoemLine
        {
            private readonly OuiJournalPoemPage page;

            public PoemLine(OuiJournalPoemPage page)
            {
                this.page = page;
            }

            public float Index;

            public string Text;

            public float HoveringEase;

            public float HoldingEase;

            public bool Remix;

            public void Render()
            {
                var num = 100f + page.Journal.Easing.CubeInOut(HoveringEase) * 20f;
                var y = GetY(Index);
                SourcePrimitiveDrawing.Rect(page.Context, page.Journal, num, y - 22f, 810f, 44f,
                    PackedColor.White * 0.25f);
                var scale = Vector2.One * (0.6f + HoldingEase * 0.4f);
                SourceAtlasDrawing.DrawCentered(page.Context, page.Journal,
                    page.MountainResources.Journal[Remix ? "heartgem1" : "heartgem0"], new(num + 20f, y),
                    PackedColor.White, scale);
                var color = PackedColor.Black * (0.7f + HoveringEase * 0.3f);
                var scale2 = Vector2.One * (0.5f + HoldingEase * 0.1f);
                page.Text.ActiveFont.Draw(page.Context, page.Journal, Text, new(num + 60f, y),
                    new(0f, 0.5f), scale2, color);
            }
        }

        private const float textScale = 0.5f;

        private const float holdingScaleAdd = 0.1f;

        private const float poemHeight = 44f;

        private const float poemSpacing = 4f;

        private const float poemStanzaSpacing = 16f;

        private readonly List<PoemLine> lines = [];

        private int index;

        private float slider;

        private bool dragging;

        private bool swapping;

        private readonly SimulationCoroutine swapRoutine;

        private readonly OscillationPulseState wiggler;

        private SourceTweenState tween;

        public OuiJournalPoemPage(OuiJournalSequence journal)
            : base(journal)
        {
            swapRoutine = new(engine);
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 4f);
            PageTexture = "page";
            swapRoutine.RemoveOnComplete = false;
            var num = 0f;
            foreach (var item in ((IOriginalSavePoemEnvironment)engine).SavePoem.GetPoemSafe(Journal.Process
                         .SaveContext
                         .CurrentSave))
            {
                var text = Text.Dialog.Clean("poem_" + item);
                text = text.Replace("\n", " - ");
                lines.Add(new(this)
                {
                    Text = text,
                    Index = num,
                    Remix = OriginalAreaPoemQueries.IsPoemRemix(((IOriginalSessionConstructionProcess)engine).AreaTable,
                        item),
                });
                num += 1f;
            }
        }

        public static float GetY(float index)
        {
            return 120f + 44f * (index + 0.5f) + 4f * index + (int)index / 4 * 16f;
        }

        public override void Redraw(VirtualRenderTarget buffer)
        {
            base.Redraw(buffer);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin();
            Text.ActiveFont.Draw(Context, Journal, Text.Dialog.Clean("journal_poem"), new(60f, 60f),
                new(0f, 0.5f), Vector2.One, PackedColor.Black * 0.6f);
            foreach (var line in lines) line.Render();

            if (lines.Count > 0)
            {
                var mTexture = MountainResources.Journal[dragging ? "poemSlider" : "poemArrow"];
                var position = new Vector2(50f, GetY(slider));
                SourceAtlasDrawing.DrawCentered(Context, Journal, mTexture, position, PackedColor.White,
                    1f + 0.25f * wiggler.Value);
            }

            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }

        private IEnumerator Swap(int a, int b)
        {
            var value =
                ((IOriginalSavePoemEnvironment)engine).SavePoem.GetPoemSafe(Journal.Process.SaveContext.CurrentSave)[a];
            ((IOriginalSavePoemEnvironment)engine).SavePoem.GetPoemSafe(Journal.Process.SaveContext.CurrentSave)[a] =
                ((IOriginalSavePoemEnvironment)engine).SavePoem.GetPoemSafe(Journal.Process.SaveContext.CurrentSave)[b];
            ((IOriginalSavePoemEnvironment)engine).SavePoem.GetPoemSafe(Journal.Process.SaveContext.CurrentSave)[b] =
                value;
            var poemA = lines[a];
            var poemB = lines[b];
            var value2 = lines[a];
            lines[a] = lines[b];
            lines[b] = value2;
            tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Journal.Easing.CubeInOut,
                0.125f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                poemA.Index = ScalarMath.Lerp(a, b, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                poemB.Index = ScalarMath.Lerp(b, a, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            };
            tween.OnComplete = delegate { tween = null; };
            yield return tween.Wait();
            swapping = false;
        }

        public override void Update()
        {
            if (lines.Count <= 0) return;

            if (tween != null && tween.Active) tween.Update();

            if (Journal.Input.MenuDown.Pressed && index + 1 < lines.Count && !swapping)
            {
                if (dragging)
                {
                    Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_shift_down");
                    swapRoutine.Replace(Swap(index, index + 1));
                    swapping = true;
                }
                else
                {
                    Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_roll");
                }

                index++;
            }
            else if (Journal.Input.MenuUp.Pressed && index > 0 && !swapping)
            {
                if (dragging)
                {
                    Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_shift_up");
                    swapRoutine.Replace(Swap(index, index - 1));
                    swapping = true;
                }
                else
                {
                    Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_roll");
                }

                index--;
            }
            else if (Journal.Input.MenuConfirm.Pressed)
            {
                Journal.PageTurningLocked = true;
                Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_grab");
                dragging = true;
                wiggler.Start();
            }
            else if (!Journal.Input.MenuConfirm.Check && dragging)
            {
                Journal.PageTurningLocked = false;
                Journal.Process.AudioSession.Play("event:/ui/world_map/journal/heart_release");
                dragging = false;
                wiggler.Start();
            }

            for (var i = 0; i < lines.Count; i++)
            {
                var poemLine = lines[i];
                poemLine.HoveringEase = ScalarMath.Approach(poemLine.HoveringEase, index == i ? 1f : 0f,
                    8f * engine.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                poemLine.HoldingEase = ScalarMath.Approach(poemLine.HoldingEase, index == i && dragging ? 1f : 0f,
                    8f * engine.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            slider = ScalarMath.Approach(slider, index, 16f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (swapRoutine != null && swapRoutine.Active) swapRoutine.Update();

            wiggler.Update();
            Redraw(Journal.CurrentPageBuffer);
        }
    }
}
