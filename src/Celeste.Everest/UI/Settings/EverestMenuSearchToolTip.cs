using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.UI.Menus.Policies;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuSearchToolTip : TextMenuPresentation.Item, IEverestTextMenuAlwaysRenderItem
    {
        private readonly ISourceEngineContext engine;
        public Vector2 preferredRenderLocation = new(100f, 952f);
        private readonly AtlasEntry searchIcon;
        public bool AlwaysRender => true;

        public EverestMenuSearchToolTip(ISourceEngineContext engine)
        {
            this.engine = engine;
            searchIcon = ((ISourceGuiAtlasResources)engine).GuiAtlas["menu/mapsearch"];
            AboveAll = true;
            Selectable = false;
            IncludeWidthInMeasurement = false;
        }

        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            var scale = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                (EngineRuntime.Width - Container.Width) / 2f /
                (preferredRenderLocation.X + searchIcon.FrameWidth / 2), 1f);
            var iconPosition = new Vector2(preferredRenderLocation.X * scale, preferredRenderLocation.Y);
            SourceAtlasDrawing.DrawCentered(context, Container, searchIcon, iconPosition, PackedColor.White, scale);
            var input = ((IOriginalGameInputProcessEnvironment)engine).InputSource;
            SourceAtlasDrawing.Draw(context, Container, input.GuiKey(input.FirstKey(input.QuickRestart)),
                iconPosition, Vector2.Zero, PackedColor.White, scale);
        }
    }
}
