using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart14(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", "BloomDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557234, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.BloomDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                "CoreSwapDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557235, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.CoreSwapDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "DecalRegistryHandler",
                assemblyIdentity,
                "Celeste", 33557236, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", "DepthDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557237, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.DepthDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                "FlagSwapDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557238, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FlagSwapDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", "FloatyDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557239, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.FloatyDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", "LegacyDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557240, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler", 0,
                false);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LegacyDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", "LightDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557241, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                "LightOccludeDecalRegistryHandler", assemblyIdentity, "Celeste", 33557242, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.LightOccludeDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", "MirrorDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557243, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.MirrorDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler", "OverlayDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557244, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler",
                0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.OverlayDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                "ParallaxDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557245, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ParallaxDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler",
                "RandomizeFrameDecalRegistryHandler", assemblyIdentity, "Celeste", 33557246, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler", 0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.RandomizeFrameDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", "ScaleDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557247, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaleDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", "ScaredDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557248, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.ScaredDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", "SmokeDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557249, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SmokeDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", "SolidDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557250, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SolidDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", "SoundDecalRegistryHandler",
                assemblyIdentity, "Celeste", 33557251, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.SoundDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                "StaticMoverDecalRegistryHandler", assemblyIdentity, "Celeste", 33557252, false,
                ["Celeste.Mod.Registry.DecalRegistryHandlers.DecalRegistryHandler", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Registry.DecalRegistryHandlers.StaticMoverDecalRegistryHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.IMeta", "Celeste.Mod.Meta.IMeta", "IMeta",
                assemblyIdentity,
                "Celeste", 33557253, true, [], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.IMeta", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.IMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMeta", "Celeste.Mod.Meta.MapMeta", "MapMeta",
                assemblyIdentity, "Celeste", 33557254, false, ["System.Object", "Celeste.Mod.Meta.IMeta"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMeta", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMeta+<>c", "Celeste.Mod.Meta.MapMeta.<>c", "<>c",
                assemblyIdentity, "Celeste", 33557255, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMeta.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMeta.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMeta+<>c__DisplayClass131_0",
                "Celeste.Mod.Meta.MapMeta.<>c__DisplayClass131_0", "<>c__DisplayClass131_0", assemblyIdentity,
                "Celeste",
                33557256, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMeta.<>c__DisplayClass131_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMeta.<>c__DisplayClass131_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaModeProperties",
                "Celeste.Mod.Meta.MapMetaModeProperties", "MapMetaModeProperties", assemblyIdentity, "Celeste",
                33557257,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaModeProperties", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaModeProperties",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaModeProperties+<>c",
                "Celeste.Mod.Meta.MapMetaModeProperties.<>c", "<>c", assemblyIdentity, "Celeste", 33557258, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaModeProperties.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaModeProperties.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaAudioState", "Celeste.Mod.Meta.MapMetaAudioState",
                "MapMetaAudioState", assemblyIdentity, "Celeste", 33557259, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaAudioState", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaAudioState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCheckpointData",
                "Celeste.Mod.Meta.MapMetaCheckpointData", "MapMetaCheckpointData", assemblyIdentity, "Celeste",
                33557260,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCheckpointData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCheckpointData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCheckpointData+<>c",
                "Celeste.Mod.Meta.MapMetaCheckpointData.<>c", "<>c", assemblyIdentity, "Celeste", 33557261, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCheckpointData.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCheckpointData.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaMountain", "Celeste.Mod.Meta.MapMetaMountain",
                "MapMetaMountain", assemblyIdentity, "Celeste", 33557262, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaMountain", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaMountain",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaMountainCamera",
                "Celeste.Mod.Meta.MapMetaMountainCamera", "MapMetaMountainCamera", assemblyIdentity, "Celeste",
                33557263,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaMountainCamera", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaMountainCamera",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCompleteScreen",
                "Celeste.Mod.Meta.MapMetaCompleteScreen", "MapMetaCompleteScreen", assemblyIdentity, "Celeste",
                33557264,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCompleteScreen", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCompleteScreen",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCompleteScreenLayer",
                "Celeste.Mod.Meta.MapMetaCompleteScreenLayer", "MapMetaCompleteScreenLayer", assemblyIdentity,
                "Celeste",
                33557265, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCompleteScreenLayer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCompleteScreenLayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCompleteScreenTitle",
                "Celeste.Mod.Meta.MapMetaCompleteScreenTitle", "MapMetaCompleteScreenTitle", assemblyIdentity,
                "Celeste",
                33557266, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCompleteScreenTitle", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCompleteScreenTitle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaTextVignette",
                "Celeste.Mod.Meta.MapMetaTextVignette",
                "MapMetaTextVignette", assemblyIdentity, "Celeste", 33557267, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaTextVignette", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaTextVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaCassetteModifier",
                "Celeste.Mod.Meta.MapMetaCassetteModifier", "MapMetaCassetteModifier", assemblyIdentity, "Celeste",
                33557268, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaCassetteModifier", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaCassetteModifier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MapMetaPostcard", "Celeste.Mod.Meta.MapMetaPostcard",
                "MapMetaPostcard", assemblyIdentity, "Celeste", 33557269, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MapMetaPostcard", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MapMetaPostcard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.IMTextureMeta", "Celeste.Mod.Meta.IMTextureMeta",
                "IMTextureMeta", assemblyIdentity, "Celeste", 33557270, true, ["Celeste.Mod.Meta.IMeta"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.IMTextureMeta", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.IMTextureMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.MTextureMeta", "Celeste.Mod.Meta.MTextureMeta",
                "MTextureMeta", assemblyIdentity, "Celeste", 33557271, false,
                [
                    "System.Object", "Celeste.Mod.Meta.IMTextureMeta", "Celeste.Mod.Meta.IMeta",
                    "Celeste.Mod.Meta.ITextureMeta",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.MTextureMeta", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.MTextureMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.ITextureMeta", "Celeste.Mod.Meta.ITextureMeta",
                "ITextureMeta", assemblyIdentity, "Celeste", 33557272, true, ["Celeste.Mod.Meta.IMeta"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.ITextureMeta", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.ITextureMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Meta.TextureMeta", "Celeste.Mod.Meta.TextureMeta",
                "TextureMeta",
                assemblyIdentity, "Celeste", 33557273, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Meta.TextureMeta", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Meta.TextureMeta",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CacheHelper`2", "Celeste.Mod.Helpers.CacheHelper`2",
                "CacheHelper`2", assemblyIdentity, "Celeste", 33557274, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CacheHelper`2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CacheHelper`2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CacheHelper`2+ValueNode",
                "Celeste.Mod.Helpers.CacheHelper`2.ValueNode", "ValueNode", assemblyIdentity, "Celeste", 33557275,
                false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CacheHelper`2.ValueNode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CacheHelper`2.ValueNode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.Commands", "Celeste.Mod.Helpers.Commands", "Commands",
                assemblyIdentity, "Celeste", 33557276, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.Commands", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.Commands",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.Commands+WhatToSave",
                "Celeste.Mod.Helpers.Commands.WhatToSave", "WhatToSave", assemblyIdentity, "Celeste", 33557277, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.Commands.WhatToSave", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.Commands.WhatToSave",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.OverworldLoaderToSoundTest",
                "Celeste.Mod.Helpers.OverworldLoaderToSoundTest", "OverworldLoaderToSoundTest", assemblyIdentity,
                "Celeste",
                33557278, false,
                [
                    "Celeste.OverworldLoader", "Monocle.Scene", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.OverworldLoaderToSoundTest", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.OverworldLoaderToSoundTest",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CompressedHttpClient",
                "Celeste.Mod.Helpers.CompressedHttpClient", "CompressedHttpClient", assemblyIdentity, "Celeste",
                33557279,
                false, ["System.Net.Http.HttpClient"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CompressedHttpClient", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CompressedHttpClient",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CompressedHttpClient+<>c",
                "Celeste.Mod.Helpers.CompressedHttpClient.<>c", "<>c", assemblyIdentity, "Celeste", 33557280, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CompressedHttpClient.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CompressedHttpClient.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CompressedHttpClient+<>c+<<-cctor>b__2_0>d",
                "Celeste.Mod.Helpers.CompressedHttpClient.<>c.<<-cctor>b__2_0>d", "<<-cctor>b__2_0>d", assemblyIdentity,
                "Celeste", 33557281, false,
                ["System.ValueType", "System.Runtime.CompilerServices.IAsyncStateMachine"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CompressedHttpClient.<>c.<<-cctor>b__2_0>d", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CompressedHttpClient.<>c.<<-cctor>b__2_0>d",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.CullHelper", "Celeste.Mod.Helpers.CullHelper",
                "CullHelper", assemblyIdentity, "Celeste", 33557282, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.CullHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.CullHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.DirectoryProxy", "Celeste.Mod.Helpers.DirectoryProxy",
                "DirectoryProxy", assemblyIdentity, "Celeste", 33557283, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.DirectoryProxy", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.DirectoryProxy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.DirectoryProxy+<>c__DisplayClass0_0",
                "Celeste.Mod.Helpers.DirectoryProxy.<>c__DisplayClass0_0", "<>c__DisplayClass0_0", assemblyIdentity,
                "Celeste", 33557284, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.DirectoryProxy.<>c__DisplayClass0_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.DirectoryProxy.<>c__DisplayClass0_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.DisposeActionStream",
                "Celeste.Mod.Helpers.DisposeActionStream", "DisposeActionStream", assemblyIdentity, "Celeste", 33557285,
                false, ["System.IO.Stream"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.DisposeActionStream", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.DisposeActionStream",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.EverestContentManager",
                "Celeste.Mod.Helpers.EverestContentManager", "EverestContentManager", assemblyIdentity, "Celeste",
                33557286,
                false, ["Microsoft.Xna.Framework.Content.ContentManager"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.EverestContentManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.EverestContentManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.EverestBuild6580",
                "Celeste.Mod.Helpers.EverestBuild6580",
                "EverestBuild6580", assemblyIdentity, "Celeste", 33557287, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.EverestBuild6580", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.EverestBuild6580",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ExceptionExt", "Celeste.Mod.Helpers.ExceptionExt",
                "ExceptionExt", assemblyIdentity, "Celeste", 33557288, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ExceptionExt", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ExceptionExt",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ExceptionExt+<>c",
                "Celeste.Mod.Helpers.ExceptionExt.<>c",
                "<>c", assemblyIdentity, "Celeste", 33557289, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ExceptionExt.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ExceptionExt.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass0_0",
                "Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass0_0", "<>c__DisplayClass0_0", assemblyIdentity,
                "Celeste", 33557290, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass0_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass0_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ExceptionExt+<>c__DisplayClass1_0",
                "Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity,
                "Celeste", 33557291, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ExceptionExt.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.AutotilerException",
                "Celeste.Mod.Helpers.AutotilerException", "AutotilerException", assemblyIdentity, "Celeste", 33557292,
                false, ["System.Exception"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.AutotilerException", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.AutotilerException",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.EndUserException",
                "Celeste.Mod.Helpers.EndUserException",
                "EndUserException", assemblyIdentity, "Celeste", 33557293, false, ["System.Exception"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.EndUserException", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.EndUserException",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.FakeAssembly", "Celeste.Mod.Helpers.FakeAssembly",
                "FakeAssembly", assemblyIdentity, "Celeste", 33557294, false, ["System.Reflection.Assembly"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.FakeAssembly", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.FakeAssembly",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.FileProxyStream",
                "Celeste.Mod.Helpers.FileProxyStream",
                "FileProxyStream", assemblyIdentity, "Celeste", 33557295, false, ["System.IO.FileStream"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.FileProxyStream", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.FileProxyStream",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.FileProxy", "Celeste.Mod.Helpers.FileProxy",
                "FileProxy",
                assemblyIdentity, "Celeste", 33557296, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.FileProxy", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.FileProxy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.HookUtils", "Celeste.Mod.Helpers.HookUtils",
                "HookUtils",
                assemblyIdentity, "Celeste", 33557297, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.HookUtils", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.HookUtils",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.IConst`1", "Celeste.Mod.Helpers.IConst`1", "IConst`1",
                assemblyIdentity, "Celeste", 33557298, true, [], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.IConst`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.IConst`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ILCursorExtensions",
                "Celeste.Mod.Helpers.ILCursorExtensions", "ILCursorExtensions", assemblyIdentity, "Celeste", 33557299,
                true,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ILCursorExtensions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ILCursorExtensions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.InternHelper", "Celeste.Mod.Helpers.InternHelper",
                "InternHelper", assemblyIdentity, "Celeste", 33557300, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.InternHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.InternHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.InternHelper`1", "Celeste.Mod.Helpers.InternHelper`1",
                "InternHelper`1", assemblyIdentity, "Celeste", 33557301, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.InternHelper`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.InternHelper`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.InternHelper`1+<>c",
                "Celeste.Mod.Helpers.InternHelper`1.<>c", "<>c", assemblyIdentity, "Celeste", 33557302, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.InternHelper`1.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.InternHelper`1.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LoggedMonoModder",
                "Celeste.Mod.Helpers.LoggedMonoModder",
                "LoggedMonoModder", assemblyIdentity, "Celeste", 33557303, false, ["MonoMod.MonoModder"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LoggedMonoModder", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LoggedMonoModder",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LogRotationHelper",
                "Celeste.Mod.Helpers.LogRotationHelper", "LogRotationHelper", assemblyIdentity, "Celeste", 33557304,
                true,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LogRotationHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LogRotationHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LogRotationHelper+OldestFirst",
                "Celeste.Mod.Helpers.LogRotationHelper.OldestFirst", "OldestFirst", assemblyIdentity, "Celeste",
                33557305,
                false, ["System.Object", "System.Collections.Generic.IComparer`1<System.String>"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LogRotationHelper.OldestFirst", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LogRotationHelper.OldestFirst",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LogRotationHelper+<>c",
                "Celeste.Mod.Helpers.LogRotationHelper.<>c", "<>c", assemblyIdentity, "Celeste", 33557306, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LogRotationHelper.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LogRotationHelper.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LogWriter", "Celeste.Mod.Helpers.LogWriter",
                "LogWriter",
                assemblyIdentity, "Celeste", 33557307, false, ["System.Object", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LogWriter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LogWriter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.OutputStreamCapture",
                "Celeste.Mod.Helpers.OutputStreamCapture", "OutputStreamCapture", assemblyIdentity, "Celeste", 33557308,
                false, ["System.IO.TextWriter"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.OutputStreamCapture", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.OutputStreamCapture",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdateInfo", "Celeste.Mod.Helpers.ModUpdateInfo",
                "ModUpdateInfo", assemblyIdentity, "Celeste", 33557309, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdateInfo", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdateInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper",
                "Celeste.Mod.Helpers.ModUpdaterHelper",
                "ModUpdaterHelper", assemblyIdentity, "Celeste", 33557310, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper+MostRecentUpdatedFirst",
                "Celeste.Mod.Helpers.ModUpdaterHelper.MostRecentUpdatedFirst", "MostRecentUpdatedFirst",
                assemblyIdentity,
                "Celeste", 33557311, false,
                ["System.Object", "System.Collections.Generic.IComparer`1<Celeste.Mod.Helpers.ModUpdateInfo>"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper.MostRecentUpdatedFirst", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper.MostRecentUpdatedFirst",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper+DependencyGraphEntry",
                "Celeste.Mod.Helpers.ModUpdaterHelper.DependencyGraphEntry", "DependencyGraphEntry", assemblyIdentity,
                "Celeste", 33557312, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper.DependencyGraphEntry", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper.DependencyGraphEntry",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass11_0",
                "Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity,
                "Celeste", 33557313, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass11_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass11_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper+<>c__DisplayClass4_0",
                "Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass4_0", "<>c__DisplayClass4_0", assemblyIdentity,
                "Celeste", 33557314, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass4_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper.<>c__DisplayClass4_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ModUpdaterHelper+<getAllMirrorUrls>d__16",
                "Celeste.Mod.Helpers.ModUpdaterHelper.<getAllMirrorUrls>d__16", "<getAllMirrorUrls>d__16",
                assemblyIdentity,
                "Celeste", 33557315, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerable`1<System.String>",
                    "System.Collections.IEnumerable", "System.Collections.Generic.IEnumerator`1<System.String>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ModUpdaterHelper.<getAllMirrorUrls>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ModUpdaterHelper.<getAllMirrorUrls>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.ScopeFinalizer", "Celeste.Mod.Helpers.ScopeFinalizer",
                "ScopeFinalizer", assemblyIdentity, "Celeste", 33557316, false,
                ["System.Object", "System.IDisposable"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.ScopeFinalizer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.ScopeFinalizer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.SynchronizedZipEntryStream",
                "Celeste.Mod.Helpers.SynchronizedZipEntryStream", "SynchronizedZipEntryStream", assemblyIdentity,
                "Celeste",
                33557317, false, ["System.IO.Stream"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.SynchronizedZipEntryStream", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.SynchronizedZipEntryStream",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.UndisposableStream",
                "Celeste.Mod.Helpers.UndisposableStream", "UndisposableStream", assemblyIdentity, "Celeste", 33557318,
                false, ["System.IO.Stream"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.UndisposableStream", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.UndisposableStream",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.UnicodeStringHelper",
                "Celeste.Mod.Helpers.UnicodeStringHelper", "UnicodeStringHelper", assemblyIdentity, "Celeste", 33557319,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.UnicodeStringHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.UnicodeStringHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.UnicodeStringHelper+ListInt",
                "Celeste.Mod.Helpers.UnicodeStringHelper.ListInt", "ListInt", assemblyIdentity, "Celeste", 33557320,
                false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.UnicodeStringHelper.ListInt", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.UnicodeStringHelper.ListInt",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.UnicodeStringHelper+Cacher",
                "Celeste.Mod.Helpers.UnicodeStringHelper.Cacher", "Cacher", assemblyIdentity, "Celeste", 33557321,
                false,
                [
                    "Celeste.Mod.Helpers.CacheHelper`2<System.String,Celeste.Mod.Helpers.UnicodeStringHelper+ListInt>",
                    "System.Object",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.UnicodeStringHelper.Cacher", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.UnicodeStringHelper.Cacher",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.UnicodeStringHelper+Cacher+<>c",
                "Celeste.Mod.Helpers.UnicodeStringHelper.Cacher.<>c", "<>c", assemblyIdentity, "Celeste", 33557322,
                false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.UnicodeStringHelper.Cacher.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.UnicodeStringHelper.Cacher.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.URIHelper", "Celeste.Mod.Helpers.URIHelper",
                "URIHelper",
                assemblyIdentity, "Celeste", 33557323, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.URIHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.URIHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.URIHelper+<>c", "Celeste.Mod.Helpers.URIHelper.<>c",
                "<>c", assemblyIdentity, "Celeste", 33557324, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.URIHelper.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.URIHelper.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.URIHelper+<>c__DisplayClass3_0",
                "Celeste.Mod.Helpers.URIHelper.<>c__DisplayClass3_0", "<>c__DisplayClass3_0", assemblyIdentity,
                "Celeste",
                33557325, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.URIHelper.<>c__DisplayClass3_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.URIHelper.<>c__DisplayClass3_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.VanillaMouseBindings",
                "Celeste.Mod.Helpers.VanillaMouseBindings", "VanillaMouseBindings", assemblyIdentity, "Celeste",
                33557326,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.VanillaMouseBindings", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.VanillaMouseBindings",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.WorkerThreadTaskScheduler",
                "Celeste.Mod.Helpers.WorkerThreadTaskScheduler", "WorkerThreadTaskScheduler", assemblyIdentity,
                "Celeste",
                33557327, false, ["System.Threading.Tasks.TaskScheduler", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.WorkerThreadTaskScheduler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.WorkerThreadTaskScheduler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig", "LegacyDetourConfig", assemblyIdentity,
                "Celeste",
                33557328, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourConfig",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour", "LegacyDetour", assemblyIdentity, "Celeste", 33557329,
                false,
                [
                    "System.Object", "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour`1",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour`1", "LegacyDetour`1", assemblyIdentity, "Celeste",
                33557330,
                false,
                [
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour", "System.Object",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetour`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", "LegacyDetourContext", assemblyIdentity,
                "Celeste",
                33557331, false, ["System.Object", "System.IDisposable"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+ReorgContext",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.ReorgContext", "ReorgContext", assemblyIdentity,
                "Celeste", 33557332, false, ["MonoMod.RuntimeDetour.DetourContext"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.ReorgContext", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.ReorgContext",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c", "<>c", assemblyIdentity, "Celeste",
                33557333,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext+<>c__DisplayClass28_0",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c__DisplayClass28_0", "<>c__DisplayClass28_0",
                assemblyIdentity, "Celeste", 33557334, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c__DisplayClass28_0",
                0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourContext.<>c__DisplayClass28_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", "LegacyDetourHelper", assemblyIdentity,
                "Celeste",
                33557335, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker", "MethodPinTracker",
                assemblyIdentity, "Celeste", 33557336, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker", 0,
                false);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper+MethodPinTracker+<>c",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker.<>c", "<>c", assemblyIdentity,
                "Celeste", 33557337, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker.<>c", 0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDetourHelper.MethodPinTracker.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", "LegacyDynamicDataCompatHooks",
                assemblyIdentity, "Celeste", 33557338, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c", "<>c", assemblyIdentity,
                "Celeste",
                33557339, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c", 0,
                true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_0",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_0",
                "<>c__DisplayClass5_0", assemblyIdentity, "Celeste", 33557340, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_0", 0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_0",
                []);
            catalog.RegisterLogicalTypeFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks+<>c__DisplayClass5_1",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_1",
                "<>c__DisplayClass5_1", assemblyIdentity, "Celeste", 33557341, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_1", 0, true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks.<>c__DisplayClass5_1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", "LegacyFastReflectionDelegate",
                assemblyIdentity, "Celeste", 33557342, false, ["System.MulticastDelegate"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionDelegate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", "LegacyFastReflectionHelper",
                assemblyIdentity, "Celeste", 33557343, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyFastReflectionHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", "LegacyHookConfig", assemblyIdentity, "Celeste",
                33557344, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookConfig",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", "LegacyHook", assemblyIdentity, "Celeste", 33557345,
                false,
                ["System.Object", "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", "LegacyHook`1", assemblyIdentity, "Celeste", 33557346,
                false,
                [
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", "System.Object",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", "LegacyHook`2", assemblyIdentity, "Celeste", 33557347,
                false,
                [
                    "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook", "System.Object",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHook`2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", "LegacyHookEndpointManager",
                assemblyIdentity, "Celeste", 33557348, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager+<>c",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager.<>c", "<>c", assemblyIdentity, "Celeste",
                33557349, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager.<>c", 0,
                true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyHookEndpointManager.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "ILegacyDetour", assemblyIdentity, "Celeste",
                33557350,
                true, ["System.IDisposable"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", "ILegacySortableDetour", assemblyIdentity,
                "Celeste", 33557351, true,
                ["Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", "LegacyILHookConfig", assemblyIdentity,
                "Celeste",
                33557352, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHookConfig",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", "LegacyILHook", assemblyIdentity, "Celeste", 33557353,
                false,
                [
                    "System.Object", "Celeste.Mod.Helpers.LegacyMonoMod.ILegacySortableDetour",
                    "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyILHook",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.RelinkedMonoModLegacyAttribute",
                "Celeste.Mod.Helpers.LegacyMonoMod.RelinkedMonoModLegacyAttribute", "RelinkedMonoModLegacyAttribute",
                assemblyIdentity, "Celeste", 33557354, false, ["System.Attribute"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.RelinkedMonoModLegacyAttribute", 0,
                true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.RelinkedMonoModLegacyAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyMonoModCompatLayer",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyMonoModCompatLayer", "LegacyMonoModCompatLayer",
                assemblyIdentity,
                "Celeste", 33557355, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyMonoModCompatLayer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyMonoModCompatLayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILShims",
                "Celeste.Mod.Helpers.LegacyMonoMod.ILShims", "ILShims", assemblyIdentity, "Celeste", 33557356, true,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.ILShims", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.ILShims",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper", "LegacyPlatformHelper", assemblyIdentity,
                "Celeste", 33557357, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper+Platform",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper.Platform", "Platform", assemblyIdentity,
                "Celeste",
                33557358, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper.Platform", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyPlatformHelper.Platform",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice",
                "Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice", "MonoModPolice", assemblyIdentity, "Celeste",
                33557359,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice+MonoModCrimeException",
                "Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice.MonoModCrimeException", "MonoModCrimeException",
                assemblyIdentity, "Celeste", 33557360, false, ["System.Exception"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice.MonoModCrimeException", 0,
                false);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice.MonoModCrimeException",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourConfig",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourConfig", "LegacyNativeDetourConfig",
                assemblyIdentity,
                "Celeste", 33557361, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourConfig", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourConfig",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetour",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetour", "LegacyNativeDetour", assemblyIdentity,
                "Celeste",
                33557362, false,
                ["System.Object", "Celeste.Mod.Helpers.LegacyMonoMod.ILegacyDetour", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetour", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetour",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourData",
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourData", "LegacyNativeDetourData", assemblyIdentity,
                "Celeste", 33557363, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Helpers.LegacyMonoMod.LegacyNativeDetourData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.ActivateDreamBlocksTrigger",
                "Celeste.Mod.Entities.ActivateDreamBlocksTrigger", "ActivateDreamBlocksTrigger", assemblyIdentity,
                "Celeste", 33557364, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.ActivateDreamBlocksTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.ActivateDreamBlocksTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.AmbienceTrigger",
                "Celeste.Mod.Entities.AmbienceTrigger",
                "AmbienceTrigger", assemblyIdentity, "Celeste", 33557365, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.AmbienceTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.AmbienceTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.AmbienceVolumeTrigger",
                "Celeste.Mod.Entities.AmbienceVolumeTrigger", "AmbienceVolumeTrigger", assemblyIdentity, "Celeste",
                33557366, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.AmbienceVolumeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.AmbienceVolumeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.BadelineOldsiteEnd",
                "Celeste.Mod.Entities.BadelineOldsiteEnd", "BadelineOldsiteEnd", assemblyIdentity, "Celeste", 33557367,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.BadelineOldsiteEnd", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.BadelineOldsiteEnd",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CassetteListener",
                "Celeste.Mod.Entities.CassetteListener", "CassetteListener", assemblyIdentity, "Celeste", 33557368,
                false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CassetteListener", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CassetteListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CassetteListener+Modes",
                "Celeste.Mod.Entities.CassetteListener.Modes", "Modes", assemblyIdentity, "Celeste", 33557369, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CassetteListener.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CassetteListener.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CassetteListener+<>c",
                "Celeste.Mod.Entities.CassetteListener.<>c", "<>c", assemblyIdentity, "Celeste", 33557370, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CassetteListener.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CassetteListener.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.ChangeInventoryTrigger",
                "Celeste.Mod.Entities.ChangeInventoryTrigger", "ChangeInventoryTrigger", assemblyIdentity, "Celeste",
                33557371, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.ChangeInventoryTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.ChangeInventoryTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CompleteAreaTrigger",
                "Celeste.Mod.Entities.CompleteAreaTrigger", "CompleteAreaTrigger", assemblyIdentity, "Celeste",
                33557372,
                false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CompleteAreaTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CompleteAreaTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CoreModeTrigger",
                "Celeste.Mod.Entities.CoreModeTrigger",
                "CoreModeTrigger", assemblyIdentity, "Celeste", 33557373, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CoreModeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CoreModeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CoreModeTrigger+Modes",
                "Celeste.Mod.Entities.CoreModeTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33557374, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CoreModeTrigger.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CoreModeTrigger.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CrystalShatterTrigger",
                "Celeste.Mod.Entities.CrystalShatterTrigger", "CrystalShatterTrigger", assemblyIdentity, "Celeste",
                33557375, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CrystalShatterTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CrystalShatterTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CrystalShatterTrigger+Modes",
                "Celeste.Mod.Entities.CrystalShatterTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33557376,
                false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CrystalShatterTrigger.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CrystalShatterTrigger.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CrystalShatterTrigger+ModesLegacy",
                "Celeste.Mod.Entities.CrystalShatterTrigger.ModesLegacy", "ModesLegacy", assemblyIdentity, "Celeste",
                33557377, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CrystalShatterTrigger.ModesLegacy", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CrystalShatterTrigger.ModesLegacy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds",
                "Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds", "CSGEN_GenericStrawberrySeeds", assemblyIdentity,
                "Celeste", 33557378, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds+<>c__DisplayClass8_0",
                "Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<>c__DisplayClass8_0", "<>c__DisplayClass8_0",
                assemblyIdentity, "Celeste", 33557379, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<>c__DisplayClass8_0",
                0,
                true);
            catalog.PublishDeclaredTrackedAliases(
                "Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<>c__DisplayClass8_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds+<Cutscene>d__7",
                "Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<Cutscene>d__7", "<Cutscene>d__7", assemblyIdentity,
                "Celeste", 33557380, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<Cutscene>d__7", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds.<Cutscene>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomBirdTutorial",
                "Celeste.Mod.Entities.CustomBirdTutorial", "CustomBirdTutorial", assemblyIdentity, "Celeste", 33557381,
                false,
                [
                    "Celeste.BirdNPC", "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomBirdTutorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomBirdTutorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomBirdTutorial+<>c__DisplayClass11_0",
                "Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass11_0", "<>c__DisplayClass11_0",
                assemblyIdentity,
                "Celeste", 33557382, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass11_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass11_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomBirdTutorial+<>c__DisplayClass7_0",
                "Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass7_0", "<>c__DisplayClass7_0",
                assemblyIdentity,
                "Celeste", 33557383, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass7_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomBirdTutorial.<>c__DisplayClass7_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomBirdTutorialTrigger",
                "Celeste.Mod.Entities.CustomBirdTutorialTrigger", "CustomBirdTutorialTrigger", assemblyIdentity,
                "Celeste",
                33557384, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomBirdTutorialTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomBirdTutorialTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomCoreMessage",
                "Celeste.Mod.Entities.CustomCoreMessage", "CustomCoreMessage", assemblyIdentity, "Celeste", 33557385,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomCoreMessage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomCoreMessage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomEntityAttribute",
                "Celeste.Mod.Entities.CustomEntityAttribute", "CustomEntityAttribute", assemblyIdentity, "Celeste",
                33557386, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomEntityAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomEntityAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomEventAttribute",
                "Celeste.Mod.Entities.CustomEventAttribute", "CustomEventAttribute", assemblyIdentity, "Celeste",
                33557387,
                false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomEventAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomEventAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomHeightDisplay",
                "Celeste.Mod.Entities.CustomHeightDisplay", "CustomHeightDisplay", assemblyIdentity, "Celeste",
                33557388,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomHeightDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomHeightDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomHeightDisplay+<CameraUp>d__28",
                "Celeste.Mod.Entities.CustomHeightDisplay.<CameraUp>d__28", "<CameraUp>d__28", assemblyIdentity,
                "Celeste",
                33557389, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomHeightDisplay.<CameraUp>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomHeightDisplay.<CameraUp>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomHeightDisplay+<Routine>d__27",
                "Celeste.Mod.Entities.CustomHeightDisplay.<Routine>d__27", "<Routine>d__27", assemblyIdentity,
                "Celeste",
                33557390, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomHeightDisplay.<Routine>d__27", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomHeightDisplay.<Routine>d__27",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomHeightDisplayTrigger",
                "Celeste.Mod.Entities.CustomHeightDisplayTrigger", "CustomHeightDisplayTrigger", assemblyIdentity,
                "Celeste", 33557391, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomHeightDisplayTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomHeightDisplayTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomMemorial",
                "Celeste.Mod.Entities.CustomMemorial",
                "CustomMemorial", assemblyIdentity, "Celeste", 33557392, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomMemorial", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomMemorial",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomMemorialText",
                "Celeste.Mod.Entities.CustomMemorialText", "CustomMemorialText", assemblyIdentity, "Celeste", 33557393,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomMemorialText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomMemorialText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomNPC", "Celeste.Mod.Entities.CustomNPC",
                "CustomNPC", assemblyIdentity, "Celeste", 33557394, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomNPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomNPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomNPC+<Talk>d__28",
                "Celeste.Mod.Entities.CustomNPC.<Talk>d__28", "<Talk>d__28", assemblyIdentity, "Celeste", 33557395,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomNPC.<Talk>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomNPC.<Talk>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomScreenVignette",
                "Celeste.Mod.Entities.CustomScreenVignette", "CustomScreenVignette", assemblyIdentity, "Celeste",
                33557396,
                false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomScreenVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomScreenVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomTextVignette",
                "Celeste.Mod.Entities.CustomTextVignette", "CustomTextVignette", assemblyIdentity, "Celeste", 33557397,
                false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomTextVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomTextVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomTextVignette+<>c__DisplayClass25_0",
                "Celeste.Mod.Entities.CustomTextVignette.<>c__DisplayClass25_0", "<>c__DisplayClass25_0",
                assemblyIdentity,
                "Celeste", 33557398, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomTextVignette.<>c__DisplayClass25_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomTextVignette.<>c__DisplayClass25_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomTextVignette+<TextSequence>d__20",
                "Celeste.Mod.Entities.CustomTextVignette.<TextSequence>d__20", "<TextSequence>d__20", assemblyIdentity,
                "Celeste", 33557399, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomTextVignette.<TextSequence>d__20", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomTextVignette.<TextSequence>d__20",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.CustomWipeAttribute",
                "Celeste.Mod.Entities.CustomWipeAttribute", "CustomWipeAttribute", assemblyIdentity, "Celeste",
                33557400,
                false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.CustomWipeAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.CustomWipeAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.DialogCutscene",
                "Celeste.Mod.Entities.DialogCutscene",
                "DialogCutscene", assemblyIdentity, "Celeste", 33557401, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.DialogCutscene", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.DialogCutscene",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.DialogCutscene+<Cutscene>d__5",
                "Celeste.Mod.Entities.DialogCutscene.<Cutscene>d__5", "<Cutscene>d__5", assemblyIdentity, "Celeste",
                33557402, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.DialogCutscene.<Cutscene>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.DialogCutscene.<Cutscene>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.DialogCutsceneTrigger",
                "Celeste.Mod.Entities.DialogCutsceneTrigger", "DialogCutsceneTrigger", assemblyIdentity, "Celeste",
                33557403, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.DialogCutsceneTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.DialogCutsceneTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.EntityCollider`1",
                "Celeste.Mod.Entities.EntityCollider`1", "EntityCollider`1", assemblyIdentity, "Celeste", 33557404,
                false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.EntityCollider`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.EntityCollider`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.EntityColliderByComponent`1",
                "Celeste.Mod.Entities.EntityColliderByComponent`1", "EntityColliderByComponent`1", assemblyIdentity,
                "Celeste", 33557405, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.EntityColliderByComponent`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.EntityColliderByComponent`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.EntityRemovedListener",
                "Celeste.Mod.Entities.EntityRemovedListener", "EntityRemovedListener", assemblyIdentity, "Celeste",
                33557406, false, ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.EntityRemovedListener", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.EntityRemovedListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.EntityTrigger", "Celeste.Mod.Entities.EntityTrigger",
                "EntityTrigger", assemblyIdentity, "Celeste", 33557407, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.EntityTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.EntityTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.EntityTriggerListener",
                "Celeste.Mod.Entities.EntityTriggerListener", "EntityTriggerListener", assemblyIdentity, "Celeste",
                33557408, false, ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.EntityTriggerListener", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.EntityTriggerListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.FlagTrigger", "Celeste.Mod.Entities.FlagTrigger",
                "FlagTrigger", assemblyIdentity, "Celeste", 33557409, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.FlagTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.FlagTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.FlagTrigger+Modes",
                "Celeste.Mod.Entities.FlagTrigger.Modes", "Modes", assemblyIdentity, "Celeste", 33557410, false,
                ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.FlagTrigger.Modes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.FlagTrigger.Modes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.GenericStrawberrySeed",
                "Celeste.Mod.Entities.GenericStrawberrySeed", "GenericStrawberrySeed", assemblyIdentity, "Celeste",
                33557411, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.GenericStrawberrySeed", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.GenericStrawberrySeed",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.GenericStrawberrySeed+<>c__DisplayClass32_0",
                "Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass32_0", "<>c__DisplayClass32_0",
                assemblyIdentity, "Celeste", 33557412, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass32_0", 0,
                true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass32_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.GenericStrawberrySeed+<>c__DisplayClass33_0",
                "Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass33_0", "<>c__DisplayClass33_0",
                assemblyIdentity, "Celeste", 33557413, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass33_0", 0,
                true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.GenericStrawberrySeed.<>c__DisplayClass33_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.GenericStrawberrySeed+<ReturnRoutine>d__30",
                "Celeste.Mod.Entities.GenericStrawberrySeed.<ReturnRoutine>d__30", "<ReturnRoutine>d__30",
                assemblyIdentity,
                "Celeste", 33557414, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.GenericStrawberrySeed.<ReturnRoutine>d__30", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.GenericStrawberrySeed.<ReturnRoutine>d__30",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.LavaBlockerTrigger",
                "Celeste.Mod.Entities.LavaBlockerTrigger", "LavaBlockerTrigger", assemblyIdentity, "Celeste", 33557415,
                false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.LavaBlockerTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.LavaBlockerTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.LavaBlockerTrigger+<>c",
                "Celeste.Mod.Entities.LavaBlockerTrigger.<>c", "<>c", assemblyIdentity, "Celeste", 33557416, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.LavaBlockerTrigger.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.LavaBlockerTrigger.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.MusicLayerTrigger",
                "Celeste.Mod.Entities.MusicLayerTrigger", "MusicLayerTrigger", assemblyIdentity, "Celeste", 33557417,
                false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.MusicLayerTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.MusicLayerTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.RegisterStrawberryAttribute",
                "Celeste.Mod.Entities.RegisterStrawberryAttribute", "RegisterStrawberryAttribute", assemblyIdentity,
                "Celeste", 33557418, false, ["System.Attribute"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.RegisterStrawberryAttribute", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.RegisterStrawberryAttribute",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.SceneRenderer", "Celeste.Mod.Entities.SceneRenderer",
                "SceneRenderer", assemblyIdentity, "Celeste", 33557419, false,
                ["Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.SceneRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.SceneRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.SceneWrappingEntity",
                "Celeste.Mod.Entities.SceneWrappingEntity", "SceneWrappingEntity", assemblyIdentity, "Celeste",
                33557420,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.SceneWrappingEntity", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.SceneWrappingEntity",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.SceneWrappingEntity`1",
                "Celeste.Mod.Entities.SceneWrappingEntity`1", "SceneWrappingEntity`1", assemblyIdentity, "Celeste",
                33557421, false,
                [
                    "Celeste.Mod.Entities.SceneWrappingEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.SceneWrappingEntity`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.SceneWrappingEntity`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.SmoothCameraOffsetTrigger",
                "Celeste.Mod.Entities.SmoothCameraOffsetTrigger", "SmoothCameraOffsetTrigger", assemblyIdentity,
                "Celeste",
                33557422, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.SmoothCameraOffsetTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.SmoothCameraOffsetTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.SpaceControllerBlocker",
                "Celeste.Mod.Entities.SpaceControllerBlocker", "SpaceControllerBlocker", assemblyIdentity, "Celeste",
                33557423, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.SpaceControllerBlocker", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.SpaceControllerBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.StarClimbGraphicsController",
                "Celeste.Mod.Entities.StarClimbGraphicsController", "StarClimbGraphicsController", assemblyIdentity,
                "Celeste", 33557424, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.StarClimbGraphicsController", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.StarClimbGraphicsController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.StarClimbGraphicsController+Ray",
                "Celeste.Mod.Entities.StarClimbGraphicsController.Ray", "Ray", assemblyIdentity, "Celeste", 33557425,
                false,
                ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.StarClimbGraphicsController.Ray", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.StarClimbGraphicsController.Ray",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.TimeRateModifier",
                "Celeste.Mod.Entities.TimeRateModifier", "TimeRateModifier", assemblyIdentity, "Celeste", 33557426,
                false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.TimeRateModifier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.TimeRateModifier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.TriggerSpikesOriginal",
                "Celeste.Mod.Entities.TriggerSpikesOriginal", "TriggerSpikesOriginal", assemblyIdentity, "Celeste",
                33557427, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.TriggerSpikesOriginal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.TriggerSpikesOriginal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.TriggerSpikesOriginal+Directions",
                "Celeste.Mod.Entities.TriggerSpikesOriginal.Directions", "Directions", assemblyIdentity, "Celeste",
                33557428, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.TriggerSpikesOriginal.Directions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.TriggerSpikesOriginal.Directions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Entities.TriggerSpikesOriginal+SpikeInfo",
                "Celeste.Mod.Entities.TriggerSpikesOriginal.SpikeInfo", "SpikeInfo", assemblyIdentity, "Celeste",
                33557429,
                false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Entities.TriggerSpikesOriginal.SpikeInfo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Entities.TriggerSpikesOriginal.SpikeInfo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Core.CoreMapDataProcessor",
                "Celeste.Mod.Core.CoreMapDataProcessor", "CoreMapDataProcessor", assemblyIdentity, "Celeste", 33557430,
                false, ["Celeste.Mod.EverestMapDataProcessor", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Core.CoreMapDataProcessor", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Core.CoreMapDataProcessor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Core.CoreMapDataProcessor+<>c",
                "Celeste.Mod.Core.CoreMapDataProcessor.<>c", "<>c", assemblyIdentity, "Celeste", 33557431, false,
                ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Core.CoreMapDataProcessor.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Core.CoreMapDataProcessor.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Core.CoreMapDataProcessor+<>c__DisplayClass12_0",
                "Celeste.Mod.Core.CoreMapDataProcessor.<>c__DisplayClass12_0", "<>c__DisplayClass12_0",
                assemblyIdentity,
                "Celeste", 33557432, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Core.CoreMapDataProcessor.<>c__DisplayClass12_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Core.CoreMapDataProcessor.<>c__DisplayClass12_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Mod.Core.CoreModule", "Celeste.Mod.Core.CoreModule", "CoreModule",
                assemblyIdentity, "Celeste", 33557433, false, ["Celeste.Mod.EverestModule", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Mod.Core.CoreModule", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Mod.Core.CoreModule",
                []);
        }
    }
}
