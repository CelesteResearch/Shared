using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Dust
{
    public class OriginalDustRotateSpinnerState : OriginalRotateSpinnerState
    {
        private readonly DustGraphicState _dusty;

        public OriginalDustRotateSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
            OwnedComponents.Add(_dusty = new(engine, true));
        }

        public override void Update()
        {
            base.Update();
            if (Moving)
            {
                _dusty.EyeDirection = _dusty.EyeTargetDirection = Vector2Geometry.AngleToVector(
                    Angle + (float)Math.PI / 2f * (Clockwise ? 1 : -1), 1f);
                var level = (OriginalLevelSceneRoot)Scene;
                if (level.Clock.OnInterval(.02f, Engine))
                    level.ParticlesBG.Emit(((IOriginalGameplayProcess)Engine).ParticleTypes.DustStaticSpinner.P_Move,
                        1, Position, Vector2.One * 4f);
            }
        }

        public override void OnPlayer(RoomPlayerSession player)
        {
            base.OnPlayer(player);
            _dusty.OnHitPlayer();
        }
    }
}
