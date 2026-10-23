using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Game.Execution.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalCassetteManagerScene
    {
        public bool HasCassetteBlocks;
        public float CassetteBlockTempo;
        public int CassetteBlockBeats;

        private void InitializeSourceCassetteFields()
        {
            HasCassetteBlocks = false;
            CassetteBlockTempo = 1f;
            CassetteBlockBeats = 2;
        }

        string IOriginalCassetteManagerScene.SessionRoom => Session.Level;

        string IOriginalCassetteManagerScene.CassetteSong =>
            ((IOriginalSessionConstructionProcess)EngineContext).AreaTable.Areas[Session.AreaID].CassetteSong;

        bool IOriginalCassetteManagerScene.HasCassetteBlocks => HasCassetteBlocks;
        int IOriginalCassetteManagerScene.CassetteBlockBeats => CassetteBlockBeats;
        float IOriginalCassetteManagerScene.CassetteBlockTempo => CassetteBlockTempo;
    }
}
