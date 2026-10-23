using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.IntroCar
{
    public class OriginalIntroCarBarrierState : SceneEntityState
    {
        public OriginalIntroCarBarrierState(ISourceEngineContext engine, Vector2 position, int depth, PackedColor color)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            Depth = depth;
            var image =
                new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/car/barrier"]);
            image.Origin = new(0f, image.Height);
            image.Color = color;
            Components.Add(image);
        }
    }
}
