using System;

namespace Celeste.Simulation.Runtime.Components.Oscillation
{
    internal sealed class VisualWiggler
    {
        private float counter, sineCounter;
        private readonly float increment, sineAdd;
        private readonly bool startZero;
        private readonly Action<float> change;

        public VisualWiggler(float duration, float frequency, bool startZero, Action<float> change)
        {
            increment = 1 / duration;
            sineAdd = (float)Math.PI * 2 * frequency;
            this.startZero = startZero;
            this.change = change;
        }

        public void Start()
        {
            counter = 1;
            sineCounter = startZero ? (float)Math.PI / 2 : 0;
            change(startZero ? 0 : 1);
        }

        public void Update(float dt)
        {
            if (counter <= 0) return;
            sineCounter += sineAdd * dt;
            counter = Math.Max(0, counter - increment * dt);
            change((float)Math.Cos(sineCounter) * counter);
        }
    }
}
