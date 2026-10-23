using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Components.Oscillation
{
    public class ShakerListComponent : SourceComponentState
    {
        public Vector2[] Values;
        public float Interval = .05f;
        public float Timer;
        public bool RemoveOnFinish;
        public Action<Vector2[]> OnShake;
        private bool on;
        private readonly ISourceEngineContext engine;

        public bool On
        {
            get => on;
            set
            {
                on = value;
                if (on) return;
                Timer = 0f;
                if (Values[0] != Vector2.Zero)
                {
                    for (var i = 0; i < Values.Length; i++) Values[i] = Vector2.Zero;
                    if (OnShake != null) OnShake(Values);
                }
            }
        }

        public ShakerListComponent(int length, ISourceEngineContext engine,
            bool on = true, Action<Vector2[]> onShake = null)
            : base(true, false)
        {
            this.engine = engine;
            Values = new Vector2[length];
            this.on = on;
            OnShake = onShake;
        }

        public ShakerListComponent(int length, float time, bool removeOnFinish,
            ISourceEngineContext engine, Action<Vector2[]> onShake = null)
            : this(length, engine, true, onShake)
        {
            Timer = time;
            RemoveOnFinish = removeOnFinish;
        }

        public ShakerListComponent ShakeFor(float seconds, bool removeOnFinish)
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
                    for (var i = 0; i < Values.Length; i++) Values[i] = Vector2.Zero;
                    if (OnShake != null) OnShake(Values);
                    if (RemoveOnFinish) RemoveSelf();
                    return;
                }
            }

            if (on)
            {
                var time = ((ISourceScene)Scene).SourceScene.Clock.TimeActive;
                if ((int)((time - engine.DeltaTime) / Interval) < (int)(time / Interval))
                {
                    for (var i = 0; i < Values.Length; i++)
                        Values[i] = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
                    if (OnShake != null) OnShake(Values);
                }
            }
        }
    }
}
