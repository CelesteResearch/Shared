using System;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Scene.Geometry;

namespace Celeste.Simulation.Gameplay.Player.Respawn
{
    public sealed class PlayerRespawnSequence
    {
        public RoomPlayerSession Player { get; }

        private SourceTweenState respawnTween;
        public Vector2 DeadOffset { get; private set; }

        public float IntroEase { get; private set; }

        // Existing TAS IntroRespawnEnd detour functionality; admission requires its
        // actual hook registration, independently of the original source body below.
        public event Action Ended;

        public PlayerRespawnSequence(RoomPlayerSession player)
        {
            Player = player;
            player.Machine.SetCallbacks(14, null, begin: Begin, end: End);
        }

        private void Begin()
        {
            Player.Play("event:/char/madeline/revive");
            Player.Depth = -1000000;
            IntroEase = 1f;
            var from = Player.Position;
            var level = (ISourceSceneBounds)Player.Level;
            from.X = ScalarMath.Clamp(from.X, level.Bounds.Left + 40f, level.Bounds.Right - 40f);
            from.Y = ScalarMath.Clamp(from.Y, level.Bounds.Top + 40f, level.Bounds.Bottom - 40f);
            DeadOffset = from;
            from -= Player.Position;
            respawnTween = SourceTweenState.Create(Player.EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot, null, .6f, true);
            respawnTween.OnUpdate = t =>
            {
                DeadOffset = Vector2Interpolation.Lerp(from, Vector2.Zero, t.Eased,
                    ((ISourceScalarEnvironment)Player.EngineContext).ScalarArithmetic);
                IntroEase = 1f - t.Eased;
            };
            respawnTween.OnComplete = t =>
            {
                if (Player.Machine.State == 14)
                {
                    Player.Machine.State = 0;
                    Player.Sprite.Scale = new(1.5f, .5f);
                }
            };
            Player.Components.Add(respawnTween);
        }

        private void End()
        {
            Player.Depth = 0;
            DeadOffset = Vector2.Zero;
            Player.Components.Remove(respawnTween);
            respawnTween = null;
            Ended?.Invoke();
        }
    }
}
