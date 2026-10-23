using System;
using Celeste.Everest.Modules.Runtime;
using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Events.Player
{
    // patch_Player.OnPauseInGBJ: listeners run in registration order until
    // one returns true, which suppresses Everest's automatic pause.
    public static class EverestPlayerAntiSoftlockEvents
    {
        private static Func<RoomPlayerSession, bool> onPauseInGBJ;

        public static event Func<RoomPlayerSession, bool> OnPauseInGBJ
        {
            add
            {
                onPauseInGBJ += value;
                EverestModuleLifetime.Track(() => onPauseInGBJ -= value);
            }
            remove => onPauseInGBJ -= value;
        }

        public static bool PauseInGBJ(RoomPlayerSession player)
        {
            var handlers = onPauseInGBJ;
            if (handlers == null) return false;
            foreach (Func<RoomPlayerSession, bool> handler in handlers.GetInvocationList())
                if (handler(player))
                    return true;
            return false;
        }
    }
}
