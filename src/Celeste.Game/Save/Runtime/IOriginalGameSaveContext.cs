using Celeste.Game.Save.Data;
using Celeste.Core.Maps;
using Celeste.Core.Campaigns;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalGameSaveContext
    {
        OriginalSaveDataState CurrentSave { get; }
        void PublishCurrentSave(OriginalSaveDataState currentSave);
        void AddDeath(CampaignAreaKey area);
        bool HasCheckpoint(CampaignAreaKey area, string level);
        bool SetCheckpoint(CampaignAreaKey area, string level);
        void RegisterCompletion(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session);
        void AddStrawberry(MapEntityId id, bool golden);
        bool CheckStrawberry(MapEntityId id);
    }
}
