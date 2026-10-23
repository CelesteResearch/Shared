using Celeste.Core.Campaigns;
using Celeste.Core.Maps;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalGameSaveContext
    {
        OriginalSaveDataState CurrentSave { get; }
        void PublishCurrentSave(OriginalSaveDataState currentSave);
        void AddDeath(CampaignAreaKey area);
        bool HasCheckpoint(CampaignAreaKey area, string level);
        bool SetCheckpoint(CampaignAreaKey area, string level);
        void RegisterCompletion(ChapterCompletionSession session);
        void AddStrawberry(MapEntityId id, bool golden);
        bool CheckStrawberry(MapEntityId id);
    }
}
