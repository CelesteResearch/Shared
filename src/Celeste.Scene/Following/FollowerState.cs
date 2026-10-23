using System;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Following
{
    public sealed class FollowerState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        public readonly SceneTagSet PersistentTag;
        public MapEntityId ParentEntityID;
        public LeaderState Leader;
        public Action OnGainLeader, OnLoseLeader;
        public bool PersistentFollow = true;
        public float FollowDelay = .5f, DelayTimer;
        public bool MoveTowardsLeader = true;
        public bool HasLeader => Leader != null;
        public int FollowIndex => Leader == null ? -1 : Leader.Followers.IndexOf(this);

        public FollowerState(ISourceEngineContext engine,
            SceneTagSet persistentTag, MapEntityId parentEntityID = default,
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
            if (PersistentFollow) ((ISceneEntityTagFields)Entity).Tags &= ~PersistentTag;
            Leader = null;
            OnLoseLeader?.Invoke();
        }

        public void OnGainLeaderUtil(LeaderState leader)
        {
            if (PersistentFollow) ((ISceneEntityTagFields)Entity).Tags |= PersistentTag;
            Leader = leader;
            DelayTimer = FollowDelay;
            OnGainLeader?.Invoke();
        }
    }
}
