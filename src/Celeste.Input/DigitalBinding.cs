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

        public bool Check(int gamepadIndex, float threshold)
        {
            return Held;
        }

        public bool Pressed(int gamepadIndex, float threshold)
        {
            return PressEdge;
        }

        public bool Released(int gamepadIndex, float threshold)
        {
            return ReleaseEdge;
        }

        public float Axis(int gamepadIndex, float threshold)
        {
            return Held ? 1 : 0;
        }
    }
}
