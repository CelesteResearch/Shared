using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static partial class OriginalLogicalTypeFacts
    {
        private static void RegisterPart3(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.AreaCompleteTitle", "Celeste.AreaCompleteTitle",
                "AreaCompleteTitle",
                assemblyIdentity, "Celeste", 33555034, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaCompleteTitle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaCompleteTitle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MEP", "Celeste.MEP", "MEP", assemblyIdentity, "Celeste", 33555035,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MEP", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MEP",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AudioTrackState", "Celeste.AudioTrackState", "AudioTrackState",
                assemblyIdentity, "Celeste", 33555036, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AudioTrackState", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AudioTrackState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AudioState", "Celeste.AudioState", "AudioState", assemblyIdentity,
                "Celeste", 33555037, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AudioState", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AudioState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrier", "Celeste.SeekerBarrier", "SeekerBarrier",
                assemblyIdentity, "Celeste", 33555038, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleCrackedBlock", "Celeste.TempleCrackedBlock",
                "TempleCrackedBlock", assemblyIdentity, "Celeste", 33555039, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleCrackedBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleCrackedBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamHeartGem", "Celeste.DreamHeartGem", "DreamHeartGem",
                assemblyIdentity, "Celeste", 33555040, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamHeartGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamHeartGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGem", "Celeste.HeartGem", "HeartGem", assemblyIdentity,
                "Celeste", 33555041, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OshiroSprite", "Celeste.OshiroSprite", "OshiroSprite",
                assemblyIdentity, "Celeste", 33555042, false,
                [
                    "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component",
                    "System.Object",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OshiroSprite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OshiroSprite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroBreakdown", "Celeste.CS03_OshiroBreakdown",
                "CS03_OshiroBreakdown", assemblyIdentity, "Celeste", 33555043, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroBreakdown", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroBreakdown",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS04_Gondola", "Celeste.CS04_Gondola", "CS04_Gondola",
                assemblyIdentity, "Celeste", 33555044, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS04_Gondola", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS04_Gondola",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoverupWall", "Celeste.CoverupWall", "CoverupWall",
                assemblyIdentity,
                "Celeste", 33555045, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoverupWall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoverupWall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC00_Granny", "Celeste.NPC00_Granny", "NPC00_Granny",
                assemblyIdentity, "Celeste", 33555046, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC00_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC00_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC04_Granny", "Celeste.NPC04_Granny", "NPC04_Granny",
                assemblyIdentity, "Celeste", 33555047, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC04_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC04_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC", "Celeste.NPC", "NPC", assemblyIdentity, "Celeste", 33555048,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Cluttter", "Celeste.NPC03_Oshiro_Cluttter",
                "NPC03_Oshiro_Cluttter", assemblyIdentity, "Celeste", 33555049, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Cluttter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Cluttter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Breakdown", "Celeste.NPC03_Oshiro_Breakdown",
                "NPC03_Oshiro_Breakdown", assemblyIdentity, "Celeste", 33555050, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Breakdown", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Breakdown",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Hallway1", "Celeste.NPC03_Oshiro_Hallway1",
                "NPC03_Oshiro_Hallway1", assemblyIdentity, "Celeste", 33555051, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Hallway1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Hallway1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Hallway2", "Celeste.NPC03_Oshiro_Hallway2",
                "NPC03_Oshiro_Hallway2", assemblyIdentity, "Celeste", 33555052, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Hallway2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Hallway2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Lobby", "Celeste.NPC03_Oshiro_Lobby",
                "NPC03_Oshiro_Lobby", assemblyIdentity, "Celeste", 33555053, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Lobby", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Lobby",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Suite", "Celeste.NPC03_Oshiro_Suite",
                "NPC03_Oshiro_Suite", assemblyIdentity, "Celeste", 33555054, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Suite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Suite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Oshiro_Rooftop", "Celeste.NPC03_Oshiro_Rooftop",
                "NPC03_Oshiro_Rooftop", assemblyIdentity, "Celeste", 33555055, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Oshiro_Rooftop", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Oshiro_Rooftop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Theo_Escaping", "Celeste.NPC03_Theo_Escaping",
                "NPC03_Theo_Escaping", assemblyIdentity, "Celeste", 33555056, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Theo_Escaping", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Theo_Escaping",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC03_Theo_Vents", "Celeste.NPC03_Theo_Vents", "NPC03_Theo_Vents",
                assemblyIdentity, "Celeste", 33555057, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC03_Theo_Vents", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC03_Theo_Vents",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC01_Theo", "Celeste.NPC01_Theo", "NPC01_Theo", assemblyIdentity,
                "Celeste", 33555058, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC01_Theo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC01_Theo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC02_Theo", "Celeste.NPC02_Theo", "NPC02_Theo", assemblyIdentity,
                "Celeste", 33555059, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC02_Theo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC02_Theo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC04_Theo", "Celeste.NPC04_Theo", "NPC04_Theo", assemblyIdentity,
                "Celeste", 33555060, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC04_Theo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC04_Theo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Gondola", "Celeste.Gondola", "Gondola", assemblyIdentity,
                "Celeste",
                33555061, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Gondola", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Gondola",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BloomFadeTrigger", "Celeste.BloomFadeTrigger", "BloomFadeTrigger",
                assemblyIdentity, "Celeste", 33555062, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BloomFadeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BloomFadeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightFadeTrigger", "Celeste.LightFadeTrigger", "LightFadeTrigger",
                assemblyIdentity, "Celeste", 33555063, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightFadeTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightFadeTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustEdge", "Celeste.DustEdge", "DustEdge", assemblyIdentity,
                "Celeste", 33555064, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustEdge", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustEdge",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Flagline", "Celeste.Flagline", "Flagline", assemblyIdentity,
                "Celeste", 33555065, false, ["Monocle.Component", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Flagline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Flagline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CutsceneEntity", "Celeste.CutsceneEntity", "CutsceneEntity",
                assemblyIdentity, "Celeste", 33555066, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CutsceneEntity", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CutsceneEntity",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS00_Granny", "Celeste.CS00_Granny", "CS00_Granny",
                assemblyIdentity,
                "Celeste", 33555067, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS00_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS00_Ending", "Celeste.CS00_Ending", "CS00_Ending",
                assemblyIdentity,
                "Celeste", 33555068, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS00_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS00_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS01_Ending", "Celeste.CS01_Ending", "CS01_Ending",
                assemblyIdentity,
                "Celeste", 33555069, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS01_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS01_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Ending", "Celeste.CS02_Ending", "CS02_Ending",
                assemblyIdentity,
                "Celeste", 33555070, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_BadelineIntro", "Celeste.CS02_BadelineIntro",
                "CS02_BadelineIntro", assemblyIdentity, "Celeste", 33555071, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_BadelineIntro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_BadelineIntro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_Mirror", "Celeste.CS02_Mirror", "CS02_Mirror",
                assemblyIdentity,
                "Celeste", 33555072, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_Mirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_Mirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS02_DreamingPhonecall", "Celeste.CS02_DreamingPhonecall",
                "CS02_DreamingPhonecall", assemblyIdentity, "Celeste", 33555073, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS02_DreamingPhonecall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS02_DreamingPhonecall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_Ending", "Celeste.CS03_Ending", "CS03_Ending",
                assemblyIdentity,
                "Celeste", 33555074, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroClutter", "Celeste.CS03_OshiroClutter",
                "CS03_OshiroClutter", assemblyIdentity, "Celeste", 33555075, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroClutter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroClutter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroRooftop", "Celeste.CS03_OshiroRooftop",
                "CS03_OshiroRooftop", assemblyIdentity, "Celeste", 33555076, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroRooftop", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroRooftop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroMasterSuite", "Celeste.CS03_OshiroMasterSuite",
                "CS03_OshiroMasterSuite", assemblyIdentity, "Celeste", 33555077, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroMasterSuite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroMasterSuite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroHallway2", "Celeste.CS03_OshiroHallway2",
                "CS03_OshiroHallway2", assemblyIdentity, "Celeste", 33555078, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroHallway2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroHallway2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroHallway1", "Celeste.CS03_OshiroHallway1",
                "CS03_OshiroHallway1", assemblyIdentity, "Celeste", 33555079, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroHallway1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroHallway1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_OshiroLobby", "Celeste.CS03_OshiroLobby", "CS03_OshiroLobby",
                assemblyIdentity, "Celeste", 33555080, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_OshiroLobby", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_OshiroLobby",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS03_TheoEscape", "Celeste.CS03_TheoEscape", "CS03_TheoEscape",
                assemblyIdentity, "Celeste", 33555081, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS03_TheoEscape", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS03_TheoEscape",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS04_Granny", "Celeste.CS04_Granny", "CS04_Granny",
                assemblyIdentity,
                "Celeste", 33555082, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS04_Granny", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS04_Granny",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AngryOshiro", "Celeste.AngryOshiro", "AngryOshiro",
                assemblyIdentity,
                "Celeste", 33555083, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AngryOshiro", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AngryOshiro",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BadelineOldsite", "Celeste.BadelineOldsite", "BadelineOldsite",
                assemblyIdentity, "Celeste", 33555084, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BadelineOldsite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BadelineOldsite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Pathfinder", "Celeste.Pathfinder", "Pathfinder", assemblyIdentity,
                "Celeste", 33555085, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Pathfinder", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Pathfinder",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CliffFlags", "Celeste.CliffFlags", "CliffFlags", assemblyIdentity,
                "Celeste", 33555086, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CliffFlags", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CliffFlags",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Clothesline", "Celeste.Clothesline", "Clothesline",
                assemblyIdentity,
                "Celeste", 33555087, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Clothesline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Clothesline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterCabinet", "Celeste.ClutterCabinet", "ClutterCabinet",
                assemblyIdentity, "Celeste", 33555088, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterCabinet", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterCabinet",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FlutterBird", "Celeste.FlutterBird", "FlutterBird",
                assemblyIdentity,
                "Celeste", 33555089, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FlutterBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FlutterBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Water", "Celeste.Water", "Water", assemblyIdentity, "Celeste",
                33555090, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Water", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Water",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaterFall", "Celeste.WaterFall", "WaterFall", assemblyIdentity,
                "Celeste", 33555091, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaterFall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaterFall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ParticleRenderer", "Celeste.ParticleRenderer", "ParticleRenderer",
                assemblyIdentity, "Celeste", 33555092, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ParticleRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ParticleRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WaterSurface", "Celeste.WaterSurface", "WaterSurface",
                assemblyIdentity, "Celeste", 33555093, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WaterSurface", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WaterSurface",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamWipe", "Celeste.DreamWipe", "DreamWipe", assemblyIdentity,
                "Celeste", 33555094, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot", "Celeste.OuiFileSelectSlot",
                "OuiFileSelectSlot",
                assemblyIdentity, "Celeste", 33555095, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon", "Celeste.OuiChapterSelectIcon",
                "OuiChapterSelectIcon", assemblyIdentity, "Celeste", 33555096, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal", "Celeste.OuiJournal", "OuiJournal", assemblyIdentity,
                "Celeste", 33555097, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalCover", "Celeste.OuiJournalCover", "OuiJournalCover",
                assemblyIdentity, "Celeste", 33555098, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalCover", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalCover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage", "Celeste.OuiJournalPage", "OuiJournalPage",
                assemblyIdentity, "Celeste", 33555099, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem", "Celeste.OuiJournalPoem", "OuiJournalPoem",
                assemblyIdentity, "Celeste", 33555100, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalSpeedrun", "Celeste.OuiJournalSpeedrun",
                "OuiJournalSpeedrun", assemblyIdentity, "Celeste", 33555101, false,
                ["Celeste.OuiJournalPage", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalSpeedrun", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalSpeedrun",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalProgress", "Celeste.OuiJournalProgress",
                "OuiJournalProgress", assemblyIdentity, "Celeste", 33555102, false,
                ["Celeste.OuiJournalPage", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalProgress", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalProgress",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MainMenuSmallButton", "Celeste.MainMenuSmallButton",
                "MainMenuSmallButton", assemblyIdentity, "Celeste", 33555103, false,
                [
                    "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MainMenuSmallButton", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuSmallButton",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MenuButton", "Celeste.MenuButton", "MenuButton", assemblyIdentity,
                "Celeste", 33555104, true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [true], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MenuButton", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MenuButton",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MainMenuClimb", "Celeste.MainMenuClimb", "MainMenuClimb",
                assemblyIdentity, "Celeste", 33555105, false,
                [
                    "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MainMenuClimb", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuClimb",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiCredits", "Celeste.OuiCredits", "OuiCredits", assemblyIdentity,
                "Celeste", 33555106, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiCredits", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiCredits",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IntroVignette", "Celeste.IntroVignette", "IntroVignette",
                assemblyIdentity, "Celeste", 33555107, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IntroVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IntroVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelLoader", "Celeste.LevelLoader", "LevelLoader",
                assemblyIdentity,
                "Celeste", 33555108, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerDeadBody", "Celeste.PlayerDeadBody", "PlayerDeadBody",
                assemblyIdentity, "Celeste", 33555109, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerDeadBody", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDeadBody",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaMode", "Celeste.AreaMode", "AreaMode", assemblyIdentity,
                "Celeste", 33555110, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaKey", "Celeste.AreaKey", "AreaKey", assemblyIdentity,
                "Celeste",
                33555111, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaKey", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaKey",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ModeProperties", "Celeste.ModeProperties", "ModeProperties",
                assemblyIdentity, "Celeste", 33555112, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ModeProperties", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ModeProperties",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaData", "Celeste.AreaData", "AreaData", assemblyIdentity,
                "Celeste", 33555113, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CheckpointData", "Celeste.CheckpointData", "CheckpointData",
                assemblyIdentity, "Celeste", 33555114, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CheckpointData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaModeStats", "Celeste.AreaModeStats", "AreaModeStats",
                assemblyIdentity, "Celeste", 33555115, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaModeStats", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaModeStats",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaStats", "Celeste.AreaStats", "AreaStats", assemblyIdentity,
                "Celeste", 33555116, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaStats", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaStats",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste._3dSoundTest", "Celeste._3dSoundTest", "_3dSoundTest",
                assemblyIdentity, "Celeste", 33555117, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste._3dSoundTest", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste._3dSoundTest",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BlockField", "Celeste.BlockField", "BlockField", assemblyIdentity,
                "Celeste", 33555118, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BlockField", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BlockField",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Booster", "Celeste.Booster", "Booster", assemblyIdentity,
                "Celeste",
                33555119, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Booster", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Booster",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Checkpoint", "Celeste.Checkpoint", "Checkpoint", assemblyIdentity,
                "Celeste", 33555120, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Checkpoint", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Checkpoint",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cloud", "Celeste.Cloud", "Cloud", assemblyIdentity, "Celeste",
                33555121, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cloud", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cloud",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlock", "Celeste.ClutterBlock", "ClutterBlock",
                assemblyIdentity, "Celeste", 33555122, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockBase", "Celeste.ClutterBlockBase", "ClutterBlockBase",
                assemblyIdentity, "Celeste", 33555123, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockBase", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockBase",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterDoor", "Celeste.ClutterDoor", "ClutterDoor",
                assemblyIdentity,
                "Celeste", 33555124, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch", "Celeste.ClutterSwitch", "ClutterSwitch",
                assemblyIdentity, "Celeste", 33555125, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect", "Celeste.ClutterAbsorbEffect",
                "ClutterAbsorbEffect", assemblyIdentity, "Celeste", 33555126, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashListener", "Celeste.DashListener", "DashListener",
                assemblyIdentity, "Celeste", 33555127, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashListener", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LedgeBlocker", "Celeste.LedgeBlocker", "LedgeBlocker",
                assemblyIdentity, "Celeste", 33555128, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LedgeBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LedgeBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic", "Celeste.DustGraphic", "DustGraphic",
                assemblyIdentity,
                "Celeste", 33555129, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SafeGroundBlocker", "Celeste.SafeGroundBlocker",
                "SafeGroundBlocker",
                assemblyIdentity, "Celeste", 33555130, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SafeGroundBlocker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SafeGroundBlocker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SoundSource", "Celeste.SoundSource", "SoundSource",
                assemblyIdentity,
                "Celeste", 33555131, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SoundSource", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SoundSource",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TalkComponent", "Celeste.TalkComponent", "TalkComponent",
                assemblyIdentity, "Celeste", 33555132, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TalkComponent", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TalkComponent",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TileInterceptor", "Celeste.TileInterceptor", "TileInterceptor",
                assemblyIdentity, "Celeste", 33555133, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TileInterceptor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TileInterceptor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TransitionListener", "Celeste.TransitionListener",
                "TransitionListener", assemblyIdentity, "Celeste", 33555134, false,
                ["Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TransitionListener", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TransitionListener",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindMover", "Celeste.WindMover", "WindMover", assemblyIdentity,
                "Celeste", 33555135, false, ["Monocle.Component", "System.Object"], [false],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindMover", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindMover",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Seeker", "Celeste.Seeker", "Seeker", assemblyIdentity, "Celeste",
                33555136, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Seeker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Seeker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustStaticSpinner", "Celeste.DustStaticSpinner",
                "DustStaticSpinner",
                assemblyIdentity, "Celeste", 33555137, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustStaticSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustStaticSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustTrackSpinner", "Celeste.DustTrackSpinner", "DustTrackSpinner",
                assemblyIdentity, "Celeste", 33555138, false,
                [
                    "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustTrackSpinner", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustTrackSpinner",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snowball", "Celeste.Snowball", "Snowball", assemblyIdentity,
                "Celeste", 33555139, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snowball", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snowball",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DashSwitch", "Celeste.DashSwitch", "DashSwitch", assemblyIdentity,
                "Celeste", 33555140, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DashSwitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DashSwitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Cobweb", "Celeste.Cobweb", "Cobweb", assemblyIdentity, "Celeste",
                33555141, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Cobweb", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Cobweb",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ResortLantern", "Celeste.ResortLantern", "ResortLantern",
                assemblyIdentity, "Celeste", 33555142, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ResortLantern", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ResortLantern",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MrOshiroDoor", "Celeste.MrOshiroDoor", "MrOshiroDoor",
                assemblyIdentity, "Celeste", 33555143, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MrOshiroDoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MrOshiroDoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Door", "Celeste.Door", "Door", assemblyIdentity, "Celeste",
                33555144,
                false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Door", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Door",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock", "Celeste.MoveBlock", "MoveBlock", assemblyIdentity,
                "Celeste", 33555145, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PropLight", "Celeste.PropLight", "PropLight", assemblyIdentity,
                "Celeste", 33555146, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PropLight", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PropLight",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Debris", "Celeste.Debris", "Debris", assemblyIdentity, "Celeste",
                33555147, false,
                [
                    "Celeste.Actor", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Debris", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Debris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FloatingDebris", "Celeste.FloatingDebris", "FloatingDebris",
                assemblyIdentity, "Celeste", 33555148, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FloatingDebris", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FloatingDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForegroundDebris", "Celeste.ForegroundDebris", "ForegroundDebris",
                assemblyIdentity, "Celeste", 33555149, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForegroundDebris", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForegroundDebris",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Trapdoor", "Celeste.Trapdoor", "Trapdoor", assemblyIdentity,
                "Celeste", 33555150, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Trapdoor", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Trapdoor",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OldSiteChaseMusicHandler", "Celeste.OldSiteChaseMusicHandler",
                "OldSiteChaseMusicHandler", assemblyIdentity, "Celeste", 33555151, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OldSiteChaseMusicHandler", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OldSiteChaseMusicHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PicoConsole", "Celeste.PicoConsole", "PicoConsole",
                assemblyIdentity,
                "Celeste", 33555152, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PicoConsole", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PicoConsole",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror", "Celeste.ResortMirror", "ResortMirror",
                assemblyIdentity, "Celeste", 33555153, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ResortRoofEnding", "Celeste.ResortRoofEnding", "ResortRoofEnding",
                assemblyIdentity, "Celeste", 33555154, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ResortRoofEnding", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ResortRoofEnding",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy", "Celeste.BadelineDummy", "BadelineDummy",
                assemblyIdentity, "Celeste", 33555155, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Bonfire", "Celeste.Bonfire", "Bonfire", assemblyIdentity,
                "Celeste",
                33555156, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Bonfire", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Bonfire",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror", "Celeste.DreamMirror", "DreamMirror",
                assemblyIdentity,
                "Celeste", 33555157, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Payphone", "Celeste.Payphone", "Payphone", assemblyIdentity,
                "Celeste", 33555158, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Payphone", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Payphone",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Lookout", "Celeste.Lookout", "Lookout", assemblyIdentity,
                "Celeste",
                33555159, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Lookout", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Lookout",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal", "Celeste.TempleMirrorPortal",
                "TempleMirrorPortal", assemblyIdentity, "Celeste", 33555160, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SwapBlock", "Celeste.SwapBlock", "SwapBlock", assemblyIdentity,
                "Celeste", 33555161, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SwapBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SwapBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleGate", "Celeste.TempleGate", "TempleGate", assemblyIdentity,
                "Celeste", 33555162, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleGate", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Torch", "Celeste.Torch", "Torch", assemblyIdentity, "Celeste",
                33555163, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Torch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Torch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AltMusicTrigger", "Celeste.AltMusicTrigger", "AltMusicTrigger",
                assemblyIdentity, "Celeste", 33555164, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AltMusicTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AltMusicTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MusicTrigger", "Celeste.MusicTrigger", "MusicTrigger",
                assemblyIdentity, "Celeste", 33555165, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MusicTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MusicTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindAttackTrigger", "Celeste.WindAttackTrigger",
                "WindAttackTrigger",
                assemblyIdentity, "Celeste", 33555166, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindAttackTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindAttackTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindTrigger", "Celeste.WindTrigger", "WindTrigger",
                assemblyIdentity,
                "Celeste", 33555167, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Selfie", "Celeste.Selfie", "Selfie", assemblyIdentity, "Celeste",
                33555168, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Selfie", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Selfie",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TotalStrawberriesDisplay", "Celeste.TotalStrawberriesDisplay",
                "TotalStrawberriesDisplay", assemblyIdentity, "Celeste", 33555169, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TotalStrawberriesDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TotalStrawberriesDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindController", "Celeste.WindController", "WindController",
                assemblyIdentity, "Celeste", 33555170, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindController", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamStars", "Celeste.DreamStars", "DreamStars", assemblyIdentity,
                "Celeste", 33555171, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamStars", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamStars",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Autotiler", "Celeste.Autotiler", "Autotiler", assemblyIdentity,
                "Celeste", 33555172, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Autotiler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Autotiler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarsBG", "Celeste.StarsBG", "StarsBG", assemblyIdentity,
                "Celeste",
                33555173, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarsBG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarsBG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindSnowFG", "Celeste.WindSnowFG", "WindSnowFG", assemblyIdentity,
                "Celeste", 33555174, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindSnowFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindSnowFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BirdTutorialGui", "Celeste.BirdTutorialGui", "BirdTutorialGui",
                assemblyIdentity, "Celeste", 33555175, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BirdTutorialGui", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BirdTutorialGui",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Decal", "Celeste.Decal", "Decal", assemblyIdentity, "Celeste",
                33555176, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Decal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Decal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightBeam", "Celeste.LightBeam", "LightBeam", assemblyIdentity,
                "Celeste", 33555177, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightBeam", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightBeam",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustEdges", "Celeste.DustEdges", "DustEdges", assemblyIdentity,
                "Celeste", 33555178, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustEdges", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustEdges",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Textbox", "Celeste.Textbox", "Textbox", assemblyIdentity,
                "Celeste",
                33555179, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Textbox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Textbox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BestTimeDisplay", "Celeste.BestTimeDisplay", "BestTimeDisplay",
                assemblyIdentity, "Celeste", 33555180, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BestTimeDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BestTimeDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathsCounter", "Celeste.DeathsCounter", "DeathsCounter",
                assemblyIdentity, "Celeste", 33555181, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathsCounter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathsCounter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGemDisplay", "Celeste.HeartGemDisplay", "HeartGemDisplay",
                assemblyIdentity, "Celeste", 33555182, false, ["Monocle.Component", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGemDisplay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGemDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunTimerDisplay", "Celeste.SpeedrunTimerDisplay",
                "SpeedrunTimerDisplay", assemblyIdentity, "Celeste", 33555183, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunTimerDisplay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunTimerDisplay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StrawberriesCounter", "Celeste.StrawberriesCounter",
                "StrawberriesCounter", assemblyIdentity, "Celeste", 33555184, false,
                ["Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StrawberriesCounter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StrawberriesCounter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FadeWipe", "Celeste.FadeWipe", "FadeWipe", assemblyIdentity,
                "Celeste", 33555185, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FadeWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FadeWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WindWipe", "Celeste.WindWipe", "WindWipe", assemblyIdentity,
                "Celeste", 33555186, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WindWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WindWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CurtainWipe", "Celeste.CurtainWipe", "CurtainWipe",
                assemblyIdentity,
                "Celeste", 33555187, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CurtainWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CurtainWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpotlightWipe", "Celeste.SpotlightWipe", "SpotlightWipe",
                assemblyIdentity, "Celeste", 33555188, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpotlightWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpotlightWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaComplete", "Celeste.AreaComplete", "AreaComplete",
                assemblyIdentity, "Celeste", 33555189, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaComplete", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaComplete",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewPortrait", "Celeste.PreviewPortrait", "PreviewPortrait",
                assemblyIdentity, "Celeste", 33555190, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewPortrait", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPortrait",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Billboard", "Celeste.Billboard", "Billboard", assemblyIdentity,
                "Celeste", 33555191, false, ["Monocle.Component", "System.Object"], [true],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Billboard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Billboard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainRenderer", "Celeste.MountainRenderer", "MountainRenderer",
                assemblyIdentity, "Celeste", 33555192, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overworld", "Celeste.Overworld", "Overworld", assemblyIdentity,
                "Celeste", 33555193, false,
                [
                    "Monocle.Scene", "Celeste.IOverlayHandler", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overworld", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overworld",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterPanel", "Celeste.OuiChapterPanel", "OuiChapterPanel",
                assemblyIdentity, "Celeste", 33555194, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterPanel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterPanel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelect", "Celeste.OuiChapterSelect", "OuiChapterSelect",
                assemblyIdentity, "Celeste", 33555195, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelect", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileNaming", "Celeste.OuiFileNaming", "OuiFileNaming",
                assemblyIdentity, "Celeste", 33555196, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileNaming", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileNaming",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelect", "Celeste.OuiFileSelect", "OuiFileSelect",
                assemblyIdentity, "Celeste", 33555197, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelect", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiMainMenu", "Celeste.OuiMainMenu", "OuiMainMenu",
                assemblyIdentity,
                "Celeste", 33555198, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiMainMenu", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiMainMenu",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiOptions", "Celeste.OuiOptions", "OuiOptions", assemblyIdentity,
                "Celeste", 33555199, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiOptions", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiOptions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiTitleScreen", "Celeste.OuiTitleScreen", "OuiTitleScreen",
                assemblyIdentity, "Celeste", 33555200, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiTitleScreen", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiTitleScreen",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Oui", "Celeste.Oui", "Oui", assemblyIdentity, "Celeste", 33555201,
                true,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Oui", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Oui",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Poem", "Celeste.Poem", "Poem", assemblyIdentity, "Celeste",
                33555202,
                false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Poem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Poem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TestWipes", "Celeste.TestWipes", "TestWipes", assemblyIdentity,
                "Celeste", 33555203, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TestWipes", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TestWipes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SummitVignette", "Celeste.SummitVignette", "SummitVignette",
                assemblyIdentity, "Celeste", 33555204, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SummitVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SummitVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FancyText", "Celeste.FancyText", "FancyText", assemblyIdentity,
                "Celeste", 33555205, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FancyText", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FancyText",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MTN", "Celeste.MTN", "MTN", assemblyIdentity, "Celeste", 33555206,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MTN", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MTN",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlaybackData", "Celeste.PlaybackData", "PlaybackData",
                assemblyIdentity, "Celeste", 33555207, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlaybackData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlaybackData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayBuffers", "Celeste.GameplayBuffers", "GameplayBuffers",
                assemblyIdentity, "Celeste", 33555208, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayBuffers", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayBuffers",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockGenerator", "Celeste.ClutterBlockGenerator",
                "ClutterBlockGenerator", assemblyIdentity, "Celeste", 33555209, true, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockGenerator", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockGenerator",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ColorGrade", "Celeste.ColorGrade", "ColorGrade", assemblyIdentity,
                "Celeste", 33555210, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ColorGrade", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ColorGrade",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Commands", "Celeste.Commands", "Commands", assemblyIdentity,
                "Celeste", 33555211, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Commands", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Commands",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Depths", "Celeste.Depths", "Depths", assemblyIdentity, "Celeste",
                33555212, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Depths", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Depths",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Dialog", "Celeste.Dialog", "Dialog", assemblyIdentity, "Celeste",
                33555213, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Dialog", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Dialog",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Audio", "Celeste.Audio", "Audio", assemblyIdentity, "Celeste",
                33555214, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Audio", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Audio",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Fonts", "Celeste.Fonts", "Fonts", assemblyIdentity, "Celeste",
                33555215, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Fonts", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Fonts",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ActiveFont", "Celeste.ActiveFont", "ActiveFont", assemblyIdentity,
                "Celeste", 33555216, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ActiveFont", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ActiveFont",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameplayRenderer", "Celeste.GameplayRenderer", "GameplayRenderer",
                assemblyIdentity, "Celeste", 33555217, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameplayRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameplayRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HudRenderer", "Celeste.HudRenderer", "HudRenderer",
                assemblyIdentity,
                "Celeste", 33555218, false, ["Celeste.HiresRenderer", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HudRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HudRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Glitch", "Celeste.Glitch", "Glitch", assemblyIdentity, "Celeste",
                33555219, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Glitch", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Glitch",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MenuOptions", "Celeste.MenuOptions", "MenuOptions",
                assemblyIdentity,
                "Celeste", 33555220, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MenuOptions", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MenuOptions",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ParticleTypes", "Celeste.ParticleTypes", "ParticleTypes",
                assemblyIdentity, "Celeste", 33555221, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ParticleTypes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ParticleTypes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DeathData", "Celeste.DeathData", "DeathData", assemblyIdentity,
                "Celeste", 33555222, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DeathData", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DeathData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PlayerInventory", "Celeste.PlayerInventory", "PlayerInventory",
                assemblyIdentity, "Celeste", 33555223, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PlayerInventory", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PlayerInventory",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveData", "Celeste.SaveData", "SaveData", assemblyIdentity,
                "Celeste", 33555224, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveData", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveData",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Session", "Celeste.Session", "Session", assemblyIdentity,
                "Celeste",
                33555225, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Session", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Session",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.EntityID", "Celeste.EntityID", "EntityID", assemblyIdentity,
                "Celeste", 33555226, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.EntityID", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.EntityID",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.RumbleAmount", "Celeste.RumbleAmount", "RumbleAmount",
                assemblyIdentity, "Celeste", 33555227, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.RumbleAmount", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.RumbleAmount",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SpeedrunType", "Celeste.SpeedrunType", "SpeedrunType",
                assemblyIdentity, "Celeste", 33555228, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SpeedrunType", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SpeedrunType",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ScreenshakeAmount", "Celeste.ScreenshakeAmount",
                "ScreenshakeAmount",
                assemblyIdentity, "Celeste", 33555229, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ScreenshakeAmount", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ScreenshakeAmount",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GrabModes", "Celeste.GrabModes", "GrabModes", assemblyIdentity,
                "Celeste", 33555230, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GrabModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GrabModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CrouchDashModes", "Celeste.CrouchDashModes", "CrouchDashModes",
                assemblyIdentity, "Celeste", 33555231, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CrouchDashModes", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CrouchDashModes",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Settings", "Celeste.Settings", "Settings", assemblyIdentity,
                "Celeste", 33555232, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Settings", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Settings",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Assists", "Celeste.Assists", "Assists", assemblyIdentity,
                "Celeste",
                33555233, false, ["System.ValueType"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Assists", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Assists",
                []);
        }
    }
}
