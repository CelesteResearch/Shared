using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public string FormatModName(string modNameRaw)
        {
            if (modNameRaw == null) return null;
            var key = "modname_" + EverestStringSource.DialogKeyify(modNameRaw);
            string clean = null;
            if (((IOriginalGameTextEnvironment)engine).Text.Dialog.Has(key))
                clean = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean(key);
            return clean ?? EverestStringSource.SpacedPascalCase(modNameRaw);
        }
    }
}
