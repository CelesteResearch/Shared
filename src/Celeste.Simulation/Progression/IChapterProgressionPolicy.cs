namespace Celeste.Simulation.Progression
{
    public interface IChapterProgressionPolicy
    {
        string DefaultCampaignId { get; }
        int InitialUnlockedAreas(global::Celeste.Simulation.Save.Progress.ChapterProgress progress, string campaignId);

        int CampaignMaxArea(global::Celeste.Simulation.Save.Progress.ChapterProgress progress,
            global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats campaign);

        int MaxAssistArea(global::Celeste.Simulation.Save.Progress.ChapterProgress progress);

        int GetUnlockedAreas(global::Celeste.Simulation.Save.Progress.ChapterProgress progress,
            global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats campaign);

        void SetUnlockedAreas(global::Celeste.Simulation.Save.Progress.ChapterProgress progress,
            global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats campaign, int value);

        int UnlockedModes(global::Celeste.Simulation.Save.Progress.ChapterProgress progress);

        int UnlockedModesFor(global::Celeste.Simulation.Save.Progress.ChapterProgress progress,
            global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats campaign);

        void RegisterCompletionUnlock(global::Celeste.Simulation.Save.Progress.ChapterProgress progress,
            global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session);
    }
}
