using System;
using System.Numerics;

namespace Celeste.Input
{
    public sealed class DigitalBinding : IInputBinding
    {
        public bool Held, PressEdge, ReleaseEdge;

        public void Sample(bool held)
        {
            PressEdge = held && !Held;
            ReleaseEdge = !held && Held;
            Held = held;
        }

        public bool Check(int gamepadIndex, float threshold) => Held;
        public bool Pressed(int gamepadIndex, float threshold) => PressEdge;
        public bool Released(int gamepadIndex, float threshold) => ReleaseEdge;
        public float Axis(int gamepadIndex, float threshold) => Held ? 1 : 0;
    }
}
