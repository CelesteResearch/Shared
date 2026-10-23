using Celeste.Scene.Scenes;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        public SourceSceneState SourceSceneValue
        {
            get => (SourceSceneState)Scene;
            set => Scene = value;
        }
    }
}
