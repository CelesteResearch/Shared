using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Credits.Triggers
{
    public sealed class CreditsTriggerState : SourceTriggerEntityState
    {
        public string Event;

        public CreditsTriggerState(Vector2 position, float width, float height, string eventName,
            ISourceEngineContext engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position, width, height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            Event = eventName;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            // The original override does not call Trigger.OnEnter.
            Triggered = true;
            var process = ((IOriginalCreditsProcessEnvironment)
                ((ISourceEngineContextScene)Scene).EngineContext).CreditsProcess;
            if (process.Instance != null)
                process.Instance.Event = Event;
        }
    }
}
