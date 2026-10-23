using System;
using Celeste.Simulation;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Events.Player
{
    public static class EverestPlayerSourceEvents
    {
        private static Action<RoomPlayerSession> beforeUpdate, afterUpdate, spawn, die, registerStates;

        public static event Action<RoomPlayerSession> OnBeforeUpdate
        {
            add
            {
                beforeUpdate += value;
                EverestModuleLifetime.Track(() => beforeUpdate -= value);
            }
            remove { beforeUpdate -= value; }
        }

        public static event Action<RoomPlayerSession> OnAfterUpdate
        {
            add
            {
                afterUpdate += value;
                EverestModuleLifetime.Track(() => afterUpdate -= value);
            }
            remove { afterUpdate -= value; }
        }

        public static event Action<RoomPlayerSession> OnSpawn
        {
            add
            {
                spawn += value;
                EverestModuleLifetime.Track(() => spawn -= value);
            }
            remove { spawn -= value; }
        }

        public static event Action<RoomPlayerSession> OnDie
        {
            add
            {
                die += value;
                EverestModuleLifetime.Track(() => die -= value);
            }
            remove { die -= value; }
        }

        public static event Action<RoomPlayerSession> OnRegisterStates
        {
            add
            {
                registerStates += value;
                EverestModuleLifetime.Track(() => registerStates -= value);
            }
            remove { registerStates -= value; }
        }

        public static void RegisterStates(RoomPlayerSession player) => registerStates?.Invoke(player);
        public static void BeforeUpdate(RoomPlayerSession player) => beforeUpdate?.Invoke(player);
        public static void AfterUpdate(RoomPlayerSession player) => afterUpdate?.Invoke(player);
        public static void Spawn(RoomPlayerSession player) => spawn?.Invoke(player);
        public static void Die(RoomPlayerSession player) => die?.Invoke(player);
    }
}
