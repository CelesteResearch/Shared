namespace Celeste.Game.Platform.Statistics
{
    public interface IOriginalPlatformStatisticsOutput
    {
        bool RequestCurrentStats();
        void RequestGlobalStats(int historyDays);
        bool GetStat(string name, out int value);
        void SetStat(string name, int value);
        void GetGlobalStat(string name, out long value);
        void StoreStats();
        bool GetAchievement(string name, out bool achieved);
        void SetAchievement(string name);
    }
}
