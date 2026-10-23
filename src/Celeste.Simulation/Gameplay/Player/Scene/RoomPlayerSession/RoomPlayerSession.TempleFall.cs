using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.ScreenEffects;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // Player.TempleFallUpdate/Coroutine run in state-machine component order.
        // Ordinary Player movement still owns collisions/subpixel accumulation.
        private void BindTempleFall()
        {
            Machine.SetCallbacks(20, TempleFallUpdate, TempleFallCoroutine);
        }

        private int TempleFallUpdate()
        {
            Data.Facing = 1;
            if (!Data.OnGround)
            {
                var target = World.Contacts.RoomBounds.X + 160;
                var distance = target - Body.Position.X;
                var direction = Math.Abs(distance) > 4f ? Math.Sign(distance) : 0;
                Data.Motion.Normal.Speed.X = ScalarMath.Approach(
                    Data.Motion.Normal.Speed.X,
                    54.000004f * direction, 325f * Input.DeltaTime);
                if (Dummy.Gravity)
                    Data.Motion.Normal.Speed.Y = ScalarMath.Approach(
                        Data.Motion.Normal.Speed.Y,
                        320f, 225f * Input.DeltaTime);
            }

            return 20;
        }

        private IEnumerator TempleFallCoroutine()
        {
            Sprite.Play("fallFast");
            while (!Data.OnGround) yield return null;
            Report(RoomPlayerEventKind.Sound,
                "event:/char/madeline/mirrortemple_big_landing", Body.Position);
            Sprite.Play(Data.Dashes <= 1 ? "fallPose" : "idle");
            Sprite.Scale.Y = Data.Motion.Normal.SpriteScaleY = .7f;
            ReportRumble(2, 1, "StrongMedium", Body.Position);
            ((ISourceLevelShakeScene)Level)
                .DirectionalShake(Vector2.UnitY, .5f);
            Report(RoomPlayerEventKind.Shake, "Directional",
                Body.Position, .5f, Vector2.UnitY);
            Data.Motion.Normal.Speed.X = 0f;
            var bounds = World.Bounds;
            var bottom = new Vector2(bounds.X + bounds.Width / 2f, bounds.Bottom);
            ((ISourcePlayerIntroScene)Level).EmitSummitLand(0, false,
                12, bottom, Vector2.UnitX * 3f, -(float)Math.PI / 2f);
            ((ISourcePlayerIntroScene)Level).EmitSummitLand(1, false,
                8, bottom - Vector2.UnitX * 2f, Vector2.UnitX * 2f, 3.403392f);
            ((ISourcePlayerIntroScene)Level).EmitSummitLand(1, false,
                8, bottom + Vector2.UnitX * 2f, Vector2.UnitX * 2f, -(float)Math.PI / 12f);
            for (var elapsed = 0f; elapsed < 1f; elapsed += Input.DeltaTime) yield return null;
            Machine.State = 0;
        }
    }
}
