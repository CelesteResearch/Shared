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

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                float alpha = Container.Alpha;
                global::Celeste.Core.Display.PackedColor strokeColor =
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                ActiveFont.DrawEdgeOutline(context, Container, Title,
                    position + new Vector2(Container.Width * 0.5f, 0f),
                    new Vector2(0.5f, 0.5f), Vector2.One * 2f,
                    global::Celeste.Core.Display.PackedColor.Gray * alpha, 4f,
                    global::Celeste.Core.Display.PackedColor.DarkSlateBlue * alpha, 2f,
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
                return ((Title.Length > 0) ? (ActiveFont.HeightOf(Title) * 0.6f) : 0f) + (float)(TopPadding ? 48 : 0);
            }

            public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
                bool highlighted)
            {
                if (Title.Length > 0)
                {
                    float alpha = Container.Alpha;
                    global::Celeste.Core.Display.PackedColor strokeColor =
                        global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha);
                    int num = (TopPadding ? 32 : 0);
                    Vector2 position2 = position + ((Container.InnerContent == InnerContentMode.TwoColumn)
                        ? new Vector2(0f, num)
                        : new Vector2(Container.Width * 0.5f, num));
                    Vector2 justify = new Vector2((Container.InnerContent == InnerContentMode.TwoColumn) ? 0f : 0.5f,
                        0.5f);
                    ActiveFont.DrawOutline(context, Container, Title, position2, justify, Vector2.One * 0.6f,
                        global::Celeste.Core.Display.PackedColor.Gray * alpha, 2f,
                        strokeColor);
                }
            }
        }
    }
}
