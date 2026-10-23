using System;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Platform.Statistics;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        private static OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)Process).Text;

        [SourceCommand("global_stats", "logs global steam stats")]
        private static void CmdGlobalStats()
        {
            foreach (OriginalStatistic value in Enum.GetValues(typeof(OriginalStatistic)))
                Console.Log(value + ": " +
                            ((IOriginalPlatformStatisticsEnvironment)Process).Statistics.Global(value));
        }

        [SourceCommand("input_gui", "override input gui")]
        private static void CmdInputGui(string prefix)
        {
            ((IOriginalGameInputProcessEnvironment)Process).InputSource.OverrideInputPrefix = prefix;
        }

        [SourceCommand("lines", "Counts Dialog Lines")]
        private static void CmdLines(string language)
        {
            if (string.IsNullOrEmpty(language)) language = Text.Dialog.Language.Id;

            if (Text.Dialog.Languages.ContainsKey(language))
                Console.Log(language + ": " + Text.Dialog.Languages[language].Lines + " lines, " +
                            Text.Dialog.Languages[language].Words + " words");
            else
                Console.Log("language '" + language + "' doesn't exist");
        }

        [SourceCommand("fonts", "check loaded fonts")]
        private static void CmdFonts()
        {
            Text.Fonts.Log();
        }

        [SourceCommand("postcard", "views a postcard")]
        private static void CmdPostcard(string id, int area = 1)
        {
            Scene = new PreviewPostcardState(Process,
                new(Process, Text.Dialog.Get("POSTCARD_" + id), area));
        }

        [SourceCommand("postcard_cside", "views a postcard")]
        private static void CmdPostcardCside()
        {
            Scene = new PreviewPostcardState(Process,
                new(Process, Text.Dialog.Get("POSTCARD_CSIDES"), "event:/ui/main/postcard_csides_in",
                    "event:/ui/main/postcard_csides_out"));
        }

        [SourceCommand("postcard_variants", "views a postcard")]
        private static void CmdPostcardVariants()
        {
            Scene = new PreviewPostcardState(Process,
                new(Process, Text.Dialog.Get("POSTCARD_VARIANTS"),
                    "event:/new_content/ui/postcard_variants_in", "event:/new_content/ui/postcard_variants_out"));
        }
    }
}
