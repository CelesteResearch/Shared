using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.UI.ModToggling
{
    public sealed class
        EverestModTogglerHeader : global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.SubHeader
    {
        public global::Celeste.Core.Display.PackedColor TextColor =
            global::Celeste.Core.Display.PackedColor.Gray;

        public float HeightExtra = 48f;

        public EverestModTogglerHeader(string title) : base(title)
        {
        }

        public override float Height() => base.Height() - 48f + HeightExtra;

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, Vector2 position,
            bool highlighted)
        {
            float alpha = Container.Alpha;
            bool column = Container.InnerContent ==
                          global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.InnerContentMode.TwoColumn;
            Vector2 at = position + new Vector2(column ? 0 : Container.Width * .5f,
                Math.Max(0, 32 - 48 + HeightExtra));
            if (Title.Length > 0)
                ActiveFont.DrawOutline(context, Container, Title, at,
                    new Vector2(column ? 0 : .5f, .5f), Vector2.One * .6f,
                    TextColor * alpha, 2f,
                    global::Celeste.Core.Display.PackedColor.Black * (alpha * alpha * alpha));
        }
    }
}
