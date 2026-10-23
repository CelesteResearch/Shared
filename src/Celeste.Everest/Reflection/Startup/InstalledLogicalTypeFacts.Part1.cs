using System;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup;

public static partial class InstalledLogicalTypeFacts
{
    private static void RegisterPart1(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY", "FMOD.Studio.USER_PROPERTY", "USER_PROPERTY",
            assemblyIdentity, "Celeste", 33554634, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY_INTERNAL", "FMOD.Studio.USER_PROPERTY_INTERNAL",
            "USER_PROPERTY_INTERNAL", assemblyIdentity, "Celeste", 33554635, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY_INTERNAL", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY_INTERNAL",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMAND_INFO_INTERNAL", "FMOD.Studio.COMMAND_INFO_INTERNAL",
            "COMMAND_INFO_INTERNAL", assemblyIdentity, "Celeste", 33554636, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMAND_INFO_INTERNAL", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMAND_INFO_INTERNAL",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.Union_IntBoolFloatString", "FMOD.Studio.Union_IntBoolFloatString",
            "Union_IntBoolFloatString", assemblyIdentity, "Celeste", 33554637, false,
            new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.Union_IntBoolFloatString", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Union_IntBoolFloatString",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.INITFLAGS", "FMOD.Studio.INITFLAGS", "INITFLAGS",
            assemblyIdentity, "Celeste", 33554638, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.INITFLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.INITFLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_BANK_FLAGS", "FMOD.Studio.LOAD_BANK_FLAGS",
            "LOAD_BANK_FLAGS", assemblyIdentity, "Celeste", 33554639, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_BANK_FLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_BANK_FLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDCAPTURE_FLAGS", "FMOD.Studio.COMMANDCAPTURE_FLAGS",
            "COMMANDCAPTURE_FLAGS", assemblyIdentity, "Celeste", 33554640, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDCAPTURE_FLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDCAPTURE_FLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_FLAGS", "FMOD.Studio.COMMANDREPLAY_FLAGS",
            "COMMANDREPLAY_FLAGS", assemblyIdentity, "Celeste", 33554641, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_FLAGS", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_FLAGS",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PLAYBACK_STATE", "FMOD.Studio.PLAYBACK_STATE", "PLAYBACK_STATE",
            assemblyIdentity, "Celeste", 33554642, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PLAYBACK_STATE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PLAYBACK_STATE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_PROPERTY", "FMOD.Studio.EVENT_PROPERTY", "EVENT_PROPERTY",
            assemblyIdentity, "Celeste", 33554643, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_PROPERTY", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_PROPERTY",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES",
            "FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES", "PLUGIN_INSTANCE_PROPERTIES", assemblyIdentity, "Celeste",
            33554644, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_CALLBACK_TYPE", "FMOD.Studio.EVENT_CALLBACK_TYPE",
            "EVENT_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554645, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_CALLBACK_TYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_CALLBACK_TYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_CALLBACK", "FMOD.Studio.EVENT_CALLBACK", "EVENT_CALLBACK",
            assemblyIdentity, "Celeste", 33554646, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK",
            "FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK", "COMMANDREPLAY_FRAME_CALLBACK", assemblyIdentity, "Celeste",
            33554647, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
            "FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK", "COMMANDREPLAY_LOAD_BANK_CALLBACK", assemblyIdentity,
            "Celeste", 33554648, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
            "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", "COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
            assemblyIdentity, "Celeste", 33554649, false, new string[] { "System.MulticastDelegate" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.INSTANCETYPE", "FMOD.Studio.INSTANCETYPE", "INSTANCETYPE",
            assemblyIdentity, "Celeste", 33554650, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.INSTANCETYPE", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.INSTANCETYPE",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMAND_INFO", "FMOD.Studio.COMMAND_INFO", "COMMAND_INFO",
            assemblyIdentity, "Celeste", 33554651, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMAND_INFO", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMAND_INFO",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.Util", "FMOD.Studio.Util", "Util", assemblyIdentity, "Celeste",
            33554652, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.Util", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Util",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.HandleBase", "FMOD.Studio.HandleBase", "HandleBase",
            assemblyIdentity, "Celeste", 33554653, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.HandleBase", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.HandleBase",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.System", "FMOD.Studio.System", "System", assemblyIdentity,
            "Celeste", 33554654, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.System", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.System",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.EventDescription", "FMOD.Studio.EventDescription",
            "EventDescription", assemblyIdentity, "Celeste", 33554655, false,
            new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.EventDescription", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EventDescription",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.EventInstance", "FMOD.Studio.EventInstance", "EventInstance",
            assemblyIdentity, "Celeste", 33554656, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.EventInstance", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EventInstance",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.ParameterInstance", "FMOD.Studio.ParameterInstance",
            "ParameterInstance", assemblyIdentity, "Celeste", 33554657, false,
            new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.ParameterInstance", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.ParameterInstance",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.Bus", "FMOD.Studio.Bus", "Bus", assemblyIdentity, "Celeste",
            33554658, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.Bus", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Bus",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.VCA", "FMOD.Studio.VCA", "VCA", assemblyIdentity, "Celeste",
            33554659, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.VCA", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.VCA",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.Bank", "FMOD.Studio.Bank", "Bank", assemblyIdentity, "Celeste",
            33554660, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.Bank", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Bank",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.CommandReplay", "FMOD.Studio.CommandReplay", "CommandReplay",
            assemblyIdentity, "Celeste", 33554661, false, new string[] { "FMOD.Studio.HandleBase", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.CommandReplay", 0, false);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.CommandReplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("FMOD.Studio.MarshallingHelper", "FMOD.Studio.MarshallingHelper",
            "MarshallingHelper", assemblyIdentity, "Celeste", 33554662, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("FMOD.Studio.MarshallingHelper", 0, true);
        catalog.PublishDeclaredTrackedAliases("FMOD.Studio.MarshallingHelper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding", "Monocle.Binding", "Binding", assemblyIdentity, "Celeste",
            33554663, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding+<>c__DisplayClass16_0",
            "Monocle.Binding.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste", 33554664,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding.<>c__DisplayClass16_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding.<>c__DisplayClass16_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding+<>c__DisplayClass16_1",
            "Monocle.Binding.<>c__DisplayClass16_1", "<>c__DisplayClass16_1", assemblyIdentity, "Celeste", 33554665,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding.<>c__DisplayClass16_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding.<>c__DisplayClass16_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding+<>c__DisplayClass17_0",
            "Monocle.Binding.<>c__DisplayClass17_0", "<>c__DisplayClass17_0", assemblyIdentity, "Celeste", 33554666,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding.<>c__DisplayClass17_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding.<>c__DisplayClass17_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding+<>c__DisplayClass17_1",
            "Monocle.Binding.<>c__DisplayClass17_1", "<>c__DisplayClass17_1", assemblyIdentity, "Celeste", 33554667,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding.<>c__DisplayClass17_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding.<>c__DisplayClass17_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Binding+<>c__DisplayClass4_0", "Monocle.Binding.<>c__DisplayClass4_0",
            "<>c__DisplayClass4_0", assemblyIdentity, "Celeste", 33554668, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Binding.<>c__DisplayClass4_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Binding.<>c__DisplayClass4_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleEmitter", "Monocle.ParticleEmitter", "ParticleEmitter",
            assemblyIdentity, "Celeste", 33554669, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleEmitter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleEmitter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Circle", "Monocle.Circle", "Circle", assemblyIdentity, "Celeste",
            33554670, false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Circle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Circle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PointSectors", "Monocle.PointSectors", "PointSectors",
            assemblyIdentity, "Celeste", 33554671, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PointSectors", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PointSectors",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Collide", "Monocle.Collide", "Collide", assemblyIdentity, "Celeste",
            33554672, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Collide", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Collide",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Collider", "Monocle.Collider", "Collider", assemblyIdentity,
            "Celeste", 33554673, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Collider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Collider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ColliderList", "Monocle.ColliderList", "ColliderList",
            assemblyIdentity, "Celeste", 33554674, false, new string[] { "Monocle.Collider", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ColliderList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ColliderList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Grid", "Monocle.Grid", "Grid", assemblyIdentity, "Celeste", 33554675,
            false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Grid", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Grid",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Hitbox", "Monocle.Hitbox", "Hitbox", assemblyIdentity, "Celeste",
            33554676, false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Hitbox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Hitbox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Component", "Monocle.Component", "Component", assemblyIdentity,
            "Celeste", 33554677, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Component", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Component",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.GraphicsComponent", "Monocle.GraphicsComponent", "GraphicsComponent",
            assemblyIdentity, "Celeste", 33554678, true, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.GraphicsComponent", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.GraphicsComponent",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Image", "Monocle.Image", "Image", assemblyIdentity, "Celeste",
            33554679, false, new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Image", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Image",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelText", "Monocle.PixelText", "PixelText", assemblyIdentity,
            "Celeste", 33554680, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelText+Char", "Monocle.PixelText.Char", "Char", assemblyIdentity,
            "Celeste", 33554681, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelText.Char", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelText.Char",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Sprite", "Monocle.Sprite", "Sprite", assemblyIdentity, "Celeste",
            33554682, false,
            new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Sprite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Sprite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Sprite+Animation", "Monocle.Sprite.Animation", "Animation",
            assemblyIdentity, "Celeste", 33554683, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Sprite.Animation", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Sprite.Animation",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Sprite+<PlayUtil>d__40", "Monocle.Sprite.<PlayUtil>d__40",
            "<PlayUtil>d__40", assemblyIdentity, "Celeste", 33554684, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Sprite.<PlayUtil>d__40", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Sprite.<PlayUtil>d__40",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Spritesheet`1", "Monocle.Spritesheet`1", "Spritesheet`1",
            assemblyIdentity, "Celeste", 33554685, false,
            new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Spritesheet`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Spritesheet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Spritesheet`1+Animation", "Monocle.Spritesheet`1.Animation",
            "Animation", assemblyIdentity, "Celeste", 33554686, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Spritesheet`1.Animation", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Spritesheet`1.Animation",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.NumberText", "Monocle.NumberText", "NumberText", assemblyIdentity,
            "Celeste", 33554687, false,
            new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.NumberText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.NumberText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.OutlineText", "Monocle.OutlineText", "OutlineText", assemblyIdentity,
            "Celeste", 33554688, false,
            new string[] { "Monocle.Text", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.OutlineText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.OutlineText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Text", "Monocle.Text", "Text", assemblyIdentity, "Celeste", 33554689,
            false, new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Text", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Text",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Text+HorizontalAlign", "Monocle.Text.HorizontalAlign",
            "HorizontalAlign", assemblyIdentity, "Celeste", 33554690, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Text.HorizontalAlign", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Text.HorizontalAlign",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Text+VerticalAlign", "Monocle.Text.VerticalAlign", "VerticalAlign",
            assemblyIdentity, "Celeste", 33554691, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Text.VerticalAlign", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Text.VerticalAlign",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TimerText", "Monocle.TimerText", "TimerText", assemblyIdentity,
            "Celeste", 33554692, false,
            new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TimerText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TimerText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TimerText+CountModes", "Monocle.TimerText.CountModes", "CountModes",
            assemblyIdentity, "Celeste", 33554693, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TimerText.CountModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TimerText.CountModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TimerText+TimerModes", "Monocle.TimerText.TimerModes", "TimerModes",
            assemblyIdentity, "Celeste", 33554694, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TimerText.TimerModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TimerText.TimerModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TileGrid", "Monocle.TileGrid", "TileGrid", assemblyIdentity,
            "Celeste", 33554695, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TileGrid", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TileGrid",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Alarm", "Monocle.Alarm", "Alarm", assemblyIdentity, "Celeste",
            33554696, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Alarm", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Alarm",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Alarm+AlarmMode", "Monocle.Alarm.AlarmMode", "AlarmMode",
            assemblyIdentity, "Celeste", 33554697, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Alarm.AlarmMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Alarm.AlarmMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Coroutine", "Monocle.Coroutine", "Coroutine", assemblyIdentity,
            "Celeste", 33554698, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Coroutine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Coroutine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder", "Monocle.CoroutineHolder", "CoroutineHolder",
            assemblyIdentity, "Celeste", 33554699, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder+CoroutineData",
            "Monocle.CoroutineHolder.CoroutineData", "CoroutineData", assemblyIdentity, "Celeste", 33554700, false,
            new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder.CoroutineData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder.CoroutineData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder+<WaitForFrames>d__8",
            "Monocle.CoroutineHolder.<WaitForFrames>d__8", "<WaitForFrames>d__8", assemblyIdentity, "Celeste", 33554701,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder.<WaitForFrames>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder.<WaitForFrames>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CounterSet`1", "Monocle.CounterSet`1", "CounterSet`1",
            assemblyIdentity, "Celeste", 33554702, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CounterSet`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CounterSet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Shaker", "Monocle.Shaker", "Shaker", assemblyIdentity, "Celeste",
            33554703, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Shaker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Shaker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ShakerList", "Monocle.ShakerList", "ShakerList", assemblyIdentity,
            "Celeste", 33554704, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ShakerList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ShakerList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SineWave", "Monocle.SineWave", "SineWave", assemblyIdentity,
            "Celeste", 33554705, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SineWave", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SineWave",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.StateMachine", "Monocle.StateMachine", "StateMachine",
            assemblyIdentity, "Celeste", 33554706, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.StateMachine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.StateMachine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.StateMachine+<>c__DisplayClass9_0`1",
            "Monocle.StateMachine.<>c__DisplayClass9_0`1", "<>c__DisplayClass9_0`1", assemblyIdentity, "Celeste",
            33554707, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.StateMachine.<>c__DisplayClass9_0`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.StateMachine.<>c__DisplayClass9_0`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tween", "Monocle.Tween", "Tween", assemblyIdentity, "Celeste",
            33554708, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tween", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tween",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tween+TweenMode", "Monocle.Tween.TweenMode", "TweenMode",
            assemblyIdentity, "Celeste", 33554709, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tween.TweenMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tween.TweenMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tween+<>c__DisplayClass35_0", "Monocle.Tween.<>c__DisplayClass35_0",
            "<>c__DisplayClass35_0", assemblyIdentity, "Celeste", 33554710, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tween.<>c__DisplayClass35_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tween.<>c__DisplayClass35_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tween+<Wait>d__45", "Monocle.Tween.<Wait>d__45", "<Wait>d__45",
            assemblyIdentity, "Celeste", 33554711, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tween.<Wait>d__45", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tween.<Wait>d__45",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Wiggler", "Monocle.Wiggler", "Wiggler", assemblyIdentity, "Celeste",
            33554712, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Wiggler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Wiggler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Engine", "Monocle.Engine", "Engine", assemblyIdentity, "Celeste",
            33554713, false, new string[] { "Microsoft.Xna.Framework.Game" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Engine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Engine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Engine+<>c", "Monocle.Engine.<>c", "<>c", assemblyIdentity, "Celeste",
            33554714, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Engine.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Engine.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Entity",
            typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName, "Entity", assemblyIdentity, "Celeste",
            33554715, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName, 0, true);
        catalog.PublishDeclaredTrackedAliases(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName,
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Atlas", "Monocle.Atlas", "Atlas", assemblyIdentity, "Celeste",
            33554716, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Atlas", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Atlas",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Atlas+AtlasDataFormat", "Monocle.Atlas.AtlasDataFormat",
            "AtlasDataFormat", assemblyIdentity, "Celeste", 33554717, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Atlas.AtlasDataFormat", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Atlas.AtlasDataFormat",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MTexture", "Monocle.MTexture", "MTexture", assemblyIdentity,
            "Celeste", 33554718, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MTexture", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.MTexture",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteBank", "Monocle.SpriteBank", "SpriteBank", assemblyIdentity,
            "Celeste", 33554719, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteBank", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteBank",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteBank+<>c", "Monocle.SpriteBank.<>c", "<>c", assemblyIdentity,
            "Celeste", 33554720, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteBank.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteBank.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteBank+<>c__DisplayClass5_0",
            "Monocle.SpriteBank.<>c__DisplayClass5_0", "<>c__DisplayClass5_0", assemblyIdentity, "Celeste", 33554721,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteBank.<>c__DisplayClass5_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteBank.<>c__DisplayClass5_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteDataSource", "Monocle.SpriteDataSource", "SpriteDataSource",
            assemblyIdentity, "Celeste", 33554722, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteDataSource", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteDataSource",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteData", "Monocle.SpriteData", "SpriteData", assemblyIdentity,
            "Celeste", 33554723, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tileset", "Monocle.Tileset", "Tileset", assemblyIdentity, "Celeste",
            33554724, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tileset", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tileset",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput", "Monocle.MInput", "MInput", assemblyIdentity, "Celeste",
            33554725, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput+KeyboardData", "Monocle.MInput.KeyboardData", "KeyboardData",
            assemblyIdentity, "Celeste", 33554726, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput.KeyboardData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput.KeyboardData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput+MouseData", "Monocle.MInput.MouseData", "MouseData",
            assemblyIdentity, "Celeste", 33554727, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput.MouseData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput.MouseData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput+MouseData+MouseButtons",
            "Monocle.MInput.MouseData.MouseButtons", "MouseButtons", assemblyIdentity, "Celeste", 33554728, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput.MouseData.MouseButtons", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput.MouseData.MouseButtons",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput+GamePadData", "Monocle.MInput.GamePadData", "GamePadData",
            assemblyIdentity, "Celeste", 33554729, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput.GamePadData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput.GamePadData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton", "Monocle.VirtualButton", "VirtualButton",
            assemblyIdentity, "Celeste", 33554730, false, new string[] { "Monocle.VirtualInput", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+Node", "Monocle.VirtualButton.Node", "Node",
            assemblyIdentity, "Celeste", 33554731, true, new string[] { "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.Node", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.Node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+KeyboardKey", "Monocle.VirtualButton.KeyboardKey",
            "KeyboardKey", assemblyIdentity, "Celeste", 33554732, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.KeyboardKey", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.KeyboardKey",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadButton", "Monocle.VirtualButton.PadButton",
            "PadButton", assemblyIdentity, "Celeste", 33554733, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadLeftStickRight",
            "Monocle.VirtualButton.PadLeftStickRight", "PadLeftStickRight", assemblyIdentity, "Celeste", 33554734,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadLeftStickRight", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadLeftStickRight",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadLeftStickLeft",
            "Monocle.VirtualButton.PadLeftStickLeft", "PadLeftStickLeft", assemblyIdentity, "Celeste", 33554735, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadLeftStickLeft", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadLeftStickLeft",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadLeftStickUp", "Monocle.VirtualButton.PadLeftStickUp",
            "PadLeftStickUp", assemblyIdentity, "Celeste", 33554736, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadLeftStickUp", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadLeftStickUp",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadLeftStickDown",
            "Monocle.VirtualButton.PadLeftStickDown", "PadLeftStickDown", assemblyIdentity, "Celeste", 33554737, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadLeftStickDown", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadLeftStickDown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadRightStickRight",
            "Monocle.VirtualButton.PadRightStickRight", "PadRightStickRight", assemblyIdentity, "Celeste", 33554738,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadRightStickRight", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadRightStickRight",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadRightStickLeft",
            "Monocle.VirtualButton.PadRightStickLeft", "PadRightStickLeft", assemblyIdentity, "Celeste", 33554739,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadRightStickLeft", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadRightStickLeft",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadRightStickUp",
            "Monocle.VirtualButton.PadRightStickUp", "PadRightStickUp", assemblyIdentity, "Celeste", 33554740, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadRightStickUp", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadRightStickUp",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadRightStickDown",
            "Monocle.VirtualButton.PadRightStickDown", "PadRightStickDown", assemblyIdentity, "Celeste", 33554741,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadRightStickDown", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadRightStickDown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadLeftTrigger", "Monocle.VirtualButton.PadLeftTrigger",
            "PadLeftTrigger", assemblyIdentity, "Celeste", 33554742, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadLeftTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadLeftTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadRightTrigger",
            "Monocle.VirtualButton.PadRightTrigger", "PadRightTrigger", assemblyIdentity, "Celeste", 33554743, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadRightTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadRightTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadDPadRight", "Monocle.VirtualButton.PadDPadRight",
            "PadDPadRight", assemblyIdentity, "Celeste", 33554744, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadDPadRight", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadDPadRight",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadDPadLeft", "Monocle.VirtualButton.PadDPadLeft",
            "PadDPadLeft", assemblyIdentity, "Celeste", 33554745, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadDPadLeft", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadDPadLeft",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadDPadUp", "Monocle.VirtualButton.PadDPadUp",
            "PadDPadUp", assemblyIdentity, "Celeste", 33554746, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadDPadUp", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadDPadUp",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+PadDPadDown", "Monocle.VirtualButton.PadDPadDown",
            "PadDPadDown", assemblyIdentity, "Celeste", 33554747, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.PadDPadDown", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.PadDPadDown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+MouseLeftButton",
            "Monocle.VirtualButton.MouseLeftButton", "MouseLeftButton", assemblyIdentity, "Celeste", 33554748, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.MouseLeftButton", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.MouseLeftButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+MouseRightButton",
            "Monocle.VirtualButton.MouseRightButton", "MouseRightButton", assemblyIdentity, "Celeste", 33554749, false,
            new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.MouseRightButton", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.MouseRightButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+MouseMiddleButton",
            "Monocle.VirtualButton.MouseMiddleButton", "MouseMiddleButton", assemblyIdentity, "Celeste", 33554750,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.MouseMiddleButton", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.MouseMiddleButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualAxisTrigger",
            "Monocle.VirtualButton.VirtualAxisTrigger", "VirtualAxisTrigger", assemblyIdentity, "Celeste", 33554751,
            false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualAxisTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualAxisTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualAxisTrigger+Modes",
            "Monocle.VirtualButton.VirtualAxisTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33554752, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualAxisTrigger.Modes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualAxisTrigger.Modes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualIntegerAxisTrigger",
            "Monocle.VirtualButton.VirtualIntegerAxisTrigger", "VirtualIntegerAxisTrigger", assemblyIdentity, "Celeste",
            33554753, false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualIntegerAxisTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualIntegerAxisTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualIntegerAxisTrigger+Modes",
            "Monocle.VirtualButton.VirtualIntegerAxisTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33554754,
            false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualIntegerAxisTrigger.Modes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualIntegerAxisTrigger.Modes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualJoystickXTrigger",
            "Monocle.VirtualButton.VirtualJoystickXTrigger", "VirtualJoystickXTrigger", assemblyIdentity, "Celeste",
            33554755, false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualJoystickXTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualJoystickXTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualJoystickXTrigger+Modes",
            "Monocle.VirtualButton.VirtualJoystickXTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33554756,
            false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualJoystickXTrigger.Modes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualJoystickXTrigger.Modes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton+VirtualJoystickYTrigger",
            "Monocle.VirtualButton.VirtualJoystickYTrigger", "VirtualJoystickYTrigger", assemblyIdentity, "Celeste",
            33554757, false, new string[] { "Monocle.VirtualButton+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton.VirtualJoystickYTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton.VirtualJoystickYTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput", "Monocle.VirtualInput", "VirtualInput",
            assemblyIdentity, "Celeste", 33554758, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput+OverlapBehaviors",
            "Monocle.VirtualInput.OverlapBehaviors", "OverlapBehaviors", assemblyIdentity, "Celeste", 33554759, false,
            new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput.OverlapBehaviors", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput.OverlapBehaviors",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput+ThresholdModes", "Monocle.VirtualInput.ThresholdModes",
            "ThresholdModes", assemblyIdentity, "Celeste", 33554760, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput.ThresholdModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput.ThresholdModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInputNode", "Monocle.VirtualInputNode", "VirtualInputNode",
            assemblyIdentity, "Celeste", 33554761, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInputNode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInputNode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualIntegerAxis", "Monocle.VirtualIntegerAxis",
            "VirtualIntegerAxis", assemblyIdentity, "Celeste", 33554762, false,
            new string[] { "Monocle.VirtualInput", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualIntegerAxis", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualIntegerAxis",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick", "Monocle.VirtualJoystick", "VirtualJoystick",
            assemblyIdentity, "Celeste", 33554763, false, new string[] { "Monocle.VirtualInput", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick+Node", "Monocle.VirtualJoystick.Node", "Node",
            assemblyIdentity, "Celeste", 33554764, true, new string[] { "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick.Node", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick.Node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick+PadLeftStick", "Monocle.VirtualJoystick.PadLeftStick",
            "PadLeftStick", assemblyIdentity, "Celeste", 33554765, false,
            new string[] { "Monocle.VirtualJoystick+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick.PadLeftStick", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick.PadLeftStick",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick+PadRightStick",
            "Monocle.VirtualJoystick.PadRightStick", "PadRightStick", assemblyIdentity, "Celeste", 33554766, false,
            new string[] { "Monocle.VirtualJoystick+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick.PadRightStick", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick.PadRightStick",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick+PadDpad", "Monocle.VirtualJoystick.PadDpad",
            "PadDpad", assemblyIdentity, "Celeste", 33554767, false,
            new string[] { "Monocle.VirtualJoystick+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick.PadDpad", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick.PadDpad",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick+KeyboardKeys", "Monocle.VirtualJoystick.KeyboardKeys",
            "KeyboardKeys", assemblyIdentity, "Celeste", 33554768, false,
            new string[] { "Monocle.VirtualJoystick+Node", "Monocle.VirtualInputNode", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick.KeyboardKeys", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick.KeyboardKeys",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ComponentList", "Monocle.ComponentList", "ComponentList",
            assemblyIdentity, "Celeste", 33554769, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ComponentList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ComponentList+LockModes", "Monocle.ComponentList.LockModes",
            "LockModes", assemblyIdentity, "Celeste", 33554770, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ComponentList.LockModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList.LockModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ComponentList+<GetAll>d__36`1",
            "Monocle.ComponentList.<GetAll>d__36`1", "<GetAll>d__36`1", assemblyIdentity, "Celeste", 33554771, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<T>", "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<T>", "System.IDisposable", "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ComponentList.<GetAll>d__36`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList.<GetAll>d__36`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.EntityList", "Monocle.EntityList", "EntityList", assemblyIdentity,
            "Celeste", 33554772, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.EntityList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.EntityList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.EntityList+<>c", "Monocle.EntityList.<>c", "<>c", assemblyIdentity,
            "Celeste", 33554773, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.EntityList.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.EntityList.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.RendererList", "Monocle.RendererList", "RendererList",
            assemblyIdentity, "Celeste", 33554774, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.RendererList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.RendererList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TagLists", "Monocle.TagLists", "TagLists", assemblyIdentity,
            "Celeste", 33554775, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TagLists", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TagLists",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Particle", "Monocle.Particle", "Particle", assemblyIdentity,
            "Celeste", 33554776, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleSystem", "Monocle.ParticleSystem", "ParticleSystem",
            assemblyIdentity, "Celeste", 33554777, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleSystem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleSystem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleType", "Monocle.ParticleType", "ParticleType",
            assemblyIdentity, "Celeste", 33554778, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleType", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+ColorModes", "Monocle.ParticleType.ColorModes",
            "ColorModes", assemblyIdentity, "Celeste", 33554779, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.ColorModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.ColorModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+FadeModes", "Monocle.ParticleType.FadeModes",
            "FadeModes", assemblyIdentity, "Celeste", 33554780, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.FadeModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.FadeModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleType+RotationModes", "Monocle.ParticleType.RotationModes",
            "RotationModes", assemblyIdentity, "Celeste", 33554781, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleType.RotationModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType.RotationModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.EverythingRenderer", "Monocle.EverythingRenderer",
            "EverythingRenderer", assemblyIdentity, "Celeste", 33554782, false,
            new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.EverythingRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.EverythingRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Renderer", "Monocle.Renderer", "Renderer", assemblyIdentity,
            "Celeste", 33554783, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Renderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Renderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SingleTagRenderer", "Monocle.SingleTagRenderer", "SingleTagRenderer",
            assemblyIdentity, "Celeste", 33554784, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SingleTagRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SingleTagRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TagExcludeRenderer", "Monocle.TagExcludeRenderer",
            "TagExcludeRenderer", assemblyIdentity, "Celeste", 33554785, false,
            new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TagExcludeRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TagExcludeRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Scene", "Monocle.Scene", "Scene", assemblyIdentity, "Celeste",
            33554786, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Scene", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Scene",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.BitTag", "Monocle.BitTag", "BitTag", assemblyIdentity, "Celeste",
            33554787, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.BitTag", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.BitTag",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Cache", "Monocle.Cache", "Cache", assemblyIdentity, "Celeste",
            33554788, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Cache", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Cache",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Calc", "Monocle.Calc", "Calc", assemblyIdentity, "Celeste", 33554789,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Calc", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Calc",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Calc+<>c", "Monocle.Calc.<>c", "<>c", assemblyIdentity, "Celeste",
            33554790, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Calc.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Calc.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Calc+<Do>d__246", "Monocle.Calc.<Do>d__246", "<Do>d__246",
            assemblyIdentity, "Celeste", 33554791, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Calc.<Do>d__246", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Calc.<Do>d__246",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.QuaternionExt", "Monocle.QuaternionExt", "QuaternionExt",
            assemblyIdentity, "Celeste", 33554792, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.QuaternionExt", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.QuaternionExt",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Camera", "Monocle.Camera", "Camera", assemblyIdentity, "Celeste",
            33554793, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Camera", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Camera",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CheatListener", "Monocle.CheatListener", "CheatListener",
            assemblyIdentity, "Celeste", 33554794, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CheatListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CheatListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ChoiceSet`1", "Monocle.ChoiceSet`1", "ChoiceSet`1", assemblyIdentity,
            "Celeste", 33554795, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ChoiceSet`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.ChoiceSet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ChoiceSet`1+Choice", "Monocle.ChoiceSet`1.Choice", "Choice",
            assemblyIdentity, "Celeste", 33554796, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ChoiceSet`1.Choice", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ChoiceSet`1.Choice",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Chooser`1", "Monocle.Chooser`1", "Chooser`1", assemblyIdentity,
            "Celeste", 33554797, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Chooser`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Chooser`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Chooser`1+Choice", "Monocle.Chooser`1.Choice", "Choice",
            assemblyIdentity, "Celeste", 33554798, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Chooser`1.Choice", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Chooser`1.Choice",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands", "Monocle.Commands", "Commands", assemblyIdentity,
            "Celeste", 33554799, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+CommandInfo", "Monocle.Commands.CommandInfo", "CommandInfo",
            assemblyIdentity, "Celeste", 33554800, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.CommandInfo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.CommandInfo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+Line", "Monocle.Commands.Line", "Line", assemblyIdentity,
            "Celeste", 33554801, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.Line", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.Line",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass38_0",
            "Monocle.Commands.<>c__DisplayClass38_0", "<>c__DisplayClass38_0", assemblyIdentity, "Celeste", 33554802,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass38_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass38_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass38_1",
            "Monocle.Commands.<>c__DisplayClass38_1", "<>c__DisplayClass38_1", assemblyIdentity, "Celeste", 33554803,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass38_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass38_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+CommandData", "Monocle.Commands.CommandData", "CommandData",
            assemblyIdentity, "Celeste", 33554804, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.CommandData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.CommandData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c", "Monocle.Commands.<>c", "<>c", assemblyIdentity,
            "Celeste", 33554805, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass28_0",
            "Monocle.Commands.<>c__DisplayClass28_0", "<>c__DisplayClass28_0", assemblyIdentity, "Celeste", 33554806,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass28_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass28_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<>c__DisplayClass29_0",
            "Monocle.Commands.<>c__DisplayClass29_0", "<>c__DisplayClass29_0", assemblyIdentity, "Celeste", 33554807,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<>c__DisplayClass29_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<>c__DisplayClass29_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands+<GetCommands>d__44", "Monocle.Commands.<GetCommands>d__44",
            "<GetCommands>d__44", assemblyIdentity, "Celeste", 33554808, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Commands+CommandData>",
                "System.Collections.IEnumerable",
                "System.Collections.Generic.IEnumerator`1<Monocle.Commands+CommandData>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands.<GetCommands>d__44", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands.<GetCommands>d__44",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Command", "Monocle.Command", "Command", assemblyIdentity, "Celeste",
            33554809, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Command", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Command",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Draw", "Monocle.Draw", "Draw", assemblyIdentity, "Celeste", 33554810,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Draw", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Draw",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease", "Monocle.Ease", "Ease", assemblyIdentity, "Celeste", 33554811,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease+Easer", "Monocle.Ease.Easer", "Easer", assemblyIdentity,
            "Celeste", 33554812, false, new string[] { "System.MulticastDelegate" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease.Easer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease.Easer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c__DisplayClass35_0", "Monocle.Ease.<>c__DisplayClass35_0",
            "<>c__DisplayClass35_0", assemblyIdentity, "Celeste", 33554813, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c__DisplayClass35_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c__DisplayClass35_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c__DisplayClass36_0", "Monocle.Ease.<>c__DisplayClass36_0",
            "<>c__DisplayClass36_0", assemblyIdentity, "Celeste", 33554814, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c__DisplayClass36_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c__DisplayClass36_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease+<>c", "Monocle.Ease.<>c", "<>c", assemblyIdentity, "Celeste",
            33554815, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ErrorLog", "Monocle.ErrorLog", "ErrorLog", assemblyIdentity,
            "Celeste", 33554816, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ErrorLog", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ErrorLog",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MethodHandle`1", "Monocle.MethodHandle`1", "MethodHandle`1",
            assemblyIdentity, "Celeste", 33554817, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MethodHandle`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MethodHandle`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFontCharacter", "Monocle.PixelFontCharacter",
            "PixelFontCharacter", assemblyIdentity, "Celeste", 33554818, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFontCharacter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontCharacter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFontSize", "Monocle.PixelFontSize", "PixelFontSize",
            assemblyIdentity, "Celeste", 33554819, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFontSize", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontSize",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFont", "Monocle.PixelFont", "PixelFont", assemblyIdentity,
            "Celeste", 33554820, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFont", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFont+<>c", "Monocle.PixelFont.<>c", "<>c", assemblyIdentity,
            "Celeste", 33554821, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFont.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFont+<>c__DisplayClass1_0",
            "Monocle.PixelFont.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste", 33554822,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFont.<>c__DisplayClass1_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont.<>c__DisplayClass1_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pnt", "Monocle.Pnt", "Pnt", assemblyIdentity, "Celeste", 33554823,
            false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pnt", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pnt",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pooler", "Monocle.Pooler", "Pooler", assemblyIdentity, "Celeste",
            33554824, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pooler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pooler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pooled", "Monocle.Pooled", "Pooled", assemblyIdentity, "Celeste",
            33554825, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pooled", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pooled",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SaveLoad", "Monocle.SaveLoad", "SaveLoad", assemblyIdentity,
            "Celeste", 33554826, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SaveLoad", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SaveLoad",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SaveLoad+SerializeModes", "Monocle.SaveLoad.SerializeModes",
            "SerializeModes", assemblyIdentity, "Celeste", 33554827, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SaveLoad.SerializeModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SaveLoad.SerializeModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SimpleCurve", "Monocle.SimpleCurve", "SimpleCurve", assemblyIdentity,
            "Celeste", 33554828, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SimpleCurve", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SimpleCurve",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpecEntity`1", "Monocle.SpecEntity`1", "SpecEntity`1",
            assemblyIdentity, "Celeste", 33554829, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpecEntity`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpecEntity`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tiler", "Monocle.Tiler", "Tiler", assemblyIdentity, "Celeste",
            33554830, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tiler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tiler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tiler+EdgeBehavior", "Monocle.Tiler.EdgeBehavior", "EdgeBehavior",
            assemblyIdentity, "Celeste", 33554831, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tiler.EdgeBehavior", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tiler.EdgeBehavior",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.AutotileData", "Monocle.AutotileData", "AutotileData",
            assemblyIdentity, "Celeste", 33554832, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.AutotileData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.AutotileData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tracker", "Monocle.Tracker", "Tracker", assemblyIdentity, "Celeste",
            33554833, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tracker", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tracker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
