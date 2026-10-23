using System;
using Celeste.Game.Controls.Source;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Entities.Postcards;
using Celeste.Game.Platform.Statistics;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        private static OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)Process).Text;

        [SourceCommandAttribute("global_stats", "logs global steam stats")]
        private static void CmdGlobalStats()
        {
            foreach (OriginalStatistic value in Enum.GetValues(typeof(OriginalStatistic)))
            {
                Console.Log(value.ToString() + ": " +
                            ((IOriginalPlatformStatisticsEnvironment)Process).Statistics.Global(value));
            }
        }

        [SourceCommandAttribute("input_gui", "override input gui")]
        private static void CmdInputGui(string prefix)
        {
            ((IOriginalGameInputProcessEnvironment)Process).InputSource.OverrideInputPrefix = prefix;
        }

        [SourceCommandAttribute("lines", "Counts Dialog Lines")]
        private static void CmdLines(string language)
        {
            if (string.IsNullOrEmpty(language))
            {
                language = Text.Dialog.Language.Id;
            }

            if (Text.Dialog.Languages.ContainsKey(language))
            {
                Console.Log(language + ": " + Text.Dialog.Languages[language].Lines + " lines, " +
                            Text.Dialog.Languages[language].Words + " words");
            }
            else
            {
                Console.Log("language '" + language + "' doesn't exist");
            }
        }

        [SourceCommandAttribute("fonts", "check loaded fonts")]
        private static void CmdFonts()
        {
            Text.Fonts.Log();
        }

        [SourceCommandAttribute("postcard", "views a postcard")]
        private static void CmdPostcard(string id, int area = 1)
        {
            Scene = new PreviewPostcardState(Process,
                new PostcardState(Process, Text.Dialog.Get("POSTCARD_" + id), area));
        }

        [SourceCommandAttribute("postcard_cside", "views a postcard")]
        private static void CmdPostcardCside()
        {
            Scene = new PreviewPostcardState(Process,
                new PostcardState(Process, Text.Dialog.Get("POSTCARD_CSIDES"), "event:/ui/main/postcard_csides_in",
                    "event:/ui/main/postcard_csides_out"));
        }

        [SourceCommandAttribute("postcard_variants", "views a postcard")]
        private static void CmdPostcardVariants()
        {
            Scene = new PreviewPostcardState(Process,
                new PostcardState(Process, Text.Dialog.Get("POSTCARD_VARIANTS"),
                    "event:/new_content/ui/postcard_variants_in", "event:/new_content/ui/postcard_variants_out"));
        }
    }
}
