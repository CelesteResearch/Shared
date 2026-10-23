using Celeste.Core.Campaigns;

namespace Celeste.Game.Menus.Chapters
{
    public static class OriginalChapterPreviewKey
    {
        // Preserve the old current-culture ID conversion and exact H / HH spelling.
        public static string Format(CampaignAreaKey area)
            => area.ID.ToString() + (area.Mode == 1 ? "H" : area.Mode == 2 ? "HH" : "");
    }
}
