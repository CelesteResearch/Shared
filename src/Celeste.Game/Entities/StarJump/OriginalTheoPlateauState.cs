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
    public class OriginalTheoPlateauState : OriginalNpcState
    {
        private float speedY;

        public OriginalTheoPlateauState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 48f;
            MoveY = false;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var beforeCampfire = SourceRuntimeExtensions
                .Get<IOriginalTheoPlateauAwakeInterceptionEnvironment>(Engine)?.BeforeTheoPlateauCampfire;
            if (!(beforeCampfire?.Invoke() ?? false))
            {
                var entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                Level.Scheduler.QueueSourceEntity(new CS06CampfireState(this, entity, Engine));
            }

            OwnedComponents.Add(Light =
                new(Engine, new(0f, -6f), PackedColor.White, 1f, 16, 48));
        }

        public override void Update()
        {
            base.Update();
            if (!CollideSolidAt(Position + new Vector2(0f, 1f)))
            {
                speedY += 400f * Engine.DeltaTime;
                Y += speedY * Engine.DeltaTime;
            }
            else
            {
                speedY = 0f;
            }
        }
    }
}
