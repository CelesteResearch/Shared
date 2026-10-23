using Celeste.Scene.Tracking;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public static class EverestWaterRuntimeTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(EverestWaterState), "Celeste.Water");
            catalog.RegisterRuntimeType(typeof(EverestWaterInteractionState), "Celeste.WaterInteraction");
        }
    }
}
