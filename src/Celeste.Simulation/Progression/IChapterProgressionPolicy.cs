using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Simulation.Progression
{
    public interface IChapterProgressionPolicy
    {
        string DefaultCampaignId { get; }
        int InitialUnlockedAreas(ChapterProgress progress, string campaignId);

        int CampaignMaxArea(ChapterProgress progress,
            ChapterLevelSetStats campaign);

        int MaxAssistArea(ChapterProgress progress);

        int GetUnlockedAreas(ChapterProgress progress,
            ChapterLevelSetStats campaign);

        void SetUnlockedAreas(ChapterProgress progress,
            ChapterLevelSetStats campaign, int value);

        int UnlockedModes(ChapterProgress progress);

        int UnlockedModesFor(ChapterProgress progress,
            ChapterLevelSetStats campaign);

        void RegisterCompletionUnlock(ChapterProgress progress,
            ChapterCompletionSession session);
    }
}
