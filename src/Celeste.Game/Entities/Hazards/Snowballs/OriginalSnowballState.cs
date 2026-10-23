using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Entities.Hazards.Snowballs
{
    public sealed class OriginalSnowballState : SceneEntityState
    {
        private const float ResetTime = 0.8f;

        private readonly Sprite _sprite;

        private float _resetTimer;

        private OriginalLevelSceneRoot _level;
        private readonly IOriginalSnowballEnvironment _engine;

        private readonly SineWaveState _sine;

        private float _atY;

        private readonly SoundSourceComponentState _spawnSfx;

        public ColliderGeometry BounceCollider { get; }

        public OriginalSnowballState(IOriginalSnowballEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, Vector2.Zero)
        {
            _engine = engine;
            Depth = -12500;
            Collider = new HitboxColliderGeometry(12f, 9f, -5f, -2f);
            BounceCollider = new HitboxColliderGeometry(16f, 6f, -6f, -8f);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new PlayerColliderComponentState(OnPlayerBounce, BounceCollider));
            Add(_sine = new(engine, 0.5f));
            Add(_sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("snowball"));
            _sprite.Play("spin");
            Add(_spawnSfx = engine.SoundSources.Create());
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            _level = (OriginalLevelSceneRoot)Scene;
            ResetPosition();
        }

        private void ResetPosition()
        {
            var entity =
                _level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && entity.Right < _level.Bounds.Right - 64)
            {
                _spawnSfx.Play("event:/game/04_cliffside/snowball_spawn");
                Collidable = Visible = true;
                _resetTimer = 0f;
                X = _level.Camera.Right + 10f;
                var num = Y = entity.CenterY;
                _atY = num;
                _sine.Reset();
                _sprite.Play("spin");
            }
            else
            {
                _resetTimer = 0.05f;
            }
        }

        private void Destroy()
        {
            Collidable = false;
            _sprite.Play("break");
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(new(-1f, 0f));
            Destroy();
            _engine.PlaySound("event:/game/04_cliffside/snowball_impact", Position);
        }

        private void OnPlayerBounce(RoomPlayerSession player)
        {
            if (!SourceEntityCollision.Check(this, player))
            {
                _engine.Freeze(0.1f);
                player.Bounce(Top - 2f);
                Destroy();
                _engine.PlaySound("event:/game/general/thing_booped", Position);
            }
        }

        public override void Update()
        {
            base.Update();
            X -= 200f * _engine.DeltaTime;
            Y = _atY + 4f * _sine.Value;
            if (X < _level.Camera.Left - 60f)
            {
                _resetTimer += _engine.DeltaTime;
                if (_resetTimer >= 0.8f) ResetPosition();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            _sprite.DrawOutline(context);
            base.Render(context);
        }
    }
}
