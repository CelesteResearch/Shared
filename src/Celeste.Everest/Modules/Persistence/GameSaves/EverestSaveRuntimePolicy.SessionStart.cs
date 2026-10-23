using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void StartSession(OriginalSaveDataState actualSave, ChapterCompletionSession session)
        {
            var previous = actualSave.CurrentSessionSafe;
            actualSave.LastAreaSafe = areaKeys.GetSessionArea(session);
            actualSave.CurrentSessionSafe = session;
            if (actualSave.DebugMode)
            {
                var mode = GetAreasSafe(actualSave)[session.AreaID].Modes[session.Mode];
                var old = session.OldStats.Modes[session.Mode];
                var current = context.CurrentSave;
                SetTotalStrawberriesSafe(current,
                    unchecked(GetTotalStrawberriesSafe(current) - mode.TotalStrawberries));
                mode.Strawberries.Clear();
                mode.TotalStrawberries = 0;
                old.Strawberries.Clear();
                old.TotalStrawberries = 0;
            }

            if (previous != session)
                foreach (var module in saveModules.SaveModules)
                {
                    if (module.SaveDataAsync) module.DeserializeSession(actualSave.FileSlot, null);
#pragma warning disable CS0618
                    // Preserve original legacy module override dispatch.
                    else module.LoadSession(actualSave.FileSlot, true);
#pragma warning restore CS0618
                }
        }

        public int GetTotalStrawberriesSafe(OriginalSaveDataState save)
        {
            return GetLevelSet(save) == "Celeste" ? save.TotalStrawberries : GetLevelSetStats(save).TotalStrawberries;
        }

        public void SetTotalStrawberriesSafe(OriginalSaveDataState save, int value)
        {
            if (save.LevelSets == null || GetLevelSet(save) == "Celeste") save.TotalStrawberries = value;
            else GetLevelSetStats(save).TotalStrawberries = value;
        }
    }
}
