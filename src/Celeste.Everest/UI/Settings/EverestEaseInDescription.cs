using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Color = global::Celeste.Core.Display.PackedColor;
using Celeste.Everest;

namespace Celeste.Everest.UI.Settings
{
    public sealed class
        EverestEaseInDescription : global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.SubHeader
    {
        private float uneasedAlpha;
        public float Alpha;
        public bool FadeVisible;

        public global::Celeste.Core.Display.PackedColor TextColor =
            global::Celeste.Core.Display.PackedColor.Gray;

        public EverestEaseInDescription(string title, bool initiallyVisible) : base(title)
        {
            CompactSectionStart = false;
            FadeVisible = initiallyVisible;
            Alpha = uneasedAlpha = initiallyVisible ? 1 : 0;
        }

        public override float Height() => -(Container?.ItemSpacing ?? 4f) * (1 - Alpha) + (base.Height() - 48f) * Alpha;

        public override void Update()
        {
            float target = FadeVisible ? 1 : 0;
            if (uneasedAlpha != target)
            {
                float amount = Container.RawDeltaTime * 3;
                uneasedAlpha = uneasedAlpha > target
                    ? Math.Max(uneasedAlpha - amount, target)
                    : Math.Min(uneasedAlpha + amount, target);
                Alpha = FadeVisible
                    ? (float)Math.Sin(uneasedAlpha * Math.PI / 2)
                    : 1 - (float)Math.Cos(uneasedAlpha * Math.PI / 2);
            }

            Visible = Alpha != 0;
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
            bool highlighted)
        {
            float alpha = Container.Alpha * Alpha;
            bool column = Container.InnerContent ==
                          global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.InnerContentMode.TwoColumn;
            var at = position + (column ? Vector2.Zero : new Vector2(Container.Width * .5f, 0));
            if (Title.Length > 0)
                ActiveFont.DrawOutline(context, Container, Title, at, new Vector2(column ? 0 : .5f, .5f),
                    new Vector2(.6f),
                    TextColor * alpha, 2,
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha));
        }
    }
}
