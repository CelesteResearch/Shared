using System;
using System.Collections.Generic;
using Celeste.Game.Execution.Processes;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommandAttribute("sound_instances", "gets active sound count")]
        private static void CmdSounds()
        {
            int num = 0;
            foreach (KeyValuePair<string, global::Celeste.Audio.Fmod.Events.FmodEventDescriptionReference>
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
                    global::System.Console.WriteLine(path + ": " + count);
                }

                num += count;
            }

            Console.Log("total: " + num);
            global::System.Console.WriteLine("total: " + num);
        }
    }
}
