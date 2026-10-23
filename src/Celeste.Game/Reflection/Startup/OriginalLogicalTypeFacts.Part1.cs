using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup;

public static partial class OriginalLogicalTypeFacts
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
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleEmitter", "Monocle.ParticleEmitter", "ParticleEmitter",
            assemblyIdentity, "Celeste", 33554664, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleEmitter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleEmitter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Circle", "Monocle.Circle", "Circle", assemblyIdentity, "Celeste",
            33554665, false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Circle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Circle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PointSectors", "Monocle.PointSectors", "PointSectors",
            assemblyIdentity, "Celeste", 33554666, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PointSectors", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PointSectors",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Collide", "Monocle.Collide", "Collide", assemblyIdentity, "Celeste",
            33554667, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Collide", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Collide",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Collider", "Monocle.Collider", "Collider", assemblyIdentity,
            "Celeste", 33554668, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Collider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Collider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ColliderList", "Monocle.ColliderList", "ColliderList",
            assemblyIdentity, "Celeste", 33554669, false, new string[] { "Monocle.Collider", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ColliderList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ColliderList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Grid", "Monocle.Grid", "Grid", assemblyIdentity, "Celeste", 33554670,
            false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Grid", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Grid",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Hitbox", "Monocle.Hitbox", "Hitbox", assemblyIdentity, "Celeste",
            33554671, false, new string[] { "Monocle.Collider", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Hitbox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Hitbox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Component", "Monocle.Component", "Component", assemblyIdentity,
            "Celeste", 33554672, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Component", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Component",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.GraphicsComponent", "Monocle.GraphicsComponent", "GraphicsComponent",
            assemblyIdentity, "Celeste", 33554673, true, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.GraphicsComponent", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.GraphicsComponent",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Image", "Monocle.Image", "Image", assemblyIdentity, "Celeste",
            33554674, false, new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Image", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Image",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelText", "Monocle.PixelText", "PixelText", assemblyIdentity,
            "Celeste", 33554675, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Sprite", "Monocle.Sprite", "Sprite", assemblyIdentity, "Celeste",
            33554676, false,
            new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Sprite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Sprite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Spritesheet`1", "Monocle.Spritesheet`1", "Spritesheet`1",
            assemblyIdentity, "Celeste", 33554677, false,
            new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Spritesheet`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Spritesheet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.NumberText", "Monocle.NumberText", "NumberText", assemblyIdentity,
            "Celeste", 33554678, false,
            new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.NumberText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.NumberText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.OutlineText", "Monocle.OutlineText", "OutlineText", assemblyIdentity,
            "Celeste", 33554679, false,
            new string[] { "Monocle.Text", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.OutlineText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.OutlineText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Text", "Monocle.Text", "Text", assemblyIdentity, "Celeste", 33554680,
            false, new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Text", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Text",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TimerText", "Monocle.TimerText", "TimerText", assemblyIdentity,
            "Celeste", 33554681, false,
            new string[] { "Monocle.GraphicsComponent", "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TimerText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TimerText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TileGrid", "Monocle.TileGrid", "TileGrid", assemblyIdentity,
            "Celeste", 33554682, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TileGrid", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TileGrid",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Alarm", "Monocle.Alarm", "Alarm", assemblyIdentity, "Celeste",
            33554683, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Alarm", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Alarm",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Coroutine", "Monocle.Coroutine", "Coroutine", assemblyIdentity,
            "Celeste", 33554684, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Coroutine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Coroutine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder", "Monocle.CoroutineHolder", "CoroutineHolder",
            assemblyIdentity, "Celeste", 33554685, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CounterSet`1", "Monocle.CounterSet`1", "CounterSet`1",
            assemblyIdentity, "Celeste", 33554686, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CounterSet`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CounterSet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Shaker", "Monocle.Shaker", "Shaker", assemblyIdentity, "Celeste",
            33554687, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Shaker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Shaker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ShakerList", "Monocle.ShakerList", "ShakerList", assemblyIdentity,
            "Celeste", 33554688, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ShakerList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ShakerList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SineWave", "Monocle.SineWave", "SineWave", assemblyIdentity,
            "Celeste", 33554689, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SineWave", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SineWave",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.StateMachine", "Monocle.StateMachine", "StateMachine",
            assemblyIdentity, "Celeste", 33554690, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.StateMachine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.StateMachine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tween", "Monocle.Tween", "Tween", assemblyIdentity, "Celeste",
            33554691, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tween", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tween",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Wiggler", "Monocle.Wiggler", "Wiggler", assemblyIdentity, "Celeste",
            33554692, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Wiggler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Wiggler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Engine", "Monocle.Engine", "Engine", assemblyIdentity, "Celeste",
            33554693, false, new string[] { "Microsoft.Xna.Framework.Game" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Engine", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Engine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Entity",
            typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName, "Entity", assemblyIdentity, "Celeste",
            33554694, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName, 0, true);
        catalog.PublishDeclaredTrackedAliases(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName,
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Atlas", "Monocle.Atlas", "Atlas", assemblyIdentity, "Celeste",
            33554695, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Atlas", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Atlas",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MTexture", "Monocle.MTexture", "MTexture", assemblyIdentity,
            "Celeste", 33554696, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MTexture", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.MTexture",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteBank", "Monocle.SpriteBank", "SpriteBank", assemblyIdentity,
            "Celeste", 33554697, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteBank", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteBank",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteDataSource", "Monocle.SpriteDataSource", "SpriteDataSource",
            assemblyIdentity, "Celeste", 33554698, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteDataSource", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteDataSource",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpriteData", "Monocle.SpriteData", "SpriteData", assemblyIdentity,
            "Celeste", 33554699, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpriteData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpriteData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tileset", "Monocle.Tileset", "Tileset", assemblyIdentity, "Celeste",
            33554700, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tileset", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tileset",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MInput", "Monocle.MInput", "MInput", assemblyIdentity, "Celeste",
            33554701, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MInput", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MInput",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton", "Monocle.VirtualButton", "VirtualButton",
            assemblyIdentity, "Celeste", 33554702, false, new string[] { "Monocle.VirtualInput", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput", "Monocle.VirtualInput", "VirtualInput",
            assemblyIdentity, "Celeste", 33554703, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualInputNode", "Monocle.VirtualInputNode", "VirtualInputNode",
            assemblyIdentity, "Celeste", 33554704, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualInputNode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInputNode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualIntegerAxis", "Monocle.VirtualIntegerAxis",
            "VirtualIntegerAxis", assemblyIdentity, "Celeste", 33554705, false,
            new string[] { "Monocle.VirtualInput", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualIntegerAxis", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualIntegerAxis",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick", "Monocle.VirtualJoystick", "VirtualJoystick",
            assemblyIdentity, "Celeste", 33554706, false, new string[] { "Monocle.VirtualInput", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ComponentList", "Monocle.ComponentList", "ComponentList",
            assemblyIdentity, "Celeste", 33554707, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ComponentList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.EntityList", "Monocle.EntityList", "EntityList", assemblyIdentity,
            "Celeste", 33554708, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.EntityList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.EntityList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.RendererList", "Monocle.RendererList", "RendererList",
            assemblyIdentity, "Celeste", 33554709, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.RendererList", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.RendererList",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TagLists", "Monocle.TagLists", "TagLists", assemblyIdentity,
            "Celeste", 33554710, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TagLists", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TagLists",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Particle", "Monocle.Particle", "Particle", assemblyIdentity,
            "Celeste", 33554711, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Particle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Particle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleSystem", "Monocle.ParticleSystem", "ParticleSystem",
            assemblyIdentity, "Celeste", 33554712, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleSystem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleSystem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ParticleType", "Monocle.ParticleType", "ParticleType",
            assemblyIdentity, "Celeste", 33554713, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ParticleType", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.EverythingRenderer", "Monocle.EverythingRenderer",
            "EverythingRenderer", assemblyIdentity, "Celeste", 33554714, false,
            new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.EverythingRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.EverythingRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Renderer", "Monocle.Renderer", "Renderer", assemblyIdentity,
            "Celeste", 33554715, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Renderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Renderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SingleTagRenderer", "Monocle.SingleTagRenderer", "SingleTagRenderer",
            assemblyIdentity, "Celeste", 33554716, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SingleTagRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SingleTagRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.TagExcludeRenderer", "Monocle.TagExcludeRenderer",
            "TagExcludeRenderer", assemblyIdentity, "Celeste", 33554717, false,
            new string[] { "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.TagExcludeRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.TagExcludeRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Scene", "Monocle.Scene", "Scene", assemblyIdentity, "Celeste",
            33554718, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Scene", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Scene",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.BitTag", "Monocle.BitTag", "BitTag", assemblyIdentity, "Celeste",
            33554719, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.BitTag", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.BitTag",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Cache", "Monocle.Cache", "Cache", assemblyIdentity, "Celeste",
            33554720, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Cache", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Cache",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Calc", "Monocle.Calc", "Calc", assemblyIdentity, "Celeste", 33554721,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Calc", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Calc",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.QuaternionExt", "Monocle.QuaternionExt", "QuaternionExt",
            assemblyIdentity, "Celeste", 33554722, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.QuaternionExt", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.QuaternionExt",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Camera", "Monocle.Camera", "Camera", assemblyIdentity, "Celeste",
            33554723, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Camera", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Camera",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.CheatListener", "Monocle.CheatListener", "CheatListener",
            assemblyIdentity, "Celeste", 33554724, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.CheatListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.CheatListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ChoiceSet`1", "Monocle.ChoiceSet`1", "ChoiceSet`1", assemblyIdentity,
            "Celeste", 33554725, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ChoiceSet`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.ChoiceSet`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Chooser`1", "Monocle.Chooser`1", "Chooser`1", assemblyIdentity,
            "Celeste", 33554726, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Chooser`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Chooser`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Commands", "Monocle.Commands", "Commands", assemblyIdentity,
            "Celeste", 33554727, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Commands", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Commands",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Command", "Monocle.Command", "Command", assemblyIdentity, "Celeste",
            33554728, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Command", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Command",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Draw", "Monocle.Draw", "Draw", assemblyIdentity, "Celeste", 33554729,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Draw", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Draw",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Ease", "Monocle.Ease", "Ease", assemblyIdentity, "Celeste", 33554730,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Ease", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Ease",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.ErrorLog", "Monocle.ErrorLog", "ErrorLog", assemblyIdentity,
            "Celeste", 33554731, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.ErrorLog", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.ErrorLog",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.MethodHandle`1", "Monocle.MethodHandle`1", "MethodHandle`1",
            assemblyIdentity, "Celeste", 33554732, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.MethodHandle`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.MethodHandle`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFontCharacter", "Monocle.PixelFontCharacter",
            "PixelFontCharacter", assemblyIdentity, "Celeste", 33554733, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFontCharacter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontCharacter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFontSize", "Monocle.PixelFontSize", "PixelFontSize",
            assemblyIdentity, "Celeste", 33554734, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFontSize", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontSize",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.PixelFont", "Monocle.PixelFont", "PixelFont", assemblyIdentity,
            "Celeste", 33554735, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.PixelFont", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pnt", "Monocle.Pnt", "Pnt", assemblyIdentity, "Celeste", 33554736,
            false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pnt", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pnt",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pooler", "Monocle.Pooler", "Pooler", assemblyIdentity, "Celeste",
            33554737, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pooler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pooler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Pooled", "Monocle.Pooled", "Pooled", assemblyIdentity, "Celeste",
            33554738, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Pooled", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Pooled",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SaveLoad", "Monocle.SaveLoad", "SaveLoad", assemblyIdentity,
            "Celeste", 33554739, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SaveLoad", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SaveLoad",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SimpleCurve", "Monocle.SimpleCurve", "SimpleCurve", assemblyIdentity,
            "Celeste", 33554740, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SimpleCurve", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.SimpleCurve",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.SpecEntity`1", "Monocle.SpecEntity`1", "SpecEntity`1",
            assemblyIdentity, "Celeste", 33554741, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.SpecEntity`1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.SpecEntity`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tiler", "Monocle.Tiler", "Tiler", assemblyIdentity, "Celeste",
            33554742, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tiler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tiler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.AutotileData", "Monocle.AutotileData", "AutotileData",
            assemblyIdentity, "Celeste", 33554743, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.AutotileData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.AutotileData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tracker", "Monocle.Tracker", "Tracker", assemblyIdentity, "Celeste",
            33554744, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tracker", 0, true);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tracker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.Tracked", "Monocle.Tracked", "Tracked", assemblyIdentity, "Celeste",
            33554745, false, new string[] { "System.Attribute" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.Tracked", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.Tracked",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualAsset", "Monocle.VirtualAsset", "VirtualAsset",
            assemblyIdentity, "Celeste", 33554746, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualAsset", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualAsset",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture", "Monocle.VirtualTexture", "VirtualTexture",
            assemblyIdentity, "Celeste", 33554747, false, new string[] { "Monocle.VirtualAsset", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualRenderTarget", "Monocle.VirtualRenderTarget",
            "VirtualRenderTarget", assemblyIdentity, "Celeste", 33554748, false,
            new string[] { "Monocle.VirtualAsset", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualRenderTarget", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualRenderTarget",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualContent", "Monocle.VirtualContent", "VirtualContent",
            assemblyIdentity, "Celeste", 33554749, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualContent", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualContent",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Monocle.VirtualMap`1", "Monocle.VirtualMap`1", "VirtualMap`1",
            assemblyIdentity, "Celeste", 33554750, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Monocle.VirtualMap`1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Monocle.VirtualMap`1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Language", "Celeste.Language", "Language", assemblyIdentity,
            "Celeste", 33554751, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Language", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Language",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DisconnectedControllerUI", "Celeste.DisconnectedControllerUI",
            "DisconnectedControllerUI", assemblyIdentity, "Celeste", 33554752, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DisconnectedControllerUI", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DisconnectedControllerUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock", "Celeste.BounceBlock", "BounceBlock", assemblyIdentity,
            "Celeste", 33554753, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock", "Celeste.CassetteBlock", "CassetteBlock",
            assemblyIdentity, "Celeste", 33554754, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlockManager", "Celeste.CassetteBlockManager",
            "CassetteBlockManager", assemblyIdentity, "Celeste", 33554755, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlockManager", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlockManager",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FloatySpaceBlock", "Celeste.FloatySpaceBlock", "FloatySpaceBlock",
            assemblyIdentity, "Celeste", 33554756, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FloatySpaceBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FloatySpaceBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell", "Celeste.CS10_Farewell", "CS10_Farewell",
            assemblyIdentity, "Celeste", 33554757, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch", "Celeste.CS10_FinalLaunch", "CS10_FinalLaunch",
            assemblyIdentity, "Celeste", 33554758, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom", "Celeste.CS10_FinalRoom", "CS10_FinalRoom",
            assemblyIdentity, "Celeste", 33554759, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarRotateSpinner", "Celeste.StarRotateSpinner", "StarRotateSpinner",
            assemblyIdentity, "Celeste", 33554760, false,
            new string[]
            {
                "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarRotateSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarRotateSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarTrackSpinner", "Celeste.StarTrackSpinner", "StarTrackSpinner",
            assemblyIdentity, "Celeste", 33554761, false,
            new string[]
            {
                "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarTrackSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarTrackSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrumbleWallOnRumble", "Celeste.CrumbleWallOnRumble",
            "CrumbleWallOnRumble", assemblyIdentity, "Celeste", 33554762, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrumbleWallOnRumble", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrumbleWallOnRumble",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock", "Celeste.CrushBlock", "CrushBlock", assemblyIdentity,
            "Celeste", 33554763, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GlassBlock", "Celeste.GlassBlock", "GlassBlock", assemblyIdentity,
            "Celeste", 33554764, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GlassBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GoldenBlock", "Celeste.GoldenBlock", "GoldenBlock", assemblyIdentity,
            "Celeste", 33554765, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GoldenBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GoldenBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IceBlock", "Celeste.IceBlock", "IceBlock", assemblyIdentity,
            "Celeste", 33554766, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IceBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.IceBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightningBreakerBox", "Celeste.LightningBreakerBox",
            "LightningBreakerBox", assemblyIdentity, "Celeste", 33554767, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightningBreakerBox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightningBreakerBox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cassette", "Celeste.Cassette", "Cassette", assemblyIdentity,
            "Celeste", 33554768, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cassette", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cassette",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StrawberryPoints", "Celeste.StrawberryPoints", "StrawberryPoints",
            assemblyIdentity, "Celeste", 33554769, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StrawberryPoints", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StrawberryPoints",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitGem", "Celeste.SummitGem", "SummitGem", assemblyIdentity,
            "Celeste", 33554770, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitGem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineAutoAnimator", "Celeste.BadelineAutoAnimator",
            "BadelineAutoAnimator", assemblyIdentity, "Celeste", 33554771, false,
            new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineAutoAnimator", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineAutoAnimator",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClimbBlocker", "Celeste.ClimbBlocker", "ClimbBlocker",
            assemblyIdentity, "Celeste", 33554772, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClimbBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClimbBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoreModeListener", "Celeste.CoreModeListener", "CoreModeListener",
            assemblyIdentity, "Celeste", 33554773, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoreModeListener", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoreModeListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DeathEffect", "Celeste.DeathEffect", "DeathEffect", assemblyIdentity,
            "Celeste", 33554774, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DeathEffect", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DeathEffect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GrannyLaughSfx", "Celeste.GrannyLaughSfx", "GrannyLaughSfx",
            assemblyIdentity, "Celeste", 33554775, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GrannyLaughSfx", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GrannyLaughSfx",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LavaRect", "Celeste.LavaRect", "LavaRect", assemblyIdentity,
            "Celeste", 33554776, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LavaRect", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelEndingHook", "Celeste.LevelEndingHook", "LevelEndingHook",
            assemblyIdentity, "Celeste", 33554777, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelEndingHook", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelEndingHook",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PostUpdateHook", "Celeste.PostUpdateHook", "PostUpdateHook",
            assemblyIdentity, "Celeste", 33554778, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PostUpdateHook", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PostUpdateHook",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PufferCollider", "Celeste.PufferCollider", "PufferCollider",
            assemblyIdentity, "Celeste", 33554779, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PufferCollider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PufferCollider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerCollider", "Celeste.SeekerCollider", "SeekerCollider",
            assemblyIdentity, "Celeste", 33554780, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerCollider", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerCollider",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SolidOnInvinciblePlayer", "Celeste.SolidOnInvinciblePlayer",
            "SolidOnInvinciblePlayer", assemblyIdentity, "Celeste", 33554781, false,
            new string[] { "Monocle.Component", "System.Object" }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SolidOnInvinciblePlayer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SolidOnInvinciblePlayer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaterInteraction", "Celeste.WaterInteraction", "WaterInteraction",
            assemblyIdentity, "Celeste", 33554782, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaterInteraction", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaterInteraction",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending", "Celeste.CS10_Ending", "CS10_Ending", assemblyIdentity,
            "Celeste", 33554783, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird", "Celeste.CS10_MissTheBird", "CS10_MissTheBird",
            assemblyIdentity, "Celeste", 33554784, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_FreeBird", "Celeste.CS10_FreeBird", "CS10_FreeBird",
            assemblyIdentity, "Celeste", 33554785, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_FreeBird", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FreeBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone", "Celeste.CS10_Gravestone", "CS10_Gravestone",
            assemblyIdentity, "Celeste", 33554786, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Diary", "Celeste.CS03_Diary", "CS03_Diary", assemblyIdentity,
            "Celeste", 33554787, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Diary", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Diary",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Guestbook", "Celeste.CS03_Guestbook", "CS03_Guestbook",
            assemblyIdentity, "Celeste", 33554788, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Guestbook", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Guestbook",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo", "Celeste.CS03_Memo", "CS03_Memo", assemblyIdentity,
            "Celeste", 33554789, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone", "Celeste.CS05_TheoPhone", "CS05_TheoPhone",
            assemblyIdentity, "Celeste", 33554790, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits", "Celeste.CS07_Credits", "CS07_Credits",
            assemblyIdentity, "Celeste", 33554791, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending", "Celeste.CS08_Ending", "CS08_Ending", assemblyIdentity,
            "Celeste", 33554792, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird", "Celeste.CS10_CatchTheBird", "CS10_CatchTheBird",
            assemblyIdentity, "Celeste", 33554793, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro", "Celeste.CS10_HubIntro", "CS10_HubIntro",
            assemblyIdentity, "Celeste", 33554794, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps", "Celeste.CS10_BadelineHelps",
            "CS10_BadelineHelps", assemblyIdentity, "Celeste", 33554795, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro", "Celeste.CS10_MoonIntro", "CS10_MoonIntro",
            assemblyIdentity, "Celeste", 33554796, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS08_EnterDoor", "Celeste.CS08_EnterDoor", "CS08_EnterDoor",
            assemblyIdentity, "Celeste", 33554797, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS08_EnterDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS08_EnterDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending", "Celeste.CS07_Ending", "CS07_Ending", assemblyIdentity,
            "Celeste", 33554798, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal", "Celeste.CS02_Journal", "CS02_Journal",
            assemblyIdentity, "Celeste", 33554799, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Reflection1", "Celeste.CS05_Reflection1", "CS05_Reflection1",
            assemblyIdentity, "Celeste", 33554800, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Reflection1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Reflection1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossMid", "Celeste.CS06_BossMid", "CS06_BossMid",
            assemblyIdentity, "Celeste", 33554801, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossMid", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossMid",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_StarJumpEnd", "Celeste.CS06_StarJumpEnd", "CS06_StarJumpEnd",
            assemblyIdentity, "Celeste", 33554802, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_StarJumpEnd", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_StarJumpEnd",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS06_Reflection", "Celeste.CS06_Reflection", "CS06_Reflection",
            assemblyIdentity, "Celeste", 33554803, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS06_Reflection", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Reflection",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ascend", "Celeste.CS07_Ascend", "CS07_Ascend", assemblyIdentity,
            "Celeste", 33554804, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ascend", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ascend",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CSGEN_StrawberrySeeds", "Celeste.CSGEN_StrawberrySeeds",
            "CSGEN_StrawberrySeeds", assemblyIdentity, "Celeste", 33554805, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CSGEN_StrawberrySeeds", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CSGEN_StrawberrySeeds",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FireBall", "Celeste.FireBall", "FireBall", assemblyIdentity,
            "Celeste", 33554806, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FireBall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FireBall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FireBarrier", "Celeste.FireBarrier", "FireBarrier", assemblyIdentity,
            "Celeste", 33554807, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FireBarrier", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FireBarrier",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Killbox", "Celeste.Killbox", "Killbox", assemblyIdentity, "Celeste",
            33554808, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Killbox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Killbox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Lightning", "Celeste.Lightning", "Lightning", assemblyIdentity,
            "Celeste", 33554809, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Lightning", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Lightning",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RisingLava", "Celeste.RisingLava", "RisingLava", assemblyIdentity,
            "Celeste", 33554810, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RisingLava", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RisingLava",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SandwichLava", "Celeste.SandwichLava", "SandwichLava",
            assemblyIdentity, "Celeste", 33554811, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SandwichLava", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SandwichLava",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeballShockwave", "Celeste.TempleBigEyeballShockwave",
            "TempleBigEyeballShockwave", assemblyIdentity, "Celeste", 33554812, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeballShockwave", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeballShockwave",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerDashAssist", "Celeste.PlayerDashAssist", "PlayerDashAssist",
            assemblyIdentity, "Celeste", 33554813, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerDashAssist", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDashAssist",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlaybackBillboard", "Celeste.PlaybackBillboard", "PlaybackBillboard",
            assemblyIdentity, "Celeste", 33554814, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlaybackBillboard", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlaybackBillboard",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PowerSourceNumber", "Celeste.PowerSourceNumber", "PowerSourceNumber",
            assemblyIdentity, "Celeste", 33554815, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PowerSourceNumber", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PowerSourceNumber",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BirdPath", "Celeste.BirdPath", "BirdPath", assemblyIdentity,
            "Celeste", 33554816, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BirdPath", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BirdPath",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CutsceneNode", "Celeste.CutsceneNode", "CutsceneNode",
            assemblyIdentity, "Celeste", 33554817, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CutsceneNode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CutsceneNode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlingBirdIntro", "Celeste.FlingBirdIntro", "FlingBirdIntro",
            assemblyIdentity, "Celeste", 33554818, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlingBirdIntro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlingBirdIntro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC07X_Granny_Ending", "Celeste.NPC07X_Granny_Ending",
            "NPC07X_Granny_Ending", assemblyIdentity, "Celeste", 33554819, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC07X_Granny_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC07X_Granny_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC09_Granny_Inside", "Celeste.NPC09_Granny_Inside",
            "NPC09_Granny_Inside", assemblyIdentity, "Celeste", 33554820, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC09_Granny_Inside", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC09_Granny_Inside",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC10_Gravestone", "Celeste.NPC10_Gravestone", "NPC10_Gravestone",
            assemblyIdentity, "Celeste", 33554821, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC10_Gravestone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC10_Gravestone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC09_Granny_Outside", "Celeste.NPC09_Granny_Outside",
            "NPC09_Granny_Outside", assemblyIdentity, "Celeste", 33554822, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC09_Granny_Outside", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC09_Granny_Outside",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC08_Theo", "Celeste.NPC08_Theo", "NPC08_Theo", assemblyIdentity,
            "Celeste", 33554823, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC08_Theo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC08_Theo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC08_Granny", "Celeste.NPC08_Granny", "NPC08_Granny",
            assemblyIdentity, "Celeste", 33554824, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC08_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC08_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Bumper", "Celeste.Bumper", "Bumper", assemblyIdentity, "Celeste",
            33554825, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Bumper", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Bumper",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineBoost", "Celeste.BadelineBoost", "BadelineBoost",
            assemblyIdentity, "Celeste", 33554826, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineBoost", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineBoost",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BeforeRenderHook", "Celeste.BeforeRenderHook", "BeforeRenderHook",
            assemblyIdentity, "Celeste", 33554827, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BeforeRenderHook", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BeforeRenderHook",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CameraLocker", "Celeste.CameraLocker", "CameraLocker",
            assemblyIdentity, "Celeste", 33554828, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CameraLocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CameraLocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CustomBloom", "Celeste.CustomBloom", "CustomBloom", assemblyIdentity,
            "Celeste", 33554829, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CustomBloom", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CustomBloom",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderHook", "Celeste.DisplacementRenderHook",
            "DisplacementRenderHook", assemblyIdentity, "Celeste", 33554830, false,
            new string[] { "Monocle.Component", "System.Object" }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderHook", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderHook",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurface", "Celeste.MirrorSurface", "MirrorSurface",
            assemblyIdentity, "Celeste", 33554831, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurface", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurface",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS05_Badeline", "Celeste.CS05_Badeline", "CS05_Badeline",
            assemblyIdentity, "Celeste", 33554832, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS05_Badeline", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Badeline",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS04_MirrorPortal", "Celeste.CS04_MirrorPortal", "CS04_MirrorPortal",
            assemblyIdentity, "Celeste", 33554833, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS04_MirrorPortal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS04_MirrorPortal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
