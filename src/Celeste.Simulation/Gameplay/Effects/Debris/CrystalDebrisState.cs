using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Simulation.Gameplay.Effects.Debris
{
    public class CrystalDebrisState : SourceActorEntityState
    {
        public SpriteImage Image;
        public float Percent;
        public float Duration;
        public Vector2 Speed;
        public PackedColor Color;
        public bool BossShatter;

        public CrystalDebrisState(AtlasData atlas, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(new(null, Vector2.Zero), engine, targetMotionPolicy)
        {
            Engine = engine;
            Position = Vector2.Zero;
            Depth = -9990;
            Collider = new HitboxColliderGeometry(2f, 2f, -1f, -1f);
            CollisionH = OnCollideH;
            CollisionV = OnCollideV;
            Image = new(atlas.Entries["particles/shard"]);
            Image.CenterOrigin();
            OwnedComponents.Add(Image);
        }

        protected void Init(Vector2 position, PackedColor color, bool boss)
        {
            Init(position, color, boss, null);
        }

        protected void Init(Vector2 position, PackedColor color, bool boss, float? fixedDuration)
        {
            Position = position;
            Image.Color = Color = color;
            Image.Scale = Vector2.One;
            Percent = 0f;
            CrystalDebrisPhysics.Initialize(((ISourceRandomEnvironment)Engine).Random, boss, fixedDuration,
                out Duration, out Speed);
            BossShatter = boss;
        }

        protected ISourceEngineContext Engine { get; }

        protected SourceCollisionHandler CollisionH { get; }

        protected SourceCollisionHandler CollisionV { get; }

        public override void Update()
        {
            base.Update();
            if (!AdvancePhysics()) return;
            MoveH(Speed.X * Engine.DeltaTime, CollisionH);
            MoveV(Speed.Y * Engine.DeltaTime, CollisionV);
            EmitDust();
        }

        protected bool AdvancePhysics()
        {
            if (!CrystalDebrisPhysics.Advance(ref Speed, ref Percent, Duration, BossShatter, Engine.DeltaTime,
                    ((ISourceVectorEnvironment)Engine).VectorArithmetic,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic, out var scale, out var rotation))
            {
                RemoveSelf();
                return false;
            }

            if (rotation.HasValue) Image.Rotation = rotation.Value;
            Image.Scale = scale;
            return true;
        }

        protected void EmitDust()
        {
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.05f, Engine))
                ((ISourceForegroundParticleScene)Scene).ForegroundParticles.Emit(
                    ((ICrystalDebrisParticleEnvironment)Engine).Dust, Position);
        }

        public override void Render(ISourceRenderContext context)
        {
            var color = Image.Color;
            Image.Color = PackedColor.Black;
            Image.Position = new(-1f, 0f);
            Image.Render(context);
            Image.Position = new(0f, -1f);
            Image.Render(context);
            Image.Position = new(1f, 0f);
            Image.Render(context);
            Image.Position = new(0f, 1f);
            Image.Render(context);
            Image.Position = Vector2.Zero;
            Image.Color = color;
            base.Render(context);
        }

        private void OnCollideH(PixelCollision hit)
        {
            CrystalDebrisPhysics.BounceHorizontal(ref Speed);
        }

        private void OnCollideV(PixelCollision hit)
        {
            if (!CrystalDebrisPhysics.BounceVertical(ref Speed, BossShatter,
                    ((ISourceRandomEnvironment)Engine).Random))
                RemoveSelf();
        }

        public static void Burst(ISourceEngineContext engine, Vector2 position,
            PackedColor color, bool boss, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                var piece = engine.EntityPools.Create<CrystalDebrisState>();
                var at = position +
                         new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4),
                             SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4));
                piece.Init(at, color, boss);
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(piece);
            }
        }
    }
}
