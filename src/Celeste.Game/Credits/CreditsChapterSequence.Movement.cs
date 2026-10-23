using Celeste.Input.Runtime;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Controls.Source;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private ISourceExtremaArithmetic Extrema
            => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private IEnumerator FadeTo(float value)
        {
            while ((fade = ScalarMath.Approach(fade, value, engine.Frame.DeltaTime * .5f, Extrema)) != value)
                yield return null;
            fade = value;
        }

        private IEnumerator BadelineApproachWalking()
        {
            while (badelineWalkApproach < 1f)
            {
                badeline.Floatness = ScalarMath.Approach(badeline.Floatness, 0f, engine.Frame.DeltaTime * 8f, Extrema);
                badelineWalkApproach =
                    ScalarMath.Approach(badelineWalkApproach, 1f, engine.Frame.DeltaTime * .6f, Extrema);
                yield return null;
            }
        }

        public override void Update()
        {
            var input = ((IOriginalGameInputProcessEnvironment)engine).InputSource;
            ((ISourceMInputEnvironment)engine).MInput.Disabled = false;
            if (Level.CanPause && (input.Pause.Pressed || input.ESC.Pressed))
            {
                input.Pause.ConsumeBuffer();
                input.ESC.ConsumeBuffer();
                Level.Pause(0, minimal: true);
            }

            ((ISourceMInputEnvironment)engine).MInput.Disabled = true;
            if (player != null && player.Scene != null)
            {
                if (player.Motor.Dash.Data.OverrideDirection.HasValue)
                {
                    input.MoveX.Value = (int)player.Motor.Dash.Data.OverrideDirection.Value.X;
                    input.MoveY.Value = (int)player.Motor.Dash.Data.OverrideDirection.Value.Y;
                }

                if (autoWalk)
                {
                    if (player.OnGround())
                    {
                        player.Data.Motion.Normal.Speed.X = -44.8f;
                        bool obstacle = SourceTrackedEntityCollision.CheckAt(
                            ((ISourceScene)player.Scene).SourceScene.Entities,
                            "Celeste.Solid", player, player.Position + new Vector2(-20f, 0f));
                        bool ledge = !SourceTrackedEntityCollision.CheckAt(
                                         ((ISourceScene)player.Scene).SourceScene.Entities,
                                         "Celeste.Solid", player, player.Position + new Vector2(-8f, 1f))
                                     && !SourceTrackedEntityCollision.CheckAt(
                                         ((ISourceScene)player.Scene).SourceScene.Entities,
                                         "Celeste.Solid", player, player.Position + new Vector2(-8f, 32f));
                        if (obstacle || ledge)
                        {
                            player.Jump();
                            player.Data.Motion.AutoJump = true;
                            player.Data.AutoJumpTimer = obstacle ? .6f : 2f;
                        }
                    }
                    else player.Data.Motion.Normal.Speed.X = -64f;
                }

                if (badeline != null && badelineAutoFloat)
                {
                    Vector2 position = badeline.Position;
                    Vector2 target = player.Position + new Vector2(16f, -16f);
                    badeline.Position = position + (target - position)
                        * (1f - (float)Math.Pow(.009999999776482582, engine.Frame.DeltaTime));
                    badeline.Sprite.Scale.X = -1f;
                }

                if (badeline != null && badelineAutoWalk)
                {
                    player.GetChasePosition(((ISourceScene)Scene).SourceScene.Clock.TimeActive,
                        .35f + (float)Math.Sin(walkOffset) * .1f, out var chaseState);
                    if (chaseState.OnGround) walkOffset += engine.Frame.DeltaTime;
                    if (badelineWalkApproach >= 1f)
                    {
                        badeline.Position = chaseState.Position;
                        if (badeline.Sprite.Has(chaseState.Animation)) badeline.Sprite.Play(chaseState.Animation);
                        badeline.Sprite.Scale.X = chaseState.Facing;
                    }
                    else
                        badeline.Position = Vector2Interpolation.Lerp(badelineWalkApproachFrom,
                            chaseState.Position, badelineWalkApproach,
                            ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                }

                if (Math.Abs(player.Data.Motion.Normal.Speed.X) > 90f)
                    player.Data.Motion.Normal.Speed.X = ScalarMath.Approach(player.Data.Motion.Normal.Speed.X,
                        90f * Math.Sign(player.Data.Motion.Normal.Speed.X), 1000f * engine.Frame.DeltaTime, Extrema);
            }

            if (credits != null) credits.Update();
            base.Update();
        }

        public new void PostUpdate()
        {
            if (player != null && player.Scene != null && autoUpdateCamera)
            {
                Vector2 position = Level.Camera.Position;
                Vector2 target = player.CameraTarget;
                if (!player.OnGround()) target.Y = (Level.Camera.Position.Y * 2f + target.Y) / 3f;
                Level.Camera.Position = position + (target - position)
                    * (1f - (float)Math.Pow(.009999999776482582, engine.Frame.DeltaTime));
                Level.Camera.Position = new Vector2((int)target.X, Level.Camera.Position.Y);
            }
        }
    }
}
