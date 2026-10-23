using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Gameplay.Effects.Debris
{
    public class CrystalDebrisState : SourceActorEntityState
    {
        public SpriteImage Image;
        private readonly ISourceEngineContext engine;
        private global::Celeste.Physics.Collision.SourceCollisionHandler collideH;
        private global::Celeste.Physics.Collision.SourceCollisionHandler collideV;
        public float Percent;
        public float Duration;
        public Vector2 Speed;
        public PackedColor Color;
        public bool BossShatter;

        public CrystalDebrisState(AtlasData atlas, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(new PixelActor(null, Vector2.Zero), engine, targetMotionPolicy)
        {
            this.engine = engine;
            Position = Vector2.Zero;
            Depth = -9990;
            Collider = new HitboxColliderGeometry(2f, 2f, -1f, -1f);
            collideH = OnCollideH;
            collideV = OnCollideV;
            Image = new SpriteImage(atlas.Entries["particles/shard"]);
            Image.CenterOrigin();
            OwnedComponents.Add(Image);
        }

        protected void Init(Vector2 position, PackedColor color, bool boss)
            => Init(position, color, boss, null);

        protected void Init(Vector2 position, PackedColor color, bool boss, float? fixedDuration)
        {
            Position = position;
            Image.Color = Color = color;
            Image.Scale = Vector2.One;
            Percent = 0f;
            CrystalDebrisPhysics.Initialize(((ISourceRandomEnvironment)engine).Random, boss, fixedDuration,
                out Duration, out Speed);
            BossShatter = boss;
        }

        protected ISourceEngineContext Engine => engine;
        protected SourceCollisionHandler CollisionH => collideH;
        protected SourceCollisionHandler CollisionV => collideV;

        public override void Update()
        {
            base.Update();
            if (!AdvancePhysics()) return;
            MoveH(Speed.X * engine.DeltaTime, collideH);
            MoveV(Speed.Y * engine.DeltaTime, collideV);
            EmitDust();
        }

        protected bool AdvancePhysics()
        {
            if (!CrystalDebrisPhysics.Advance(ref Speed, ref Percent, Duration, BossShatter, engine.DeltaTime,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic, out var scale, out var rotation))
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
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.05f, engine))
                ((ISourceForegroundParticleScene)Scene).ForegroundParticles.Emit(
                    ((ICrystalDebrisParticleEnvironment)engine).Dust, Position);
        }

        public override void Render(ISourceRenderContext context)
        {
            PackedColor color = Image.Color;
            Image.Color = PackedColor.Black;
            Image.Position = new Vector2(-1f, 0f);
            Image.Render(context);
            Image.Position = new Vector2(0f, -1f);
            Image.Render(context);
            Image.Position = new Vector2(1f, 0f);
            Image.Render(context);
            Image.Position = new Vector2(0f, 1f);
            Image.Render(context);
            Image.Position = Vector2.Zero;
            Image.Color = color;
            base.Render(context);
        }

        private void OnCollideH(PixelCollision hit) => CrystalDebrisPhysics.BounceHorizontal(ref Speed);

        private void OnCollideV(PixelCollision hit)
        {
            if (!CrystalDebrisPhysics.BounceVertical(ref Speed, BossShatter,
                    ((ISourceRandomEnvironment)engine).Random))
                RemoveSelf();
        }

        public static void Burst(ISourceEngineContext engine, Vector2 position,
            PackedColor color, bool boss, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                var piece = engine.EntityPools.Create<CrystalDebrisState>();
                Vector2 at = position +
                             new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4),
                                 SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4));
                piece.Init(at, color, boss);
                ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(piece);
            }
        }
    }
}
