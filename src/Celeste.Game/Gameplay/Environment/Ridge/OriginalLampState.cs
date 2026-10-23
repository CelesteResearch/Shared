using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Image = Celeste.Graphics.Animation.SpriteImage;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalLampState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private readonly Image sprite;

        public OriginalLampState(Vector2 position, bool broken, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            Depth = 5;
            Add(sprite = new(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/lamp"]
                .GetSubtexture(broken ? 16 : 0, 0, 16, 80)));
            sprite.Origin = new(sprite.Width / 2f, sprite.Height);
            if (!broken) Add(new BloomPoint(new(0f, -66f), 1f, 16f));
        }
    }
}
