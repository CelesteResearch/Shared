using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Input;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Menus.Files;

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
