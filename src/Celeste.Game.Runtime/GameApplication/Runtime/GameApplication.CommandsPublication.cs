using System;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Everest.Diagnostics.Commands;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceCommandsProcessEnvironment,
        ISourceCommandsPublicationEnvironment
    {
        private SourceCommands sourceCommands;
        private Func<string, object, object, string> sourceCommandsLevelCursorFormatter;

        public event Func<string, object, object, string> SourceCommandsLevelCursorFormatter
        {
            add
            {
                sourceCommandsLevelCursorFormatter += value;
                if (sourceCommands is SourceEverestCommands installedCommands)
                    installedCommands.SourceLevelCursorFormatter += value;
            }
            remove
            {
                sourceCommandsLevelCursorFormatter -= value;
                if (sourceCommands is SourceEverestCommands installedCommands)
                    installedCommands.SourceLevelCursorFormatter -= value;
            }
        }

        public SourceCommands Commands => sourceCommands ??
                                          throw new InvalidOperationException(
                                              "The actual source Commands process is not constructed.");

        public SourceCommands CommandsOrNull => sourceCommands;

        private void PublishSourceCommands(SourceCommands actualCommands)
        {
            if (sourceCommands != null)
                throw new InvalidOperationException("The actual source Commands process is already published.");
            sourceCommands = actualCommands ?? throw new ArgumentNullException(nameof(actualCommands));
            if (actualCommands is SourceEverestCommands installedCommands)
                installedCommands.SourceLevelCursorFormatter += sourceCommandsLevelCursorFormatter;
        }
    }
}
