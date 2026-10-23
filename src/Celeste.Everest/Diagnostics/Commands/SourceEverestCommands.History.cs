using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        protected override void EnterCommand()
        {
            if (!string.IsNullOrWhiteSpace(currentText.Replace(",", "")))
            {
                base.EnterCommand();
            }
        }

        public void ReloadCommandsList()
        {
            commands.Clear();
            sorted.Clear();
            BuildCommandsList();
        }

        public IEnumerable<SourceCommandData> GetCommands()
        {
            foreach (KeyValuePair<string, SourceCommandInfo> command in commands)
            {
                yield return new SourceCommandData
                {
                    Name = command.Key,
                    Help = command.Value.Help,
                    Usage = command.Value.Usage
                };
            }
        }
    }
}
