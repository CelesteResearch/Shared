using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Components.Shaking
{
    public class ShakerComponentState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        private bool on;
        public Vector2 Value;
        public float Interval = .05f;
        public float Timer;
        public bool RemoveOnFinish;
        public Action<Vector2> OnShake;

        public bool On
        {
            get => on;
            set
            {
                on = value;
                if (on) return;
                Timer = 0f;
                if (Value != Vector2.Zero)
                {
                    Value = Vector2.Zero;
                    OnShake?.Invoke(Vector2.Zero);
                }
            }
        }

        public ShakerComponentState(ISourceEngineContext engine,
            bool on = true, Action<Vector2> onShake = null)
            : base(true, false)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.on = on;
            OnShake = onShake;
        }

        public ShakerComponentState(ISourceEngineContext engine,
            float time, bool removeOnFinish, Action<Vector2> onShake = null)
            : this(engine, true, onShake)
        {
            Timer = time;
            RemoveOnFinish = removeOnFinish;
        }

        public ShakerComponentState ShakeFor(float seconds, bool removeOnFinish)
        {
            on = true;
            Timer = seconds;
            RemoveOnFinish = removeOnFinish;
            return this;
        }

        public override void Update()
        {
            if (on && Timer > 0f)
            {
                Timer -= engine.DeltaTime;
                if (Timer <= 0f)
                {
                    on = false;
                    Value = Vector2.Zero;
                    OnShake?.Invoke(Vector2.Zero);
                    if (RemoveOnFinish) RemoveSelf();
                    return;
                }
            }

            if (on && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(Interval, engine))
            {
                Value = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
                OnShake?.Invoke(Value);
            }
        }
    }
}
