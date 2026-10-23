using System;
using System.IO;
using System.Text;
using System.Linq;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Reflection;
using System.Collections.Generic;
using System.Reflection;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Core.Reflection.Compatibility;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Scripting.Lua;
using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Everest.Entities.Triggers.Events;
using Celeste.Everest.Content.Maps.Backdrops;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Menus.Overworld;
using Celeste.Game.Entities.Triggers.Events;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Overworld;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private IEverestAssemblyRegistriesEnvironment AssemblyRegistries =>
            (IEverestAssemblyRegistriesEnvironment)sourceEngine;

        public void ProcessAssembly(EverestModuleMetadata meta, Assembly asm,
            IEnumerable<SourceTypeDefinition> declaredSourceTypes)
        {
            if (declaredSourceTypes == null) throw new ArgumentNullException(nameof(declaredSourceTypes));
            var sourceDefinitions = declaredSourceTypes.ToArray();
            if (sourceDefinitions.Length == 0)
                throw new InvalidOperationException(
                    "Original assembly TypeDef facts must be published before assembly processing.");
            var sourceAssemblyIdentities = new HashSet<string>(StringComparer.Ordinal);
            foreach (var definition in sourceDefinitions)
            {
                if (sourceAssemblyIdentities.Add(definition.AssemblyIdentity))
                    ((IEverestLuaLoaderProcessEnvironment)sourceEngine).LuaLoader.PrecacheSourceAssembly(definition
                        .AssemblyIdentity);
            }

            ProcessRegistrations(meta, asm, sourceDefinitions.Select(definition =>
                new AssemblyRegistrationType(definition.Identity,
                    () => SourceRegistrationMembers.GetActualSourceType(definition.AssemblyIdentity,
                        definition.Identity),
                    () => IsSourceOui(definition),
                    (definition.Attributes & (int)TypeAttributes.Abstract) != 0,
                    definition.DeclaredAttributes.Any(attribute => IsRegistrationAttribute(attribute.TypeIdentity)),
                    identity => ReadSourceRegistrationAttributes(definition, identity))), null);
        }

        private void ProcessRegistrations(EverestModuleMetadata meta, Assembly asm,
            IEnumerable<AssemblyRegistrationType> registrationTypes, AssemblyRegistrationLease lease)
        {
            bool flag = false;
            foreach (AssemblyRegistrationType definition in registrationTypes)
            {
                bool hasRegistration =
                    definition.HasRegistration;
                bool needsUi = sourceEngine.Frame.Scenes.CurrentScene is EverestOverworldSequence &&
                               definition.IsOui() && !definition.IsAbstract;
                if (!hasRegistration && !needsUi) continue;
                Type type = definition.ResolveType();
                foreach (SourceRegistrationAttribute customAttribute in definition.ReadAttributes(
                             "Celeste.Mod.Entities.CustomEntityAttribute"))
                {
                    string[] iDs = customAttribute.IDs;
                    foreach (string text in iDs)
                    {
                        string[] array = text.Split('=');
                        string text2;
                        string text3;
                        if (array.Length == 1)
                        {
                            text2 = array[0];
                            text3 = "Load";
                        }
                        else
                        {
                            if (array.Length != 2)
                            {
                                string text4 = "core";
                                string tag = text4;
                                var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Warn);
                                if (sourceLog1.ShouldLog)
                                    sourceLog1.Write("Invalid number of custom entity ID elements: " + (text) + " (" +
                                                     (definition.Identity) + ")");
                                continue;
                            }

                            text2 = array[0];
                            text3 = array[1];
                        }

                        text2 = text2.Trim();
                        text3 = text3.Trim();
                        EverestLevelEntityLoadProcess.EntityLoader entityLoader = null;
                        ConstructorInfo ctor = null;
                        MethodInfo gen = type.GetMethod(text3, new Type[4]
                        {
                            typeof(OriginalLevelSceneRoot),
                            typeof(OriginalLevelRoomData),
                            typeof(Vector2),
                            typeof(OriginalLevelEntityData)
                        });
                        if (gen != null && gen.IsStatic && typeof(SceneEntityState).IsAssignableFrom(gen.ReturnType))
                        {
                            entityLoader = delegate(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
                                Vector2 offset, OriginalLevelEntityData entityData)
                            {
                                MapEntityId sourceId = level.CreateEntityId(levelData, entityData);
                                SceneEntityState entity = (SceneEntityState)gen.Invoke(null,
                                    new object[4] { level, levelData, offset, entityData });
                                if (entity != null)
                                {
                                    entity.SourceData = entityData;
                                    entity.SourceId = sourceId;
                                }

                                return entity;
                            };
                        }
                        else if (typeof(SceneEntityState).IsAssignableFrom(type) && TryQualifySourceEntityConstructor(
                                     type, out ctor, out var createArguments,
                                     out var sourceIdIsConstructorArgument))
                        {
                            entityLoader = delegate(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
                                Vector2 offset, OriginalLevelEntityData entityData)
                            {
                                MapEntityId entityID = sourceIdIsConstructorArgument
                                    ? level.CreateEntityId(levelData, entityData)
                                    : default;
                                SceneEntityState entity =
                                    (SceneEntityState)ctor.Invoke(createArguments(entityData, offset, entityID));
                                entity.SourceData = entityData;
                                entity.SourceId = sourceIdIsConstructorArgument
                                    ? entityID
                                    : level.CreateEntityId(levelData, entityData);
                                return entity;
                            };
                        }

                        if (entityLoader == null)
                        {
                            string text4 = "core";
                            string tag2 = text4;
                            var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Warn);
                            if (sourceLog2.ShouldLog)
                                sourceLog2.Write("Found custom entity without suitable constructor / " + (text3) +
                                                 "(Level, LevelData, Vector2, EntityData): " + (text2) + " (" +
                                                 (definition.Identity) + ")");
                        }
                        else
                        {
                            if (ctor != null)
                            {
                                if (lease == null)
                                    AssemblyRegistries.EntityRegistry.RegisterSidToTypeConnection(text2,
                                        ctor.DeclaringType);
                                else
                                    lease.Add(AssemblyRegistries.EntityRegistry.RegisterOwnedSidToTypeConnection(
                                        text2, ctor.DeclaringType));
                            }

                            if (lease == null) AssemblyRegistries.EntityLoaders.EntityLoaders[text2] = entityLoader;
                            else lease.Set(AssemblyRegistries.EntityLoaders.EntityLoaders, text2, entityLoader);
                        }
                    }
                }

                foreach (SourceRegistrationAttribute customAttribute2 in definition.ReadAttributes(
                             "Celeste.Mod.Entities.RegisterStrawberryAttribute"))
                {
                    List<string> list = new List<string>();
                    foreach (SourceRegistrationAttribute customAttribute3 in definition.ReadAttributes(
                                 "Celeste.Mod.Entities.CustomEntityAttribute"))
                    {
                        string[] iDs = customAttribute3.IDs;
                        foreach (string text5 in iDs)
                        {
                            string[] array2 = text5.Split('=');
                            if (array2.Length == 0)
                            {
                                string text4 = "core";
                                string tag3 = text4;
                                var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Warn);
                                if (sourceLog3.ShouldLog)
                                    sourceLog3.Write("Invalid number of custom entity ID elements: " + (text5) + " (" +
                                                     (definition.Identity) + ")");
                            }
                            else
                            {
                                list.Add(array2[0]);
                            }
                        }
                    }

                    if (list.Count == 0)
                    {
                        break;
                    }

                    foreach (string item in list)
                    {
                        if (lease == null)
                            AssemblyRegistries.StrawberryRegistry.Register(type, item, customAttribute2.isTracked,
                                customAttribute2.blocksNormalCollection);
                        else
                            lease.Add(AssemblyRegistries.StrawberryRegistry.RegisterOwned(type, item,
                                customAttribute2.isTracked, customAttribute2.blocksNormalCollection));
                        flag = true;
                    }
                }

                foreach (SourceRegistrationAttribute customAttribute4 in definition.ReadAttributes(
                             "Celeste.Mod.Entities.CustomEventAttribute"))
                {
                    string[] iDs = customAttribute4.IDs;
                    foreach (string text6 in iDs)
                    {
                        string[] array3 = text6.Split('=');
                        string text7;
                        string text8;
                        if (array3.Length == 1)
                        {
                            text7 = array3[0];
                            text8 = "Load";
                        }
                        else
                        {
                            if (array3.Length != 2)
                            {
                                string text4 = "core";
                                string tag4 = text4;
                                var sourceLog4 = Logger.BeginEnabledMessage(tag4, EverestLogLevel.Warn);
                                if (sourceLog4.ShouldLog)
                                    sourceLog4.Write("Invalid number of custom cutscene ID elements: " + (text6) +
                                                     " (" +
                                                     (definition.Identity) + ")");
                                continue;
                            }

                            text7 = array3[0];
                            text8 = array3[1];
                        }

                        text7 = text7.Trim();
                        text8 = text8.Trim();
                        EverestEventTriggerRuntimePolicy.CutsceneLoader cutsceneLoader = null;
                        MethodInfo gen2 = type.GetMethod(text8, new Type[3]
                        {
                            typeof(OriginalEventTriggerState),
                            typeof(RoomPlayerSession),
                            typeof(string)
                        });
                        if (gen2 != null && gen2.IsStatic && typeof(SceneEntityState).IsAssignableFrom(gen2.ReturnType))
                        {
                            cutsceneLoader =
                                (OriginalEventTriggerState trigger, RoomPlayerSession player, string eventID) =>
                                    (SceneEntityState)gen2.Invoke(null, new object[3] { trigger, player, eventID });
                        }
                        else
                        {
                            ConstructorInfo ctor2 = type.GetConstructor(new Type[4]
                            {
                                typeof(ISourceEngineContext), typeof(OriginalEventTriggerState),
                                typeof(RoomPlayerSession),
                                typeof(string)
                            });
                            if (ctor2 != null)
                            {
                                cutsceneLoader =
                                    (OriginalEventTriggerState trigger, RoomPlayerSession player, string eventID) =>
                                        (SceneEntityState)ctor2.Invoke(new object[4]
                                            { sourceEngine, trigger, player, eventID });
                            }
                            else
                            {
                                ctor2 = type.GetConstructor(new[] { typeof(ISourceEngineContext) });
                                if (ctor2 != null)
                                {
                                    cutsceneLoader =
                                        (OriginalEventTriggerState trigger, RoomPlayerSession player, string eventID) =>
                                            (SceneEntityState)ctor2.Invoke(new object[] { sourceEngine });
                                }
                            }
                        }

                        if (cutsceneLoader == null)
                        {
                            string text4 = "core";
                            string tag5 = text4;
                            var sourceLog5 = Logger.BeginEnabledMessage(tag5, EverestLogLevel.Warn);
                            if (sourceLog5.ShouldLog)
                                sourceLog5.Write("Found custom cutscene without suitable constructor / " + (text8) +
                                                 "(EventTrigger, Player, string): " + (text7) + " (" +
                                                 (definition.Identity) + ")");
                        }
                        else
                        {
                            if (lease == null) AssemblyRegistries.EventTriggers.CutsceneLoaders[text7] = cutsceneLoader;
                            else lease.Set(AssemblyRegistries.EventTriggers.CutsceneLoaders, text7, cutsceneLoader);
                        }
                    }
                }

                foreach (SourceRegistrationAttribute customAttribute5 in definition.ReadAttributes(
                             "Celeste.Mod.Backdrops.CustomBackdropAttribute"))
                {
                    string[] iDs = customAttribute5.IDs;
                    foreach (string text9 in iDs)
                    {
                        string[] array4 = text9.Split('=');
                        string text10;
                        string text11;
                        if (array4.Length == 1)
                        {
                            text10 = array4[0];
                            text11 = "Load";
                        }
                        else
                        {
                            if (array4.Length != 2)
                            {
                                string text4 = "core";
                                string tag6 = text4;
                                var sourceLog6 = Logger.BeginEnabledMessage(tag6, EverestLogLevel.Warn);
                                if (sourceLog6.ShouldLog)
                                    sourceLog6.Write("Invalid number of custom backdrop ID elements: " + (text9) +
                                                     " (" +
                                                     (definition.Identity) + ")");
                                continue;
                            }

                            text10 = array4[0];
                            text11 = array4[1];
                        }

                        text10 = text10.Trim();
                        text11 = text11.Trim();
                        EverestBackdropLoaders.BackdropLoader backdropLoader = null;
                        MethodInfo gen3 = type.GetMethod(text11, new Type[1] { typeof(BinaryPackerElement) });
                        if (gen3 != null && gen3.IsStatic &&
                            typeof(BackdropPresentation).IsAssignableFrom(gen3.ReturnType))
                        {
                            backdropLoader = (BinaryPackerElement data) =>
                                (BackdropPresentation)gen3.Invoke(null, new object[1] { data });
                        }
                        else
                        {
                            ConstructorInfo ctor3 = type.GetConstructor(new Type[2]
                                { typeof(ISourceEngineContext), typeof(BinaryPackerElement) });
                            if (ctor3 != null)
                            {
                                backdropLoader = (BinaryPackerElement data) =>
                                    (BackdropPresentation)ctor3.Invoke(new object[2] { sourceEngine, data });
                            }
                        }

                        if (backdropLoader == null)
                        {
                            string text4 = "core";
                            string tag7 = text4;
                            var sourceLog7 = Logger.BeginEnabledMessage(tag7, EverestLogLevel.Warn);
                            if (sourceLog7.ShouldLog)
                                sourceLog7.Write("Found custom backdrop without suitable constructor / " + (text11) +
                                                 "(OriginalBinaryPackerElement): " + (text10) + " (" +
                                                 (definition.Identity) + ")");
                        }
                        else
                        {
                            if (lease == null) AssemblyRegistries.Backdrops.BackdropLoaders[text10] = backdropLoader;
                            else lease.Set(AssemblyRegistries.Backdrops.BackdropLoaders, text10, backdropLoader);
                        }
                    }
                }

                foreach (SourceRegistrationAttribute customAttribute6 in definition.ReadAttributes(
                             "Celeste.Mod.Entities.CustomWipeAttribute"))
                {
                    string[] iDs = customAttribute6.IDs;
                    foreach (string text12 in iDs)
                    {
                        string[] array5 = text12.Split('=');
                        string text13;
                        string text14;
                        if (array5.Length == 1)
                        {
                            text13 = array5[0];
                            text14 = "Load";
                        }
                        else
                        {
                            if (array5.Length != 2)
                            {
                                string text4 = "core";
                                string tag8 = text4;
                                var sourceLog8 = Logger.BeginEnabledMessage(tag8, EverestLogLevel.Warn);
                                if (sourceLog8.ShouldLog)
                                    sourceLog8.Write("Invalid number of custom wipe ID elements: " + (text12) + " (" +
                                                     (definition.Identity) + ")");
                                continue;
                            }

                            text13 = array5[0];
                            text14 = array5[1];
                        }

                        text13 = text13.Trim();
                        text14 = text14.Trim();
                        Action<ISourceRendererScene, bool, Action> action = null;
                        MethodInfo gen4 = type.GetMethod(text14, new Type[3]
                        {
                            typeof(ISourceRendererScene),
                            typeof(bool),
                            typeof(Action)
                        });
                        if (gen4 != null && gen4.IsStatic &&
                            typeof(ScreenWipePresentation).IsAssignableFrom(gen4.ReturnType))
                        {
                            action = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                            {
                                gen4.Invoke(null, new object[3] { scene, wipeIn, onComplete });
                            };
                        }
                        else
                        {
                            ConstructorInfo ctor4 = type.GetConstructor(new Type[4]
                            {
                                typeof(ISourceEngineContext), typeof(ISourceRendererScene),
                                typeof(bool),
                                typeof(Action)
                            });
                            if (ctor4 != null)
                            {
                                action = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                                {
                                    ctor4.Invoke(new object[4] { sourceEngine, scene, wipeIn, onComplete });
                                };
                            }
                        }

                        if (action == null)
                        {
                            string text4 = "core";
                            string tag9 = text4;
                            var sourceLog9 = Logger.BeginEnabledMessage(tag9, EverestLogLevel.Warn);
                            if (sourceLog9.ShouldLog)
                                sourceLog9.Write("Found custom wipe without suitable constructor / " + (text14) +
                                                 "(Scene, bool, Action): " + (text13) + " (" + (definition.Identity) +
                                                 ")");
                        }
                        else
                        {
                            if (lease == null) AssemblyRegistries.Wipes.WipeLoaders[text13] = action;
                            else lease.Set(AssemblyRegistries.Wipes.WipeLoaders, text13, action);
                        }
                    }
                }

                if (sourceEngine.Frame.Scenes.CurrentScene is EverestOverworldSequence overworld && needsUi)
                {
                    string text4 = "core";
                    string tag10 = text4;
                    var sourceLog10 = Logger.BeginEnabledMessage(tag10, EverestLogLevel.Verbose);
                    if (sourceLog10.ShouldLog)
                        sourceLog10.Write("Instantiating UI from " + (meta) + ": " + (definition.Identity));
                    bool hadProperties = overworld.UIProperties != null &&
                                         overworld.UIProperties.TryGetValue(type, out var previousProperties);
                    var previousOuiProperties = hadProperties ? overworld.UIProperties[type] : null;
                    OuiState oui = overworld.RegisterOui(type);
                    var assignedProperties = overworld.UIProperties != null &&
                                             overworld.UIProperties.TryGetValue(type, out var properties)
                        ? properties
                        : null;
                    if (lease != null)
                        lease.Add(() =>
                        {
                            overworld.UIs.Remove(oui);
                            overworld.SourceScene.RemoveEntity(oui);
                            if (overworld.UIProperties == null ||
                                !overworld.UIProperties.TryGetValue(type, out var currentProperties) ||
                                !ReferenceEquals(currentProperties, assignedProperties)) return;
                            if (hadProperties) overworld.UIProperties[type] = previousOuiProperties;
                            else overworld.UIProperties.Remove(type);
                        });
                }
            }

            if (flag && ((IEverestStartupRuntimeEnvironment)sourceEngine).EverestRuntime.Initialized)
            {
                string text4 = "core";
                string tag11 = text4;
                var sourceLog11 = Logger.BeginEnabledMessage(tag11, EverestLogLevel.Verbose);
                if (sourceLog11.ShouldLog)
                    sourceLog11.Write("Assembly " + (asm.FullName) + " for module " + (meta) +
                                      " has custom strawberries: triggering map reload.");
                ModulesProcess.TriggerModInitMapReload();
            }
        }

        private SourceMemberCatalog SourceRegistrationMembers =>
            ((ISourceEverestReflectionEnvironment)sourceEngine).Reflection.SourceMembers;

        public void ProcessAssembly(EverestModuleMetadata meta, Assembly asm, Type[] types)
        {
            if (asm == null) throw new ArgumentNullException(nameof(asm));
            if (types == null) throw new ArgumentNullException(nameof(types));
            if (assemblyRegistrationLeases.ContainsKey(asm))
                throw new InvalidOperationException("The assembly already owns Everest registrations: " + asm.FullName);
            var lease = new AssemblyRegistrationLease();
            try
            {
                // Admit before module constructors/Load can install hooks. This first
                // lease is released last, after consumers have completed their teardown.
                lease.Add(modFrameOwnership.Register(meta, asm));
                lease.Add(
                    ((global::Celeste.Everest.Reflection.Runtime.ISourceRuntimeTypeDiscoveryEnvironment)sourceEngine)
                    .RegisterRuntimeAssemblyTypes(asm, types));
                ((IEverestLuaLoaderProcessEnvironment)sourceEngine).LuaLoader.Precache(asm);
                ProcessRegistrations(meta, asm, types.Select(CreateActualRegistrationType), lease);
                assemblyRegistrationLeases.Add(asm, lease);
            }
            catch
            {
                lease.Dispose();
                throw;
            }
        }

        private static bool IsRegistrationAttribute(string identity)
            => identity == "Celeste.Mod.Entities.CustomEntityAttribute"
               || identity == "Celeste.Mod.Entities.RegisterStrawberryAttribute"
               || identity == "Celeste.Mod.Entities.CustomEventAttribute"
               || identity == "Celeste.Mod.Backdrops.CustomBackdropAttribute"
               || identity == "Celeste.Mod.Entities.CustomWipeAttribute";

        private bool IsSourceOui(SourceTypeDefinition definition)
        {
            for (var current = definition; current != null;)
            {
                if (current.Identity == "Celeste.Oui") return true;
                if (current.BaseTypeIdentity == null) return false;
                current = SourceRegistrationMembers.GetOriginalTypeDefinition(current.BaseAssemblyIdentity,
                    current.BaseTypeIdentity);
            }

            return false;
        }

        private sealed class SourceRegistrationAttribute
        {
            public string[] IDs;
            public bool isTracked;
            public bool blocksNormalCollection;
        }

        public static IEnumerable<string> ReadSourceCustomEntityIds(SourceTypeDefinition definition)
            => ReadSourceRegistrationAttributes(definition, "Celeste.Mod.Entities.CustomEntityAttribute")
                .SelectMany(attribute => attribute.IDs);

        private static IEnumerable<SourceRegistrationAttribute> ReadSourceRegistrationAttributes(
            SourceTypeDefinition definition, string identity)
        {
            foreach (var attribute in definition.DeclaredAttributes)
            {
                if (attribute.TypeIdentity != identity) continue;
                using var stream = new MemoryStream(attribute.ValueBlob.ToArray(), false);
                using var reader = new BinaryReader(stream, Encoding.UTF8, false);
                if (reader.ReadUInt16() != 1)
                    throw new BadImageFormatException("Invalid source custom attribute prolog.");
                var result = new SourceRegistrationAttribute();
                if (identity == "Celeste.Mod.Entities.RegisterStrawberryAttribute")
                {
                    result.isTracked = reader.ReadBoolean();
                    result.blocksNormalCollection = reader.ReadBoolean();
                }
                else result.IDs = ReadSourceStringArray(reader);

                int named = reader.ReadUInt16();
                for (int i = 0; i < named; i++)
                {
                    byte memberKind = reader.ReadByte();
                    if (memberKind != 0x53 && memberKind != 0x54)
                        throw new BadImageFormatException("Invalid source attribute member kind.");
                    byte valueKind = reader.ReadByte();
                    byte arrayKind = valueKind == 0x1d ? reader.ReadByte() : (byte)0;
                    string name = ReadSourceSerializedString(reader);
                    if (name == "IDs" && valueKind == 0x1d && arrayKind == 0x0e)
                        result.IDs = ReadSourceStringArray(reader);
                    else if (name == "isTracked" && valueKind == 0x02) result.isTracked = reader.ReadBoolean();
                    else if (name == "blocksNormalCollection" && valueKind == 0x02)
                        result.blocksNormalCollection = reader.ReadBoolean();
                    else
                        throw new BadImageFormatException("Unsupported source registration attribute named argument: " +
                                                          name);
                }

                if (stream.Position != stream.Length)
                    throw new BadImageFormatException("Trailing source registration attribute bytes.");
                yield return result;
            }
        }

        private static string[] ReadSourceStringArray(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            if (count == -1) return null;
            if (count < 0) throw new BadImageFormatException("Invalid source attribute array length.");
            var values = new string[count];
            for (int i = 0; i < count; i++) values[i] = ReadSourceSerializedString(reader);
            return values;
        }

        private static string ReadSourceSerializedString(BinaryReader reader)
        {
            byte first = reader.ReadByte();
            if (first == 0xff) return null;
            int length;
            if ((first & 0x80) == 0) length = first;
            else if ((first & 0xc0) == 0x80) length = ((first & 0x3f) << 8) | reader.ReadByte();
            else if ((first & 0xe0) == 0xc0)
                length = ((first & 0x1f) << 24) | (reader.ReadByte() << 16) | (reader.ReadByte() << 8) |
                         reader.ReadByte();
            else throw new BadImageFormatException("Invalid source attribute compressed string length.");
            byte[] bytes = reader.ReadBytes(length);
            if (bytes.Length != length) throw new EndOfStreamException();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
