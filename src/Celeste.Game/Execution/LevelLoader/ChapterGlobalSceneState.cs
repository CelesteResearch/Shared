using System;
using System.Numerics;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.LevelLoader
{
    // The LevelLoader's chapter-wide scene entities. Artwork and effects are
    // supplied by engine adapters, while this identity is shared by every room
    // and by the entity registry/Tracker for the lifetime of the Level.
    public class ChapterGlobalSceneState : ISceneEntityAssociation,
        ISceneEntityDepth, ISceneEntityTagFields
    {
        public SceneEntityDepthState DepthState { get; }

        public int Depth
        {
            get => DepthState.RawDepth;
            set
            {
                if (DepthState.RawDepth == value) return;
                DepthState.SetDepth(value, Scene, this);
                DepthChanged?.Invoke(value);
            }
        }

        public object Scene { get; private set; }

        object ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        private SceneTagSet tags;

        protected ChapterGlobalSceneState(int depth, SceneTagSet tags)
        {
            DepthState = new(depth);
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
                if (Scene is ISceneEntityTagScene actualScene)
                    actualScene.SetEntityTags(this, value);
                TagsChanged?.Invoke(value);
            }
        }

        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool Collidable { get; set; } = true;
        public Action<int> DepthChanged;

        public Action<SceneTagSet> TagsChanged;

        // Reflection writes to Monocle.Entity's backing fields bypass the
        // Depth/Tag property callbacks and leave scene sort/tag lists untouched.
        public void SetRawDepth(int value)
        {
            DepthState.RawDepth = value;
        }

        public void SetRawTags(SceneTagSet value)
        {
            tags = value;
        }
    }
}
