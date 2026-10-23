using Celeste.Scene.Scheduling;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.LevelLoader
{
    // The LevelLoader's chapter-wide scene entities. Artwork and effects are
    // supplied by engine adapters, while this identity is shared by every room
    // and by the entity registry/Tracker for the lifetime of the Level.
    public class ChapterGlobalSceneState : global::Celeste.Scene.Tracking.ISceneEntityAssociation,
        global::Celeste.Scene.Tracking.ISceneEntityDepth, global::Celeste.Scene.Tracking.ISceneEntityTagFields
    {
        private readonly global::Celeste.Scene.Tracking.SceneEntityDepthState depthState;
        public global::Celeste.Scene.Tracking.SceneEntityDepthState DepthState => depthState;

        public int Depth
        {
            get => depthState.RawDepth;
            set
            {
                if (depthState.RawDepth == value) return;
                depthState.SetDepth(value, Scene, this);
                DepthChanged?.Invoke(value);
            }
        }

        public object Scene { get; private set; }

        object global::Celeste.Scene.Tracking.ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        private SceneTagSet tags;

        protected ChapterGlobalSceneState(int depth, SceneTagSet tags)
        {
            depthState = new global::Celeste.Scene.Tracking.SceneEntityDepthState(depth);
            this.tags = tags;
        }

        public Vector2 Position { get; set; }


        public SceneTagSet Tags
        {
            get => tags;
            set
            {
                if (tags == value) return;
                tags = value;
                if (Scene is global::Celeste.Scene.Tracking.ISceneEntityTagScene actualScene)
                    actualScene.SetEntityTags(this, value);
                TagsChanged?.Invoke(value);
            }
        }

        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool Collidable { get; set; } = true;
        public System.Action<int> DepthChanged;

        public System.Action<SceneTagSet> TagsChanged;

        // Reflection writes to Monocle.Entity's backing fields bypass the
        // Depth/Tag property callbacks and leave scene sort/tag lists untouched.
        public void SetRawDepth(int value) => depthState.RawDepth = value;
        public void SetRawTags(SceneTagSet value) => tags = value;
    }
}
