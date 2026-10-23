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

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState : FileNamingSequence
    {
        private IEverestFileNamingEnvironment Environment => (IEverestFileNamingEnvironment)SourceEngine;
        private EverestTextInputProcess TextInput => ((IEverestTextInputEnvironment)SourceEngine).TextInput;
        private SourceCommands Commands => ((ISourceCommandsProcessEnvironment)SourceEngine).Commands;
        public bool UseKeyboardInput => Environment.CurrentCoreSettings?.UseKeyboardForTextInput ?? false;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public EverestFileNamingState(ISourceEngineContext engine) : base(engine)
        {
        }
    }
}
