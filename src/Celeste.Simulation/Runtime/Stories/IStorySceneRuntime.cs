using System;
using System.Collections.Generic;
using Celeste.Scene.Scheduling;

namespace Celeste.Simulation.Runtime.Stories
{
    public interface IStorySceneRuntime
    {
        SceneUpdateScheduler SceneScheduler { get; }
        IList<Action> DeferredEntityAdds { get; }
    }
}
