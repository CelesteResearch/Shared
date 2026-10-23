using System;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Presentation.PostProcessing.Glitch
{
    // Level.Update owns this clock. Hosts call Advance once per unpaused Level
    // update, even when the glitch effect is visually disabled or Value is zero.
    public sealed class LevelGlitchState
    {
        private readonly SourceEngineEffectsState effects;

        public float Value
        {
            get => effects.Glitch;
            set => effects.Glitch = value;
        }

        public LevelGlitchState(SourceEngineEffectsState effects)
        {
            this.effects = effects ?? throw new ArgumentNullException(nameof(effects));
        }

        public float Timer { get; private set; }
        public float Seed { get; private set; }

        public void Advance(float deltaTime, ISourceRandom random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            Timer += deltaTime;
            Seed = (float)random.NextDouble(); // Monocle.Calc.NextFloat
        }

        public void ResetValue()
        {
            Value = 0f;
            // Level.Reload
        }
    }
}
