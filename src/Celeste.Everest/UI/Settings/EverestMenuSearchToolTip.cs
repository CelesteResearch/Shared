using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Everest.UI.Menus.Policies;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Engine;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuSearchToolTip : TextMenuPresentation.Item, IEverestTextMenuAlwaysRenderItem
    {
        private readonly ISourceEngineContext engine;
        public Vector2 preferredRenderLocation = new Vector2(100f, 952f);
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
            float scale = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                ((float)EngineRuntime.Width - Container.Width) / 2f /
                (preferredRenderLocation.X + (float)(searchIcon.FrameWidth / 2)), 1f);
            Vector2 iconPosition = new Vector2(preferredRenderLocation.X * scale, preferredRenderLocation.Y);
            SourceAtlasDrawing.DrawCentered(context, Container, searchIcon, iconPosition, PackedColor.White, scale);
            OriginalGameInputProcess input = ((IOriginalGameInputProcessEnvironment)engine).InputSource;
            SourceAtlasDrawing.Draw(context, Container, input.GuiKey(input.FirstKey(input.QuickRestart)),
                iconPosition, Vector2.Zero, PackedColor.White, scale);
        }
    }
}
