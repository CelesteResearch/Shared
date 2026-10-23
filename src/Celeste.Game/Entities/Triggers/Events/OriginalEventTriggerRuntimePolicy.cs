using Celeste.Simulation;

namespace Celeste.Game.Entities.Triggers.Events
{
    public sealed class OriginalEventTriggerRuntimePolicy : IOriginalEventTriggerRuntimePolicy
    {
        // The original executable has no installed custom-event hook.
        public bool TriggerCustomEvent(OriginalEventTriggerState trigger, RoomPlayerSession player, string eventId)
        {
            return false;
        }
    }
}
