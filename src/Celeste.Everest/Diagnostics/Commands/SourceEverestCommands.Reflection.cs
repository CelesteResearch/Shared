using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        protected override void BuildCommandsList()
        {
            ISourceTypeMetadata[] types = process.CommandsCallingAssembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                ISourceCommandMethodMetadata[] methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (ISourceCommandMethodMetadata method in methods)
                {
                    ProcessMethod(method);
                }
            }

            types = process.CommandsEntryAssembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                ISourceCommandMethodMetadata[] methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (ISourceCommandMethodMetadata method2 in methods)
                {
                    ProcessMethod(method2);
                }
            }

            if (process is Celeste.Everest.Reflection.Runtime.ISourceRuntimeTypeDiscoveryEnvironment runtime)
                foreach (ISourceTypeMetadata type in runtime.RuntimeTypeDiscovery.GetTypes())
                foreach (ISourceCommandMethodMetadata method in
                         ((ISourceCommandTypeMetadata)type).GetDeclaredStaticMethods())
                    ProcessMethod(method);

            foreach (KeyValuePair<string, SourceCommandInfo> command in commands)
            {
                sorted.Add(command.Key);
            }

            sorted.Sort();
        }

        protected override void ProcessMethod(ISourceCommandMethodMetadata method)
        {
            try
            {
                base.ProcessMethod(method);
            }
            catch (Exception e)
            {
                installed.Logger.Log(EverestLogLevel.Warn, "commands",
                    "Could not look for custom commands in method " + method.Name);
                installed.Logger.LogDetailed(e);
            }
        }
    }
}
