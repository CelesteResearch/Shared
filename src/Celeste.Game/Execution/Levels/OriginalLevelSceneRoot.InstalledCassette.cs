using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Simulation.Gameplay.Platforms.Cassette;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IInstalledCassetteManagerScene
    {
        private IOriginalAreaData SourceCassetteArea =>
            ((IOriginalSessionConstructionProcess)EngineContext).AreaTable.Areas[Session.AreaID];

        string IInstalledCassetteManagerScene.CassetteSong
        {
            get => SourceCassetteArea.CassetteSong;
            set => SourceCassetteArea.CassetteSong = value;
        }

        ICassetteRhythmOptions IInstalledCassetteManagerScene.CassetteModifier =>
            ((IInstalledCassetteAreaData)SourceCassetteArea).CassetteModifier;

        bool IInstalledCassetteManagerScene.HasCassetteBlocks
        {
            get => HasCassetteBlocks;
            set => HasCassetteBlocks = value;
        }

        int IInstalledCassetteManagerScene.CassetteBlockBeats
        {
            get => CassetteBlockBeats;
            set => CassetteBlockBeats = value;
        }

        float IInstalledCassetteManagerScene.CassetteBlockTempo
        {
            get => CassetteBlockTempo;
            set => CassetteBlockTempo = value;
        }

        bool IInstalledCassetteManagerScene.ShouldCreateCassetteManager => ShouldCreateCassetteManager;
    }
}
