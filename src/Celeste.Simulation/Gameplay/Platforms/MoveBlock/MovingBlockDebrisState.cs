using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.MoveBlock
{
    public abstract class MovingBlockDebrisState : SourceActorEntityState
    {
        public readonly SpriteImage Sprite;
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private readonly SourceCollisionHandler onCollideH;
        private readonly SourceCollisionHandler onCollideV;
        private bool firstHit;
        public Vector2 Home { get; private set; }
        public Vector2 Speed;
        public bool Shaking { get; private set; }
        public bool Returning { get; private set; }
        public float ReturnEase { get; private set; }
        public float ReturnDuration { get; private set; }
        public SimpleCurve ReturnCurve { get; private set; }
        public float Spin { get; private set; }
        public float Alpha { get; private set; }

        protected MovingBlockDebrisState(AtlasData atlas, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : this(atlas, engine, targetMotionPolicy, "objects/moveblock/debris")
        {
        }

        protected MovingBlockDebrisState(AtlasData atlas, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy, string texturePath)
            : base(new(null, Vector2.Zero), engine, targetMotionPolicy)
        {
            this.engine = engine;
            Position = Vector2.Zero;
            Tags =
                ((ISourcePersistentTransitionExecutionTagsEnvironment)
                    engine)
                .PersistentTransitionExecutionTags.TransitionUpdate.Value;
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -2f);
            var textures = atlas.GetAtlasSubtextures(texturePath);
            Sprite = new(Random.Choose(textures));
            OwnedComponents.Add(Sprite);
            Sprite.CenterOrigin();
            Sprite.FlipX = SourceRandomMath.NextFloat(Random) < .5f;
            onCollideH = _ => Speed.X = (0f - Speed.X) * .5f;
            onCollideV = _ =>
            {
                if (firstHit || Speed.Y > 50f)
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/general/debris_stone",
                        Position,
                        "debris_velocity", ScalarMath.ClampedMap(Speed.Y, 0f, 600f));
                if (Speed.Y > 0f && Speed.Y < 40f) Speed.Y = 0f;
                else Speed.Y = (0f - Speed.Y) * .25f;
                firstHit = false;
            };
        }

        protected override void OnSquish(PixelCollision data)
        {
        }

        public MovingBlockDebrisState Init(Vector2 position, Vector2 center, Vector2 returnTo)
        {
            Collidable = true;
            Position = position;
            Speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(position - center,
                60f + SourceRandomMath.NextFloat(Random, 60f));
            Home = returnTo;
            Sprite.Position = Vector2.Zero;
            Sprite.Rotation = SourceRandomMath.NextAngle(Random);
            Returning = false;
            Shaking = false;
            Sprite.Scale.X = 1f;
            Sprite.Scale.Y = 1f;
            Sprite.Color = PackedColor.White;
            Alpha = 1f;
            firstHit = false;
            Spin = SourceRandomMath.Range(Random, 3.4906585f, 10.471975f) * Random.Choose(1, -1);
            return this;
        }

        public override void Update()
        {
            UpdateActorComponents();
            if (!Returning)
            {
                if (Collidable) AdvanceFalling();
                AdvanceShaking();
            }
            else
            {
                AdvanceReturn();
            }

            AdvanceVisualState();
        }

        protected void UpdateActorComponents()
        {
            base.Update();
        }

        protected void AdvanceFalling()
        {
            Speed.X = ScalarMath.Approach(Speed.X, 0f, engine.DeltaTime * 100f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (!OnGround()) Speed.Y += 400f * engine.DeltaTime;
            MoveH(Speed.X * engine.DeltaTime, onCollideH);
            MoveV(Speed.Y * engine.DeltaTime, onCollideV);
        }

        protected void AdvanceShaking()
        {
            if (Shaking && OnInterval(.05f))
            {
                Sprite.Position.X = -1 + Random.Next(3);
                Sprite.Position.Y = -1 + Random.Next(3);
            }
        }

        protected virtual Vector2 ReturnBaseScale => Vector2.One;

        protected virtual PackedColor TransitionBaseColor => PackedColor.White;

        protected void AdvanceReturn()
        {
            Position = ReturnCurve.GetPoint(((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ReturnEase),
                ((ISourceCurveEnvironment)engine).CurveArithmetic);
            ReturnEase = ScalarMath.Approach(ReturnEase, 1f, engine.DeltaTime / ReturnDuration,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Sprite.Scale = ReturnBaseScale * (1f + ReturnEase * .5f);
        }

        protected void AdvanceVisualState()
        {
            if (((ISourceTransitionScene)Scene).Transitioning)
            {
                Alpha = ScalarMath.Approach(Alpha, 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                Sprite.Color = TransitionBaseColor * Alpha;
            }

            Sprite.Rotation += Spin * ScalarMath.ClampedMap(Math.Abs(Speed.Y), 50f, 150f) * engine.DeltaTime;
        }

        public void StopMoving()
        {
            Collidable = false;
        }

        public void StartShaking()
        {
            Shaking = true;
        }

        public void ReturnHome(float duration)
        {
            if (Scene != null)
            {
                var camera = ((ISourceCameraScene)Scene).Camera;
                if (X < camera.X) X = camera.X - 8f;
                if (Y < camera.Y) Y = camera.Y - 8f;
                if (X > camera.X + 320f) X = camera.X + 320f + 8f;
                if (Y > camera.Y + 180f) Y = camera.Y + 180f + 8f;
            }

            Returning = true;
            ReturnEase = 0f;
            ReturnDuration = duration;
            var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(Home - Position);
            var control = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(Position + Home, 2f) +
                          new Vector2(vector.Y, 0f - vector.X)
                          * (SourceRandomMath.NextFloat(Random, 16f) + 16f) *
                          (SourceRandomMath.NextFloat(Random) < .5f ? -1 : 1);
            ReturnCurve = new(Position, Home, control);
        }

        private bool OnInterval(float interval)
        {
            return ((ISourceScene)Scene).SourceScene.Clock.OnInterval(interval, engine);
        }
    }
}
