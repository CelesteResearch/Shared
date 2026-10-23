using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Scene.Following
{
    public sealed class LeaderState : global::Celeste.Core.Components.SourceComponentState
    {
        public const int MaxPastPoints = 350;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public List<FollowerState> Followers = new List<FollowerState>();
        public List<Vector2> PastPoints = new List<Vector2>();
        public Vector2 Position;

        public LeaderState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, Vector2 offset = default) :
            base(true, false)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Position = offset;
        }

        public void GainFollower(FollowerState follower)
        {
            Followers.Add(follower);
            follower.OnGainLeaderUtil(this);
        }

        public void LoseFollower(FollowerState follower)
        {
            Followers.Remove(follower);
            follower.OnLoseLeaderUtil();
        }

        public void LoseFollowers()
        {
            // Preserve the native live-list enumeration: callbacks may mutate
            // it, including the resulting InvalidOperationException.
            foreach (var follower in Followers) follower.OnLoseLeaderUtil();
            Followers.Clear();
        }

        public override void Update()
        {
            Vector2 position = ((global::Celeste.Core.Components.ISourceEntityPosition)Entity).Position + Position;
            if (((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(.02f, engine) &&
                (PastPoints.Count == 0 ||
                 ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                     position - PastPoints[0]) >= 3f))
            {
                PastPoints.Insert(0, position);
                if (PastPoints.Count > MaxPastPoints) PastPoints.RemoveAt(PastPoints.Count - 1);
            }

            int index = 5;
            foreach (var follower in Followers)
            {
                if (index >= PastPoints.Count) break;
                Vector2 target = PastPoints[index];
                if (follower.DelayTimer <= 0 && follower.MoveTowardsLeader)
                {
                    var actual = (global::Celeste.Core.Components.ISourceMutableEntityState)follower.Entity;
                    actual.Position = actual.Position + (target - actual.Position) *
                        (1f - (float)Math.Pow(0.009999999776482582, engine.DeltaTime));
                }

                index += 5;
            }
        }

        public bool HasFollower<T>()
        {
            foreach (var follower in Followers)
                if (follower.Entity is T)
                    return true;
            return false;
        }

        public void TransferFollowers()
        {
            for (int i = 0; i < Followers.Count; i++)
                if ((((global::Celeste.Scene.Tracking.ISceneEntityTagFields)Followers[i].Entity).Tags &
                     Followers[i].PersistentTag) == 0)
                {
                    LoseFollower(Followers[i]);
                    i--;
                }
        }
    }
}
