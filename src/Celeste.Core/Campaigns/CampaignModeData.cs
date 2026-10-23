namespace Celeste.Core.Campaigns
{
    public sealed class CampaignModeData
    {
        public string MapPath;

        // A content scan detected the collectible identified by the content provider's progression policy.
        // This does not mean the collectible has been collected or that the level is complete.
        public bool CompletionCollectibleDetected;
        public CampaignCheckpointData[] Checkpoints;
        public Collectibles.CheckpointCollectibleCatalog Collectibles = new Collectibles.CheckpointCollectibleCatalog();
    }
}
