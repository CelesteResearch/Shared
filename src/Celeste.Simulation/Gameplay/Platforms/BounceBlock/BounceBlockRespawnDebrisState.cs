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
    public class BounceBlockRespawnDebrisState : SceneEntityState
    {
        private SpriteImage sprite;
        private Vector2 from;
        private Vector2 to;
        private float percent;
        private float duration;
        private readonly ISourceEngineContext engine;

        public BounceBlockRespawnDebrisState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
        }

        public BounceBlockRespawnDebrisState Init(Vector2 from, Vector2 to, bool ice, float duration)
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

            Position = this.from = from;
            percent = 0f;
            this.to = to;
            this.duration = duration;
            return this;
        }

        public override void Update()
        {
            if (percent > 1f)
            {
                RemoveSelf();
                return;
            }

            percent += engine.DeltaTime / duration;
            Position = Vector2Interpolation.Lerp(from, to, percent * percent * percent,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            sprite.Color = PackedColor.White * percent;
        }

        public override void Render(ISourceRenderContext context)
        {
            sprite.DrawOutline(context, PackedColor.Black);
            base.Render(context);
        }
    }
}
