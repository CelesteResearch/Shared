using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.ScreenEffects;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceLevelShakeScene
    {
        private Vector2 shakeDirection;

        private int lastDirectionalShake;

        private float shakeTimer;

        private Vector2 cameraPreShake;

        public float ScreenPadding;

        private float flash;

        private PackedColor flashColor = PackedColor.White;

        private bool doFlash;

        private bool flashDrawPlayer;


        public Vector2 ShakeVector { get; private set; }

        public void Shake(float time = 0.3f)
        {
            if (!((RoomScreenshakeAmount)((ISettingsContext)EngineContext).Settings.ScreenShake !=
                  RoomScreenshakeAmount.Off))
                return;
            shakeDirection = Vector2.Zero;
            shakeTimer = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(shakeTimer, time);
        }

        public void StopShake()
        {
            shakeTimer = 0f;
        }

        public void DirectionalShake(Vector2 dir, float time = 0.3f)
        {
            if (!((RoomScreenshakeAmount)((ISettingsContext)EngineContext).Settings.ScreenShake !=
                  RoomScreenshakeAmount.Off))
                return;
            shakeDirection = ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.SafeNormalize(dir);
            lastDirectionalShake = 0;
            shakeTimer = ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Max(shakeTimer, time);
        }

        public void Flash(PackedColor color, bool drawPlayerOver = false)
        {
            if (!(((IOriginalLevelScreenEffectsProcess)EngineContext).LevelScreenEffectsBehavior ==
                  LevelScreenEffectsBehavior.Original
                    ? !((ISettingsContext)EngineContext).Settings.DisableFlashes
                    : ((IOriginalLevelScreenEffectsProcess)EngineContext).AllowScreenFlash))
                return;
            doFlash = true;
            flashDrawPlayer = drawPlayerOver;
            flash = 1f;
            flashColor = color;
        }


        private void UpdateSourceScreenEffects()
        {
            if (shakeTimer > 0f)
            {
                if (Clock.OnRawInterval(0.04f, EngineContext))
                {
                    var num2 = (int)Math.Ceiling(shakeTimer * 10f);
                    if (shakeDirection == Vector2.Zero)
                    {
                        ShakeVector =
                            new(-num2 + ((ISourceRandomEnvironment)EngineContext).Random.Next(num2 * 2 + 1),
                                -num2 + ((ISourceRandomEnvironment)EngineContext).Random.Next(num2 * 2 + 1));
                    }
                    else
                    {
                        if (lastDirectionalShake == 0)
                            lastDirectionalShake = 1;
                        else
                            lastDirectionalShake *= -1;

                        ShakeVector = -shakeDirection * lastDirectionalShake * num2;
                    }

                    if ((RoomScreenshakeAmount)((ISettingsContext)EngineContext).Settings.ScreenShake ==
                        RoomScreenshakeAmount.Half)
                    {
                        float x = Math.Sign(ShakeVector.X);
                        float y = Math.Sign(ShakeVector.Y);
                        ShakeVector = new(x, y);
                    }
                }

                var num3 =
                    (RoomScreenshakeAmount)((ISettingsContext)EngineContext).Settings.ScreenShake ==
                    RoomScreenshakeAmount.Half
                        ? 1.5f
                        : 1f;
                shakeTimer -= EngineContext.RawDeltaTime * num3;
            }
            else
            {
                ShakeVector = Vector2.Zero;
            }

            if (doFlash)
            {
                flash = ScalarMath.Approach(flash, 1f, EngineContext.DeltaTime * 10f,
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
                if (flash >= 1f) doFlash = false;
            }
            else if (flash > 0f)
            {
                flash = ScalarMath.Approach(flash, 0f, EngineContext.DeltaTime * 3f,
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
            }
        }
    }
}
