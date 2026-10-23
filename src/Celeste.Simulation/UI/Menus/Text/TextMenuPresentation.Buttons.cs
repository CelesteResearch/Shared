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
        public class Button : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public override string SearchLabel() => Label;

            public bool AlwaysCenter;

            public Button(string label)
            {
                Label = label;
                Selectable = true;
            }

            public override void ConfirmPressed()
            {
                if (!string.IsNullOrEmpty(ConfirmSfx))
                {
                    Container.PlaySound(ConfirmSfx);
                }

                base.ConfirmPressed();
            }

            public override float LeftWidth()
            {
                return ActiveFont.Measure(Label).X;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight;
            }

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor color = (Disabled
                    ? global::Celeste.Core.Display.PackedColor.DarkSlateGray
                    : ((highlighted
                        ? Container.HighlightColor
                        : global::Celeste.Core.Display.PackedColor.White) * alpha));
                global::Celeste.Core.Display.PackedColor strokeColor =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                bool flag = Container.InnerContent == InnerContentMode.TwoColumn && !AlwaysCenter;
                Vector2 position2 = position + (flag ? Vector2.Zero : new Vector2(Container.Width * 0.5f, 0f));
                Vector2 justify = ((flag && !AlwaysCenter) ? new Vector2(0f, 0.5f) : new Vector2(0.5f, 0.5f));
                ActiveFont.DrawOutline(context, Container, Label, position2, justify, Vector2.One, color, 2f,
                    strokeColor);
            }
        }

        public class LanguageButton : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public global::Celeste.Localization.Languages.DialogLanguage Language;

            public bool AlwaysCenter;

            public LanguageButton(string label, global::Celeste.Localization.Languages.DialogLanguage language)
            {
                Label = label;
                Language = language;
                Selectable = true;
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
                return ResourceSet.LanguageIcon(Language).FrameWidth;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight;
            }

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor color = (Disabled
                    ? global::Celeste.Core.Display.PackedColor.DarkSlateGray
                    : ((highlighted
                        ? Container.HighlightColor
                        : global::Celeste.Core.Display.PackedColor.White) * alpha));
                global::Celeste.Core.Display.PackedColor strokeColor =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                ActiveFont.DrawOutline(context, Container, Label, position, new Vector2(0f, 0.5f), Vector2.One, color,
                    2f, strokeColor);
                ActiveFont.Image(context, Container, ResourceSet.LanguageIcon(Language),
                    position + new Vector2(Container.Width - RightWidth(), 0f), new Vector2(0f, .5f),
                    global::Celeste.Core.Display.PackedColor.White);
            }
        }
    }
}
