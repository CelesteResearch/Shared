using System;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Scene.Geometry;

namespace Celeste.Simulation.Gameplay.Player.Respawn
{
    public sealed class PlayerRespawnSequence
    {
        private readonly RoomPlayerSession player;
        public RoomPlayerSession Player => player;
        private SourceTweenState respawnTween;
        public Vector2 DeadOffset { get; private set; }

        public float IntroEase { get; private set; }

        // Existing TAS IntroRespawnEnd detour functionality; admission requires its
        // actual hook registration, independently of the original source body below.
        public event Action Ended;

        public PlayerRespawnSequence(RoomPlayerSession player)
        {
            this.player = player;
            player.Machine.SetCallbacks(14, null, begin: Begin, end: End);
        }

        private void Begin()
        {
            player.Play("event:/char/madeline/revive");
            player.Depth = -1000000;
            IntroEase = 1f;
            Vector2 from = player.Position;
            var level = (ISourceSceneBounds)player.Level;
            from.X = ScalarMath.Clamp(from.X, (float)level.Bounds.Left + 40f, (float)level.Bounds.Right - 40f);
            from.Y = ScalarMath.Clamp(from.Y, (float)level.Bounds.Top + 40f, (float)level.Bounds.Bottom - 40f);
            DeadOffset = from;
            from -= player.Position;
            respawnTween = SourceTweenState.Create(player.EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot, null, .6f, start: true);
            respawnTween.OnUpdate = t =>
            {
                DeadOffset = Vector2Interpolation.Lerp(from, Vector2.Zero, t.Eased,
                    ((ISourceScalarEnvironment)player.EngineContext).ScalarArithmetic);
                IntroEase = 1f - t.Eased;
            };
            respawnTween.OnComplete = t =>
            {
                if (player.Machine.State == 14)
                {
                    player.Machine.State = 0;
                    player.Sprite.Scale = new Vector2(1.5f, .5f);
                }
            };
            player.Components.Add(respawnTween);
        }

        private void End()
        {
            player.Depth = 0;
            DeadOffset = Vector2.Zero;
            player.Components.Remove(respawnTween);
            respawnTween = null;
            Ended?.Invoke();
        }
    }
}
