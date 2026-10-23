using System.Linq;
using Celeste.Everest.Presentation.Hud;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public override void LoadContent(bool firstLoad)
        {
            if (!string.IsNullOrEmpty(Settings.InputGui))
            {
                var inputGuiPath = "controls/" + Settings.InputGui + "/";
                if (((ISourceGuiAtlasResources)SourceEngine).GuiAtlas.Entries.Any(pair =>
                        pair.Key.StartsWith(inputGuiPath)))
                    ((IOriginalGameInputProcessEnvironment)SourceEngine).InputSource.OverrideInputPrefix =
                        Settings.InputGui;
                else
                    Settings.InputGui = "";
            }

            if (firstLoad)
                ((IEverestSubHudRendererEnvironment)SourceEngine).SubHudRendererProcess.Buffer =
                    ((ISourceVirtualContentEnvironment)SourceEngine).VirtualContent.CreateRenderTarget("subhud-target",
                        1922, 1082);
        }
    }
}
