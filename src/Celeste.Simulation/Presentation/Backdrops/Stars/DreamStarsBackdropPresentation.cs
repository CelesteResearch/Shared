using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public class DreamStarsBackdropPresentation : BackdropPresentation
    {
        private struct Star
        {
            public Vector2 Position;
            public float Speed, Size;
        }

        private readonly Star[] stars = new Star[50];
        private readonly Vector2 angle;
        private Vector2 lastCamera = Vector2.Zero;
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public DreamStarsBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            angle = ((ISourceVectorEnvironment)engine).VectorArithmetic.Normalize(new Vector2(-2f, -7f));
            for (var i = 0; i < stars.Length; i++)
            {
                stars[i].Position = new(SourceRandomMath.NextFloat(Random, 320f),
                    SourceRandomMath.NextFloat(Random, 180f));
                stars[i].Speed = 24f + SourceRandomMath.NextFloat(Random, 24f);
                stars[i].Size = 2f + SourceRandomMath.NextFloat(Random, 6f);
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            var camera = scene.Camera.Position;
            var delta = camera - lastCamera;
            for (var i = 0; i < stars.Length; i++)
                stars[i].Position += angle * stars[i].Speed * engine.Frame.DeltaTime - delta * .5f;
            lastCamera = camera;
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            for (var i = 0; i < stars.Length; i++)
                SourcePrimitiveDrawing.HollowRect(context, null,
                    new(ScalarMath.Mod(stars[i].Position.X, 320f), ScalarMath.Mod(stars[i].Position.Y, 180f)),
                    stars[i].Size, stars[i].Size, PackedColor.Teal);
        }
    }
}
