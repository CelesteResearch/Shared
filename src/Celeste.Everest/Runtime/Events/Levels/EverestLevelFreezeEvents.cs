using System;
using Celeste.Simulation;
using Celeste.Everest;

namespace Celeste.Everest.Runtime.Events.Levels
{
    public static class EverestLevelFreezeEvents
    {
        private static Action<global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext>
            onBeforeFreezeFrameUpdate;

        private static Action<global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext>
            onAfterFreezeFrameUpdate;

        public static bool HasBeforeFreezeFrameUpdateListeners => onBeforeFreezeFrameUpdate != null;
        public static bool HasAfterFreezeFrameUpdateListeners => onAfterFreezeFrameUpdate != null;

        public static event Action<global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext>
            OnBeforeFreezeFrameUpdate
            {
                add
                {
                    onBeforeFreezeFrameUpdate += value;
                    global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(() =>
                        onBeforeFreezeFrameUpdate -= value);
                }
                remove { onBeforeFreezeFrameUpdate -= value; }
            }

        public static event Action<global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext>
            OnAfterFreezeFrameUpdate
            {
                add
                {
                    onAfterFreezeFrameUpdate += value;
                    global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(() =>
                        onAfterFreezeFrameUpdate -= value);
                }
                remove { onAfterFreezeFrameUpdate -= value; }
            }

        public static void BeforeFreezeFrameUpdate(
            global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext context)
            => onBeforeFreezeFrameUpdate?.Invoke(context);

        public static void AfterFreezeFrameUpdate(
            global::Celeste.Everest.Runtime.Events.Levels.EverestLevelFreezeContext context)
            => onAfterFreezeFrameUpdate?.Invoke(context);
    }
}
