using System;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        public override void Added(object scene)
        {
            base.Added(scene);
            var level = (OriginalLevelSceneRoot)Scene;
            random = engine.RandomProcess.Factory.CreateSeeded(
                ((OriginalLevelRoomData)level.Session.LevelData).LoadSeed);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var entities =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);

            var player = entities.Count > 0 ? entities[0] as RoomPlayerSession : null;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (player == null || X == player.X) SnapFacing(1f);
            else SnapFacing(Math.Sign(player.X - X));
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return false;
        }

        public override bool IsRiding(ISourceJumpThruCollider jumpThru)
        {
            return false;
        }
    }
}
