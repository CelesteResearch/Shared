using System;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Save.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceScreenWipeEnvironment, ISourceCurrentSaveEnvironment
    {
        private ScreenWipeProcessState sourceScreenWipes;

        public ScreenWipeProcessState ProcessWipe => sourceScreenWipes ??
                                                     throw new InvalidOperationException(
                                                         "The actual screen wipe process is not initialized.");

        ISourceSaveMirrorData ISourceCurrentSaveEnvironment.CurrentSave =>
            ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;

        public void InitializeSourceScreenWipeProcess()
        {
            if (sourceScreenWipes != null)
                throw new InvalidOperationException("The actual screen wipe process is already initialized.");
            sourceScreenWipes = new();
        }
    }
}
