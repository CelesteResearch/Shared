using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart0(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("SimplexNoise.Noise", "SimplexNoise.Noise", "Noise", assemblyIdentity,
                "Celeste", 33554434, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("SimplexNoise.Noise", 0, true);
            catalog.PublishDeclaredTrackedAliases("SimplexNoise.Noise",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.VERSION", "FMOD.VERSION", "VERSION", assemblyIdentity, "Celeste",
                33554435, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.VERSION", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.VERSION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CONSTANTS", "FMOD.CONSTANTS", "CONSTANTS", assemblyIdentity,
                "Celeste",
                33554436, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CONSTANTS", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.CONSTANTS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.RESULT", "FMOD.RESULT", "RESULT", assemblyIdentity, "Celeste",
                33554437,
                false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.RESULT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.RESULT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_TYPE", "FMOD.CHANNELCONTROL_TYPE",
                "CHANNELCONTROL_TYPE",
                assemblyIdentity, "Celeste", 33554438, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.VECTOR", "FMOD.VECTOR", "VECTOR", assemblyIdentity, "Celeste",
                33554439,
                false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.VECTOR", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.VECTOR",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD._3D_ATTRIBUTES", "FMOD._3D_ATTRIBUTES", "_3D_ATTRIBUTES",
                assemblyIdentity, "Celeste", 33554440, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD._3D_ATTRIBUTES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD._3D_ATTRIBUTES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ASYNCREADINFO", "FMOD.ASYNCREADINFO", "ASYNCREADINFO",
                assemblyIdentity,
                "Celeste", 33554441, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ASYNCREADINFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ASYNCREADINFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.OUTPUTTYPE", "FMOD.OUTPUTTYPE", "OUTPUTTYPE", assemblyIdentity,
                "Celeste", 33554442, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.OUTPUTTYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.OUTPUTTYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_MODE", "FMOD.DEBUG_MODE", "DEBUG_MODE", assemblyIdentity,
                "Celeste", 33554443, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_MODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_MODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_FLAGS", "FMOD.DEBUG_FLAGS", "DEBUG_FLAGS", assemblyIdentity,
                "Celeste", 33554444, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_FLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_FLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_TYPE", "FMOD.MEMORY_TYPE", "MEMORY_TYPE", assemblyIdentity,
                "Celeste", 33554445, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SPEAKERMODE", "FMOD.SPEAKERMODE", "SPEAKERMODE", assemblyIdentity,
                "Celeste", 33554446, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SPEAKERMODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SPEAKERMODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SPEAKER", "FMOD.SPEAKER", "SPEAKER", assemblyIdentity, "Celeste",
                33554447, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SPEAKER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SPEAKER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNELMASK", "FMOD.CHANNELMASK", "CHANNELMASK", assemblyIdentity,
                "Celeste", 33554448, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNELMASK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELMASK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNELORDER", "FMOD.CHANNELORDER", "CHANNELORDER", assemblyIdentity,
                "Celeste", 33554449, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNELORDER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELORDER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.PLUGINTYPE", "FMOD.PLUGINTYPE", "PLUGINTYPE", assemblyIdentity,
                "Celeste", 33554450, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.PLUGINTYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.PLUGINTYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.PLUGINLIST", "FMOD.PLUGINLIST", "PLUGINLIST", assemblyIdentity,
                "Celeste", 33554451, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.PLUGINLIST", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.PLUGINLIST",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.INITFLAGS", "FMOD.INITFLAGS", "INITFLAGS", assemblyIdentity,
                "Celeste",
                33554452, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.INITFLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.INITFLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUND_TYPE", "FMOD.SOUND_TYPE", "SOUND_TYPE", assemblyIdentity,
                "Celeste", 33554453, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUND_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUND_FORMAT", "FMOD.SOUND_FORMAT", "SOUND_FORMAT", assemblyIdentity,
                "Celeste", 33554454, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUND_FORMAT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_FORMAT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.MODE", "FMOD.MODE", "MODE", assemblyIdentity, "Celeste", 33554455,
                false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.MODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.MODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.OPENSTATE", "FMOD.OPENSTATE", "OPENSTATE", assemblyIdentity,
                "Celeste",
                33554456, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.OPENSTATE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.OPENSTATE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUNDGROUP_BEHAVIOR", "FMOD.SOUNDGROUP_BEHAVIOR",
                "SOUNDGROUP_BEHAVIOR",
                assemblyIdentity, "Celeste", 33554457, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUNDGROUP_BEHAVIOR", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUNDGROUP_BEHAVIOR",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_CALLBACK_TYPE", "FMOD.CHANNELCONTROL_CALLBACK_TYPE",
                "CHANNELCONTROL_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554458, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_CALLBACK_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_CALLBACK_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_DSP_INDEX", "FMOD.CHANNELCONTROL_DSP_INDEX",
                "CHANNELCONTROL_DSP_INDEX", assemblyIdentity, "Celeste", 33554459, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_DSP_INDEX", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_DSP_INDEX",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ERRORCALLBACK_INSTANCETYPE", "FMOD.ERRORCALLBACK_INSTANCETYPE",
                "ERRORCALLBACK_INSTANCETYPE", assemblyIdentity, "Celeste", 33554460, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ERRORCALLBACK_INSTANCETYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ERRORCALLBACK_INSTANCETYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ERRORCALLBACK_INFO", "FMOD.ERRORCALLBACK_INFO", "ERRORCALLBACK_INFO",
                assemblyIdentity, "Celeste", 33554461, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ERRORCALLBACK_INFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ERRORCALLBACK_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SYSTEM_CALLBACK_TYPE", "FMOD.SYSTEM_CALLBACK_TYPE",
                "SYSTEM_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554462, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SYSTEM_CALLBACK_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SYSTEM_CALLBACK_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.StringWrapper", "FMOD.StringWrapper", "StringWrapper",
                assemblyIdentity,
                "Celeste", 33554463, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.StringWrapper", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.StringWrapper",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ASYNCREADINFO_DONE_CALLBACK", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
                "ASYNCREADINFO_DONE_CALLBACK", assemblyIdentity, "Celeste", 33554464, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ASYNCREADINFO_DONE_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ASYNCREADINFO_DONE_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_CALLBACK", "FMOD.DEBUG_CALLBACK", "DEBUG_CALLBACK",
                assemblyIdentity, "Celeste", 33554465, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SYSTEM_CALLBACK", "FMOD.SYSTEM_CALLBACK", "SYSTEM_CALLBACK",
                assemblyIdentity, "Celeste", 33554466, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SYSTEM_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SYSTEM_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CHANNEL_CALLBACK", "FMOD.CHANNEL_CALLBACK", "CHANNEL_CALLBACK",
                assemblyIdentity, "Celeste", 33554467, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CHANNEL_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CHANNEL_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUND_NONBLOCKCALLBACK", "FMOD.SOUND_NONBLOCKCALLBACK",
                "SOUND_NONBLOCKCALLBACK", assemblyIdentity, "Celeste", 33554468, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUND_NONBLOCKCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_NONBLOCKCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUND_PCMREADCALLBACK", "FMOD.SOUND_PCMREADCALLBACK",
                "SOUND_PCMREADCALLBACK", assemblyIdentity, "Celeste", 33554469, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUND_PCMREADCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_PCMREADCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SOUND_PCMSETPOSCALLBACK", "FMOD.SOUND_PCMSETPOSCALLBACK",
                "SOUND_PCMSETPOSCALLBACK", assemblyIdentity, "Celeste", 33554470, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SOUND_PCMSETPOSCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_PCMSETPOSCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_OPENCALLBACK", "FMOD.FILE_OPENCALLBACK", "FILE_OPENCALLBACK",
                assemblyIdentity, "Celeste", 33554471, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_OPENCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_OPENCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_CLOSECALLBACK", "FMOD.FILE_CLOSECALLBACK", "FILE_CLOSECALLBACK",
                assemblyIdentity, "Celeste", 33554472, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_CLOSECALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_CLOSECALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_READCALLBACK", "FMOD.FILE_READCALLBACK", "FILE_READCALLBACK",
                assemblyIdentity, "Celeste", 33554473, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_READCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_READCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_SEEKCALLBACK", "FMOD.FILE_SEEKCALLBACK", "FILE_SEEKCALLBACK",
                assemblyIdentity, "Celeste", 33554474, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_SEEKCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_SEEKCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_ASYNCREADCALLBACK", "FMOD.FILE_ASYNCREADCALLBACK",
                "FILE_ASYNCREADCALLBACK", assemblyIdentity, "Celeste", 33554475, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_ASYNCREADCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_ASYNCREADCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.FILE_ASYNCCANCELCALLBACK", "FMOD.FILE_ASYNCCANCELCALLBACK",
                "FILE_ASYNCCANCELCALLBACK", assemblyIdentity, "Celeste", 33554476, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.FILE_ASYNCCANCELCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.FILE_ASYNCCANCELCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_ALLOC_CALLBACK", "FMOD.MEMORY_ALLOC_CALLBACK",
                "MEMORY_ALLOC_CALLBACK", assemblyIdentity, "Celeste", 33554477, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_ALLOC_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_ALLOC_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_REALLOC_CALLBACK", "FMOD.MEMORY_REALLOC_CALLBACK",
                "MEMORY_REALLOC_CALLBACK", assemblyIdentity, "Celeste", 33554478, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_REALLOC_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_REALLOC_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_FREE_CALLBACK", "FMOD.MEMORY_FREE_CALLBACK",
                "MEMORY_FREE_CALLBACK", assemblyIdentity, "Celeste", 33554479, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_FREE_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_FREE_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CB_3D_ROLLOFFCALLBACK", "FMOD.CB_3D_ROLLOFFCALLBACK",
                "CB_3D_ROLLOFFCALLBACK", assemblyIdentity, "Celeste", 33554480, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CB_3D_ROLLOFFCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CB_3D_ROLLOFFCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_RESAMPLER", "FMOD.DSP_RESAMPLER", "DSP_RESAMPLER",
                assemblyIdentity,
                "Celeste", 33554481, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_RESAMPLER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RESAMPLER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSPCONNECTION_TYPE", "FMOD.DSPCONNECTION_TYPE", "DSPCONNECTION_TYPE",
                assemblyIdentity, "Celeste", 33554482, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSPCONNECTION_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSPCONNECTION_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.TAGTYPE", "FMOD.TAGTYPE", "TAGTYPE", assemblyIdentity, "Celeste",
                33554483, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.TAGTYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.TAGTYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.TAGDATATYPE", "FMOD.TAGDATATYPE", "TAGDATATYPE", assemblyIdentity,
                "Celeste", 33554484, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.TAGDATATYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.TAGDATATYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.TAG", "FMOD.TAG", "TAG", assemblyIdentity, "Celeste", 33554485,
                false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.TAG", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.TAG",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.TIMEUNIT", "FMOD.TIMEUNIT", "TIMEUNIT", assemblyIdentity, "Celeste",
                33554486, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.TIMEUNIT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.TIMEUNIT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.PORT_INDEX", "FMOD.PORT_INDEX", "PORT_INDEX", assemblyIdentity,
                "Celeste", 33554487, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.PORT_INDEX", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.PORT_INDEX",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.CREATESOUNDEXINFO", "FMOD.CREATESOUNDEXINFO", "CREATESOUNDEXINFO",
                assemblyIdentity, "Celeste", 33554488, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.CREATESOUNDEXINFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.CREATESOUNDEXINFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.REVERB_PROPERTIES", "FMOD.REVERB_PROPERTIES", "REVERB_PROPERTIES",
                assemblyIdentity, "Celeste", 33554489, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.REVERB_PROPERTIES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.REVERB_PROPERTIES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.PRESET", "FMOD.PRESET", "PRESET", assemblyIdentity, "Celeste",
                33554490,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.PRESET", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.PRESET",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ADVANCEDSETTINGS", "FMOD.ADVANCEDSETTINGS", "ADVANCEDSETTINGS",
                assemblyIdentity, "Celeste", 33554491, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ADVANCEDSETTINGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ADVANCEDSETTINGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DRIVER_STATE", "FMOD.DRIVER_STATE", "DRIVER_STATE", assemblyIdentity,
                "Celeste", 33554492, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DRIVER_STATE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DRIVER_STATE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Factory", "FMOD.Factory", "Factory", assemblyIdentity, "Celeste",
                33554493, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Factory", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Factory",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Memory", "FMOD.Memory", "Memory", assemblyIdentity, "Celeste",
                33554494,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Memory", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Memory",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Debug", "FMOD.Debug", "Debug", assemblyIdentity, "Celeste", 33554495,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Debug", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Debug",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.HandleBase", "FMOD.HandleBase", "HandleBase", assemblyIdentity,
                "Celeste", 33554496, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.HandleBase", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.HandleBase",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.System", "FMOD.System", "System", assemblyIdentity, "Celeste",
                33554497,
                false, ["FMOD.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.System", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.System",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Sound", "FMOD.Sound", "Sound", assemblyIdentity, "Celeste", 33554498,
                false, ["FMOD.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Sound", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Sound",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ChannelControl", "FMOD.ChannelControl", "ChannelControl",
                assemblyIdentity, "Celeste", 33554499, false, ["FMOD.HandleBase", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ChannelControl", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ChannelControl",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Channel", "FMOD.Channel", "Channel", assemblyIdentity, "Celeste",
                33554500, false, ["FMOD.ChannelControl", "FMOD.HandleBase", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Channel", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Channel",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.ChannelGroup", "FMOD.ChannelGroup", "ChannelGroup", assemblyIdentity,
                "Celeste", 33554501, false, ["FMOD.ChannelControl", "FMOD.HandleBase", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.ChannelGroup", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.ChannelGroup",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.SoundGroup", "FMOD.SoundGroup", "SoundGroup", assemblyIdentity,
                "Celeste", 33554502, false, ["FMOD.HandleBase", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.SoundGroup", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.SoundGroup",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP", "FMOD.DSP", "DSP", assemblyIdentity, "Celeste", 33554503,
                false,
                ["FMOD.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSPConnection", "FMOD.DSPConnection", "DSPConnection",
                assemblyIdentity,
                "Celeste", 33554504, false, ["FMOD.HandleBase", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSPConnection", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSPConnection",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Geometry", "FMOD.Geometry", "Geometry", assemblyIdentity, "Celeste",
                33554505, false, ["FMOD.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Geometry", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Geometry",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Reverb3D", "FMOD.Reverb3D", "Reverb3D", assemblyIdentity, "Celeste",
                33554506, false, ["FMOD.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Reverb3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Reverb3D",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.StringMarshalHelper", "FMOD.StringMarshalHelper",
                "StringMarshalHelper",
                assemblyIdentity, "Celeste", 33554507, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.StringMarshalHelper", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.StringMarshalHelper",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_BUFFER_ARRAY", "FMOD.DSP_BUFFER_ARRAY", "DSP_BUFFER_ARRAY",
                assemblyIdentity, "Celeste", 33554508, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_BUFFER_ARRAY", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_BUFFER_ARRAY",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PROCESS_OPERATION", "FMOD.DSP_PROCESS_OPERATION",
                "DSP_PROCESS_OPERATION", assemblyIdentity, "Celeste", 33554509, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PROCESS_OPERATION", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PROCESS_OPERATION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.COMPLEX", "FMOD.COMPLEX", "COMPLEX", assemblyIdentity, "Celeste",
                33554510, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.COMPLEX", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.COMPLEX",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SURROUND_FLAGS", "FMOD.DSP_PAN_SURROUND_FLAGS",
                "DSP_PAN_SURROUND_FLAGS", assemblyIdentity, "Celeste", 33554511, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SURROUND_FLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SURROUND_FLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_CREATECALLBACK", "FMOD.DSP_CREATECALLBACK", "DSP_CREATECALLBACK",
                assemblyIdentity, "Celeste", 33554512, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_CREATECALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CREATECALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_RELEASECALLBACK", "FMOD.DSP_RELEASECALLBACK",
                "DSP_RELEASECALLBACK",
                assemblyIdentity, "Celeste", 33554513, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_RELEASECALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RELEASECALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_RESETCALLBACK", "FMOD.DSP_RESETCALLBACK", "DSP_RESETCALLBACK",
                assemblyIdentity, "Celeste", 33554514, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_RESETCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RESETCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPOSITIONCALLBACK", "FMOD.DSP_SETPOSITIONCALLBACK",
                "DSP_SETPOSITIONCALLBACK", assemblyIdentity, "Celeste", 33554515, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPOSITIONCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPOSITIONCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_READCALLBACK", "FMOD.DSP_READCALLBACK", "DSP_READCALLBACK",
                assemblyIdentity, "Celeste", 33554516, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_READCALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_READCALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SHOULDIPROCESS_CALLBACK", "FMOD.DSP_SHOULDIPROCESS_CALLBACK",
                "DSP_SHOULDIPROCESS_CALLBACK", assemblyIdentity, "Celeste", 33554517, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SHOULDIPROCESS_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SHOULDIPROCESS_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PROCESS_CALLBACK", "FMOD.DSP_PROCESS_CALLBACK",
                "DSP_PROCESS_CALLBACK", assemblyIdentity, "Celeste", 33554518, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PROCESS_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PROCESS_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_FLOAT_CALLBACK", "FMOD.DSP_SETPARAM_FLOAT_CALLBACK",
                "DSP_SETPARAM_FLOAT_CALLBACK", assemblyIdentity, "Celeste", 33554519, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_FLOAT_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_FLOAT_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_INT_CALLBACK", "FMOD.DSP_SETPARAM_INT_CALLBACK",
                "DSP_SETPARAM_INT_CALLBACK", assemblyIdentity, "Celeste", 33554520, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_INT_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_INT_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_BOOL_CALLBACK", "FMOD.DSP_SETPARAM_BOOL_CALLBACK",
                "DSP_SETPARAM_BOOL_CALLBACK", assemblyIdentity, "Celeste", 33554521, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_BOOL_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_BOOL_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_DATA_CALLBACK", "FMOD.DSP_SETPARAM_DATA_CALLBACK",
                "DSP_SETPARAM_DATA_CALLBACK", assemblyIdentity, "Celeste", 33554522, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_DATA_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_DATA_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_FLOAT_CALLBACK", "FMOD.DSP_GETPARAM_FLOAT_CALLBACK",
                "DSP_GETPARAM_FLOAT_CALLBACK", assemblyIdentity, "Celeste", 33554523, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_FLOAT_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_FLOAT_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_INT_CALLBACK", "FMOD.DSP_GETPARAM_INT_CALLBACK",
                "DSP_GETPARAM_INT_CALLBACK", assemblyIdentity, "Celeste", 33554524, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_INT_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_INT_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_BOOL_CALLBACK", "FMOD.DSP_GETPARAM_BOOL_CALLBACK",
                "DSP_GETPARAM_BOOL_CALLBACK", assemblyIdentity, "Celeste", 33554525, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_BOOL_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_BOOL_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_DATA_CALLBACK", "FMOD.DSP_GETPARAM_DATA_CALLBACK",
                "DSP_GETPARAM_DATA_CALLBACK", assemblyIdentity, "Celeste", 33554526, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_DATA_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_DATA_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_REGISTER_CALLBACK", "FMOD.DSP_SYSTEM_REGISTER_CALLBACK",
                "DSP_SYSTEM_REGISTER_CALLBACK", assemblyIdentity, "Celeste", 33554527, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_REGISTER_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_REGISTER_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
                "FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
                "DSP_SYSTEM_DEREGISTER_CALLBACK", assemblyIdentity, "Celeste", 33554528, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_MIX_CALLBACK", "FMOD.DSP_SYSTEM_MIX_CALLBACK",
                "DSP_SYSTEM_MIX_CALLBACK", assemblyIdentity, "Celeste", 33554529, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_MIX_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_MIX_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_ALLOC_FUNC", "FMOD.DSP_ALLOC_FUNC", "DSP_ALLOC_FUNC",
                assemblyIdentity, "Celeste", 33554530, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_ALLOC_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ALLOC_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_REALLOC_FUNC", "FMOD.DSP_REALLOC_FUNC", "DSP_REALLOC_FUNC",
                assemblyIdentity, "Celeste", 33554531, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_REALLOC_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_REALLOC_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_FREE_FUNC", "FMOD.DSP_FREE_FUNC", "DSP_FREE_FUNC",
                assemblyIdentity,
                "Celeste", 33554532, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_FREE_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FREE_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOG_FUNC", "FMOD.DSP_LOG_FUNC", "DSP_LOG_FUNC", assemblyIdentity,
                "Celeste", 33554533, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOG_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOG_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETSAMPLERATE_FUNC", "FMOD.DSP_GETSAMPLERATE_FUNC",
                "DSP_GETSAMPLERATE_FUNC", assemblyIdentity, "Celeste", 33554534, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETSAMPLERATE_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETSAMPLERATE_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETBLOCKSIZE_FUNC", "FMOD.DSP_GETBLOCKSIZE_FUNC",
                "DSP_GETBLOCKSIZE_FUNC", assemblyIdentity, "Celeste", 33554535, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETBLOCKSIZE_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETBLOCKSIZE_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETSPEAKERMODE_FUNC", "FMOD.DSP_GETSPEAKERMODE_FUNC",
                "DSP_GETSPEAKERMODE_FUNC", assemblyIdentity, "Celeste", 33554536, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETSPEAKERMODE_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETSPEAKERMODE_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETCLOCK_FUNC", "FMOD.DSP_GETCLOCK_FUNC", "DSP_GETCLOCK_FUNC",
                assemblyIdentity, "Celeste", 33554537, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETCLOCK_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETCLOCK_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
                "FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
                "DSP_GETLISTENERATTRIBUTES_FUNC", assemblyIdentity, "Celeste", 33554538, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETUSERDATA_FUNC", "FMOD.DSP_GETUSERDATA_FUNC",
                "DSP_GETUSERDATA_FUNC", assemblyIdentity, "Celeste", 33554539, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETUSERDATA_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETUSERDATA_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_DFT_FFTREAL_FUNC", "FMOD.DSP_DFT_FFTREAL_FUNC",
                "DSP_DFT_FFTREAL_FUNC", assemblyIdentity, "Celeste", 33554540, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_DFT_FFTREAL_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DFT_FFTREAL_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_DFT_IFFTREAL_FUNC", "FMOD.DSP_DFT_IFFTREAL_FUNC",
                "DSP_DFT_IFFTREAL_FUNC", assemblyIdentity, "Celeste", 33554541, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_DFT_IFFTREAL_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DFT_IFFTREAL_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC", "FMOD.DSP_PAN_SUMMONOMATRIX_FUNC",
                "DSP_PAN_SUMMONOMATRIX_FUNC", assemblyIdentity, "Celeste", 33554542, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC", "FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC",
                "DSP_PAN_SUMSTEREOMATRIX_FUNC", assemblyIdentity, "Celeste", 33554543, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
                "FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
                "DSP_PAN_SUMSURROUNDMATRIX_FUNC", assemblyIdentity, "Celeste", 33554544, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC",
                "FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", "DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", assemblyIdentity,
                "Celeste", 33554545, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
                "FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC", "DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
                assemblyIdentity,
                "Celeste", 33554546, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC", "FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC",
                "DSP_PAN_GETROLLOFFGAIN_FUNC", assemblyIdentity, "Celeste", 33554547, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_TYPE", "FMOD.DSP_TYPE", "DSP_TYPE", assemblyIdentity, "Celeste",
                33554548, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_TYPE", "FMOD.DSP_PARAMETER_TYPE", "DSP_PARAMETER_TYPE",
                assemblyIdentity, "Celeste", 33554549, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE",
                "FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE", "DSP_PARAMETER_FLOAT_MAPPING_TYPE", assemblyIdentity,
                "Celeste",
                33554550, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
                "FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR", "DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
                assemblyIdentity, "Celeste", 33554551, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING", "FMOD.DSP_PARAMETER_FLOAT_MAPPING",
                "DSP_PARAMETER_FLOAT_MAPPING", assemblyIdentity, "Celeste", 33554552, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_FLOAT", "FMOD.DSP_PARAMETER_DESC_FLOAT",
                "DSP_PARAMETER_DESC_FLOAT", assemblyIdentity, "Celeste", 33554553, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_FLOAT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_FLOAT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_INT", "FMOD.DSP_PARAMETER_DESC_INT",
                "DSP_PARAMETER_DESC_INT", assemblyIdentity, "Celeste", 33554554, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_INT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_INT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_BOOL", "FMOD.DSP_PARAMETER_DESC_BOOL",
                "DSP_PARAMETER_DESC_BOOL", assemblyIdentity, "Celeste", 33554555, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_BOOL", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_BOOL",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_DATA", "FMOD.DSP_PARAMETER_DESC_DATA",
                "DSP_PARAMETER_DESC_DATA", assemblyIdentity, "Celeste", 33554556, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_DATA", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_DATA",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_UNION", "FMOD.DSP_PARAMETER_DESC_UNION",
                "DSP_PARAMETER_DESC_UNION", assemblyIdentity, "Celeste", 33554557, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_UNION", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_UNION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC", "FMOD.DSP_PARAMETER_DESC", "DSP_PARAMETER_DESC",
                assemblyIdentity, "Celeste", 33554558, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DATA_TYPE", "FMOD.DSP_PARAMETER_DATA_TYPE",
                "DSP_PARAMETER_DATA_TYPE", assemblyIdentity, "Celeste", 33554559, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DATA_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DATA_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_OVERALLGAIN", "FMOD.DSP_PARAMETER_OVERALLGAIN",
                "DSP_PARAMETER_OVERALLGAIN", assemblyIdentity, "Celeste", 33554560, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_OVERALLGAIN", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_OVERALLGAIN",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES", "FMOD.DSP_PARAMETER_3DATTRIBUTES",
                "DSP_PARAMETER_3DATTRIBUTES", assemblyIdentity, "Celeste", 33554561, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_3DATTRIBUTES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI",
                "FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI", "DSP_PARAMETER_3DATTRIBUTES_MULTI", assemblyIdentity,
                "Celeste",
                33554562, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_SIDECHAIN", "FMOD.DSP_PARAMETER_SIDECHAIN",
                "DSP_PARAMETER_SIDECHAIN", assemblyIdentity, "Celeste", 33554563, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_SIDECHAIN", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_SIDECHAIN",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FFT", "FMOD.DSP_PARAMETER_FFT", "DSP_PARAMETER_FFT",
                assemblyIdentity, "Celeste", 33554564, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FFT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FFT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_DESCRIPTION", "FMOD.DSP_DESCRIPTION", "DSP_DESCRIPTION",
                assemblyIdentity, "Celeste", 33554565, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_DESCRIPTION", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DESCRIPTION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_DFT_FUNCTIONS", "FMOD.DSP_STATE_DFT_FUNCTIONS",
                "DSP_STATE_DFT_FUNCTIONS", assemblyIdentity, "Celeste", 33554566, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_DFT_FUNCTIONS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_DFT_FUNCTIONS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_PAN_FUNCTIONS", "FMOD.DSP_STATE_PAN_FUNCTIONS",
                "DSP_STATE_PAN_FUNCTIONS", assemblyIdentity, "Celeste", 33554567, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_PAN_FUNCTIONS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_PAN_FUNCTIONS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_FUNCTIONS", "FMOD.DSP_STATE_FUNCTIONS",
                "DSP_STATE_FUNCTIONS",
                assemblyIdentity, "Celeste", 33554568, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_FUNCTIONS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_FUNCTIONS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE", "FMOD.DSP_STATE", "DSP_STATE", assemblyIdentity,
                "Celeste",
                33554569, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_METERING_INFO", "FMOD.DSP_METERING_INFO", "DSP_METERING_INFO",
                assemblyIdentity, "Celeste", 33554570, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_METERING_INFO", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_METERING_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_OSCILLATOR", "FMOD.DSP_OSCILLATOR", "DSP_OSCILLATOR",
                assemblyIdentity, "Celeste", 33554571, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_OSCILLATOR", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_OSCILLATOR",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOWPASS", "FMOD.DSP_LOWPASS", "DSP_LOWPASS", assemblyIdentity,
                "Celeste", 33554572, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOWPASS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOWPASS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_ITLOWPASS", "FMOD.DSP_ITLOWPASS", "DSP_ITLOWPASS",
                assemblyIdentity,
                "Celeste", 33554573, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_ITLOWPASS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ITLOWPASS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_HIGHPASS", "FMOD.DSP_HIGHPASS", "DSP_HIGHPASS", assemblyIdentity,
                "Celeste", 33554574, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_HIGHPASS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_HIGHPASS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_ECHO", "FMOD.DSP_ECHO", "DSP_ECHO", assemblyIdentity, "Celeste",
                33554575, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_ECHO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ECHO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_FADER", "FMOD.DSP_FADER", "DSP_FADER", assemblyIdentity,
                "Celeste",
                33554576, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_FADER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FADER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_DELAY", "FMOD.DSP_DELAY", "DSP_DELAY", assemblyIdentity,
                "Celeste",
                33554577, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_DELAY", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DELAY",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_FLANGE", "FMOD.DSP_FLANGE", "DSP_FLANGE", assemblyIdentity,
                "Celeste", 33554578, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_FLANGE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FLANGE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_TREMOLO", "FMOD.DSP_TREMOLO", "DSP_TREMOLO", assemblyIdentity,
                "Celeste", 33554579, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_TREMOLO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TREMOLO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_DISTORTION", "FMOD.DSP_DISTORTION", "DSP_DISTORTION",
                assemblyIdentity, "Celeste", 33554580, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_DISTORTION", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DISTORTION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_NORMALIZE", "FMOD.DSP_NORMALIZE", "DSP_NORMALIZE",
                assemblyIdentity,
                "Celeste", 33554581, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_NORMALIZE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_NORMALIZE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_LIMITER", "FMOD.DSP_LIMITER", "DSP_LIMITER", assemblyIdentity,
                "Celeste", 33554582, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_LIMITER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LIMITER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMEQ", "FMOD.DSP_PARAMEQ", "DSP_PARAMEQ", assemblyIdentity,
                "Celeste", 33554583, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMEQ", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMEQ",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_MULTIBAND_EQ", "FMOD.DSP_MULTIBAND_EQ", "DSP_MULTIBAND_EQ",
                assemblyIdentity, "Celeste", 33554584, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_MULTIBAND_EQ", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_MULTIBAND_EQ",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE", "FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE",
                "DSP_MULTIBAND_EQ_FILTER_TYPE", assemblyIdentity, "Celeste", 33554585, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PITCHSHIFT", "FMOD.DSP_PITCHSHIFT", "DSP_PITCHSHIFT",
                assemblyIdentity, "Celeste", 33554586, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PITCHSHIFT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PITCHSHIFT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHORUS", "FMOD.DSP_CHORUS", "DSP_CHORUS", assemblyIdentity,
                "Celeste", 33554587, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHORUS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHORUS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_ITECHO", "FMOD.DSP_ITECHO", "DSP_ITECHO", assemblyIdentity,
                "Celeste", 33554588, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_ITECHO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ITECHO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_COMPRESSOR", "FMOD.DSP_COMPRESSOR", "DSP_COMPRESSOR",
                assemblyIdentity, "Celeste", 33554589, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_COMPRESSOR", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_COMPRESSOR",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SFXREVERB", "FMOD.DSP_SFXREVERB", "DSP_SFXREVERB",
                assemblyIdentity,
                "Celeste", 33554590, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SFXREVERB", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SFXREVERB",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOWPASS_SIMPLE", "FMOD.DSP_LOWPASS_SIMPLE", "DSP_LOWPASS_SIMPLE",
                assemblyIdentity, "Celeste", 33554591, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOWPASS_SIMPLE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOWPASS_SIMPLE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_SEND", "FMOD.DSP_SEND", "DSP_SEND", assemblyIdentity, "Celeste",
                33554592, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_SEND", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SEND",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_RETURN", "FMOD.DSP_RETURN", "DSP_RETURN", assemblyIdentity,
                "Celeste", 33554593, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_RETURN", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RETURN",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_HIGHPASS_SIMPLE", "FMOD.DSP_HIGHPASS_SIMPLE",
                "DSP_HIGHPASS_SIMPLE",
                assemblyIdentity, "Celeste", 33554594, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_HIGHPASS_SIMPLE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_HIGHPASS_SIMPLE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                "DSP_PAN_2D_STEREO_MODE_TYPE", assemblyIdentity, "Celeste", 33554595, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_MODE_TYPE", "FMOD.DSP_PAN_MODE_TYPE", "DSP_PAN_MODE_TYPE",
                assemblyIdentity, "Celeste", 33554596, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_MODE_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_MODE_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_3D_ROLLOFF_TYPE", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                "DSP_PAN_3D_ROLLOFF_TYPE", assemblyIdentity, "Celeste", 33554597, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_3D_ROLLOFF_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                "DSP_PAN_3D_EXTENT_MODE_TYPE", assemblyIdentity, "Celeste", 33554598, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN", "FMOD.DSP_PAN", "DSP_PAN", assemblyIdentity, "Celeste",
                33554599, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", "DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", assemblyIdentity,
                "Celeste",
                33554600, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_THREE_EQ", "FMOD.DSP_THREE_EQ", "DSP_THREE_EQ", assemblyIdentity,
                "Celeste", 33554601, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_THREE_EQ", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_THREE_EQ",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_FFT_WINDOW", "FMOD.DSP_FFT_WINDOW", "DSP_FFT_WINDOW",
                assemblyIdentity, "Celeste", 33554602, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_FFT_WINDOW", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FFT_WINDOW",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_FFT", "FMOD.DSP_FFT", "DSP_FFT", assemblyIdentity, "Celeste",
                33554603, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_FFT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FFT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_ENVELOPEFOLLOWER", "FMOD.DSP_ENVELOPEFOLLOWER",
                "DSP_ENVELOPEFOLLOWER", assemblyIdentity, "Celeste", 33554604, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_ENVELOPEFOLLOWER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ENVELOPEFOLLOWER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_CONVOLUTION_REVERB", "FMOD.DSP_CONVOLUTION_REVERB",
                "DSP_CONVOLUTION_REVERB", assemblyIdentity, "Celeste", 33554605, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_CONVOLUTION_REVERB", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CONVOLUTION_REVERB",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHANNELMIX_OUTPUT", "FMOD.DSP_CHANNELMIX_OUTPUT",
                "DSP_CHANNELMIX_OUTPUT", assemblyIdentity, "Celeste", 33554606, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHANNELMIX_OUTPUT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHANNELMIX_OUTPUT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHANNELMIX", "FMOD.DSP_CHANNELMIX", "DSP_CHANNELMIX",
                assemblyIdentity, "Celeste", 33554607, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHANNELMIX", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHANNELMIX",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_TRANSCEIVER_SPEAKERMODE", "FMOD.DSP_TRANSCEIVER_SPEAKERMODE",
                "DSP_TRANSCEIVER_SPEAKERMODE", assemblyIdentity, "Celeste", 33554608, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_TRANSCEIVER_SPEAKERMODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TRANSCEIVER_SPEAKERMODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_TRANSCEIVER", "FMOD.DSP_TRANSCEIVER", "DSP_TRANSCEIVER",
                assemblyIdentity, "Celeste", 33554609, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_TRANSCEIVER", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TRANSCEIVER",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.DSP_OBJECTPAN", "FMOD.DSP_OBJECTPAN", "DSP_OBJECTPAN",
                assemblyIdentity,
                "Celeste", 33554610, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.DSP_OBJECTPAN", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.DSP_OBJECTPAN",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Error", "FMOD.Error", "Error", assemblyIdentity, "Celeste", 33554611,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Error", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Error",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.STUDIO_VERSION", "FMOD.Studio.STUDIO_VERSION",
                "STUDIO_VERSION",
                assemblyIdentity, "Celeste", 33554612, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.STUDIO_VERSION", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.STUDIO_VERSION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.STOP_MODE", "FMOD.Studio.STOP_MODE", "STOP_MODE",
                assemblyIdentity, "Celeste", 33554613, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.STOP_MODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.STOP_MODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOADING_STATE", "FMOD.Studio.LOADING_STATE", "LOADING_STATE",
                assemblyIdentity, "Celeste", 33554614, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOADING_STATE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOADING_STATE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio._3D_ATTRIBUTES", "FMOD.Studio._3D_ATTRIBUTES",
                "_3D_ATTRIBUTES",
                assemblyIdentity, "Celeste", 33554615, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio._3D_ATTRIBUTES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio._3D_ATTRIBUTES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES",
                "FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES", "PROGRAMMER_SOUND_PROPERTIES", assemblyIdentity, "Celeste",
                33554616, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.TIMELINE_MARKER_PROPERTIES",
                "FMOD.Studio.TIMELINE_MARKER_PROPERTIES", "TIMELINE_MARKER_PROPERTIES", assemblyIdentity, "Celeste",
                33554617, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.TIMELINE_MARKER_PROPERTIES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.TIMELINE_MARKER_PROPERTIES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
                "FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
                "TIMELINE_BEAT_PROPERTIES", assemblyIdentity, "Celeste", 33554618, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.TIMELINE_BEAT_PROPERTIES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.ADVANCEDSETTINGS", "FMOD.Studio.ADVANCEDSETTINGS",
                "ADVANCEDSETTINGS", assemblyIdentity, "Celeste", 33554619, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.ADVANCEDSETTINGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.ADVANCEDSETTINGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.CPU_USAGE", "FMOD.Studio.CPU_USAGE", "CPU_USAGE",
                assemblyIdentity, "Celeste", 33554620, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.CPU_USAGE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.CPU_USAGE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.BUFFER_INFO", "FMOD.Studio.BUFFER_INFO", "BUFFER_INFO",
                assemblyIdentity, "Celeste", 33554621, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.BUFFER_INFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BUFFER_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.BUFFER_USAGE", "FMOD.Studio.BUFFER_USAGE", "BUFFER_USAGE",
                assemblyIdentity, "Celeste", 33554622, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.BUFFER_USAGE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BUFFER_USAGE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.BANK_INFO", "FMOD.Studio.BANK_INFO", "BANK_INFO",
                assemblyIdentity, "Celeste", 33554623, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.BANK_INFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BANK_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.SYSTEM_CALLBACK_TYPE", "FMOD.Studio.SYSTEM_CALLBACK_TYPE",
                "SYSTEM_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554624, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.SYSTEM_CALLBACK_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SYSTEM_CALLBACK_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.SYSTEM_CALLBACK", "FMOD.Studio.SYSTEM_CALLBACK",
                "SYSTEM_CALLBACK", assemblyIdentity, "Celeste", 33554625, false,
                ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.SYSTEM_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SYSTEM_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_TYPE", "FMOD.Studio.PARAMETER_TYPE",
                "PARAMETER_TYPE",
                assemblyIdentity, "Celeste", 33554626, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_DESCRIPTION", "FMOD.Studio.PARAMETER_DESCRIPTION",
                "PARAMETER_DESCRIPTION", assemblyIdentity, "Celeste", 33554627, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_DESCRIPTION", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_DESCRIPTION",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL",
                "FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL", "PARAMETER_DESCRIPTION_INTERNAL", assemblyIdentity,
                "Celeste",
                33554628, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_MEMORY_MODE", "FMOD.Studio.LOAD_MEMORY_MODE",
                "LOAD_MEMORY_MODE", assemblyIdentity, "Celeste", 33554629, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_MEMORY_MODE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_MEMORY_MODE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_MEMORY_ALIGNMENT", "FMOD.Studio.LOAD_MEMORY_ALIGNMENT",
                "LOAD_MEMORY_ALIGNMENT", assemblyIdentity, "Celeste", 33554630, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_MEMORY_ALIGNMENT", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_MEMORY_ALIGNMENT",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.SOUND_INFO", "FMOD.Studio.SOUND_INFO", "SOUND_INFO",
                assemblyIdentity, "Celeste", 33554631, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.SOUND_INFO", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SOUND_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.SOUND_INFO_INTERNAL", "FMOD.Studio.SOUND_INFO_INTERNAL",
                "SOUND_INFO_INTERNAL", assemblyIdentity, "Celeste", 33554632, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.SOUND_INFO_INTERNAL", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SOUND_INFO_INTERNAL",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY_TYPE", "FMOD.Studio.USER_PROPERTY_TYPE",
                "USER_PROPERTY_TYPE", assemblyIdentity, "Celeste", 33554633, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY_TYPE",
                []);
        }
    }
}
