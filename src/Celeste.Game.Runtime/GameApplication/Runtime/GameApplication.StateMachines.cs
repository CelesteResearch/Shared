using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Scheduling;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceStateMachineEnvironment
    {
        private ISourceStateMachineFactory sourceStateMachines;

        public ISourceStateMachineFactory StateMachines => sourceStateMachines ??
                                                           throw new InvalidOperationException(
                                                               "The source StateMachine factory is not selected.");

        public void ConstructSourceStateMachineFactory()
        {
            if (sourceStateMachines != null)
                throw new InvalidOperationException("The source StateMachine factory is already selected.");
            if (SourceProfile == GameProfile.Original)
                sourceStateMachines = new OriginalStateMachineFactory();
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceStateMachines = new InstalledStateMachineFactory();
            else throw new InvalidOperationException("A supported source profile is required.");
        }
    }
}
