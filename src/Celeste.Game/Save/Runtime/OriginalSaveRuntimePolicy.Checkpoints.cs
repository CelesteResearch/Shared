using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public bool FoundAnyCheckpoints(OriginalSaveDataState save, OriginalAreaKey area)
        {
            if (environment.EventMode) return false;
            if (save.DebugMode || save.CheatMode)
            {
                var mode = areas.Areas[area.ID].GetOriginalMode(area.Mode);
                if (mode != null && mode.Checkpoints != null) return mode.Checkpoints.Length != 0;
                return false;
            }

            return save.Areas[area.ID].Modes[area.Mode].Checkpoints.Count > 0;
        }

        public HashSet<string> GetCheckpoints(OriginalSaveDataState save, OriginalAreaKey area)
        {
            if (environment.EventMode) return [];
            if (save.DebugMode || save.CheatMode)
            {
                var result = new HashSet<string>();
                var mode = areas.Areas[area.ID].GetOriginalMode(area.Mode);
                if (mode.Checkpoints != null)
                {
                    var checkpoints = mode.Checkpoints;
                    foreach (var checkpoint in checkpoints) result.Add(checkpoint.Level);
                }

                return result;
            }

            return save.Areas[area.ID].Modes[area.Mode].Checkpoints;
        }
    }
}
