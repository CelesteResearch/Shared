using Celeste.Simulation;

namespace Celeste.Game.Entities.Triggers.Events
{
    public interface IOriginalEventTriggerRuntimePolicy
    {
        bool TriggerCustomEvent(OriginalEventTriggerState trigger, RoomPlayerSession player, string eventId);
    }
}
