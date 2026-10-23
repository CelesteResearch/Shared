using System;

namespace Celeste.Game.Presentation
{
    public static class OriginalWipeFactory
    {
        public static global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation CreateForMap(
            string mapPackage, global::Celeste.Scene.Rendering.ISourceRendererScene scene, bool wipeIn,
            Action onComplete = null)
        {
            // Validate exact vanilla package names before selecting AreaData.Wipe shared by every side.
            global::Celeste.Game.Chapters.OriginalInventoryFactory.CreateForMap(mapPackage);
            if (mapPackage == "LostLevels")
                return new global::Celeste.Simulation.Presentation.Scene.Transitions.StarfieldWipePresentation(scene,
                    wipeIn, onComplete);
            switch (mapPackage[0])
            {
                case '0':
                case '8':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.CurtainWipePresentation(scene,
                        wipeIn, onComplete);
                case '1':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.AngledWipePresentation(scene,
                        wipeIn, onComplete);
                case '2':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.DreamWipePresentation(scene,
                        wipeIn, onComplete);
                case '3':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.KeyDoorWipePresentation(scene,
                        wipeIn, onComplete);
                case '4':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.WindWipePresentation(scene,
                        wipeIn, onComplete);
                case '5':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.DropWipePresentation(scene,
                        wipeIn, onComplete);
                case '6':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.FallWipePresentation(scene,
                        wipeIn, onComplete);
                case '7':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.MountainWipePresentation(scene,
                        wipeIn, onComplete);
                case '9':
                    return new global::Celeste.Simulation.Presentation.Scene.Transitions.HeartWipePresentation(scene,
                        wipeIn, onComplete);
                default: throw new ArgumentException("Unknown original wipe chapter.", nameof(mapPackage));
            }
        }
    }
}
