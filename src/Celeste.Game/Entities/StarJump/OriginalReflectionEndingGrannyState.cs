using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.StarJump.Cutscenes;
using Celeste.Graphics.Content;
using Celeste.Simulation;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalReflectionEndingGrannyState : OriginalNpcState
    {
        private bool talked;

        public OriginalReflectionEndingGrannyState(EntityData data, Vector2 position,
            ISourceEngineContext engine)
            : base(engine, data.Position + position)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Scale.X = -1f;
            Sprite.Play("idle");
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 30f;
            Visible = false;
            OwnedComponents.Add(Light =
                new(Engine, new(0f, -8f), PackedColor.White, 1f, 16, 32));
            SetupGrannySpriteSounds();
        }

        public override void Update()
        {
            base.Update();
            if (!!talked)
                return;
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && entity.OnGround())
            {
                talked = true;
                Level.Scheduler.QueueSourceEntity(new CS06EndingState(entity, this, Engine));
            }
        }
    }
}
