using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Gameplay.Clutter
{
    public interface IClutterAbsorbEffect
    {
        void FlyClutter(Vector2 position, AtlasEntry texture, bool shake,
            float delay);

        void CloseCabinets();
    }
}
