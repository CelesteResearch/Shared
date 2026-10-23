using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Menus.Files;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Menus.Files
{
    public sealed class EverestAssistModeState : AssistModeSequence
    {
        public EverestAssistModeState(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override PackedColor SelectionColor(bool selected)
        {
            if (selected)
                return (!((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.AllowTextHighlight ||
                        ((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(0.1f)
                    ? TextMenuPresentation.HighlightColorA
                    : TextMenuPresentation.HighlightColorB) * fade;
            return PackedColor.White * fade;
        }
    }
}
