using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart2(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_HIGHPASS_SIMPLE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_MODE_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_PAN", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_THREE_EQ", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_FFT_WINDOW", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_FFT", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_ENVELOPEFOLLOWER",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_CONVOLUTION_REVERB",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_CHANNELMIX_OUTPUT",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_CHANNELMIX", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_TRANSCEIVER_SPEAKERMODE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_TRANSCEIVER", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.DSP_OBJECTPAN", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Error", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664218, "Error", "String", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.STUDIO_VERSION",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.STOP_MODE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.LOADING_STATE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio._3D_ATTRIBUTES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.TIMELINE_MARKER_PROPERTIES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.ADVANCEDSETTINGS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.CPU_USAGE", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.BUFFER_INFO",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.BUFFER_USAGE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.BANK_INFO", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.SYSTEM_CALLBACK_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.SYSTEM_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PARAMETER_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PARAMETER_DESCRIPTION",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.LOAD_MEMORY_MODE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.LOAD_MEMORY_ALIGNMENT",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.SOUND_INFO",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.SOUND_INFO_INTERNAL",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.USER_PROPERTY_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.USER_PROPERTY",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.USER_PROPERTY_INTERNAL",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMAND_INFO_INTERNAL",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.Union_IntBoolFloatString",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.INITFLAGS", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.LOAD_BANK_FLAGS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMANDCAPTURE_FLAGS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMANDREPLAY_FLAGS",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PLAYBACK_STATE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.EVENT_PROPERTY",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.EVENT_CALLBACK_TYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.EVENT_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.INSTANCETYPE",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.COMMAND_INFO",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.Util", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664248, "Util", "ParseID", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664249, "Util", "FMOD_Studio_ParseID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.HandleBase", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664258, "HandleBase", "op_Equality", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664259, "HandleBase", "op_Inequality", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.System", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664260, "System", "create", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664301, "System", "FMOD_Studio_System_Create", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664302, "System", "FMOD_Studio_System_IsValid", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664303, "System", "FMOD_Studio_System_SetAdvancedSettings",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664304, "System", "FMOD_Studio_System_GetAdvancedSettings",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664305, "System", "FMOD_Studio_System_Initialize",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664306, "System", "FMOD_Studio_System_Release", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664307, "System", "FMOD_Studio_System_Update", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664308, "System", "FMOD_Studio_System_GetLowLevelSystem",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664309, "System", "FMOD_Studio_System_GetEvent", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664310, "System", "FMOD_Studio_System_GetBus", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664311, "System", "FMOD_Studio_System_GetVCA", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664312, "System", "FMOD_Studio_System_GetBank", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664313, "System", "FMOD_Studio_System_GetEventByID",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664314, "System", "FMOD_Studio_System_GetBusByID",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664315, "System", "FMOD_Studio_System_GetVCAByID",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664316, "System", "FMOD_Studio_System_GetBankByID",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664317, "System", "FMOD_Studio_System_GetSoundInfo",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664318, "System", "FMOD_Studio_System_LookupID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664319, "System", "FMOD_Studio_System_LookupPath",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664320, "System", "FMOD_Studio_System_GetNumListeners",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664321, "System", "FMOD_Studio_System_SetNumListeners",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664322, "System", "FMOD_Studio_System_GetListenerAttributes",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664323, "System", "FMOD_Studio_System_SetListenerAttributes",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664324, "System", "FMOD_Studio_System_GetListenerWeight",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664325, "System", "FMOD_Studio_System_SetListenerWeight",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664326, "System", "FMOD_Studio_System_LoadBankFile",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664327, "System", "FMOD_Studio_System_LoadBankMemory",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664328, "System", "FMOD_Studio_System_LoadBankCustom",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664329, "System", "FMOD_Studio_System_UnloadAll", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664330, "System", "FMOD_Studio_System_FlushCommands",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664331, "System", "FMOD_Studio_System_FlushSampleLoading",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664332, "System", "FMOD_Studio_System_StartCommandCapture",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664333, "System", "FMOD_Studio_System_StopCommandCapture",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664334, "System", "FMOD_Studio_System_LoadCommandReplay",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664335, "System", "FMOD_Studio_System_GetBankCount",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664336, "System", "FMOD_Studio_System_GetBankList",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664337, "System", "FMOD_Studio_System_GetCPUUsage",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664338, "System", "FMOD_Studio_System_GetBufferUsage",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664339, "System", "FMOD_Studio_System_ResetBufferUsage",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664340, "System", "FMOD_Studio_System_SetCallback",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664341, "System", "FMOD_Studio_System_GetUserData",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664342, "System", "FMOD_Studio_System_SetUserData",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.EventDescription", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664372, "EventDescription", "FMOD_Studio_EventDescription_IsValid",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664373, "EventDescription", "FMOD_Studio_EventDescription_GetID",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664374, "EventDescription", "FMOD_Studio_EventDescription_GetPath",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664375, "EventDescription",
                    "FMOD_Studio_EventDescription_GetParameterCount", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664376, "EventDescription",
                    "FMOD_Studio_EventDescription_GetParameterByIndex", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664377, "EventDescription", "FMOD_Studio_EventDescription_GetParameter",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664378, "EventDescription",
                    "FMOD_Studio_EventDescription_GetUserPropertyCount", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664379, "EventDescription",
                    "FMOD_Studio_EventDescription_GetUserPropertyByIndex", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664380, "EventDescription",
                    "FMOD_Studio_EventDescription_GetUserProperty",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664381, "EventDescription", "FMOD_Studio_EventDescription_GetLength",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664382, "EventDescription",
                    "FMOD_Studio_EventDescription_GetMinimumDistance", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664383, "EventDescription",
                    "FMOD_Studio_EventDescription_GetMaximumDistance", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664384, "EventDescription", "FMOD_Studio_EventDescription_GetSoundSize",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664385, "EventDescription", "FMOD_Studio_EventDescription_IsSnapshot",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664386, "EventDescription", "FMOD_Studio_EventDescription_IsOneshot",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664387, "EventDescription", "FMOD_Studio_EventDescription_IsStream",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664388, "EventDescription", "FMOD_Studio_EventDescription_Is3D",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664389, "EventDescription", "FMOD_Studio_EventDescription_HasCue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664390, "EventDescription",
                    "FMOD_Studio_EventDescription_CreateInstance",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664391, "EventDescription",
                    "FMOD_Studio_EventDescription_GetInstanceCount",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664392, "EventDescription",
                    "FMOD_Studio_EventDescription_GetInstanceList",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664393, "EventDescription",
                    "FMOD_Studio_EventDescription_LoadSampleData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664394, "EventDescription",
                    "FMOD_Studio_EventDescription_UnloadSampleData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664395, "EventDescription",
                    "FMOD_Studio_EventDescription_GetSampleLoadingState", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664396, "EventDescription",
                    "FMOD_Studio_EventDescription_ReleaseAllInstances", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664397, "EventDescription", "FMOD_Studio_EventDescription_SetCallback",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664398, "EventDescription", "FMOD_Studio_EventDescription_GetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664399, "EventDescription", "FMOD_Studio_EventDescription_SetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.EventInstance", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664437, "EventInstance", "FMOD_Studio_EventInstance_IsValid",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664438, "EventInstance", "FMOD_Studio_EventInstance_GetDescription",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664439, "EventInstance", "FMOD_Studio_EventInstance_GetVolume",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664440, "EventInstance", "FMOD_Studio_EventInstance_SetVolume",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664441, "EventInstance", "FMOD_Studio_EventInstance_GetPitch",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664442, "EventInstance", "FMOD_Studio_EventInstance_SetPitch",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664443, "EventInstance", "FMOD_Studio_EventInstance_Get3DAttributes",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664444, "EventInstance", "FMOD_Studio_EventInstance_Set3DAttributes",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664445, "EventInstance", "FMOD_Studio_EventInstance_GetListenerMask",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664446, "EventInstance", "FMOD_Studio_EventInstance_SetListenerMask",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664447, "EventInstance", "FMOD_Studio_EventInstance_GetProperty",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664448, "EventInstance", "FMOD_Studio_EventInstance_SetProperty",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664449, "EventInstance", "FMOD_Studio_EventInstance_GetReverbLevel",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664450, "EventInstance", "FMOD_Studio_EventInstance_SetReverbLevel",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664451, "EventInstance", "FMOD_Studio_EventInstance_GetPaused",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664452, "EventInstance", "FMOD_Studio_EventInstance_SetPaused",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664453, "EventInstance", "FMOD_Studio_EventInstance_Start",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664454, "EventInstance", "FMOD_Studio_EventInstance_Stop",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664455, "EventInstance",
                    "FMOD_Studio_EventInstance_GetTimelinePosition",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664456, "EventInstance",
                    "FMOD_Studio_EventInstance_SetTimelinePosition",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664457, "EventInstance", "FMOD_Studio_EventInstance_GetPlaybackState",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664458, "EventInstance", "FMOD_Studio_EventInstance_GetChannelGroup",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664459, "EventInstance", "FMOD_Studio_EventInstance_Release",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664460, "EventInstance", "FMOD_Studio_EventInstance_IsVirtual",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664461, "EventInstance", "FMOD_Studio_EventInstance_GetParameter",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664462, "EventInstance",
                    "FMOD_Studio_EventInstance_GetParameterByIndex",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664463, "EventInstance", "FMOD_Studio_EventInstance_GetParameterCount",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664464, "EventInstance", "FMOD_Studio_EventInstance_GetParameterValue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664465, "EventInstance", "FMOD_Studio_EventInstance_SetParameterValue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664466, "EventInstance",
                    "FMOD_Studio_EventInstance_GetParameterValueByIndex", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664467, "EventInstance",
                    "FMOD_Studio_EventInstance_SetParameterValueByIndex", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664468, "EventInstance",
                    "FMOD_Studio_EventInstance_SetParameterValuesByIndices", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664469, "EventInstance", "FMOD_Studio_EventInstance_TriggerCue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664470, "EventInstance", "FMOD_Studio_EventInstance_SetCallback",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664471, "EventInstance", "FMOD_Studio_EventInstance_GetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664472, "EventInstance", "FMOD_Studio_EventInstance_SetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.ParameterInstance", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664478, "ParameterInstance", "FMOD_Studio_ParameterInstance_IsValid",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664479, "ParameterInstance",
                    "FMOD_Studio_ParameterInstance_GetDescription",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664480, "ParameterInstance", "FMOD_Studio_ParameterInstance_GetValue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664481, "ParameterInstance", "FMOD_Studio_ParameterInstance_SetValue",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.Bus", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664496, "Bus", "FMOD_Studio_Bus_IsValid", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664497, "Bus", "FMOD_Studio_Bus_GetID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664498, "Bus", "FMOD_Studio_Bus_GetPath", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664499, "Bus", "FMOD_Studio_Bus_GetVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664500, "Bus", "FMOD_Studio_Bus_SetVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664501, "Bus", "FMOD_Studio_Bus_GetPaused", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664502, "Bus", "FMOD_Studio_Bus_SetPaused", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664503, "Bus", "FMOD_Studio_Bus_GetMute", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664504, "Bus", "FMOD_Studio_Bus_SetMute", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664505, "Bus", "FMOD_Studio_Bus_StopAllEvents", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664506, "Bus", "FMOD_Studio_Bus_LockChannelGroup",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664507, "Bus", "FMOD_Studio_Bus_UnlockChannelGroup",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664508, "Bus", "FMOD_Studio_Bus_GetChannelGroup", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.VCA", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664515, "VCA", "FMOD_Studio_VCA_IsValid", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664516, "VCA", "FMOD_Studio_VCA_GetID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664517, "VCA", "FMOD_Studio_VCA_GetPath", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664518, "VCA", "FMOD_Studio_VCA_GetVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664519, "VCA", "FMOD_Studio_VCA_SetVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.Bank", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664539, "Bank", "FMOD_Studio_Bank_IsValid", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664540, "Bank", "FMOD_Studio_Bank_GetID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664541, "Bank", "FMOD_Studio_Bank_GetPath", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664542, "Bank", "FMOD_Studio_Bank_Unload", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664543, "Bank", "FMOD_Studio_Bank_LoadSampleData",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664544, "Bank", "FMOD_Studio_Bank_UnloadSampleData",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664545, "Bank", "FMOD_Studio_Bank_GetLoadingState",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664546, "Bank", "FMOD_Studio_Bank_GetSampleLoadingState",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664547, "Bank", "FMOD_Studio_Bank_GetStringCount",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664548, "Bank", "FMOD_Studio_Bank_GetStringInfo", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664549, "Bank", "FMOD_Studio_Bank_GetEventCount", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664550, "Bank", "FMOD_Studio_Bank_GetEventList", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664551, "Bank", "FMOD_Studio_Bank_GetBusCount", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664552, "Bank", "FMOD_Studio_Bank_GetBusList", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664553, "Bank", "FMOD_Studio_Bank_GetVCACount", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664554, "Bank", "FMOD_Studio_Bank_GetVCAList", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664555, "Bank", "FMOD_Studio_Bank_GetUserData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664556, "Bank", "FMOD_Studio_Bank_SetUserData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.CommandReplay", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664580, "CommandReplay", "FMOD_Studio_CommandReplay_IsValid",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664581, "CommandReplay", "FMOD_Studio_CommandReplay_GetSystem",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664582, "CommandReplay", "FMOD_Studio_CommandReplay_GetLength",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664583, "CommandReplay", "FMOD_Studio_CommandReplay_GetCommandCount",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664584, "CommandReplay", "FMOD_Studio_CommandReplay_GetCommandInfo",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664585, "CommandReplay", "FMOD_Studio_CommandReplay_GetCommandString",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664586, "CommandReplay", "FMOD_Studio_CommandReplay_GetCommandAtTime",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664587, "CommandReplay", "FMOD_Studio_CommandReplay_SetBankPath",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664588, "CommandReplay", "FMOD_Studio_CommandReplay_Start",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664589, "CommandReplay", "FMOD_Studio_CommandReplay_Stop",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664590, "CommandReplay", "FMOD_Studio_CommandReplay_SeekToTime",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664591, "CommandReplay", "FMOD_Studio_CommandReplay_SeekToCommand",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664592, "CommandReplay", "FMOD_Studio_CommandReplay_GetPaused",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664593, "CommandReplay", "FMOD_Studio_CommandReplay_SetPaused",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664594, "CommandReplay", "FMOD_Studio_CommandReplay_GetPlaybackState",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664595, "CommandReplay", "FMOD_Studio_CommandReplay_GetCurrentCommand",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664596, "CommandReplay", "FMOD_Studio_CommandReplay_Release",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664597, "CommandReplay", "FMOD_Studio_CommandReplay_SetFrameCallback",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664598, "CommandReplay",
                    "FMOD_Studio_CommandReplay_SetLoadBankCallback",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664599, "CommandReplay",
                    "FMOD_Studio_CommandReplay_SetCreateInstanceCallback", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664600, "CommandReplay", "FMOD_Studio_CommandReplay_GetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664601, "CommandReplay", "FMOD_Studio_CommandReplay_SetUserData",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("FMOD.Studio.MarshallingHelper", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664604, "MarshallingHelper", "stringLengthUtf8", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664605, "MarshallingHelper", "stringFromNativeUtf8",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Binding", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664620, "Binding", "SetExclusive", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.ParticleEmitter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Circle", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PointSectors", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Collide", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664651, "Collide", "Check", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664652, "Collide", "Check", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664653, "Collide", "Check", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664654, "Collide", "Check", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664655, "Collide", "First", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664656, "Collide", "First", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664657, "Collide", "All", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664658, "Collide", "All", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664659, "Collide", "All", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664660, "Collide", "All", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664661, "Collide", "CheckPoint", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664662, "Collide", "CheckPoint", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664663, "Collide", "CheckLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664664, "Collide", "CheckLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664665, "Collide", "CheckRect", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664666, "Collide", "CheckRect", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664667, "Collide", "LineCheck", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664668, "Collide", "LineCheck", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664669, "Collide", "CircleToLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664670, "Collide", "CircleToPoint", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664671, "Collide", "CircleToRect", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664672, "Collide", "CircleToRect", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664673, "Collide", "RectToCircle", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664674, "Collide", "RectToCircle", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664675, "Collide", "RectToLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664676, "Collide", "RectToLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664677, "Collide", "RectToPoint", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664678, "Collide", "RectToPoint", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664679, "Collide", "GetSector", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100664680, "Collide", "GetSector", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Collider", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.ColliderList", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Grid", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664813, "Grid", "IsBitstringEmpty", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Hitbox", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Component", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.GraphicsComponent",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
