using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;


namespace Celeste.Game.Entities.Bridges
{
    public class OriginalBridgeTileState : SourceJumpThruEntityState
    {
        private List<SpriteImage> images;

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
            images = new List<SpriteImage>();
            if (tileSize.Width == 16)
            {
                int num = 24;
                int num2 = 0;
                while (num2 < tileSize.Height)
                {
                    SpriteImage image;
                    OwnedComponents.Add(image = new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                        .GameAtlas.Entries["scenery/bridge"].GetSubtexture(tileSize.X, num2, tileSize.Width, num)));
                    image.Origin = new Vector2(image.Width / 2f, 0f);
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
                OwnedComponents.Add(image2 = new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                    .GameAtlas
                    .Entries["scenery/bridge"].GetSubtexture(tileSize.X, tileSize.Y, tileSize.Width, tileSize.Height)));
                image2.Origin = new Vector2(image2.Width / 2f, 0f);
                image2.Position.X = image2.Width / 2f;
                image2.Position.Y = -8f;
                images.Add(image2);
            }
        }

        public override void Update()
        {
            base.Update();
            bool flag = images[0].Width == 16f;
            if (!Fallen)
            {
                return;
            }

            if (shakeTimer > 0f)
            {
                shakeTimer -= engine.DeltaTime;
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                {
                    shakeOffset = RandomShakeVector.Next(((ISourceRandomEnvironment)engine).Random);
                }

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
                        foreach (SpriteImage image in images)
                        {
                            if (image.RenderPosition.Y > base.Y + 4f)
                            {
                                OriginalDustBurstSource.Burst(engine, image.RenderPosition, -(float)Math.PI / 2f, 8);
                            }
                        }
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
                int num = 0;
                foreach (SpriteImage image2 in images)
                {
                    image2.Rotation -= (float)((num % 2 != 0) ? 1 : (-1)) * engine.DeltaTime * (float)num * 2f;
                    image2.Position.Y += (float)num * engine.DeltaTime * 16f;
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
            if (base.Top > 220f)
            {
                RemoveSelf();
            }
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
