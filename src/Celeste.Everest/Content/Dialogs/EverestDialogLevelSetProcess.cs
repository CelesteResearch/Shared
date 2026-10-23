using System;
using System.Collections.Generic;
using System.Text;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Localization.Languages;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Content.Dialogs
{
    // Source Dialog warning sets share this one installed process. Reload must clear these same sets.
    public sealed partial class EverestDialogLevelSetProcess : IOriginalInstalledDialogPolicy
    {
        private readonly ISourceEngineContext engine;
        public readonly HashSet<string> MissingDialogIds = new HashSet<string>();
        public readonly HashSet<string> InvalidDialogIds = new HashSet<string>();

        public EverestDialogLevelSetProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        public string CleanLevelSet(string name)
        {
            if (string.IsNullOrEmpty(name)) return Text.Dialog.Clean("levelset_");
            name = Celeste.Everest.Modules.Updating.EverestStringSource.DialogKeyify(name);
            string value =
                Celeste.Everest.UI.Controls.EverestModuleDialogText.CleanOrNull(engine, "levelset_" + name) ??
                Celeste.Everest.UI.Controls.EverestModuleDialogText.CleanOrNull(engine, name);
            if (value != null) return value;
            if (!IsValidId(name)) WarnInvalidDialogId(name, true);
            else WarnMissingDialogId(name, null, true);
            return Celeste.Everest.Modules.Updating.EverestStringSource.SpacedPascalCase(name);
        }

        private static bool IsValidId(string id)
        {
            foreach (char c in id)
                if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')) && c != '_')
                    return false;
            return true;
        }

        private void WarnMissingDialogId(string id, DialogLanguage language = null, bool isLevelSet = false)
        {
            if (MissingDialogIds.Add(id))
            {
                if (language == null) language = Text.Dialog.Language;
                StringBuilder builder = new StringBuilder();
                if (isLevelSet) builder.Append("Level set ");
                builder.AppendFormat("Dialog ID \"{0}\" has no translation in {1}", id, language.FilePath);
                if (language != Text.Dialog.FallbackLanguage)
                    builder.AppendFormat(" or {0}", Text.Dialog.FallbackLanguage.FilePath);
                builder.Append('!');
                Logger.Log(EverestLogLevel.Warn, "Dialog", builder.ToString());
            }
        }

        private void WarnInvalidDialogId(string id, bool isLevelSet = false)
        {
            if (InvalidDialogIds.Add(id))
            {
                StringBuilder builder = new StringBuilder();
                if (isLevelSet) builder.Append("Level set ");
                builder.Append($"Dialog ID \"{id}\" contains invalid characters!");
                Logger.Log(EverestLogLevel.Warn, "Dialog", builder.ToString());
            }
        }
    }
}
