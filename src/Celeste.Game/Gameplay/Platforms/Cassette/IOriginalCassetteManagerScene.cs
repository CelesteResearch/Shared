namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public interface IOriginalCassetteManagerScene
    {
        string SessionRoom { get; }
        string CassetteSong { get; }
        bool HasCassetteBlocks { get; }
        int CassetteBlockBeats { get; }
        float CassetteBlockTempo { get; }
    }
}
