using System;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.Levels.Hooks
{
    public sealed class OriginalLevelLifecycleSourceHooks
    {
        public event Action<OriginalLevelSceneRoot> AfterUpdate;
        public event Action<OriginalLevelSceneRoot> AfterBegin;
        public event Action<OriginalLevelSceneRoot> AfterEnd;
        public event Action<OriginalLevelSceneRoot> AfterLoadLevel;
        public event Action<OriginalLevelSceneRoot> AfterUpdateTime;
        public void InvokeAfterUpdate(OriginalLevelSceneRoot level) => AfterUpdate?.Invoke(level);
        public void InvokeAfterBegin(OriginalLevelSceneRoot level) => AfterBegin?.Invoke(level);
        public void InvokeAfterEnd(OriginalLevelSceneRoot level) => AfterEnd?.Invoke(level);
        public void InvokeAfterLoadLevel(OriginalLevelSceneRoot level) => AfterLoadLevel?.Invoke(level);
        public void InvokeAfterUpdateTime(OriginalLevelSceneRoot level) => AfterUpdateTime?.Invoke(level);
    }
}
