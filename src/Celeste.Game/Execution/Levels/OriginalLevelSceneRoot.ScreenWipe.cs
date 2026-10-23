using System;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void DoScreenWipe(bool wipeIn, Action onComplete = null, bool hiresSnow = false)
        {
            if (((IOriginalLevelLoadOverrideEnvironment)EngineContext)
                .LevelLoadOverrides.SkipWipe(this, onComplete, hiresSnow)) return;
            var area = AreaData;
            if (area.Wipe == null)
                _ = new WindWipePresentation(this, wipeIn, onComplete);
            else
                area.Wipe(this, wipeIn, onComplete);
            if (!hiresSnow)
                return;
            HiresSnow = new(EngineContext);
            Renderers.Add(HiresSnow);
            HiresSnow.Alpha = 0f;
            HiresSnow.AttachAlphaTo = Wipe;
        }
    }
}
