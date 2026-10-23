using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public class DreamStarsBackdropPresentation : BackdropPresentation
    {
        private struct Star
        {
            public Vector2 Position;
            public float Speed, Size;
        }

        private Star[] stars = new Star[50];
        private Vector2 angle;
        private Vector2 lastCamera = Vector2.Zero;
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public DreamStarsBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            angle = ((ISourceVectorEnvironment)engine).VectorArithmetic.Normalize(new Vector2(-2f, -7f));
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Position = new Vector2(SourceRandomMath.NextFloat(Random, 320f),
                    SourceRandomMath.NextFloat(Random, 180f));
                stars[i].Speed = 24f + SourceRandomMath.NextFloat(Random, 24f);
                stars[i].Size = 2f + SourceRandomMath.NextFloat(Random, 6f);
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            Vector2 camera = scene.Camera.Position;
            Vector2 delta = camera - lastCamera;
            for (int i = 0; i < stars.Length; i++)
                stars[i].Position += angle * stars[i].Speed * engine.Frame.DeltaTime - delta * .5f;
            lastCamera = camera;
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            for (int i = 0; i < stars.Length; i++)
                SourcePrimitiveDrawing.HollowRect(context, null,
                    new Vector2(ScalarMath.Mod(stars[i].Position.X, 320f), ScalarMath.Mod(stars[i].Position.Y, 180f)),
                    stars[i].Size, stars[i].Size, PackedColor.Teal);
        }
    }
}
