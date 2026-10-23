using System;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    // Original Monocle.Wiggler (Monocle/Wiggler.cs:6-133): Counter starts at 1 and
    // Value = Cos(sineCounter) * Counter, with Counter decremented before the cosine.
    public sealed class CassetteWiggler
    {
        public bool StartZero, UseRawDeltaTime, Active, Visible;
        public float Counter { get; private set; }
        public float Value { get; private set; }
        public Action<float> OnChange;
        private float sineCounter;
        private readonly float increment;
        private readonly float sineAdd;

        public CassetteWiggler(float duration, float frequency, Action<float> onChange)
        {
            increment = 1f / duration;
            sineAdd = (float)Math.PI * 2f * frequency;
            OnChange = onChange;
        }

        public void Start()
        {
            Counter = 1f;
            if (StartZero)
            {
                sineCounter = (float)Math.PI / 2f;
                Value = 0f;
                OnChange?.Invoke(0f);
            }
            else
            {
                sineCounter = 0f;
                Value = 1f;
                OnChange?.Invoke(1f);
            }

            Active = true;
        }

        public void Update(float dt, float rawDt)
        {
            if (UseRawDeltaTime)
            {
                sineCounter += sineAdd * rawDt;
                Counter -= increment * rawDt;
            }
            else
            {
                sineCounter += sineAdd * dt;
                Counter -= increment * dt;
            }

            if (Counter <= 0f)
            {
                Counter = 0f;
                Active = false;
            }

            Value = (float)Math.Cos(sineCounter) * Counter;
            OnChange?.Invoke(Value);
        }
    }
}
