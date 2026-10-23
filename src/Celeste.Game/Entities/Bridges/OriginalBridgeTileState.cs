using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Particles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Bridges
{
    public class OriginalBridgeTileState : SourceJumpThruEntityState
    {
        private readonly List<SpriteImage> images;

        private readonly ISourceEngineContext engine;

        private Vector2 shakeOffset;

        private float shakeTimer;

        private float speedY;

        private float colorLerp;

        public bool Fallen { get; private set; }

        public OriginalBridgeTileState(Vector2 position, IntRect tileSize, ISourceEngineContext engine,
            ISourceSolidWorld world)
            : base(position, tileSize.Width, false, world)
        {
            this.engine = engine;
            images = [];
            if (tileSize.Width == 16)
            {
                var num = 24;
                var num2 = 0;
                while (num2 < tileSize.Height)
                {
                    SpriteImage image;
                    OwnedComponents.Add(image = new(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                        .GameAtlas.Entries["scenery/bridge"].GetSubtexture(tileSize.X, num2, tileSize.Width, num)));
                    image.Origin = new(image.Width / 2f, 0f);
                    image.Position.X = image.Width / 2f;
                    image.Position.Y = num2 - 8;
                    images.Add(image);
                    num2 += num;
                    num = 12;
                }
            }
            else
            {
                SpriteImage image2;
                OwnedComponents.Add(image2 = new(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                    .GameAtlas
                    .Entries["scenery/bridge"].GetSubtexture(tileSize.X, tileSize.Y, tileSize.Width, tileSize.Height)));
                image2.Origin = new(image2.Width / 2f, 0f);
                image2.Position.X = image2.Width / 2f;
                image2.Position.Y = -8f;
                images.Add(image2);
            }
        }

        public override void Update()
        {
            base.Update();
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var flag = images[0].Width == 16f;
            if (!Fallen) return;

            if (shakeTimer > 0f)
            {
                shakeTimer -= engine.DeltaTime;
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                    shakeOffset = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);

                if (shakeTimer <= 0f)
                {
                    Collidable = false;
                    ((OriginalLevelSceneRoot)Scene).Shake(0.1f);
                    ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                        RumbleLength.Medium);
                    if (flag)
                    {
                        ((IOriginalGameplayProcess)engine).AudioSession.Play(
                            "event:/game/00_prologue/bridge_support_break",
                            Position, ((IOriginalGameplayProcess)engine).SaveContext);
                        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                        foreach (var image in images)
                            if (image.RenderPosition.Y > Y + 4f)
                                OriginalDustBurstSource.Burst(engine, image.RenderPosition, -(float)Math.PI / 2f, 8);
                    }
                }

                images[0].Position = new Vector2(images[0].Width / 2f, -8f) + shakeOffset;
                return;
            }

            colorLerp = ScalarMath.Approach(colorLerp, 1f, 10f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            images[0].Color = SourceColorInterpolation.Lerp(PackedColor.White, PackedColor.Gray, colorLerp,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            shakeOffset = Vector2.Zero;
            if (flag)
            {
                var num = 0;
                foreach (var image2 in images)
                {
                    image2.Rotation -= (num % 2 != 0 ? 1 : -1) * engine.DeltaTime * num * 2f;
                    image2.Position.Y += num * engine.DeltaTime * 16f;
                    num++;
                }

                speedY = ScalarMath.Approach(speedY, 120f, 600f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
            else
            {
                speedY = ScalarMath.Approach(speedY, 200f, 900f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            MoveV(speedY * engine.DeltaTime);
            if (Top > 220f) RemoveSelf();
        }

        public void Fall(float timer = 0.2f)
        {
            if (!Fallen)
            {
                Fallen = true;
                shakeTimer = timer;
            }
        }
    }
}
