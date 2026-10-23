using System;

namespace Celeste.Scene.Components.Oscillation
{
    public class WigglerComponent : OscillationPulseState
    {
        private readonly WigglerComponentPool pool;
        private bool removeSelfOnFinish;

        internal WigglerComponent(WigglerComponentPool pool) : base(pool.EngineContext)
        {
            this.pool = pool;
        }

        public static WigglerComponent Create(WigglerComponentPool pool, float duration, float frequency,
            Action<float> onChange = null, bool start = false, bool removeSelfOnFinish = false)
            => pool.Create(duration, frequency, onChange, start, removeSelfOnFinish);

        internal void Init(float duration, float frequency, Action<float> onChange, bool start, bool removeOnFinish)
        {
            Counter = SineCounter = 0f;
            UseRawDeltaTime = false;
            Increment = 1f / duration;
            SineAdd = (float)Math.PI * 2f * frequency;
            OnChange = onChange;
            removeSelfOnFinish = removeOnFinish;
            if (start) Start();
            else Active = false;
        }

        public override void Removed(object entity)
        {
            base.Removed(entity);
            pool.Return(this);
        }

        public override void Update()
        {
            if (AdvanceWithoutActiveGate() && removeSelfOnFinish) RemoveSelf();
            PublishValue();
        }

        public void AddTo(global::Celeste.Core.Components.SourceOwnedComponentList components)
            => components.Add(this);
    }
}
