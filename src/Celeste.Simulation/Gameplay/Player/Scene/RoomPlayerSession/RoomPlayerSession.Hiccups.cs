using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Scene;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        /// <summary>Player.cs:589 `private float hiccupTimer;`.</summary>
        public float hiccupTimer;

        /// <summary>
        ///     Player.cs:1437-1456. Called from PlayerFrameMotion.Update at the original's position:
        ///     after `climbTriggerDir = 0`, before the glider boost timer.
        /// </summary>
        public void UpdateHiccups(float deltaTime)
        {
            if (!Settings.Hiccups) return;
            if (hiccupTimer <= 0f) hiccupTimer = NextHiccupDelay();
            hiccupTimer -= Data.Motion.Ducking ? deltaTime * 0.5f : deltaTime;
            if (hiccupTimer <= 0f) HiccupJump();
        }

        // Monocle `Calc.Random.Range(float min, float max)` => NextFloat(min, max)
        //   = min + (float)Random.NextDouble() * (max - min)
        private float NextHiccupDelay()
        {
            return 1.2f +
                   (float)((ISourceHiccupScene)Scene).HiccupRandom
                   .NextDouble() * (1.8f - 1.2f);
        }

        /// <summary>
        ///     Player.cs:2364-2434. Field writes go through `Data.Motion.Normal` / `Data.Motion` directly:
        ///     `NormalMotionState` is a struct, so a `ref` local would have to be re-stored after every
        ///     mutation and the original has no such notion.
        /// </summary>
        public void HiccupJump()
        {
            switch (Machine.State)
            {
                default:
                    Machine.State = 0;
                    Data.Motion.Normal.Speed.X =
                        ScalarMath.Approach(Data.Motion.Normal.Speed.X, 0f, 40f);
                    if (Data.Motion.Normal.Speed.Y > -60f)
                    {
                        Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -60f;
                        Data.Motion.Normal.VariableJumpTimer = 0.15f;
                        Data.Motion.AutoJump = true;
                        Data.AutoJumpTimer = 0f;
                        if (Data.Motion.JumpGraceTimer > 0f) Data.Motion.JumpGraceTimer = 0.6f;
                    }

                    Sweat.Play("jump", true);
                    break;
                case 1:
                    Machine.State = 0;
                    Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -60f;
                    Data.Motion.Normal.VariableJumpTimer = 0.15f;
                    Data.Motion.Normal.Speed.X = 130f * (0 - Data.Facing);
                    Data.Motion.AutoJump = true;
                    Data.AutoJumpTimer = 0f;
                    Sweat.Play("jump", true);
                    break;
                case 19:
                    Data.Motion.Normal.Speed = VectorArithmetic.Rotate(Data.Motion.Normal.Speed,
                        Data.Motion.Normal.Speed.X > 0f ? 0.6981317f : -0.6981317f);
                    break;
                case 5:
                case 9:
                    Data.Motion.Normal.Speed = VectorArithmetic.Rotate(Data.Motion.Normal.Speed,
                        Data.Motion.Normal.Speed.X < 0f ||
                        (Data.Motion.Normal.Speed.X == 0f && Data.Motion.Normal.Speed.Y < 0f)
                            ? 0.17453292f
                            : -0.17453292f);
                    break;
                case 4:
                case 7:
                case 22:
                    Sweat.Play("jump", true);
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 21:
                case 24:
                    return;
            }

            ReportRumble(2, 0, "StrongShort", Body.Position);
            Report(RoomPlayerEventKind.Sound, Data.Motion.Ducking
                ? "event:/new_content/char/madeline/hiccup_ducking"
                : "event:/new_content/char/madeline/hiccup_standing", Body.Position);
        }
    }
}
