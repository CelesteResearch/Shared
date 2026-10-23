using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishInstalled107(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116311,
                "offScreenX", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x00, 0x00, 0xF0, 0xC4]), "System.Single",
                "0000F0C4", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116312,
                "PageTurningLocked", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116313,
                "Pages",
                SourceMemberKind.Field, 6, "System.Collections.Generic.List`1<Celeste.OuiJournalPage>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournalPage"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116314,
                "PageIndex", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116315,
                "CurrentPageBuffer", SourceMemberKind.Field, 6, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116316,
                "NextPageBuffer", SourceMemberKind.Field, 6, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116317,
                "turningPage", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116318,
                "turningScale", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116319,
                "backColor", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116320,
                "fromAreaInspect", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116321,
                "rotation", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116322,
                "cameraStart", SourceMemberKind.Field, 1, "Celeste.MountainCamera", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainCamera")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116323,
                "cameraEnd", SourceMemberKind.Field, 1, "Celeste.MountainCamera", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainCamera")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116324,
                "arrow",
                SourceMemberKind.Field, 1, "Monocle.MTexture", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.MTexture")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116325, "dot",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116326,
                "dotTarget", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116327,
                "dotEase",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116328,
                "leftArrowEase", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 67116329,
                "rightArrowEase", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 385877366,
                "Page",
                SourceMemberKind.Property, 0, "Celeste.OuiJournalPage", 2182, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 385877367,
                "NextPage", SourceMemberKind.Property, 0, "Celeste.OuiJournalPage", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 385877368,
                "PrevPage", SourceMemberKind.Property, 0, "Celeste.OuiJournalPage", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                67116330, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                67116331, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                67116332, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                67116333, "from", SourceMemberKind.Field, 6, "Celeste.Oui", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Oui")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                67116334, "<p>5__2", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                385877369, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                385877370, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                67116335, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                67116336, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                67116337, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                67116338, "direction", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                385877371, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                385877372, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                33555864, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                67116339, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                67116340, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                67116341, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                385877373, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                385877374, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                33555865, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116342, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116343, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116344, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116345, "duration", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116346, "<rotFrom>5__2", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                67116347, "<p>5__3", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                385877375, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<EaseOut>d__30",
                385877376, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                33555866, 1048835, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.Collections.IEnumerator",
                    "System.IDisposable",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.IEnumerator"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                67116348, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                67116349, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                67116350, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                67116351, "from", SourceMemberKind.Field, 6, "Celeste.Oui", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Oui")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                67116352, "<orig>5__2", SourceMemberKind.Field, 1, "System.Collections.IEnumerator", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Collections.IEnumerator")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                385877377, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__1",
                385877378, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalCover", 33555867,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 33555868,
                1048705, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116353,
                "PageWidth", SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x4A, 0x06, 0x00, 0x00]), "System.Int32",
                "4A060000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116354,
                "PageHeight", SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xE8, 0x03, 0x00, 0x00]), "System.Int32",
                "E8030000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116355,
                "TextJustify", SourceMemberKind.Field, 38, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116356,
                "TextScale", SourceMemberKind.Field, 32854, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x3F]), "System.Single",
                "0000003F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116357,
                "TextColor", SourceMemberKind.Field, 38, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116358,
                "PageIndex", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116359,
                "PageTexture", SourceMemberKind.Field, 6, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage", 67116360,
                "Journal", SourceMemberKind.Field, 6, "Celeste.OuiJournal", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournal")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                33555869,
                1048578, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                67116361,
                "headerHeight", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x00, 0x00, 0xA0, 0x42]), "System.Single",
                "0000A042", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                67116362,
                "headerBottomMargin", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x00, 0x00, 0xA0, 0x41]), "System.Single",
                "0000A041", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                67116363,
                "rowHeight", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x70, 0x42]), "System.Single",
                "00007042", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                67116364,
                "rows", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Celeste.OuiJournalPage+Row>", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournalPage+Row"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                385877379,
                "Rows", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Table",
                385877380,
                "Header", SourceMemberKind.Property, 0, "Celeste.OuiJournalPage+Row", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Row")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Row",
                33555870,
                1048578, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
                [
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Row",
                67116365,
                "Entries", SourceMemberKind.Field, 6, "System.Collections.Generic.List`1<Celeste.OuiJournalPage+Cell>",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournalPage+Cell"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Row",
                385877381,
                "Count", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Row",
                385877382,
                "Item", SourceMemberKind.Property, 0, "Celeste.OuiJournalPage+Cell", 2182, -1, 1,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Cell")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Cell",
                33555871,
                1048706, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+Cell",
                67116366,
                "SpreadOverColumns", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+EmptyCell",
                33555872, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiJournalPage+Cell", [], [], null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Cell"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+EmptyCell",
                67116367, "width", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                33555873, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiJournalPage+Cell", [], [], null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Cell"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116368, "text", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116369, "justify", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116370, "scale", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116371, "color", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116372, "width", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+TextCell",
                67116373, "forceWidth", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+IconCell",
                33555874, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiJournalPage+Cell", [], [], null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Cell"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+IconCell",
                67116374, "icon", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+IconCell",
                67116375, "width", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage+IconsCell",
                33555875, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiJournalPage+Cell", [], [], null,
                [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Cell"),
                []));
        }
    }
}
