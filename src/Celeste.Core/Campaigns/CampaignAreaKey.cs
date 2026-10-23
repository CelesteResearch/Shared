namespace Celeste.Core.Campaigns
{
    // Numeric selection identity. Original H / HH asset-name syntax belongs to an original-game formatter.
    public struct CampaignAreaKey
    {
        public int ID;
        public int Mode;

        public CampaignAreaKey(int id, int mode = 0)
        {
            ID = id;
            Mode = mode;
        }
    }
}
