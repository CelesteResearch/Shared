using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.ModToggling
{
    public sealed class
        EverestModTogglerHeader : TextMenuPresentation.SubHeader
    {
        public PackedColor TextColor =
            PackedColor.Gray;

        public float HeightExtra = 48f;

        public EverestModTogglerHeader(string title) : base(title)
        {
        }

        public override float Height()
        {
            return base.Height() - 48f + HeightExtra;
        }

        public override void Render(ISourceRenderContext context, Vector2 position,
            bool highlighted)
        {
            var alpha = Container.Alpha;
            var column = Container.InnerContent ==
                         TextMenuPresentation.InnerContentMode.TwoColumn;
            var at = position + new Vector2(column ? 0 : Container.Width * .5f,
                Math.Max(0, 32 - 48 + HeightExtra));
            if (Title.Length > 0)
                ActiveFont.DrawOutline(context, Container, Title, at,
                    new(column ? 0 : .5f, .5f), Vector2.One * .6f,
                    TextColor * alpha, 2f,
                    PackedColor.Black * (alpha * alpha * alpha));
        }
    }
}
