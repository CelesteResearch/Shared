using System.Collections.Generic;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        protected override void EnterCommand()
        {
            if (!string.IsNullOrWhiteSpace(currentText.Replace(",", ""))) base.EnterCommand();
        }

        public void ReloadCommandsList()
        {
            commands.Clear();
            sorted.Clear();
            BuildCommandsList();
        }

        public IEnumerable<SourceCommandData> GetCommands()
        {
            foreach (var command in commands)
                yield return new()
                {
                    Name = command.Key,
                    Help = command.Value.Help,
                    Usage = command.Value.Usage,
                };
        }
    }
}
