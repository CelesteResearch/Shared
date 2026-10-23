using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public partial class OriginalDreamBlockState
    {
        // ReSharper disable once ConvertToAutoProperty
        protected ISourceEngineContext SourceEngine => engine;
        protected ref bool SourcePlayerHasDreamDash => ref playerHasDreamDash;
        protected ref LightOccludeState SourceOcclude => ref occlude;
        protected ref float SourceWhiteFill => ref whiteFill;
        protected ref float SourceWhiteHeight => ref whiteHeight;
        protected ref Vector2 SourceShake => ref shake;
        protected ref ShakerComponentState SourceShaker => ref shaker;
    }
}
