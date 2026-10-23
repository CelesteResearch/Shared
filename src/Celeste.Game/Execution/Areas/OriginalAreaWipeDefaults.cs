using System;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaWipeDefaults
    {
        public static Action<ISourceRendererScene, bool, Action> Get(int areaId) => areaId switch
        {
            0 or 8 => static (scene, wipeIn, done) => _ = new CurtainWipePresentation(scene, wipeIn, done),
            1 => static (scene, wipeIn, done) => _ = new AngledWipePresentation(scene, wipeIn, done),
            2 => static (scene, wipeIn, done) => _ = new DreamWipePresentation(scene, wipeIn, done),
            3 => static (scene, wipeIn, done) => _ = new KeyDoorWipePresentation(scene, wipeIn, done),
            4 => static (scene, wipeIn, done) => _ = new WindWipePresentation(scene, wipeIn, done),
            5 => static (scene, wipeIn, done) => _ = new DropWipePresentation(scene, wipeIn, done),
            6 => static (scene, wipeIn, done) => _ = new FallWipePresentation(scene, wipeIn, done),
            7 => static (scene, wipeIn, done) => _ = new MountainWipePresentation(scene, wipeIn, done),
            9 => static (scene, wipeIn, done) => _ = new HeartWipePresentation(scene, wipeIn, done),
            10 => static (scene, wipeIn, done) => _ = new StarfieldWipePresentation(scene, wipeIn, done),
            _ => throw new ArgumentOutOfRangeException(nameof(areaId))
        };
    }
}
