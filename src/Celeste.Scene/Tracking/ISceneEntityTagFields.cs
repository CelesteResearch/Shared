using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    public interface ISceneEntityTagFields : ISceneEntityTags
    {
        new SceneTagSet Tags { get; set; }
        void SetRawTags(SceneTagSet value);
    }
}
