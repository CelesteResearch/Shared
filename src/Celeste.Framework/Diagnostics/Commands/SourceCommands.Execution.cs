using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public void ExecuteCommand(string command, string[] args)
        {
            if (commands.ContainsKey(command))
            {
                using (new SourceCommandExecutionScope(process as Celeste.Core.Scheduling.ISourceEngineContext))
                    commands[command].Action(args);
            }
            else
            {
                Log("Command '" + command + "' not found! Type 'help' for list of commands", PackedColor.Yellow);
            }
        }

        public void ExecuteFunctionKeyAction(int num)
        {
            if (FunctionKeyActions[num] != null)
            {
                FunctionKeyActions[num]();
            }
        }
    }
}
