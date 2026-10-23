using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public interface IOriginalAngryOshiroProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceVectorEnvironment, ISourceScalarEnvironment, ISourceSineWaveEnvironment, ISourceExtremaEnvironment,
        ISourceRandomEnvironment, ISourceSpatialAudioEnvironment, ISourceFreezeEnvironment,
        ISourceRenderEnvironment, Celeste.Core.Components.ISourceEntitySourceDataEnvironment,
        Celeste.Game.Controls.Source.IOriginalGameInputProcessEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
