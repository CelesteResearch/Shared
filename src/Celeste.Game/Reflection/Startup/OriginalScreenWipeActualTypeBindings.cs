using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalScreenWipeActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(ScreenWipePresentation), "Celeste.ScreenWipe");
            catalog.RegisterRuntimeType(typeof(AngledWipePresentation), "Celeste.AngledWipe");
            catalog.RegisterRuntimeType(typeof(CurtainWipePresentation), "Celeste.CurtainWipe");
            catalog.RegisterRuntimeType(typeof(DreamWipePresentation), "Celeste.DreamWipe");
            catalog.RegisterRuntimeType(typeof(DropWipePresentation), "Celeste.DropWipe");
            catalog.RegisterRuntimeType(typeof(FadeWipePresentation), "Celeste.FadeWipe");
            catalog.RegisterRuntimeType(typeof(FallWipePresentation), "Celeste.FallWipe");
            catalog.RegisterRuntimeType(typeof(HeartWipePresentation), "Celeste.HeartWipe");
            catalog.RegisterRuntimeType(typeof(KeyDoorWipePresentation), "Celeste.KeyDoorWipe");
            catalog.RegisterRuntimeType(typeof(MountainWipePresentation), "Celeste.MountainWipe");
            catalog.RegisterRuntimeType(typeof(SpotlightWipePresentation), "Celeste.SpotlightWipe");
            catalog.RegisterRuntimeType(typeof(StarfieldWipePresentation), "Celeste.StarfieldWipe");
            catalog.RegisterRuntimeType(typeof(WindWipePresentation), "Celeste.WindWipe");
        }
    }
}
