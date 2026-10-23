using System.Linq;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void BeforeSave(OriginalSaveDataState actualSave)
        {
            if (areaKeys.GetLevelSet(actualSave.LastAreaSafe) == "Celeste")
            {
                actualSave.LastArea = actualSave.LastAreaSafe;
            }

            if (actualSave.CurrentSessionSafe != null
                && areaKeys.GetLevelSet(areaKeys.GetSessionArea(actualSave.CurrentSessionSafe)) == "Celeste")
                actualSave.CurrentSession = actualSave.CurrentSessionSafe;
            foreach (var set in actualSave.LevelSets)
            {
                if (set.Name == "Celeste") continue;
                int playable = registry.Areas.Count(area => area.LevelSet == set.Name
                                                            && string.IsNullOrEmpty(
                                                                ((global::Celeste.Everest.Content.Maps.Registry.
                                                                        EverestArea)
                                                                    area).Metadata?.Parent));
                var areas = set.Areas;
                while (areas.Count > playable) areas.RemoveAt(areas.Count - 1);
            }

            // The orig body reads the actual current save again after installed mutations.
            context.CurrentSave.Version = engineIdentity.EngineIdentity.Version.ToString();
        }
    }
}
