namespace Celeste.Game.Save.Data
{
    public interface IFileSaveStatistics
    {
        void Increment(FileStatistic statistic);
        void IncrementStadiaDeaths();
        void SetStadiaBerriesIfLarger(int count);
        void RegisterAchievement(string achievement);
    }
}
