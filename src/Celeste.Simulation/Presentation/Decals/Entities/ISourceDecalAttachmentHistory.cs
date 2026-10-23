using System.Numerics;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public interface ISourceDecalAttachmentHistory
    {
        bool Contains(string name, Vector2 position);
        void Record(string name, Vector2 position);
    }
}
