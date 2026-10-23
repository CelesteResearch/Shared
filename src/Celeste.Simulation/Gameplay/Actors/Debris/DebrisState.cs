using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Actors.Debris
{
    public class DebrisState : SourceActorEntityState
    {
        private float lifeTimer;

        private float alpha;
        private Vector2 speed;
        private readonly SourceCollisionHandler collideH;
        private readonly SourceCollisionHandler collideV;
        private int rotateSign;
        private float fadeLerp;

        private bool playSound = true;
        private bool dreaming;
        private readonly SineWaveState dreamSine;
        private bool hasHitGround;

        private char tileset;
        private AtlasData Atlas => ((ISourceGameGraphicsEnvironment)SourceEngine).GameGraphics.GameAtlas;
        protected ISourceEngineContext SourceEngine { get; }

        protected SpriteImage SourceImage { get; }

        public SpriteImage DebrisImage => SourceImage;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public float DebrisAlpha => alpha;

        public void SetTexture(AtlasEntry texture)
        {
            SourceImage.Texture = texture;
        }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        protected char SourceTileset => tileset;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        protected bool SourcePlaySound => playSound;
        private ISourceRandom Random => ((ISourceRandomEnvironment)SourceEngine).Random;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)SourceEngine).VectorArithmetic;

        private ISourceExtremaArithmetic ExtremaArithmetic =>
            ((ISourceExtremaEnvironment)SourceEngine).ExtremaArithmetic;

        public DebrisState(ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(new(null, Vector2.Zero), engine, targetMotionPolicy)
        {
            SourceEngine = engine;
            Position = Vector2.Zero;
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -2f);
            Tags =
                ((ISourcePersistentTransitionExecutionTagsEnvironment)
                    engine)
                .PersistentTransitionExecutionTags.Persistent.Value;
            Depth = 2000;
            SourceImage = new(null);
            OwnedComponents.Add(SourceImage);
            collideH = OnCollideH;
            collideV = OnCollideV;
            dreamSine = new(engine, .6f);
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
            if (Atlas.Has("debris/" + tileset)) SourceImage.Texture = Atlas["debris/" + tileset];
            else SourceImage.Texture = Atlas["debris/1"];
            SourceImage.CenterOrigin();
            SourceImage.Color = PackedColor.White * DebrisAlpha;
            SourceImage.Rotation = (float)Random.NextDouble() * ((float)Math.PI * 2f);
            SourceImage.Scale.X = .5f + (float)Random.NextDouble() * (1f - .5f);
            SourceImage.Scale.Y = .5f + (float)Random.NextDouble() * (1f - .5f);
            SourceImage.FlipX = (float)Random.NextDouble() < .5f;
            SourceImage.FlipY = (float)Random.NextDouble() < .5f;
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

        private void OnCollideH(PixelCollision data)
        {
            speed.X *= -.8f;
        }

        private void OnCollideV(PixelCollision data)
        {
            if (speed.Y > 0f) hasHitGround = true;
            speed.Y *= -.6f;
            if (speed.Y < 0f && speed.Y > -50f) speed.Y = 0f;
            if (speed.Y != 0f || !hasHitGround) ImpactSfx(Math.Abs(speed.Y));
        }

        protected virtual void ImpactSfx(float velocity)
        {
            if (SourcePlaySound)
            {
                var path = "event:/game/general/debris_dirt";
                if (SourceTileset == '4' || SourceTileset == '5' || SourceTileset == '6' || SourceTileset == '7' ||
                    SourceTileset == 'a'
                    || SourceTileset == 'c' || SourceTileset == 'd' || SourceTileset == 'e' || SourceTileset == 'f' ||
                    SourceTileset == 'd' ||
                    SourceTileset == 'g')
                    path = "event:/game/general/debris_stone";
                else if (SourceTileset == '9') path = "event:/game/general/debris_wood";
                ((ISourceSpatialAudioEnvironment)SourceEngine).SpatialAudio.Play(path, Position, "debris_velocity",
                    ScalarMath.ClampedMap(velocity, 0f, 150f));
            }
        }

        public override void Update()
        {
            base.Update();
            SourceImage.Rotation += Math.Abs(speed.X) * rotateSign * SourceEngine.DeltaTime;
            if (fadeLerp < 1f)
                fadeLerp = ScalarMath.Approach(fadeLerp, 1f, 2f * SourceEngine.DeltaTime, ExtremaArithmetic);
            MoveH(speed.X * SourceEngine.DeltaTime, collideH);
            MoveV(speed.Y * SourceEngine.DeltaTime, collideV);
            if (dreaming)
            {
                speed.X = ScalarMath.Approach(speed.X, 0f, 50f * SourceEngine.DeltaTime, ExtremaArithmetic);
                speed.Y = ScalarMath.Approach(speed.Y, 6f * dreamSine.Value, 100f * SourceEngine.DeltaTime,
                    ExtremaArithmetic);
            }
            else
            {
                var onGround = OnGround();
                speed.X = ScalarMath.Approach(speed.X, 0f, (onGround ? 50f : 20f) * SourceEngine.DeltaTime,
                    ExtremaArithmetic);
                if (!onGround)
                    speed.Y = ScalarMath.Approach(speed.Y, 100f, 400f * SourceEngine.DeltaTime, ExtremaArithmetic);
            }

            if (lifeTimer > 0f)
            {
                lifeTimer -= SourceEngine.DeltaTime;
            }
            else if (DebrisAlpha > 0f)
            {
                alpha -= 4f * SourceEngine.DeltaTime;
                if (DebrisAlpha <= 0f) RemoveSelf();
            }

            SourceImage.Color = PackedColor.Lerp(PackedColor.White, PackedColor.Gray, fadeLerp) * DebrisAlpha;
        }
    }
}
