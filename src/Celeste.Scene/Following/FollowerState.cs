using System;
using System.Numerics;
using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Following
{
    public sealed class FollowerState : global::Celeste.Core.Components.SourceComponentState
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public readonly SceneTagSet PersistentTag;
        public global::Celeste.Core.Maps.MapEntityId ParentEntityID;
        public LeaderState Leader;
        public Action OnGainLeader, OnLoseLeader;
        public bool PersistentFollow = true;
        public float FollowDelay = .5f, DelayTimer;
        public bool MoveTowardsLeader = true;
        public bool HasLeader => Leader != null;
        public int FollowIndex => Leader == null ? -1 : Leader.Followers.IndexOf(this);

        public FollowerState(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            SceneTagSet persistentTag, global::Celeste.Core.Maps.MapEntityId parentEntityID = default,
            Action onGainLeader = null, Action onLoseLeader = null) : base(true, false)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            PersistentTag = persistentTag;
            ParentEntityID = parentEntityID;
            OnGainLeader = onGainLeader;
            OnLoseLeader = onLoseLeader;
        }

        public override void Update()
        {
            base.Update();
            if (DelayTimer > 0) DelayTimer -= engine.DeltaTime;
        }

        public void OnLoseLeaderUtil()
        {
            if (PersistentFollow) ((global::Celeste.Scene.Tracking.ISceneEntityTagFields)Entity).Tags &= ~PersistentTag;
            Leader = null;
            OnLoseLeader?.Invoke();
        }

        public void OnGainLeaderUtil(LeaderState leader)
        {
            if (PersistentFollow) ((global::Celeste.Scene.Tracking.ISceneEntityTagFields)Entity).Tags |= PersistentTag;
            Leader = leader;
            DelayTimer = FollowDelay;
            OnGainLeader?.Invoke();
        }
    }
}
