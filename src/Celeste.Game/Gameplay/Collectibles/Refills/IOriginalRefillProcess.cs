using Celeste.Core.Audio;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Particles.Definitions.Refill;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IOriginalRefillProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceRandomEnvironment,
        ISourceExtremaEnvironment, ISourceSpatialAudioEnvironment, ISourceRumbleEnvironment,
        ISourceFreezeEnvironment
    {
        RefillParticleDefinitions RefillParticles { get; }
    }
}
