using System.Collections;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Geometry;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.ScreenEffects;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public readonly PlayerIntroSequence Intro;
        public PlayerIntroType IntroType;

        public PlayerIntroType LastIntroType { get; private set; } =
            PlayerIntroType.None;

        public PlayerIntroType? OverrideIntroType;


        public IEnumerator MoonLanding(Vector2 at)
        {
            return Intro.MoonLanding(at);
        }

        private sealed class IntroWorld : IPlayerIntroWorld
        {
            private readonly RoomPlayerSession p;

            public IntroWorld(RoomPlayerSession player)
            {
                p = player;
            }

            public PlayerSprite Sprite => p.Sprite;

            public Vector2 Position
            {
                get => p.Body.Position;
                set => p.Body.Position = value;
            }

            public IntRect RoomBounds =>
                ((ISourceSceneBounds)p.Level).Bounds;

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
                get => ((ISourcePlayerIntroScene)p.Level).CameraX;
                set => ((ISourcePlayerIntroScene)p.Level).CameraX =
                    value;
            }

            public bool SolidAt(Vector2 at)
            {
                return p.Body.CollideSolidAt(at);
            }

            public bool OnGround()
            {
                return p.OnGround();
            }

            public void MoveTowardsX(float target, float maximum)
            {
                p.MoveTowardsX(target, maximum);
            }

            public void MoveToX(float target)
            {
                p.MoveToX(target);
            }

            public void MoveH(float amount)
            {
                p.MoveH(amount);
            }

            public void MoveV(float amount)
            {
                p.MoveV(amount);
            }

            public void PlaySound(string name)
            {
                p.Play(name);
            }

            public void DirectionalShake(Vector2 direction)
            {
                ((ISourceLevelShakeScene)p.Level)
                    .DirectionalShake(direction);
            }

            public void RumbleStrongMedium()
            {
                ((ISourceRumbleEnvironment)p.EngineContext).RumbleSession
                    .Rumble(2, 1);
            }

            public Vector2 BottomCenter => p.BottomCenter;

            public void EmitSummitLand(int type, bool background, int count, Vector2 position, Vector2 range,
                float? direction)
            {
                ((ISourcePlayerIntroScene)p.Level)
                    .EmitSummitLand(type, background, count, position, range, direction);
            }
        }
    }
}
