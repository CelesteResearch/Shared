using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics.Extrema;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.Gameplay.Actors.Debris
{
    public class DebrisState : SourceActorEntityState
    {
        private readonly SpriteImage image;
        private float lifeTimer;
        private float alpha;
        private Vector2 speed;
        private readonly global::Celeste.Physics.Collision.SourceCollisionHandler collideH;
        private readonly global::Celeste.Physics.Collision.SourceCollisionHandler collideV;
        private int rotateSign;
        private float fadeLerp;
        private bool playSound = true;
        private bool dreaming;
        private readonly SineWaveState dreamSine;
        private bool hasHitGround;
        private char tileset;
        private AtlasData Atlas => ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;
        private readonly ISourceEngineContext engine;
        protected ISourceEngineContext SourceEngine => engine;
        protected SpriteImage SourceImage => image;
        public SpriteImage DebrisImage => image;
        public float DebrisAlpha => alpha;
        public void SetTexture(AtlasEntry texture) => image.Texture = texture;
        protected char SourceTileset => tileset;
        protected bool SourcePlaySound => playSound;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic ExtremaArithmetic => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        public DebrisState(ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(new PixelActor(null, Vector2.Zero), engine, targetMotionPolicy)
        {
            this.engine = engine;
            Position = Vector2.Zero;
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -2f);
            Tags =
                ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourcePersistentTransitionExecutionTagsEnvironment)
                    engine)
                .PersistentTransitionExecutionTags.Persistent.Value;
            Depth = 2000;
            image = new SpriteImage(null);
            OwnedComponents.Add(image);
            collideH = OnCollideH;
            collideV = OnCollideV;
            dreamSine = new SineWaveState(engine, .6f);
            OwnedComponents.Add(dreamSine);
            dreamSine.Randomize();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            dreaming = ((ISourceDebrisScene)Scene).Dreaming;
        }

        public virtual DebrisState Init(Vector2 position, char tileset, bool playSound = true)
        {
            Position = position;
            this.tileset = tileset;
            this.playSound = playSound;
            lifeTimer = .6f + (float)Random.NextDouble() * (2.6f - .6f);
            alpha = 1f;
            hasHitGround = false;
            speed = Vector2.Zero;
            fadeLerp = 0f;
            rotateSign = Random.Next(2) == 0 ? 1 : -1;
            if (Atlas.Has("debris/" + tileset)) image.Texture = Atlas["debris/" + tileset];
            else image.Texture = Atlas["debris/1"];
            image.CenterOrigin();
            image.Color = PackedColor.White * alpha;
            image.Rotation = (float)Random.NextDouble() * ((float)Math.PI * 2f);
            image.Scale.X = .5f + (float)Random.NextDouble() * (1f - .5f);
            image.Scale.Y = .5f + (float)Random.NextDouble() * (1f - .5f);
            image.FlipX = (float)Random.NextDouble() < .5f;
            image.FlipY = (float)Random.NextDouble() < .5f;
            return this;
        }

        public DebrisState BlastFrom(Vector2 from)
        {
            float length = 30 + Random.Next(10);
            speed = VectorArithmetic.SafeNormalize(Position - from, length);
            speed = VectorArithmetic.Rotate(speed, -(float)Math.PI / 12f
                                                   + (float)Random.NextDouble() *
                                                   ((float)Math.PI / 12f - -(float)Math.PI / 12f));
            return this;
        }

        private void OnCollideH(PixelCollision data) => speed.X *= -.8f;

        private void OnCollideV(PixelCollision data)
        {
            if (speed.Y > 0f) hasHitGround = true;
            speed.Y *= -.6f;
            if (speed.Y < 0f && speed.Y > -50f) speed.Y = 0f;
            if (speed.Y != 0f || !hasHitGround) ImpactSfx(Math.Abs(speed.Y));
        }

        protected virtual void ImpactSfx(float velocity)
        {
            if (playSound)
            {
                string path = "event:/game/general/debris_dirt";
                if (tileset == '4' || tileset == '5' || tileset == '6' || tileset == '7' || tileset == 'a'
                    || tileset == 'c' || tileset == 'd' || tileset == 'e' || tileset == 'f' || tileset == 'd' ||
                    tileset == 'g')
                    path = "event:/game/general/debris_stone";
                else if (tileset == '9') path = "event:/game/general/debris_wood";
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(path, Position, "debris_velocity",
                    ScalarMath.ClampedMap(velocity, 0f, 150f));
            }
        }

        public override void Update()
        {
            base.Update();
            image.Rotation += Math.Abs(speed.X) * (float)rotateSign * engine.DeltaTime;
            if (fadeLerp < 1f) fadeLerp = ScalarMath.Approach(fadeLerp, 1f, 2f * engine.DeltaTime, ExtremaArithmetic);
            MoveH(speed.X * engine.DeltaTime, collideH);
            MoveV(speed.Y * engine.DeltaTime, collideV);
            if (dreaming)
            {
                speed.X = ScalarMath.Approach(speed.X, 0f, 50f * engine.DeltaTime, ExtremaArithmetic);
                speed.Y = ScalarMath.Approach(speed.Y, 6f * dreamSine.Value, 100f * engine.DeltaTime,
                    ExtremaArithmetic);
            }
            else
            {
                bool onGround = OnGround();
                speed.X = ScalarMath.Approach(speed.X, 0f, (onGround ? 50f : 20f) * engine.DeltaTime,
                    ExtremaArithmetic);
                if (!onGround) speed.Y = ScalarMath.Approach(speed.Y, 100f, 400f * engine.DeltaTime, ExtremaArithmetic);
            }

            if (lifeTimer > 0f) lifeTimer -= engine.DeltaTime;
            else if (alpha > 0f)
            {
                alpha -= 4f * engine.DeltaTime;
                if (alpha <= 0f) RemoveSelf();
            }

            image.Color = PackedColor.Lerp(PackedColor.White, PackedColor.Gray, fadeLerp) * alpha;
        }
    }
}
