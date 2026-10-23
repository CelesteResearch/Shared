using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Player.Death
{
    public sealed class DeathEffect : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        public Vector2 Position;
        public PackedColor Color;
        public float Percent;
        public float Duration = .834f;
        public Action<float> OnUpdate;
        public Action OnEnd;

        public DeathEffect(PackedColor color, ISourceEngineContext engine, Vector2? offset = null)
            : base(true, true)
        {
            this.engine = engine;
            Color = color;
            Position = offset ?? Vector2.Zero;
            Percent = 0f;
        }

        public override void Update()
        {
            base.Update();
            if (Percent > 1f)
            {
                RemoveSelf();
                OnEnd?.Invoke();
            }

            Percent = ScalarMath.Approach(Percent, 1f, engine.DeltaTime / Duration,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            OnUpdate?.Invoke(Percent);
        }

        public override void Render(ISourceRenderContext context)
        {
            Draw(context, ((ISourceEntityPosition)Entity).Position + Position, Color, Percent, Entity, engine);
        }

        public static void Draw(ISourceRenderContext context, Vector2 position, PackedColor color,
            float ease, object actualEntity, ISourceEngineContext engine)
        {
            var flash = Math.Floor(ease * 10f) % 2d == 0d ? color : PackedColor.White;
            var texture = ((ISourceGameAtlasRenderContext)context).GameAtlas.Entries["characters/player/hair00"];
            var size = ease < .5f
                ? .5f + ease
                : ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(1f - (ease - .5f) * 2f);
            for (var i = 0; i < 8; i++)
            {
                var radial = Vector2Geometry.AngleToVector(
                    (i / 8f + ease * .25f) * ((float)Math.PI * 2f),
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease) * 24f);
                Place(position + radial + new Vector2(-1f, 0f), PackedColor.Black);
                Place(position + radial + new Vector2(1f, 0f), PackedColor.Black);
                Place(position + radial + new Vector2(0f, -1f), PackedColor.Black);
                Place(position + radial + new Vector2(0f, 1f), PackedColor.Black);
            }

            for (var i = 0; i < 8; i++)
            {
                var radial = Vector2Geometry.AngleToVector(
                    (i / 8f + ease * .25f) * ((float)Math.PI * 2f),
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease) * 24f);
                Place(position + radial, flash);
            }

            void Place(Vector2 at, PackedColor tint)
            {
                var draw = new AtlasTextureDraw(texture, at,
                    new(texture.FrameWidth / 2f, texture.FrameHeight / 2f),
                    tint, new(size, size));
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, actualEntity);
            }
        }
    }
}
