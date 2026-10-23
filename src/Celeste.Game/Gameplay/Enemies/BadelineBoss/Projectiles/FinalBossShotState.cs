using Celeste.Core.Display;
using Celeste.Simulation;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles;
using Celeste.Game.Execution.Levels;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public class FinalBossShotState : FinalBossProjectileState
    {
        public global::Celeste.Graphics.Animation.Sprite Sprite;
        public global::Celeste.Scene.Components.Oscillation.SineWaveState Sine;
        public readonly PlayerColliderComponentState PlayerColliderComponent;
        public IFinalBossSource Boss;
        public RoomPlayerSession Target;
        public OriginalLevelSceneRoot Level;
        public Vector2 Speed;
        public Vector2 Anchor;
        public Vector2 Perpendicular;
        public Vector2 TargetPoint;
        public float ParticleDirection;
        public float AngleOffset;
        public float CantKillTimer;
        public float AppearTimer;
        public float SineMultiplier;
        public bool Dead;
        public bool HasBeenInCamera;

        public FinalBossShotState(ISourceEngineContext engine) : base(engine)
        {
            Sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("badeline_projectile");
            OwnedComponents.Add(Sprite);
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -2f);
            PlayerColliderComponent = new PlayerColliderComponentState(OnPlayer);
            OwnedComponents.Add(PlayerColliderComponent);
            Depth = -1000000;
            Sine = new global::Celeste.Scene.Components.Oscillation.SineWaveState(engine, 1.4f);
            OwnedComponents.Add(Sine);
        }

        public FinalBossShotState Init(IFinalBossSource boss, RoomPlayerSession target, float angleOffset = 0)
        {
            Boss = boss;
            Anchor = Position = boss.Center;
            Target = target;
            AngleOffset = angleOffset;
            Reset();
            return this;
        }

        public FinalBossShotState Init(IFinalBossSource boss, Vector2 target)
        {
            Boss = boss;
            Anchor = Position = boss.Center;
            Target = null;
            AngleOffset = 0;
            TargetPoint = target;
            Reset();
            return this;
        }

        void Reset()
        {
            Dead = HasBeenInCamera = false;
            CantKillTimer = .15f;
            AppearTimer = .1f;
            Sine.Reset();
            SineMultiplier = 0;
            Sprite.Play("charge", true);
            Speed = VectorArithmetic.SafeNormalize((Target != null ? Target.Center : TargetPoint) - Center, 100);
            if (AngleOffset != 0)
            {
                Speed = VectorArithmetic.Rotate(Speed, AngleOffset);
            }

            Perpendicular = VectorArithmetic.SafeNormalize(Vector2Geometry.Perpendicular(Speed));
            ParticleDirection = Vector2Geometry.Angle(-Speed);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Level = (OriginalLevelSceneRoot)scene;
            if (Boss.Moving) RemoveSelf();
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Level = null;
        }

        public override void Update()
        {
            base.Update();
            if (AppearTimer > 0)
            {
                Position = Anchor = Boss.ShotOrigin;
                AppearTimer -= EngineContext.DeltaTime;
                return;
            }

            if (CantKillTimer > 0) CantKillTimer -= EngineContext.DeltaTime;
            Anchor += Speed * EngineContext.DeltaTime;
            Position = Anchor + Perpendicular * SineMultiplier * Sine.Value * 3;
            SineMultiplier = ScalarMath.Approach(SineMultiplier, 1, 2 * EngineContext.DeltaTime, ExtremaArithmetic);
            if (!Dead)
            {
                bool inside = Level.IsInCamera(Position, 8);
                if (inside && !HasBeenInCamera) HasBeenInCamera = true;
                else if (!inside && HasBeenInCamera) Destroy();
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.04f, EngineContext))
                    Level.ParticlesFG.Emit(Process.ParticleTypes.FinalBossShot.P_Trail, 1, Center, Vector2.One * 2,
                        ParticleDirection);
            }
        }

        public void Destroy()
        {
            Dead = true;
            RemoveSelf();
        }

        public void OnPlayer(RoomPlayerSession player)
        {
            if (!Dead)
            {
                if (CantKillTimer > 0) Destroy();
                else player.Die(VectorArithmetic.SafeNormalize(player.Center - Position));
            }
        }

        public override void Render(ISourceRenderContext ctx)
        {
            var color = Sprite.Color;
            var position = Sprite.Position;
            Sprite.Color = Celeste.Core.Display.PackedColor.Black;
            Sprite.Position = position + new Vector2(-1f, 0f);
            Sprite.Render(ctx);
            Sprite.Position = position + new Vector2(1f, 0f);
            Sprite.Render(ctx);
            Sprite.Position = position + new Vector2(0f, -1f);
            Sprite.Render(ctx);
            Sprite.Position = position + new Vector2(0f, 1f);
            Sprite.Render(ctx);
            Sprite.Color = color;
            Sprite.Position = position;
            base.Render(ctx);
        }
    }
}
