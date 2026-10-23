using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Backdrops.Blackhole;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Backdrops
{
    public class OriginalBlackholeStrengthTriggerState : SourceTriggerEntityState
    {
        private readonly BlackholeBackdropPresentation.Strengths strength;

        public OriginalBlackholeStrengthTriggerState(ISourceEngineContext engine, EntityData data,
            Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            strength = EntityAttributeReader.Enum(data.Values, "strength",
                BlackholeBackdropPresentation.Strengths.Mild);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            (Scene as OriginalLevelSceneRoot).Background.Get<BlackholeBackdropPresentation>()
                ?.NextStrength(Scene as OriginalLevelSceneRoot, strength);
        }
    }
}
