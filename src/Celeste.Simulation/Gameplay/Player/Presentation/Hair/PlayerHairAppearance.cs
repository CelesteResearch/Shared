using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public sealed class PlayerHairAppearance
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public PlayerHairAppearance(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public int LastDashes, StartHairCount = 4;
        public float HairFlashTimer, WindHairTimer, WindTimeout;
        public Vector2 WindDirection, ForceStrongWindHair;

        public static readonly PackedColor NormalHairColor = Rgb(0xAC3232),
            UsedHairColor = Rgb(0x44B7FF),
            TwoDashesHairColor = Rgb(0xFF6DEF),
            NormalBadelineHairColor = Rgb(0x9B3FB5),
            FlashHairColor = PackedColor.White,
            UsedBadelineHairColor = UsedHairColor,
            TwoDashesBadelineHairColor = TwoDashesHairColor;

        public void UpdatePhysics(global::Celeste.Simulation.Gameplay.Player.State.PlayerState player, int state,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair hair, float sceneTime,
            float deltaTime)
        {
            if (WindTimeout > 0) WindTimeout -= deltaTime;
            Vector2 wind = WindDirection;
            if (((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                    ForceStrongWindHair) > 0) wind = ForceStrongWindHair;
            if (WindTimeout > 0 && wind.X != 0)
            {
                WindHairTimer += deltaTime * 8;
                hair.StepPerSegment = new Vector2(wind.X * 5, (float)Math.Sin(WindHairTimer));
                hair.StepInFacingPerSegment = 0;
                hair.StepApproach = 128;
                hair.StepYSinePerSegment = 0;
            }
            else if (player.Dashes > 1)
            {
                hair.StepPerSegment = new Vector2((float)Math.Sin(sceneTime * 2) * .7f - player.Facing * 3,
                    (float)Math.Sin(sceneTime));
                hair.StepInFacingPerSegment = 0;
                hair.StepApproach = 90;
                hair.StepYSinePerSegment = 1;
                hair.StepPerSegment.Y += wind.Y * 2;
            }
            else
            {
                hair.StepPerSegment = new Vector2(0, 2);
                hair.StepInFacingPerSegment = .5f;
                hair.StepApproach = 64;
                hair.StepYSinePerSegment = 0;
                hair.StepPerSegment.Y += wind.Y * .5f;
            }

            if (state == 5) hair.Sprite.HairCount = 1;
            else if (state != 19) hair.Sprite.HairCount = player.Dashes > 1 ? 5 : StartHairCount;
        }

        public void UpdateColor(global::Celeste.Simulation.Gameplay.Player.State.PlayerState player, int state,
            int maxDashes, global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair hair,
            bool applyGravity,
            float deltaTime, PackedColor? overrideHairColor)
        {
            if (state == 19)
            {
                hair.Color = hair.Sprite.Color;
                applyGravity = false;
            }
            else if (player.Dashes == 0 && player.Dashes < maxDashes)
                hair.Color = global::Celeste.Graphics.Display.Colors.SourceColorInterpolation.Lerp(hair.Color,
                    hair.Sprite.Mode == global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode
                        .MadelineAsBadeline
                        ? UsedBadelineHairColor
                        : UsedHairColor,
                    6 * deltaTime,
                    ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)engine).ScalarArithmetic);
            else
            {
                PackedColor color;
                if (LastDashes != player.Dashes)
                {
                    color = FlashHairColor;
                    HairFlashTimer = .12f;
                }
                else if (!(HairFlashTimer > 0))
                    color = hair.Sprite.Mode == global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites
                        .PlayerSpriteMode.MadelineAsBadeline
                        ? (player.Dashes != 2 ? NormalBadelineHairColor : TwoDashesBadelineHairColor)
                        : (player.Dashes != 2 ? NormalHairColor : TwoDashesHairColor);
                else
                {
                    color = FlashHairColor;
                    HairFlashTimer -= deltaTime;
                }

                hair.Color = color;
            }

            if (overrideHairColor.HasValue) hair.Color = overrideHairColor.Value;
            hair.Facing = player.Facing;
            hair.SimulateMotion = applyGravity;
            LastDashes = player.Dashes;
        }

        private static PackedColor Rgb(int hex) => new PackedColor(hex >> 16 & 255, hex >> 8 & 255, hex & 255);
    }
}
