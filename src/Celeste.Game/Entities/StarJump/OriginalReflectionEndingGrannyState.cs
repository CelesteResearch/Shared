using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Npcs;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Entities.StarJump.Cutscenes;

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
                new VertexLightState(Engine, new Vector2(0f, -8f), PackedColor.White, 1f, 16, 32));
            SetupGrannySpriteSounds();
        }

        public override void Update()
        {
            base.Update();
            if (!talked)
            {
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && entity.OnGround())
                {
                    talked = true;
                    Level.Scheduler.QueueSourceEntity(new CS06EndingState(entity, this, Engine));
                }
            }
        }
    }
}
