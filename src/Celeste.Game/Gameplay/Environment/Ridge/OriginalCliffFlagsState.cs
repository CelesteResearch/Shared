using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalCliffFlagsState : SceneEntityState
    {
        public OriginalCliffFlagsState(Vector2 from, Vector2 to, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Depth = 8999;
            Position = from;
            OriginalFlaglineState flagline;
            Add(flagline = ((IOriginalRidgeClothEnvironment)engine).Flaglines.Create(engine, to,
                ((IOriginalRidgeClothEnvironment)engine).CliffFlags.LineColor,
                ((IOriginalRidgeClothEnvironment)engine).CliffFlags.PinColor,
                ((IOriginalRidgeClothEnvironment)engine).CliffFlags.Colors, 10, 10, 10, 10, 2, 8));
            flagline.ClothDroopAmount = 0.2f;
        }

        public OriginalCliffFlagsState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Nodes[0] + offset, engine)
        {
        }
    }
}
