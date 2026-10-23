namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public interface IOriginalRidgeClothEnvironment
    {
        IOriginalRidgeClothResources CliffFlags { get; }
        IOriginalRidgeClothResources Clothesline { get; }
        IOriginalFlaglineFactory Flaglines { get; }
    }
}
