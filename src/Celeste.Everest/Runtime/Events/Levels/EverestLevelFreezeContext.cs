using Celeste.Scene.Scheduling;
using System;
using Celeste.Simulation;
using Celeste.Everest;

namespace Celeste.Everest.Runtime.Events.Levels
{
    // Engine-independent equivalent of Everest.Events.Level's freeze-frame pair.
    public sealed class EverestLevelFreezeContext
    {
        private readonly Func<float> readFreeze;
        private readonly Action<float> writeFreeze;
        public object NativeLevel { get; }
        public SceneUpdateScheduler Entities { get; }
        public bool Paused { get; }
        public bool Frozen { get; }
        public bool Transitioning { get; }
        public float RawDeltaTime { get; }
        public float DeltaTime { get; }

        public float FreezeTimer
        {
            get => readFreeze();
            set => writeFreeze(value);
        }

        public EverestLevelFreezeContext(object nativeLevel, SceneUpdateScheduler entities,
            Func<float> readFreeze, Action<float> writeFreeze, bool paused, bool frozen,
            bool transitioning, float rawDeltaTime, float deltaTime)
        {
            NativeLevel = nativeLevel;
            Entities = entities ?? throw new ArgumentNullException(nameof(entities));
            this.readFreeze = readFreeze ?? throw new ArgumentNullException(nameof(readFreeze));
            this.writeFreeze = writeFreeze ?? throw new ArgumentNullException(nameof(writeFreeze));
            Paused = paused;
            Frozen = frozen;
            Transitioning = transitioning;
            RawDeltaTime = rawDeltaTime;
            DeltaTime = deltaTime;
        }
    }
}
