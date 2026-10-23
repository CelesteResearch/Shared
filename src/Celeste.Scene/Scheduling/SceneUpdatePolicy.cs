using System;

namespace Celeste.Scene.Scheduling
{
    public sealed class SceneUpdatePolicy
    {
        private readonly SceneUpdatePass[][] committed, uncommitted, alternative;
        public bool EntityUpdateEvents { get; }
        public string PostUpdateComponentType { get; }
        public SceneTagSet UncommittedPostUpdateTags { get; }

        public SceneUpdatePolicy(SceneUpdatePass[][] committedPasses,
            SceneUpdatePass[][] uncommittedPasses, SceneUpdatePass[][] alternativeUncommittedPasses,
            string postUpdateComponentType = null, SceneTagSet uncommittedPostUpdateTags = default,
            bool entityUpdateEvents = false)
        {
            EntityUpdateEvents = entityUpdateEvents;
            committed = Copy(committedPasses);
            uncommitted = Copy(uncommittedPasses);
            alternative = Copy(alternativeUncommittedPasses);
            if (committed.Length == 0 || committed.Length != uncommitted.Length ||
                committed.Length != alternative.Length)
                throw new ArgumentException("Policy mode tables must have the same nonzero length.");
            PostUpdateComponentType = postUpdateComponentType;
            UncommittedPostUpdateTags = uncommittedPostUpdateTags;
        }

        private SceneUpdatePass[][] Copy(SceneUpdatePass[][] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var copy = new SceneUpdatePass[source.Length][];
            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = (SceneUpdatePass[])(source[i] ?? throw new ArgumentException("Null policy mode.")).Clone();
            }

            return copy;
        }

        internal SceneUpdatePass[] Passes(SceneModeKey mode, bool withoutCommit, bool alternate)
            => (withoutCommit ? alternate ? alternative : uncommitted : committed)[mode.Value];
    }
}
