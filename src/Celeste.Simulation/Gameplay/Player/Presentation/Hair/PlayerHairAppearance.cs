using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public sealed class PlayerHairAppearance
    {
        private readonly ISourceEngineContext engine;

        public PlayerHairAppearance(ISourceEngineContext engine)
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

        public void UpdatePhysics(PlayerState player, int state,
            PlayerHair hair, float sceneTime,
            float deltaTime)
        {
            if (WindTimeout > 0) WindTimeout -= deltaTime;
            var wind = WindDirection;
            if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                    ForceStrongWindHair) > 0) wind = ForceStrongWindHair;
            if (WindTimeout > 0 && wind.X != 0)
            {
                WindHairTimer += deltaTime * 8;
                hair.StepPerSegment = new(wind.X * 5, (float)Math.Sin(WindHairTimer));
                hair.StepInFacingPerSegment = 0;
                hair.StepApproach = 128;
                hair.StepYSinePerSegment = 0;
            }
            else if (player.Dashes > 1)
            {
                hair.StepPerSegment = new((float)Math.Sin(sceneTime * 2) * .7f - player.Facing * 3,
                    (float)Math.Sin(sceneTime));
                hair.StepInFacingPerSegment = 0;
                hair.StepApproach = 90;
                hair.StepYSinePerSegment = 1;
                hair.StepPerSegment.Y += wind.Y * 2;
            }
            else
            {
                hair.StepPerSegment = new(0, 2);
                hair.StepInFacingPerSegment = .5f;
                hair.StepApproach = 64;
                hair.StepYSinePerSegment = 0;
                hair.StepPerSegment.Y += wind.Y * .5f;
            }

            if (state == 5) hair.Sprite.HairCount = 1;
            else if (state != 19) hair.Sprite.HairCount = player.Dashes > 1 ? 5 : StartHairCount;
        }

        public void UpdateColor(PlayerState player, int state,
            int maxDashes, PlayerHair hair,
            bool applyGravity,
            float deltaTime, PackedColor? overrideHairColor)
        {
            if (state == 19)
            {
                hair.Color = hair.Sprite.Color;
                applyGravity = false;
            }
            else if (player.Dashes == 0 && player.Dashes < maxDashes)
            {
                hair.Color = SourceColorInterpolation.Lerp(hair.Color,
                    hair.Sprite.Mode == PlayerSpriteMode
                        .MadelineAsBadeline
                        ? UsedBadelineHairColor
                        : UsedHairColor,
                    6 * deltaTime,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            }
            else
            {
                PackedColor color;
                if (LastDashes != player.Dashes)
                {
                    color = FlashHairColor;
                    HairFlashTimer = .12f;
                }
                else if (!(HairFlashTimer > 0))
                {
                    color = hair.Sprite.Mode == PlayerSpriteMode.MadelineAsBadeline
                        ? player.Dashes != 2 ? NormalBadelineHairColor : TwoDashesBadelineHairColor
                        : player.Dashes != 2
                            ? NormalHairColor
                            : TwoDashesHairColor;
                }
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

        private static PackedColor Rgb(int hex)
        {
            return new((hex >> 16) & 255, (hex >> 8) & 255, hex & 255);
        }
    }
}
