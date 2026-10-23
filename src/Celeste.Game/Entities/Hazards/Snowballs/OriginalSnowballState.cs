using Celeste.Core.Components;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Hazards.Snowballs
{
    public sealed class OriginalSnowballState : SceneEntityState
    {
        private const float ResetTime = 0.8f;

        private Sprite sprite;

        private float resetTimer;

        private OriginalLevelSceneRoot level;
        private readonly IOriginalSnowballEnvironment engine;

        private SineWaveState sine;

        private float atY;

        private SoundSourceComponentState spawnSfx;

        private ColliderGeometry bounceCollider;
        public ColliderGeometry BounceCollider => bounceCollider;

        public OriginalSnowballState(IOriginalSnowballEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, Vector2.Zero)
        {
            this.engine = engine;
            base.Depth = -12500;
            base.Collider = new HitboxColliderGeometry(12f, 9f, -5f, -2f);
            bounceCollider = new HitboxColliderGeometry(16f, 6f, -6f, -8f);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new PlayerColliderComponentState(OnPlayerBounce, bounceCollider));
            Add(sine = new SineWaveState(engine, 0.5f));
            Add(sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("snowball"));
            sprite.Play("spin");
            Add(spawnSfx = engine.SoundSources.Create());
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
            ResetPosition();
        }

        private void ResetPosition()
        {
            RoomPlayerSession entity =
                level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null && entity.Right < (float)(level.Bounds.Right - 64))
            {
                spawnSfx.Play("event:/game/04_cliffside/snowball_spawn");
                Collidable = (Visible = true);
                resetTimer = 0f;
                base.X = level.Camera.Right + 10f;
                float num = (base.Y = entity.CenterY);
                atY = num;
                sine.Reset();
                sprite.Play("spin");
            }
            else
            {
                resetTimer = 0.05f;
            }
        }

        private void Destroy()
        {
            Collidable = false;
            sprite.Play("break");
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(new Vector2(-1f, 0f));
            Destroy();
            engine.PlaySound("event:/game/04_cliffside/snowball_impact", Position);
        }

        private void OnPlayerBounce(RoomPlayerSession player)
        {
            if (!SourceEntityCollision.Check(this, player))
            {
                engine.Freeze(0.1f);
                player.Bounce(base.Top - 2f);
                Destroy();
                engine.PlaySound("event:/game/general/thing_booped", Position);
            }
        }

        public override void Update()
        {
            base.Update();
            base.X -= 200f * engine.DeltaTime;
            base.Y = atY + 4f * sine.Value;
            if (base.X < level.Camera.Left - 60f)
            {
                resetTimer += engine.DeltaTime;
                if (resetTimer >= 0.8f)
                {
                    ResetPosition();
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            sprite.DrawOutline(context);
            base.Render(context);
        }
    }
}
