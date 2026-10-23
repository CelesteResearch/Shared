using System.Collections.Generic;
using System.Linq;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public bool FoundAnyCheckpoints(OriginalSaveDataState save, OriginalAreaKey area)
        {
            if (environment.EventMode) return false;
            if (save.DebugMode || save.CheatMode)
            {
                var mode = registry.Areas[area.ID].GetOriginalMode(area.Mode);
                if (mode != null && mode.Checkpoints != null) return mode.Checkpoints.Length != 0;
                return false;
            }

            return GetAreasSafe(save)[area.ID].Modes[area.Mode].Checkpoints.Count > 0;
        }

        public HashSet<string> GetCheckpoints(OriginalSaveDataState save, OriginalAreaKey area)
        {
            HashSet<string> result = GetOriginalCheckpoints(save, area);
            if (environment.EventMode || save.DebugMode || save.CheatMode) return result;
            var mode = areaKeys.GetArea(area).GetOriginalMode(area.Mode);
            if (mode == null) result.Clear();
            else result.RemoveWhere(a => !mode.Checkpoints.Any(b => b.Level == a));
            return result;
        }

        private HashSet<string> GetOriginalCheckpoints(OriginalSaveDataState save, OriginalAreaKey area)
        {
            if (environment.EventMode) return new HashSet<string>();
            if (save.DebugMode || save.CheatMode)
            {
                HashSet<string> result = new HashSet<string>();
                var mode = registry.Areas[area.ID].GetOriginalMode(area.Mode);
                if (mode.Checkpoints != null)
                {
                    var checkpoints = mode.Checkpoints;
                    foreach (var checkpoint in checkpoints) result.Add(checkpoint.Level);
                }

                return result;
            }

            return GetAreasSafe(save)[area.ID].Modes[area.Mode].Checkpoints;
        }
    }
}
