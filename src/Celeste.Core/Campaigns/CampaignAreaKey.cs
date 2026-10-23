namespace Celeste.Core.Campaigns
{
    // Numeric selection identity. Original H / HH asset-name syntax belongs to an original-game formatter.
    public struct CampaignAreaKey(int id, int mode = 0)
    {
        public int ID = id;
        public int Mode = mode;
    }
}
