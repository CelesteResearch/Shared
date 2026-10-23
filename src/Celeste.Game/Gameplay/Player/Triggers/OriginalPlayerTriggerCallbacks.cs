using System;
using Celeste.Scene.Triggers;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Player.Triggers
{
    public static class OriginalPlayerTriggerCallbacks
    {
        // These original overrides omit Trigger.OnEnter. The once-event policy
        // remains in the existing original story router supplied by the owner.
        public static PlayerTriggerCallbacks<RoomPlayerSession> Event(object actualIdentity,
            Func<RoomPlayerSession, bool> collide, Func<bool> readCollisionTriggered,
            Action<bool> writeCollisionTriggered, Action<RoomPlayerSession> enterOriginalEvent,
            Action leaveInherited)
        {
            return new(actualIdentity, collide,
                readCollisionTriggered, writeCollisionTriggered, enterOriginalEvent, null,
                player => leaveInherited());
        }

        public static PlayerTriggerCallbacks<RoomPlayerSession> Credits(object actualIdentity,
            Func<RoomPlayerSession, bool> collide, Func<bool> readTriggered,
            Action<bool> writeTriggered, Action publishRunningChapterEvent)
        {
            return new(actualIdentity, collide,
                readTriggered, writeTriggered,
                player =>
                {
                    writeTriggered(true);
                    publishRunningChapterEvent();
                }, null, null);
        }
    }
}
