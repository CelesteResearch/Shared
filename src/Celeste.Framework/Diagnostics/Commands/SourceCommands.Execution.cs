using Celeste.Core.Display;
using Celeste.Core.Scheduling;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public void ExecuteCommand(string command, string[] args)
        {
            if (commands.ContainsKey(command))
                using (new SourceCommandExecutionScope(process as ISourceEngineContext))
                {
                    commands[command].Action(args);
                }
            else
                Log("Command '" + command + "' not found! Type 'help' for list of commands", PackedColor.Yellow);
        }

        public void ExecuteFunctionKeyAction(int num)
        {
            if (FunctionKeyActions[num] != null) FunctionKeyActions[num]();
        }
    }
}
