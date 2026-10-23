using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Platforms.Cassette;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public interface IInstalledCassetteManagerScene : IOriginalCassetteManagerScene
    {
        new string CassetteSong { get; set; }
        ICassetteRhythmOptions CassetteModifier { get; }
        new bool HasCassetteBlocks { get; set; }
        new int CassetteBlockBeats { get; set; }
        new float CassetteBlockTempo { get; set; }
        bool ShouldCreateCassetteManager { get; }
        ISourceEngineContext EngineContext { get; }
    }
}
