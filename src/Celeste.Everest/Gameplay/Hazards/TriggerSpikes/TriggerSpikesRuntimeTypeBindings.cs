using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes;

namespace Celeste.Everest.Gameplay.Hazards.TriggerSpikes
{
    public static class TriggerSpikesRuntimeTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            // Installed Celeste.TriggerSpikes retains the original complete 4px actor implementation.
            catalog.RegisterRuntimeType(typeof(TriggerSpikesState), "Celeste.TriggerSpikes");
            catalog.SelectLogicalActualType(typeof(TriggerSpikesState), "Celeste.TriggerSpikes");
            catalog.RegisterRuntimeType(typeof(TriggerSpikesState.SpikeInfo), "Celeste.TriggerSpikes.SpikeInfo");
            catalog.SelectLogicalActualType(typeof(TriggerSpikesState.SpikeInfo), "Celeste.TriggerSpikes+SpikeInfo");
            catalog.RegisterRuntimeType(typeof(TriggerSpikesDirection), "Celeste.TriggerSpikes.Directions");
            catalog.SelectLogicalActualType(typeof(TriggerSpikesDirection), "Celeste.TriggerSpikes+Directions");
            catalog.RegisterRuntimeType(typeof(EverestOriginalTriggerSpikesState),
                "Celeste.Mod.Entities.TriggerSpikesOriginal");
            catalog.SelectLogicalActualType(typeof(EverestOriginalTriggerSpikesState),
                "Celeste.Mod.Entities.TriggerSpikesOriginal");
            catalog.RegisterRuntimeType(typeof(EverestOriginalTriggerSpikesState.SpikeInfo),
                "Celeste.Mod.Entities.TriggerSpikesOriginal.SpikeInfo");
            catalog.SelectLogicalActualType(typeof(EverestOriginalTriggerSpikesState.SpikeInfo),
                "Celeste.Mod.Entities.TriggerSpikesOriginal+SpikeInfo");
            catalog.RegisterRuntimeType(typeof(EverestOriginalTriggerSpikesState.Directions),
                "Celeste.Mod.Entities.TriggerSpikesOriginal.Directions");
            catalog.SelectLogicalActualType(typeof(EverestOriginalTriggerSpikesState.Directions),
                "Celeste.Mod.Entities.TriggerSpikesOriginal+Directions");
        }
    }
}
