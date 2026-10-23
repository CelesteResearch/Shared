using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Simulation.Gameplay.Platforms.BounceBlock
{
    public class BounceBlockBreakDebrisState : SceneEntityState
    {
        private SpriteImage sprite;
        private Vector2 speed;
        private float percent;
        private float duration;
        private readonly ISourceEngineContext engine;

        public BounceBlockBreakDebrisState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
        }

        public BounceBlockBreakDebrisState Init(Vector2 position, Vector2 direction, bool ice)
        {
            var textures = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                ice ? "objects/bumpblocknew/ice_rubble" : "objects/bumpblocknew/fire_rubble");
            var texture = textures[((ISourceRandomEnvironment)engine).Random.Next(textures.Count)];
            if (sprite == null)
            {
                sprite = new(texture);
                OwnedComponents.Add(sprite);
                sprite.CenterOrigin();
            }
            else
            {
                sprite.Texture = texture;
            }

            Position = position;
            direction = Vector2Geometry.AngleToVector(Vector2Geometry.Angle(direction)
                                                      + SourceRandomMath.Range(
                                                          ((ISourceRandomEnvironment)engine).Random,
                                                          -.1f, .1f), 1f);
            speed = direction *
                    (ice
                        ? 20 + ((ISourceRandomEnvironment)engine).Random.Next(20)
                        : 120 + ((ISourceRandomEnvironment)engine).Random.Next(80));
            percent = 0f;
            duration = 2 + ((ISourceRandomEnvironment)engine).Random.Next(1);
            return this;
        }

        public override void Update()
        {
            base.Update();
            if (percent >= 1f)
            {
                RemoveSelf();
                return;
            }

            Position += speed * engine.DeltaTime;
            speed.X = ScalarMath.Approach(speed.X, 0f, 180f * engine.DeltaTime);
            speed.Y += 200f * engine.DeltaTime;
            percent += engine.DeltaTime / duration;
            sprite.Color = PackedColor.White * (1f - percent);
        }

        public override void Render(ISourceRenderContext context)
        {
            sprite.DrawOutline(context, PackedColor.Black);
            base.Render(context);
        }
    }
}
