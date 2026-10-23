using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Graphics.Content;
using Celeste.Game.Presentation.Particles.Definitions.Refill;

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
