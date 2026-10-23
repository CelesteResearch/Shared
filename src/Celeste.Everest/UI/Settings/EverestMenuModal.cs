using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Everest.UI.Menus.Policies;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuModal : TextMenuPresentation.Item, IEverestTextMenuAlwaysRenderItem
    {
        public readonly TextMenuPresentation.Item Item;

        private readonly float? absoluteY;

        private readonly float? absoluteX;

        public Color BoxBorderColor { get; set; } = Color.White;

        public Color BoxBackgroundColor { get; set; } = Color.Black * 0.8f;

        public int BorderThickness { get; set; } = 2;

        public bool AlwaysRender => true;

        public EverestMenuModal(TextMenuPresentation.Item item, float? absoluteX, float? absoluteY)
        {
            AboveAll = true;
            Visible = false;
            IncludeWidthInMeasurement = false;
            this.absoluteY = absoluteY;
            this.absoluteX = absoluteX;
            Item = item;
        }

        public override void Added()
        {
            base.Added();
            Item.Container = Container;
            Item.Added();
        }

        public override void Update()
        {
            base.Update();
            Item.OnUpdate?.Invoke();
            Item.Update();
        }

        public override float Height()
        {
            if (Container != null) return Container.ItemSpacing * -1f;

            return 0f;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            var position2 = new Vector2(absoluteX ?? position.X, absoluteY ?? position.Y);
            for (var i = 1; i <= BorderThickness; i++)
                SourcePrimitiveDrawing.HollowRect(context, Container, position2.X - i, position2.Y - i,
                    Item.Width + 2 * i, Item.Height() + 2 * i, BoxBorderColor * Container.Alpha);

            Item.Render(context, position2, highlighted);
        }
    }
}
