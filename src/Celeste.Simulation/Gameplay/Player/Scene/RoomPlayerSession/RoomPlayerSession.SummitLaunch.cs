using System;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public float SummitLaunchTargetX { get; private set; }
        public float SummitLaunchParticleTimer { get; private set; }
        public Action<int, Vector2, Vector2> EmitSummitBoostMove;

        private Vector2 SummitCenter => Center;

        private void BindSummitLaunch() => Machine.SetCallbacks(10, UpdateSummitLaunch, begin: BeginSummitLaunch);

        public void BadelineBoostLaunch(float atX)
        {
            Special.LaunchApproachX = atX;
            Data.Motion.Normal.Speed.X = 0;
            Data.Motion.Normal.Speed.Y = -330;
            Data.Motion.AutoJump = true;
            if (Holding.Holding != null) Holding.Drop();
            CreateDashSlash(SummitCenter,
                global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Motion.Normal.Speed));
            Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "Slash", SummitCenter,
                (float)Math.Atan2(Data.Motion.Normal.Speed.Y, Data.Motion.Normal.Speed.X), Data.Motion.Normal.Speed);
            World.RefillDash();
            RefillStamina();
            Data.CooldownTimer = .2f;
            Machine.State = 7;
        }

        public void SummitLaunch(float targetX)
        {
            SummitLaunchTargetX = targetX;
            Machine.State = 10;
        }

        private void BeginSummitLaunch()
        {
            Data.Motion.WallBoostTimer = 0;
            Sprite.Play("launch");
            Data.Motion.Normal.Speed = -Vector2.UnitY * 240;
            SummitLaunchParticleTimer = .4f;
        }

        private int UpdateSummitLaunch()
        {
            float dt = engineContext.DeltaTime;
            SummitLaunchParticleTimer -= dt;
            if (SummitLaunchParticleTimer > 0 && World.OnInterval(.03f))
                EmitSummitBoostMove?.Invoke(1, SummitCenter, Vector2.One * 4);
            Data.Facing = 1;
            World.MoveTowardsX(SummitLaunchTargetX, 20 * dt);
            Data.Motion.Normal.Speed = -Vector2.UnitY * 240;
            if (((global::Celeste.Scene.Tracking.ISourceScene)Level).SourceScene.Clock.OnInterval(.2f, engineContext))
                World.SpeedRingUp();
            var spinner = global::Celeste.Simulation.Gameplay.Collision.SourceSceneCollisionQueries
                .First<global::Celeste.Simulation.Gameplay.Hazards.IDestructibleHazard>(
                    new global::Celeste.Core.Geometry.IntRect((int)(Position.X - 4), (int)(Position.Y - 40), 8, 12),
                    ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntities("Celeste.CrystalStaticSpinner"));
            if (spinner != null)
            {
                spinner.Destroy();
                ((global::Celeste.Simulation.Presentation.ScreenEffects.ISourceLevelShakeScene)Level).Shake();
                ReportRumble(1, 0, "MediumShort", Body.Position);
                Freeze(.01f);
            }

            return 10;
        }

        public void StopSummitLaunch()
        {
            Machine.State = 0;
            Data.Motion.Normal.Speed.Y = -140;
            Data.Motion.AutoJump = true;
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
        }
    }
}
