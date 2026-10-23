using System.Collections;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestUserIOProcess
    {
        public IEnumerator SaveHandlerLegacy(bool file, bool settings)
        {
            SaveHandler(file, settings);
            return SaveNonHandler();
        }

        private IEnumerator SaveNonHandler()
        {
            // Current installed iterator retains one read, then returns false.
            _ = Saving;
            yield break;
        }
    }
}
