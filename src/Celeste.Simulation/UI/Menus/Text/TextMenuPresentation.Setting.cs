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
        public class Setting : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public List<object> Values = new List<object>();

            public global::Celeste.Simulation.UI.Menus.Text.ITextMenuBinding Binding;

            public bool BindingController;

            private int bindingHash;

            public Setting(string label, string value = "")
            {
                Label = label;
                Values.Add(value);
                Selectable = true;
            }

            public Setting(string label, global::Celeste.Simulation.UI.Menus.Text.ITextMenuBinding binding,
                bool controllerMode)
                : this(label)
            {
                Binding = binding;
                BindingController = controllerMode;
                bindingHash = 0;
            }

            public void SetKeys(IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> keys)
            {
                Values.Clear();
                int i = 0;
                for (int num = Math.Min(8, keys.Count); i < num; i++)
                {
                    if (keys[i].Code == 0)
                    {
                        continue;
                    }

                    global::Celeste.Graphics.Content.Atlas.AtlasEntry mTexture = ResourceSet.GuiKey(keys[i].Code);
                    if (mTexture != null)
                    {
                        Values.Add(mTexture);
                        continue;
                    }

                    string text = keys[i].ToString();
                    string text2 = "";
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (j > 0 && char.IsUpper(text[j]))
                        {
                            text2 += " ";
                        }

                        text2 += text[j];
                    }

                    Values.Add(text2);
                }
            }

            public void SetButtons(IReadOnlyList<global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue> buttons)
            {
                Values.Clear();
                int i = 0;
                for (int num = Math.Min(8, buttons.Count); i < num; i++)
                {
                    global::Celeste.Graphics.Content.Atlas.AtlasEntry mTexture =
                        ResourceSet.GuiControllerButton(buttons[i].Code);
                    if (mTexture != null)
                    {
                        Values.Add(mTexture);
                        continue;
                    }

                    string text = buttons[i].ToString();
                    string text2 = "";
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (j > 0 && char.IsUpper(text[j]))
                        {
                            text2 += " ";
                        }

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
                float num = 0f;
                foreach (object value in Values)
                {
                    if (value is global::Celeste.Graphics.Content.Atlas.AtlasEntry)
                    {
                        num += (float)(value as global::Celeste.Graphics.Content.Atlas.AtlasEntry).FrameWidth;
                    }
                    else if (value is string)
                    {
                        num += ActiveFont.Measure(value as string).X * 0.7f + 16f;
                    }
                }

                return num;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight * 1.2f;
            }

            public override void Update()
            {
                if (Binding == null)
                {
                    return;
                }

                int num = 17;
                if (BindingController)
                {
                    foreach (global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue item in Binding.Controller)
                    {
                        num = num * 31 + item.GetHashCode();
                    }
                }
                else
                {
                    foreach (global::Celeste.Simulation.UI.Menus.Text.TextMenuBindingValue item2 in Binding.Keyboard)
                    {
                        num = num * 31 + item2.GetHashCode();
                    }
                }

                if (num != bindingHash)
                {
                    bindingHash = num;
                    if (BindingController)
                    {
                        SetButtons(Binding.Controller);
                    }
                    else
                    {
                        SetKeys(Binding.Keyboard);
                    }
                }
            }

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor strokeColor =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                global::Celeste.Core.Display.PackedColor color = (Disabled
                    ? global::Celeste.Core.Display.PackedColor.DarkSlateGray
                    : ((highlighted
                        ? Container.HighlightColor
                        : global::Celeste.Core.Display.PackedColor.White) * alpha));
                ActiveFont.DrawOutline(context, Container, Label, position, new Vector2(0f, 0.5f), Vector2.One, color,
                    2f, strokeColor);
                float num = RightWidth();
                foreach (object value in Values)
                {
                    if (value is global::Celeste.Graphics.Content.Atlas.AtlasEntry)
                    {
                        global::Celeste.Graphics.Content.Atlas.AtlasEntry mTexture =
                            value as global::Celeste.Graphics.Content.Atlas.AtlasEntry;
                        ActiveFont.Image(context, Container, mTexture,
                            position + new Vector2(Container.Width - num, 0f),
                            new Vector2(0f, .5f), global::Celeste.Core.Display.PackedColor.White * alpha);
                        num -= (float)mTexture.FrameWidth;
                    }
                    else if (value is string)
                    {
                        string text = value as string;
                        float num2 = ActiveFont.Measure(value as string).X * 0.7f + 16f;
                        ActiveFont.DrawOutline(context, Container, text,
                            position + new Vector2(Container.Width - num + num2 * 0.5f, 0f),
                            new Vector2(0.5f, 0.5f), Vector2.One * 0.7f,
                            global::Celeste.Core.Display.PackedColor.LightGray * alpha, 2f, strokeColor);
                        num -= num2;
                    }
                }
            }
        }
    }
}
