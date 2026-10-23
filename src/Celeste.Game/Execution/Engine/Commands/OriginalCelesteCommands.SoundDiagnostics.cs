using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommand("sound_instances", "gets active sound count")]
        private static void CmdSounds()
        {
            var num = 0;
            foreach (var
                         cachedEventDescription
                     in
                     ((IOriginalGameplayProcess)Process).AudioSession.cachedEventDescriptions)
            {
                var description = cachedEventDescription.Value;
                description.GetInstanceCount(out var count);
                if (count > 0)
                {
                    description.GetPath(out var path);
                    Console.Log(path + ": " + count);
                    System.Console.WriteLine(path + ": " + count);
                }

                num += count;
            }

            Console.Log("total: " + num);
            System.Console.WriteLine("total: " + num);
        }
    }
}
