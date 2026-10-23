using System.Text;

namespace Celeste.Framework.Diagnostics.Commands
{
    public static class SourceCommandsBuiltinScope

    {
        public static void Clear(ISourceCommandsBuiltinProcess process)

        {
            process.Commands.drawCommands.Clear();
        }

        public static void Exit(ISourceCommandsBuiltinProcess process)

        {
            process.Exit();
        }

        public static void Vsync(ISourceCommandsBuiltinProcess process, bool enabled = true)

        {
            process.Graphics.SynchronizeWithVerticalRetrace = enabled;

            process.Graphics.ApplyChanges();

            process.Commands.Log("Vertical Sync " + (enabled ? "Enabled" : "Disabled"));
        }

        public static void Count(ISourceCommandsBuiltinProcess process, int tagIndex = -1)

        {
            if (process.Scene == null)
                process.Commands.Log("Current Scene is null!");

            else if (tagIndex < 0)
                process.Commands.Log(process.Scene.EntityCount.ToString());

            else
                process.Commands.Log(process.Scene.GetTagCount(tagIndex).ToString());
        }

        public static void Tracker(ISourceCommandsBuiltinProcess process, string mode)

        {
            if (process.Scene == null)

            {
                process.Commands.Log("Current Scene is null!");
            }

            else if (!(mode == "e"))

            {
                if (!(mode == "c"))

                {
                    process.Commands.Log("-- Entities --");

                    process.Scene.LogEntities(process.Commands);

                    process.Commands.Log("-- Components --");

                    process.Scene.LogComponents(process.Commands);
                }

                else

                {
                    process.Scene.LogComponents(process.Commands);
                }
            }

            else

            {
                process.Scene.LogEntities(process.Commands);
            }
        }

        public static void Pooler(ISourceCommandsBuiltinProcess process)

        {
            process.Pooler.Log(process.Commands, process.SceneMetadata);
        }

        public static void Fullscreen(ISourceCommandsBuiltinProcess process)

        {
            process.SetFullscreen();
        }

        public static void Window(ISourceCommandsBuiltinProcess process, int scale = 1)

        {
            process.SetWindowed(320 * scale, 180 * scale);
        }

        public static void Help(ISourceCommandsBuiltinProcess process, string command)

        {
            if (process.Commands.sorted.Contains(command))

            {
                var commandInfo = process.Commands.commands[command];

                var stringBuilder = new StringBuilder();

                stringBuilder.Append(":: ");

                stringBuilder.Append(command);

                if (!string.IsNullOrEmpty(commandInfo.Usage))

                {
                    stringBuilder.Append(" ");

                    stringBuilder.Append(commandInfo.Usage);
                }

                process.Commands.Log(stringBuilder.ToString());

                if (string.IsNullOrEmpty(commandInfo.Help))
                    process.Commands.Log("No help info set");

                else
                    process.Commands.Log(commandInfo.Help);
            }

            else

            {
                var stringBuilder2 = new StringBuilder();

                stringBuilder2.Append("Commands list: ");

                stringBuilder2.Append(string.Join(", ", process.Commands.sorted));

                process.Commands.Log(stringBuilder2.ToString());

                process.Commands.Log("Type 'help command' for more info on that command!");
            }
        }
    }
}
