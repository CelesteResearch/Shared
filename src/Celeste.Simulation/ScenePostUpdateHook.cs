using System;
using Celeste.Core.Components;

namespace Celeste.Simulation
{
    public sealed class ScenePostUpdateHook : SourceComponentState
    {
        public Action OnPostUpdate;

        public ScenePostUpdateHook(Action onPostUpdate) : base(false, false)
        {
            OnPostUpdate = onPostUpdate;
        }
    }
}
