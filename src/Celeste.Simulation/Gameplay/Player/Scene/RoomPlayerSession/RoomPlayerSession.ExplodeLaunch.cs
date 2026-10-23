using System;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Vector2 ExplodeLaunch(Vector2 from, bool snapUp = true, bool sidesOnly = false)
        {
            ReportRumble(2, 1, "StrongMedium", Body.Position);
            Freeze(.1f);
            Special.LaunchApproachX = null;
            var center = Center;
            Vector2 direction = center - from;
            if (direction == Vector2.Zero) direction = -Vector2.UnitY;
            else direction = VectorArithmetic.Normalize(direction);

            float dot = VectorArithmetic.Dot(direction, Vector2.UnitY);
            if (snapUp && dot <= -.7f)
            {
                direction.X = 0;
                direction.Y = -1;
            }
            else if (dot <= .65f && dot >= -.55f)
            {
                direction.Y = 0;
                direction.X = Math.Sign(direction.X);
            }

            if (sidesOnly && direction.X != 0)
            {
                direction.Y = 0;
                direction.X = Math.Sign(direction.X);
            }

            Data.Motion.Normal.Speed = 280f * direction;
            if (Data.Motion.Normal.Speed.Y <= 50)
            {
                Data.Motion.Normal.Speed.Y = Math.Min(-150, Data.Motion.Normal.Speed.Y);
                Data.Motion.AutoJump = true;
            }

            if (Data.Motion.Normal.Speed.X != 0)
            {
                if (Input.MoveX.Value == Math.Sign(Data.Motion.Normal.Speed.X))
                {
                    Data.ExplodeLaunchBoostTimer = 0;
                    Data.Motion.Normal.Speed.X *= 1.2f;
                }
                else
                {
                    Data.ExplodeLaunchBoostTimer = .01f;
                    Data.ExplodeLaunchBoostSpeed = Data.Motion.Normal.Speed.X * 1.2f;
                }
            }

            center = Center;
            CreateDashSlash(center, global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Motion.Normal.Speed));
            Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash, "Slash", center,
                global::Celeste.Core.Mathematics.Vector2Geometry.Angle(Data.Motion.Normal.Speed),
                Data.Motion.Normal.Speed);
            if (!World.NoRefills) World.RefillDash();
            RefillStamina();
            Data.CooldownTimer = .2f;
            Machine.State = 7;
            return direction;
        }
    }
}
