using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalAreaStatsPolicy
    {
        int GetAreaStatsId(ChapterAreaProgress actualArea);
        ChapterAreaProgress CreateAreaStats(int id);
        ChapterAreaProgress CloneAreaStats(ChapterAreaProgress actualArea);
    }
}
