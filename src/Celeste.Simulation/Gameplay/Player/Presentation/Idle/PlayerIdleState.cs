using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Idle
{
    // Candidate only: invoke BeforeComponents at Player.Update's original idleTimer site.
    public sealed class PlayerIdleState
    {
        private readonly IPlayerIdleWorld world;
        private PlayerSprite sprite => world.Sprite;
        private ISourceAudioEventReference idleSound;
        public float Timer { get; private set; }

        public PlayerIdleState(IPlayerIdleWorld world)
        {
            this.world = world;
        }

        public void BeforeComponents(float dt, Vector2 speed)
        {
            Timer += dt;
            if (world.InCutscene) Timer = -5;
            else if (speed.X != 0 || speed.Y != 0) Timer = 0;
        }

        public void OnLastFrame(string animation)
        {
            if (!world.ScenePresent || world.Dead || sprite.CurrentAnimationID != "idle" || world.InCutscene ||
                !(Timer > 3) || !((float)world.Random.NextDouble() < .2f)) return;
            var normal = sprite.Mode == PlayerSpriteMode.Madeline;
            var choice = world.Random.NextDouble() * (normal ? world.CoreHot ? 8 : 9 : 7);
            var next = normal
                ? choice < 5 ? "idleA" : choice < 8 ? "idleB" : "idleC"
                : choice < 1
                    ? "idleA"
                    : choice < 4
                        ? "idleB"
                        : "idleC";
            if (!sprite.Has(next)) return;
            sprite.Play(next);
            if (normal)
            {
                if (next == "idleB") idleSound = world.PlaySound("event:/char/madeline/idle_scratch");
                else if (next == "idleC") idleSound = world.PlaySound("event:/char/madeline/idle_sneeze");
            }
            else if (next == "idleA")
            {
                idleSound = world.PlaySound("event:/char/madeline/idle_crackknuckles");
            }
        }

        public void OnChange(string previous, string next)
        {
            if ((previous == "idleB" || previous == "idleC") && next != null && !next.StartsWith("idle") &&
                idleSound != null) world.StopSound(idleSound);
        }
    }
}
