using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Presentation.ScreenEffects
{
    public sealed class RoomScreenEffects
    {
        private readonly global::Celeste.Core.Randomness.ISourceRandom random;
        private global::Celeste.Scene.Scheduling.SceneClock sourceClock;
        private global::Celeste.Core.Scheduling.ISourceEngineContext sourceEngine;
        private ISourceScreenEffectSettings sourceSettings;
        public RoomScreenshakeAmount ScreenShake => sourceSettings.ScreenShake;
        public bool DisableFlashes => sourceSettings.DisableFlashes;

        public void BindSourceScene(global::Celeste.Scene.Scheduling.SceneClock actualClock,
            global::Celeste.Core.Scheduling.ISourceEngineContext actualEngine,
            ISourceScreenEffectSettings actualSettings)
        {
            if (sourceEngine != null)
                throw new InvalidOperationException("The actual screen effect scene is already bound.");
            sourceClock = actualClock ?? throw new ArgumentNullException(nameof(actualClock));
            sourceEngine = actualEngine ?? throw new ArgumentNullException(nameof(actualEngine));
            sourceSettings = actualSettings ?? throw new ArgumentNullException(nameof(actualSettings));
        }

        public Vector2 ShakeVector { get; private set; }
        public Vector2 ShakeDirection { get; private set; }
        public float ShakeTimer { get; private set; }
        public int LastDirectionalShake { get; private set; }
        public float FlashAmount { get; private set; }
        public bool FlashDrawPlayer { get; private set; }
        public bool DoFlash { get; private set; }
        public Vector4 FlashColor { get; private set; } = Vector4.One;

        public Vector4 RenderFlashColor =>
            global::Celeste.Graphics.Display.Colors.ColorMath.Scale(FlashColor, FlashAmount);

        public RoomScreenEffects(global::Celeste.Core.Randomness.ISourceRandom random)
        {
            this.random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Shake(float time = .3f)
        {
            if (ScreenShake == global::Celeste.Simulation.Presentation.ScreenEffects.RoomScreenshakeAmount.Off) return;
            ShakeDirection = Vector2.Zero;
            ShakeTimer = Math.Max(ShakeTimer, time);
        }

        public void DirectionalShake(Vector2 direction, float time = .3f)
        {
            if (ScreenShake == global::Celeste.Simulation.Presentation.ScreenEffects.RoomScreenshakeAmount.Off) return;
            if (direction != Vector2.Zero)
            {
                float inverse = 1f / (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
                direction.X *= inverse;
                direction.Y *= inverse;
            }

            ShakeDirection = direction;
            LastDirectionalShake = 0;
            ShakeTimer = Math.Max(ShakeTimer, time);
        }

        // The old vector remains visible until the next Level.Update tail.
        public void StopShake()
        {
            ShakeTimer = 0;
        }

        public void Flash(Vector4 color, bool drawPlayerOver = false)
        {
            if (!sourceSettings.AllowScreenFlash) return;
            DoFlash = true;
            FlashDrawPlayer = drawPlayerOver;
            FlashAmount = 1;
            FlashColor = color;
        }

        // rawTimeActive is Scene.RawTimeActive AFTER Scene.BeforeUpdate. The caller
        // omits this tail only when Level.Update itself returns early (or is frozen by Engine).
        public void Update()
        {
            float dt = sourceEngine.DeltaTime;
            float rawDt = sourceEngine.RawDeltaTime;
            if (ShakeTimer > 0)
            {
                if (sourceClock.OnRawInterval(.04f, sourceEngine))
                {
                    int amplitude = (int)Math.Ceiling(ShakeTimer * 10f);
                    if (ShakeDirection == Vector2.Zero)
                        ShakeVector = new Vector2(-amplitude + random.Next(amplitude * 2 + 1),
                            -amplitude + random.Next(amplitude * 2 + 1));
                    else
                    {
                        LastDirectionalShake = LastDirectionalShake == 0 ? 1 : -LastDirectionalShake;
                        ShakeVector = -ShakeDirection * LastDirectionalShake * amplitude;
                    }

                    if (ScreenShake == global::Celeste.Simulation.Presentation.ScreenEffects.RoomScreenshakeAmount.Half)
                        ShakeVector = new Vector2(Math.Sign(ShakeVector.X), Math.Sign(ShakeVector.Y));
                }

                ShakeTimer -= rawDt *
                              (ScreenShake == global::Celeste.Simulation.Presentation.ScreenEffects
                                  .RoomScreenshakeAmount.Half
                                  ? 1.5f
                                  : 1f);
            }
            else ShakeVector = Vector2.Zero;

            if (DoFlash)
            {
                FlashAmount = global::Celeste.Core.Mathematics.ScalarMath.Approach(FlashAmount, 1, dt * 10);
                if (FlashAmount >= 1) DoFlash = false;
            }
            else if (FlashAmount > 0)
                FlashAmount = global::Celeste.Core.Mathematics.ScalarMath.Approach(FlashAmount, 0, dt * 3);
        }

        // Render-only position: never write this result back to the logical camera.
        public Vector2 RenderCameraPosition(Vector2 logicalCamera)
        {
            Vector2 position = logicalCamera + ShakeVector;
            return new Vector2((float)Math.Floor(position.X), (float)Math.Floor(position.Y));
        }
    }
}
