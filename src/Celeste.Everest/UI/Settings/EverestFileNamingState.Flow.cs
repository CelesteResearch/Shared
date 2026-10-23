using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override IEnumerator Enter(OuiState from)
        {
            Commands.Enabled = false;
            if (UseKeyboardInput)
            {
                TextInput.OnInput += OnTextInput;
            }

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
