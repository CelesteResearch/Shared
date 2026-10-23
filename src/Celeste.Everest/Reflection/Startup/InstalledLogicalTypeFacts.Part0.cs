using System;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup;

public static partial class InstalledLogicalTypeFacts
{
    private static void RegisterPart0(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("SimplexNoise.Noise", "SimplexNoise.Noise", "Noise", assemblyIdentity,
            "Celeste", 33554434, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("SimplexNoise.Noise", 0, true);
        catalog.PublishDeclaredTrackedAliases("SimplexNoise.Noise",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.VERSION", "FMOD.VERSION", "VERSION", assemblyIdentity, "Celeste",
            33554435, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.VERSION", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.VERSION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CONSTANTS", "FMOD.CONSTANTS", "CONSTANTS", assemblyIdentity, "Celeste",
            33554436, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CONSTANTS", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.CONSTANTS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.RESULT", "FMOD.RESULT", "RESULT", assemblyIdentity, "Celeste", 33554437,
            false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.RESULT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.RESULT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_TYPE", "FMOD.CHANNELCONTROL_TYPE", "CHANNELCONTROL_TYPE",
            assemblyIdentity, "Celeste", 33554438, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.VECTOR", "FMOD.VECTOR", "VECTOR", assemblyIdentity, "Celeste", 33554439,
            false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.VECTOR", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.VECTOR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD._3D_ATTRIBUTES", "FMOD._3D_ATTRIBUTES", "_3D_ATTRIBUTES",
            assemblyIdentity, "Celeste", 33554440, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD._3D_ATTRIBUTES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD._3D_ATTRIBUTES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ASYNCREADINFO", "FMOD.ASYNCREADINFO", "ASYNCREADINFO", assemblyIdentity,
            "Celeste", 33554441, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ASYNCREADINFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ASYNCREADINFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.OUTPUTTYPE", "FMOD.OUTPUTTYPE", "OUTPUTTYPE", assemblyIdentity,
            "Celeste", 33554442, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.OUTPUTTYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.OUTPUTTYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_MODE", "FMOD.DEBUG_MODE", "DEBUG_MODE", assemblyIdentity,
            "Celeste", 33554443, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_MODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_MODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_FLAGS", "FMOD.DEBUG_FLAGS", "DEBUG_FLAGS", assemblyIdentity,
            "Celeste", 33554444, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_FLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_FLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_TYPE", "FMOD.MEMORY_TYPE", "MEMORY_TYPE", assemblyIdentity,
            "Celeste", 33554445, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SPEAKERMODE", "FMOD.SPEAKERMODE", "SPEAKERMODE", assemblyIdentity,
            "Celeste", 33554446, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SPEAKERMODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SPEAKERMODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SPEAKER", "FMOD.SPEAKER", "SPEAKER", assemblyIdentity, "Celeste",
            33554447, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SPEAKER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SPEAKER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNELMASK", "FMOD.CHANNELMASK", "CHANNELMASK", assemblyIdentity,
            "Celeste", 33554448, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNELMASK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELMASK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNELORDER", "FMOD.CHANNELORDER", "CHANNELORDER", assemblyIdentity,
            "Celeste", 33554449, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNELORDER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELORDER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.PLUGINTYPE", "FMOD.PLUGINTYPE", "PLUGINTYPE", assemblyIdentity,
            "Celeste", 33554450, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.PLUGINTYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.PLUGINTYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.PLUGINLIST", "FMOD.PLUGINLIST", "PLUGINLIST", assemblyIdentity,
            "Celeste", 33554451, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.PLUGINLIST", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.PLUGINLIST",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.INITFLAGS", "FMOD.INITFLAGS", "INITFLAGS", assemblyIdentity, "Celeste",
            33554452, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.INITFLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.INITFLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUND_TYPE", "FMOD.SOUND_TYPE", "SOUND_TYPE", assemblyIdentity,
            "Celeste", 33554453, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUND_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUND_FORMAT", "FMOD.SOUND_FORMAT", "SOUND_FORMAT", assemblyIdentity,
            "Celeste", 33554454, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUND_FORMAT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_FORMAT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.MODE", "FMOD.MODE", "MODE", assemblyIdentity, "Celeste", 33554455, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.MODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.MODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.OPENSTATE", "FMOD.OPENSTATE", "OPENSTATE", assemblyIdentity, "Celeste",
            33554456, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.OPENSTATE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.OPENSTATE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUNDGROUP_BEHAVIOR", "FMOD.SOUNDGROUP_BEHAVIOR", "SOUNDGROUP_BEHAVIOR",
            assemblyIdentity, "Celeste", 33554457, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUNDGROUP_BEHAVIOR", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUNDGROUP_BEHAVIOR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_CALLBACK_TYPE", "FMOD.CHANNELCONTROL_CALLBACK_TYPE",
            "CHANNELCONTROL_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554458, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_CALLBACK_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_CALLBACK_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNELCONTROL_DSP_INDEX", "FMOD.CHANNELCONTROL_DSP_INDEX",
            "CHANNELCONTROL_DSP_INDEX", assemblyIdentity, "Celeste", 33554459, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNELCONTROL_DSP_INDEX", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNELCONTROL_DSP_INDEX",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ERRORCALLBACK_INSTANCETYPE", "FMOD.ERRORCALLBACK_INSTANCETYPE",
            "ERRORCALLBACK_INSTANCETYPE", assemblyIdentity, "Celeste", 33554460, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ERRORCALLBACK_INSTANCETYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ERRORCALLBACK_INSTANCETYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ERRORCALLBACK_INFO", "FMOD.ERRORCALLBACK_INFO", "ERRORCALLBACK_INFO",
            assemblyIdentity, "Celeste", 33554461, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ERRORCALLBACK_INFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ERRORCALLBACK_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SYSTEM_CALLBACK_TYPE", "FMOD.SYSTEM_CALLBACK_TYPE",
            "SYSTEM_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554462, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SYSTEM_CALLBACK_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SYSTEM_CALLBACK_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.StringWrapper", "FMOD.StringWrapper", "StringWrapper", assemblyIdentity,
            "Celeste", 33554463, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.StringWrapper", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.StringWrapper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ASYNCREADINFO_DONE_CALLBACK", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
            "ASYNCREADINFO_DONE_CALLBACK", assemblyIdentity, "Celeste", 33554464, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ASYNCREADINFO_DONE_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ASYNCREADINFO_DONE_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DEBUG_CALLBACK", "FMOD.DEBUG_CALLBACK", "DEBUG_CALLBACK",
            assemblyIdentity, "Celeste", 33554465, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DEBUG_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DEBUG_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SYSTEM_CALLBACK", "FMOD.SYSTEM_CALLBACK", "SYSTEM_CALLBACK",
            assemblyIdentity, "Celeste", 33554466, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SYSTEM_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SYSTEM_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CHANNEL_CALLBACK", "FMOD.CHANNEL_CALLBACK", "CHANNEL_CALLBACK",
            assemblyIdentity, "Celeste", 33554467, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CHANNEL_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CHANNEL_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUND_NONBLOCKCALLBACK", "FMOD.SOUND_NONBLOCKCALLBACK",
            "SOUND_NONBLOCKCALLBACK", assemblyIdentity, "Celeste", 33554468, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUND_NONBLOCKCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_NONBLOCKCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUND_PCMREADCALLBACK", "FMOD.SOUND_PCMREADCALLBACK",
            "SOUND_PCMREADCALLBACK", assemblyIdentity, "Celeste", 33554469, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUND_PCMREADCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_PCMREADCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SOUND_PCMSETPOSCALLBACK", "FMOD.SOUND_PCMSETPOSCALLBACK",
            "SOUND_PCMSETPOSCALLBACK", assemblyIdentity, "Celeste", 33554470, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SOUND_PCMSETPOSCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SOUND_PCMSETPOSCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_OPENCALLBACK", "FMOD.FILE_OPENCALLBACK", "FILE_OPENCALLBACK",
            assemblyIdentity, "Celeste", 33554471, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_OPENCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_OPENCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_CLOSECALLBACK", "FMOD.FILE_CLOSECALLBACK", "FILE_CLOSECALLBACK",
            assemblyIdentity, "Celeste", 33554472, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_CLOSECALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_CLOSECALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_READCALLBACK", "FMOD.FILE_READCALLBACK", "FILE_READCALLBACK",
            assemblyIdentity, "Celeste", 33554473, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_READCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_READCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_SEEKCALLBACK", "FMOD.FILE_SEEKCALLBACK", "FILE_SEEKCALLBACK",
            assemblyIdentity, "Celeste", 33554474, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_SEEKCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_SEEKCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_ASYNCREADCALLBACK", "FMOD.FILE_ASYNCREADCALLBACK",
            "FILE_ASYNCREADCALLBACK", assemblyIdentity, "Celeste", 33554475, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_ASYNCREADCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_ASYNCREADCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.FILE_ASYNCCANCELCALLBACK", "FMOD.FILE_ASYNCCANCELCALLBACK",
            "FILE_ASYNCCANCELCALLBACK", assemblyIdentity, "Celeste", 33554476, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.FILE_ASYNCCANCELCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.FILE_ASYNCCANCELCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_ALLOC_CALLBACK", "FMOD.MEMORY_ALLOC_CALLBACK",
            "MEMORY_ALLOC_CALLBACK", assemblyIdentity, "Celeste", 33554477, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_ALLOC_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_ALLOC_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_REALLOC_CALLBACK", "FMOD.MEMORY_REALLOC_CALLBACK",
            "MEMORY_REALLOC_CALLBACK", assemblyIdentity, "Celeste", 33554478, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_REALLOC_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_REALLOC_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.MEMORY_FREE_CALLBACK", "FMOD.MEMORY_FREE_CALLBACK",
            "MEMORY_FREE_CALLBACK", assemblyIdentity, "Celeste", 33554479, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.MEMORY_FREE_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.MEMORY_FREE_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CB_3D_ROLLOFFCALLBACK", "FMOD.CB_3D_ROLLOFFCALLBACK",
            "CB_3D_ROLLOFFCALLBACK", assemblyIdentity, "Celeste", 33554480, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CB_3D_ROLLOFFCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CB_3D_ROLLOFFCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_RESAMPLER", "FMOD.DSP_RESAMPLER", "DSP_RESAMPLER", assemblyIdentity,
            "Celeste", 33554481, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_RESAMPLER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RESAMPLER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSPCONNECTION_TYPE", "FMOD.DSPCONNECTION_TYPE", "DSPCONNECTION_TYPE",
            assemblyIdentity, "Celeste", 33554482, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSPCONNECTION_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSPCONNECTION_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.TAGTYPE", "FMOD.TAGTYPE", "TAGTYPE", assemblyIdentity, "Celeste",
            33554483, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.TAGTYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.TAGTYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.TAGDATATYPE", "FMOD.TAGDATATYPE", "TAGDATATYPE", assemblyIdentity,
            "Celeste", 33554484, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.TAGDATATYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.TAGDATATYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.TAG", "FMOD.TAG", "TAG", assemblyIdentity, "Celeste", 33554485, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.TAG", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.TAG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.TIMEUNIT", "FMOD.TIMEUNIT", "TIMEUNIT", assemblyIdentity, "Celeste",
            33554486, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.TIMEUNIT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.TIMEUNIT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.PORT_INDEX", "FMOD.PORT_INDEX", "PORT_INDEX", assemblyIdentity,
            "Celeste", 33554487, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.PORT_INDEX", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.PORT_INDEX",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.CREATESOUNDEXINFO", "FMOD.CREATESOUNDEXINFO", "CREATESOUNDEXINFO",
            assemblyIdentity, "Celeste", 33554488, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.CREATESOUNDEXINFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.CREATESOUNDEXINFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.REVERB_PROPERTIES", "FMOD.REVERB_PROPERTIES", "REVERB_PROPERTIES",
            assemblyIdentity, "Celeste", 33554489, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.REVERB_PROPERTIES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.REVERB_PROPERTIES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.PRESET", "FMOD.PRESET", "PRESET", assemblyIdentity, "Celeste", 33554490,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.PRESET", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.PRESET",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ADVANCEDSETTINGS", "FMOD.ADVANCEDSETTINGS", "ADVANCEDSETTINGS",
            assemblyIdentity, "Celeste", 33554491, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ADVANCEDSETTINGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ADVANCEDSETTINGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DRIVER_STATE", "FMOD.DRIVER_STATE", "DRIVER_STATE", assemblyIdentity,
            "Celeste", 33554492, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DRIVER_STATE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DRIVER_STATE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Factory", "FMOD.Factory", "Factory", assemblyIdentity, "Celeste",
            33554493, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Factory", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Factory",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Memory", "FMOD.Memory", "Memory", assemblyIdentity, "Celeste", 33554494,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Memory", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Memory",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Debug", "FMOD.Debug", "Debug", assemblyIdentity, "Celeste", 33554495,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Debug", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Debug",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.HandleBase", "FMOD.HandleBase", "HandleBase", assemblyIdentity,
            "Celeste", 33554496, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.HandleBase", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.HandleBase",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.System", "FMOD.System", "System", assemblyIdentity, "Celeste", 33554497,
            false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.System", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.System",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Sound", "FMOD.Sound", "Sound", assemblyIdentity, "Celeste", 33554498,
            false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Sound", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Sound",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ChannelControl", "FMOD.ChannelControl", "ChannelControl",
            assemblyIdentity, "Celeste", 33554499, false, new string[] { "FMOD.HandleBase", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ChannelControl", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ChannelControl",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Channel", "FMOD.Channel", "Channel", assemblyIdentity, "Celeste",
            33554500, false, new string[] { "FMOD.ChannelControl", "FMOD.HandleBase", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Channel", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Channel",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.ChannelGroup", "FMOD.ChannelGroup", "ChannelGroup", assemblyIdentity,
            "Celeste", 33554501, false, new string[] { "FMOD.ChannelControl", "FMOD.HandleBase", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.ChannelGroup", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.ChannelGroup",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.SoundGroup", "FMOD.SoundGroup", "SoundGroup", assemblyIdentity,
            "Celeste", 33554502, false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.SoundGroup", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.SoundGroup",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP", "FMOD.DSP", "DSP", assemblyIdentity, "Celeste", 33554503, false,
            new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSPConnection", "FMOD.DSPConnection", "DSPConnection", assemblyIdentity,
            "Celeste", 33554504, false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSPConnection", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSPConnection",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Geometry", "FMOD.Geometry", "Geometry", assemblyIdentity, "Celeste",
            33554505, false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Geometry", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Geometry",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Reverb3D", "FMOD.Reverb3D", "Reverb3D", assemblyIdentity, "Celeste",
            33554506, false, new string[] { "FMOD.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Reverb3D", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Reverb3D",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.StringMarshalHelper", "FMOD.StringMarshalHelper", "StringMarshalHelper",
            assemblyIdentity, "Celeste", 33554507, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.StringMarshalHelper", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.StringMarshalHelper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_BUFFER_ARRAY", "FMOD.DSP_BUFFER_ARRAY", "DSP_BUFFER_ARRAY",
            assemblyIdentity, "Celeste", 33554508, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_BUFFER_ARRAY", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_BUFFER_ARRAY",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PROCESS_OPERATION", "FMOD.DSP_PROCESS_OPERATION",
            "DSP_PROCESS_OPERATION", assemblyIdentity, "Celeste", 33554509, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PROCESS_OPERATION", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PROCESS_OPERATION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.COMPLEX", "FMOD.COMPLEX", "COMPLEX", assemblyIdentity, "Celeste",
            33554510, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.COMPLEX", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.COMPLEX",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SURROUND_FLAGS", "FMOD.DSP_PAN_SURROUND_FLAGS",
            "DSP_PAN_SURROUND_FLAGS", assemblyIdentity, "Celeste", 33554511, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SURROUND_FLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SURROUND_FLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_CREATECALLBACK", "FMOD.DSP_CREATECALLBACK", "DSP_CREATECALLBACK",
            assemblyIdentity, "Celeste", 33554512, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_CREATECALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CREATECALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_RELEASECALLBACK", "FMOD.DSP_RELEASECALLBACK", "DSP_RELEASECALLBACK",
            assemblyIdentity, "Celeste", 33554513, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_RELEASECALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RELEASECALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_RESETCALLBACK", "FMOD.DSP_RESETCALLBACK", "DSP_RESETCALLBACK",
            assemblyIdentity, "Celeste", 33554514, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_RESETCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RESETCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPOSITIONCALLBACK", "FMOD.DSP_SETPOSITIONCALLBACK",
            "DSP_SETPOSITIONCALLBACK", assemblyIdentity, "Celeste", 33554515, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPOSITIONCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPOSITIONCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_READCALLBACK", "FMOD.DSP_READCALLBACK", "DSP_READCALLBACK",
            assemblyIdentity, "Celeste", 33554516, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_READCALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_READCALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SHOULDIPROCESS_CALLBACK", "FMOD.DSP_SHOULDIPROCESS_CALLBACK",
            "DSP_SHOULDIPROCESS_CALLBACK", assemblyIdentity, "Celeste", 33554517, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SHOULDIPROCESS_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SHOULDIPROCESS_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PROCESS_CALLBACK", "FMOD.DSP_PROCESS_CALLBACK",
            "DSP_PROCESS_CALLBACK", assemblyIdentity, "Celeste", 33554518, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PROCESS_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PROCESS_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_FLOAT_CALLBACK", "FMOD.DSP_SETPARAM_FLOAT_CALLBACK",
            "DSP_SETPARAM_FLOAT_CALLBACK", assemblyIdentity, "Celeste", 33554519, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_FLOAT_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_FLOAT_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_INT_CALLBACK", "FMOD.DSP_SETPARAM_INT_CALLBACK",
            "DSP_SETPARAM_INT_CALLBACK", assemblyIdentity, "Celeste", 33554520, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_INT_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_INT_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_BOOL_CALLBACK", "FMOD.DSP_SETPARAM_BOOL_CALLBACK",
            "DSP_SETPARAM_BOOL_CALLBACK", assemblyIdentity, "Celeste", 33554521, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_BOOL_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_BOOL_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SETPARAM_DATA_CALLBACK", "FMOD.DSP_SETPARAM_DATA_CALLBACK",
            "DSP_SETPARAM_DATA_CALLBACK", assemblyIdentity, "Celeste", 33554522, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SETPARAM_DATA_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SETPARAM_DATA_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_FLOAT_CALLBACK", "FMOD.DSP_GETPARAM_FLOAT_CALLBACK",
            "DSP_GETPARAM_FLOAT_CALLBACK", assemblyIdentity, "Celeste", 33554523, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_FLOAT_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_FLOAT_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_INT_CALLBACK", "FMOD.DSP_GETPARAM_INT_CALLBACK",
            "DSP_GETPARAM_INT_CALLBACK", assemblyIdentity, "Celeste", 33554524, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_INT_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_INT_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_BOOL_CALLBACK", "FMOD.DSP_GETPARAM_BOOL_CALLBACK",
            "DSP_GETPARAM_BOOL_CALLBACK", assemblyIdentity, "Celeste", 33554525, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_BOOL_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_BOOL_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETPARAM_DATA_CALLBACK", "FMOD.DSP_GETPARAM_DATA_CALLBACK",
            "DSP_GETPARAM_DATA_CALLBACK", assemblyIdentity, "Celeste", 33554526, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETPARAM_DATA_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETPARAM_DATA_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_REGISTER_CALLBACK", "FMOD.DSP_SYSTEM_REGISTER_CALLBACK",
            "DSP_SYSTEM_REGISTER_CALLBACK", assemblyIdentity, "Celeste", 33554527, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_REGISTER_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_REGISTER_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK", "FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
            "DSP_SYSTEM_DEREGISTER_CALLBACK", assemblyIdentity, "Celeste", 33554528, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_DEREGISTER_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SYSTEM_MIX_CALLBACK", "FMOD.DSP_SYSTEM_MIX_CALLBACK",
            "DSP_SYSTEM_MIX_CALLBACK", assemblyIdentity, "Celeste", 33554529, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SYSTEM_MIX_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SYSTEM_MIX_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_ALLOC_FUNC", "FMOD.DSP_ALLOC_FUNC", "DSP_ALLOC_FUNC",
            assemblyIdentity, "Celeste", 33554530, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_ALLOC_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ALLOC_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_REALLOC_FUNC", "FMOD.DSP_REALLOC_FUNC", "DSP_REALLOC_FUNC",
            assemblyIdentity, "Celeste", 33554531, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_REALLOC_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_REALLOC_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_FREE_FUNC", "FMOD.DSP_FREE_FUNC", "DSP_FREE_FUNC", assemblyIdentity,
            "Celeste", 33554532, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_FREE_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FREE_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOG_FUNC", "FMOD.DSP_LOG_FUNC", "DSP_LOG_FUNC", assemblyIdentity,
            "Celeste", 33554533, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOG_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOG_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETSAMPLERATE_FUNC", "FMOD.DSP_GETSAMPLERATE_FUNC",
            "DSP_GETSAMPLERATE_FUNC", assemblyIdentity, "Celeste", 33554534, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETSAMPLERATE_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETSAMPLERATE_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETBLOCKSIZE_FUNC", "FMOD.DSP_GETBLOCKSIZE_FUNC",
            "DSP_GETBLOCKSIZE_FUNC", assemblyIdentity, "Celeste", 33554535, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETBLOCKSIZE_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETBLOCKSIZE_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETSPEAKERMODE_FUNC", "FMOD.DSP_GETSPEAKERMODE_FUNC",
            "DSP_GETSPEAKERMODE_FUNC", assemblyIdentity, "Celeste", 33554536, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETSPEAKERMODE_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETSPEAKERMODE_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETCLOCK_FUNC", "FMOD.DSP_GETCLOCK_FUNC", "DSP_GETCLOCK_FUNC",
            assemblyIdentity, "Celeste", 33554537, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETCLOCK_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETCLOCK_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC", "FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
            "DSP_GETLISTENERATTRIBUTES_FUNC", assemblyIdentity, "Celeste", 33554538, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETLISTENERATTRIBUTES_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_GETUSERDATA_FUNC", "FMOD.DSP_GETUSERDATA_FUNC",
            "DSP_GETUSERDATA_FUNC", assemblyIdentity, "Celeste", 33554539, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_GETUSERDATA_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_GETUSERDATA_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_DFT_FFTREAL_FUNC", "FMOD.DSP_DFT_FFTREAL_FUNC",
            "DSP_DFT_FFTREAL_FUNC", assemblyIdentity, "Celeste", 33554540, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_DFT_FFTREAL_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DFT_FFTREAL_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_DFT_IFFTREAL_FUNC", "FMOD.DSP_DFT_IFFTREAL_FUNC",
            "DSP_DFT_IFFTREAL_FUNC", assemblyIdentity, "Celeste", 33554541, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_DFT_IFFTREAL_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DFT_IFFTREAL_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC", "FMOD.DSP_PAN_SUMMONOMATRIX_FUNC",
            "DSP_PAN_SUMMONOMATRIX_FUNC", assemblyIdentity, "Celeste", 33554542, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMMONOMATRIX_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC", "FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC",
            "DSP_PAN_SUMSTEREOMATRIX_FUNC", assemblyIdentity, "Celeste", 33554543, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSTEREOMATRIX_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC", "FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
            "DSP_PAN_SUMSURROUNDMATRIX_FUNC", assemblyIdentity, "Celeste", 33554544, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSURROUNDMATRIX_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC",
            "FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", "DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", assemblyIdentity,
            "Celeste", 33554545, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMMONOTOSURROUNDMATRIX_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
            "FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC", "DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC", assemblyIdentity,
            "Celeste", 33554546, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC", "FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC",
            "DSP_PAN_GETROLLOFFGAIN_FUNC", assemblyIdentity, "Celeste", 33554547, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_GETROLLOFFGAIN_FUNC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_TYPE", "FMOD.DSP_TYPE", "DSP_TYPE", assemblyIdentity, "Celeste",
            33554548, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_TYPE", "FMOD.DSP_PARAMETER_TYPE", "DSP_PARAMETER_TYPE",
            assemblyIdentity, "Celeste", 33554549, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE",
            "FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE", "DSP_PARAMETER_FLOAT_MAPPING_TYPE", assemblyIdentity, "Celeste",
            33554550, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
            "FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR", "DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
            assemblyIdentity, "Celeste", 33554551, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING_PIECEWISE_LINEAR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING", "FMOD.DSP_PARAMETER_FLOAT_MAPPING",
            "DSP_PARAMETER_FLOAT_MAPPING", assemblyIdentity, "Celeste", 33554552, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FLOAT_MAPPING", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FLOAT_MAPPING",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_FLOAT", "FMOD.DSP_PARAMETER_DESC_FLOAT",
            "DSP_PARAMETER_DESC_FLOAT", assemblyIdentity, "Celeste", 33554553, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_FLOAT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_FLOAT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_INT", "FMOD.DSP_PARAMETER_DESC_INT",
            "DSP_PARAMETER_DESC_INT", assemblyIdentity, "Celeste", 33554554, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_INT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_INT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_BOOL", "FMOD.DSP_PARAMETER_DESC_BOOL",
            "DSP_PARAMETER_DESC_BOOL", assemblyIdentity, "Celeste", 33554555, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_BOOL", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_BOOL",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_DATA", "FMOD.DSP_PARAMETER_DESC_DATA",
            "DSP_PARAMETER_DESC_DATA", assemblyIdentity, "Celeste", 33554556, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_DATA", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_DATA",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC_UNION", "FMOD.DSP_PARAMETER_DESC_UNION",
            "DSP_PARAMETER_DESC_UNION", assemblyIdentity, "Celeste", 33554557, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC_UNION", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC_UNION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DESC", "FMOD.DSP_PARAMETER_DESC", "DSP_PARAMETER_DESC",
            assemblyIdentity, "Celeste", 33554558, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DESC", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DESC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_DATA_TYPE", "FMOD.DSP_PARAMETER_DATA_TYPE",
            "DSP_PARAMETER_DATA_TYPE", assemblyIdentity, "Celeste", 33554559, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_DATA_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_DATA_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_OVERALLGAIN", "FMOD.DSP_PARAMETER_OVERALLGAIN",
            "DSP_PARAMETER_OVERALLGAIN", assemblyIdentity, "Celeste", 33554560, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_OVERALLGAIN", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_OVERALLGAIN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES", "FMOD.DSP_PARAMETER_3DATTRIBUTES",
            "DSP_PARAMETER_3DATTRIBUTES", assemblyIdentity, "Celeste", 33554561, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_3DATTRIBUTES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI",
            "FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI", "DSP_PARAMETER_3DATTRIBUTES_MULTI", assemblyIdentity, "Celeste",
            33554562, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_SIDECHAIN", "FMOD.DSP_PARAMETER_SIDECHAIN",
            "DSP_PARAMETER_SIDECHAIN", assemblyIdentity, "Celeste", 33554563, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_SIDECHAIN", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_SIDECHAIN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMETER_FFT", "FMOD.DSP_PARAMETER_FFT", "DSP_PARAMETER_FFT",
            assemblyIdentity, "Celeste", 33554564, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMETER_FFT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMETER_FFT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_DESCRIPTION", "FMOD.DSP_DESCRIPTION", "DSP_DESCRIPTION",
            assemblyIdentity, "Celeste", 33554565, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_DESCRIPTION", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DESCRIPTION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_DFT_FUNCTIONS", "FMOD.DSP_STATE_DFT_FUNCTIONS",
            "DSP_STATE_DFT_FUNCTIONS", assemblyIdentity, "Celeste", 33554566, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_DFT_FUNCTIONS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_DFT_FUNCTIONS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_PAN_FUNCTIONS", "FMOD.DSP_STATE_PAN_FUNCTIONS",
            "DSP_STATE_PAN_FUNCTIONS", assemblyIdentity, "Celeste", 33554567, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_PAN_FUNCTIONS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_PAN_FUNCTIONS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE_FUNCTIONS", "FMOD.DSP_STATE_FUNCTIONS", "DSP_STATE_FUNCTIONS",
            assemblyIdentity, "Celeste", 33554568, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE_FUNCTIONS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE_FUNCTIONS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_STATE", "FMOD.DSP_STATE", "DSP_STATE", assemblyIdentity, "Celeste",
            33554569, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_STATE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_STATE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_METERING_INFO", "FMOD.DSP_METERING_INFO", "DSP_METERING_INFO",
            assemblyIdentity, "Celeste", 33554570, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_METERING_INFO", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_METERING_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_OSCILLATOR", "FMOD.DSP_OSCILLATOR", "DSP_OSCILLATOR",
            assemblyIdentity, "Celeste", 33554571, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_OSCILLATOR", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_OSCILLATOR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOWPASS", "FMOD.DSP_LOWPASS", "DSP_LOWPASS", assemblyIdentity,
            "Celeste", 33554572, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOWPASS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOWPASS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_ITLOWPASS", "FMOD.DSP_ITLOWPASS", "DSP_ITLOWPASS", assemblyIdentity,
            "Celeste", 33554573, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_ITLOWPASS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ITLOWPASS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_HIGHPASS", "FMOD.DSP_HIGHPASS", "DSP_HIGHPASS", assemblyIdentity,
            "Celeste", 33554574, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_HIGHPASS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_HIGHPASS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_ECHO", "FMOD.DSP_ECHO", "DSP_ECHO", assemblyIdentity, "Celeste",
            33554575, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_ECHO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ECHO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_FADER", "FMOD.DSP_FADER", "DSP_FADER", assemblyIdentity, "Celeste",
            33554576, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_FADER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FADER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_DELAY", "FMOD.DSP_DELAY", "DSP_DELAY", assemblyIdentity, "Celeste",
            33554577, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_DELAY", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DELAY",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_FLANGE", "FMOD.DSP_FLANGE", "DSP_FLANGE", assemblyIdentity,
            "Celeste", 33554578, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_FLANGE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FLANGE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_TREMOLO", "FMOD.DSP_TREMOLO", "DSP_TREMOLO", assemblyIdentity,
            "Celeste", 33554579, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_TREMOLO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TREMOLO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_DISTORTION", "FMOD.DSP_DISTORTION", "DSP_DISTORTION",
            assemblyIdentity, "Celeste", 33554580, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_DISTORTION", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_DISTORTION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_NORMALIZE", "FMOD.DSP_NORMALIZE", "DSP_NORMALIZE", assemblyIdentity,
            "Celeste", 33554581, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_NORMALIZE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_NORMALIZE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_LIMITER", "FMOD.DSP_LIMITER", "DSP_LIMITER", assemblyIdentity,
            "Celeste", 33554582, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_LIMITER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LIMITER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PARAMEQ", "FMOD.DSP_PARAMEQ", "DSP_PARAMEQ", assemblyIdentity,
            "Celeste", 33554583, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PARAMEQ", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PARAMEQ",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_MULTIBAND_EQ", "FMOD.DSP_MULTIBAND_EQ", "DSP_MULTIBAND_EQ",
            assemblyIdentity, "Celeste", 33554584, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_MULTIBAND_EQ", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_MULTIBAND_EQ",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE", "FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE",
            "DSP_MULTIBAND_EQ_FILTER_TYPE", assemblyIdentity, "Celeste", 33554585, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_MULTIBAND_EQ_FILTER_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PITCHSHIFT", "FMOD.DSP_PITCHSHIFT", "DSP_PITCHSHIFT",
            assemblyIdentity, "Celeste", 33554586, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PITCHSHIFT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PITCHSHIFT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHORUS", "FMOD.DSP_CHORUS", "DSP_CHORUS", assemblyIdentity,
            "Celeste", 33554587, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHORUS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHORUS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_ITECHO", "FMOD.DSP_ITECHO", "DSP_ITECHO", assemblyIdentity,
            "Celeste", 33554588, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_ITECHO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ITECHO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_COMPRESSOR", "FMOD.DSP_COMPRESSOR", "DSP_COMPRESSOR",
            assemblyIdentity, "Celeste", 33554589, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_COMPRESSOR", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_COMPRESSOR",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SFXREVERB", "FMOD.DSP_SFXREVERB", "DSP_SFXREVERB", assemblyIdentity,
            "Celeste", 33554590, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SFXREVERB", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SFXREVERB",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_LOWPASS_SIMPLE", "FMOD.DSP_LOWPASS_SIMPLE", "DSP_LOWPASS_SIMPLE",
            assemblyIdentity, "Celeste", 33554591, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_LOWPASS_SIMPLE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_LOWPASS_SIMPLE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_SEND", "FMOD.DSP_SEND", "DSP_SEND", assemblyIdentity, "Celeste",
            33554592, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_SEND", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_SEND",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_RETURN", "FMOD.DSP_RETURN", "DSP_RETURN", assemblyIdentity,
            "Celeste", 33554593, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_RETURN", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_RETURN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_HIGHPASS_SIMPLE", "FMOD.DSP_HIGHPASS_SIMPLE", "DSP_HIGHPASS_SIMPLE",
            assemblyIdentity, "Celeste", 33554594, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_HIGHPASS_SIMPLE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_HIGHPASS_SIMPLE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
            "DSP_PAN_2D_STEREO_MODE_TYPE", assemblyIdentity, "Celeste", 33554595, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_MODE_TYPE", "FMOD.DSP_PAN_MODE_TYPE", "DSP_PAN_MODE_TYPE",
            assemblyIdentity, "Celeste", 33554596, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_MODE_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_MODE_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_3D_ROLLOFF_TYPE", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
            "DSP_PAN_3D_ROLLOFF_TYPE", assemblyIdentity, "Celeste", 33554597, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_3D_ROLLOFF_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
            "DSP_PAN_3D_EXTENT_MODE_TYPE", assemblyIdentity, "Celeste", 33554598, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_PAN", "FMOD.DSP_PAN", "DSP_PAN", assemblyIdentity, "Celeste",
            33554599, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_PAN", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_PAN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
            "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", "DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", assemblyIdentity, "Celeste",
            33554600, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_THREE_EQ", "FMOD.DSP_THREE_EQ", "DSP_THREE_EQ", assemblyIdentity,
            "Celeste", 33554601, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_THREE_EQ", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_THREE_EQ",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_FFT_WINDOW", "FMOD.DSP_FFT_WINDOW", "DSP_FFT_WINDOW",
            assemblyIdentity, "Celeste", 33554602, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_FFT_WINDOW", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FFT_WINDOW",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_FFT", "FMOD.DSP_FFT", "DSP_FFT", assemblyIdentity, "Celeste",
            33554603, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_FFT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_FFT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_ENVELOPEFOLLOWER", "FMOD.DSP_ENVELOPEFOLLOWER",
            "DSP_ENVELOPEFOLLOWER", assemblyIdentity, "Celeste", 33554604, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_ENVELOPEFOLLOWER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_ENVELOPEFOLLOWER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_CONVOLUTION_REVERB", "FMOD.DSP_CONVOLUTION_REVERB",
            "DSP_CONVOLUTION_REVERB", assemblyIdentity, "Celeste", 33554605, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_CONVOLUTION_REVERB", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CONVOLUTION_REVERB",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHANNELMIX_OUTPUT", "FMOD.DSP_CHANNELMIX_OUTPUT",
            "DSP_CHANNELMIX_OUTPUT", assemblyIdentity, "Celeste", 33554606, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHANNELMIX_OUTPUT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHANNELMIX_OUTPUT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_CHANNELMIX", "FMOD.DSP_CHANNELMIX", "DSP_CHANNELMIX",
            assemblyIdentity, "Celeste", 33554607, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_CHANNELMIX", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_CHANNELMIX",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_TRANSCEIVER_SPEAKERMODE", "FMOD.DSP_TRANSCEIVER_SPEAKERMODE",
            "DSP_TRANSCEIVER_SPEAKERMODE", assemblyIdentity, "Celeste", 33554608, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_TRANSCEIVER_SPEAKERMODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TRANSCEIVER_SPEAKERMODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_TRANSCEIVER", "FMOD.DSP_TRANSCEIVER", "DSP_TRANSCEIVER",
            assemblyIdentity, "Celeste", 33554609, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_TRANSCEIVER", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_TRANSCEIVER",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.DSP_OBJECTPAN", "FMOD.DSP_OBJECTPAN", "DSP_OBJECTPAN", assemblyIdentity,
            "Celeste", 33554610, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.DSP_OBJECTPAN", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.DSP_OBJECTPAN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Error", "FMOD.Error", "Error", assemblyIdentity, "Celeste", 33554611,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Error", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Error",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.STUDIO_VERSION", "FMOD.Studio.STUDIO_VERSION", "STUDIO_VERSION",
            assemblyIdentity, "Celeste", 33554612, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.STUDIO_VERSION", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.STUDIO_VERSION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.STOP_MODE", "FMOD.Studio.STOP_MODE", "STOP_MODE",
            assemblyIdentity, "Celeste", 33554613, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.STOP_MODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.STOP_MODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOADING_STATE", "FMOD.Studio.LOADING_STATE", "LOADING_STATE",
            assemblyIdentity, "Celeste", 33554614, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOADING_STATE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOADING_STATE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio._3D_ATTRIBUTES", "FMOD.Studio._3D_ATTRIBUTES", "_3D_ATTRIBUTES",
            assemblyIdentity, "Celeste", 33554615, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio._3D_ATTRIBUTES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio._3D_ATTRIBUTES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES",
            "FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES", "PROGRAMMER_SOUND_PROPERTIES", assemblyIdentity, "Celeste",
            33554616, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.TIMELINE_MARKER_PROPERTIES",
            "FMOD.Studio.TIMELINE_MARKER_PROPERTIES", "TIMELINE_MARKER_PROPERTIES", assemblyIdentity, "Celeste",
            33554617, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.TIMELINE_MARKER_PROPERTIES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.TIMELINE_MARKER_PROPERTIES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.TIMELINE_BEAT_PROPERTIES", "FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
            "TIMELINE_BEAT_PROPERTIES", assemblyIdentity, "Celeste", 33554618, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.TIMELINE_BEAT_PROPERTIES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.TIMELINE_BEAT_PROPERTIES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.ADVANCEDSETTINGS", "FMOD.Studio.ADVANCEDSETTINGS",
            "ADVANCEDSETTINGS", assemblyIdentity, "Celeste", 33554619, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.ADVANCEDSETTINGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.ADVANCEDSETTINGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.CPU_USAGE", "FMOD.Studio.CPU_USAGE", "CPU_USAGE",
            assemblyIdentity, "Celeste", 33554620, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.CPU_USAGE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.CPU_USAGE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.BUFFER_INFO", "FMOD.Studio.BUFFER_INFO", "BUFFER_INFO",
            assemblyIdentity, "Celeste", 33554621, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.BUFFER_INFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BUFFER_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.BUFFER_USAGE", "FMOD.Studio.BUFFER_USAGE", "BUFFER_USAGE",
            assemblyIdentity, "Celeste", 33554622, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.BUFFER_USAGE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BUFFER_USAGE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.BANK_INFO", "FMOD.Studio.BANK_INFO", "BANK_INFO",
            assemblyIdentity, "Celeste", 33554623, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.BANK_INFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.BANK_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.SYSTEM_CALLBACK_TYPE", "FMOD.Studio.SYSTEM_CALLBACK_TYPE",
            "SYSTEM_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554624, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.SYSTEM_CALLBACK_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SYSTEM_CALLBACK_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.SYSTEM_CALLBACK", "FMOD.Studio.SYSTEM_CALLBACK",
            "SYSTEM_CALLBACK", assemblyIdentity, "Celeste", 33554625, false,
            new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.SYSTEM_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SYSTEM_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_TYPE", "FMOD.Studio.PARAMETER_TYPE", "PARAMETER_TYPE",
            assemblyIdentity, "Celeste", 33554626, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_DESCRIPTION", "FMOD.Studio.PARAMETER_DESCRIPTION",
            "PARAMETER_DESCRIPTION", assemblyIdentity, "Celeste", 33554627, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_DESCRIPTION", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_DESCRIPTION",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL",
            "FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL", "PARAMETER_DESCRIPTION_INTERNAL", assemblyIdentity, "Celeste",
            33554628, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PARAMETER_DESCRIPTION_INTERNAL",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_MEMORY_MODE", "FMOD.Studio.LOAD_MEMORY_MODE",
            "LOAD_MEMORY_MODE", assemblyIdentity, "Celeste", 33554629, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_MEMORY_MODE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_MEMORY_MODE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_MEMORY_ALIGNMENT", "FMOD.Studio.LOAD_MEMORY_ALIGNMENT",
            "LOAD_MEMORY_ALIGNMENT", assemblyIdentity, "Celeste", 33554630, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_MEMORY_ALIGNMENT", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_MEMORY_ALIGNMENT",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.SOUND_INFO", "FMOD.Studio.SOUND_INFO", "SOUND_INFO",
            assemblyIdentity, "Celeste", 33554631, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.SOUND_INFO", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SOUND_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.SOUND_INFO_INTERNAL", "FMOD.Studio.SOUND_INFO_INTERNAL",
            "SOUND_INFO_INTERNAL", assemblyIdentity, "Celeste", 33554632, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.SOUND_INFO_INTERNAL", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.SOUND_INFO_INTERNAL",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY_TYPE", "FMOD.Studio.USER_PROPERTY_TYPE",
            "USER_PROPERTY_TYPE", assemblyIdentity, "Celeste", 33554633, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
