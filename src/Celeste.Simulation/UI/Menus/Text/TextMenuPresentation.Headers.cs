using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public partial class TextMenuPresentation
    {
        public class Header : Item
        {
            public const float Scale = 2f;

            public string Title;

            public Header(string title)
            {
                Title = title;
                Selectable = false;
                IncludeWidthInMeasurement = false;
            }

            public override float LeftWidth()
            {
                return ActiveFont.Measure(Title).X * 2f;
            }

            public override float Height()
            {
                return ActiveFont.LineHeight * 2f;
            }

            public override void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                var alpha = Container.Alpha;
                var strokeColor =
                    PackedColor.Black * (alpha * alpha * alpha);
                ActiveFont.DrawEdgeOutline(context, Container, Title,
                    position + new Vector2(Container.Width * 0.5f, 0f),
                    new(0.5f, 0.5f), Vector2.One * 2f,
                    PackedColor.Gray * alpha, 4f,
                    PackedColor.DarkSlateBlue * alpha, 2f,
                    strokeColor);
            }
        }

        public class SubHeader : Item
        {
            public const float Scale = 0.6f;
            public bool CompactSectionStart = true;

            public string Title;

            public bool TopPadding = true;

            public SubHeader(string title, bool topPadding = true)
            {
                Title = title;
                Selectable = false;
                TopPadding = topPadding;
            }

            public override float LeftWidth()
            {
                return ActiveFont.Measure(Title).X * 0.6f;
            }

            public override float Height()
            {
                return (Title.Length > 0 ? ActiveFont.HeightOf(Title) * 0.6f : 0f) + (TopPadding ? 48 : 0);
            }

            public override void Render(ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                if (Title.Length > 0)
                {
                    var alpha = Container.Alpha;
                    var strokeColor =
                        PackedColor.Black * (alpha * alpha * alpha);
                    var num = TopPadding ? 32 : 0;
                    var position2 = position + (Container.InnerContent == InnerContentMode.TwoColumn
                        ? new(0f, num)
                        : new Vector2(Container.Width * 0.5f, num));
                    var justify = new Vector2(Container.InnerContent == InnerContentMode.TwoColumn ? 0f : 0.5f,
                        0.5f);
                    ActiveFont.DrawOutline(context, Container, Title, position2, justify, Vector2.One * 0.6f,
                        PackedColor.Gray * alpha, 2f,
                        strokeColor);
                }
            }
        }
    }
}
