using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Components.Shaking
{
    // Monocle.Shaker (Artifacts/Reference/Original/Monocle/Shaker.cs:6-95) with
    // RemoveOnFinish always false and no OnShake callback.
    public sealed class PlatformShaker : global::Celeste.Core.Components.ISourceComponentFields
    {
        public global::Celeste.Core.Components.SourceComponentFields ComponentFields { get; } =
            new global::Celeste.Core.Components.SourceComponentFields(true, false);

        public object Entity => ComponentFields.Entity;
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

        public const float Interval = 0.05f;
        public Vector2 Value { get; private set; }
        public float Timer { get; private set; }
        public bool On { get; private set; }

        public PlatformShaker(bool on)
        {
            On = on;
        }

        public void ShakeFor(float seconds)
        {
            On = true;
            Timer = seconds;
        }

        public void Update(float dt, Func<bool> interval, Func<Vector2> shake)
        {
            if (On && Timer > 0f)
            {
                Timer -= dt;
                if (Timer <= 0f)
                {
                    On = false;
                    Value = Vector2.Zero;
                    return;
                }
            }

            if (On && interval()) Value = shake();
        }
    }
}
