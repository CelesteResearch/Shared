using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart1(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_RESETCALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SETPOSITIONCALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_READCALLBACK", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SHOULDIPROCESS_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PROCESS_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SETPARAM_FLOAT_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SETPARAM_INT_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SETPARAM_BOOL_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SETPARAM_DATA_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETPARAM_FLOAT_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETPARAM_INT_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETPARAM_BOOL_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETPARAM_DATA_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SYSTEM_REGISTER_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SYSTEM_MIX_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_ALLOC_FUNC", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_REALLOC_FUNC", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_FREE_FUNC", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_LOG_FUNC", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETSAMPLERATE_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETBLOCKSIZE_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETSPEAKERMODE_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETCLOCK_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_GETUSERDATA_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_DFT_FFTREAL_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_DFT_IFFTREAL_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_TYPE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_FLOAT_MAPPING",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC_FLOAT",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC_INT",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC_BOOL",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC_DATA",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC_UNION",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DESC",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_DATA_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_OVERALLGAIN",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_3DATTRIBUTES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_SIDECHAIN",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMETER_FFT",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_DESCRIPTION", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_STATE_DFT_FUNCTIONS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_STATE_PAN_FUNCTIONS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_STATE_FUNCTIONS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_STATE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_METERING_INFO",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_OSCILLATOR", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_LOWPASS", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_ITLOWPASS", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_HIGHPASS", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_ECHO", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_FADER", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_DELAY", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_FLANGE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_TREMOLO", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_DISTORTION", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_NORMALIZE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_LIMITER", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PARAMEQ", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_MULTIBAND_EQ", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PITCHSHIFT", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_CHORUS", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_ITECHO", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_COMPRESSOR", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SFXREVERB", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_LOWPASS_SIMPLE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_SEND", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_RETURN", Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
