using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System.Numerics;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public interface IOriginalRidgeClothEnvironment
    {
        IOriginalRidgeClothResources CliffFlags { get; }
        IOriginalRidgeClothResources Clothesline { get; }
        IOriginalFlaglineFactory Flaglines { get; }
    }
}
