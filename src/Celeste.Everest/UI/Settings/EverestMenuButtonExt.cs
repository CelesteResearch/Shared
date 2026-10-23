using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Color = Celeste.Core.Display.PackedColor;
using TextMenu = Celeste.Simulation.UI.Menus.Text.TextMenuPresentation;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuButtonExt : TextMenu.Button, IEverestMenuItemExt
    {
        public Color TextColor { get; set; } = Color.White;

        public Color TextColorDisabled { get; set; } = Color.DarkSlateGray;

        public string Icon { get; set; }

        public float? IconWidth { get; set; }

        public bool IconOutline { get; set; }

        public Vector2 Offset { get; set; }

        public float Alpha { get; set; } = 1f;

        public Vector2 Scale { get; set; } = Vector2.One;

        public override float Height()
        {
            return base.Height() * Scale.Y;
        }

        public override float LeftWidth()
        {
            return base.LeftWidth() * Scale.X;
        }

        public EverestMenuButtonExt(string label, string icon = null)
            : base(label)
        {
            Icon = icon;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            position += Offset;
            float num = Container.Alpha * Alpha;
            Color color = (Disabled ? TextColorDisabled : (highlighted ? Container.HighlightColor : TextColor)) * num;
            Color strokeColor = Color.Black * (num * num * num);
            bool flag = Container.InnerContent == TextMenu.InnerContentMode.TwoColumn && !AlwaysCenter;
            Vector2 textPosition = position + (flag ? Vector2.Zero : new Vector2(Container.Width * 0.5f, 0f));
            Vector2 justify = (flag ? new Vector2(0f, 0.5f) : new Vector2(0.5f, 0.5f));
            EverestMenuIconDrawing.DrawIcon(ResourceSet, context, Container, position, Icon, IconWidth, Height(),
                IconOutline,
                (Disabled ? Color.DarkSlateGray : (highlighted ? Color.White : Color.LightSlateGray)) * num,
                ref textPosition);
            ActiveFont.DrawOutline(context, Container, Label, textPosition, justify, Scale, color, 2f, strokeColor);
        }
    }
}
