using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Scene.Components.Oscillation
{
    public class OscillationPulseState : global::Celeste.Core.Components.SourceComponentState
    {
        protected readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public bool StartZero, UseRawDeltaTime;
        public float Counter, Value, SineCounter, Increment, SineAdd;
        public Action<float> OnChange;

        protected OscillationPulseState(global::Celeste.Core.Scheduling.ISourceEngineContext engine) : base(false,
            false)
        {
            this.engine = engine;
        }

        public OscillationPulseState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, float duration,
            float frequency, Action<float> onChange) : this(engine)
        {
            Increment = 1f / duration;
            SineAdd = (float)Math.PI * 2f * frequency;
            OnChange = onChange;
        }

        public void Start()
        {
            Counter = 1f;
            if (StartZero)
            {
                SineCounter = (float)Math.PI / 2f;
                Value = 0f;
                if (OnChange != null) OnChange(0f);
            }
            else
            {
                SineCounter = 0f;
                Value = 1f;
                if (OnChange != null) OnChange(1f);
            }

            Active = true;
        }

        public void Start(float duration, float frequency)
        {
            Increment = 1f / duration;
            SineAdd = (float)Math.PI * 2f * frequency;
            Start();
        }

        public void Stop() => Active = false;

        public void StopAndClear()
        {
            Stop();
            Value = 0;
        }

        public override void Update()
        {
            AdvanceWithoutActiveGate();
            PublishValue();
        }

        // ComponentList dispatch checks Active. A direct component Update does not.
        // The completion hook belongs between the counter clamp and value publication.
        protected bool AdvanceWithoutActiveGate()
        {
            if (UseRawDeltaTime)
            {
                SineCounter += SineAdd * engine.RawDeltaTime;
                Counter -= Increment * engine.RawDeltaTime;
            }
            else
            {
                SineCounter += SineAdd * engine.DeltaTime;
                Counter -= Increment * engine.DeltaTime;
            }

            if (Counter <= 0)
            {
                Counter = 0;
                Active = false;
                return true;
            }

            return false;
        }

        protected void PublishValue()
        {
            Value = (float)Math.Cos(SineCounter) * Counter;
            if (OnChange != null) OnChange(Value);
        }
    }
}
