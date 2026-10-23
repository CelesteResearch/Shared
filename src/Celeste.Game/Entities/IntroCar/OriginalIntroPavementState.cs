using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.IntroCar
{
    public class OriginalIntroPavementState : SourceSolidEntityState
    {
        private int columns;

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
            for (int i = 0; i < columns; i++)
            {
                int num = 0;
                num = i >= columns - 2
                    ? (i != columns - 2 ? 3 : 2)
                    : ((ISourceRandomEnvironment)SourceWorld.EngineContext).Random.Next(0, 2);
                SpriteImage image = new SpriteImage(((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext)
                    .GameGraphics
                    .GameAtlas["scenery/car/pavement"].GetSubtexture(num * 8, 0, 8, 8));
                image.Position = new Vector2(i * 8, 0f);
                Components.Add(image);
            }
        }
    }
}
