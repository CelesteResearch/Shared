using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalMrOshiroDoorState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        private Sprite sprite;

        private OscillationPulseState wiggler;

        public OriginalMrOshiroDoorState(EntityData data, Vector2 offset, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, engine, worlds)
        {
        }

        private OriginalMrOshiroDoorState(Vector2 position, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds)
            : base(position, 32f, 32f, false, worlds.Create(position, false))
        {
            this.engine = engine;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("ghost_door"));
            sprite.Position = new Vector2(base.Width, base.Height) / 2f;
            sprite.Play("idle");
            OnDashCollide = OnDashed;
            OwnedComponents.Add(wiggler = new OscillationPulseState(engine, 0.6f, 3f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f - f * 0.2f); }));
            SurfaceSoundIndex = 20;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Visible = (Collidable = !((OriginalLevelSceneRoot)Scene).Session.GetFlag("oshiro_resort_talked_1"));
        }

        public void Open()
        {
            if (Collidable)
            {
                ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/forcefield_vanish",
                    Position,
                    ((IOriginalGameplayProcess)engine).SaveContext);
                sprite.Play("open");
                Collidable = false;
            }
        }

        public void InstantOpen()
        {
            Collidable = (Visible = false);
        }

        private DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/forcefield_bump", Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            wiggler.Start();
            return DashCollisionResult.Bounce;
        }
    }
}
