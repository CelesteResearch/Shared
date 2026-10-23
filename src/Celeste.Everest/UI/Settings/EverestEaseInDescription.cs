using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public sealed class
        EverestEaseInDescription : TextMenuPresentation.SubHeader
    {
        private float uneasedAlpha;
        public float Alpha;
        public bool FadeVisible;

        public PackedColor TextColor =
            PackedColor.Gray;

        public EverestEaseInDescription(string title, bool initiallyVisible) : base(title)
        {
            CompactSectionStart = false;
            FadeVisible = initiallyVisible;
            Alpha = uneasedAlpha = initiallyVisible ? 1 : 0;
        }

        public override float Height()
        {
            return -(Container?.ItemSpacing ?? 4f) * (1 - Alpha) + (base.Height() - 48f) * Alpha;
        }

        public override void Update()
        {
            float target = FadeVisible ? 1 : 0;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (uneasedAlpha != target)
            {
                var amount = Container.RawDeltaTime * 3;
                uneasedAlpha = uneasedAlpha > target
                    ? Math.Max(uneasedAlpha - amount, target)
                    : Math.Min(uneasedAlpha + amount, target);
                Alpha = FadeVisible
                    ? (float)Math.Sin(uneasedAlpha * Math.PI / 2)
                    : 1 - (float)Math.Cos(uneasedAlpha * Math.PI / 2);
            }

            Visible = Alpha != 0;
        }

        public override void Render(ISourceRenderContext context, Vector2 position,
            bool highlighted)
        {
            var alpha = Container.Alpha * Alpha;
            var column = Container.InnerContent ==
                         TextMenuPresentation.InnerContentMode.TwoColumn;
            var at = position + (column ? Vector2.Zero : new(Container.Width * .5f, 0));
            if (Title.Length > 0)
                ActiveFont.DrawOutline(context, Container, Title, at, new(column ? 0 : .5f, .5f),
                    new(.6f),
                    TextColor * alpha, 2,
                    PackedColor.Black * (alpha * alpha * alpha));
        }
    }
}
