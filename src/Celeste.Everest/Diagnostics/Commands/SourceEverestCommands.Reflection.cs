using System;
using Celeste.Core.Reflection;
using Celeste.Everest.Reflection.Runtime;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        protected override void BuildCommandsList()
        {
            var types = process.CommandsCallingAssembly.GetTypes();
            for (var i = 0; i < types.Length; i++)
            {
                var methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (var method in methods) ProcessMethod(method);
            }

            types = process.CommandsEntryAssembly.GetTypes();
            for (var i = 0; i < types.Length; i++)
            {
                var methods =
                    ((ISourceCommandTypeMetadata)types[i]).GetDeclaredStaticMethods();
                foreach (var method2 in methods) ProcessMethod(method2);
            }

            if (process is ISourceRuntimeTypeDiscoveryEnvironment runtime)
                foreach (var type in runtime.RuntimeTypeDiscovery.GetTypes())
                foreach (var method in
                         ((ISourceCommandTypeMetadata)type).GetDeclaredStaticMethods())
                    ProcessMethod(method);

            foreach (var command in commands) sorted.Add(command.Key);

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
