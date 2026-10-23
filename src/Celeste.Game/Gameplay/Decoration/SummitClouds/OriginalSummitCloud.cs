using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Decoration.SummitClouds
{
    public class OriginalSummitCloud : SceneEntityState
    {
        private readonly IOriginalSummitCloudProcess engine;

        private readonly SpriteImage image;

        private readonly float diff;

        private Vector2 RenderPosition
        {
            get
            {
                var vector = (Scene as OriginalLevelSceneRoot).Camera.Position + new Vector2(160f, 90f);
                var vector2 = Position + new Vector2(128f, 64f) / 2f - vector;
                return Position + vector2 * (0.1f + diff);
            }
        }

        public OriginalSummitCloud(EntityData data,
            Vector2 offset, IOriginalSummitCloudProcess engine)
            : base(engine.EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Depth = -10550;
            diff = SourceRandomMath.Range(engine.Random, 0.1f, 0.2f);
            var atlasSubtextures =
                engine.GameGraphics.GameAtlas.GetAtlasSubtextures("scenery/summitclouds/cloud");
            image = new(engine.Random.Choose(atlasSubtextures));
            image.CenterOrigin();
            image.Scale.X = engine.Random.Choose(-1, 1);
            OwnedComponents.Add(image);
            var sineWave =
                new SineWaveState(engine,
                    SourceRandomMath.Range(engine.Random, 0.05f, 0.15f));
            sineWave.Randomize();
            sineWave.OnUpdate = delegate(float f) { image.Position.Y = f * 8f; };
            OwnedComponents.Add(sineWave);
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position = RenderPosition;
            base.Render(context);
            Position = position;
        }
    }
}
