using System;

namespace Celeste.Core.Components.Timing
{
    public sealed class SourceAlarmState : SourceComponentState
    {
        public enum AlarmMode
        {
            Persist,
            Oneshot,
            Looping,
        }

        internal SourceAlarmPool Pool { get; }

        public Action OnComplete;
        public AlarmMode Mode { get; private set; }
        public float Duration { get; private set; }
        public float TimeLeft { get; private set; }

        internal SourceAlarmState(SourceAlarmPool pool) : base(false, false)
        {
            Pool = pool;
        }

        public static SourceAlarmState Create(SourceAlarmPool pool, AlarmMode mode,
            Action onComplete, float duration = 1f, bool start = false)
        {
            var alarm = pool.Acquire();
            alarm.Init(mode, onComplete, duration, start);
            return alarm;
        }

        public static SourceAlarmState Set(SourceAlarmPool pool, SourceOwnedComponentList components,
            float duration, Action onComplete, AlarmMode mode = AlarmMode.Oneshot)
        {
            var alarm = Create(pool, mode, onComplete, duration, true);
            components.Add(alarm);
            return alarm;
        }

        private void Init(AlarmMode mode, Action onComplete, float duration = 1f, bool start = false)
        {
            Mode = mode;
            Duration = duration;
            OnComplete = onComplete;
            Active = false;
            TimeLeft = 0f;
            if (start) Start();
        }

        public override void Update()
        {
            TimeLeft -= Pool.EngineContext.DeltaTime;
            if (TimeLeft <= 0f)
            {
                TimeLeft = 0f;
                if (OnComplete != null) OnComplete();
                if (Mode == AlarmMode.Looping) Start();
                else if (Mode == AlarmMode.Oneshot) RemoveSelf();
                else if (TimeLeft <= 0f) Active = false;
            }
        }

        public override void Removed(object entity)
        {
            base.Removed(entity);
            Pool.Cache(this);
        }

        public void Start()
        {
            Active = true;
            TimeLeft = Duration;
        }

        public void Start(float duration)
        {
            Duration = duration;
            Start();
        }

        public void Stop()
        {
            Active = false;
        }
    }
}
