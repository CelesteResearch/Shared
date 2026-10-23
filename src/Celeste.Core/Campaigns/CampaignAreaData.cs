namespace Celeste.Core.Campaigns
{
    public sealed class CampaignAreaData
    {
        public int ID;
        public bool CountsAsChapter = true;
        public CampaignModeData[] Modes;

        public bool HasMode(int mode)
        {
            return Modes.Length > mode && Modes[mode] != null && Modes[mode].MapPath != null;
        }
    }
}
