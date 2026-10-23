using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using JetBrains.Annotations;

namespace Celeste.Core.Components.Animation
{
    public sealed class SourceTweenState : SourceComponentState
    {
        public enum TweenMode
        {
            Persist,
            Oneshot,
            Looping,
            YoyoOneshot,
            YoyoLooping,
        }

        public Func<float, float> Easer;
        public Action<SourceTweenState> OnUpdate, OnComplete, OnStart;
        public bool UseRawDeltaTime;
        private bool _startedReversed;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private ulong cachedFrame;

        internal ulong CachedFrame
        {
            get => cachedFrame;
            set => cachedFrame = value;
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly SourceTweenPool pool;

        internal SourceTweenPool Pool => pool;
        public TweenMode Mode { get; private set; }
        public float Duration { get; private set; }
        public float TimeLeft { get; private set; }
        public float Percent { get; private set; }
        public float Eased { get; private set; }
        public bool Reverse { get; private set; }
        public float Inverted => 1f - Eased;

        internal SourceTweenState(SourceTweenPool pool) : base(false, false)
        {
            this.pool = pool;
        }

        public static SourceTweenState Create(SourceTweenPool pool, TweenMode mode,
            Func<float, float> easer = null, float duration = 1f, bool start = false)
        {
            var tween = pool.Acquire();
            tween.OnUpdate = tween.OnComplete = tween.OnStart = null;
            tween.Init(mode, easer, duration, start);
            return tween;
        }

        public static SourceTweenState Set(SourceTweenPool pool, SourceOwnedComponentList components,
            TweenMode mode, float duration, Func<float, float> easer,
            Action<SourceTweenState> onUpdate, Action<SourceTweenState> onComplete = null)
        {
            var tween = Create(pool, mode, easer, duration, true);
            tween.OnUpdate = (Action<SourceTweenState>)Delegate.Combine(tween.OnUpdate, onUpdate);
            tween.OnComplete = (Action<SourceTweenState>)Delegate.Combine(tween.OnComplete, onComplete);
            components.Add(tween);
            return tween;
        }

        public static SourceTweenState Position(SourceTweenPool pool, ISourceMutableEntityPosition entity,
            Vector2 targetPosition, float duration, Func<float, float> easer,
            ISourceScalarArithmetic arithmetic,
            TweenMode mode = TweenMode.Oneshot)
        {
            var startPosition = entity.Position;
            var tween = Create(pool, mode, easer, duration, true);
            tween.OnUpdate = t => entity.Position = Vector2Interpolation.Lerp(
                startPosition, targetPosition, t.Eased, arithmetic);
            ((ISourceOwnedComponentList)entity).OwnedComponents.Add(tween);
            return tween;
        }

        private void Init(TweenMode mode, Func<float, float> easer, float duration, bool start)
        {
            if (duration <= 0f) duration = 1E-06f;
            UseRawDeltaTime = false;
            Mode = mode;
            Easer = easer;
            Duration = duration;
            TimeLeft = 0f;
            Percent = 0f;
            Active = false;
            if (start) Start();
        }

        public override void Removed(object entity)
        {
            base.Removed(entity);
            pool.Cache(this);
        }

        public override void Update()
        {
            TimeLeft -= UseRawDeltaTime ? pool.EngineContext.RawDeltaTime : pool.EngineContext.DeltaTime;
            Percent = pool.ExtremaArithmetic.Max(0f, TimeLeft) / Duration;
            if (!Reverse) Percent = 1f - Percent;
            Eased = Easer != null ? Easer(Percent) : Percent;
            if (OnUpdate != null) OnUpdate(this);
            if (!(TimeLeft <= 0f)) return;
            TimeLeft = 0f;
            if (OnComplete != null) OnComplete(this);
            switch (Mode)
            {
                case TweenMode.Persist: Active = false; break;
                case TweenMode.Oneshot:
                    Active = false;
                    RemoveSelf();
                    break;
                case TweenMode.Looping: Start(Reverse); break;
                case TweenMode.YoyoOneshot:
                    if (Reverse == _startedReversed)
                    {
                        Start(!Reverse);
                        _startedReversed = !Reverse;
                    }
                    else
                    {
                        Active = false;
                        RemoveSelf();
                    }

                    break;
                case TweenMode.YoyoLooping: Start(!Reverse); break;
            }
        }

        public void Start()
        {
            Start(false);
        }

        public void Start(bool reverse)
        {
            var flag = Reverse = reverse;
            _startedReversed = flag;
            TimeLeft = Duration;
            var eased = Percent = Reverse ? 1 : 0;
            Eased = eased;
            Active = true;
            if (OnStart != null) OnStart(this);
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
            var eased = Percent = Reverse ? 1 : 0;
            Eased = eased;
        }

        public IEnumerator Wait()
        {
            while (Active) yield return null;
        }
    }
}
