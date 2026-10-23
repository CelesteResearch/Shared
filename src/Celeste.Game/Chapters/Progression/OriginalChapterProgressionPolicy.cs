using System;
using Celeste.Simulation.Progression;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Chapters.Progression
{
    // Vanilla SaveData and Everest level-set unlock semantics. The runtime
    // progress graph delegates this policy instead of imposing it on all games.
    public sealed class OriginalChapterProgressionPolicy : IChapterProgressionPolicy
    {
        public static readonly OriginalChapterProgressionPolicy Instance = new();

        private OriginalChapterProgressionPolicy()
        {
        }

        public string DefaultCampaignId => "Celeste";

        public int InitialUnlockedAreas(ChapterProgress progress,
            string campaignId)
        {
            return campaignId == "Celeste" ? progress.UnlockedAreas : 0;
        }

        public int CampaignMaxArea(ChapterProgress progress,
            ChapterLevelSetStats campaign)
        {
            var count = (campaign?.PlayableCount ?? progress.AreaCount) - 1;
            return progress.EventMode ? Math.Min(count, (campaign?.AreaOffset ?? 0) + 2) : count;
        }

        public int MaxAssistArea(ChapterProgress progress)
        {
            return progress.ActiveLevelSet == null ? progress.AreaCount - 1 : progress.MaxArea;
        }

        public int GetUnlockedAreas(ChapterProgress progress,
            ChapterLevelSetStats campaign)
        {
            if (campaign == null || campaign.Name == "Celeste") return progress.UnlockedAreas;
            return campaign.AreaOffset + (string.IsNullOrEmpty(campaign.Name)
                ? CampaignMaxArea(progress, campaign)
                : Math.Max(0, Math.Min(campaign.UnlockedAreas, campaign.AreaCount)));
        }

        public void SetUnlockedAreas(ChapterProgress progress,
            ChapterLevelSetStats campaign, int value)
        {
            if (campaign == null || campaign.Name == "Celeste") progress.UnlockedAreas = value;
            else campaign.UnlockedAreas = value - campaign.AreaOffset;
        }

        public int UnlockedModes(ChapterProgress progress)
        {
            return progress.DebugMode || progress.CheatMode ? 3 : UnlockedModesFor(progress, progress.ActiveLevelSet);
        }

        public int UnlockedModesFor(ChapterProgress progress,
            ChapterLevelSetStats campaign)
        {
            if (campaign == null)
            {
                if (progress.TotalHeartGems >= 16) return 3;
                for (var i = 1; i <= progress.MaxArea; i++)
                    if (progress.Areas[i].Cassette)
                        return 2;
                return 1;
            }

            var maxArea = CampaignMaxArea(progress, campaign);
            var completedAllBSides = true;
            for (var i = 0; i <= maxArea; i++)
            {
                var data = progress.LevelSetAreas[campaign.AreaOffset + i].Data;
                if (!data.HasMode(1)) continue;
                var stats = campaign.Areas[i].Modes[1];
                if (data.CountsAsChapter &&
                    !(data.Modes[1].CompletionCollectibleDetected ? stats.HeartGem : stats.Completed))
                    completedAllBSides = false;
            }

            if (completedAllBSides) return 3;
            for (var i = 0; i <= maxArea; i++)
                if (progress.LevelSetAreas[campaign.AreaOffset + i].Data.CountsAsChapter && campaign.Areas[i].Cassette)
                    return 2;
            return 1;
        }

        public void RegisterCompletionUnlock(ChapterProgress progress,
            ChapterCompletionSession session)
        {
            if (session.AreaID < progress.MaxAreaFor(session.AreaID))
            {
                var campaign = progress.LevelSetAreas != null && session.AreaID < progress.LevelSetAreas.Length
                    ? progress.LevelSets?.Find(value =>
                        value.Name == progress.LevelSetAreas[session.AreaID]?.CampaignId)
                    : null;
                if (campaign == null || campaign.Name == "Celeste")
                    progress.UnlockedAreas = Math.Max(progress.UnlockedAreas, session.AreaID + 1);
                else
                    campaign.UnlockedAreas = Math.Max(campaign.UnlockedAreas, session.AreaID + 1 - campaign.AreaOffset);
            }
        }
    }
}
