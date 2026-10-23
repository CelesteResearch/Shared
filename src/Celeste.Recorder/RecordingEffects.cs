using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Recorder
{
    public sealed class RecordingEffects
    {
        public float BlackFadeStart, BlackFadeEnd, BlackFadeTimer;
        public string Text = "";
        public Vector2 Position = new(960, 540);
        public float Scale = 1;

        public global::Celeste.Core.Display.PackedColor Color = global::Celeste.Core.Display.PackedColor
            .White;

        public float Alpha => BlackFadeStart <= BlackFadeEnd
            ? (BlackFadeTimer - BlackFadeStart) / (BlackFadeEnd - BlackFadeStart)
            : (BlackFadeTimer - BlackFadeEnd) / (BlackFadeStart - BlackFadeEnd);

        public void Reset()
        {
            BlackFadeStart = BlackFadeEnd = BlackFadeTimer = 0;
            Text = "";
            Position = new(960, 540);
            Scale = 1;
            Color = global::Celeste.Core.Display.PackedColor.White;
        }

        public void Update(float delta)
        {
            BlackFadeTimer = BlackFadeTimer > BlackFadeEnd
                ? Math.Max(BlackFadeTimer - delta, BlackFadeEnd)
                : Math.Min(BlackFadeTimer + delta, BlackFadeEnd);
            BlackFadeTimer = Math.Min(Math.Max(BlackFadeTimer, Math.Min(BlackFadeStart, BlackFadeEnd)),
                Math.Max(BlackFadeStart, BlackFadeEnd));
        }
    }
}
