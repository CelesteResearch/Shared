using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Scene.Components.Oscillation
{
    public class SineWaveState : global::Celeste.Core.Components.SourceComponentState
    {
        private float counter;
        public float Frequency = 1, Rate = 1;
        public bool UseRawDeltaTime;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        private global::Celeste.Core.Mathematics.ISourceSineWaveArithmetic arithmetic =>
            ((global::Celeste.Core.Mathematics.ISourceSineWaveEnvironment)engine).SineWaveArithmetic;

        public Action<float> OnUpdate;
        public float Value { get; private set; }
        public float ValueOverTwo { get; private set; }

        public float TwoValue { get; private set; }

        // Counter rounding follows the selected process source arithmetic.
        public float Counter
        {
            get => counter;
            set
            {
                counter = arithmetic.WrapCounter(value);
                Value = (float)Math.Sin(counter);
                ValueOverTwo = (float)Math.Sin(counter / 2f);
                TwoValue = (float)Math.Sin(counter * 2f);
            }
        }

        public SineWaveState(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(true, false)
        {
            this.engine = engine;
        }

        public SineWaveState(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            float frequency, float offset = 0f) : this(engine)
        {
            Frequency = frequency;
            Counter = offset;
        }

        public override void Update()
        {
            Counter = arithmetic.AdvanceCounter(counter, Frequency, Rate,
                UseRawDeltaTime ? engine.RawDeltaTime : engine.DeltaTime);
            OnUpdate?.Invoke(Value);
        }

        public float ValueOffset(float offset) => (float)Math.Sin(counter + offset);
        public void Reset() => Counter = 0;
        public void StartUp() => Counter = (float)Math.PI / 2f;
        public void StartDown() => Counter = 4.712389f;

        public SineWaveState Randomize()
        {
            Counter = arithmetic.RandomCounter((float)((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine)
                .Random.NextDouble());
            return this;
        }
    }
}
