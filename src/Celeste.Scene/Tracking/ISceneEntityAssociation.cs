using Celeste.Core.Components;

namespace Celeste.Scene.Tracking
{
    // Implement on the actual Entity identity. The setter only changes its real
    // source Scene field: no Added, Removed, SceneEnd, Tracker or component work.
    // Explicit implementation can expose an existing private-set Scene property.
    public interface ISceneEntityAssociation : ISourceEntityScene
    {
        new object Scene { get; set; }
    }
}
