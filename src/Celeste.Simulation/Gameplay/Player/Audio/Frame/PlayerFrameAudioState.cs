using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Audio.Frame
{
    public sealed class PlayerFrameAudioState
    {
        private PlayerSprite sprite => world.Sprite;
        private readonly IPlayerFrameAudioWorld world;

        public PlayerFrameAudioState(
            IPlayerFrameAudioWorld world)
        {
            this.world = world;
        }

        public void OnFrameChange(string animation)
        {
            if (!world.ScenePresent || world.Dead || !sprite.Visible) return;
            var frame = sprite.CurrentAnimationFrame;
            var step = ((animation.Equals("runSlow_carry") || animation.Equals("runFast")
                                                           || animation.Equals("runSlow") || animation.Equals("walk")
                                                           || animation.Equals("runWind") ||
                                                           animation.Equals("carryTheoWalk")) &&
                        (frame == 0 || frame == 6))
                       || (animation.Equals("runStumble") && frame == 6)
                       || (animation.Equals("flip") && frame == 4)
                       || (animation.Equals("idleC") && sprite.Mode == PlayerSpriteMode.MadelineNoBackpack
                                                     && (frame == 3 || frame == 6 || frame == 8 || frame == 11))
                       || (animation.Equals("push") && (frame == 8 || frame == 15));
            if (step)
            {
                var surface = world.StepSurface();
                if (surface.HasValue) world.PlaySound("event:/char/madeline/footstep", "surface_index", surface.Value);
            }
            else if ((animation.Equals("climbUp") || animation.Equals("climbDown")) && frame == 5)
            {
                var surface = world.WallSurface(world.Facing);
                if (surface.HasValue) world.PlaySound("event:/char/madeline/handhold", "surface_index", surface.Value);
            }
            else if (animation.Equals("wakeUp") && frame == 19)
            {
                world.PlaySound("event:/char/madeline/campfire_stand");
            }
            else if (animation.Equals("sitDown") && frame == 12)
            {
                world.PlaySound("event:/char/madeline/summit_sit");
            }

            // Independent of finding a supporting platform, and after the footstep.
            if (animation.Equals("push") && (frame == 8 || frame == 15))
            {
                var direction = new Vector2(-world.Facing, -.5f);
                world.BurstForegroundDust(world.Position + new Vector2(-world.Facing * 5, -1),
                    Vector2Geometry.Angle(direction), 1, 0);
            }
        }
    }
}
