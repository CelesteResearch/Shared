using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Runtime.Components.Oscillation
{
    // Monocle.SineWave with the members ForegroundDebris uses.
    public sealed class DebrisSineWave
    {
        public float Frequency = 1f;
        public float Rate = 1f;
        public bool UseRawDeltaTime;
        public Action<float> OnUpdate;
        public float Value { get; private set; }
        public float ValueOverTwo { get; private set; }
        public float TwoValue { get; private set; }
        private float counter;

        public DebrisSineWave()
        {
            Counter = 0f;
        }

        public DebrisSineWave(float frequency, float offset = 0f)
        {
            Frequency = frequency;
            Counter = offset;
        }

        public float Counter
        {
            get => counter;
            set
            {
                counter = (value + (float)Math.PI * 8f) % ((float)Math.PI * 8f);
                Value = (float)Math.Sin(counter);
                ValueOverTwo = (float)Math.Sin(counter / 2f);
                TwoValue = (float)Math.Sin(counter * 2f);
            }
        }

        public void Update(float deltaTime, float rawDeltaTime)
        {
            Counter += (float)Math.PI * 2f * Frequency * Rate * (UseRawDeltaTime ? rawDeltaTime : deltaTime);
            OnUpdate?.Invoke(Value);
        }

        public void Randomize(Random random) => Counter = (float)random.NextDouble() * ((float)Math.PI * 2f) * 2f;
        public void Reset() => Counter = 0f;
    }
}
