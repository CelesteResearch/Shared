using System.Collections.Generic;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public void InitializeModules()
        {
            foreach (var module in Modules.ToArray())
                InitializeModule(module);
            Runtime.Initialized = true;
        }

        public void ParseArgs(IEnumerable<string> args)
        {
            Queue<string> queue = new(args);
            while (queue.Count > 0)
            {
                var arg = queue.Dequeue();
                using var enumerator = Modules.GetEnumerator();
                while (enumerator.MoveNext() && !enumerator.Current.ParseArg(arg, queue))
                {
                }
            }
        }
    }
}
