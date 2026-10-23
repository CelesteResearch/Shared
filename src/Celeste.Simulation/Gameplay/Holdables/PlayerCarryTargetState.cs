using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public sealed class PlayerCarryTargetState
    {
        private static readonly ConditionalWeakTable<ISourceEngineContext, PlayerCarryTargetState> owners = new();
        public Vector2 Value = PlayerHoldingController.CarryOffsetTarget;

        public static PlayerCarryTargetState For(ISourceEngineContext engine)
        {
            return owners.GetValue(engine, _ => new());
        }
    }
}
