using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Triggers.Respawning
{
    public class OriginalChangeRespawnTrigger : SourceTriggerEntityState
    {
        public Vector2 Target;

        public OriginalChangeRespawnTrigger(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
            if (data.Nodes != null && data.Nodes.Length != 0) Target = data.Nodes[0] + offset;
            else Target = Center;
            Visible = Active = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Target = ((OriginalLevelSceneRoot)Scene).GetSpawnPoint(Target);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var session = ((OriginalLevelSceneRoot)Scene).Session;
            if (SolidCheck() && (!session.RespawnPoint.HasValue || session.RespawnPoint.Value != Target))
            {
                session.HitCheckpoint = true;
                session.RespawnPoint = Target;
                session.UpdateLevelStartDashes();
            }
        }

        private bool SolidCheck()
        {
            Vector2 point = Target + Vector2.UnitY * -4f;
            var entities = ((OriginalLevelSceneRoot)Scene).SourceScene.Entities;
            if (SourceSceneCollision.CheckPoint(entities, "Celeste.Solid", point))
                return SourceSceneCollision.CheckPoint(entities, "Celeste.FloatySpaceBlock", point);
            return true;
        }
    }
}
