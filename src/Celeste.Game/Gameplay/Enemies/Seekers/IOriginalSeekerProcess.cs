using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Particles.Definitions.Seeker;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public interface IOriginalSeekerProcess : IOriginalSeekerFactoryEnvironment, ISourceEngineContext,
        ISourceGameGraphicsEnvironment,
        ISourceVectorEnvironment, ISourceScalarEnvironment, ISourceExtremaEnvironment,
        ISourceSineWaveEnvironment, ISourceRandomEnvironment, ISourceRandomProcessEnvironment,
        ISourceSpatialAudioEnvironment, ISourceFreezeEnvironment, ISourceRenderEnvironment,
        ISourceRumbleEnvironment,
        ISourcePlatformTargetMotionEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
        SeekerParticleDefinitions SeekerParticles { get; }
        SeekerPatrolPoint[] SeekerPatrolChoices { get; }
    }
}
