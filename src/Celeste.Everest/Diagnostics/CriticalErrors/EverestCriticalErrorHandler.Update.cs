using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Presentation.Hud.Overlays;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        public override void Update()
        {
            if (Scene is IOverlayHandler overlayHandler && overlayHandler.Overlay != this)
            {
                if (overlayHandler.Overlay != null) return;
                overlayHandler.Overlay = this;
            }

            if (UsePlayerSprite && playerSprite != null && playerHair != null)
            {
                if (playerShouldTeabag)
                {
                    if (playerSprite.CurrentAnimationID != "rollGetUp")
                    {
                        crouchTimer -= EngineContext.DeltaTime;
                        if (crouchTimer <= 0f)
                        {
                            playerSprite.Scale = isCrouched ? new Vector2(.8f, 1.2f) : new Vector2(1.4f, .6f);
                            isCrouched = !isCrouched;
                            crouchTimer = .12f;
                        }

                        playerSprite.Play(isCrouched ? "duck" : "idle");
                    }
                }
                else
                {
                    if (playerSprite.LastAnimationID != "roll") playerSprite.Play("roll");
                    var input = ((IGameInputEnvironment)EngineContext).Input;
                    if (input.MoveX.Value != 0 || input[GameAction.MenuLeft].Check || input[GameAction.MenuRight].Check)
                        crouchTimer += EngineContext.DeltaTime;
                    else crouchTimer = 0f;
                    if (crouchTimer >= 5f)
                    {
                        playerSprite.Play("rollGetUp");
                        playerShouldTeabag = true;
                        crouchTimer = 0f;
                    }
                }

                playerSprite.Update();
                playerHair.Update();
                if (playerSprite != null)
                {
                    playerSprite.Scale.X = ScalarMath.Approach(playerSprite.Scale.X, 1f,
                        1.75f * EngineContext.DeltaTime,
                        ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)EngineContext)
                        .ExtremaArithmetic);
                    playerSprite.Scale.Y = ScalarMath.Approach(playerSprite.Scale.Y, 1f,
                        1.75f * EngineContext.DeltaTime,
                        ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)EngineContext)
                        .ExtremaArithmetic);
                }
            }

            if (Fade == 1f) optMenu?.Update();
            base.Update();
        }
    }
}
