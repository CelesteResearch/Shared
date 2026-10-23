using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Entities;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalBreathingRumblerState : SceneEntityState
    {
        private const float MaxRumble = 0.25f;
        public float Strength = 0.2f;
        private float currentRumble;
        private readonly ISourceEngineContext engine;

        public OriginalBreathingRumblerState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            currentRumble = Strength;
        }

        public override void Update()
        {
            base.Update();
            currentRumble = ScalarMath.Approach(currentRumble, Strength, 2f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (currentRumble > 0f)
                ((ISourceRumbleEnvironment)engine).RumbleSession.RumbleSpecific(currentRumble * 0.25f, 0.05f);
        }
    }
}
