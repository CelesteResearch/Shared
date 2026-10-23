using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuHeaderImage : TextMenuPresentation.Item
    {
        public string Image { get; set; }
        public bool ImageOutline { get; set; }
        public PackedColor ImageColor { get; set; } = PackedColor.White;
        public float ImageScale { get; set; } = 1f;
        public Vector2 Offset { get; set; }
        public float Alpha { get; set; } = 1f;

        public EverestMenuHeaderImage(string image = null)
        {
            Image = image;
            Selectable = false;
            IncludeWidthInMeasurement = false;
        }

        public override float LeftWidth()
        {
            if (Image == null || !ResourceSet.HasGui(Image)) return 0f;
            return ResourceSet.Gui(Image).FrameWidth * ImageScale;
        }

        public override float Height()
        {
            if (Image == null || !ResourceSet.HasGui(Image)) return 0f;
            return ResourceSet.Gui(Image).FrameHeight * ImageScale;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            position = SourceVector2Math.Add(position, Offset);
            var alpha = Container.Alpha * Alpha;
            _ = PackedColor.Black * (alpha * alpha * alpha);
            if (!(Image != null && ResourceSet.HasGui(Image)))
                return;
            var texture = ResourceSet.Gui(Image);
            var justify = SourceVector2Math.Multiply(Vector2.UnitY, .5f);
            if (ImageOutline)
                SourceAtlasJustifiedOutline.Draw(context, Container, texture, position, justify, ImageColor,
                    ImageScale);
            else
                SourceAtlasDrawing.DrawJustified(context, Container, texture, position, justify, ImageColor,
                    ImageScale);
        }
    }
}
