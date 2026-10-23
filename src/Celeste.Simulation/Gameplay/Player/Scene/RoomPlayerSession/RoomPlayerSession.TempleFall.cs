using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // Player.TempleFallUpdate/Coroutine run in state-machine component order.
        // Ordinary Player movement still owns collisions/subpixel accumulation.
        private void BindTempleFall() => Machine.SetCallbacks(20, TempleFallUpdate, TempleFallCoroutine);

        private int TempleFallUpdate()
        {
            Data.Facing = 1;
            if (!Data.OnGround)
            {
                int target = (int)World.Contacts.RoomBounds.X + 160;
                float distance = target - Body.Position.X;
                int direction = Math.Abs(distance) > 4f ? Math.Sign(distance) : 0;
                Data.Motion.Normal.Speed.X = global::Celeste.Core.Mathematics.ScalarMath.Approach(
                    Data.Motion.Normal.Speed.X,
                    54.000004f * direction, 325f * Input.DeltaTime);
                if (Dummy.Gravity)
                    Data.Motion.Normal.Speed.Y = global::Celeste.Core.Mathematics.ScalarMath.Approach(
                        Data.Motion.Normal.Speed.Y,
                        320f, 225f * Input.DeltaTime);
            }

            return 20;
        }

        private IEnumerator TempleFallCoroutine()
        {
            Sprite.Play("fallFast");
            while (!Data.OnGround) yield return null;
            Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound,
                "event:/char/madeline/mirrortemple_big_landing", Body.Position);
            Sprite.Play(Data.Dashes <= 1 ? "fallPose" : "idle");
            Sprite.Scale.Y = Data.Motion.Normal.SpriteScaleY = .7f;
            ReportRumble(2, 1, "StrongMedium", Body.Position);
            ((global::Celeste.Simulation.Presentation.ScreenEffects.ISourceLevelShakeScene)Level)
                .DirectionalShake(Vector2.UnitY, .5f);
            Report(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Shake, "Directional",
                Body.Position, .5f, Vector2.UnitY);
            Data.Motion.Normal.Speed.X = 0f;
            global::Celeste.Core.Geometry.Bounds bounds = World.Bounds;
            var bottom = new Vector2(bounds.X + bounds.Width / 2f, bounds.Bottom);
            ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)Level).EmitSummitLand(0, false,
                12, bottom, Vector2.UnitX * 3f, -(float)Math.PI / 2f);
            ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)Level).EmitSummitLand(1, false,
                8, bottom - Vector2.UnitX * 2f, Vector2.UnitX * 2f, 3.403392f);
            ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)Level).EmitSummitLand(1, false,
                8, bottom + Vector2.UnitX * 2f, Vector2.UnitX * 2f, -(float)Math.PI / 12f);
            for (float elapsed = 0f; elapsed < 1f; elapsed += Input.DeltaTime) yield return null;
            Machine.State = 0;
        }
    }
}
