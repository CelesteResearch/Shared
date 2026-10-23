namespace Celeste.Game.Audio
{
    /// <summary>LevelExit.GoldenBerryRestart's condition for stopping Summit music.</summary>
    public static class OriginalGoldenRestartAudioPolicy
    {
        public static bool IsStopCandidate(string sessionMusicEvent)
        {
            return sessionMusicEvent == "event:/music/lvl7/main" ||
                   sessionMusicEvent == "event:/music/lvl7/final_ascent";
        }
    }
}
