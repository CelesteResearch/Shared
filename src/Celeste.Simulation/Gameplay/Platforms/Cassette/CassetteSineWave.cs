using System;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    // Original Monocle.SineWave (Monocle/SineWave.cs:5-84). Counter is the only stored
    // value; Value/ValueOverTwo/TwoValue are recomputed by the Counter setter, and
    // Update advances Counter and then raises OnUpdate with the new Value.
    public sealed class CassetteSineWave
    {
        public bool Active = true, Visible;
        public float Frequency = 1f;
        public float Rate = 1f;
        public bool UseRawDeltaTime;
        public Action<float> OnUpdate;
        private float counter;
        public float Value { get; private set; }
        public float ValueOverTwo { get; private set; }
        public float TwoValue { get; private set; }

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

        public CassetteSineWave(float frequency, float offset = 0f)
        {
            Frequency = frequency;
            Counter = offset;
        }

        public void Update(float dt, float rawDt)
        {
            Counter += (float)Math.PI * 2f * Frequency * Rate * (UseRawDeltaTime ? rawDt : dt);
            OnUpdate?.Invoke(Value);
        }
    }
}
