using Celeste.Game.Entities.Triggers.Events;
using Celeste.Simulation;

namespace Celeste.Everest.Entities.Triggers.Events
{
    public sealed class EverestEventTriggerEvents
    {
        public delegate bool TriggerEventHandler(OriginalEventTriggerState trigger, RoomPlayerSession player,
            string eventID);

        public event TriggerEventHandler OnEventTrigger;

        public bool TriggerEvent(OriginalEventTriggerState trigger, RoomPlayerSession player, string eventID)
        {
            var handlers = OnEventTrigger;
            if (handlers == null) return false;
            foreach (TriggerEventHandler handler in handlers.GetInvocationList())
                if (handler(trigger, player, eventID))
                    return true;
            return false;
        }
    }
}
