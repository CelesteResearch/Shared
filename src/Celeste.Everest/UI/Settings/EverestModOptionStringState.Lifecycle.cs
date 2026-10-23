using Celeste.Game.Execution;
using Celeste.Game.Execution.Startup;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        public override void SceneEnd(object scene)
        {
            Overworld.ShowInputUI = true;
            Commands.Enabled = ((IOriginalGamePlayModeEnvironment)engine).PlayMode ==
                               GameRuntime.PlayModes.Debug;
        }
    }
}
