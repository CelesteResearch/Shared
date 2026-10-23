using System.Collections.Generic;

namespace Celeste.Scene.Ownership
{
    // Live containers owned by this scene object. Enumerating these roots must not
    // initialize lazy objects or follow world, resource, callback or pool references.
    // Consumers decide how to inspect roots and filter committed/present entities.
    public interface ISceneOwnedObjectSource
    {
        IEnumerable<object> SceneOwnedObjectRoots { get; }
    }
}
