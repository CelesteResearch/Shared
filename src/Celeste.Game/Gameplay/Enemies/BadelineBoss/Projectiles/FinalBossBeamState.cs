using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public class FinalBossBeamState : FinalBossProjectileState
    {
        public Sprite BeamSprite, BeamStartSprite;

        private readonly SourceVertexPositionColor[] fade =
            new SourceVertexPositionColor[24];

        public IFinalBossSource Boss;
        public RoomPlayerSession Player;
        public float ChargeTimer;
        public float FollowTimer;
        public float ActiveTimer;
        public float Angle;
        public float BeamAlpha;
        public float SideFadeAlpha;

        public FinalBossBeamState(ISourceEngineContext engine) : base(engine)
        {
            BeamSprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("badeline_beam");
            OwnedComponents.Add(BeamSprite);
            BeamSprite.OnLastFrame = anim =>
            {
                if (anim == "shoot") Destroy();
            };
            BeamStartSprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("badeline_beam_start");
            OwnedComponents.Add(BeamStartSprite);
            BeamSprite.Visible = false;
            Depth = -1000000;
        }

        public FinalBossBeamState Init(IFinalBossSource boss, RoomPlayerSession target)
        {
            Boss = boss;
            ChargeTimer = 1.4f;
            FollowTimer = .9f;
            ActiveTimer = .12f;
            BeamSprite.Play("charge");
            SideFadeAlpha = BeamAlpha = 0;
            var sign = target.Position.Y <= boss.Position.Y + 16 ? 1 : -1;
            if (target.Position.X >= boss.Position.X) sign *= -1;
            Angle = Vector2Geometry.Angle(target.Center - boss.BeamOrigin);
            var to = Vector2Geometry.ClosestPointOnLine(boss.BeamOrigin,
                boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 2000), target.Center, VectorArithmetic);
            to += VectorArithmetic.SafeNormalize(Vector2Geometry.Perpendicular(target.Center - boss.BeamOrigin), 100) *
                  sign;
            Angle = Vector2Geometry.Angle(to - boss.BeamOrigin);
            return this;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Boss.Moving) RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            var players =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);

            Player = players.Count > 0 ? (RoomPlayerSession)players[0] : null;
            BeamAlpha = ScalarMath.Approach(BeamAlpha, 1, 2 * EngineContext.DeltaTime, ExtremaArithmetic);
            if (ChargeTimer > 0)
            {
                SideFadeAlpha = ScalarMath.Approach(SideFadeAlpha, 1, EngineContext.DeltaTime, ExtremaArithmetic);
                if (Player != null && !Player.Dead)
                {
                    FollowTimer -= EngineContext.DeltaTime;
                    ChargeTimer -= EngineContext.DeltaTime;
                    if (FollowTimer > 0 && Player.Center != Boss.BeamOrigin)
                    {
                        var val = Vector2Geometry.ClosestPointOnLine(Boss.BeamOrigin,
                            Boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 2000), Player.Center,
                            VectorArithmetic);
                        val = VectorArithmetic.Approach(val, Player.Center, 200 * EngineContext.DeltaTime);
                        Angle = Vector2Geometry.Angle(val - Boss.BeamOrigin);
                    }
                    else if (BeamSprite.CurrentAnimationID == "charge")
                    {
                        BeamSprite.Play("lock");
                    }

                    if (ChargeTimer <= 0)
                    {
                        CurrentLevel.DirectionalShake(Vector2Geometry.AngleToVector(Angle, 1), .15f);
                        ((ISourceRumbleEnvironment)EngineContext).RumbleSession
                            .Rumble(1, 1);
                        DissipateParticles();
                    }
                }
            }
            else if (ActiveTimer > 0)
            {
                SideFadeAlpha = ScalarMath.Approach(SideFadeAlpha, 0, EngineContext.DeltaTime * 8, ExtremaArithmetic);
                if (BeamSprite.CurrentAnimationID != "shoot")
                {
                    BeamSprite.Play("shoot");
                    BeamStartSprite.Play("shoot", true);
                }

                ActiveTimer -= EngineContext.DeltaTime;
                if (ActiveTimer > 0) PlayerCollideCheck();
            }
        }

        private void DissipateParticles()
        {
            var center = ((ISourceCameraScene)Scene).Camera.Position + new Vector2(160, 90);
            var from = Boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 12);
            var to = Boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 2000);
            var perp = VectorArithmetic.SafeNormalize(Vector2Geometry.Perpendicular(to - from));
            var along = VectorArithmetic.SafeNormalize(to - from);
            var distance = VectorArithmetic.Distance(center, from) - 12f;
            center = Vector2Geometry.ClosestPointOnLine(from, to, center, VectorArithmetic);
            FinalBossBeamParticles.Emit(new BeamParticleState(this), center, along, perp, distance);
        }

        private void PlayerCollideCheck()
        {
            var from = Boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 12);
            var to = Boss.BeamOrigin + Vector2Geometry.AngleToVector(Angle, 2000);
            var perp = VectorArithmetic.SafeNormalize(Vector2Geometry.Perpendicular(to - from), 2);
            var player = SourceSceneCollision.FirstLine<RoomPlayerSession>(
                             ((ISourceScene)Scene).SourceScene.Entities,
                             typeof(RoomPlayerSession).FullName, from + perp, to + perp) ??
                         SourceSceneCollision.FirstLine<RoomPlayerSession>(
                             ((ISourceScene)Scene).SourceScene.Entities,
                             typeof(RoomPlayerSession).FullName, from - perp, to - perp) ??
                         SourceSceneCollision.FirstLine<RoomPlayerSession>(
                             ((ISourceScene)Scene).SourceScene.Entities,
                             typeof(RoomPlayerSession).FullName, from, to);

            player?.Die(VectorArithmetic.SafeNormalize(player.Center - Boss.BeamOrigin));
        }

        public void Destroy()
        {
            RemoveSelf();
        }

        public override void Render(ISourceRenderContext ctx)
        {
            FinalBossBeamDrawing.Render(new BeamDrawingState(this), ctx);
        }

        private readonly struct BeamDrawingState : IFinalBossBeamDrawingState
        {
            private readonly FinalBossBeamState owner;

            public BeamDrawingState(FinalBossBeamState owner)
            {
                this.owner = owner;
            }

            public ISourceEngineContext EngineContext => owner.EngineContext;
            public object Scene => owner.Scene;
            public Vector2 BeamOrigin => owner.Boss.BeamOrigin;
            public float Angle => owner.Angle;
            public Sprite BeamSprite => owner.BeamSprite;
            public Sprite StartSprite => owner.BeamStartSprite;
            public float BeamAlpha => owner.BeamAlpha;
            public float SideFadeAlpha => owner.SideFadeAlpha;
            public SourceVertexPositionColor[] Fade => owner.fade;
            public ISourceVectorArithmetic VectorArithmetic => owner.VectorArithmetic;
        }

        private readonly struct BeamParticleState : IFinalBossBeamParticleState
        {
            private readonly FinalBossBeamState owner;

            public BeamParticleState(FinalBossBeamState owner)
            {
                this.owner = owner;
            }

            public ParticleSystemPresentation ParticleSystem =>
                owner.CurrentLevel.ParticlesFG;

            public ParticleTypePresentation ParticleType =>
                owner.Process.ParticleTypes.FinalBossBeam.P_Dissipate;

            public ISourceRandom Random => owner.ProcessRandom;
        }
    }
}
