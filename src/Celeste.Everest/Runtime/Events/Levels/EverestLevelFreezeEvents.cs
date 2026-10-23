using System;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Events.Levels
{
    public static class EverestLevelFreezeEvents
    {
        private static Action<EverestLevelFreezeContext>
            onBeforeFreezeFrameUpdate;

        private static Action<EverestLevelFreezeContext>
            onAfterFreezeFrameUpdate;

        public static bool HasBeforeFreezeFrameUpdateListeners => onBeforeFreezeFrameUpdate != null;
        public static bool HasAfterFreezeFrameUpdateListeners => onAfterFreezeFrameUpdate != null;

        public static event Action<EverestLevelFreezeContext>
            OnBeforeFreezeFrameUpdate
            {
                add
                {
                    onBeforeFreezeFrameUpdate += value;
                    EverestModuleLifetime.Track(() =>
                        onBeforeFreezeFrameUpdate -= value);
                }
                remove => onBeforeFreezeFrameUpdate -= value;
            }

        public static event Action<EverestLevelFreezeContext>
            OnAfterFreezeFrameUpdate
            {
                add
                {
                    onAfterFreezeFrameUpdate += value;
                    EverestModuleLifetime.Track(() =>
                        onAfterFreezeFrameUpdate -= value);
                }
                remove => onAfterFreezeFrameUpdate -= value;
            }

        public static void BeforeFreezeFrameUpdate(
            EverestLevelFreezeContext context)
        {
            onBeforeFreezeFrameUpdate?.Invoke(context);
        }

        public static void AfterFreezeFrameUpdate(
            EverestLevelFreezeContext context)
        {
            onAfterFreezeFrameUpdate?.Invoke(context);
        }
    }
}
