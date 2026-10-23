using Celeste.Core.Reflection;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        private static void RegisterPart1(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY", "FMOD.Studio.USER_PROPERTY", "USER_PROPERTY",
                assemblyIdentity, "Celeste", 33554634, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.USER_PROPERTY_INTERNAL", "FMOD.Studio.USER_PROPERTY_INTERNAL",
                "USER_PROPERTY_INTERNAL", assemblyIdentity, "Celeste", 33554635, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.USER_PROPERTY_INTERNAL", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.USER_PROPERTY_INTERNAL",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMAND_INFO_INTERNAL", "FMOD.Studio.COMMAND_INFO_INTERNAL",
                "COMMAND_INFO_INTERNAL", assemblyIdentity, "Celeste", 33554636, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMAND_INFO_INTERNAL", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMAND_INFO_INTERNAL",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.Union_IntBoolFloatString",
                "FMOD.Studio.Union_IntBoolFloatString",
                "Union_IntBoolFloatString", assemblyIdentity, "Celeste", 33554637, false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.Union_IntBoolFloatString", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Union_IntBoolFloatString",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.INITFLAGS", "FMOD.Studio.INITFLAGS", "INITFLAGS",
                assemblyIdentity, "Celeste", 33554638, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.INITFLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.INITFLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.LOAD_BANK_FLAGS", "FMOD.Studio.LOAD_BANK_FLAGS",
                "LOAD_BANK_FLAGS", assemblyIdentity, "Celeste", 33554639, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.LOAD_BANK_FLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.LOAD_BANK_FLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDCAPTURE_FLAGS", "FMOD.Studio.COMMANDCAPTURE_FLAGS",
                "COMMANDCAPTURE_FLAGS", assemblyIdentity, "Celeste", 33554640, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDCAPTURE_FLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDCAPTURE_FLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_FLAGS", "FMOD.Studio.COMMANDREPLAY_FLAGS",
                "COMMANDREPLAY_FLAGS", assemblyIdentity, "Celeste", 33554641, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_FLAGS", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_FLAGS",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PLAYBACK_STATE", "FMOD.Studio.PLAYBACK_STATE",
                "PLAYBACK_STATE",
                assemblyIdentity, "Celeste", 33554642, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PLAYBACK_STATE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PLAYBACK_STATE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_PROPERTY", "FMOD.Studio.EVENT_PROPERTY",
                "EVENT_PROPERTY",
                assemblyIdentity, "Celeste", 33554643, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_PROPERTY", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_PROPERTY",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES",
                "FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES", "PLUGIN_INSTANCE_PROPERTIES", assemblyIdentity, "Celeste",
                33554644, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.PLUGIN_INSTANCE_PROPERTIES",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_CALLBACK_TYPE", "FMOD.Studio.EVENT_CALLBACK_TYPE",
                "EVENT_CALLBACK_TYPE", assemblyIdentity, "Celeste", 33554645, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_CALLBACK_TYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_CALLBACK_TYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.EVENT_CALLBACK", "FMOD.Studio.EVENT_CALLBACK",
                "EVENT_CALLBACK",
                assemblyIdentity, "Celeste", 33554646, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.EVENT_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EVENT_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK",
                "FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK", "COMMANDREPLAY_FRAME_CALLBACK", assemblyIdentity, "Celeste",
                33554647, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
                "FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK", "COMMANDREPLAY_LOAD_BANK_CALLBACK", assemblyIdentity,
                "Celeste", 33554648, false, ["System.MulticastDelegate"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
                "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", "COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
                assemblyIdentity, "Celeste", 33554649, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.INSTANCETYPE", "FMOD.Studio.INSTANCETYPE", "INSTANCETYPE",
                assemblyIdentity, "Celeste", 33554650, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.INSTANCETYPE", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.INSTANCETYPE",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.COMMAND_INFO", "FMOD.Studio.COMMAND_INFO", "COMMAND_INFO",
                assemblyIdentity, "Celeste", 33554651, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.COMMAND_INFO", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.COMMAND_INFO",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.Util", "FMOD.Studio.Util", "Util", assemblyIdentity,
                "Celeste",
                33554652, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.Util", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Util",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.HandleBase", "FMOD.Studio.HandleBase", "HandleBase",
                assemblyIdentity, "Celeste", 33554653, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.HandleBase", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.HandleBase",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.System", "FMOD.Studio.System", "System", assemblyIdentity,
                "Celeste", 33554654, false, ["FMOD.Studio.HandleBase", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.System", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.System",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.EventDescription", "FMOD.Studio.EventDescription",
                "EventDescription", assemblyIdentity, "Celeste", 33554655, false,
                ["FMOD.Studio.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.EventDescription", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EventDescription",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.EventInstance", "FMOD.Studio.EventInstance", "EventInstance",
                assemblyIdentity, "Celeste", 33554656, false, ["FMOD.Studio.HandleBase", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.EventInstance", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.EventInstance",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.ParameterInstance", "FMOD.Studio.ParameterInstance",
                "ParameterInstance", assemblyIdentity, "Celeste", 33554657, false,
                ["FMOD.Studio.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.ParameterInstance", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.ParameterInstance",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.Bus", "FMOD.Studio.Bus", "Bus", assemblyIdentity, "Celeste",
                33554658, false, ["FMOD.Studio.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.Bus", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Bus",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.VCA", "FMOD.Studio.VCA", "VCA", assemblyIdentity, "Celeste",
                33554659, false, ["FMOD.Studio.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.VCA", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.VCA",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.Bank", "FMOD.Studio.Bank", "Bank", assemblyIdentity,
                "Celeste",
                33554660, false, ["FMOD.Studio.HandleBase", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.Bank", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.Bank",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.CommandReplay", "FMOD.Studio.CommandReplay", "CommandReplay",
                assemblyIdentity, "Celeste", 33554661, false, ["FMOD.Studio.HandleBase", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.CommandReplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.CommandReplay",
                []);
            catalog.RegisterLogicalTypeFacts("FMOD.Studio.MarshallingHelper", "FMOD.Studio.MarshallingHelper",
                "MarshallingHelper", assemblyIdentity, "Celeste", 33554662, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("FMOD.Studio.MarshallingHelper", 0, true);
            catalog.PublishDeclaredTrackedAliases("FMOD.Studio.MarshallingHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Binding", "Monocle.Binding", "Binding", assemblyIdentity,
                "Celeste",
                33554663, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Binding", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Binding",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleEmitter", "Monocle.ParticleEmitter", "ParticleEmitter",
                assemblyIdentity, "Celeste", 33554664, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleEmitter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleEmitter",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Circle", "Monocle.Circle", "Circle", assemblyIdentity, "Celeste",
                33554665, false, ["Monocle.Collider", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Circle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Circle",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PointSectors", "Monocle.PointSectors", "PointSectors",
                assemblyIdentity, "Celeste", 33554666, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PointSectors", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.PointSectors",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Collide", "Monocle.Collide", "Collide", assemblyIdentity,
                "Celeste",
                33554667, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Collide", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Collide",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Collider", "Monocle.Collider", "Collider", assemblyIdentity,
                "Celeste", 33554668, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Collider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Collider",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ColliderList", "Monocle.ColliderList", "ColliderList",
                assemblyIdentity, "Celeste", 33554669, false, ["Monocle.Collider", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ColliderList", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ColliderList",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Grid", "Monocle.Grid", "Grid", assemblyIdentity, "Celeste",
                33554670,
                false, ["Monocle.Collider", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Grid", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Grid",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Hitbox", "Monocle.Hitbox", "Hitbox", assemblyIdentity, "Celeste",
                33554671, false, ["Monocle.Collider", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Hitbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Hitbox",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Component", "Monocle.Component", "Component", assemblyIdentity,
                "Celeste", 33554672, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Component", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Component",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.GraphicsComponent", "Monocle.GraphicsComponent",
                "GraphicsComponent",
                assemblyIdentity, "Celeste", 33554673, true, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.GraphicsComponent", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.GraphicsComponent",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Image", "Monocle.Image", "Image", assemblyIdentity, "Celeste",
                33554674, false, ["Monocle.GraphicsComponent", "Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Image", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Image",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelText", "Monocle.PixelText", "PixelText", assemblyIdentity,
                "Celeste", 33554675, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelText",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Sprite", "Monocle.Sprite", "Sprite", assemblyIdentity, "Celeste",
                33554676, false,
                ["Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Sprite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Sprite",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Spritesheet`1", "Monocle.Spritesheet`1", "Spritesheet`1",
                assemblyIdentity, "Celeste", 33554677, false,
                ["Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Spritesheet`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Spritesheet`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.NumberText", "Monocle.NumberText", "NumberText", assemblyIdentity,
                "Celeste", 33554678, false,
                ["Monocle.GraphicsComponent", "Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.NumberText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.NumberText",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.OutlineText", "Monocle.OutlineText", "OutlineText",
                assemblyIdentity,
                "Celeste", 33554679, false,
                ["Monocle.Text", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.OutlineText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.OutlineText",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Text", "Monocle.Text", "Text", assemblyIdentity, "Celeste",
                33554680,
                false, ["Monocle.GraphicsComponent", "Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Text", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Text",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TimerText", "Monocle.TimerText", "TimerText", assemblyIdentity,
                "Celeste", 33554681, false,
                ["Monocle.GraphicsComponent", "Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TimerText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TimerText",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TileGrid", "Monocle.TileGrid", "TileGrid", assemblyIdentity,
                "Celeste", 33554682, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TileGrid", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TileGrid",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Alarm", "Monocle.Alarm", "Alarm", assemblyIdentity, "Celeste",
                33554683, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Alarm", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Alarm",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Coroutine", "Monocle.Coroutine", "Coroutine", assemblyIdentity,
                "Celeste", 33554684, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Coroutine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Coroutine",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.CoroutineHolder", "Monocle.CoroutineHolder", "CoroutineHolder",
                assemblyIdentity, "Celeste", 33554685, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.CoroutineHolder", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.CoroutineHolder",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.CounterSet`1", "Monocle.CounterSet`1", "CounterSet`1",
                assemblyIdentity, "Celeste", 33554686, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.CounterSet`1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.CounterSet`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Shaker", "Monocle.Shaker", "Shaker", assemblyIdentity, "Celeste",
                33554687, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Shaker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Shaker",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ShakerList", "Monocle.ShakerList", "ShakerList", assemblyIdentity,
                "Celeste", 33554688, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ShakerList", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ShakerList",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SineWave", "Monocle.SineWave", "SineWave", assemblyIdentity,
                "Celeste", 33554689, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SineWave", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.SineWave",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.StateMachine", "Monocle.StateMachine", "StateMachine",
                assemblyIdentity, "Celeste", 33554690, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.StateMachine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.StateMachine",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tween", "Monocle.Tween", "Tween", assemblyIdentity, "Celeste",
                33554691, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tween", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tween",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Wiggler", "Monocle.Wiggler", "Wiggler", assemblyIdentity,
                "Celeste",
                33554692, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Wiggler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Wiggler",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Engine", "Monocle.Engine", "Engine", assemblyIdentity, "Celeste",
                33554693, false, ["Microsoft.Xna.Framework.Game"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Engine", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Engine",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Entity",
                typeof(SceneEntityState).FullName, "Entity", assemblyIdentity, "Celeste",
                33554694, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts(typeof(SceneEntityState).FullName, 0, true);
            catalog.PublishDeclaredTrackedAliases(typeof(SceneEntityState).FullName,
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Atlas", "Monocle.Atlas", "Atlas", assemblyIdentity, "Celeste",
                33554695, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Atlas", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Atlas",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MTexture", "Monocle.MTexture", "MTexture", assemblyIdentity,
                "Celeste", 33554696, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MTexture", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.MTexture",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SpriteBank", "Monocle.SpriteBank", "SpriteBank", assemblyIdentity,
                "Celeste", 33554697, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SpriteBank", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SpriteBank",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SpriteDataSource", "Monocle.SpriteDataSource", "SpriteDataSource",
                assemblyIdentity, "Celeste", 33554698, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SpriteDataSource", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.SpriteDataSource",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SpriteData", "Monocle.SpriteData", "SpriteData", assemblyIdentity,
                "Celeste", 33554699, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SpriteData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SpriteData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tileset", "Monocle.Tileset", "Tileset", assemblyIdentity,
                "Celeste",
                33554700, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tileset", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tileset",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MInput", "Monocle.MInput", "MInput", assemblyIdentity, "Celeste",
                33554701, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MInput", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.MInput",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualButton", "Monocle.VirtualButton", "VirtualButton",
                assemblyIdentity, "Celeste", 33554702, false, ["Monocle.VirtualInput", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualButton", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualButton",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualInput", "Monocle.VirtualInput", "VirtualInput",
                assemblyIdentity, "Celeste", 33554703, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualInput", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInput",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualInputNode", "Monocle.VirtualInputNode", "VirtualInputNode",
                assemblyIdentity, "Celeste", 33554704, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualInputNode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualInputNode",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualIntegerAxis", "Monocle.VirtualIntegerAxis",
                "VirtualIntegerAxis", assemblyIdentity, "Celeste", 33554705, false,
                ["Monocle.VirtualInput", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualIntegerAxis", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualIntegerAxis",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualJoystick", "Monocle.VirtualJoystick", "VirtualJoystick",
                assemblyIdentity, "Celeste", 33554706, false, ["Monocle.VirtualInput", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualJoystick", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualJoystick",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ComponentList", "Monocle.ComponentList", "ComponentList",
                assemblyIdentity, "Celeste", 33554707, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ComponentList", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ComponentList",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.EntityList", "Monocle.EntityList", "EntityList", assemblyIdentity,
                "Celeste", 33554708, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.EntityList", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.EntityList",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.RendererList", "Monocle.RendererList", "RendererList",
                assemblyIdentity, "Celeste", 33554709, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.RendererList", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.RendererList",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TagLists", "Monocle.TagLists", "TagLists", assemblyIdentity,
                "Celeste", 33554710, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TagLists", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TagLists",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Particle", "Monocle.Particle", "Particle", assemblyIdentity,
                "Celeste", 33554711, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleSystem", "Monocle.ParticleSystem", "ParticleSystem",
                assemblyIdentity, "Celeste", 33554712, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleSystem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleSystem",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ParticleType", "Monocle.ParticleType", "ParticleType",
                assemblyIdentity, "Celeste", 33554713, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ParticleType", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.ParticleType",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.EverythingRenderer", "Monocle.EverythingRenderer",
                "EverythingRenderer", assemblyIdentity, "Celeste", 33554714, false,
                ["Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.EverythingRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.EverythingRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Renderer", "Monocle.Renderer", "Renderer", assemblyIdentity,
                "Celeste", 33554715, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Renderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Renderer",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SingleTagRenderer", "Monocle.SingleTagRenderer",
                "SingleTagRenderer",
                assemblyIdentity, "Celeste", 33554716, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SingleTagRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SingleTagRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.TagExcludeRenderer", "Monocle.TagExcludeRenderer",
                "TagExcludeRenderer", assemblyIdentity, "Celeste", 33554717, false,
                ["Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.TagExcludeRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.TagExcludeRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Scene", "Monocle.Scene", "Scene", assemblyIdentity, "Celeste",
                33554718, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Scene", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Scene",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.BitTag", "Monocle.BitTag", "BitTag", assemblyIdentity, "Celeste",
                33554719, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.BitTag", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.BitTag",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Cache", "Monocle.Cache", "Cache", assemblyIdentity, "Celeste",
                33554720, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Cache", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Cache",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Calc", "Monocle.Calc", "Calc", assemblyIdentity, "Celeste",
                33554721,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Calc", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Calc",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.QuaternionExt", "Monocle.QuaternionExt", "QuaternionExt",
                assemblyIdentity, "Celeste", 33554722, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.QuaternionExt", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.QuaternionExt",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Camera", "Monocle.Camera", "Camera", assemblyIdentity, "Celeste",
                33554723, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Camera", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Camera",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.CheatListener", "Monocle.CheatListener", "CheatListener",
                assemblyIdentity, "Celeste", 33554724, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.CheatListener", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.CheatListener",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ChoiceSet`1", "Monocle.ChoiceSet`1", "ChoiceSet`1",
                assemblyIdentity,
                "Celeste", 33554725, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ChoiceSet`1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.ChoiceSet`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Chooser`1", "Monocle.Chooser`1", "Chooser`1", assemblyIdentity,
                "Celeste", 33554726, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Chooser`1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Chooser`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Commands", "Monocle.Commands", "Commands", assemblyIdentity,
                "Celeste", 33554727, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Commands", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Commands",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Command", "Monocle.Command", "Command", assemblyIdentity,
                "Celeste",
                33554728, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Command", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Command",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Draw", "Monocle.Draw", "Draw", assemblyIdentity, "Celeste",
                33554729,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Draw", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Draw",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Ease", "Monocle.Ease", "Ease", assemblyIdentity, "Celeste",
                33554730,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Ease", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Ease",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.ErrorLog", "Monocle.ErrorLog", "ErrorLog", assemblyIdentity,
                "Celeste", 33554731, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.ErrorLog", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.ErrorLog",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.MethodHandle`1", "Monocle.MethodHandle`1", "MethodHandle`1",
                assemblyIdentity, "Celeste", 33554732, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.MethodHandle`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.MethodHandle`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelFontCharacter", "Monocle.PixelFontCharacter",
                "PixelFontCharacter", assemblyIdentity, "Celeste", 33554733, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelFontCharacter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontCharacter",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelFontSize", "Monocle.PixelFontSize", "PixelFontSize",
                assemblyIdentity, "Celeste", 33554734, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelFontSize", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelFontSize",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.PixelFont", "Monocle.PixelFont", "PixelFont", assemblyIdentity,
                "Celeste", 33554735, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.PixelFont", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.PixelFont",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Pnt", "Monocle.Pnt", "Pnt", assemblyIdentity, "Celeste", 33554736,
                false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Pnt", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Pnt",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Pooler", "Monocle.Pooler", "Pooler", assemblyIdentity, "Celeste",
                33554737, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Pooler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Pooler",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Pooled", "Monocle.Pooled", "Pooled", assemblyIdentity, "Celeste",
                33554738, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Pooled", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Pooled",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SaveLoad", "Monocle.SaveLoad", "SaveLoad", assemblyIdentity,
                "Celeste", 33554739, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SaveLoad", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SaveLoad",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SimpleCurve", "Monocle.SimpleCurve", "SimpleCurve",
                assemblyIdentity,
                "Celeste", 33554740, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SimpleCurve", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.SimpleCurve",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.SpecEntity`1", "Monocle.SpecEntity`1", "SpecEntity`1",
                assemblyIdentity, "Celeste", 33554741, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.SpecEntity`1", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.SpecEntity`1",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tiler", "Monocle.Tiler", "Tiler", assemblyIdentity, "Celeste",
                33554742, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tiler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tiler",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.AutotileData", "Monocle.AutotileData", "AutotileData",
                assemblyIdentity, "Celeste", 33554743, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.AutotileData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.AutotileData",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracker", "Monocle.Tracker", "Tracker", assemblyIdentity,
                "Celeste",
                33554744, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracker", 0, true);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracker",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.Tracked", "Monocle.Tracked", "Tracked", assemblyIdentity,
                "Celeste",
                33554745, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.Tracked", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.Tracked",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualAsset", "Monocle.VirtualAsset", "VirtualAsset",
                assemblyIdentity, "Celeste", 33554746, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualAsset", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualAsset",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualTexture", "Monocle.VirtualTexture", "VirtualTexture",
                assemblyIdentity, "Celeste", 33554747, false, ["Monocle.VirtualAsset", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualTexture", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualTexture",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualRenderTarget", "Monocle.VirtualRenderTarget",
                "VirtualRenderTarget", assemblyIdentity, "Celeste", 33554748, false,
                ["Monocle.VirtualAsset", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualRenderTarget", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualRenderTarget",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualContent", "Monocle.VirtualContent", "VirtualContent",
                assemblyIdentity, "Celeste", 33554749, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualContent", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualContent",
                []);
            catalog.RegisterLogicalTypeFacts("Monocle.VirtualMap`1", "Monocle.VirtualMap`1", "VirtualMap`1",
                assemblyIdentity, "Celeste", 33554750, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Monocle.VirtualMap`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Monocle.VirtualMap`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Language", "Celeste.Language", "Language", assemblyIdentity,
                "Celeste", 33554751, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Language", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Language",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisconnectedControllerUI", "Celeste.DisconnectedControllerUI",
                "DisconnectedControllerUI", assemblyIdentity, "Celeste", 33554752, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisconnectedControllerUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisconnectedControllerUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BounceBlock", "Celeste.BounceBlock", "BounceBlock",
                assemblyIdentity,
                "Celeste", 33554753, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BounceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BounceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlock", "Celeste.CassetteBlock", "CassetteBlock",
                assemblyIdentity, "Celeste", 33554754, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CassetteBlockManager", "Celeste.CassetteBlockManager",
                "CassetteBlockManager", assemblyIdentity, "Celeste", 33554755, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CassetteBlockManager", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CassetteBlockManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FloatySpaceBlock", "Celeste.FloatySpaceBlock", "FloatySpaceBlock",
                assemblyIdentity, "Celeste", 33554756, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FloatySpaceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FloatySpaceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Farewell", "Celeste.CS10_Farewell", "CS10_Farewell",
                assemblyIdentity, "Celeste", 33554757, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Farewell", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Farewell",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalLaunch", "Celeste.CS10_FinalLaunch", "CS10_FinalLaunch",
                assemblyIdentity, "Celeste", 33554758, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalLaunch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalLaunch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FinalRoom", "Celeste.CS10_FinalRoom", "CS10_FinalRoom",
                assemblyIdentity, "Celeste", 33554759, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FinalRoom", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FinalRoom",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarRotateSpinner", "Celeste.StarRotateSpinner",
                "StarRotateSpinner",
                assemblyIdentity, "Celeste", 33554760, false,
                [
                    "Celeste.RotateSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarRotateSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarRotateSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarTrackSpinner", "Celeste.StarTrackSpinner", "StarTrackSpinner",
                assemblyIdentity, "Celeste", 33554761, false,
                [
                    "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarTrackSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarTrackSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrumbleWallOnRumble", "Celeste.CrumbleWallOnRumble",
                "CrumbleWallOnRumble", assemblyIdentity, "Celeste", 33554762, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrumbleWallOnRumble", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrumbleWallOnRumble",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrushBlock", "Celeste.CrushBlock", "CrushBlock", assemblyIdentity,
                "Celeste", 33554763, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrushBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrushBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GlassBlock", "Celeste.GlassBlock", "GlassBlock", assemblyIdentity,
                "Celeste", 33554764, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GlassBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GlassBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GoldenBlock", "Celeste.GoldenBlock", "GoldenBlock",
                assemblyIdentity,
                "Celeste", 33554765, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GoldenBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GoldenBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IceBlock", "Celeste.IceBlock", "IceBlock", assemblyIdentity,
                "Celeste", 33554766, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IceBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IceBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightningBreakerBox", "Celeste.LightningBreakerBox",
                "LightningBreakerBox", assemblyIdentity, "Celeste", 33554767, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightningBreakerBox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightningBreakerBox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cassette", "Celeste.Cassette", "Cassette", assemblyIdentity,
                "Celeste", 33554768, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cassette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cassette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberryPoints", "Celeste.StrawberryPoints", "StrawberryPoints",
                assemblyIdentity, "Celeste", 33554769, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberryPoints", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberryPoints",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitGem", "Celeste.SummitGem", "SummitGem", assemblyIdentity,
                "Celeste", 33554770, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BadelineAutoAnimator", "Celeste.BadelineAutoAnimator",
                "BadelineAutoAnimator", assemblyIdentity, "Celeste", 33554771, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BadelineAutoAnimator", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BadelineAutoAnimator",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClimbBlocker", "Celeste.ClimbBlocker", "ClimbBlocker",
                assemblyIdentity, "Celeste", 33554772, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClimbBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClimbBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreModeListener", "Celeste.CoreModeListener", "CoreModeListener",
                assemblyIdentity, "Celeste", 33554773, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreModeListener", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreModeListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathEffect", "Celeste.DeathEffect", "DeathEffect",
                assemblyIdentity,
                "Celeste", 33554774, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrannyLaughSfx", "Celeste.GrannyLaughSfx", "GrannyLaughSfx",
                assemblyIdentity, "Celeste", 33554775, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrannyLaughSfx", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrannyLaughSfx",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LavaRect", "Celeste.LavaRect", "LavaRect", assemblyIdentity,
                "Celeste", 33554776, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LavaRect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LavaRect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEndingHook", "Celeste.LevelEndingHook", "LevelEndingHook",
                assemblyIdentity, "Celeste", 33554777, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEndingHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEndingHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PostUpdateHook", "Celeste.PostUpdateHook", "PostUpdateHook",
                assemblyIdentity, "Celeste", 33554778, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PostUpdateHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PostUpdateHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PufferCollider", "Celeste.PufferCollider", "PufferCollider",
                assemblyIdentity, "Celeste", 33554779, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PufferCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PufferCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerCollider", "Celeste.SeekerCollider", "SeekerCollider",
                assemblyIdentity, "Celeste", 33554780, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SolidOnInvinciblePlayer", "Celeste.SolidOnInvinciblePlayer",
                "SolidOnInvinciblePlayer", assemblyIdentity, "Celeste", 33554781, false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SolidOnInvinciblePlayer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SolidOnInvinciblePlayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaterInteraction", "Celeste.WaterInteraction", "WaterInteraction",
                assemblyIdentity, "Celeste", 33554782, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaterInteraction", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaterInteraction",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Ending", "Celeste.CS10_Ending", "CS10_Ending",
                assemblyIdentity,
                "Celeste", 33554783, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MissTheBird", "Celeste.CS10_MissTheBird", "CS10_MissTheBird",
                assemblyIdentity, "Celeste", 33554784, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MissTheBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MissTheBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_FreeBird", "Celeste.CS10_FreeBird", "CS10_FreeBird",
                assemblyIdentity, "Celeste", 33554785, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_FreeBird", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_FreeBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_Gravestone", "Celeste.CS10_Gravestone", "CS10_Gravestone",
                assemblyIdentity, "Celeste", 33554786, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_Gravestone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_Gravestone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Diary", "Celeste.CS03_Diary", "CS03_Diary", assemblyIdentity,
                "Celeste", 33554787, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Diary", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Diary",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Guestbook", "Celeste.CS03_Guestbook", "CS03_Guestbook",
                assemblyIdentity, "Celeste", 33554788, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Guestbook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Guestbook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Memo", "Celeste.CS03_Memo", "CS03_Memo", assemblyIdentity,
                "Celeste", 33554789, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Memo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Memo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoPhone", "Celeste.CS05_TheoPhone", "CS05_TheoPhone",
                assemblyIdentity, "Celeste", 33554790, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoPhone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoPhone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Credits", "Celeste.CS07_Credits", "CS07_Credits",
                assemblyIdentity, "Celeste", 33554791, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Credits", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Credits",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_Ending", "Celeste.CS08_Ending", "CS08_Ending",
                assemblyIdentity,
                "Celeste", 33554792, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_Ending", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_CatchTheBird", "Celeste.CS10_CatchTheBird",
                "CS10_CatchTheBird",
                assemblyIdentity, "Celeste", 33554793, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_CatchTheBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_CatchTheBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_HubIntro", "Celeste.CS10_HubIntro", "CS10_HubIntro",
                assemblyIdentity, "Celeste", 33554794, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_HubIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_HubIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_BadelineHelps", "Celeste.CS10_BadelineHelps",
                "CS10_BadelineHelps", assemblyIdentity, "Celeste", 33554795, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_BadelineHelps", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_BadelineHelps",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS10_MoonIntro", "Celeste.CS10_MoonIntro", "CS10_MoonIntro",
                assemblyIdentity, "Celeste", 33554796, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS10_MoonIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS10_MoonIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS08_EnterDoor", "Celeste.CS08_EnterDoor", "CS08_EnterDoor",
                assemblyIdentity, "Celeste", 33554797, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS08_EnterDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS08_EnterDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ending", "Celeste.CS07_Ending", "CS07_Ending",
                assemblyIdentity,
                "Celeste", 33554798, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Journal", "Celeste.CS02_Journal", "CS02_Journal",
                assemblyIdentity, "Celeste", 33554799, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Journal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Journal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Reflection1", "Celeste.CS05_Reflection1", "CS05_Reflection1",
                assemblyIdentity, "Celeste", 33554800, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Reflection1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Reflection1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_BossMid", "Celeste.CS06_BossMid", "CS06_BossMid",
                assemblyIdentity, "Celeste", 33554801, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_BossMid", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_BossMid",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_StarJumpEnd", "Celeste.CS06_StarJumpEnd", "CS06_StarJumpEnd",
                assemblyIdentity, "Celeste", 33554802, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_StarJumpEnd", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_StarJumpEnd",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS06_Reflection", "Celeste.CS06_Reflection", "CS06_Reflection",
                assemblyIdentity, "Celeste", 33554803, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS06_Reflection", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS06_Reflection",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS07_Ascend", "Celeste.CS07_Ascend", "CS07_Ascend",
                assemblyIdentity,
                "Celeste", 33554804, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS07_Ascend", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS07_Ascend",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CSGEN_StrawberrySeeds", "Celeste.CSGEN_StrawberrySeeds",
                "CSGEN_StrawberrySeeds", assemblyIdentity, "Celeste", 33554805, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CSGEN_StrawberrySeeds", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CSGEN_StrawberrySeeds",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FireBall", "Celeste.FireBall", "FireBall", assemblyIdentity,
                "Celeste", 33554806, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FireBall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FireBall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FireBarrier", "Celeste.FireBarrier", "FireBarrier",
                assemblyIdentity,
                "Celeste", 33554807, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FireBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FireBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Killbox", "Celeste.Killbox", "Killbox", assemblyIdentity,
                "Celeste",
                33554808, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Killbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Killbox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Lightning", "Celeste.Lightning", "Lightning", assemblyIdentity,
                "Celeste", 33554809, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Lightning", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Lightning",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RisingLava", "Celeste.RisingLava", "RisingLava", assemblyIdentity,
                "Celeste", 33554810, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RisingLava", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RisingLava",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SandwichLava", "Celeste.SandwichLava", "SandwichLava",
                assemblyIdentity, "Celeste", 33554811, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SandwichLava", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SandwichLava",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleBigEyeballShockwave", "Celeste.TempleBigEyeballShockwave",
                "TempleBigEyeballShockwave", assemblyIdentity, "Celeste", 33554812, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleBigEyeballShockwave", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleBigEyeballShockwave",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerDashAssist", "Celeste.PlayerDashAssist", "PlayerDashAssist",
                assemblyIdentity, "Celeste", 33554813, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerDashAssist", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDashAssist",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlaybackBillboard", "Celeste.PlaybackBillboard",
                "PlaybackBillboard",
                assemblyIdentity, "Celeste", 33554814, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlaybackBillboard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlaybackBillboard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PowerSourceNumber", "Celeste.PowerSourceNumber",
                "PowerSourceNumber",
                assemblyIdentity, "Celeste", 33554815, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PowerSourceNumber", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PowerSourceNumber",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdPath", "Celeste.BirdPath", "BirdPath", assemblyIdentity,
                "Celeste", 33554816, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdPath", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdPath",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CutsceneNode", "Celeste.CutsceneNode", "CutsceneNode",
                assemblyIdentity, "Celeste", 33554817, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CutsceneNode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CutsceneNode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FlingBirdIntro", "Celeste.FlingBirdIntro", "FlingBirdIntro",
                assemblyIdentity, "Celeste", 33554818, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FlingBirdIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FlingBirdIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC07X_Granny_Ending", "Celeste.NPC07X_Granny_Ending",
                "NPC07X_Granny_Ending", assemblyIdentity, "Celeste", 33554819, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC07X_Granny_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC07X_Granny_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC09_Granny_Inside", "Celeste.NPC09_Granny_Inside",
                "NPC09_Granny_Inside", assemblyIdentity, "Celeste", 33554820, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC09_Granny_Inside", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC09_Granny_Inside",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC10_Gravestone", "Celeste.NPC10_Gravestone", "NPC10_Gravestone",
                assemblyIdentity, "Celeste", 33554821, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC10_Gravestone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC10_Gravestone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC09_Granny_Outside", "Celeste.NPC09_Granny_Outside",
                "NPC09_Granny_Outside", assemblyIdentity, "Celeste", 33554822, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC09_Granny_Outside", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC09_Granny_Outside",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC08_Theo", "Celeste.NPC08_Theo", "NPC08_Theo", assemblyIdentity,
                "Celeste", 33554823, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC08_Theo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC08_Theo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC08_Granny", "Celeste.NPC08_Granny", "NPC08_Granny",
                assemblyIdentity, "Celeste", 33554824, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC08_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC08_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Bumper", "Celeste.Bumper", "Bumper", assemblyIdentity, "Celeste",
                33554825, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Bumper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Bumper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BadelineBoost", "Celeste.BadelineBoost", "BadelineBoost",
                assemblyIdentity, "Celeste", 33554826, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BadelineBoost", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BadelineBoost",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BeforeRenderHook", "Celeste.BeforeRenderHook", "BeforeRenderHook",
                assemblyIdentity, "Celeste", 33554827, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BeforeRenderHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BeforeRenderHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CameraLocker", "Celeste.CameraLocker", "CameraLocker",
                assemblyIdentity, "Celeste", 33554828, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CameraLocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CameraLocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CustomBloom", "Celeste.CustomBloom", "CustomBloom",
                assemblyIdentity,
                "Celeste", 33554829, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CustomBloom", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CustomBloom",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DisplacementRenderHook", "Celeste.DisplacementRenderHook",
                "DisplacementRenderHook", assemblyIdentity, "Celeste", 33554830, false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DisplacementRenderHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DisplacementRenderHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurface", "Celeste.MirrorSurface", "MirrorSurface",
                assemblyIdentity, "Celeste", 33554831, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurface", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurface",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Badeline", "Celeste.CS05_Badeline", "CS05_Badeline",
                assemblyIdentity, "Celeste", 33554832, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Badeline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Badeline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS04_MirrorPortal", "Celeste.CS04_MirrorPortal",
                "CS04_MirrorPortal",
                assemblyIdentity, "Celeste", 33554833, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS04_MirrorPortal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS04_MirrorPortal",
                []);
        }
    }
}
