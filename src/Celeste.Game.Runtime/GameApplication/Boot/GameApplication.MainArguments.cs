using System.Linq;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        internal void ApplySourceMainStartupArguments()
        {
            var args = PhysicalIO.CommandLine.GetCommandLineArgs().Skip(1).ToArray();
            _ = SettingsProcess.Existed;
            for (var i = 0; i < args.Length - 1; i++)
                if (args[i] == "--language" || args[i] == "-l")
                {
                    SettingsProcess.Instance.LanguageId = args[++i];
                }
                else if (args[i] == "--default-language" || args[i] == "-dl")
                {
                    if (!SettingsProcess.Existed)
                        SettingsProcess.Instance.LanguageId = args[++i];
                }
                else if (args[i] == "--gui" || args[i] == "-g")
                {
                    InputSource.OverrideInputPrefix = args[++i];
                }
        }
    }
}
