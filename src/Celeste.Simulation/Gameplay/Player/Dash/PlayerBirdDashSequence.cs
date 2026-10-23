using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public sealed class PlayerBirdDashSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly ISourceGameInput input;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        private readonly PixelActor body;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBirdDashWorld world;

        public PlayerBirdDashSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            ISourceGameInput input, PixelActor body,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBirdDashWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
            this.data = data;
            this.input = input;
            this.body = body;
            this.dash = dash;
            this.world = world;
            machine.SetCallbacks(16, Update, Coroutine, Begin);
        }

        private float DeltaTime => input.DeltaTime;

        private Vector2 Center => body.Position +
                                  new Vector2(body.Hitbox.X + body.Hitbox.Width / 2,
                                      body.Hitbox.Y + body.Hitbox.Height / 2);

        private Vector2 BottomCenter =>
            body.Position + new Vector2(body.Hitbox.X + body.Hitbox.Width / 2, body.Hitbox.Bottom);

        public void Begin()
        {
            dash.Begin();
            world.PlaySound("event:/char/madeline/dash_red_right");
            world.PlaySprite("dash");
        }

        public int Update() => 16;

        public IEnumerator Coroutine()
        {
            yield return null;
            world.CreateTrail();
            world.AddTrailAlarm(.08f);
            world.AddTrailAlarm(.15f);
            Vector2 direction = Vector2.Normalize(new Vector2(1, -1));
            data.Facing = 1;
            data.Motion.Normal.Speed = direction * 240f;
            data.Direction = direction;
            world.DirectionalShake(data.Direction, .2f);
            world.Slash(Center, (float)Math.Atan2(data.Direction.Y, data.Direction.X));
            for (float time = 0; time < .15f; time += DeltaTime)
            {
                if (data.Motion.Normal.Speed != Vector2.Zero && world.OnInterval(.02f))
                    world.EmitDashParticle(Center, Vector2.One * 2,
                        (float)Math.Atan2(data.Direction.Y, data.Direction.X));
                yield return null;
            }

            data.Motion.AutoJump = true;
            data.AutoJumpTimer = 0;
            if (data.Direction.Y <= 0) data.Motion.Normal.Speed = data.Direction * 160f;
            if (data.Motion.Normal.Speed.Y < 0) data.Motion.Normal.Speed.Y *= .75f;
            world.PlaySprite("fallFast");
            bool climbing = false;
            while (!world.OnGround() && !climbing)
            {
                data.Motion.Normal.Speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(
                    data.Motion.Normal.Speed.Y, 160, 900f * DeltaTime,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (world.SolidAt(new Vector2(1, 0))) climbing = true;
                if (body.BoundsAt(body.Position).Y > world.LevelBottom)
                {
                    world.CancelCutscene();
                    world.Die(Vector2.Zero);
                }

                yield return null;
            }

            if (climbing)
            {
                world.PlaySprite("wallslide");
                world.DustBurst(body.Position + new Vector2(4, -6), (float)Math.Atan2(0, -4), 1);
                data.Motion.Normal.Speed.Y = 0;
                yield return .2f;
                world.PlaySprite("climbUp");
                while (world.SolidAt(new Vector2(1, 0)))
                {
                    body.Position.Y += -45f * DeltaTime;
                    yield return null;
                }

                body.Position.Y = (float)Math.Round(body.Position.Y);
                world.PlaySound("event:/char/madeline/climb_ledge");
                world.PlaySprite("jumpFast");
                data.Motion.Normal.Speed.Y = -105;
                while (!world.OnGround())
                {
                    data.Motion.Normal.Speed.Y =
                        global::Celeste.Core.Mathematics.ScalarMath.Approach(data.Motion.Normal.Speed.Y, 160,
                            900f * DeltaTime,
                            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine)
                            .ExtremaArithmetic);
                    data.Motion.Normal.Speed.X = 20;
                    yield return null;
                }

                data.Motion.Normal.Speed = Vector2.Zero;
                world.PlaySprite("walk");
                for (float time = 0; time < .5f; time += DeltaTime)
                {
                    body.Position.X += 32f * DeltaTime;
                    yield return null;
                }

                world.PlaySprite("tired");
                yield break;
            }

            world.PlaySprite("tired");
            data.Motion.Normal.Speed.Y = 0;
            while (data.Motion.Normal.Speed.X != 0)
            {
                data.Motion.Normal.Speed.X = global::Celeste.Core.Mathematics.ScalarMath.Approach(
                    data.Motion.Normal.Speed.X, 0, 240f * DeltaTime,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (world.OnInterval(.04f))
                    world.DustBurst(BottomCenter + new Vector2(0, -2), (float)Math.PI * -3f / 4f, 1);
                yield return null;
            }
        }
    }
}
