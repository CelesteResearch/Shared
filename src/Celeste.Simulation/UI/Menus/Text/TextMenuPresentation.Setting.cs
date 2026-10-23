using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation
    {
        public class Setting : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public List<object> Values = [];

            public ITextMenuBinding Binding;

            public bool BindingController;

            private int bindingHash;

            public Setting(string label, string value = "")
            {
                Label = label;
                Values.Add(value);
                Selectable = true;
            }

            public Setting(string label, ITextMenuBinding binding,
                bool controllerMode)
                : this(label)
            {
                Binding = binding;
                BindingController = controllerMode;
                bindingHash = 0;
            }

            public void SetKeys(IReadOnlyList<TextMenuBindingValue> keys)
            {
                Values.Clear();
                var i = 0;
                for (var num = Math.Min(8, keys.Count); i < num; i++)
                {
                    if (keys[i].Code == 0) continue;

                    var mTexture = ResourceSet.GuiKey(keys[i].Code);
                    if (mTexture != null)
                    {
                        Values.Add(mTexture);
                        continue;
                    }

                    var text = keys[i].ToString();
                    var text2 = "";
                    for (var j = 0; j < text.Length; j++)
                    {
                        if (j > 0 && char.IsUpper(text[j])) text2 += " ";

                        text2 += text[j];
                    }

                    Values.Add(text2);
                }
            }

            public void SetButtons(IReadOnlyList<TextMenuBindingValue> buttons)
            {
                Values.Clear();
                var i = 0;
                for (var num = Math.Min(8, buttons.Count); i < num; i++)
                {
                    var mTexture =
                        ResourceSet.GuiControllerButton(buttons[i].Code);
                    if (mTexture != null)
                    {
                        Values.Add(mTexture);
                        continue;
                    }

                    var text = buttons[i].ToString();
                    var text2 = "";
                    for (var j = 0; j < text.Length; j++)
                    {
                        if (j > 0 && char.IsUpper(text[j])) text2 += " ";

                        text2 += text[j];
                    }

                    Values.Add(text2);
                }
            }

            public override void Added()
            {
                Container.InnerContent = InnerContentMode.TwoColumn;
            }

            public override void ConfirmPressed()
            {
                Container.PlaySound(ConfirmSfx);
                base.ConfirmPressed();
            }

            public override float LeftWidth()
            {
                return ActiveFont.Measure(Label).X;
            }

            public override float RightWidth()
            {
                var num = 0f;
                foreach (var value in Values)
                    if (value is AtlasEntry)
                        num += (value as AtlasEntry).FrameWidth;
                    else if (value is string) num += ActiveFont.Measure(value as string).X * 0.7f + 16f;

                return num;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight * 1.2f;
            }

            public override void Update()
            {
                if (Binding == null) return;

                var num = 17;
                if (BindingController)
                    foreach (var item in Binding.Controller)
                        num = num * 31 + item.GetHashCode();
                else
                    foreach (var item2 in Binding.Keyboard)
                        num = num * 31 + item2.GetHashCode();

                if (num != bindingHash)
                {
                    bindingHash = num;
                    if (BindingController)
                        SetButtons(Binding.Controller);
                    else
                        SetKeys(Binding.Keyboard);
                }
            }

            public override void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                var alpha = Container.Alpha;
                var strokeColor =
                    PackedColor.Black * (alpha * alpha * alpha);
                var color = Disabled
                    ? PackedColor.DarkSlateGray
                    : (highlighted
                        ? Container.HighlightColor
                        : PackedColor.White) * alpha;
                ActiveFont.DrawOutline(context, Container, Label, position, new(0f, 0.5f), Vector2.One, color,
                    2f, strokeColor);
                var num = RightWidth();
                foreach (var value in Values)
                    if (value is AtlasEntry)
                    {
                        var mTexture =
                            value as AtlasEntry;
                        ActiveFont.Image(context, Container, mTexture,
                            position + new Vector2(Container.Width - num, 0f),
                            new(0f, .5f), PackedColor.White * alpha);
                        num -= mTexture.FrameWidth;
                    }
                    else if (value is string)
                    {
                        var text = value as string;
                        var num2 = ActiveFont.Measure(value as string).X * 0.7f + 16f;
                        ActiveFont.DrawOutline(context, Container, text,
                            position + new Vector2(Container.Width - num + num2 * 0.5f, 0f),
                            new(0.5f, 0.5f), Vector2.One * 0.7f,
                            PackedColor.LightGray * alpha, 2f, strokeColor);
                        num -= num2;
                    }
            }
        }
    }
}
