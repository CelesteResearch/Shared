using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Entities.Hazards.Killboxes
{
    public class OriginalKillboxEntity : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext _engine;
        private readonly IOriginalGameSaveContext _saveContext;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => _engine;

        public OriginalKillboxEntity(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            _engine = engine;
            _saveContext = ((IOriginalGameplayProcess)engine).SaveContext;
            Collider = new HitboxColliderGeometry(data.Width, 32f);
            Collidable = false;
            Add(new PlayerColliderComponentState(OnPlayer));
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (_saveContext.CurrentSave.Assists.Invincible)
            {
                player.Play("event:/game/general/assist_screenbottom");
                player.Bounce(Top);
            }
            else
            {
                player.Die(Vector2.Zero);
            }
        }

        public override void Update()
        {
            if (!Collidable)
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (player != null && player.Bottom < Top - 32f) Collidable = true;
            }
            else
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (player != null && player.Top > Bottom + 32f) Collidable = false;
            }

            base.Update();
        }
    }
}
