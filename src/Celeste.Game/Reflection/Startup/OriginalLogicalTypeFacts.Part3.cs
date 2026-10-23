using System;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup;

public static partial class OriginalLogicalTypeFacts
{
    private static void RegisterPart3(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.AreaCompleteTitle", "Celeste.AreaCompleteTitle", "AreaCompleteTitle",
            assemblyIdentity, "Celeste", 33555034, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaCompleteTitle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaCompleteTitle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MEP", "Celeste.MEP", "MEP", assemblyIdentity, "Celeste", 33555035,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MEP", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MEP",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AudioTrackState", "Celeste.AudioTrackState", "AudioTrackState",
            assemblyIdentity, "Celeste", 33555036, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AudioTrackState", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AudioTrackState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AudioState", "Celeste.AudioState", "AudioState", assemblyIdentity,
            "Celeste", 33555037, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AudioState", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AudioState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrier", "Celeste.SeekerBarrier", "SeekerBarrier",
            assemblyIdentity, "Celeste", 33555038, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrier", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrier",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleCrackedBlock", "Celeste.TempleCrackedBlock",
            "TempleCrackedBlock", assemblyIdentity, "Celeste", 33555039, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleCrackedBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleCrackedBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamHeartGem", "Celeste.DreamHeartGem", "DreamHeartGem",
            assemblyIdentity, "Celeste", 33555040, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamHeartGem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamHeartGem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGem", "Celeste.HeartGem", "HeartGem", assemblyIdentity,
            "Celeste", 33555041, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OshiroSprite", "Celeste.OshiroSprite", "OshiroSprite",
            assemblyIdentity, "Celeste", 33555042, false,
            new string[]
            {
                "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component", "System.Object"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OshiroSprite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OshiroSprite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroBreakdown", "Celeste.CS03_OshiroBreakdown",
            "CS03_OshiroBreakdown", assemblyIdentity, "Celeste", 33555043, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroBreakdown", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroBreakdown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS04_Gondola", "Celeste.CS04_Gondola", "CS04_Gondola",
            assemblyIdentity, "Celeste", 33555044, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS04_Gondola", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS04_Gondola",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CoverupWall", "Celeste.CoverupWall", "CoverupWall", assemblyIdentity,
            "Celeste", 33555045, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CoverupWall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CoverupWall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC00_Granny", "Celeste.NPC00_Granny", "NPC00_Granny",
            assemblyIdentity, "Celeste", 33555046, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC00_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC00_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC04_Granny", "Celeste.NPC04_Granny", "NPC04_Granny",
            assemblyIdentity, "Celeste", 33555047, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC04_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC04_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC", "Celeste.NPC", "NPC", assemblyIdentity, "Celeste", 33555048,
            false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Cluttter", "Celeste.NPC03_Oshiro_Cluttter",
            "NPC03_Oshiro_Cluttter", assemblyIdentity, "Celeste", 33555049, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Cluttter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Cluttter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Breakdown", "Celeste.NPC03_Oshiro_Breakdown",
            "NPC03_Oshiro_Breakdown", assemblyIdentity, "Celeste", 33555050, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Breakdown", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Breakdown",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Hallway1", "Celeste.NPC03_Oshiro_Hallway1",
            "NPC03_Oshiro_Hallway1", assemblyIdentity, "Celeste", 33555051, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Hallway1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Hallway1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Hallway2", "Celeste.NPC03_Oshiro_Hallway2",
            "NPC03_Oshiro_Hallway2", assemblyIdentity, "Celeste", 33555052, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Hallway2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Hallway2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Lobby", "Celeste.NPC03_Oshiro_Lobby",
            "NPC03_Oshiro_Lobby", assemblyIdentity, "Celeste", 33555053, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Lobby", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Lobby",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Suite", "Celeste.NPC03_Oshiro_Suite",
            "NPC03_Oshiro_Suite", assemblyIdentity, "Celeste", 33555054, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Suite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Suite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Rooftop", "Celeste.NPC03_Oshiro_Rooftop",
            "NPC03_Oshiro_Rooftop", assemblyIdentity, "Celeste", 33555055, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Rooftop", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Rooftop",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Theo_Escaping", "Celeste.NPC03_Theo_Escaping",
            "NPC03_Theo_Escaping", assemblyIdentity, "Celeste", 33555056, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Theo_Escaping", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Theo_Escaping",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Theo_Vents", "Celeste.NPC03_Theo_Vents", "NPC03_Theo_Vents",
            assemblyIdentity, "Celeste", 33555057, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Theo_Vents", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Theo_Vents",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC01_Theo", "Celeste.NPC01_Theo", "NPC01_Theo", assemblyIdentity,
            "Celeste", 33555058, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC01_Theo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC01_Theo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC02_Theo", "Celeste.NPC02_Theo", "NPC02_Theo", assemblyIdentity,
            "Celeste", 33555059, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC02_Theo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC02_Theo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.NPC04_Theo", "Celeste.NPC04_Theo", "NPC04_Theo", assemblyIdentity,
            "Celeste", 33555060, false,
            new string[]
            {
                "Celeste.NPC", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.NPC04_Theo", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.NPC04_Theo",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Gondola", "Celeste.Gondola", "Gondola", assemblyIdentity, "Celeste",
            33555061, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Gondola", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Gondola",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BloomFadeTrigger", "Celeste.BloomFadeTrigger", "BloomFadeTrigger",
            assemblyIdentity, "Celeste", 33555062, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BloomFadeTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BloomFadeTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightFadeTrigger", "Celeste.LightFadeTrigger", "LightFadeTrigger",
            assemblyIdentity, "Celeste", 33555063, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightFadeTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightFadeTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustEdge", "Celeste.DustEdge", "DustEdge", assemblyIdentity,
            "Celeste", 33555064, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustEdge", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustEdge",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Flagline", "Celeste.Flagline", "Flagline", assemblyIdentity,
            "Celeste", 33555065, false, new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Flagline", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Flagline",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CutsceneEntity", "Celeste.CutsceneEntity", "CutsceneEntity",
            assemblyIdentity, "Celeste", 33555066, true,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CutsceneEntity", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CutsceneEntity",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS00_Granny", "Celeste.CS00_Granny", "CS00_Granny", assemblyIdentity,
            "Celeste", 33555067, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS00_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS00_Ending", "Celeste.CS00_Ending", "CS00_Ending", assemblyIdentity,
            "Celeste", 33555068, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS00_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS01_Ending", "Celeste.CS01_Ending", "CS01_Ending", assemblyIdentity,
            "Celeste", 33555069, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS01_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS01_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_Ending", "Celeste.CS02_Ending", "CS02_Ending", assemblyIdentity,
            "Celeste", 33555070, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_BadelineIntro", "Celeste.CS02_BadelineIntro",
            "CS02_BadelineIntro", assemblyIdentity, "Celeste", 33555071, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_BadelineIntro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_BadelineIntro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_Mirror", "Celeste.CS02_Mirror", "CS02_Mirror", assemblyIdentity,
            "Celeste", 33555072, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_Mirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Mirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS02_DreamingPhonecall", "Celeste.CS02_DreamingPhonecall",
            "CS02_DreamingPhonecall", assemblyIdentity, "Celeste", 33555073, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS02_DreamingPhonecall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS02_DreamingPhonecall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_Ending", "Celeste.CS03_Ending", "CS03_Ending", assemblyIdentity,
            "Celeste", 33555074, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_Ending", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Ending",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroClutter", "Celeste.CS03_OshiroClutter",
            "CS03_OshiroClutter", assemblyIdentity, "Celeste", 33555075, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroClutter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroClutter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroRooftop", "Celeste.CS03_OshiroRooftop",
            "CS03_OshiroRooftop", assemblyIdentity, "Celeste", 33555076, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroRooftop", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroRooftop",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroMasterSuite", "Celeste.CS03_OshiroMasterSuite",
            "CS03_OshiroMasterSuite", assemblyIdentity, "Celeste", 33555077, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroMasterSuite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroMasterSuite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroHallway2", "Celeste.CS03_OshiroHallway2",
            "CS03_OshiroHallway2", assemblyIdentity, "Celeste", 33555078, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroHallway2", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroHallway2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroHallway1", "Celeste.CS03_OshiroHallway1",
            "CS03_OshiroHallway1", assemblyIdentity, "Celeste", 33555079, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroHallway1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroHallway1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroLobby", "Celeste.CS03_OshiroLobby", "CS03_OshiroLobby",
            assemblyIdentity, "Celeste", 33555080, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroLobby", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroLobby",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS03_TheoEscape", "Celeste.CS03_TheoEscape", "CS03_TheoEscape",
            assemblyIdentity, "Celeste", 33555081, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS03_TheoEscape", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS03_TheoEscape",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CS04_Granny", "Celeste.CS04_Granny", "CS04_Granny", assemblyIdentity,
            "Celeste", 33555082, false,
            new string[]
            {
                "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CS04_Granny", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CS04_Granny",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AngryOshiro", "Celeste.AngryOshiro", "AngryOshiro", assemblyIdentity,
            "Celeste", 33555083, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AngryOshiro", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AngryOshiro",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineOldsite", "Celeste.BadelineOldsite", "BadelineOldsite",
            assemblyIdentity, "Celeste", 33555084, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineOldsite", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineOldsite",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Pathfinder", "Celeste.Pathfinder", "Pathfinder", assemblyIdentity,
            "Celeste", 33555085, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Pathfinder", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Pathfinder",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CliffFlags", "Celeste.CliffFlags", "CliffFlags", assemblyIdentity,
            "Celeste", 33555086, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CliffFlags", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CliffFlags",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Clothesline", "Celeste.Clothesline", "Clothesline", assemblyIdentity,
            "Celeste", 33555087, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Clothesline", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Clothesline",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterCabinet", "Celeste.ClutterCabinet", "ClutterCabinet",
            assemblyIdentity, "Celeste", 33555088, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterCabinet", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterCabinet",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FlutterBird", "Celeste.FlutterBird", "FlutterBird", assemblyIdentity,
            "Celeste", 33555089, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FlutterBird", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FlutterBird",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Water", "Celeste.Water", "Water", assemblyIdentity, "Celeste",
            33555090, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Water", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Water",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaterFall", "Celeste.WaterFall", "WaterFall", assemblyIdentity,
            "Celeste", 33555091, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaterFall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaterFall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ParticleRenderer", "Celeste.ParticleRenderer", "ParticleRenderer",
            assemblyIdentity, "Celeste", 33555092, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ParticleRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ParticleRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaterSurface", "Celeste.WaterSurface", "WaterSurface",
            assemblyIdentity, "Celeste", 33555093, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaterSurface", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaterSurface",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamWipe", "Celeste.DreamWipe", "DreamWipe", assemblyIdentity,
            "Celeste", 33555094, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot", "Celeste.OuiFileSelectSlot", "OuiFileSelectSlot",
            assemblyIdentity, "Celeste", 33555095, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon", "Celeste.OuiChapterSelectIcon",
            "OuiChapterSelectIcon", assemblyIdentity, "Celeste", 33555096, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal", "Celeste.OuiJournal", "OuiJournal", assemblyIdentity,
            "Celeste", 33555097, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalCover", "Celeste.OuiJournalCover", "OuiJournalCover",
            assemblyIdentity, "Celeste", 33555098, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalCover", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalCover",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage", "Celeste.OuiJournalPage", "OuiJournalPage",
            assemblyIdentity, "Celeste", 33555099, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem", "Celeste.OuiJournalPoem", "OuiJournalPoem",
            assemblyIdentity, "Celeste", 33555100, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalSpeedrun", "Celeste.OuiJournalSpeedrun",
            "OuiJournalSpeedrun", assemblyIdentity, "Celeste", 33555101, false,
            new string[] { "Celeste.OuiJournalPage", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalSpeedrun", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalSpeedrun",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalProgress", "Celeste.OuiJournalProgress",
            "OuiJournalProgress", assemblyIdentity, "Celeste", 33555102, false,
            new string[] { "Celeste.OuiJournalPage", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalProgress", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalProgress",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MainMenuSmallButton", "Celeste.MainMenuSmallButton",
            "MainMenuSmallButton", assemblyIdentity, "Celeste", 33555103, false,
            new string[]
            {
                "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MainMenuSmallButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuSmallButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MenuButton", "Celeste.MenuButton", "MenuButton", assemblyIdentity,
            "Celeste", 33555104, true,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { true }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MenuButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MenuButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MainMenuClimb", "Celeste.MainMenuClimb", "MainMenuClimb",
            assemblyIdentity, "Celeste", 33555105, false,
            new string[]
            {
                "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MainMenuClimb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuClimb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiCredits", "Celeste.OuiCredits", "OuiCredits", assemblyIdentity,
            "Celeste", 33555106, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiCredits", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiCredits",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IntroVignette", "Celeste.IntroVignette", "IntroVignette",
            assemblyIdentity, "Celeste", 33555107, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IntroVignette", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.IntroVignette",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelLoader", "Celeste.LevelLoader", "LevelLoader", assemblyIdentity,
            "Celeste", 33555108, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelLoader", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelLoader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerDeadBody", "Celeste.PlayerDeadBody", "PlayerDeadBody",
            assemblyIdentity, "Celeste", 33555109, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerDeadBody", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDeadBody",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaMode", "Celeste.AreaMode", "AreaMode", assemblyIdentity,
            "Celeste", 33555110, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaKey", "Celeste.AreaKey", "AreaKey", assemblyIdentity, "Celeste",
            33555111, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaKey", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaKey",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ModeProperties", "Celeste.ModeProperties", "ModeProperties",
            assemblyIdentity, "Celeste", 33555112, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ModeProperties", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ModeProperties",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData", "Celeste.AreaData", "AreaData", assemblyIdentity,
            "Celeste", 33555113, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CheckpointData", "Celeste.CheckpointData", "CheckpointData",
            assemblyIdentity, "Celeste", 33555114, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CheckpointData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaModeStats", "Celeste.AreaModeStats", "AreaModeStats",
            assemblyIdentity, "Celeste", 33555115, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaModeStats", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaModeStats",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaStats", "Celeste.AreaStats", "AreaStats", assemblyIdentity,
            "Celeste", 33555116, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaStats", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaStats",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste._3dSoundTest", "Celeste._3dSoundTest", "_3dSoundTest",
            assemblyIdentity, "Celeste", 33555117, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste._3dSoundTest", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste._3dSoundTest",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlockField", "Celeste.BlockField", "BlockField", assemblyIdentity,
            "Celeste", 33555118, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlockField", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlockField",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Booster", "Celeste.Booster", "Booster", assemblyIdentity, "Celeste",
            33555119, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Booster", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Booster",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Checkpoint", "Celeste.Checkpoint", "Checkpoint", assemblyIdentity,
            "Celeste", 33555120, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Checkpoint", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Checkpoint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cloud", "Celeste.Cloud", "Cloud", assemblyIdentity, "Celeste",
            33555121, false,
            new string[]
            {
                "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cloud", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cloud",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlock", "Celeste.ClutterBlock", "ClutterBlock",
            assemblyIdentity, "Celeste", 33555122, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockBase", "Celeste.ClutterBlockBase", "ClutterBlockBase",
            assemblyIdentity, "Celeste", 33555123, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockBase", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockBase",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterDoor", "Celeste.ClutterDoor", "ClutterDoor", assemblyIdentity,
            "Celeste", 33555124, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch", "Celeste.ClutterSwitch", "ClutterSwitch",
            assemblyIdentity, "Celeste", 33555125, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect", "Celeste.ClutterAbsorbEffect",
            "ClutterAbsorbEffect", assemblyIdentity, "Celeste", 33555126, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DashListener", "Celeste.DashListener", "DashListener",
            assemblyIdentity, "Celeste", 33555127, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DashListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DashListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LedgeBlocker", "Celeste.LedgeBlocker", "LedgeBlocker",
            assemblyIdentity, "Celeste", 33555128, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LedgeBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LedgeBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic", "Celeste.DustGraphic", "DustGraphic", assemblyIdentity,
            "Celeste", 33555129, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SafeGroundBlocker", "Celeste.SafeGroundBlocker", "SafeGroundBlocker",
            assemblyIdentity, "Celeste", 33555130, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SafeGroundBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SafeGroundBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SoundSource", "Celeste.SoundSource", "SoundSource", assemblyIdentity,
            "Celeste", 33555131, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SoundSource", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SoundSource",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TalkComponent", "Celeste.TalkComponent", "TalkComponent",
            assemblyIdentity, "Celeste", 33555132, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TalkComponent", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TalkComponent",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TileInterceptor", "Celeste.TileInterceptor", "TileInterceptor",
            assemblyIdentity, "Celeste", 33555133, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TileInterceptor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TileInterceptor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TransitionListener", "Celeste.TransitionListener",
            "TransitionListener", assemblyIdentity, "Celeste", 33555134, false,
            new string[] { "Monocle.Component", "System.Object" }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TransitionListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TransitionListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindMover", "Celeste.WindMover", "WindMover", assemblyIdentity,
            "Celeste", 33555135, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindMover", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindMover",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker", "Celeste.Seeker", "Seeker", assemblyIdentity, "Celeste",
            33555136, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustStaticSpinner", "Celeste.DustStaticSpinner", "DustStaticSpinner",
            assemblyIdentity, "Celeste", 33555137, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustStaticSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustStaticSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustTrackSpinner", "Celeste.DustTrackSpinner", "DustTrackSpinner",
            assemblyIdentity, "Celeste", 33555138, false,
            new string[]
            {
                "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustTrackSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustTrackSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Snowball", "Celeste.Snowball", "Snowball", assemblyIdentity,
            "Celeste", 33555139, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Snowball", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Snowball",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DashSwitch", "Celeste.DashSwitch", "DashSwitch", assemblyIdentity,
            "Celeste", 33555140, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DashSwitch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DashSwitch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cobweb", "Celeste.Cobweb", "Cobweb", assemblyIdentity, "Celeste",
            33555141, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cobweb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cobweb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortLantern", "Celeste.ResortLantern", "ResortLantern",
            assemblyIdentity, "Celeste", 33555142, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortLantern", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortLantern",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MrOshiroDoor", "Celeste.MrOshiroDoor", "MrOshiroDoor",
            assemblyIdentity, "Celeste", 33555143, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MrOshiroDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MrOshiroDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Door", "Celeste.Door", "Door", assemblyIdentity, "Celeste", 33555144,
            false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Door", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Door",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock", "Celeste.MoveBlock", "MoveBlock", assemblyIdentity,
            "Celeste", 33555145, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PropLight", "Celeste.PropLight", "PropLight", assemblyIdentity,
            "Celeste", 33555146, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PropLight", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PropLight",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Debris", "Celeste.Debris", "Debris", assemblyIdentity, "Celeste",
            33555147, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Debris", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Debris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FloatingDebris", "Celeste.FloatingDebris", "FloatingDebris",
            assemblyIdentity, "Celeste", 33555148, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FloatingDebris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FloatingDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForegroundDebris", "Celeste.ForegroundDebris", "ForegroundDebris",
            assemblyIdentity, "Celeste", 33555149, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForegroundDebris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForegroundDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Trapdoor", "Celeste.Trapdoor", "Trapdoor", assemblyIdentity,
            "Celeste", 33555150, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Trapdoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Trapdoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OldSiteChaseMusicHandler", "Celeste.OldSiteChaseMusicHandler",
            "OldSiteChaseMusicHandler", assemblyIdentity, "Celeste", 33555151, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OldSiteChaseMusicHandler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OldSiteChaseMusicHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PicoConsole", "Celeste.PicoConsole", "PicoConsole", assemblyIdentity,
            "Celeste", 33555152, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PicoConsole", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PicoConsole",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror", "Celeste.ResortMirror", "ResortMirror",
            assemblyIdentity, "Celeste", 33555153, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortRoofEnding", "Celeste.ResortRoofEnding", "ResortRoofEnding",
            assemblyIdentity, "Celeste", 33555154, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortRoofEnding", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortRoofEnding",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy", "Celeste.BadelineDummy", "BadelineDummy",
            assemblyIdentity, "Celeste", 33555155, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Bonfire", "Celeste.Bonfire", "Bonfire", assemblyIdentity, "Celeste",
            33555156, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Bonfire", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Bonfire",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror", "Celeste.DreamMirror", "DreamMirror", assemblyIdentity,
            "Celeste", 33555157, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Payphone", "Celeste.Payphone", "Payphone", assemblyIdentity,
            "Celeste", 33555158, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Payphone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Payphone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Lookout", "Celeste.Lookout", "Lookout", assemblyIdentity, "Celeste",
            33555159, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Lookout", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Lookout",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal", "Celeste.TempleMirrorPortal",
            "TempleMirrorPortal", assemblyIdentity, "Celeste", 33555160, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SwapBlock", "Celeste.SwapBlock", "SwapBlock", assemblyIdentity,
            "Celeste", 33555161, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SwapBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SwapBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate", "Celeste.TempleGate", "TempleGate", assemblyIdentity,
            "Celeste", 33555162, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Torch", "Celeste.Torch", "Torch", assemblyIdentity, "Celeste",
            33555163, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Torch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Torch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AltMusicTrigger", "Celeste.AltMusicTrigger", "AltMusicTrigger",
            assemblyIdentity, "Celeste", 33555164, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AltMusicTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AltMusicTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MusicTrigger", "Celeste.MusicTrigger", "MusicTrigger",
            assemblyIdentity, "Celeste", 33555165, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MusicTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MusicTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindAttackTrigger", "Celeste.WindAttackTrigger", "WindAttackTrigger",
            assemblyIdentity, "Celeste", 33555166, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindAttackTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindAttackTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindTrigger", "Celeste.WindTrigger", "WindTrigger", assemblyIdentity,
            "Celeste", 33555167, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie", "Celeste.Selfie", "Selfie", assemblyIdentity, "Celeste",
            33555168, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TotalStrawberriesDisplay", "Celeste.TotalStrawberriesDisplay",
            "TotalStrawberriesDisplay", assemblyIdentity, "Celeste", 33555169, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TotalStrawberriesDisplay", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TotalStrawberriesDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindController", "Celeste.WindController", "WindController",
            assemblyIdentity, "Celeste", 33555170, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindController", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindController",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamStars", "Celeste.DreamStars", "DreamStars", assemblyIdentity,
            "Celeste", 33555171, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamStars", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamStars",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Autotiler", "Celeste.Autotiler", "Autotiler", assemblyIdentity,
            "Celeste", 33555172, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Autotiler", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StarsBG", "Celeste.StarsBG", "StarsBG", assemblyIdentity, "Celeste",
            33555173, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StarsBG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.StarsBG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindSnowFG", "Celeste.WindSnowFG", "WindSnowFG", assemblyIdentity,
            "Celeste", 33555174, false, new string[] { "Celeste.Backdrop", "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindSnowFG", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindSnowFG",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BirdTutorialGui", "Celeste.BirdTutorialGui", "BirdTutorialGui",
            assemblyIdentity, "Celeste", 33555175, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BirdTutorialGui", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BirdTutorialGui",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Decal", "Celeste.Decal", "Decal", assemblyIdentity, "Celeste",
            33555176, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Decal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Decal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LightBeam", "Celeste.LightBeam", "LightBeam", assemblyIdentity,
            "Celeste", 33555177, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LightBeam", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LightBeam",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustEdges", "Celeste.DustEdges", "DustEdges", assemblyIdentity,
            "Celeste", 33555178, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustEdges", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustEdges",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Textbox", "Celeste.Textbox", "Textbox", assemblyIdentity, "Celeste",
            33555179, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Textbox", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Textbox",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BestTimeDisplay", "Celeste.BestTimeDisplay", "BestTimeDisplay",
            assemblyIdentity, "Celeste", 33555180, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BestTimeDisplay", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BestTimeDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DeathsCounter", "Celeste.DeathsCounter", "DeathsCounter",
            assemblyIdentity, "Celeste", 33555181, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DeathsCounter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DeathsCounter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDisplay", "Celeste.HeartGemDisplay", "HeartGemDisplay",
            assemblyIdentity, "Celeste", 33555182, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDisplay", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunTimerDisplay", "Celeste.SpeedrunTimerDisplay",
            "SpeedrunTimerDisplay", assemblyIdentity, "Celeste", 33555183, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunTimerDisplay", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunTimerDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.StrawberriesCounter", "Celeste.StrawberriesCounter",
            "StrawberriesCounter", assemblyIdentity, "Celeste", 33555184, false,
            new string[] { "Monocle.Component", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.StrawberriesCounter", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.StrawberriesCounter",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FadeWipe", "Celeste.FadeWipe", "FadeWipe", assemblyIdentity,
            "Celeste", 33555185, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FadeWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FadeWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindWipe", "Celeste.WindWipe", "WindWipe", assemblyIdentity,
            "Celeste", 33555186, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CurtainWipe", "Celeste.CurtainWipe", "CurtainWipe", assemblyIdentity,
            "Celeste", 33555187, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CurtainWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CurtainWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpotlightWipe", "Celeste.SpotlightWipe", "SpotlightWipe",
            assemblyIdentity, "Celeste", 33555188, false,
            new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpotlightWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpotlightWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaComplete", "Celeste.AreaComplete", "AreaComplete",
            assemblyIdentity, "Celeste", 33555189, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaComplete", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaComplete",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PreviewPortrait", "Celeste.PreviewPortrait", "PreviewPortrait",
            assemblyIdentity, "Celeste", 33555190, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PreviewPortrait", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPortrait",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Billboard", "Celeste.Billboard", "Billboard", assemblyIdentity,
            "Celeste", 33555191, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { true },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Billboard", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Billboard",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MountainRenderer", "Celeste.MountainRenderer", "MountainRenderer",
            assemblyIdentity, "Celeste", 33555192, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MountainRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MountainRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Overworld", "Celeste.Overworld", "Overworld", assemblyIdentity,
            "Celeste", 33555193, false,
            new string[]
            {
                "Monocle.Scene", "Celeste.IOverlayHandler", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Overworld", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Overworld",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel", "Celeste.OuiChapterPanel", "OuiChapterPanel",
            assemblyIdentity, "Celeste", 33555194, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect", "Celeste.OuiChapterSelect", "OuiChapterSelect",
            assemblyIdentity, "Celeste", 33555195, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileNaming", "Celeste.OuiFileNaming", "OuiFileNaming",
            assemblyIdentity, "Celeste", 33555196, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileNaming", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileNaming",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect", "Celeste.OuiFileSelect", "OuiFileSelect",
            assemblyIdentity, "Celeste", 33555197, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu", "Celeste.OuiMainMenu", "OuiMainMenu", assemblyIdentity,
            "Celeste", 33555198, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiOptions", "Celeste.OuiOptions", "OuiOptions", assemblyIdentity,
            "Celeste", 33555199, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiOptions", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiOptions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen", "Celeste.OuiTitleScreen", "OuiTitleScreen",
            assemblyIdentity, "Celeste", 33555200, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Oui", "Celeste.Oui", "Oui", assemblyIdentity, "Celeste", 33555201,
            true,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Oui", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Oui",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Poem", "Celeste.Poem", "Poem", assemblyIdentity, "Celeste", 33555202,
            false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Poem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Poem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TestWipes", "Celeste.TestWipes", "TestWipes", assemblyIdentity,
            "Celeste", 33555203, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TestWipes", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TestWipes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SummitVignette", "Celeste.SummitVignette", "SummitVignette",
            assemblyIdentity, "Celeste", 33555204, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SummitVignette", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SummitVignette",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FancyText", "Celeste.FancyText", "FancyText", assemblyIdentity,
            "Celeste", 33555205, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FancyText", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FancyText",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MTN", "Celeste.MTN", "MTN", assemblyIdentity, "Celeste", 33555206,
            true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MTN", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MTN",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlaybackData", "Celeste.PlaybackData", "PlaybackData",
            assemblyIdentity, "Celeste", 33555207, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlaybackData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlaybackData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameplayBuffers", "Celeste.GameplayBuffers", "GameplayBuffers",
            assemblyIdentity, "Celeste", 33555208, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameplayBuffers", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameplayBuffers",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator", "Celeste.ClutterBlockGenerator",
            "ClutterBlockGenerator", assemblyIdentity, "Celeste", 33555209, true, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ColorGrade", "Celeste.ColorGrade", "ColorGrade", assemblyIdentity,
            "Celeste", 33555210, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ColorGrade", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ColorGrade",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Commands", "Celeste.Commands", "Commands", assemblyIdentity,
            "Celeste", 33555211, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Commands", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Commands",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Depths", "Celeste.Depths", "Depths", assemblyIdentity, "Celeste",
            33555212, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Depths", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Depths",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Dialog", "Celeste.Dialog", "Dialog", assemblyIdentity, "Celeste",
            33555213, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Dialog", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Dialog",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Audio", "Celeste.Audio", "Audio", assemblyIdentity, "Celeste",
            33555214, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Audio", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Audio",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Fonts", "Celeste.Fonts", "Fonts", assemblyIdentity, "Celeste",
            33555215, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Fonts", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Fonts",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ActiveFont", "Celeste.ActiveFont", "ActiveFont", assemblyIdentity,
            "Celeste", 33555216, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ActiveFont", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ActiveFont",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GameplayRenderer", "Celeste.GameplayRenderer", "GameplayRenderer",
            assemblyIdentity, "Celeste", 33555217, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GameplayRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.GameplayRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.HudRenderer", "Celeste.HudRenderer", "HudRenderer", assemblyIdentity,
            "Celeste", 33555218, false, new string[] { "Celeste.HiresRenderer", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.HudRenderer", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.HudRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Glitch", "Celeste.Glitch", "Glitch", assemblyIdentity, "Celeste",
            33555219, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Glitch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Glitch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MenuOptions", "Celeste.MenuOptions", "MenuOptions", assemblyIdentity,
            "Celeste", 33555220, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MenuOptions", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MenuOptions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ParticleTypes", "Celeste.ParticleTypes", "ParticleTypes",
            assemblyIdentity, "Celeste", 33555221, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ParticleTypes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ParticleTypes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DeathData", "Celeste.DeathData", "DeathData", assemblyIdentity,
            "Celeste", 33555222, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DeathData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DeathData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerInventory", "Celeste.PlayerInventory", "PlayerInventory",
            assemblyIdentity, "Celeste", 33555223, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerInventory", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerInventory",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SaveData", "Celeste.SaveData", "SaveData", assemblyIdentity,
            "Celeste", 33555224, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SaveData", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SaveData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Session", "Celeste.Session", "Session", assemblyIdentity, "Celeste",
            33555225, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Session", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Session",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.EntityID", "Celeste.EntityID", "EntityID", assemblyIdentity,
            "Celeste", 33555226, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.EntityID", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.EntityID",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.RumbleAmount", "Celeste.RumbleAmount", "RumbleAmount",
            assemblyIdentity, "Celeste", 33555227, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.RumbleAmount", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.RumbleAmount",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunType", "Celeste.SpeedrunType", "SpeedrunType",
            assemblyIdentity, "Celeste", 33555228, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunType", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunType",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ScreenshakeAmount", "Celeste.ScreenshakeAmount", "ScreenshakeAmount",
            assemblyIdentity, "Celeste", 33555229, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ScreenshakeAmount", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ScreenshakeAmount",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.GrabModes", "Celeste.GrabModes", "GrabModes", assemblyIdentity,
            "Celeste", 33555230, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.GrabModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.GrabModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CrouchDashModes", "Celeste.CrouchDashModes", "CrouchDashModes",
            assemblyIdentity, "Celeste", 33555231, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CrouchDashModes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CrouchDashModes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Settings", "Celeste.Settings", "Settings", assemblyIdentity,
            "Celeste", 33555232, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Settings", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Settings",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Assists", "Celeste.Assists", "Assists", assemblyIdentity, "Celeste",
            33555233, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Assists", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Assists",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
