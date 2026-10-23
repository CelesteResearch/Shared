using System.Linq;
using Celeste.Everest.Runtime.Startup;
using Celeste.Game.Runtime.Physical.Processes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        internal void ApplySourceInstalledEarlyMainArguments()
        {
            string[] args = PhysicalIO.CommandLine.GetCommandLineArgs().Skip(1).ToArray();
            EverestRuntime.ParseSourceEarlyArguments(args);
            SourceFnaMainArguments.Parse(args, Flags.IsHeadless, new SourceFnaMainArgumentEnvironment());
        }
    }
}
