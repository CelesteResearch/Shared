using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningRemovalBlock
    {
        Bounds Bounds { get; }
        bool Disappearing { get; set; }
        void Shatter();
        void RemoveSelf();
    }
}
