using Celeste.Game.Components.Talking;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Gameplay.Interaction.Talking;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalTalkProcess, ISourceTalkHoverEnvironment
    {
        bool ISourceTalkHoverEnvironment.HasTalkHover => OriginalTalkComponent.PlayerOver != null;
        OriginalSaveDataState IOriginalTalkProcess.CurrentSave => SaveContext.CurrentSave;

        void IOriginalTalkProcess.PlayUiSound(string eventName)
        {
            AudioSession.Play(eventName);
        }
    }
}
