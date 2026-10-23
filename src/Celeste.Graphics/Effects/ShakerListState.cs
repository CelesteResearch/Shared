using System;
using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Graphics.Effects
{
    public sealed class ShakerListState : ISourceComponentFields
    {
        private static readonly int[] offsets = [-1, -1, 0, 1, 1];
        private bool on;
        public Vector2[] Values;
        public float Interval = .05f, Timer;
        public bool RemoveOnFinish;
        public SourceComponentFields ComponentFields { get; } = new(true, false);

        public object Entity
        {
            get => ComponentFields.Entity;
            set => ComponentFields.SetRawEntity(value);
        }

        public object Scene => ComponentFields.Scene;

        public bool Active
        {
            get => ComponentFields.Active;
            set => ComponentFields.Active = value;
        }

        public bool Visible
        {
            get => ComponentFields.Visible;
            set => ComponentFields.Visible = value;
        }

        public Action<Vector2[]> OnShake;
        public Random Random;
        public bool Attached { get; private set; }

        public event Action<ShakerListState> RemovalRequested;

        public bool On
        {
            get => on;
            set
            {
                on = value;
                if (on)
                    return;
                Timer = 0;
                // Original tests only Values[0], even if later values are nonzero.
                if (Values[0] != Vector2.Zero)
                {
                    for (var i = 0; i < Values.Length; i++)
                        Values[i] = Vector2.Zero;
                    OnShake?.Invoke(Values);
                }
            }
        }

        // ReSharper disable once ConvertToPrimaryConstructor
        public ShakerListState(int length, bool on, Action<Vector2[]> onShake, Random sharedRandom)
        {
            Values = new Vector2[length];
            this.on = on;
            OnShake = onShake;
            Random = sharedRandom ?? throw new ArgumentNullException(nameof(sharedRandom));
        }

        public ShakerListState(int length, float time, bool removeOnFinish, Action<Vector2[]> onShake,
            Random sharedRandom) : this(length, true, onShake, sharedRandom)
        {
            Timer = time;
            RemoveOnFinish = removeOnFinish;
        }

        public ShakerListState ShakeFor(float seconds, bool removeOnFinish)
        {
            on = true;
            Timer = seconds;
            RemoveOnFinish = removeOnFinish;
            return this;
        }

        public void Attach()
        {
            Attached = true;
        }

        public void Detach()
        {
            Attached = false;
        }

        public void Update(float deltaTime, Func<float, bool> onInterval)
        {
            if (on && Timer > 0)
            {
                Timer -= deltaTime;
                if (Timer <= 0)
                {
                    on = false;
                    for (var i = 0; i < Values.Length; i++)
                        Values[i] = Vector2.Zero;
                    OnShake?.Invoke(Values);
                    if (RemoveOnFinish && Attached)
                        RemovalRequested?.Invoke(this);
                    return;
                }
            }

            if (on && onInterval(Interval))
            {
                for (var i = 0; i < Values.Length; i++)
                    Values[i] = new(offsets[Random.Next(5)], offsets[Random.Next(5)]);
                OnShake?.Invoke(Values);
            }
        }
    }
}
