using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Startup
{
    public static partial class InstalledLogicalTypeFacts
    {
        private static void RegisterPart5(SceneEntityCatalog catalog, string assemblyIdentity,
            ISourceAssemblyMetadata assembly)
        {
            catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights", "Celeste.NorthernLights", "NorthernLights",
                assemblyIdentity, "Celeste", 33555434, false, ["Celeste.Backdrop", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Strand", "Celeste.NorthernLights.Strand", "Strand",
                assemblyIdentity, "Celeste", 33555435, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Strand", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Strand",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Node", "Celeste.NorthernLights.Node", "Node",
                assemblyIdentity, "Celeste", 33555436, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Node", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Node",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NorthernLights+Particle", "Celeste.NorthernLights.Particle",
                "Particle", assemblyIdentity, "Celeste", 33555437, false, ["System.ValueType"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NorthernLights.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NorthernLights.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Petals", "Celeste.Petals", "Petals", assemblyIdentity, "Celeste",
                33555438, false, ["Celeste.Backdrop", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Petals", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Petals",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Petals+Particle", "Celeste.Petals.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555439, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Petals.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Petals.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreStarsFG", "Celeste.CoreStarsFG", "CoreStarsFG",
                assemblyIdentity,
                "Celeste", 33555440, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreStarsFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreStarsFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreStarsFG+Particle", "Celeste.CoreStarsFG.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555441, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreStarsFG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreStarsFG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionFG", "Celeste.ReflectionFG", "ReflectionFG",
                assemblyIdentity, "Celeste", 33555442, false, ["Celeste.Backdrop", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ReflectionFG+Particle", "Celeste.ReflectionFG.Particle",
                "Particle",
                assemblyIdentity, "Celeste", 33555443, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ReflectionFG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ReflectionFG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorFG", "Celeste.MirrorFG", "MirrorFG", assemblyIdentity,
                "Celeste", 33555444, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorFG", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorFG",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorFG+Particle", "Celeste.MirrorFG.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555445, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorFG.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorFG.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Tentacles", "Celeste.Tentacles", "Tentacles", assemblyIdentity,
                "Celeste", 33555446, false, ["Celeste.Backdrop", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Tentacles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Tentacles+Side", "Celeste.Tentacles.Side", "Side",
                assemblyIdentity,
                "Celeste", 33555447, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Tentacles.Side", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles.Side",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Tentacles+Tentacle", "Celeste.Tentacles.Tentacle", "Tentacle",
                assemblyIdentity, "Celeste", 33555448, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Tentacles.Tentacle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Tentacles.Tentacle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay", "Celeste.FileErrorOverlay", "FileErrorOverlay",
                assemblyIdentity, "Celeste", 33555449, false,
                [
                    "Celeste.Overlay", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+Error", "Celeste.FileErrorOverlay.Error",
                "Error",
                assemblyIdentity, "Celeste", 33555450, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.Error", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.Error",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+<>c__DisplayClass16_0",
                "Celeste.FileErrorOverlay.<>c__DisplayClass16_0", "<>c__DisplayClass16_0", assemblyIdentity, "Celeste",
                33555451, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.<>c__DisplayClass16_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.<>c__DisplayClass16_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FileErrorOverlay+<Routine>d__16",
                "Celeste.FileErrorOverlay.<Routine>d__16", "<Routine>d__16", assemblyIdentity, "Celeste", 33555452,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FileErrorOverlay.<Routine>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FileErrorOverlay.<Routine>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overlay", "Celeste.Overlay", "Overlay", assemblyIdentity,
                "Celeste",
                33555453, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overlay", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overlay",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overlay+<FadeIn>d__5", "Celeste.Overlay.<FadeIn>d__5",
                "<FadeIn>d__5",
                assemblyIdentity, "Celeste", 33555454, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overlay.<FadeIn>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overlay.<FadeIn>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Overlay+<FadeOut>d__6", "Celeste.Overlay.<FadeOut>d__6",
                "<FadeOut>d__6", assemblyIdentity, "Celeste", 33555455, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Overlay.<FadeOut>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Overlay.<FadeOut>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HiresRenderer", "Celeste.HiresRenderer", "HiresRenderer",
                assemblyIdentity, "Celeste", 33555456, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HiresRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HiresRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TrailManager", "Celeste.TrailManager", "TrailManager",
                assemblyIdentity, "Celeste", 33555457, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TrailManager", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TrailManager",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TrailManager+Snapshot", "Celeste.TrailManager.Snapshot",
                "Snapshot",
                assemblyIdentity, "Celeste", 33555458, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TrailManager.Snapshot", 1, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TrailManager.Snapshot",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ButtonUI", "Celeste.ButtonUI", "ButtonUI", assemblyIdentity,
                "Celeste", 33555459, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ButtonUI", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ButtonUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits", "Celeste.Credits", "Credits", assemblyIdentity,
                "Celeste",
                33555460, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+CreditNode", "Celeste.Credits.CreditNode", "CreditNode",
                assemblyIdentity, "Celeste", 33555461, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.CreditNode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.CreditNode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Role", "Celeste.Credits.Role", "Role", assemblyIdentity,
                "Celeste", 33555462, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Role", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Role",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Team", "Celeste.Credits.Team", "Team", assemblyIdentity,
                "Celeste", 33555463, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Team", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Team",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Thanks", "Celeste.Credits.Thanks", "Thanks",
                assemblyIdentity,
                "Celeste", 33555464, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Thanks", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Thanks",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+MultiCredit", "Celeste.Credits.MultiCredit",
                "MultiCredit",
                assemblyIdentity, "Celeste", 33555465, false,
                ["Celeste.Credits+CreditNode", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.MultiCredit", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.MultiCredit",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+MultiCredit+Section",
                "Celeste.Credits.MultiCredit.Section",
                "Section", assemblyIdentity, "Celeste", 33555466, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.MultiCredit.Section", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.MultiCredit.Section",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Ending", "Celeste.Credits.Ending", "Ending",
                assemblyIdentity,
                "Celeste", 33555467, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Ending", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Ending",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Image", "Celeste.Credits.Image", "Image",
                assemblyIdentity,
                "Celeste", 33555468, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Image", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Image",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+ImageRow", "Celeste.Credits.ImageRow", "ImageRow",
                assemblyIdentity, "Celeste", 33555469, false,
                ["Celeste.Credits+CreditNode", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.ImageRow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.ImageRow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Credits+Break", "Celeste.Credits.Break", "Break",
                assemblyIdentity,
                "Celeste", 33555470, false, ["Celeste.Credits+CreditNode", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Credits.Break", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Credits.Break",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CustomSpriteEffect", "Celeste.CustomSpriteEffect",
                "CustomSpriteEffect", assemblyIdentity, "Celeste", 33555471, false,
                ["Microsoft.Xna.Framework.Graphics.Effect"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CustomSpriteEffect", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CustomSpriteEffect",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorReflection", "Celeste.MirrorReflection", "MirrorReflection",
                assemblyIdentity, "Celeste", 33555472, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorReflection", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorReflection",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HoldableCollider", "Celeste.HoldableCollider", "HoldableCollider",
                assemblyIdentity, "Celeste", 33555473, false, ["Monocle.Component", "System.Object"],
                [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HoldableCollider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HoldableCollider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HoldableCollider+<>c__DisplayClass1_0",
                "Celeste.HoldableCollider.<>c__DisplayClass1_0", "<>c__DisplayClass1_0", assemblyIdentity, "Celeste",
                33555474, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HoldableCollider.<>c__DisplayClass1_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.HoldableCollider.<>c__DisplayClass1_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo", "Celeste.CS05_SaveTheo", "CS05_SaveTheo",
                assemblyIdentity, "Celeste", 33555475, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo+<Cutscene>d__7",
                "Celeste.CS05_SaveTheo.<Cutscene>d__7",
                "<Cutscene>d__7", assemblyIdentity, "Celeste", 33555476, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo.<Cutscene>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo.<Cutscene>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SaveTheo+<TryToBreakCrystal>d__8",
                "Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8", "<TryToBreakCrystal>d__8", assemblyIdentity, "Celeste",
                33555477, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SaveTheo.<TryToBreakCrystal>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo", "Celeste.CS05_SeeTheo", "CS05_SeeTheo",
                assemblyIdentity, "Celeste", 33555478, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<Cutscene>d__7",
                "Celeste.CS05_SeeTheo.<Cutscene>d__7",
                "<Cutscene>d__7", assemblyIdentity, "Celeste", 33555479, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<Cutscene>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<Cutscene>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<ZoomIn>d__8", "Celeste.CS05_SeeTheo.<ZoomIn>d__8",
                "<ZoomIn>d__8", assemblyIdentity, "Celeste", 33555480, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<ZoomIn>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<ZoomIn>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<MadelineTurnsAround>d__9",
                "Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9", "<MadelineTurnsAround>d__9", assemblyIdentity,
                "Celeste",
                33555481, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<MadelineTurnsAround>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<WaitABit>d__10",
                "Celeste.CS05_SeeTheo.<WaitABit>d__10",
                "<WaitABit>d__10", assemblyIdentity, "Celeste", 33555482, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<WaitABit>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<WaitABit>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<MadelineTurnsBackAndBrighten>d__11",
                "Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11", "<MadelineTurnsBackAndBrighten>d__11",
                assemblyIdentity, "Celeste", 33555483, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<MadelineTurnsBackAndBrighten>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_SeeTheo+<Brighten>d__12",
                "Celeste.CS05_SeeTheo.<Brighten>d__12",
                "<Brighten>d__12", assemblyIdentity, "Celeste", 33555484, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_SeeTheo.<Brighten>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_SeeTheo.<Brighten>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoInMirror", "Celeste.CS05_TheoInMirror",
                "CS05_TheoInMirror",
                assemblyIdentity, "Celeste", 33555485, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoInMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoInMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_TheoInMirror+<Cutscene>d__6",
                "Celeste.CS05_TheoInMirror.<Cutscene>d__6", "<Cutscene>d__6", assemblyIdentity, "Celeste", 33555486,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_TheoInMirror.<Cutscene>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_TheoInMirror.<Cutscene>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance", "Celeste.CS05_Entrance", "CS05_Entrance",
                assemblyIdentity, "Celeste", 33555487, false,
                [
                    "Celeste.CutsceneEntity", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<Cutscene>d__6",
                "Celeste.CS05_Entrance.<Cutscene>d__6",
                "<Cutscene>d__6", assemblyIdentity, "Celeste", 33555488, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<Cutscene>d__6", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<Cutscene>d__6",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<MaddyTurnsRight>d__7",
                "Celeste.CS05_Entrance.<MaddyTurnsRight>d__7", "<MaddyTurnsRight>d__7", assemblyIdentity, "Celeste",
                33555489, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<MaddyTurnsRight>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<MaddyTurnsRight>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<TheoTurns>d__8",
                "Celeste.CS05_Entrance.<TheoTurns>d__8", "<TheoTurns>d__8", assemblyIdentity, "Celeste", 33555490,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<TheoTurns>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<TheoTurns>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CS05_Entrance+<TheoLeaves>d__9",
                "Celeste.CS05_Entrance.<TheoLeaves>d__9", "<TheoLeaves>d__9", assemblyIdentity, "Celeste", 33555491,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CS05_Entrance.<TheoLeaves>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CS05_Entrance.<TheoLeaves>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Slider", "Celeste.Slider", "Slider", assemblyIdentity, "Celeste",
                33555492, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Slider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Slider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Slider+Surfaces", "Celeste.Slider.Surfaces", "Surfaces",
                assemblyIdentity, "Celeste", 33555493, false, ["System.Enum"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Slider.Surfaces", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Slider.Surfaces",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline", "Celeste.NPC05_Badeline", "NPC05_Badeline",
                assemblyIdentity, "Celeste", 33555494, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<FirstScene>d__9",
                "Celeste.NPC05_Badeline.<FirstScene>d__9", "<FirstScene>d__9", assemblyIdentity, "Celeste", 33555495,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<FirstScene>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<FirstScene>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<SecondScene>d__10",
                "Celeste.NPC05_Badeline.<SecondScene>d__10", "<SecondScene>d__10", assemblyIdentity, "Celeste",
                33555496,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<SecondScene>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<SecondScene>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Badeline+<>c__DisplayClass11_0",
                "Celeste.NPC05_Badeline.<>c__DisplayClass11_0", "<>c__DisplayClass11_0", assemblyIdentity, "Celeste",
                33555497, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Badeline.<>c__DisplayClass11_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Badeline.<>c__DisplayClass11_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Mirror", "Celeste.NPC05_Theo_Mirror",
                "NPC05_Theo_Mirror",
                assemblyIdentity, "Celeste", 33555498, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Mirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Mirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.NPC05_Theo_Entrance", "Celeste.NPC05_Theo_Entrance",
                "NPC05_Theo_Entrance", assemblyIdentity, "Celeste", 33555499, false,
                [
                    "Celeste.NPC", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.NPC05_Theo_Entrance", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.NPC05_Theo_Entrance",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleMirror", "Celeste.TempleMirror", "TempleMirror",
                assemblyIdentity, "Celeste", 33555500, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleMirror", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirror",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleMirror+Frame", "Celeste.TempleMirror.Frame", "Frame",
                assemblyIdentity, "Celeste", 33555501, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleMirror.Frame", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleMirror.Frame",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerEffectsController", "Celeste.SeekerEffectsController",
                "SeekerEffectsController", assemblyIdentity, "Celeste", 33555502, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerEffectsController", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerEffectsController",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite", "Celeste.ForsakenCitySatellite",
                "ForsakenCitySatellite", assemblyIdentity, "Celeste", 33555503, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird",
                "Celeste.ForsakenCitySatellite.CodeBird", "CodeBird", assemblyIdentity, "Celeste", 33555504, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<AimlessFlightRoutine>d__12",
                "Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", "<AimlessFlightRoutine>d__12",
                assemblyIdentity, "Celeste", 33555505, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<AimlessFlightRoutine>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<DashRoutine>d__13",
                "Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", "<DashRoutine>d__13", assemblyIdentity,
                "Celeste", 33555506, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<DashRoutine>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+CodeBird+<TransformRoutine>d__14",
                "Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", "<TransformRoutine>d__14",
                assemblyIdentity, "Celeste", 33555507, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14", 0,
                false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.CodeBird.<TransformRoutine>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+<PulseRoutine>d__28",
                "Celeste.ForsakenCitySatellite.<PulseRoutine>d__28", "<PulseRoutine>d__28", assemblyIdentity, "Celeste",
                33555508, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.<PulseRoutine>d__28", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.<PulseRoutine>d__28",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ForsakenCitySatellite+<UnlockGem>d__29",
                "Celeste.ForsakenCitySatellite.<UnlockGem>d__29", "<UnlockGem>d__29", assemblyIdentity, "Celeste",
                33555509,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ForsakenCitySatellite.<UnlockGem>d__29", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ForsakenCitySatellite.<UnlockGem>d__29",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness", "Celeste.GondolaDarkness", "GondolaDarkness",
                assemblyIdentity, "Celeste", 33555510, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+Blackness", "Celeste.GondolaDarkness.Blackness",
                "Blackness", assemblyIdentity, "Celeste", 33555511, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.Blackness", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.Blackness",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Appear>d__7",
                "Celeste.GondolaDarkness.<Appear>d__7",
                "<Appear>d__7", assemblyIdentity, "Celeste", 33555512, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Appear>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Appear>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Expand>d__8",
                "Celeste.GondolaDarkness.<Expand>d__8",
                "<Expand>d__8", assemblyIdentity, "Celeste", 33555513, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Expand>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Expand>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GondolaDarkness+<Reach>d__9",
                "Celeste.GondolaDarkness.<Reach>d__9",
                "<Reach>d__9", assemblyIdentity, "Celeste", 33555514, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GondolaDarkness.<Reach>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GondolaDarkness.<Reach>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.WhiteBlock", "Celeste.WhiteBlock", "WhiteBlock", assemblyIdentity,
                "Celeste", 33555515, false,
                [
                    "Celeste.JumpThru", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.WhiteBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.WhiteBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ChangeRespawnTrigger", "Celeste.ChangeRespawnTrigger",
                "ChangeRespawnTrigger", assemblyIdentity, "Celeste", 33555516, false,
                [
                    "Celeste.Trigger", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ChangeRespawnTrigger", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.ChangeRespawnTrigger",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustStyles", "Celeste.DustStyles", "DustStyles", assemblyIdentity,
                "Celeste", 33555517, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustStyles", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustStyles",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DustStyles+DustStyle", "Celeste.DustStyles.DustStyle",
                "DustStyle",
                assemblyIdentity, "Celeste", 33555518, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DustStyles.DustStyle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DustStyles.DustStyle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FormationBackdrop", "Celeste.FormationBackdrop",
                "FormationBackdrop",
                assemblyIdentity, "Celeste", 33555519, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FormationBackdrop", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.FormationBackdrop",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurfaces", "Celeste.MirrorSurfaces", "MirrorSurfaces",
                assemblyIdentity, "Celeste", 33555520, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurfaces", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurfaces",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MirrorSurfaces+<>c", "Celeste.MirrorSurfaces.<>c", "<>c",
                assemblyIdentity, "Celeste", 33555521, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MirrorSurfaces.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MirrorSurfaces.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ObjModel", "Celeste.ObjModel", "ObjModel", assemblyIdentity,
                "Celeste", 33555522, false, ["System.Object", "System.IDisposable"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ObjModel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ObjModel+Mesh", "Celeste.ObjModel.Mesh", "Mesh", assemblyIdentity,
                "Celeste", 33555523, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ObjModel.Mesh", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel.Mesh",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ObjModel+<>c__DisplayClass8_0",
                "Celeste.ObjModel.<>c__DisplayClass8_0", "<>c__DisplayClass8_0", assemblyIdentity, "Celeste", 33555524,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ObjModel.<>c__DisplayClass8_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ObjModel.<>c__DisplayClass8_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AutoSavingNotice", "Celeste.AutoSavingNotice", "AutoSavingNotice",
                assemblyIdentity, "Celeste", 33555525, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AutoSavingNotice", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AutoSavingNotice",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer", "Celeste.CompleteRenderer", "CompleteRenderer",
                assemblyIdentity, "Celeste", 33555526, false,
                ["Celeste.HiresRenderer", "System.IDisposable", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+Layer", "Celeste.CompleteRenderer.Layer",
                "Layer",
                assemblyIdentity, "Celeste", 33555527, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.Layer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.Layer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+UILayer", "Celeste.CompleteRenderer.UILayer",
                "UILayer", assemblyIdentity, "Celeste", 33555528, false,
                ["Celeste.CompleteRenderer+Layer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.UILayer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.UILayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+ImageLayer",
                "Celeste.CompleteRenderer.ImageLayer",
                "ImageLayer", assemblyIdentity, "Celeste", 33555529, false,
                ["Celeste.CompleteRenderer+Layer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.ImageLayer", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.ImageLayer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+<SlideRoutine>d__23",
                "Celeste.CompleteRenderer.<SlideRoutine>d__23", "<SlideRoutine>d__23", assemblyIdentity, "Celeste",
                33555530, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.<SlideRoutine>d__23", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.<SlideRoutine>d__23",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+LayerNoXML",
                "Celeste.CompleteRenderer.LayerNoXML",
                "LayerNoXML", assemblyIdentity, "Celeste", 33555531, true,
                ["Celeste.CompleteRenderer+Layer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.LayerNoXML", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.LayerNoXML",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+UILayerNoXML",
                "Celeste.CompleteRenderer.UILayerNoXML", "UILayerNoXML", assemblyIdentity, "Celeste", 33555532, false,
                ["Celeste.CompleteRenderer+UILayer", "Celeste.CompleteRenderer+Layer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.UILayerNoXML", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.UILayerNoXML",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CompleteRenderer+ImageLayerNoXML",
                "Celeste.CompleteRenderer.ImageLayerNoXML", "ImageLayerNoXML", assemblyIdentity, "Celeste", 33555533,
                false,
                ["Celeste.CompleteRenderer+ImageLayer", "Celeste.CompleteRenderer+Layer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CompleteRenderer.ImageLayerNoXML", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CompleteRenderer.ImageLayerNoXML",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HiresSnow", "Celeste.HiresSnow", "HiresSnow", assemblyIdentity,
                "Celeste", 33555534, false, ["Monocle.Renderer", "System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HiresSnow", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HiresSnow",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HiresSnow+Particle", "Celeste.HiresSnow.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555535, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HiresSnow.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HiresSnow.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI", "Celeste.KeyboardConfigUI", "KeyboardConfigUI",
                assemblyIdentity, "Celeste", 33555536, false,
                [
                    "Celeste.TextMenu", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI+<>c__DisplayClass12_0",
                "Celeste.KeyboardConfigUI.<>c__DisplayClass12_0", "<>c__DisplayClass12_0", assemblyIdentity, "Celeste",
                33555537, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI.<>c__DisplayClass12_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI.<>c__DisplayClass12_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyboardConfigUI+<>c__DisplayClass20_0",
                "Celeste.KeyboardConfigUI.<>c__DisplayClass20_0", "<>c__DisplayClass20_0", assemblyIdentity, "Celeste",
                33555538, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyboardConfigUI.<>c__DisplayClass20_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyboardConfigUI.<>c__DisplayClass20_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard", "Celeste.Postcard", "Postcard", assemblyIdentity,
                "Celeste", 33555539, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<DisplayRoutine>d__13",
                "Celeste.Postcard.<DisplayRoutine>d__13", "<DisplayRoutine>d__13", assemblyIdentity, "Celeste",
                33555540,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<DisplayRoutine>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<DisplayRoutine>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseIn>d__14", "Celeste.Postcard.<EaseIn>d__14",
                "<EaseIn>d__14", assemblyIdentity, "Celeste", 33555541, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseIn>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseIn>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseButtinIn>d__15",
                "Celeste.Postcard.<EaseButtinIn>d__15",
                "<EaseButtinIn>d__15", assemblyIdentity, "Celeste", 33555542, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseButtinIn>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseButtinIn>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Postcard+<EaseOut>d__16", "Celeste.Postcard.<EaseOut>d__16",
                "<EaseOut>d__16", assemblyIdentity, "Celeste", 33555543, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Postcard.<EaseOut>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Postcard.<EaseOut>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveLoadIcon", "Celeste.SaveLoadIcon", "SaveLoadIcon",
                assemblyIdentity, "Celeste", 33555544, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveLoadIcon", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveLoadIcon",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SaveLoadIcon+<Routine>d__9", "Celeste.SaveLoadIcon.<Routine>d__9",
                "<Routine>d__9", assemblyIdentity, "Celeste", 33555545, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SaveLoadIcon.<Routine>d__9", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SaveLoadIcon.<Routine>d__9",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu", "Celeste.TextMenu", "TextMenu", assemblyIdentity,
                "Celeste", 33555546, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+InnerContentMode", "Celeste.TextMenu.InnerContentMode",
                "InnerContentMode", assemblyIdentity, "Celeste", 33555547, false, ["System.Enum"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.InnerContentMode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.InnerContentMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Item", "Celeste.TextMenu.Item", "Item", assemblyIdentity,
                "Celeste", 33555548, true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Item", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Item",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Header", "Celeste.TextMenu.Header", "Header",
                assemblyIdentity, "Celeste", 33555549, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Header", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Header",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+SubHeader", "Celeste.TextMenu.SubHeader", "SubHeader",
                assemblyIdentity, "Celeste", 33555550, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.SubHeader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.SubHeader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Option`1", "Celeste.TextMenu.Option`1", "Option`1",
                assemblyIdentity, "Celeste", 33555551, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Option`1", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Option`1",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Option`1+<>c", "Celeste.TextMenu.Option`1.<>c", "<>c",
                assemblyIdentity, "Celeste", 33555552, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Option`1.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Option`1.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Slider", "Celeste.TextMenu.Slider", "Slider",
                assemblyIdentity, "Celeste", 33555553, false,
                ["Celeste.TextMenu+Option`1<System.Int32>", "Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Slider", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Slider",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+OnOff", "Celeste.TextMenu.OnOff", "OnOff",
                assemblyIdentity,
                "Celeste", 33555554, false,
                ["Celeste.TextMenu+Option`1<System.Boolean>", "Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.OnOff", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.OnOff",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Setting", "Celeste.TextMenu.Setting", "Setting",
                assemblyIdentity, "Celeste", 33555555, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Setting", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Setting",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+Button", "Celeste.TextMenu.Button", "Button",
                assemblyIdentity, "Celeste", 33555556, false, ["Celeste.TextMenu+Item", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.Button", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.Button",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+LanguageButton", "Celeste.TextMenu.LanguageButton",
                "LanguageButton", assemblyIdentity, "Celeste", 33555557, false,
                ["Celeste.TextMenu+Item", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.LanguageButton", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.LanguageButton",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+<CloseAndRunRoutine>d__54",
                "Celeste.TextMenu.<CloseAndRunRoutine>d__54", "<CloseAndRunRoutine>d__54", assemblyIdentity, "Celeste",
                33555558, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.<CloseAndRunRoutine>d__54", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.<CloseAndRunRoutine>d__54",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TextMenu+<>c", "Celeste.TextMenu.<>c", "<>c", assemblyIdentity,
                "Celeste", 33555559, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TextMenu.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TextMenu.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.ViewportAdjustmentUI", "Celeste.ViewportAdjustmentUI",
                "ViewportAdjustmentUI", assemblyIdentity, "Celeste", 33555560, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.ViewportAdjustmentUI", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.ViewportAdjustmentUI",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartWipe", "Celeste.HeartWipe", "HeartWipe", assemblyIdentity,
                "Celeste", 33555561, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.KeyDoorWipe", "Celeste.KeyDoorWipe", "KeyDoorWipe",
                assemblyIdentity,
                "Celeste", 33555562, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.KeyDoorWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.KeyDoorWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.FallWipe", "Celeste.FallWipe", "FallWipe", assemblyIdentity,
                "Celeste", 33555563, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.FallWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.FallWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainWipe", "Celeste.MountainWipe", "MountainWipe",
                assemblyIdentity, "Celeste", 33555564, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AngledWipe", "Celeste.AngledWipe", "AngledWipe", assemblyIdentity,
                "Celeste", 33555565, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AngledWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AngledWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DropWipe", "Celeste.DropWipe", "DropWipe", assemblyIdentity,
                "Celeste", 33555566, false, ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DropWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DropWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightingRenderer", "Celeste.LightingRenderer", "LightingRenderer",
                assemblyIdentity, "Celeste", 33555567, false, ["Monocle.Renderer", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightingRenderer", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightingRenderer",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LightingRenderer+VertexPositionColorMaskTexture",
                "Celeste.LightingRenderer.VertexPositionColorMaskTexture", "VertexPositionColorMaskTexture",
                assemblyIdentity, "Celeste", 33555568, false,
                ["System.ValueType", "Microsoft.Xna.Framework.Graphics.IVertexType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LightingRenderer.VertexPositionColorMaskTexture", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LightingRenderer.VertexPositionColorMaskTexture",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarfieldWipe", "Celeste.StarfieldWipe", "StarfieldWipe",
                assemblyIdentity, "Celeste", 33555569, false,
                ["Celeste.ScreenWipe", "Monocle.Renderer", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarfieldWipe", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarfieldWipe",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.StarfieldWipe+Star", "Celeste.StarfieldWipe.Star", "Star",
                assemblyIdentity, "Celeste", 33555570, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.StarfieldWipe.Star", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.StarfieldWipe.Star",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OVR", "Celeste.OVR", "OVR", assemblyIdentity, "Celeste", 33555571,
                true, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OVR", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OVR",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewPostcard", "Celeste.PreviewPostcard", "PreviewPostcard",
                assemblyIdentity, "Celeste", 33555572, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewPostcard", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPostcard",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewPostcard+<Routine>d__2",
                "Celeste.PreviewPostcard.<Routine>d__2", "<Routine>d__2", assemblyIdentity, "Celeste", 33555573, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewPostcard.<Routine>d__2", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewPostcard.<Routine>d__2",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.PreviewRecording", "Celeste.PreviewRecording", "PreviewRecording",
                assemblyIdentity, "Celeste", 33555574, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.PreviewRecording", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.PreviewRecording",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameLoader", "Celeste.GameLoader", "GameLoader", assemblyIdentity,
                "Celeste", 33555575, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameLoader", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameLoader+<IntroRoutine>d__16",
                "Celeste.GameLoader.<IntroRoutine>d__16", "<IntroRoutine>d__16", assemblyIdentity, "Celeste", 33555576,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameLoader.<IntroRoutine>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader.<IntroRoutine>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameLoader+<FadeInOut>d__17",
                "Celeste.GameLoader.<FadeInOut>d__17",
                "<FadeInOut>d__17", assemblyIdentity, "Celeste", 33555577, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameLoader.<FadeInOut>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader.<FadeInOut>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.GameLoader+<>c", "Celeste.GameLoader.<>c", "<>c",
                assemblyIdentity,
                "Celeste", 33555578, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.GameLoader.<>c", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.GameLoader.<>c",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.IOverlayHandler", "Celeste.IOverlayHandler", "IOverlayHandler",
                assemblyIdentity, "Celeste", 33555579, true, [], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.IOverlayHandler", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.IOverlayHandler",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Maddy3D", "Celeste.Maddy3D", "Maddy3D", assemblyIdentity,
                "Celeste",
                33555580, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Maddy3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Maddy3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonParticle3D", "Celeste.MoonParticle3D", "MoonParticle3D",
                assemblyIdentity, "Celeste", 33555581, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonParticle3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonParticle3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MoonParticle3D+Particle", "Celeste.MoonParticle3D.Particle",
                "Particle", assemblyIdentity, "Celeste", 33555582, false,
                ["Celeste.Billboard", "Monocle.Component", "System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MoonParticle3D.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MoonParticle3D.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow3D", "Celeste.Snow3D", "Snow3D", assemblyIdentity, "Celeste",
                33555583, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow3D", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow3D",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Snow3D+Particle", "Celeste.Snow3D.Particle", "Particle",
                assemblyIdentity, "Celeste", 33555584, false,
                ["Celeste.Billboard", "Monocle.Component", "System.Object"], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Snow3D.Particle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Snow3D.Particle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalGlobal", "Celeste.OuiJournalGlobal", "OuiJournalGlobal",
                assemblyIdentity, "Celeste", 33555585, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalGlobal", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalGlobal",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode", "Celeste.OuiAssistMode", "OuiAssistMode",
                assemblyIdentity, "Celeste", 33555586, false,
                [
                    "Celeste.Oui", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+Page", "Celeste.OuiAssistMode.Page", "Page",
                assemblyIdentity, "Celeste", 33555587, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.Page", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.Page",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<Enter>d__16", "Celeste.OuiAssistMode.<Enter>d__16",
                "<Enter>d__16", assemblyIdentity, "Celeste", 33555588, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<Enter>d__16", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<Enter>d__16",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<Leave>d__17", "Celeste.OuiAssistMode.<Leave>d__17",
                "<Leave>d__17", assemblyIdentity, "Celeste", 33555589, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<Leave>d__17", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<Leave>d__17",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiAssistMode+<InputRoutine>d__18",
                "Celeste.OuiAssistMode.<InputRoutine>d__18", "<InputRoutine>d__18", assemblyIdentity, "Celeste",
                33555590,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiAssistMode.<InputRoutine>d__18", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiAssistMode.<InputRoutine>d__18",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette", "Celeste.CoreVignette", "CoreVignette",
                assemblyIdentity, "Celeste", 33555591, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette+<TextSequence>d__15",
                "Celeste.CoreVignette.<TextSequence>d__15", "<TextSequence>d__15", assemblyIdentity, "Celeste",
                33555592,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette.<TextSequence>d__15", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette.<TextSequence>d__15",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.CoreVignette+<>c__DisplayClass20_0",
                "Celeste.CoreVignette.<>c__DisplayClass20_0", "<>c__DisplayClass20_0", assemblyIdentity, "Celeste",
                33555593, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.CoreVignette.<>c__DisplayClass20_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.CoreVignette.<>c__DisplayClass20_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Achievement", "Celeste.Achievement", "Achievement",
                assemblyIdentity,
                "Celeste", 33555594, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Achievement", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Achievement",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Achievements", "Celeste.Achievements", "Achievements",
                assemblyIdentity, "Celeste", 33555595, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Achievements", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Achievements",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BinaryPacker", "Celeste.BinaryPacker", "BinaryPacker",
                assemblyIdentity, "Celeste", 33555596, true, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BinaryPacker", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.BinaryPacker",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.BinaryPacker+Element", "Celeste.BinaryPacker.Element", "Element",
                assemblyIdentity, "Celeste", 33555597, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.BinaryPacker.Element", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.BinaryPacker.Element",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter", "Celeste.LevelEnter", "LevelEnter", assemblyIdentity,
                "Celeste", 33555598, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle", "Celeste.LevelEnter.BSideTitle",
                "BSideTitle",
                assemblyIdentity, "Celeste", 33555599, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseIn>d__10",
                "Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", "<EaseIn>d__10", assemblyIdentity, "Celeste", 33555600,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseIn>d__10",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<EaseOut>d__11",
                "Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", "<EaseOut>d__11", assemblyIdentity, "Celeste", 33555601,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<EaseOut>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+BSideTitle+<FadeTo>d__12",
                "Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", "<FadeTo>d__12", assemblyIdentity, "Celeste", 33555602,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.BSideTitle.<FadeTo>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+<Routine>d__5", "Celeste.LevelEnter.<Routine>d__5",
                "<Routine>d__5", assemblyIdentity, "Celeste", 33555603, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.<Routine>d__5", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.<Routine>d__5",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+<EnterWithPostcardRoutine>d__13",
                "Celeste.LevelEnter.<EnterWithPostcardRoutine>d__13", "<EnterWithPostcardRoutine>d__13",
                assemblyIdentity,
                "Celeste", 33555604, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.<EnterWithPostcardRoutine>d__13", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.<EnterWithPostcardRoutine>d__13",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelEnter+<ErrorRoutine>d__11",
                "Celeste.LevelEnter.<ErrorRoutine>d__11", "<ErrorRoutine>d__11", assemblyIdentity, "Celeste", 33555605,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>",
                    "System.Collections.IEnumerator", "System.IDisposable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelEnter.<ErrorRoutine>d__11", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelEnter.<ErrorRoutine>d__11",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainCamera", "Celeste.MountainCamera", "MountainCamera",
                assemblyIdentity, "Celeste", 33555606, false, ["System.ValueType"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainCamera", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainCamera",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainState", "Celeste.MountainState", "MountainState",
                assemblyIdentity, "Celeste", 33555607, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainState", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Skybox", "Celeste.Skybox", "Skybox", assemblyIdentity, "Celeste",
                33555608, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Skybox", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Skybox",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.Ring", "Celeste.Ring", "Ring", assemblyIdentity, "Celeste",
                33555609,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.Ring", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.Ring",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainModel", "Celeste.MountainModel", "MountainModel",
                assemblyIdentity, "Celeste", 33555610, false, ["System.Object", "System.IDisposable"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainModel", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainModel",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainModel+<>c__DisplayClass48_0",
                "Celeste.MountainModel.<>c__DisplayClass48_0", "<>c__DisplayClass48_0", assemblyIdentity, "Celeste",
                33555611, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainModel.<>c__DisplayClass48_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainModel.<>c__DisplayClass48_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MountainModel+<>c__DisplayClass50_0",
                "Celeste.MountainModel.<>c__DisplayClass50_0", "<>c__DisplayClass50_0", assemblyIdentity, "Celeste",
                33555612, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MountainModel.<>c__DisplayClass50_0", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MountainModel.<>c__DisplayClass50_0",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldLoader", "Celeste.OverworldLoader", "OverworldLoader",
                assemblyIdentity, "Celeste", 33555613, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldLoader", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldLoader",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldLoader+<Routine>d__12",
                "Celeste.OverworldLoader.<Routine>d__12", "<Routine>d__12", assemblyIdentity, "Celeste", 33555614,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldLoader.<Routine>d__12", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldLoader.<Routine>d__12",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall", "Celeste.OverworldReflectionsFall",
                "OverworldReflectionsFall", assemblyIdentity, "Celeste", 33555615, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall+<Routine>d__7",
                "Celeste.OverworldReflectionsFall.<Routine>d__7", "<Routine>d__7", assemblyIdentity, "Celeste",
                33555616,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall.<Routine>d__7", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall.<Routine>d__7",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OverworldReflectionsFall+<MaddyFall>d__8",
                "Celeste.OverworldReflectionsFall.<MaddyFall>d__8", "<MaddyFall>d__8", assemblyIdentity, "Celeste",
                33555617, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OverworldReflectionsFall.<MaddyFall>d__8", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OverworldReflectionsFall.<MaddyFall>d__8",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.OuiJournalDeaths", "Celeste.OuiJournalDeaths", "OuiJournalDeaths",
                assemblyIdentity, "Celeste", 33555618, false, ["Celeste.OuiJournalPage", "System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.OuiJournalDeaths", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.OuiJournalDeaths",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TestBreathingGame", "Celeste.TestBreathingGame",
                "TestBreathingGame",
                assemblyIdentity, "Celeste", 33555619, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TestBreathingGame", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.TestBreathingGame",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelExit", "Celeste.LevelExit", "LevelExit", assemblyIdentity,
                "Celeste", 33555620, false,
                [
                    "Monocle.Scene", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelExit", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelExit+Mode", "Celeste.LevelExit.Mode", "Mode",
                assemblyIdentity,
                "Celeste", 33555621, false, ["System.Enum"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelExit.Mode", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit.Mode",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.LevelExit+<Routine>d__14", "Celeste.LevelExit.<Routine>d__14",
                "<Routine>d__14", assemblyIdentity, "Celeste", 33555622, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.LevelExit.<Routine>d__14", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.LevelExit.<Routine>d__14",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaCompleteTitle", "Celeste.AreaCompleteTitle",
                "AreaCompleteTitle",
                assemblyIdentity, "Celeste", 33555623, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaCompleteTitle", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaCompleteTitle",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AreaCompleteTitle+Letter", "Celeste.AreaCompleteTitle.Letter",
                "Letter", assemblyIdentity, "Celeste", 33555624, false, ["System.Object"],
                [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AreaCompleteTitle.Letter", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.AreaCompleteTitle.Letter",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.MEP", "Celeste.MEP", "MEP", assemblyIdentity, "Celeste", 33555625,
                false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.MEP", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.MEP",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AudioTrackState", "Celeste.AudioTrackState", "AudioTrackState",
                assemblyIdentity, "Celeste", 33555626, false, ["System.Object"], [],
                assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AudioTrackState", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AudioTrackState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.AudioState", "Celeste.AudioState", "AudioState", assemblyIdentity,
                "Celeste", 33555627, false, ["System.Object"], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.AudioState", 0, true);
            catalog.PublishDeclaredTrackedAliases("Celeste.AudioState",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.SeekerBarrier", "Celeste.SeekerBarrier", "SeekerBarrier",
                assemblyIdentity, "Celeste", 33555628, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.SeekerBarrier", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.SeekerBarrier",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.TempleCrackedBlock", "Celeste.TempleCrackedBlock",
                "TempleCrackedBlock", assemblyIdentity, "Celeste", 33555629, false,
                [
                    "Celeste.Solid", "Celeste.Platform", "Monocle.Entity", "System.Object",
                    "System.Collections.Generic.IEnumerable`1<Monocle.Component>", "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.TempleCrackedBlock", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.TempleCrackedBlock",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.DreamHeartGem", "Celeste.DreamHeartGem", "DreamHeartGem",
                assemblyIdentity, "Celeste", 33555630, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.DreamHeartGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.DreamHeartGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGem", "Celeste.HeartGem", "HeartGem", assemblyIdentity,
                "Celeste", 33555631, false,
                [
                    "Monocle.Entity", "System.Object", "System.Collections.Generic.IEnumerable`1<Monocle.Component>",
                    "System.Collections.IEnumerable",
                ], [false], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGem", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGem",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGem+<CollectRoutine>d__35",
                "Celeste.HeartGem.<CollectRoutine>d__35", "<CollectRoutine>d__35", assemblyIdentity, "Celeste",
                33555632,
                false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGem.<CollectRoutine>d__35", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGem.<CollectRoutine>d__35",
                []);
            catalog.RegisterLogicalTypeFacts("Celeste.HeartGem+<DoFakeRoutineWithBird>d__38",
                "Celeste.HeartGem.<DoFakeRoutineWithBird>d__38", "<DoFakeRoutineWithBird>d__38", assemblyIdentity,
                "Celeste", 33555633, false,
                [
                    "System.Object", "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ], [], assembly);
            catalog.PublishDeclaredPoolFacts("Celeste.HeartGem.<DoFakeRoutineWithBird>d__38", 0, false);
            catalog.PublishDeclaredTrackedAliases("Celeste.HeartGem.<DoFakeRoutineWithBird>d__38",
                []);
        }
    }
}
