using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Following;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers
{
    public sealed class DetachStrawberryTriggerState : SourceTriggerEntityState
    {
        public Vector2 Target;
        public bool Global;
        private readonly IOriginalStrawberryProcess process;

        public DetachStrawberryTriggerState(EntityData data, Vector2 offset,
            IOriginalStrawberryProcess process) : base(
            ((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)process).EntitySourceDataRegistration,
            data.Position + offset, data.Width, data.Height,
            ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process).ExtremaArithmetic)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            Vector2[] nodes = data.NodesOffset(offset);
            if (nodes.Length != 0) Target = nodes[0];
            Global = EntityAttributeReader.Bool(data.Values, "global", true);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            for (int i = player.Leader.Followers.Count - 1; i >= 0; i--)
                if (player.Leader.Followers[i].Entity is OriginalStrawberryState)
                    OwnedComponents.Add(new SimulationCoroutine(process, DetatchFollower(player.Leader.Followers[i])));
        }

        private IEnumerator DetatchFollower(FollowerState follower)
        {
            LeaderState leader = follower.Leader;
            var entity = (SceneEntityState)follower.Entity;
            float distance = process.VectorArithmetic.Length(entity.Position - Target);
            float time = distance / 200f;
            if (entity is OriginalStrawberryState strawberry) strawberry.ReturnHomeWhenLost = false;
            leader.LoseFollower(follower);
            entity.Active = false;
            entity.Collidable = false;
            if (Global)
            {
                entity.Tags |= ((Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)process).Tags.Global
                    .Value;
                follower.OnGainLeader += () =>
                    entity.Tags &= ~((Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)process).Tags.Global
                        .Value;
            }
            else
                entity.Tags |= ((Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)process).Tags.Persistent
                    .Value;

            process.AudioSession.Play("event:/new_content/game/10_farewell/strawberry_gold_detach", entity.Position,
                process.SaveContext);
            Vector2 position = entity.Position;
            var curve = new SimpleCurve(position, Target,
                position + (Target - position) * .5f + new Vector2(0f, -64f));
            for (float p = 0f; p < 1f; p += process.DeltaTime / time)
            {
                entity.Position = process.CurveArithmetic.GetPoint(curve, process.EasingArithmetic.CubeInOut(p));
                yield return null;
            }

            entity.Active = true;
            entity.Collidable = true;
        }
    }
}
