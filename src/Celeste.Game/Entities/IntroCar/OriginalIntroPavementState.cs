using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.IntroCar
{
    public class OriginalIntroPavementState : SourceSolidEntityState
    {
        private readonly int columns;

        public OriginalIntroPavementState(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            Vector2 position,
            int width)
            : base(position, width, 8f, true, worlds.Create(position, true))
        {
            columns = width / 8;
            Depth = -10;
            SurfaceSoundIndex = 1;
            SurfaceSoundPriority = 10;
        }

        public override void Awake(object scene)
        {
            for (var i = 0; i < columns; i++)
            {
                var num = 0;
                num = i >= columns - 2
                    ? i != columns - 2 ? 3 : 2
                    : ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random.Next(0, 2);
                var image = new SpriteImage(((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext)
                    .GameGraphics
                    .GameAtlas["scenery/car/pavement"].GetSubtexture(num * 8, 0, 8, 8));
                image.Position = new(i * 8, 0f);
                Components.Add(image);
            }
        }
    }
}
