using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Color = global::Celeste.Core.Display.PackedColor;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation
    {
        public class Option<T> : Item
        {
            public string Label;

            public override string SearchLabel() => Label;

            // Everest patch_TextMenu.Option<T> exposes this for ModToggler's state colours.
            public global::Celeste.Core.Display.PackedColor UnselectedColor =
                global::Celeste.Core.Display.PackedColor.White;

            public int Index;

            public Action<T> OnValueChange;

            public int PreviousIndex;

            public List<Tuple<string, T>> Values = new List<Tuple<string, T>>();

            private float sine;

            private int lastDir;

            public Option(string label)
            {
                Label = label;
                Selectable = true;
            }

            public Option<T> Add(string label, T value, bool selected = false)
            {
                Values.Add(new Tuple<string, T>(label, value));
                if (selected)
                {
                    PreviousIndex = (Index = Values.Count - 1);
                }

                return this;
            }

            public Option<T> Change(Action<T> action)
            {
                OnValueChange = action;
                return this;
            }

            public override void Added()
            {
                Container.InnerContent = InnerContentMode.TwoColumn;
            }

            public override void LeftPressed()
            {
                if (Index > 0)
                {
                    Container.PlaySound("event:/ui/main/button_toggle_off");
                    PreviousIndex = Index;
                    Index--;
                    lastDir = -1;
                    ValueWiggler.Start();
                    if (OnValueChange != null)
                    {
                        OnValueChange(Values[Index].Item2);
                    }
                }
            }

            public override void RightPressed()
            {
                if (Index < Values.Count - 1)
                {
                    Container.PlaySound("event:/ui/main/button_toggle_on");
                    PreviousIndex = Index;
                    Index++;
                    lastDir = 1;
                    ValueWiggler.Start();
                    if (OnValueChange != null)
                    {
                        OnValueChange(Values[Index].Item2);
                    }
                }
            }

            public override void ConfirmPressed()
            {
                if (Values.Count == 2)
                {
                    if (Index == 0)
                    {
                        Container.PlaySound("event:/ui/main/button_toggle_on");
                    }
                    else
                    {
                        Container.PlaySound("event:/ui/main/button_toggle_off");
                    }

                    PreviousIndex = Index;
                    Index = 1 - Index;
                    lastDir = ((Index == 1) ? 1 : (-1));
                    ValueWiggler.Start();
                    if (OnValueChange != null)
                    {
                        OnValueChange(Values[Index].Item2);
                    }
                }
            }

            public override void Update()
            {
                sine += Container.EngineContext.RawDeltaTime;
            }

            public override float LeftWidth()
            {
                return ActiveFont.Measure(Label).X + 32f;
            }

            public override float RightWidth()
            {
                float num = 0f;
                foreach (Tuple<string, T> value in Values)
                {
                    num = Math.Max(num, ActiveFont.Measure(value.Item1).X);
                }

                return num + 120f;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight;
            }

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor strokeColor =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                global::Celeste.Core.Display.PackedColor color = (Disabled
                    ? global::Celeste.Core.Display.PackedColor.DarkSlateGray
                    : ((highlighted ? Container.HighlightColor : UnselectedColor) * alpha));
                ActiveFont.DrawOutline(context, Container, Label, position, new Vector2(0f, 0.5f), Vector2.One, color,
                    2f, strokeColor);
                if (Values.Count > 0)
                {
                    float num = RightWidth();
                    ActiveFont.DrawOutline(context, Container, Values[Index].Item1,
                        position + new Vector2(Container.Width - num * 0.5f + (float)lastDir * ValueWiggler.Value * 8f,
                            0f), new Vector2(0.5f, 0.5f), Vector2.One * 0.8f, color, 2f, strokeColor);
                    Vector2 vector = Vector2.UnitX * (highlighted ? ((float)Math.Sin(sine * 4f) * 4f) : 0f);
                    bool flag = Index > 0;
                    global::Celeste.Core.Display.PackedColor color2 =
                        (flag ? color : (global::Celeste.Core.Display.PackedColor.DarkSlateGray * alpha));
                    Vector2 position2 = position +
                                        new Vector2(
                                            Container.Width - num + 40f +
                                            ((lastDir < 0) ? ((0f - ValueWiggler.Value) * 8f) : 0f), 0f) -
                                        (flag ? vector : Vector2.Zero);
                    ActiveFont.DrawOutline(context, Container, "<", position2, new Vector2(0.5f, 0.5f), Vector2.One,
                        color2, 2f,
                        strokeColor);
                    bool flag2 = Index < Values.Count - 1;
                    global::Celeste.Core.Display.PackedColor color3 =
                        (flag2 ? color : (global::Celeste.Core.Display.PackedColor.DarkSlateGray * alpha));
                    Vector2 position3 = position +
                                        new Vector2(
                                            Container.Width - 40f + ((lastDir > 0) ? (ValueWiggler.Value * 8f) : 0f),
                                            0f) + (flag2 ? vector : Vector2.Zero);
                    ActiveFont.DrawOutline(context, Container, ">", position3, new Vector2(0.5f, 0.5f), Vector2.One,
                        color3, 2f,
                        strokeColor);
                }
            }
        }

        // TextMenuExt.IntSlider: large ranges are held as bounds rather than materialized values.
        public class IntSlider : Item
        {
            public string Label;
            public int Index, PreviousIndex;
            public Action<int> OnValueChange;
            private readonly int min, max;
            private float sine, fastMoveTimer;
            private int lastDir;

            public IntSlider(string label, int min, int max, int value = 0)
            {
                Label = label;
                Selectable = true;
                this.min = min;
                this.max = max;
                Index = Math.Min(max, Math.Max(min, value));
            }

            public IntSlider Change(Action<int> action)
            {
                OnValueChange = action;
                return this;
            }

            public override void Added()
            {
                Container.InnerContent = InnerContentMode.TwoColumn;
            }

            public override void LeftPressed()
            {
                fastMoveTimer = Container.Input.MenuLeft.Repeating ? fastMoveTimer + Container.RawDeltaTime * 8f : 0f;
                if (Index <= min) return;
                Container.PlaySound("event:/ui/main/button_toggle_off");
                PreviousIndex = Index;
                Index = (int)Math.Max(min, (long)Index - Step());
                lastDir = -1;
                ValueWiggler.Start();
                OnValueChange?.Invoke(Index);
            }

            public override void RightPressed()
            {
                fastMoveTimer = Container.Input.MenuRight.Repeating ? fastMoveTimer + Container.RawDeltaTime * 8f : 0f;
                if (Index >= max) return;
                Container.PlaySound("event:/ui/main/button_toggle_on");
                PreviousIndex = Index;
                Index = (int)Math.Min(max, (long)Index + Step());
                lastDir = 1;
                ValueWiggler.Start();
                OnValueChange?.Invoke(Index);
            }

            private int Step() => fastMoveTimer < 1f ? 1 : fastMoveTimer < 3f ? 10 : 25;

            public override void ConfirmPressed()
            {
                if ((long)max - min != 1) return;
                Container.PlaySound(Index == min
                    ? "event:/ui/main/button_toggle_on"
                    : "event:/ui/main/button_toggle_off");
                PreviousIndex = Index;
                lastDir = Index == min ? 1 : -1;
                Index = Index == min ? max : min;
                ValueWiggler.Start();
                OnValueChange?.Invoke(Index);
            }

            public override void Update()
            {
                sine += Container.RawDeltaTime;
            }

            public override float LeftWidth() => ActiveFont.Measure(Label).X + 32f;

            public override float RightWidth() => Math.Max(0f,
                Math.Max(ActiveFont.Measure(max.ToString()).X,
                    Math.Max(ActiveFont.Measure(min.ToString()).X, ActiveFont.Measure(Index.ToString()).X))) + 120f;

            public override float Height() => ActiveFont.LineHeight;

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor stroke =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                global::Celeste.Core.Display.PackedColor color = Disabled
                    ? global::Celeste.Core.Display.PackedColor.DarkSlateGray
                    : (highlighted ? Container.HighlightColor : global::Celeste.Core.Display.PackedColor.White) *
                      alpha;
                ActiveFont.DrawOutline(context, Container, Label, position, new Vector2(0f, .5f), Vector2.One, color,
                    2f, stroke);
                if (max <= min) return;
                float width = RightWidth();
                ActiveFont.DrawOutline(context, Container, Index.ToString(),
                    position + new Vector2(Container.Width - width * .5f + lastDir * ValueWiggler.Value * 8f, 0),
                    new Vector2(.5f, .5f), Vector2.One * .8f, color, 2f, stroke);
                Vector2 wiggle = Vector2.UnitX * (highlighted ? (float)Math.Sin(sine * 4f) * 4f : 0f);
                bool left = Index > min, right = Index < max;
                Vector2 leftAt = position +
                                 new Vector2(
                                     Container.Width - width + 40f + (lastDir < 0 ? -ValueWiggler.Value * 8f : 0f), 0) -
                                 (left ? wiggle : Vector2.Zero);
                Vector2 rightAt = position +
                                  new Vector2(Container.Width - 40f + (lastDir > 0 ? ValueWiggler.Value * 8f : 0f), 0) +
                                  (right ? wiggle : Vector2.Zero);
                ActiveFont.DrawOutline(context, Container, "<", leftAt, new Vector2(.5f, .5f), Vector2.One,
                    left ? color : global::Celeste.Core.Display.PackedColor.DarkSlateGray * alpha, 2f, stroke);
                ActiveFont.DrawOutline(context, Container, ">", rightAt, new Vector2(.5f, .5f), Vector2.One,
                    right ? color : global::Celeste.Core.Display.PackedColor.DarkSlateGray * alpha, 2f, stroke);
            }
        }

        public class Slider : Option<int>
        {
            public Slider(string label, Func<int, string> values, int min, int max, int value = -1)
                : base(label)
            {
                for (int i = min; i <= max; i++)
                {
                    Add(values(i), i, value == i);
                }
            }
        }

        public class OnOff : Option<bool>
        {
            public OnOff(string label, bool on, global::Celeste.Core.Scheduling.ISourceEngineContext engine)
                : base(label)
            {
                Add(((global::Celeste.Localization.Lookup.ISourceDialogEnvironment)engine).Dialog.Clean("options_off"),
                    value: false, !on);
                Add(((global::Celeste.Localization.Lookup.ISourceDialogEnvironment)engine).Dialog.Clean("options_on"),
                    value: true, on);
            }
        }
    }
}
