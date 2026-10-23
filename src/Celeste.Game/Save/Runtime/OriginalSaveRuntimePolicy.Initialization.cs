using System;
using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public string GetFilename(int slot) => slot == 4 ? "debug" : slot.ToString();

        public void AfterInitialize(OriginalSaveDataState save, IOriginalSaveInitializationServices services)
        {
            while (save.Areas.Count < areas.Areas.Count)
                save.Areas.Add(new OriginalAreaStats(save.Areas.Count));
            while (save.Areas.Count > areas.Areas.Count)
                save.Areas.RemoveAt(save.Areas.Count - 1);
            int completed = -1;
            for (int i = 0; i < save.Areas.Count; i++)
                if (save.Areas[i].Modes[0].Completed
                    || (save.Areas[i].Modes.Length > 1 && save.Areas[i].Modes[1].Completed))
                    completed = i;
            if (save.UnlockedAreas < completed + 1 && GetMaxArea(save) >= completed + 1)
                save.UnlockedAreas = completed + 1;
            if (save.DebugMode)
            {
                save.CurrentSession = null;
                save.RevealedChapter9 = true;
                save.UnlockedAreas = GetMaxArea(save);
            }

            if (save.CheatMode) save.UnlockedAreas = GetMaxArea(save);
            if (string.IsNullOrEmpty(save.TheoSisterName))
            {
                save.TheoSisterName = services.CleanDialog("THEO_SISTER_NAME");
                if (save.Name.IndexOf(save.TheoSisterName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    save.TheoSisterName = services.CleanDialog("THEO_SISTER_ALT_NAME");
            }

            save.AssistModeChecks(services);
            foreach (var area in save.Areas)
            {
                foreach (global::Celeste.Formats.Save.Xml.AreaMode sourceModeValue in
                         Enum.GetValues(typeof(global::Celeste.Formats.Save.Xml.AreaMode)))
                {
                    int mode = (int)sourceModeValue;
                    if (areas.Areas[area.ID].ModeCount <= mode) continue;
                    var state = area.Modes[mode];
                    var sourceMode = areas.Areas[area.ID].GetOriginalMode(mode);
                    var old = new HashSet<string>(state.Checkpoints);
                    state.Checkpoints.Clear();
                    if (sourceMode != null && sourceMode.Checkpoints != null)
                        foreach (var checkpoint in sourceMode.Checkpoints)
                            if (old.Contains(checkpoint.Level))
                                state.Checkpoints.Add(checkpoint.Level);
                }
            }

            if (save.Version == null || !(new Version(save.Version) < new Version(1, 2, 1, 1))) return;
            for (int i = 0; i < save.Areas.Count; i++)
            {
                if (save.Areas[i] == null) continue;
                for (int mode = 0; mode < save.Areas[i].Modes.Length; mode++)
                {
                    if (save.Areas[i].Modes[mode] != null)
                    {
                        if (save.Areas[i].Modes[mode].BestTime > 0)
                            save.Areas[i].Modes[mode].SingleRunCompleted = true;
                        save.Areas[i].Modes[mode].BestTime = 0;
                        save.Areas[i].Modes[mode].BestFullClearTime = 0;
                    }
                }
            }
        }
    }
}
