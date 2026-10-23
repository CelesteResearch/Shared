using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public interface IOriginalAngryOshiroProcess : ISourceEngineContext, ISourceGameGraphicsEnvironment,
        ISourceVectorEnvironment, ISourceScalarEnvironment, ISourceSineWaveEnvironment, ISourceExtremaEnvironment,
        ISourceRandomEnvironment, ISourceSpatialAudioEnvironment, ISourceFreezeEnvironment,
        ISourceRenderEnvironment, ISourceEntitySourceDataEnvironment,
        IOriginalGameInputProcessEnvironment
    {
        ISourceSoundSourceFactory SoundSources { get; }
    }
}
