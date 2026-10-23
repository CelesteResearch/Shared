namespace Celeste.Game.Audio
{
    /// <summary>LevelExit.Begin's completed-area music choice.</summary>
    public static class OriginalCompletionMusicPolicy
    {
        public static string SelectEvent(int areaMode, int areaId)
            => areaMode != 0 ? "event:/music/menu/complete_bside"
                : areaId == 7 ? "event:/music/menu/complete_summit"
                : "event:/music/menu/complete_area";
    }
}
