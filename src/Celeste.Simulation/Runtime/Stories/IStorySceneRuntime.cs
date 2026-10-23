using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Runtime.Stories
{
    public interface IStorySceneRuntime
    {
        SceneUpdateScheduler SceneScheduler { get; }
        IList<Action> DeferredEntityAdds { get; }
    }
}
