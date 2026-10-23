using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        // The source private int field bypasses the Tag property callbacks.
        // Retain all signed bits in the one existing tag storage.
        internal int SourceRawTagValue
        {
            get => tags.Bits;
            set => tags = new SceneTagSet(value);
        }

        // The original Tag property uses the same source scene notification point.
        internal int SourceTagValue
        {
            get => tags.Bits;
            set => Tags = new SceneTagSet(value);
        }
    }
}
