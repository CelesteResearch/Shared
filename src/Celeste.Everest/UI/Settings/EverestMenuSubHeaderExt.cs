using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuSubHeaderExt : TextMenuPresentation.SubHeader, IEverestMenuItemExt
    {
        public PackedColor TextColor { get; set; } = PackedColor.Gray;
        public string Icon { get; set; }
        public float? IconWidth { get; set; }
        public bool IconOutline { get; set; }
        public Vector2 Offset { get; set; }
        public float Alpha { get; set; } = 1f;
        public bool AlwaysCenter { get; set; }
        public float HeightExtra { get; set; } = 48f;
        public override float Height() => base.Height() - 48f + HeightExtra;

        public EverestMenuSubHeaderExt(string title, string icon = null) : base(title)
        {
            Icon = icon;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            position = SourceVector2Math.Add(position, Offset);
            float alpha = Container.Alpha * Alpha;
            PackedColor strokeColor = PackedColor.Black * (alpha * alpha * alpha);
            Vector2 textPosition = SourceVector2Math.Add(position,
                Container.InnerContent == TextMenuPresentation.InnerContentMode.TwoColumn && !AlwaysCenter
                    ? new Vector2(0f, SourceFrameworkMath.Max(0f, -16f + HeightExtra))
                    : new Vector2(Container.Width * 0.5f, SourceFrameworkMath.Max(0f, -16f + HeightExtra)));
            Vector2 justify = new Vector2(
                Container.InnerContent == TextMenuPresentation.InnerContentMode.TwoColumn && !AlwaysCenter ? 0f : 0.5f,
                0.5f);
            EverestMenuIconDrawing.DrawIcon(ResourceSet, context, Container, position, Icon, IconWidth,
                Height(), IconOutline, PackedColor.White * alpha, ref textPosition);
            if (Title.Length > 0)
                ActiveFont.DrawOutline(context, Container, Title, textPosition, justify,
                    SourceVector2Math.Multiply(Vector2.One, 0.6f), TextColor * alpha, 2f, strokeColor);
        }
    }
}
