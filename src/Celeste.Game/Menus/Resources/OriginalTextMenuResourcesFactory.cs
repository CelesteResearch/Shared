using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Menus.Resources
{
    public static class OriginalTextMenuResourcesFactory
    {
        public static TextMenuResources Create(ISourceEngineContext engine)
        {
            var resources = (IOriginalGameInputSourceEnvironment)engine;
            var input = ((IOriginalGameInputProcessEnvironment)engine).InputSource;
            return new(engine)
            {
                LanguageIcon = language => language.Icon,
                Gui = path => resources.GuiAtlas[path],
                HasGui = path => resources.GuiAtlas.Has(path),
                GuiKey = code => input.GuiKey((SourceKeys)code, null),
                GuiControllerButton = code => input.GuiSingleButton((SourceGamePadButtonFlags)code, fallback: null),
            };
        }
    }
}
