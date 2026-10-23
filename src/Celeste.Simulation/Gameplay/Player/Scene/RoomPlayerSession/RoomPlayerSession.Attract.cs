using System;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Vector2 AttractTarget { get; private set; }
        public bool AtAttractTarget => Machine.State == 22 && Body.ExactPosition == AttractTarget;
        private void BindAttract() => Machine.SetCallbacks(22, UpdateAttract, begin: BeginAttract);

        public void StartAttract(Vector2 target)
        {
            AttractTarget = new Vector2((float)Math.Round(target.X), (float)Math.Round(target.Y));
            Machine.State = 22;
        }

        private void BeginAttract() => Data.Motion.Normal.Speed = Vector2.Zero;

        private int UpdateAttract()
        {
            var exact = Body.ExactPosition;
            // FNA Distance retains the component differences in Double.
            double dx = (double)AttractTarget.X - exact.X, dy = (double)AttractTarget.Y - exact.Y;
            if ((float)Math.Sqrt(dx * dx + dy * dy) <= 1.5f)
            {
                Body.Position = AttractTarget;
                Body.Remainder.X = 0;
                Body.Remainder.Y = 0;
            }
            else
            {
                // Both states use the installed Calc.Approach(Vector2) operation.
                var target =
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engineContext).VectorArithmetic
                    .Approach(exact, AttractTarget, (float)(200.0 * Input.DeltaTime));
                // Actor.MoveTo preserves Position and its remainder separately;
                // subtracting a rounded ExactPosition loses the subpixel residual.
                MoveToX(target.X);
                MoveToY(target.Y);
            }

            return 22;
        }

        public void FinalBossPushLaunch(int direction)
        {
            Special.LaunchApproachX = null;
            Data.Motion.Normal.Speed.X = .9f * direction * 280;
            Data.Motion.Normal.Speed.Y = -150;
            Data.Motion.AutoJump = true;
            ReportRumble(2, 1, "StrongMedium", Body.Position);
            var center = Body.Position + new Vector2(Body.Hitbox.X + Body.Hitbox.Width / 2,
                Body.Hitbox.Y + Body.Hitbox.Height / 2);
            CreateDashSlash(center, global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Motion.Normal.Speed));
            Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "Slash", center,
                (float)Math.Atan2(Data.Motion.Normal.Speed.Y, Data.Motion.Normal.Speed.X), Data.Motion.Normal.Speed);
            World.RefillDash();
            RefillStamina();
            Data.CooldownTimer = .28f;
            Machine.State = 7;
        }
    }
}
