using System.Collections;
using System.Runtime.CompilerServices;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override IEnumerator Enter(OuiState from)
        {
            Commands.Enabled = false;
            if (UseKeyboardInput) TextInput.OnInput += OnTextInput;

            return base.Enter(from);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override IEnumerator Leave(OuiState next)
        {
            Commands.Enabled = ((IOriginalGamePlayModeEnvironment)SourceEngine).PlayMode ==
                               GameRuntime.PlayModes.Debug;
            TextInput.OnInput -= OnTextInput;
            return base.Leave(next);
        }
    }
}
