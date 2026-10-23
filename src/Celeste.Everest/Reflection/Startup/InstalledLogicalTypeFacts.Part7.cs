using System;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup;

public static partial class InstalledLogicalTypeFacts
{
    private static void RegisterPart7(SceneEntityCatalog catalog, string assemblyIdentity,
        Celeste.Core.Reflection.ISourceAssemblyMetadata assembly)
    {
        catalog.RegisterLogicalTypeFacts("Celeste.WaterFall", "Celeste.WaterFall", "WaterFall", assemblyIdentity,
            "Celeste", 33555834, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaterFall", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaterFall",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ParticleRenderer", "Celeste.ParticleRenderer", "ParticleRenderer",
            assemblyIdentity, "Celeste", 33555835, false, new string[] { "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ParticleRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ParticleRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WaterSurface", "Celeste.WaterSurface", "WaterSurface",
            assemblyIdentity, "Celeste", 33555836, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WaterSurface", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.WaterSurface",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamWipe", "Celeste.DreamWipe", "DreamWipe", assemblyIdentity,
            "Celeste", 33555837, false, new string[] { "Celeste.ScreenWipe", "Monocle.Renderer", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamWipe", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamWipe",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamWipe+Circle", "Celeste.DreamWipe.Circle", "Circle",
            assemblyIdentity, "Celeste", 33555838, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamWipe.Circle", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamWipe.Circle",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot", "Celeste.OuiFileSelectSlot", "OuiFileSelectSlot",
            assemblyIdentity, "Celeste", 33555839, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+Button", "Celeste.OuiFileSelectSlot.Button",
            "Button", assemblyIdentity, "Celeste", 33555840, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.Button", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.Button",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c", "Celeste.OuiFileSelectSlot.<>c", "<>c",
            assemblyIdentity, "Celeste", 33555841, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68",
            "Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__68", "<EnterFirstAreaRoutine>d__68", assemblyIdentity,
            "Celeste", 33555842, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__68", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__68",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass73_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass73_0", "<>c__DisplayClass73_0", assemblyIdentity, "Celeste",
            33555843, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass73_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass73_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass74_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass74_0", "<>c__DisplayClass74_0", assemblyIdentity, "Celeste",
            33555844, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass74_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass74_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass75_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass75_0", "<>c__DisplayClass75_0", assemblyIdentity, "Celeste",
            33555845, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass75_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass75_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass76_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass76_0", "<>c__DisplayClass76_0", assemblyIdentity, "Celeste",
            33555846, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass76_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass76_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass77_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass77_0", "<>c__DisplayClass77_0", assemblyIdentity, "Celeste",
            33555847, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass77_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass77_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass78_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass78_0", "<>c__DisplayClass78_0", assemblyIdentity, "Celeste",
            33555848, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass78_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass78_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+ISubmenu", "Celeste.OuiFileSelectSlot.ISubmenu",
            "ISubmenu", assemblyIdentity, "Celeste", 33555849, true, Array.Empty<string>(), Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.ISubmenu", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.ISubmenu",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass43_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass43_0", "<>c__DisplayClass43_0", assemblyIdentity, "Celeste",
            33555850, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass43_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass43_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<>c__DisplayClass53_0",
            "Celeste.OuiFileSelectSlot.<>c__DisplayClass53_0", "<>c__DisplayClass53_0", assemblyIdentity, "Celeste",
            33555851, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<>c__DisplayClass53_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<>c__DisplayClass53_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47",
            "Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__47", "<EnterFirstAreaRoutine>d__47", assemblyIdentity,
            "Celeste", 33555852, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__47", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiFileSelectSlot.<EnterFirstAreaRoutine>d__47",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon", "Celeste.OuiChapterSelectIcon",
            "OuiChapterSelectIcon", assemblyIdentity, "Celeste", 33555853, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<>c__DisplayClass31_0",
            "Celeste.OuiChapterSelectIcon.<>c__DisplayClass31_0", "<>c__DisplayClass31_0", assemblyIdentity, "Celeste",
            33555854, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<>c__DisplayClass31_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<>c__DisplayClass31_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<>c__DisplayClass33_0",
            "Celeste.OuiChapterSelectIcon.<>c__DisplayClass33_0", "<>c__DisplayClass33_0", assemblyIdentity, "Celeste",
            33555855, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<>c__DisplayClass33_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<>c__DisplayClass33_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<>c__DisplayClass34_0",
            "Celeste.OuiChapterSelectIcon.<>c__DisplayClass34_0", "<>c__DisplayClass34_0", assemblyIdentity, "Celeste",
            33555856, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<>c__DisplayClass34_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<>c__DisplayClass34_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<>c__DisplayClass35_0",
            "Celeste.OuiChapterSelectIcon.<>c__DisplayClass35_0", "<>c__DisplayClass35_0", assemblyIdentity, "Celeste",
            33555857, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<>c__DisplayClass35_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<>c__DisplayClass35_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37",
            "Celeste.OuiChapterSelectIcon.<AssistModeUnlockRoutine>d__37", "<AssistModeUnlockRoutine>d__37",
            assemblyIdentity, "Celeste", 33555858, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<AssistModeUnlockRoutine>d__37", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<AssistModeUnlockRoutine>d__37",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39",
            "Celeste.OuiChapterSelectIcon.<HighlightUnlockRoutine>d__39", "<HighlightUnlockRoutine>d__39",
            assemblyIdentity, "Celeste", 33555859, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.<HighlightUnlockRoutine>d__39", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.<HighlightUnlockRoutine>d__39",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta",
            "Celeste.OuiChapterSelectIcon.AnimatedMapIconMeta", "AnimatedMapIconMeta", assemblyIdentity, "Celeste",
            33555860, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiChapterSelectIcon.AnimatedMapIconMeta", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiChapterSelectIcon.AnimatedMapIconMeta",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal", "Celeste.OuiJournal", "OuiJournal", assemblyIdentity,
            "Celeste", 33555861, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal+<Enter>d__26", "Celeste.OuiJournal.<Enter>d__26",
            "<Enter>d__26", assemblyIdentity, "Celeste", 33555862, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal.<Enter>d__26", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal.<Enter>d__26",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal+<TurnPage>d__28", "Celeste.OuiJournal.<TurnPage>d__28",
            "<TurnPage>d__28", assemblyIdentity, "Celeste", 33555863, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal.<TurnPage>d__28", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal.<TurnPage>d__28",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal+<Leave>d__29", "Celeste.OuiJournal.<Leave>d__29",
            "<Leave>d__29", assemblyIdentity, "Celeste", 33555864, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal.<Leave>d__29", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal.<Leave>d__29",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal+<EaseOut>d__30", "Celeste.OuiJournal.<EaseOut>d__30",
            "<EaseOut>d__30", assemblyIdentity, "Celeste", 33555865, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal.<EaseOut>d__30", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal.<EaseOut>d__30",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournal+<Enter>d__1", "Celeste.OuiJournal.<Enter>d__1",
            "<Enter>d__1", assemblyIdentity, "Celeste", 33555866, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                "System.Collections.IEnumerator", "System.IDisposable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournal.<Enter>d__1", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournal.<Enter>d__1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalCover", "Celeste.OuiJournalCover", "OuiJournalCover",
            assemblyIdentity, "Celeste", 33555867, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalCover", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalCover",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage", "Celeste.OuiJournalPage", "OuiJournalPage",
            assemblyIdentity, "Celeste", 33555868, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+Table", "Celeste.OuiJournalPage.Table", "Table",
            assemblyIdentity, "Celeste", 33555869, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.Table", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.Table",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+Row", "Celeste.OuiJournalPage.Row", "Row",
            assemblyIdentity, "Celeste", 33555870, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.Row", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.Row",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+Cell", "Celeste.OuiJournalPage.Cell", "Cell",
            assemblyIdentity, "Celeste", 33555871, true, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.Cell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.Cell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+EmptyCell", "Celeste.OuiJournalPage.EmptyCell",
            "EmptyCell", assemblyIdentity, "Celeste", 33555872, false,
            new string[] { "Celeste.OuiJournalPage+Cell", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.EmptyCell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.EmptyCell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+TextCell", "Celeste.OuiJournalPage.TextCell",
            "TextCell", assemblyIdentity, "Celeste", 33555873, false,
            new string[] { "Celeste.OuiJournalPage+Cell", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.TextCell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.TextCell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+IconCell", "Celeste.OuiJournalPage.IconCell",
            "IconCell", assemblyIdentity, "Celeste", 33555874, false,
            new string[] { "Celeste.OuiJournalPage+Cell", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.IconCell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.IconCell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPage+IconsCell", "Celeste.OuiJournalPage.IconsCell",
            "IconsCell", assemblyIdentity, "Celeste", 33555875, false,
            new string[] { "Celeste.OuiJournalPage+Cell", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPage.IconsCell", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPage.IconsCell",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem", "Celeste.OuiJournalPoem", "OuiJournalPoem",
            assemblyIdentity, "Celeste", 33555876, false, new string[] { "Celeste.OuiJournalPage", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem+PoemLine", "Celeste.OuiJournalPoem.PoemLine",
            "PoemLine", assemblyIdentity, "Celeste", 33555877, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem.PoemLine", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem.PoemLine",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem+<>c__DisplayClass17_0",
            "Celeste.OuiJournalPoem.<>c__DisplayClass17_0", "<>c__DisplayClass17_0", assemblyIdentity, "Celeste",
            33555878, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem.<>c__DisplayClass17_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem.<>c__DisplayClass17_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalPoem+<Swap>d__17", "Celeste.OuiJournalPoem.<Swap>d__17",
            "<Swap>d__17", assemblyIdentity, "Celeste", 33555879, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalPoem.<Swap>d__17", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalPoem.<Swap>d__17",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalSpeedrun", "Celeste.OuiJournalSpeedrun",
            "OuiJournalSpeedrun", assemblyIdentity, "Celeste", 33555880, false,
            new string[] { "Celeste.OuiJournalPage", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalSpeedrun", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalSpeedrun",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalProgress", "Celeste.OuiJournalProgress",
            "OuiJournalProgress", assemblyIdentity, "Celeste", 33555881, false,
            new string[] { "Celeste.OuiJournalPage", "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalProgress", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalProgress",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MainMenuSmallButton", "Celeste.MainMenuSmallButton",
            "MainMenuSmallButton", assemblyIdentity, "Celeste", 33555882, false,
            new string[]
            {
                "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MainMenuSmallButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuSmallButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MenuButton", "Celeste.MenuButton", "MenuButton", assemblyIdentity,
            "Celeste", 33555883, true,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { true }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MenuButton", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MenuButton",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MenuButton+<>c__DisplayClass15_0",
            "Celeste.MenuButton.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste", 33555884,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MenuButton.<>c__DisplayClass15_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MenuButton.<>c__DisplayClass15_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MenuButton+<>c__DisplayClass16_0",
            "Celeste.MenuButton.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste", 33555885,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MenuButton.<>c__DisplayClass16_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MenuButton.<>c__DisplayClass16_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MainMenuClimb", "Celeste.MainMenuClimb", "MainMenuClimb",
            assemblyIdentity, "Celeste", 33555886, false,
            new string[]
            {
                "Celeste.MenuButton", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MainMenuClimb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MainMenuClimb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiCredits", "Celeste.OuiCredits", "OuiCredits", assemblyIdentity,
            "Celeste", 33555887, false,
            new string[]
            {
                "Celeste.Oui", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiCredits", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiCredits",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiCredits+<Enter>d__5", "Celeste.OuiCredits.<Enter>d__5",
            "<Enter>d__5", assemblyIdentity, "Celeste", 33555888, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiCredits.<Enter>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiCredits.<Enter>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OuiCredits+<Leave>d__6", "Celeste.OuiCredits.<Leave>d__6",
            "<Leave>d__6", assemblyIdentity, "Celeste", 33555889, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OuiCredits.<Leave>d__6", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.OuiCredits.<Leave>d__6",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IntroVignette", "Celeste.IntroVignette", "IntroVignette",
            assemblyIdentity, "Celeste", 33555890, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IntroVignette", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.IntroVignette",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IntroVignette+<TextSequence>d__19",
            "Celeste.IntroVignette.<TextSequence>d__19", "<TextSequence>d__19", assemblyIdentity, "Celeste", 33555891,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IntroVignette.<TextSequence>d__19", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.IntroVignette.<TextSequence>d__19",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.IntroVignette+<>c__DisplayClass24_0",
            "Celeste.IntroVignette.<>c__DisplayClass24_0", "<>c__DisplayClass24_0", assemblyIdentity, "Celeste",
            33555892, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.IntroVignette.<>c__DisplayClass24_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.IntroVignette.<>c__DisplayClass24_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelLoader", "Celeste.LevelLoader", "LevelLoader", assemblyIdentity,
            "Celeste", 33555893, false,
            new string[]
            {
                "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelLoader", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelLoader",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LevelLoader+<>c", "Celeste.LevelLoader.<>c", "<>c", assemblyIdentity,
            "Celeste", 33555894, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LevelLoader.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.LevelLoader.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerDeadBody", "Celeste.PlayerDeadBody", "PlayerDeadBody",
            assemblyIdentity, "Celeste", 33555895, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerDeadBody", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDeadBody",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerDeadBody+<>c__DisplayClass15_0",
            "Celeste.PlayerDeadBody.<>c__DisplayClass15_0", "<>c__DisplayClass15_0", assemblyIdentity, "Celeste",
            33555896, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerDeadBody.<>c__DisplayClass15_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDeadBody.<>c__DisplayClass15_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PlayerDeadBody+<DeathRoutine>d__15",
            "Celeste.PlayerDeadBody.<DeathRoutine>d__15", "<DeathRoutine>d__15", assemblyIdentity, "Celeste", 33555897,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PlayerDeadBody.<DeathRoutine>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PlayerDeadBody.<DeathRoutine>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaMode", "Celeste.AreaMode", "AreaMode", assemblyIdentity,
            "Celeste", 33555898, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaMode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaMode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaKey", "Celeste.AreaKey", "AreaKey", assemblyIdentity, "Celeste",
            33555899, false, new string[] { "System.ValueType" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaKey", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaKey",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ModeProperties", "Celeste.ModeProperties", "ModeProperties",
            assemblyIdentity, "Celeste", 33555900, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ModeProperties", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ModeProperties",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData", "Celeste.AreaData", "AreaData", assemblyIdentity,
            "Celeste", 33555901, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData+<>c", "Celeste.AreaData.<>c", "<>c", assemblyIdentity,
            "Celeste", 33555902, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData+<>O", "Celeste.AreaData.<>O", "<>O", assemblyIdentity,
            "Celeste", 33555903, true, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData.<>O", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData.<>O",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData+<>c__DisplayClass29_0",
            "Celeste.AreaData.<>c__DisplayClass29_0", "<>c__DisplayClass29_0", assemblyIdentity, "Celeste", 33555904,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData.<>c__DisplayClass29_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData.<>c__DisplayClass29_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData+<>c__DisplayClass31_0",
            "Celeste.AreaData.<>c__DisplayClass31_0", "<>c__DisplayClass31_0", assemblyIdentity, "Celeste", 33555905,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData.<>c__DisplayClass31_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData.<>c__DisplayClass31_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaData+<>c__DisplayClass31_1",
            "Celeste.AreaData.<>c__DisplayClass31_1", "<>c__DisplayClass31_1", assemblyIdentity, "Celeste", 33555906,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaData.<>c__DisplayClass31_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaData.<>c__DisplayClass31_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.CheckpointData", "Celeste.CheckpointData", "CheckpointData",
            assemblyIdentity, "Celeste", 33555907, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.CheckpointData", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.CheckpointData",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaModeStats", "Celeste.AreaModeStats", "AreaModeStats",
            assemblyIdentity, "Celeste", 33555908, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaModeStats", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaModeStats",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AreaStats", "Celeste.AreaStats", "AreaStats", assemblyIdentity,
            "Celeste", 33555909, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AreaStats", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AreaStats",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste._3dSoundTest", "Celeste._3dSoundTest", "_3dSoundTest",
            assemblyIdentity, "Celeste", 33555910, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste._3dSoundTest", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste._3dSoundTest",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BlockField", "Celeste.BlockField", "BlockField", assemblyIdentity,
            "Celeste", 33555911, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BlockField", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BlockField",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Booster", "Celeste.Booster", "Booster", assemblyIdentity, "Celeste",
            33555912, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Booster", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Booster",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Booster+<BoostRoutine>d__31", "Celeste.Booster.<BoostRoutine>d__31",
            "<BoostRoutine>d__31", assemblyIdentity, "Celeste", 33555913, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Booster.<BoostRoutine>d__31", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Booster.<BoostRoutine>d__31",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Checkpoint", "Celeste.Checkpoint", "Checkpoint", assemblyIdentity,
            "Celeste", 33555914, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Checkpoint", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Checkpoint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Checkpoint+<EaseLightsOn>d__18",
            "Celeste.Checkpoint.<EaseLightsOn>d__18", "<EaseLightsOn>d__18", assemblyIdentity, "Celeste", 33555915,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Checkpoint.<EaseLightsOn>d__18", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Checkpoint.<EaseLightsOn>d__18",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cloud", "Celeste.Cloud", "Cloud", assemblyIdentity, "Celeste",
            33555916, false,
            new string[]
            {
                "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cloud", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cloud",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlock", "Celeste.ClutterBlock", "ClutterBlock",
            assemblyIdentity, "Celeste", 33555917, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlock+Colors", "Celeste.ClutterBlock.Colors", "Colors",
            assemblyIdentity, "Celeste", 33555918, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlock.Colors", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlock.Colors",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterBlockBase", "Celeste.ClutterBlockBase", "ClutterBlockBase",
            assemblyIdentity, "Celeste", 33555919, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterBlockBase", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterBlockBase",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterDoor", "Celeste.ClutterDoor", "ClutterDoor", assemblyIdentity,
            "Celeste", 33555920, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterDoor+<UnlockRoutine>d__7",
            "Celeste.ClutterDoor.<UnlockRoutine>d__7", "<UnlockRoutine>d__7", assemblyIdentity, "Celeste", 33555921,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterDoor.<UnlockRoutine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterDoor.<UnlockRoutine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch", "Celeste.ClutterSwitch", "ClutterSwitch",
            assemblyIdentity, "Celeste", 33555922, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch+<LightningRoutine>d__25",
            "Celeste.ClutterSwitch.<LightningRoutine>d__25", "<LightningRoutine>d__25", assemblyIdentity, "Celeste",
            33555923, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch.<LightningRoutine>d__25", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch.<LightningRoutine>d__25",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch+<>c__DisplayClass26_0",
            "Celeste.ClutterSwitch.<>c__DisplayClass26_0", "<>c__DisplayClass26_0", assemblyIdentity, "Celeste",
            33555924, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch.<>c__DisplayClass26_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch.<>c__DisplayClass26_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch+<>c__DisplayClass26_1",
            "Celeste.ClutterSwitch.<>c__DisplayClass26_1", "<>c__DisplayClass26_1", assemblyIdentity, "Celeste",
            33555925, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch.<>c__DisplayClass26_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch.<>c__DisplayClass26_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch+<>c__DisplayClass26_2",
            "Celeste.ClutterSwitch.<>c__DisplayClass26_2", "<>c__DisplayClass26_2", assemblyIdentity, "Celeste",
            33555926, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch.<>c__DisplayClass26_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch.<>c__DisplayClass26_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterSwitch+<AbsorbRoutine>d__26",
            "Celeste.ClutterSwitch.<AbsorbRoutine>d__26", "<AbsorbRoutine>d__26", assemblyIdentity, "Celeste", 33555927,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterSwitch.<AbsorbRoutine>d__26", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterSwitch.<AbsorbRoutine>d__26",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect", "Celeste.ClutterAbsorbEffect",
            "ClutterAbsorbEffect", assemblyIdentity, "Celeste", 33555928, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5",
            "Celeste.ClutterAbsorbEffect.<FlyClutterRoutine>d__5", "<FlyClutterRoutine>d__5", assemblyIdentity,
            "Celeste", 33555929, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect.<FlyClutterRoutine>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect.<FlyClutterRoutine>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect+<>c", "Celeste.ClutterAbsorbEffect.<>c", "<>c",
            assemblyIdentity, "Celeste", 33555930, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect.<>c", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect.<>c",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7",
            "Celeste.ClutterAbsorbEffect.<CloseCabinetsRoutine>d__7", "<CloseCabinetsRoutine>d__7", assemblyIdentity,
            "Celeste", 33555931, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ClutterAbsorbEffect.<CloseCabinetsRoutine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ClutterAbsorbEffect.<CloseCabinetsRoutine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DashListener", "Celeste.DashListener", "DashListener",
            assemblyIdentity, "Celeste", 33555932, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DashListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DashListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.LedgeBlocker", "Celeste.LedgeBlocker", "LedgeBlocker",
            assemblyIdentity, "Celeste", 33555933, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.LedgeBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.LedgeBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic", "Celeste.DustGraphic", "DustGraphic", assemblyIdentity,
            "Celeste", 33555934, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic+Node", "Celeste.DustGraphic.Node", "Node",
            assemblyIdentity, "Celeste", 33555935, false, new string[] { "System.Object" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic.Node", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic.Node",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic+Eyeballs", "Celeste.DustGraphic.Eyeballs", "Eyeballs",
            assemblyIdentity, "Celeste", 33555936, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic.Eyeballs", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic.Eyeballs",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustGraphic+<BlinkRoutine>d__45",
            "Celeste.DustGraphic.<BlinkRoutine>d__45", "<BlinkRoutine>d__45", assemblyIdentity, "Celeste", 33555937,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustGraphic.<BlinkRoutine>d__45", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustGraphic.<BlinkRoutine>d__45",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SafeGroundBlocker", "Celeste.SafeGroundBlocker", "SafeGroundBlocker",
            assemblyIdentity, "Celeste", 33555938, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SafeGroundBlocker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SafeGroundBlocker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SoundSource", "Celeste.SoundSource", "SoundSource", assemblyIdentity,
            "Celeste", 33555939, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SoundSource", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.SoundSource",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TalkComponent", "Celeste.TalkComponent", "TalkComponent",
            assemblyIdentity, "Celeste", 33555940, false, new string[] { "Monocle.Component", "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TalkComponent", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TalkComponent",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TalkComponent+HoverDisplay", "Celeste.TalkComponent.HoverDisplay",
            "HoverDisplay", assemblyIdentity, "Celeste", 33555941, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TalkComponent.HoverDisplay", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TalkComponent.HoverDisplay",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TalkComponent+TalkComponentUI",
            "Celeste.TalkComponent.TalkComponentUI", "TalkComponentUI", assemblyIdentity, "Celeste", 33555942, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TalkComponent.TalkComponentUI", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TalkComponent.TalkComponentUI",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TileInterceptor", "Celeste.TileInterceptor", "TileInterceptor",
            assemblyIdentity, "Celeste", 33555943, false, new string[] { "Monocle.Component", "System.Object" },
            new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TileInterceptor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TileInterceptor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TileInterceptor+<>c__DisplayClass3_0",
            "Celeste.TileInterceptor.<>c__DisplayClass3_0", "<>c__DisplayClass3_0", assemblyIdentity, "Celeste",
            33555944, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TileInterceptor.<>c__DisplayClass3_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TileInterceptor.<>c__DisplayClass3_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TransitionListener", "Celeste.TransitionListener",
            "TransitionListener", assemblyIdentity, "Celeste", 33555945, false,
            new string[] { "Monocle.Component", "System.Object" }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TransitionListener", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.TransitionListener",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindMover", "Celeste.WindMover", "WindMover", assemblyIdentity,
            "Celeste", 33555946, false, new string[] { "Monocle.Component", "System.Object" }, new bool[] { false },
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindMover", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindMover",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker", "Celeste.Seeker", "Seeker", assemblyIdentity, "Celeste",
            33555947, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+PatrolPoint", "Celeste.Seeker.PatrolPoint", "PatrolPoint",
            assemblyIdentity, "Celeste", 33555948, false, new string[] { "System.ValueType" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.PatrolPoint", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.PatrolPoint",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+RecoverBlast", "Celeste.Seeker.RecoverBlast", "RecoverBlast",
            assemblyIdentity, "Celeste", 33555949, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.RecoverBlast", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.RecoverBlast",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<>c__DisplayClass58_0", "Celeste.Seeker.<>c__DisplayClass58_0",
            "<>c__DisplayClass58_0", assemblyIdentity, "Celeste", 33555950, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<>c__DisplayClass58_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<>c__DisplayClass58_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<IdleCoroutine>d__91", "Celeste.Seeker.<IdleCoroutine>d__91",
            "<IdleCoroutine>d__91", assemblyIdentity, "Celeste", 33555951, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<IdleCoroutine>d__91", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<IdleCoroutine>d__91",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<SpottedCoroutine>d__113",
            "Celeste.Seeker.<SpottedCoroutine>d__113", "<SpottedCoroutine>d__113", assemblyIdentity, "Celeste",
            33555952, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<SpottedCoroutine>d__113", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<SpottedCoroutine>d__113",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<AttackCoroutine>d__127",
            "Celeste.Seeker.<AttackCoroutine>d__127", "<AttackCoroutine>d__127", assemblyIdentity, "Celeste", 33555953,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<AttackCoroutine>d__127", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<AttackCoroutine>d__127",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<StunnedCoroutine>d__131",
            "Celeste.Seeker.<StunnedCoroutine>d__131", "<StunnedCoroutine>d__131", assemblyIdentity, "Celeste",
            33555954, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<StunnedCoroutine>d__131", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<StunnedCoroutine>d__131",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<SkiddingCoroutine>d__138",
            "Celeste.Seeker.<SkiddingCoroutine>d__138", "<SkiddingCoroutine>d__138", assemblyIdentity, "Celeste",
            33555955, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<SkiddingCoroutine>d__138", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<SkiddingCoroutine>d__138",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<RegenerateCoroutine>d__143",
            "Celeste.Seeker.<RegenerateCoroutine>d__143", "<RegenerateCoroutine>d__143", assemblyIdentity, "Celeste",
            33555956, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<RegenerateCoroutine>d__143", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<RegenerateCoroutine>d__143",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Seeker+<ReturnedCoroutine>d__144",
            "Celeste.Seeker.<ReturnedCoroutine>d__144", "<ReturnedCoroutine>d__144", assemblyIdentity, "Celeste",
            33555957, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Seeker.<ReturnedCoroutine>d__144", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Seeker.<ReturnedCoroutine>d__144",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustStaticSpinner", "Celeste.DustStaticSpinner", "DustStaticSpinner",
            assemblyIdentity, "Celeste", 33555958, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustStaticSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustStaticSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DustTrackSpinner", "Celeste.DustTrackSpinner", "DustTrackSpinner",
            assemblyIdentity, "Celeste", 33555959, false,
            new string[]
            {
                "Celeste.TrackSpinner", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DustTrackSpinner", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DustTrackSpinner",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Snowball", "Celeste.Snowball", "Snowball", assemblyIdentity,
            "Celeste", 33555960, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Snowball", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Snowball",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DashSwitch", "Celeste.DashSwitch", "DashSwitch", assemblyIdentity,
            "Celeste", 33555961, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DashSwitch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DashSwitch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DashSwitch+Sides", "Celeste.DashSwitch.Sides", "Sides",
            assemblyIdentity, "Celeste", 33555962, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DashSwitch.Sides", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DashSwitch.Sides",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Cobweb", "Celeste.Cobweb", "Cobweb", assemblyIdentity, "Celeste",
            33555963, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Cobweb", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Cobweb",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortLantern", "Celeste.ResortLantern", "ResortLantern",
            assemblyIdentity, "Celeste", 33555964, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortLantern", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortLantern",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MrOshiroDoor", "Celeste.MrOshiroDoor", "MrOshiroDoor",
            assemblyIdentity, "Celeste", 33555965, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MrOshiroDoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MrOshiroDoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Door", "Celeste.Door", "Door", assemblyIdentity, "Celeste", 33555966,
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
            "Celeste", 33555967, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+Directions", "Celeste.MoveBlock.Directions", "Directions",
            assemblyIdentity, "Celeste", 33555968, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.Directions", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.Directions",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+MovementState", "Celeste.MoveBlock.MovementState",
            "MovementState", assemblyIdentity, "Celeste", 33555969, false, new string[] { "System.Enum" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.MovementState", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.MovementState",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+Border", "Celeste.MoveBlock.Border", "Border",
            assemblyIdentity, "Celeste", 33555970, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.Border", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.Border",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+Debris", "Celeste.MoveBlock.Debris", "Debris",
            assemblyIdentity, "Celeste", 33555971, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.Debris", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.Debris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+<Controller>d__45", "Celeste.MoveBlock.<Controller>d__45",
            "<Controller>d__45", assemblyIdentity, "Celeste", 33555972, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.<Controller>d__45", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.<Controller>d__45",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MoveBlock+<SoundFollowsDebrisCenter>d__46",
            "Celeste.MoveBlock.<SoundFollowsDebrisCenter>d__46", "<SoundFollowsDebrisCenter>d__46", assemblyIdentity,
            "Celeste", 33555973, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MoveBlock.<SoundFollowsDebrisCenter>d__46", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MoveBlock.<SoundFollowsDebrisCenter>d__46",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PropLight", "Celeste.PropLight", "PropLight", assemblyIdentity,
            "Celeste", 33555974, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PropLight", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PropLight",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Debris", "Celeste.Debris", "Debris", assemblyIdentity, "Celeste",
            33555975, false,
            new string[]
            {
                "Celeste.Actor", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Debris", 1, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Debris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.FloatingDebris", "Celeste.FloatingDebris", "FloatingDebris",
            assemblyIdentity, "Celeste", 33555976, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.FloatingDebris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.FloatingDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForegroundDebris", "Celeste.ForegroundDebris", "ForegroundDebris",
            assemblyIdentity, "Celeste", 33555977, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForegroundDebris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForegroundDebris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ForegroundDebris+<>c__DisplayClass2_0",
            "Celeste.ForegroundDebris.<>c__DisplayClass2_0", "<>c__DisplayClass2_0", assemblyIdentity, "Celeste",
            33555978, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ForegroundDebris.<>c__DisplayClass2_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ForegroundDebris.<>c__DisplayClass2_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Trapdoor", "Celeste.Trapdoor", "Trapdoor", assemblyIdentity,
            "Celeste", 33555979, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Trapdoor", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Trapdoor",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Trapdoor+<OpenFromBottom>d__5",
            "Celeste.Trapdoor.<OpenFromBottom>d__5", "<OpenFromBottom>d__5", assemblyIdentity, "Celeste", 33555980,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Trapdoor.<OpenFromBottom>d__5", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Trapdoor.<OpenFromBottom>d__5",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.OldSiteChaseMusicHandler", "Celeste.OldSiteChaseMusicHandler",
            "OldSiteChaseMusicHandler", assemblyIdentity, "Celeste", 33555981, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.OldSiteChaseMusicHandler", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.OldSiteChaseMusicHandler",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PicoConsole", "Celeste.PicoConsole", "PicoConsole", assemblyIdentity,
            "Celeste", 33555982, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PicoConsole", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PicoConsole",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PicoConsole+<>c__DisplayClass8_0",
            "Celeste.PicoConsole.<>c__DisplayClass8_0", "<>c__DisplayClass8_0", assemblyIdentity, "Celeste", 33555983,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PicoConsole.<>c__DisplayClass8_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.PicoConsole.<>c__DisplayClass8_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.PicoConsole+<InteractRoutine>d__8",
            "Celeste.PicoConsole.<InteractRoutine>d__8", "<InteractRoutine>d__8", assemblyIdentity, "Celeste", 33555984,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.PicoConsole.<InteractRoutine>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.PicoConsole.<InteractRoutine>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror", "Celeste.ResortMirror", "ResortMirror",
            assemblyIdentity, "Celeste", 33555985, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<>c__DisplayClass11_0",
            "Celeste.ResortMirror.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
            33555986, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<>c__DisplayClass11_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<>c__DisplayClass11_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<>c__DisplayClass11_1",
            "Celeste.ResortMirror.<>c__DisplayClass11_1", "<>c__DisplayClass11_1", assemblyIdentity, "Celeste",
            33555987, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<>c__DisplayClass11_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<>c__DisplayClass11_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<>c__DisplayClass11_2",
            "Celeste.ResortMirror.<>c__DisplayClass11_2", "<>c__DisplayClass11_2", assemblyIdentity, "Celeste",
            33555988, false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<>c__DisplayClass11_2", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<>c__DisplayClass11_2",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<EvilAppearRoutine>d__13",
            "Celeste.ResortMirror.<EvilAppearRoutine>d__13", "<EvilAppearRoutine>d__13", assemblyIdentity, "Celeste",
            33555989, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<EvilAppearRoutine>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<EvilAppearRoutine>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<FadeLights>d__14",
            "Celeste.ResortMirror.<FadeLights>d__14", "<FadeLights>d__14", assemblyIdentity, "Celeste", 33555990, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<FadeLights>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<FadeLights>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortMirror+<SmashRoutine>d__15",
            "Celeste.ResortMirror.<SmashRoutine>d__15", "<SmashRoutine>d__15", assemblyIdentity, "Celeste", 33555991,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortMirror.<SmashRoutine>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortMirror.<SmashRoutine>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortRoofEnding", "Celeste.ResortRoofEnding", "ResortRoofEnding",
            assemblyIdentity, "Celeste", 33555992, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortRoofEnding", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortRoofEnding",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.ResortRoofEnding+<WobbleImage>d__8",
            "Celeste.ResortRoofEnding.<WobbleImage>d__8", "<WobbleImage>d__8", assemblyIdentity, "Celeste", 33555993,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.ResortRoofEnding.<WobbleImage>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.ResortRoofEnding.<WobbleImage>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy", "Celeste.BadelineDummy", "BadelineDummy",
            assemblyIdentity, "Celeste", 33555994, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy+<FloatTo>d__13", "Celeste.BadelineDummy.<FloatTo>d__13",
            "<FloatTo>d__13", assemblyIdentity, "Celeste", 33555995, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy.<FloatTo>d__13", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy.<FloatTo>d__13",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy+<WalkTo>d__14", "Celeste.BadelineDummy.<WalkTo>d__14",
            "<WalkTo>d__14", assemblyIdentity, "Celeste", 33555996, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy.<WalkTo>d__14", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy.<WalkTo>d__14",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.BadelineDummy+<SmashBlock>d__15",
            "Celeste.BadelineDummy.<SmashBlock>d__15", "<SmashBlock>d__15", assemblyIdentity, "Celeste", 33555997,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.BadelineDummy.<SmashBlock>d__15", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.BadelineDummy.<SmashBlock>d__15",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Bonfire", "Celeste.Bonfire", "Bonfire", assemblyIdentity, "Celeste",
            33555998, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Bonfire", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Bonfire",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Bonfire+Mode", "Celeste.Bonfire.Mode", "Mode", assemblyIdentity,
            "Celeste", 33555999, false, new string[] { "System.Enum" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Bonfire.Mode", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Bonfire.Mode",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror", "Celeste.DreamMirror", "DreamMirror", assemblyIdentity,
            "Celeste", 33556000, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror+<>c__DisplayClass21_0",
            "Celeste.DreamMirror.<>c__DisplayClass21_0", "<>c__DisplayClass21_0", assemblyIdentity, "Celeste", 33556001,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror.<>c__DisplayClass21_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror.<>c__DisplayClass21_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror+<>c__DisplayClass21_1",
            "Celeste.DreamMirror.<>c__DisplayClass21_1", "<>c__DisplayClass21_1", assemblyIdentity, "Celeste", 33556002,
            false, new string[] { "System.Object" }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror.<>c__DisplayClass21_1", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror.<>c__DisplayClass21_1",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror+<InteractRoutine>d__25",
            "Celeste.DreamMirror.<InteractRoutine>d__25", "<InteractRoutine>d__25", assemblyIdentity, "Celeste",
            33556003, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror.<InteractRoutine>d__25", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror.<InteractRoutine>d__25",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.DreamMirror+<BreakRoutine>d__26",
            "Celeste.DreamMirror.<BreakRoutine>d__26", "<BreakRoutine>d__26", assemblyIdentity, "Celeste", 33556004,
            false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.DreamMirror.<BreakRoutine>d__26", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.DreamMirror.<BreakRoutine>d__26",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Payphone", "Celeste.Payphone", "Payphone", assemblyIdentity,
            "Celeste", 33556005, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Payphone", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Payphone",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Lookout", "Celeste.Lookout", "Lookout", assemblyIdentity, "Celeste",
            33556006, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Lookout", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Lookout",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Lookout+Hud", "Celeste.Lookout.Hud", "Hud", assemblyIdentity,
            "Celeste", 33556007, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Lookout.Hud", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Lookout.Hud",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Lookout+<LookRoutine>d__16", "Celeste.Lookout.<LookRoutine>d__16",
            "<LookRoutine>d__16", assemblyIdentity, "Celeste", 33556008, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Lookout.<LookRoutine>d__16", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Lookout.<LookRoutine>d__16",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal", "Celeste.TempleMirrorPortal",
            "TempleMirrorPortal", assemblyIdentity, "Celeste", 33556009, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal+Debris", "Celeste.TempleMirrorPortal.Debris",
            "Debris", assemblyIdentity, "Celeste", 33556010, false, new string[] { "System.ValueType" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal.Debris", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal.Debris",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal+Bg", "Celeste.TempleMirrorPortal.Bg", "Bg",
            assemblyIdentity, "Celeste", 33556011, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal.Bg", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal.Bg",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal+Curtain", "Celeste.TempleMirrorPortal.Curtain",
            "Curtain", assemblyIdentity, "Celeste", 33556012, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal.Curtain", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal.Curtain",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal+<OnSwitchRoutine>d__19",
            "Celeste.TempleMirrorPortal.<OnSwitchRoutine>d__19", "<OnSwitchRoutine>d__19", assemblyIdentity, "Celeste",
            33556013, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal.<OnSwitchRoutine>d__19", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal.<OnSwitchRoutine>d__19",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleMirrorPortal+<ActivateRoutine>d__21",
            "Celeste.TempleMirrorPortal.<ActivateRoutine>d__21", "<ActivateRoutine>d__21", assemblyIdentity, "Celeste",
            33556014, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleMirrorPortal.<ActivateRoutine>d__21", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirrorPortal.<ActivateRoutine>d__21",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SwapBlock", "Celeste.SwapBlock", "SwapBlock", assemblyIdentity,
            "Celeste", 33556015, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SwapBlock", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SwapBlock",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SwapBlock+Themes", "Celeste.SwapBlock.Themes", "Themes",
            assemblyIdentity, "Celeste", 33556016, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SwapBlock.Themes", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SwapBlock.Themes",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.SwapBlock+PathRenderer", "Celeste.SwapBlock.PathRenderer",
            "PathRenderer", assemblyIdentity, "Celeste", 33556017, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.SwapBlock.PathRenderer", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.SwapBlock.PathRenderer",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate", "Celeste.TempleGate", "TempleGate", assemblyIdentity,
            "Celeste", 33556018, false,
            new string[]
            {
                "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate+Types", "Celeste.TempleGate.Types", "Types",
            assemblyIdentity, "Celeste", 33556019, false, new string[] { "System.Enum" }, Array.Empty<bool>(),
            assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate.Types", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate.Types",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate+<CloseBehindPlayer>d__27",
            "Celeste.TempleGate.<CloseBehindPlayer>d__27", "<CloseBehindPlayer>d__27", assemblyIdentity, "Celeste",
            33556020, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate.<CloseBehindPlayer>d__27", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate.<CloseBehindPlayer>d__27",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate+<CloseBehindPlayerAndTheo>d__28",
            "Celeste.TempleGate.<CloseBehindPlayerAndTheo>d__28", "<CloseBehindPlayerAndTheo>d__28", assemblyIdentity,
            "Celeste", 33556021, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate.<CloseBehindPlayerAndTheo>d__28", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate.<CloseBehindPlayerAndTheo>d__28",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.TempleGate+<CheckTouchSwitches>d__29",
            "Celeste.TempleGate.<CheckTouchSwitches>d__29", "<CheckTouchSwitches>d__29", assemblyIdentity, "Celeste",
            33556022, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.TempleGate.<CheckTouchSwitches>d__29", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.TempleGate.<CheckTouchSwitches>d__29",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Torch", "Celeste.Torch", "Torch", assemblyIdentity, "Celeste",
            33556023, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Torch", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Torch",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.AltMusicTrigger", "Celeste.AltMusicTrigger", "AltMusicTrigger",
            assemblyIdentity, "Celeste", 33556024, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.AltMusicTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.AltMusicTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.MusicTrigger", "Celeste.MusicTrigger", "MusicTrigger",
            assemblyIdentity, "Celeste", 33556025, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.MusicTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.MusicTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindAttackTrigger", "Celeste.WindAttackTrigger", "WindAttackTrigger",
            assemblyIdentity, "Celeste", 33556026, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindAttackTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindAttackTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.WindTrigger", "Celeste.WindTrigger", "WindTrigger", assemblyIdentity,
            "Celeste", 33556027, false,
            new string[]
            {
                "Celeste.Trigger", "Monocle.Entity", "System.Object",
                "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable"
            }, new bool[] { false }, assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.WindTrigger", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.WindTrigger",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie", "Celeste.Selfie", "Selfie", assemblyIdentity, "Celeste",
            33556028, false,
            new string[]
            {
                "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                "System.Collections.IEnumerable"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<PictureRoutine>d__7", "Celeste.Selfie.<PictureRoutine>d__7",
            "<PictureRoutine>d__7", assemblyIdentity, "Celeste", 33556029, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<PictureRoutine>d__7", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<PictureRoutine>d__7",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<>c__DisplayClass8_0", "Celeste.Selfie.<>c__DisplayClass8_0",
            "<>c__DisplayClass8_0", assemblyIdentity, "Celeste", 33556030, false, new string[] { "System.Object" },
            Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<>c__DisplayClass8_0", 0, true);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<>c__DisplayClass8_0",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<FilterRoutine>d__8", "Celeste.Selfie.<FilterRoutine>d__8",
            "<FilterRoutine>d__8", assemblyIdentity, "Celeste", 33556031, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<FilterRoutine>d__8", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<FilterRoutine>d__8",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<OpenRoutine>d__9", "Celeste.Selfie.<OpenRoutine>d__9",
            "<OpenRoutine>d__9", assemblyIdentity, "Celeste", 33556032, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<OpenRoutine>d__9", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<OpenRoutine>d__9",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
        catalog.RegisterLogicalTypeFacts("Celeste.Selfie+<WaitForInput>d__10", "Celeste.Selfie.<WaitForInput>d__10",
            "<WaitForInput>d__10", assemblyIdentity, "Celeste", 33556033, false,
            new string[]
            {
                "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            }, Array.Empty<bool>(), assembly);
        catalog.PublishDeclaredPoolFacts("Celeste.Selfie.<WaitForInput>d__10", 0, false);
        catalog.PublishDeclaredTrackedAliases("Celeste.Selfie.<WaitForInput>d__10",
            Array.Empty<Celeste.Core.Reflection.SourceTrackedAliasMetadata>());
    }
}
