using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Animation;
using Celeste.Game.Execution.Levels;
using System.Collections.Generic;
using Celeste.Core.Randomness;

namespace Celeste.Game.Gameplay.Decoration.SummitClouds
{
    public class OriginalSummitCloud : SceneEntityState
    {
        private readonly IOriginalSummitCloudProcess engine;

        private SpriteImage image;

        private float diff;

        private Vector2 RenderPosition
        {
            get
            {
                Vector2 vector = (base.Scene as OriginalLevelSceneRoot).Camera.Position + new Vector2(160f, 90f);
                Vector2 vector2 = Position + new Vector2(128f, 64f) / 2f - vector;
                return Position + vector2 * (0.1f + diff);
            }
        }

        public OriginalSummitCloud(global::Celeste.Formats.Map.Entities.Structure.EntityData data,
            Vector2 offset, IOriginalSummitCloudProcess engine)
            : base(engine.EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            base.Depth = -10550;
            diff = SourceRandomMath.Range(engine.Random, 0.1f, 0.2f);
            List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> atlasSubtextures =
                engine.GameGraphics.GameAtlas.GetAtlasSubtextures("scenery/summitclouds/cloud");
            image = new SpriteImage(engine.Random.Choose(atlasSubtextures));
            image.CenterOrigin();
            image.Scale.X = engine.Random.Choose(-1, 1);
            OwnedComponents.Add(image);
            global::Celeste.Scene.Components.Oscillation.SineWaveState sineWave =
                new global::Celeste.Scene.Components.Oscillation.SineWaveState(engine,
                    SourceRandomMath.Range(engine.Random, 0.05f, 0.15f));
            sineWave.Randomize();
            sineWave.OnUpdate = delegate(float f) { image.Position.Y = f * 8f; };
            OwnedComponents.Add(sineWave);
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            Vector2 position = Position;
            Position = RenderPosition;
            base.Render(context);
            Position = position;
        }
    }
}
