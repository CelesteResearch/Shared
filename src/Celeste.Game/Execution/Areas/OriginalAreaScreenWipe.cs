using System;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaScreenWipe
    {
        public static void DoScreenWipe(IOriginalAreaData area, ISourceRendererScene scene,
            bool wipeIn, Action onComplete = null)
        {
            if (area.Wipe == null)
                new WindWipePresentation(scene, wipeIn, onComplete);
            else
                area.Wipe(scene, wipeIn, onComplete);
        }
    }
}
