using System;
using System.Collections;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroSequence Intro;
        public global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType IntroType;

        public global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType LastIntroType { get; private set; } =
            global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.None;

        public global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? OverrideIntroType;


        public IEnumerator MoonLanding(Vector2 at) => Intro.MoonLanding(at);

        private sealed class IntroWorld : global::Celeste.Simulation.Gameplay.Player.Intro.IPlayerIntroWorld
        {
            private readonly RoomPlayerSession p;

            public IntroWorld(RoomPlayerSession player)
            {
                p = player;
            }

            public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite => p.Sprite;

            public Vector2 Position
            {
                get => p.Body.Position;
                set => p.Body.Position = value;
            }

            public global::Celeste.Core.Geometry.IntRect RoomBounds =>
                ((global::Celeste.Scene.Geometry.ISourceSceneBounds)p.Level).Bounds;

            public int Depth
            {
                get => p.Depth;
                set => p.Depth = value;
            }

            public bool Visible
            {
                get => p.Visible;
                set => p.Visible = value;
            }

            public float CameraX
            {
                get => ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)p.Level).CameraX;
                set => ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)p.Level).CameraX =
                    value;
            }

            public bool SolidAt(Vector2 at) => p.Body.CollideSolidAt(at);
            public bool OnGround() => p.OnGround();
            public void MoveTowardsX(float target, float maximum) => p.MoveTowardsX(target, maximum);
            public void MoveToX(float target) => p.MoveToX(target);
            public void MoveH(float amount) => p.MoveH(amount);
            public void MoveV(float amount) => p.MoveV(amount);
            public void PlaySound(string name) => p.Play(name);

            public void DirectionalShake(Vector2 direction) =>
                ((global::Celeste.Simulation.Presentation.ScreenEffects.ISourceLevelShakeScene)p.Level)
                .DirectionalShake(direction);

            public void RumbleStrongMedium() =>
                ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)p.engineContext).RumbleSession
                .Rumble(2, 1);

            public Vector2 BottomCenter => p.BottomCenter;

            public void EmitSummitLand(int type, bool background, int count, Vector2 position, Vector2 range,
                float? direction) => ((global::Celeste.Simulation.Gameplay.Player.Intro.ISourcePlayerIntroScene)p.Level)
                .EmitSummitLand(type, background, count, position, range, direction);
        }
    }
}
