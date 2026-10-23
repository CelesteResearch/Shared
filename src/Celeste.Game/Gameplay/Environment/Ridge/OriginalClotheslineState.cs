using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalClotheslineState : SceneEntityState
    {
        public OriginalClotheslineState(Vector2 from, Vector2 to, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Depth = 8999;
            Position = from;
            Add(((IOriginalRidgeClothEnvironment)engine).Flaglines.Create(engine, to,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.LineColor,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.PinColor,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.Colors, 8, 20, 8, 16, 2, 8));
        }

        public OriginalClotheslineState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Nodes[0] + offset, engine)
        {
        }
    }
}
