using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuIntSlider : TextMenuPresentation.Item
    {
        private ISourceEngineContext Engine => ResourceSet.EngineContext;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)Engine).InputSource;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)Engine;
        public string Label;

        public int Index;

        public Action<int> OnValueChange;

        public int PreviousIndex;

        private float sine;

        private int lastDir;

        private readonly int min;

        private readonly int max;

        private float fastMoveTimer;

        /// <summary>
        ///     Creates a new <see cref="T:Celeste.TextMenuExt.EverestMenuIntSlider" />
        /// </summary>
        /// <param name="label">Slider label</param>
        /// <param name="min">Minimum possible value</param>
        /// <param name="max">Maximum possible value</param>
        /// <param name="value">Initial value<br />Restricted between min and max</param>
        public EverestMenuIntSlider(string label, int min, int max, int value = 0)
        {
            Label = label;
            Selectable = true;
            this.min = min;
            this.max = max;
            Index = value < min ? min : value > max ? max : value;
        }

        /// <inheritdoc cref="M:Celeste.TextMenu.Option`1.Change(System.Action{`0})" />
        public EverestMenuIntSlider Change(Action<int> action)
        {
            OnValueChange = action;
            return this;
        }

        public override void Added()
        {
            Container.InnerContent = TextMenuPresentation.InnerContentMode.TwoColumn;
        }

        public override void LeftPressed()
        {
            if (Input.MenuLeft.Repeating)
                fastMoveTimer += Engine.Frame.RawDeltaTime * 8f;
            else
                fastMoveTimer = 0f;

            if (Index > min)
            {
                Process.AudioSession.Play("event:/ui/main/button_toggle_off");
                PreviousIndex = Index;
                Index -= fastMoveTimer < 1f ? 1 : fastMoveTimer < 3f ? 10 : 25;
                Index = Math.Max(min, Index);
                lastDir = -1;
                ValueWiggler.Start();
                OnValueChange?.Invoke(Index);
            }
        }

        public override void RightPressed()
        {
            if (Input.MenuRight.Repeating)
                fastMoveTimer += Engine.Frame.RawDeltaTime * 8f;
            else
                fastMoveTimer = 0f;

            if (Index < max)
            {
                Process.AudioSession.Play("event:/ui/main/button_toggle_on");
                PreviousIndex = Index;
                Index += fastMoveTimer < 1f ? 1 : fastMoveTimer < 3f ? 10 : 25;
                Index = Math.Min(max, Index);
                lastDir = 1;
                ValueWiggler.Start();
                OnValueChange?.Invoke(Index);
            }
        }

        public override void ConfirmPressed()
        {
            if (!(max - min == 1))
                return;
            if (Index == min)
                Process.AudioSession.Play("event:/ui/main/button_toggle_on");
            else
                Process.AudioSession.Play("event:/ui/main/button_toggle_off");

            PreviousIndex = Index;
            lastDir = Index == min ? 1 : -1;
            Index = Index == min ? max : min;
            ValueWiggler.Start();
            OnValueChange?.Invoke(Index);
        }

        public override void Update()
        {
            sine += Engine.Frame.RawDeltaTime;
        }

        public override float LeftWidth()
        {
            return ActiveFont.Measure(Label).X + 32f;
        }

        public override float RightWidth()
        {
            return SourceArrayExtrema.Max(0f, ActiveFont.Measure(max.ToString()).X,
                ActiveFont.Measure(min.ToString()).X,
                ActiveFont.Measure(Index.ToString()).X) + 120f;
        }

        public override float Height()
        {
            return ActiveFont.LineHeight;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            var alpha = Container.Alpha;
            var strokeColor = Color.Black * (alpha * alpha * alpha);
            var color =
                Disabled ? Color.DarkSlateGray : (highlighted ? Container.HighlightColor : Color.White) * alpha;
            ActiveFont.DrawOutline(context, Container, Label, position, new(0f, 0.5f), Vector2.One, color, 2f,
                strokeColor);
            if (max - min > 0)
            {
                var num = RightWidth();
                ActiveFont.DrawOutline(context, Container, Index.ToString(),
                    SourceVector2Math.Add(position,
                        new(Container.Width - num * 0.5f + lastDir * ValueWiggler.Value * 8f, 0f)),
                    new(0.5f, 0.5f), SourceVector2Math.Multiply(Vector2.One, 0.8f), color, 2f, strokeColor);
                var vector =
                    SourceVector2Math.Multiply(Vector2.UnitX, (float)(highlighted ? Math.Sin(sine * 4f) * 4.0 : 0.0));
                var position2 = SourceVector2Math.Subtract(
                    SourceVector2Math.Add(position,
                        new(
                            Container.Width - num + 40f + (lastDir < 0 ? (0f - ValueWiggler.Value) * 8f : 0f),
                            0f)), Index > min ? vector : Vector2.Zero);
                ActiveFont.DrawOutline(context, Container, "<", position2, new(0.5f, 0.5f), Vector2.One,
                    Index > min ? color : Color.DarkSlateGray * alpha, 2f, strokeColor);
                position2 = SourceVector2Math.Add(
                    SourceVector2Math.Add(position,
                        new(Container.Width - 40f + (lastDir > 0 ? ValueWiggler.Value * 8f : 0f), 0f)),
                    Index < max ? vector : Vector2.Zero);
                ActiveFont.DrawOutline(context, Container, ">", position2, new(0.5f, 0.5f), Vector2.One,
                    Index < max ? color : Color.DarkSlateGray * alpha, 2f, strokeColor);
            }
        }
    }
}
