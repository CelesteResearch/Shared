using System;

namespace Celeste.Simulation.Runtime.Components.Tweening
{
    // All VertexLight factory tweens use TweenMode.Persist and start=false.
    public sealed class VertexLightTween
    {
        public float Duration { get; private set; }
        public float TimeLeft { get; private set; }
        public float Percent { get; private set; }
        public float Eased { get; private set; }
        public bool Reverse { get; private set; }
        public bool Active { get; private set; }
        public bool UseRawDeltaTime;
        public Func<float, float> Easer;

        public Action<VertexLightTween> OnUpdate,
            OnComplete,
            OnStart;

        public VertexLightTween(float duration, Func<float, float> easer,
            Action<VertexLightTween> update)
        {
            Duration = duration <= 0 ? .000001f : duration;
            Easer = easer;
            OnUpdate = update;
        }

        public void Start(bool reverse = false)
        {
            Reverse = reverse;
            Reset();
            Active = true;
            OnStart?.Invoke(this);
        }

        public void Start(float duration, bool reverse = false)
        {
            Duration = duration;
            Start(reverse);
        }

        public void Stop()
        {
            Active = false;
        }

        public void Reset()
        {
            TimeLeft = Duration;
            Percent = Eased = Reverse ? 1 : 0;
        }

        public void Update(float dt, float rawDeltaTime)
        {
            TimeLeft -= UseRawDeltaTime ? rawDeltaTime : dt;
            Percent = Math.Max(0, TimeLeft) / Duration;
            if (!Reverse) Percent = 1 - Percent;
            Eased = Easer?.Invoke(Percent) ?? Percent;
            OnUpdate?.Invoke(this);
            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                OnComplete?.Invoke(this);
                Active = false;
            }
        }
    }
}
