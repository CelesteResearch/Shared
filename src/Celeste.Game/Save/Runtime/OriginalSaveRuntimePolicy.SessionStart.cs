using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void StartSession(OriginalSaveDataState actualSave, ChapterCompletionSession session)
        {
            SetLastAreaSafe(actualSave, new() { ID = session.AreaID, Mode = session.Mode });
            SetCurrentSessionSafe(actualSave, session);
            if (actualSave.DebugMode)
            {
                var mode = actualSave.Areas[session.AreaID].Modes[session.Mode];
                var old = session.OldStats.Modes[session.Mode];
                var current = context.CurrentSave;
                current.TotalStrawberries = unchecked(current.TotalStrawberries - mode.TotalStrawberries);
                mode.Strawberries.Clear();
                mode.TotalStrawberries = 0;
                old.Strawberries.Clear();
                old.TotalStrawberries = 0;
            }
        }
    }
}
