using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Simulation.Gameplay.Platforms.Cassette;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed partial class EverestArea : IInstalledCassetteAreaData
    {
        ICassetteRhythmOptions IInstalledCassetteAreaData.CassetteModifier => Metadata?.CassetteModifier;
    }
}
