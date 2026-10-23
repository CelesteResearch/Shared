using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Localization.Languages;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation
    {
        public class Button : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public override string SearchLabel()
            {
                return Label;
            }

            public bool AlwaysCenter;

            public Button(string label)
            {
                Label = label;
                Selectable = true;
            }

            public override void ConfirmPressed()
            {
                if (!string.IsNullOrEmpty(ConfirmSfx)) Container.PlaySound(ConfirmSfx);

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

            public override void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                var alpha = Container.Alpha;
                var color = Disabled
                    ? PackedColor.DarkSlateGray
                    : (highlighted
                        ? Container.HighlightColor
                        : PackedColor.White) * alpha;
                var strokeColor =
                    PackedColor.Black * (alpha * alpha * alpha);
                var flag = Container.InnerContent == InnerContentMode.TwoColumn && !AlwaysCenter;
                var position2 = position + (flag ? Vector2.Zero : new(Container.Width * 0.5f, 0f));
                var justify = flag && !AlwaysCenter ? new Vector2(0f, 0.5f) : new Vector2(0.5f, 0.5f);
                ActiveFont.DrawOutline(context, Container, Label, position2, justify, Vector2.One, color, 2f,
                    strokeColor);
            }
        }

        public class LanguageButton : Item
        {
            public string ConfirmSfx = "event:/ui/main/button_select";

            public string Label;

            public DialogLanguage Language;

            public bool AlwaysCenter;

            public LanguageButton(string label, DialogLanguage language)
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

            public override void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                var alpha = Container.Alpha;
                var color = Disabled
                    ? PackedColor.DarkSlateGray
                    : (highlighted
                        ? Container.HighlightColor
                        : PackedColor.White) * alpha;
                var strokeColor =
                    PackedColor.Black * (alpha * alpha * alpha);
                ActiveFont.DrawOutline(context, Container, Label, position, new(0f, 0.5f), Vector2.One, color,
                    2f, strokeColor);
                ActiveFont.Image(context, Container, ResourceSet.LanguageIcon(Language),
                    position + new Vector2(Container.Width - RightWidth(), 0f), new(0f, .5f),
                    PackedColor.White);
            }
        }
    }
}
