using System;
using Celeste.Core.Components;

namespace Celeste.Scene.Lifecycle
{
    public class LevelEndingHookState : SourceComponentState, ILevelEndingCallback
    {
        public Action OnEnd;
        Action ILevelEndingCallback.OnEnd => OnEnd;
        public LevelEndingHookState(Action onEnd) : base(false, false) => OnEnd = onEnd;
    }
}
