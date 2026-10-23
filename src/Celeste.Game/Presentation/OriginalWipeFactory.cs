using System;
using Celeste.Game.Chapters;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Presentation
{
    public static class OriginalWipeFactory
    {
        public static ScreenWipePresentation CreateForMap(
            string mapPackage, ISourceRendererScene scene, bool wipeIn,
            Action onComplete = null)
        {
            // Validate exact vanilla package names before selecting AreaData.Wipe shared by every side.
            OriginalInventoryFactory.CreateForMap(mapPackage);
            if (mapPackage == "LostLevels")
                return new StarfieldWipePresentation(scene,
                    wipeIn, onComplete);
            switch (mapPackage[0])
            {
                case '0':
                case '8':
                    return new CurtainWipePresentation(scene,
                        wipeIn, onComplete);
                case '1':
                    return new AngledWipePresentation(scene,
                        wipeIn, onComplete);
                case '2':
                    return new DreamWipePresentation(scene,
                        wipeIn, onComplete);
                case '3':
                    return new KeyDoorWipePresentation(scene,
                        wipeIn, onComplete);
                case '4':
                    return new WindWipePresentation(scene,
                        wipeIn, onComplete);
                case '5':
                    return new DropWipePresentation(scene,
                        wipeIn, onComplete);
                case '6':
                    return new FallWipePresentation(scene,
                        wipeIn, onComplete);
                case '7':
                    return new MountainWipePresentation(scene,
                        wipeIn, onComplete);
                case '9':
                    return new HeartWipePresentation(scene,
                        wipeIn, onComplete);
                default: throw new ArgumentException("Unknown original wipe chapter.", nameof(mapPackage));
            }
        }
    }
}
