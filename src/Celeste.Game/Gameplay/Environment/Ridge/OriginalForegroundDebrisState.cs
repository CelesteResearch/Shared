using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Image = Celeste.Graphics.Animation.SpriteImage;
using SineWave = Celeste.Scene.Components.Oscillation.SineWaveState;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalForegroundDebrisState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private readonly Vector2 start;

        private readonly float parallax;

        public OriginalForegroundDebrisState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            start = Position;
            Depth = -999900;
            var key = "scenery/fgdebris/" + ((ISourceRandomEnvironment)engine).Random.Choose("rock_a", "rock_b");
            var atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(key);
            atlasSubtextures.Reverse();
            foreach (var item in atlasSubtextures)
            {
                var img = new Image(item);
                img.CenterOrigin();
                Add(img);
                var sine = new SineWave(engine, 0.4f);
                sine.Randomize();
                sine.OnUpdate = delegate { img.Position.Y = sine.Value * 2f; };
                Add(sine);
            }

            parallax = 0.05f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.08f);
        }

        public OriginalForegroundDebrisState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = ((Level)Scene).Camera.Position + new Vector2(320f, 180f) / 2f - start;
            var position = Position;
            Position -= vector * parallax;
            base.Render(context);
            Position = position;
        }
    }
}
