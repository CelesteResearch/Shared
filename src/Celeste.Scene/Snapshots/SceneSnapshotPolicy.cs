using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Snapshots
{
    // Type registration belongs to the content/module lifetime, not to a saved scene frame.
    // Ports can compose this policy with their native-resource snapshot policy.
    public static class SceneSnapshotPolicy
    {
        public static object RetainExternalConfiguration(object value)
            => value is SceneEntityCatalog || value is SceneUpdatePolicy ? value : null;
    }
}
