namespace Celeste.Simulation.Runtime.Session.Maps
{
    public interface IChapterSessionMapData
    {
        int DetectedStrawberries { get; set; }
        IChapterSessionAreaData Data { get; }
        IChapterSessionModeData ModeData { get; }
        IChapterSessionLevelData StartLevel();
        IChapterSessionLevelData GetLevel(string name);
    }
}
